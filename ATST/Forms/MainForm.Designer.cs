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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBoxTagList = new System.Windows.Forms.GroupBox();
            this.btnExcelSave = new System.Windows.Forms.Button();
            this.listViewSearchList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txbEPC = new System.Windows.Forms.TextBox();
            this.lbSelectedPort = new System.Windows.Forms.Label();
            this.listviewTagList = new System.Windows.Forms.ListView();
            this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRssi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbPort = new System.Windows.Forms.Label();
            this.lbEPC = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tablePanel1 = new UserControls.Controls.TablePanel();
            this.lbServer = new System.Windows.Forms.Label();
            this.lbServerConnectState = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageList = new System.Windows.Forms.TabPage();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.tabPageExcel = new System.Windows.Forms.TabPage();
            this.btn_rfid_inventory = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.groupBoxTagList.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_rfid_connect
            // 
            resources.ApplyResources(this.btn_rfid_connect, "btn_rfid_connect");
            this.btn_rfid_connect.Name = "btn_rfid_connect";
            this.btn_rfid_connect.UseVisualStyleBackColor = true;
            this.btn_rfid_connect.Click += new System.EventHandler(this.btn_rfid_connect_Click);
            this.btn_rfid_connect.MouseCaptureChanged += new System.EventHandler(this.btn_rfid_connect_MouseCaptureChanged);
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
            this.deviceSettingToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            resources.ApplyResources(this.settingToolStripMenuItem, "settingToolStripMenuItem");
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // deviceSearchToolStripMenuItem
            // 
            this.deviceSearchToolStripMenuItem.Name = "deviceSearchToolStripMenuItem";
            resources.ApplyResources(this.deviceSearchToolStripMenuItem, "deviceSearchToolStripMenuItem");
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // groupBoxTagList
            // 
            resources.ApplyResources(this.groupBoxTagList, "groupBoxTagList");
            this.groupBoxTagList.Controls.Add(this.btnExcelSave);
            this.groupBoxTagList.Controls.Add(this.listViewSearchList);
            this.groupBoxTagList.Controls.Add(this.btnSearch);
            this.groupBoxTagList.Controls.Add(this.txbEPC);
            this.groupBoxTagList.Controls.Add(this.lbSelectedPort);
            this.groupBoxTagList.Controls.Add(this.listviewTagList);
            this.groupBoxTagList.Controls.Add(this.lbPort);
            this.groupBoxTagList.Controls.Add(this.lbEPC);
            this.groupBoxTagList.Name = "groupBoxTagList";
            this.groupBoxTagList.TabStop = false;
            this.groupBoxTagList.Enter += new System.EventHandler(this.groupBoxTagList_Enter);
            // 
            // btnExcelSave
            // 
            resources.ApplyResources(this.btnExcelSave, "btnExcelSave");
            this.btnExcelSave.Name = "btnExcelSave";
            this.btnExcelSave.UseVisualStyleBackColor = true;
            // 
            // listViewSearchList
            // 
            resources.ApplyResources(this.listViewSearchList, "listViewSearchList");
            this.listViewSearchList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewSearchList.GridLines = true;
            this.listViewSearchList.HideSelection = false;
            this.listViewSearchList.Name = "listViewSearchList";
            this.listViewSearchList.UseCompatibleStateImageBehavior = false;
            this.listViewSearchList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txbEPC
            // 
            resources.ApplyResources(this.txbEPC, "txbEPC");
            this.txbEPC.Name = "txbEPC";
            this.txbEPC.TextChanged += new System.EventHandler(this.txbEPC_TextChanged);
            // 
            // lbSelectedPort
            // 
            resources.ApplyResources(this.lbSelectedPort, "lbSelectedPort");
            this.lbSelectedPort.Name = "lbSelectedPort";
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
            // lbPort
            // 
            resources.ApplyResources(this.lbPort, "lbPort");
            this.lbPort.Name = "lbPort";
            // 
            // lbEPC
            // 
            resources.ApplyResources(this.lbEPC, "lbEPC");
            this.lbEPC.Name = "lbEPC";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tablePanel1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tablePanel1
            // 
            resources.ApplyResources(this.tablePanel1, "tablePanel1");
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Load += new System.EventHandler(this.tablePanel1_Load_1);
            // 
            // lbServer
            // 
            resources.ApplyResources(this.lbServer, "lbServer");
            this.lbServer.Name = "lbServer";
            this.lbServer.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbServerConnectState
            // 
            resources.ApplyResources(this.lbServerConnectState, "lbServerConnectState");
            this.lbServerConnectState.BackColor = System.Drawing.Color.Lime;
            this.lbServerConnectState.Name = "lbServerConnectState";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPageList);
            this.tabControl1.Controls.Add(this.tabPageSearch);
            this.tabControl1.Controls.Add(this.tabPageExcel);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageList
            // 
            resources.ApplyResources(this.tabPageList, "tabPageList");
            this.tabPageList.Name = "tabPageList";
            this.tabPageList.UseVisualStyleBackColor = true;
            // 
            // tabPageSearch
            // 
            resources.ApplyResources(this.tabPageSearch, "tabPageSearch");
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // tabPageExcel
            // 
            resources.ApplyResources(this.tabPageExcel, "tabPageExcel");
            this.tabPageExcel.Name = "tabPageExcel";
            this.tabPageExcel.UseVisualStyleBackColor = true;
            // 
            // btn_rfid_inventory
            // 
            resources.ApplyResources(this.btn_rfid_inventory, "btn_rfid_inventory");
            this.btn_rfid_inventory.Name = "btn_rfid_inventory";
            this.btn_rfid_inventory.UseVisualStyleBackColor = true;
            this.btn_rfid_inventory.Click += new System.EventHandler(this.btn_rfid_inventory_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_rfid_inventory);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbServerConnectState);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.btn_rfid_connect);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBoxTagList);
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
            this.groupBoxTagList.ResumeLayout(false);
            this.groupBoxTagList.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_rfid_connect;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deviceSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private UserControls.Controls.TablePanel tablePanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBoxTagList;
        private System.Windows.Forms.ListView listviewTagList;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderTag;
        private System.Windows.Forms.ColumnHeader columnHeaderRssi;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbSelectedPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Label lbServerConnectState;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.TabPage tabPageExcel;
        private System.Windows.Forms.Button btn_rfid_inventory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txbEPC;
        private System.Windows.Forms.Label lbEPC;
        private System.Windows.Forms.ListView listViewSearchList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnExcelSave;
    }
}