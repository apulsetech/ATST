using Apulsetech.Event;
using Apulsetech.Rfid.Type;
using Apulsetech.Util;
using ATST.Data;
using ATST.Diagnotics;
using ATST.Forms.Diagnotics;
using ATST.Forms.Settings;
using ATST.GlobalKey;
using ATST.Properties;
using ATST.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using UserControls.Controls;
using static System.Windows.Forms.AxHost;

namespace ATST.Forms
{
    public partial class MainForm : Form, ReaderEventListener
    {
        private SearchForm searchForm = null;

        private Log.LogEventHandler m_fnOutputLog;

        // Log창 닫혀있을때 로그 저장할 텍스트박스
        public TextBox txb = new TextBox();

        // 바인딩 리스트를 사용하기 위한 리스트
        private BindingList<object> BindingList = new BindingList<object>();

        public MainForm()
        {
            InitializeComponent();
            Initialize();

            Log.OutputLog += this.OutputLog;

            m_fnOutputLog = new Log.LogEventHandler(OutputLog); // Invoke시 사용하거나 Event의 콜백메서드를 삭제하기 위함.

            SearchForm.OpenFormEvent += new SearchForm.OpenFormReturn(ReturnForm);  // 활성화된 장비검색폼 객체를 리턴한다.
            this.KeyPreview = true; // 폼이 모든 키 이벤트를 받게함. -> ESC 키를 눌렀을때 폼이 이벤트 핸들러가 발생될 수 있게하기 위함.

            SharedValues.ReaderConnected = false;
            tablePanel1.set_TagDataView_Size(90, 80, 640, 560);
            tablePanel1.set_TagDataView_Font(12, 30);
        }

        private void Initialize()
        {
            // 이름 따로 설정안하면 ApplyResources에서 Name이 Null로 나옴
            //listview_rfid_inventory_tag_data.Columns[0].Name = "column_tag_value";
            //listview_rfid_inventory_tag_data.Columns[1].Name = "column_tag_rssi";
            //listview_rfid_inventory_tag_data.Columns[2].Name = "column_tag_port";

            EnableControl(false);
            InitializeCreateConfig();
        }

        
        private void InitializeCreateConfig()
        {
            CreateConfig.MainConfig();
        }

        // Config 정보 불러오기
        private void LoadConfigInfo(int antCount)
        {
            if (SharedValues.Reader != null)
            {
                for (int i = 0; i < antCount; i++)
                {
                    SharedValues.Reader.SetAntennaPortState(i, Config.AntStates[i] ? RFID.ON : RFID.OFF);
                    SharedValues.Reader.SetRadioPower(i, Config.AntPowerGains[i]);
                    SharedValues.Reader.SetDwellTime(i, Config.AntDwellTimes[i]);
                }
            }
        }

        // 컨트롤 사용가능 여부 체크
        private void EnableControl(bool enable)
        {
            btn_rfid_connect.Enabled = enable;
            btn_rfid_inventory.Enabled = enable;
            deviceSettingToolStripMenuItem.Enabled = enable;
        }

        public void OutputLog(String msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_fnOutputLog, msg);
                return;
            }

            txb.AppendText(msg);
            txb.Select(txb.TextLength, 0);
            txb.ScrollToCaret();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CultureInfo current = LoadCultureInfo();
            Thread.CurrentThread.CurrentUICulture = current;
            Thread.CurrentThread.CurrentCulture = current;
            Resources.Culture = current;

            SetCulture(current);

            DeviceConnectSetting();
        }

        private void DeviceConnectSetting()
        {
            using (AccessForm dlg = new AccessForm(this))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (SharedValues.ReaderConnected)
                    {
                        if (SharedValues.WebInterLockCheck)
                        {
                            lbServerConnectState.Text = SharedValues.DeviceId + "/" + SharedValues.DeviceName;
                            lbServerConnectState.BackColor = Color.Lime;
                        }
                        else
                        {
                            lbServerConnectState.Text = null;
                            lbServerConnectState.BackColor = Color.Red;
                        }

                        for (int i = 0; i < 128; i++)
                        {
                            tablePanel1.DataViewFontSize(i);
                        }

                        if (SharedValues.WebInterLockCheck)
                            DataFormat.UpdateColRowNum(SharedValues.DeviceId, Config.Panel_Column, Config.Panel_Row);

                        // 판넬 사이즈 자동 조정
                        if (SharedValues.SelectedPortCount > 0)
                        {
                            if (SharedValues.SelectedPortCount == 1)
                            {
                                Config.Panel_Row = SharedValues.SelectedPortCount;
                                Config.Panel_Column = 0;
                            }

                            int PortCount = SharedValues.SelectedPortCount;
                            List<int> factorization = new List<int>();
                            // 2로 나누었을때
                            // 3으로 나누었을때
                            // 자신으로 나누었을때 -> 소인수분해 끝
                            while (PortCount != 1)
                            {
                                if (PortCount % 2 == 0)
                                {
                                    PortCount = PortCount / 2;
                                    factorization.Add(2);
                                    continue;
                                }
                                else if (PortCount % 3 == 0)
                                {
                                    PortCount = PortCount / 3;
                                    factorization.Add(3);
                                    continue;
                                }
                                else
                                {
                                    PortCount = PortCount / PortCount;
                                }
                            }

                            // 소인수분해 후 가장 작은 두수를 곱하는 것을 수가 인자가 2개만 남을때까지 계속 진행한다.
                            if (factorization.Count == 2)
                            {
                                Config.Panel_Row = factorization.Min();
                                Config.Panel_Column = factorization.Max();
                            }
                            else
                            {
                                while (factorization.Count != 2)
                                {
                                    int minnumber = factorization.Min();
                                    factorization.Remove(minnumber);
                                    int minnumber2 = factorization.Min();
                                    factorization.Remove(minnumber2);
                                    int mulnumber = minnumber * minnumber2;
                                    factorization.Add(mulnumber);
                                }

                                Config.Panel_Row = factorization.Min();
                                Config.Panel_Column = factorization.Max();
                            }
                        }
                        tablePanel1.set_panel(Config.Panel_Column, Config.Panel_Row);

                        // 판넬 클릭 이벤트 생성
                        AddEvent();

                        // 메인폼 클리어
                        ItemClear();
                        this.Visible = true;
                    }
                    else
                    {
                        this.Close();
                    }

                }
            }
        }
        private void ItemClear()
        {
            EnableControl(true);
            for (int i = 0; i < SharedValues.NumberOfAntennaPorts; i++)
            {
                tablePanel1.DataViewTagCntNum(i, 0);
            }

            txbEPC.Text = null;
            listViewSearchList.Items.Clear();
            listviewTagList.Items.Clear();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kor, Eng 메뉴 아이템 중 누가 이벤트를 호출했는가
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            CultureInfo cultureInfo = null;

            // mCurrentLangMenu가 null이 아닐때
            // 지금 이벤트 호출하기 전 Kor이 만약 그전에 클릭되어 있었다면 false처리
            if (mCurrentLangMenu != null)
                mCurrentLangMenu.Checked = false;
            if (menu == engToolStripMenuItem)
            {
                // 영어로 문화권 정보 바꿔주고
                cultureInfo = new CultureInfo("en-US");
                // 현재 어떤 메뉴가 눌렸는지 저장
                mCurrentLangMenu = engToolStripMenuItem;
            }
            else if (menu == korToolStripMenuItem)
            {
                cultureInfo = new CultureInfo("ko-KR");
                mCurrentLangMenu = korToolStripMenuItem;
            }
            if (cultureInfo != null)
            {
                Config.CultureName = cultureInfo.Name;
                // 서브 폼은 아직 윈도우가 켜지지 않은 상태
                // 즉, InitializeComponent가 아직 실행되지 않은 상태이므로
                // 이렇게 쓰레드 문화권 정보만 바꿔주면 언어가 변경된다.
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

                // 메인 폼 이름의 리소스 문화권도 변경해줘야 하므로
                Resources.Culture = cultureInfo;

                // 하지만 현재 켜져있는 메인 윈도우는 InitializeComponent가 
                // 이미 실행된 상태이기 때문에 이렇게 직접 변경해주어야한다.
                SetCulture(cultureInfo);
            }
            if (mCurrentLangMenu != null)
                mCurrentLangMenu.Checked = true;
        }

        private void ReturnForm(SearchForm form)
        {
            searchForm = form;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            // Ctrl + F1 -> 메뉴스트립의 하위 아이템 활성화
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Ctrl, Keys.F1);
            // Ctrl + F2 -> 설정스트립의 하위 아이템 활성화
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.F2);
            // Ctrl + F3 -> 도움스트립의 하위 아이템 활성화
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Ctrl, Keys.F3);
            // Ctrl + Shift + I -> 인벤토리 버튼 클릭 이벤트 발생
            HotKey.RegisterHotKey(Handle, 105, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Shift, Keys.I);
            // Ctrl + Alt + S -> 장비 검색 버튼 클릭 이벤트 발생
            HotKey.RegisterHotKey(Handle, 107, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Alt, Keys.S);
            // Ctrl + Alt + C -> 클리어 버튼 클릭 이벤트 발생
            HotKey.RegisterHotKey(Handle, 108, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Alt, Keys.C);
            // Ctrl + Alt + O -> 확인 버튼 클릭 이벤트 발생
            HotKey.RegisterHotKey(Handle, 109, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Alt, Keys.O);
            // Ctrl + Alt + N -> 취소 버튼 클릭 이벤트 발생
            HotKey.RegisterHotKey(Handle, 110, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Alt, Keys.N);
            // Ctrl + Shift + N -> 장비 연결 
            HotKey.RegisterHotKey(Handle, 111, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Shift, Keys.N);
        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            // 레지스터
            HotKey.UnregisterHotKey(Handle, 100);
            HotKey.UnregisterHotKey(Handle, 101);
            HotKey.UnregisterHotKey(Handle, 102);
            HotKey.UnregisterHotKey(Handle, 103);
            HotKey.UnregisterHotKey(Handle, 104);
            HotKey.UnregisterHotKey(Handle, 105);
            HotKey.UnregisterHotKey(Handle, 107);
            HotKey.UnregisterHotKey(Handle, 108);
            HotKey.UnregisterHotKey(Handle, 109);
            HotKey.UnregisterHotKey(Handle, 110);
            HotKey.UnregisterHotKey(Handle, 111);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:
                            menuToolStripMenuItem_Click(this, null);
                            break;
                        case 101:
                            settingToolStripMenuItem_Click(this, null);
                            break;
                        case 102:
                            helpToolStripMenuItem_Click(this, null);
                            break;
                        case 105:
                            if (SharedValues.Reader != null)
                                btn_rfid_inventory_Click(this, null);
                            break;
                        case 107:
                            if (searchForm != null)
                                searchForm.btnStartSearch.PerformClick();
                            break;
                        case 108:
                            if (searchForm != null)
                                searchForm.btnClear.PerformClick();
                            break;
                        case 109:
                            if (searchForm != null)
                                searchForm.btnOk.PerformClick();
                            break;
                        case 110:
                            if (searchForm != null)
                                searchForm.btnCancel.PerformClick();
                            break;
                        case 111:
                            btn_rfid_connect_Click(this, null);
                            break;
                    }
                    break;
            }
            //comboBox1.Text = "";
            base.WndProc(ref m);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuToolStripMenuItem.ShowDropDown();   // 하위 아이템들 보여줌.
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingToolStripMenuItem.ShowDropDown();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //helpToolStripMenuItem.ShowDropDown();
        }

        private async void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SharedValues.ReaderConnected)
                await Rfid_Connect().ConfigureAwait(true);

            Log.WriteLine("INFO. Close Application.");
            GC.Collect();
            Application.Exit();

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (SharedValues.Reader != null)
                {
                    Popup.Show(Properties.Resources.StringExitError);
                    return;
                }

                Log.WriteLine("INFO. Close Application.");
                GC.Collect();
                Application.Exit();
            }
        }
        private void AddEvent()
        {
            for (int i = 0; i < tablePanel1.TagDataViews.Length; i++)
            {
                tablePanel1.TagDataViews[i].lbl_ant_tag_cnt.Click += (EventHandler)((sender, e) =>
                {
                    int Number = Int32.Parse((((sender as Label).Parent) as TagDataView).lbl_ant_num.Text) - 1;
                    lbSelectedPort.Text = Number.ToString();
                    var keyList = SharedValues.mTagSaveDictionary.Where(x => x.Value.Port == Number).Select(x => x.Key).ToList();
                    listviewTagList.Items.Clear();
                    foreach (var key in keyList)
                    {
                        ListViewItem items = new ListViewItem((SharedValues.mTagSaveDictionary[key].Port + 1).ToString());
                        items.SubItems.Add(SharedValues.mTagSaveDictionary[key].Epc);
                        items.SubItems.Add(SharedValues.mTagSaveDictionary[key].Rssi.ToString());

                        listviewTagList.Items.Add(items);
                    }

                });
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                using (LogDialog form = new LogDialog(this))
                {
                    // LogDialog를 Main의 자식폼으로 해서 부모폼인 Main폼에 포커스가 가도록 하기 위함.
                    form.Owner = this;
                    // 기존 이벤트에 대한 콜백메서드 삭제 (Log폼이 안띄어져있을때까지 사용한 콜백 메서드)
                    Log.OutputLog -= m_fnOutputLog;
                    // Log폼이 띄어졌으니 실시간으로 출력해야 하므로 새로운 콜백메서드 등록
                    Log.OutputLog += form.m_fnOutputLog;

                    // Owner설정 시 크로스 스레드 문제 처리를 위함.
                    if (InvokeRequired)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            form.ShowDialog();
                        }));
                    }

                    if (form.DialogResult == DialogResult.Cancel)
                    {
                        Log.OutputLog -= form.m_fnOutputLog;
                        Log.OutputLog += m_fnOutputLog;
                    }

                }
            });
            thread.Start();

        }

        private void deviceSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AntennaSettingForm form = new AntennaSettingForm())
            {
                form.ResultEvent += new AntennaSettingForm.RfidAntennaRsultHandler(GetAntSettingInfo);
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void GetAntSettingInfo(bool[] satets, int[] powerGains, int[] dwellTime)
        {
            for (int i = 0; i < SharedValues.NumberOfAntennaPorts; i++)
            {
                Config.AntStates[i] = satets[i];
                Config.AntPowerGains[i] = powerGains[i];
                Config.AntDwellTimes[i] = dwellTime[i];
            }

            for (int i = SharedValues.NumberOfAntennaPorts + 1; i < 128; i++)
            {
                Config.AntStates[i] = false;
                Config.AntPowerGains[i] = 1;
                Config.AntDwellTimes[i] = 50;
            }
        }

        private void tablePanel1_Load_1(object sender, EventArgs e)
        {

        }

        private void groupBoxTagList_Enter(object sender, EventArgs e)
        {

        }

        private void btn_rfid_connect_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                lbSelectedPort.Visible = true;
                listviewTagList.Visible = true;
                lbSelectedPort.Visible = true;

                lbEPC.Visible = false;
                txbEPC.Visible = false;
                btnSearch.Visible = false;
                btnExcelSave.Visible = false;
                listViewSearchList.Visible = false;
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                lbEPC.Visible = true;
                txbEPC.Visible = true;
                btnSearch.Visible = true;
                listViewSearchList.Visible = true;

                lbSelectedPort.Visible = false;
                listviewTagList.Visible = false;
                btnExcelSave.Visible = false;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                btnExcelSave.Visible = true;

                lbSelectedPort.Visible = false;
                lbEPC.Visible = false;
                lbSelectedPort.Visible = false;
                txbEPC.Visible = false;
                btnSearch.Visible=false;
                listViewSearchList.Visible = false;
                listviewTagList.Visible = false;
                lbSelectedPort.Visible = false;
            }
        }

        private void txbEPC_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbEPC.Text.Length > 0)
            {
                var SearchKeyList = SharedValues.mTagSaveDictionary.Where(x => x.Key.Contains(txbEPC.Text)).ToList();
            }
        }
    }
}
