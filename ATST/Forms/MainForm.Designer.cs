using ATST.Util;

namespace ATST.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rbx_serial = new System.Windows.Forms.RadioButton();
            this.rbx_ethernet = new System.Windows.Forms.RadioButton();
            this.ipAddressBox = new ControlIpAddressBox.IpAddressBox();
            this.btn_rfid_connect = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.engToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deviceSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readerSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnComPortSearch = new System.Windows.Forms.Button();
            this.cbxConnectionInterfacePort = new System.Windows.Forms.ComboBox();
            this.btn_rfid_inventory = new System.Windows.Forms.Button();
            this.btn_rfid_clear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_tbl_panel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.tbx_row_tbl_panel = new System.Windows.Forms.TextBox();
            this.tbx_col_tbl_panel = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tablePanel1 = new UserControls.Controls.TablePanel();
            this.lb3 = new System.Windows.Forms.Label();
            this.txbAntCount = new System.Windows.Forms.TextBox();
            this.btnAntCount = new System.Windows.Forms.Button();
            this.rbtnServerConnect = new System.Windows.Forms.RadioButton();
            this.rbtnLocal = new System.Windows.Forms.RadioButton();
            this.groupBoxTagList = new System.Windows.Forms.GroupBox();
            this.lbSelectedPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listviewTagList = new System.Windows.Forms.ListView();
            this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRssi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.virtualListViewIO1 = new UserControls.Controls.VirtualListViewIO();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBoxTagList.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbx_serial
            // 
            resources.ApplyResources(this.rbx_serial, "rbx_serial");
            this.rbx_serial.Checked = true;
            this.rbx_serial.Name = "rbx_serial";
            this.rbx_serial.TabStop = true;
            this.rbx_serial.UseVisualStyleBackColor = true;
            this.rbx_serial.CheckedChanged += new System.EventHandler(this.rbx_serial_CheckedChanged);
            // 
            // rbx_ethernet
            // 
            resources.ApplyResources(this.rbx_ethernet, "rbx_ethernet");
            this.rbx_ethernet.Name = "rbx_ethernet";
            this.rbx_ethernet.UseVisualStyleBackColor = true;
            this.rbx_ethernet.CheckedChanged += new System.EventHandler(this.rbx_ethernet_CheckedChanged);
            // 
            // ipAddressBox
            // 
            this.ipAddressBox.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            resources.ApplyResources(this.ipAddressBox, "ipAddressBox");
            this.ipAddressBox.Name = "ipAddressBox";
            // 
            // btn_rfid_connect
            // 
            resources.ApplyResources(this.btn_rfid_connect, "btn_rfid_connect");
            this.btn_rfid_connect.Name = "btn_rfid_connect";
            this.btn_rfid_connect.UseVisualStyleBackColor = true;
            this.btn_rfid_connect.Click += new System.EventHandler(this.btn_rfid_connect_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.toolStripMenuItem2,
            this.logToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            resources.ApplyResources(this.menuToolStripMenuItem, "menuToolStripMenuItem");
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korToolStripMenuItem,
            this.engToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // korToolStripMenuItem
            // 
            this.korToolStripMenuItem.Name = "korToolStripMenuItem";
            resources.ApplyResources(this.korToolStripMenuItem, "korToolStripMenuItem");
            this.korToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // engToolStripMenuItem
            // 
            this.engToolStripMenuItem.Name = "engToolStripMenuItem";
            resources.ApplyResources(this.engToolStripMenuItem, "engToolStripMenuItem");
            this.engToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            resources.ApplyResources(this.logToolStripMenuItem, "logToolStripMenuItem");
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceSearchToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deviceSettingToolStripMenuItem,
            this.readerSettingToolStripMenuItem,
            this.selectMaskToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            resources.ApplyResources(this.settingToolStripMenuItem, "settingToolStripMenuItem");
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // deviceSearchToolStripMenuItem
            // 
            this.deviceSearchToolStripMenuItem.Name = "deviceSearchToolStripMenuItem";
            resources.ApplyResources(this.deviceSearchToolStripMenuItem, "deviceSearchToolStripMenuItem");
            this.deviceSearchToolStripMenuItem.Click += new System.EventHandler(this.deviceSearchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // deviceSettingToolStripMenuItem
            // 
            this.deviceSettingToolStripMenuItem.Name = "deviceSettingToolStripMenuItem";
            resources.ApplyResources(this.deviceSettingToolStripMenuItem, "deviceSettingToolStripMenuItem");
            this.deviceSettingToolStripMenuItem.Click += new System.EventHandler(this.deviceSettingToolStripMenuItem_Click);
            // 
            // readerSettingToolStripMenuItem
            // 
            this.readerSettingToolStripMenuItem.Name = "readerSettingToolStripMenuItem";
            resources.ApplyResources(this.readerSettingToolStripMenuItem, "readerSettingToolStripMenuItem");
            this.readerSettingToolStripMenuItem.Click += new System.EventHandler(this.readerSettingToolStripMenuItem_Click);
            // 
            // selectMaskToolStripMenuItem
            // 
            this.selectMaskToolStripMenuItem.Name = "selectMaskToolStripMenuItem";
            resources.ApplyResources(this.selectMaskToolStripMenuItem, "selectMaskToolStripMenuItem");
            this.selectMaskToolStripMenuItem.Click += new System.EventHandler(this.selectMaskToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnComPortSearch);
            this.panel1.Controls.Add(this.cbxConnectionInterfacePort);
            this.panel1.Controls.Add(this.btn_rfid_connect);
            this.panel1.Controls.Add(this.ipAddressBox);
            this.panel1.Controls.Add(this.rbx_ethernet);
            this.panel1.Controls.Add(this.rbx_serial);
            this.panel1.Name = "panel1";
            // 
            // btnComPortSearch
            // 
            resources.ApplyResources(this.btnComPortSearch, "btnComPortSearch");
            this.btnComPortSearch.Name = "btnComPortSearch";
            this.btnComPortSearch.UseVisualStyleBackColor = true;
            this.btnComPortSearch.Click += new System.EventHandler(this.btnComPortSearch_Click);
            // 
            // cbxConnectionInterfacePort
            // 
            this.cbxConnectionInterfacePort.FormattingEnabled = true;
            resources.ApplyResources(this.cbxConnectionInterfacePort, "cbxConnectionInterfacePort");
            this.cbxConnectionInterfacePort.Name = "cbxConnectionInterfacePort";
            this.cbxConnectionInterfacePort.DropDown += new System.EventHandler(this.cbxConnectionInterfacePort_DropDown);
            this.cbxConnectionInterfacePort.SelectedIndexChanged += new System.EventHandler(this.cbxConnectionInterfacePort_SelectedIndexChanged);
            // 
            // btn_rfid_inventory
            // 
            resources.ApplyResources(this.btn_rfid_inventory, "btn_rfid_inventory");
            this.btn_rfid_inventory.Name = "btn_rfid_inventory";
            this.btn_rfid_inventory.UseVisualStyleBackColor = true;
            this.btn_rfid_inventory.Click += new System.EventHandler(this.btn_rfid_inventory_Click);
            // 
            // btn_rfid_clear
            // 
            resources.ApplyResources(this.btn_rfid_clear, "btn_rfid_clear");
            this.btn_rfid_clear.Name = "btn_rfid_clear";
            this.btn_rfid_clear.UseVisualStyleBackColor = true;
            this.btn_rfid_clear.Click += new System.EventHandler(this.btn_rfid_clear_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.btn_rfid_clear);
            this.panel2.Controls.Add(this.btn_rfid_inventory);
            this.panel2.Name = "panel2";
            // 
            // btn_tbl_panel
            // 
            resources.ApplyResources(this.btn_tbl_panel, "btn_tbl_panel");
            this.btn_tbl_panel.Name = "btn_tbl_panel";
            this.btn_tbl_panel.UseVisualStyleBackColor = true;
            this.btn_tbl_panel.Click += new System.EventHandler(this.btn_tbl_panel_Click);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.lb1);
            this.panel3.Controls.Add(this.lb2);
            this.panel3.Controls.Add(this.tbx_row_tbl_panel);
            this.panel3.Controls.Add(this.tbx_col_tbl_panel);
            this.panel3.Controls.Add(this.btn_tbl_panel);
            this.panel3.Name = "panel3";
            // 
            // lb1
            // 
            resources.ApplyResources(this.lb1, "lb1");
            this.lb1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lb1.Name = "lb1";
            // 
            // lb2
            // 
            resources.ApplyResources(this.lb2, "lb2");
            this.lb2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lb2.Name = "lb2";
            // 
            // tbx_row_tbl_panel
            // 
            resources.ApplyResources(this.tbx_row_tbl_panel, "tbx_row_tbl_panel");
            this.tbx_row_tbl_panel.Name = "tbx_row_tbl_panel";
            // 
            // tbx_col_tbl_panel
            // 
            resources.ApplyResources(this.tbx_col_tbl_panel, "tbx_col_tbl_panel");
            this.tbx_col_tbl_panel.Name = "tbx_col_tbl_panel";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // tablePanel1
            // 
            resources.ApplyResources(this.tablePanel1, "tablePanel1");
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Load += new System.EventHandler(this.tablePanel1_Load_1);
            // 
            // lb3
            // 
            this.lb3.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.lb3, "lb3");
            this.lb3.Name = "lb3";
            // 
            // txbAntCount
            // 
            resources.ApplyResources(this.txbAntCount, "txbAntCount");
            this.txbAntCount.Name = "txbAntCount";
            // 
            // btnAntCount
            // 
            resources.ApplyResources(this.btnAntCount, "btnAntCount");
            this.btnAntCount.Name = "btnAntCount";
            this.btnAntCount.UseVisualStyleBackColor = true;
            this.btnAntCount.Click += new System.EventHandler(this.btnSettingAntCount_Click);
            // 
            // rbtnServerConnect
            // 
            resources.ApplyResources(this.rbtnServerConnect, "rbtnServerConnect");
            this.rbtnServerConnect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnServerConnect.Name = "rbtnServerConnect";
            this.rbtnServerConnect.TabStop = true;
            this.rbtnServerConnect.UseVisualStyleBackColor = false;
            this.rbtnServerConnect.CheckedChanged += new System.EventHandler(this.rbtnServerConnect_CheckedChanged);
            // 
            // rbtnLocal
            // 
            resources.ApplyResources(this.rbtnLocal, "rbtnLocal");
            this.rbtnLocal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnLocal.Name = "rbtnLocal";
            this.rbtnLocal.TabStop = true;
            this.rbtnLocal.UseVisualStyleBackColor = false;
            this.rbtnLocal.CheckedChanged += new System.EventHandler(this.rbtnLocal_CheckedChanged);
            // 
            // groupBoxTagList
            // 
            resources.ApplyResources(this.groupBoxTagList, "groupBoxTagList");
            this.groupBoxTagList.Controls.Add(this.lbSelectedPort);
            this.groupBoxTagList.Controls.Add(this.label1);
            this.groupBoxTagList.Controls.Add(this.listviewTagList);
            this.groupBoxTagList.Name = "groupBoxTagList";
            this.groupBoxTagList.TabStop = false;
            this.groupBoxTagList.Enter += new System.EventHandler(this.groupBoxTagList_Enter);
            // 
            // lbSelectedPort
            // 
            resources.ApplyResources(this.lbSelectedPort, "lbSelectedPort");
            this.lbSelectedPort.Name = "lbSelectedPort";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // listviewTagList
            // 
            resources.ApplyResources(this.listviewTagList, "listviewTagList");
            this.listviewTagList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPort,
            this.columnHeaderTag,
            this.columnHeaderRssi});
            this.listviewTagList.GridLines = true;
            this.listviewTagList.HideSelection = false;
            this.listviewTagList.Name = "listviewTagList";
            this.listviewTagList.UseCompatibleStateImageBehavior = false;
            this.listviewTagList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPort
            // 
            resources.ApplyResources(this.columnHeaderPort, "columnHeaderPort");
            // 
            // columnHeaderTag
            // 
            resources.ApplyResources(this.columnHeaderTag, "columnHeaderTag");
            // 
            // columnHeaderRssi
            // 
            resources.ApplyResources(this.columnHeaderRssi, "columnHeaderRssi");
            // 
            // virtualListViewIO1
            // 
            resources.ApplyResources(this.virtualListViewIO1, "virtualListViewIO1");
            this.virtualListViewIO1.Name = "virtualListViewIO1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.virtualListViewIO1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tablePanel1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBoxTagList);
            this.Controls.Add(this.rbtnLocal);
            this.Controls.Add(this.rbtnServerConnect);
            this.Controls.Add(this.btnAntCount);
            this.Controls.Add(this.txbAntCount);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Leave += new System.EventHandler(this.MainForm_Leave);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBoxTagList.ResumeLayout(false);
            this.groupBoxTagList.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbx_serial;
        private System.Windows.Forms.RadioButton rbx_ethernet;
        private ControlIpAddressBox.IpAddressBox ipAddressBox;
        private System.Windows.Forms.Button btn_rfid_connect;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deviceSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btn_rfid_inventory;
        private System.Windows.Forms.Button btn_rfid_clear;
        private System.Windows.Forms.ToolStripMenuItem korToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_tbl_panel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbx_row_tbl_panel;
        private System.Windows.Forms.TextBox tbx_col_tbl_panel;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private UserControls.Controls.TablePanel tablePanel1;
        private System.Windows.Forms.Button btnComPortSearch;
        private System.Windows.Forms.ComboBox cbxConnectionInterfacePort;
        private System.Windows.Forms.ToolStripMenuItem readerSettingToolStripMenuItem;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.TextBox txbAntCount;
        private System.Windows.Forms.Button btnAntCount;
        private System.Windows.Forms.ToolStripMenuItem selectMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.RadioButton rbtnServerConnect;
        private System.Windows.Forms.RadioButton rbtnLocal;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
        private UserControls.Controls.VirtualListViewIO virtualListViewIO1;
        private System.Windows.Forms.GroupBox groupBoxTagList;
        private System.Windows.Forms.ListView listviewTagList;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderTag;
        private System.Windows.Forms.ColumnHeader columnHeaderRssi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSelectedPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}