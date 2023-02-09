using Apulsetech.Event;
using Apulsetech.Rfid;
using Apulsetech.Rfid.Type;
using ATST.Data;
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

        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            InitItem();
        }

        private void InitItem()
        {
            rbx_ethernet.Checked = true;
        }



        private void rbx_ethernet_CheckedChanged(object sender, EventArgs e)
        {
            SharedValues.ConnectionType = SharedValues.InterfaceType.TCP;
        }

        private void rbx_serial_CheckedChanged(object sender, EventArgs e)
        {
            SharedValues.ConnectionType = SharedValues.InterfaceType.SERIAL;
        }

        private void deviceSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SearchForm dlg = new SearchForm())
            {
                dlg.Owner = this;
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

        private void btn_tbl_panel_Click(object sender, EventArgs e)
        {
            if (tablePanel1.set_panel(
                Int32.Parse(tbx_col_tbl_panel.Text),
                Int32.Parse(tbx_row_tbl_panel.Text)))
            {

            }
        }
    }
}
