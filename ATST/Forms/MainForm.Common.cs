using ATST.Data;
using ATST.Properties;
using ATST.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATST.Forms
{
    public partial class MainForm
    {
        private ToolStripMenuItem mCurrentLangMenu;

        // Load Culture Info
        private CultureInfo LoadCultureInfo()
        {
            CultureInfo current;

            if (String.IsNullOrEmpty(Config.CultureName))
            {
                current = CultureInfo.CurrentCulture;
                Config.CultureName = current.Name;
            }
            else
            {
                current = new CultureInfo(Config.CultureName);
            }

            if (current.Name.Contains("ko-"))
                mCurrentLangMenu = korToolStripMenuItem;
            else
                mCurrentLangMenu = engToolStripMenuItem;
            mCurrentLangMenu.Checked = true;
            return current;
        }

        // Set Culture
        private void SetCulture(CultureInfo cultureInfo)
        {
            // Form에 등록된 리소스(.resx) 접근하기
            // 리소스 매니저 생성
            // MainForm 반환
            // MainForm의 리소스를 변경할 것이므로
            ComponentResourceManager manager = new ComponentResourceManager(GetType());

            // 폼 텍스트 변경
            this.Text = String.Format("{0} v{1}", Resources.StringName, SysUtil.GetVersion());

            // 메뉴스트립에 리소스 적용하기
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                // MainForm에 있는 각 메뉴스트립의 아이템들의 변경된 리소스 적용하기
                manager.ApplyResources(item, item.Name, cultureInfo);
                // 메뉴스트립에서 아이템들이 드롭다운된 상태인지 확인
                if (item.HasDropDown)
                    // 드롭다운에 보이는 서브 메뉴들의 리소스를 변경해야겠지
                    UpdateSubMenuCultureInfo(manager, item, cultureInfo);
            }
            // 컨트롤에 리소스 적용하기
            foreach (Control control in Controls)
            {
                manager.ApplyResources(control, control.Name, cultureInfo);
                if (control.Controls.Count > 0)
                    UpdateSubControlCulture(manager, control, cultureInfo);
                // 서브 컨트롤이 아닌 리스트뷰 리소스 적용하기
                else if (control is ListView)
                    UpdateListViewColumns(manager, control as ListView, cultureInfo);
            }
            
        }

        // Update Sub Controls Cultrue Info
        private void UpdateSubControlCulture(ComponentResourceManager manager,
            Control parent, CultureInfo cultureInfo)
        {
            foreach (Control control in parent.Controls)
            {
                manager.ApplyResources(control, control.Name, cultureInfo);
                if (control.Controls.Count > 0)
                    UpdateSubControlCulture(manager, control, cultureInfo);
                if (control is ListView)
                    UpdateListViewColumns(manager, control as ListView, cultureInfo);
            }
        }

        // Update Sub Menu Culture Info
        private void UpdateSubMenuCultureInfo(ComponentResourceManager manager,
            ToolStripMenuItem parent, CultureInfo cultureInfo)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                // MainForm에 있는 드롭다운해서 보이는 각 서브 아이템들 리소스 적용하기
                manager.ApplyResources(item, item.Name, cultureInfo);
                // 이 아이템들이  toolStripMenuItem이라면
                // if문을 해주는 이유는 item이 ToolStripItem를 상속하는 ToolStripMenuItem인지 확인하고 또한
                // toolStipSeparator를 걸러주기 위함.
                if (item is ToolStripMenuItem)
                {
                    // 막약 이 아이템도 드롭다운된 상태라면 서브 아이템들도 리소스 변경해줘야한다.
                    if (((ToolStripMenuItem)item).HasDropDown)
                        UpdateSubMenuCultureInfo(manager, (ToolStripMenuItem)item, cultureInfo);
                }
            }
        }

        // Update ListView columns
        private void UpdateListViewColumns(ComponentResourceManager manager,
            ListView parent, CultureInfo cultureInfos)
        {
            foreach (ColumnHeader col in parent.Columns)
                manager.ApplyResources(col, col.Name, cultureInfos);
        }
    }
}
