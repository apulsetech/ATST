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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_row_tbl_panel = new System.Windows.Forms.TextBox();
            this.tbx_col_tbl_panel = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tablePanel1 = new CsControl.Control.TablePanel();
            this.io_data_listview = new CsControl.Control.io_data_listview();
            this.label2 = new System.Windows.Forms.Label();
            this.txbAntCount1 = new System.Windows.Forms.TextBox();
            this.btnAntCount = new System.Windows.Forms.Button();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.webLinkageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.toolStripSeparator1,
            this.exitToolStripMenuItem,
            this.toolStripSeparator2,
            this.webLinkageToolStripMenuItem});
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
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tbx_row_tbl_panel);
            this.panel3.Controls.Add(this.tbx_col_tbl_panel);
            this.panel3.Controls.Add(this.btn_tbl_panel);
            this.panel3.Name = "panel3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label3.Name = "label3";
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
            // 
            // io_data_listview
            // 
            resources.ApplyResources(this.io_data_listview, "io_data_listview");
            this.io_data_listview.BackColor = System.Drawing.Color.White;
            this.io_data_listview.Name = "io_data_listview";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Name = "label2";
            // 
            // txbAntCount1
            // 
            resources.ApplyResources(this.txbAntCount1, "txbAntCount1");
            this.txbAntCount1.Name = "txbAntCount1";
            // 
            // btnAntCount
            // 
            resources.ApplyResources(this.btnAntCount, "btnAntCount");
            this.btnAntCount.Name = "btnAntCount";
            this.btnAntCount.UseVisualStyleBackColor = true;
            this.btnAntCount.Click += new System.EventHandler(this.btnSettingAntCount_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // webLinkageToolStripMenuItem
            // 
            this.webLinkageToolStripMenuItem.Name = "webLinkageToolStripMenuItem";
            resources.ApplyResources(this.webLinkageToolStripMenuItem, "webLinkageToolStripMenuItem");
            this.webLinkageToolStripMenuItem.Click += new System.EventHandler(this.webLinkageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAntCount);
            this.Controls.Add(this.txbAntCount1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.io_data_listview);
            this.Controls.Add(this.tablePanel1);
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
        private CsControl.Control.TablePanel tablePanel1;
        private CsControl.Control.io_data_listview io_data_listview;
        private System.Windows.Forms.Button btnComPortSearch;
        private System.Windows.Forms.ComboBox cbxConnectionInterfacePort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem readerSettingToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbAntCount1;
        private System.Windows.Forms.Button btnAntCount;
        private System.Windows.Forms.ToolStripMenuItem selectMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem webLinkageToolStripMenuItem;
    }
}