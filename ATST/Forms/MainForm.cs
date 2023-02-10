using Apulsetech.Event;
using Apulsetech.Rfid;
using Apulsetech.Rfid.Type;
using ATST.Data;
using ATST.Diagnotics;
using ATST.Forms.Diagnotics;
using ATST.GlobalKey;
using ATST.Properties;
using ATST.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATST.Forms
{
    public partial class MainForm : Form, ReaderEventListener
    {
        private SearchForm searchForm = null;

        private Log.LogEventHandler m_fnOutputLog;

        // Log창 닫혀있을때 로그 저장할 텍스트박스
        public TextBox txb = new TextBox();

        public MainForm()
        {
            InitializeComponent();
            Initialize();

            Log.OutputLog += this.OutputLog;

            m_fnOutputLog = new Log.LogEventHandler(OutputLog); // Invoke시 사용하거나 Event의 콜백메서드를 삭제하기 위함.

            SearchForm.OpenFormEvent += new SearchForm.OpenFormReturn(ReturnForm);  // 활성화된 장비검색폼 객체를 리턴한다.
            this.KeyPreview = true; // 폼이 모든 키 이벤트를 받게함. -> ESC 키를 눌렀을때 폼이 이벤트 핸들러가 발생될 수 있게하기 위함.
        }

        private void Initialize()
        {
            // 이름 따로 설정안하면 ApplyResources에서 Name이 Null로 나옴
            listview_rfid_inventory_tag_data.Columns[0].Name = "column_tag_value";
            listview_rfid_inventory_tag_data.Columns[1].Name = "column_tag_rssi";
            listview_rfid_inventory_tag_data.Columns[2].Name = "column_tag_port";

            EnableControl(false);
        }

        // 컨트롤 사용가능 여부 체크
        private void EnableControl(bool enable)
        {
            btn_rfid_inventory.Enabled = enable;
            btn_rfid_clear.Enabled = enable;

            btn_rfid_connect.Enabled = btn_rfid_inventory.Enabled && btn_rfid_clear.Enabled ? enable : !enable;
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

        private void rbx_ethernet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbx_serial.Checked)
            {
                rbx_serial.Checked = false;
                rbx_ethernet.Checked = true;
            }
            SharedValues.ConnectionType = SharedValues.InterfaceType.TCP;
        }

        private void rbx_serial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbx_ethernet.Checked)
            {
                rbx_ethernet.Checked = false;
                rbx_serial.Checked = true;
            }
            SharedValues.ConnectionType = SharedValues.InterfaceType.SERIAL; 
        }

        private void deviceSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SearchForm dlg = new SearchForm())
            {
                //dlg.Owner = this;         
                if (dlg.ShowDialog() == DialogResult.OK)
                    ipAddressBox.SetIpData(SharedValues.Ethernet);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CultureInfo current = LoadCultureInfo();
            Thread.CurrentThread.CurrentUICulture = current;
            Thread.CurrentThread.CurrentCulture = current;
            Resources.Culture = current;

            SetCulture(current);
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

        private void btn_rfid_clear_Click(object sender, EventArgs e)
        {

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
            // Ctrl + Shift + E -> 이더넷 모드 활성화
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Shift, Keys.E);
            // Ctrl + Shift + S -> 시리얼 모드 활성화
            HotKey.RegisterHotKey(Handle, 104, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Shift, Keys.S);
            // Ctrl + Shift + I -> 인벤토리 버튼 클릭 이벤트 발생
            HotKey.RegisterHotKey(Handle, 105, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Shift, Keys.I);
            // Ctrl + Shift + C -> 클리어 버튼 클릭 이벤트 발생
            HotKey.RegisterHotKey(Handle, 106, HotKey.KeyModifiers.Ctrl | HotKey.KeyModifiers.Shift, Keys.C);
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
            HotKey.UnregisterHotKey(Handle, 106);
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
                        case 103:
                            rbx_ethernet_CheckedChanged(this, null);
                            break;
                        case 104:
                            rbx_serial_CheckedChanged(this, null);
                            break;
                        case 105:
                            if (SharedValues.Reader != null)
                                btn_rfid_inventory_Click(this, null);
                            break;
                        case 106:
                            btn_rfid_clear_Click(this, null);
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.WriteLine("INFO. Close Application.");
            GC.Collect();
            Application.Exit();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Log.WriteLine("INFO. Close Application.");
                GC.Collect();
                Application.Exit();
            }
        }

        private void btn_tbl_panel_Click(object sender, EventArgs e)
        {
            if (tablePanel1.set_panel(
                Int32.Parse(tbx_col_tbl_panel.Text),
                Int32.Parse(tbx_row_tbl_panel.Text)))
            {

            }
        }

        private void tablePanel1_Load(object sender, EventArgs e)
        {

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
    }
}
