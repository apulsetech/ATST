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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deviceSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_rfid_inventory = new System.Windows.Forms.Button();
            this.btn_rfid_clear = new System.Windows.Forms.Button();
            this.listview_rfid_inventory_tag_data = new System.Windows.Forms.ListView();
            this.column_tag_value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_tag_rssi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_tag_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_tbl_panel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbx_row_tbl_panel = new System.Windows.Forms.TextBox();
            this.tbx_col_tbl_panel = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tablePanel1 = new CsControl.Control.TablePanel();
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
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
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_rfid_connect);
            this.panel1.Controls.Add(this.ipAddressBox);
            this.panel1.Controls.Add(this.rbx_ethernet);
            this.panel1.Controls.Add(this.rbx_serial);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
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
            // listview_rfid_inventory_tag_data
            // 
            this.listview_rfid_inventory_tag_data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_tag_value,
            this.column_tag_rssi,
            this.column_tag_port});
            this.listview_rfid_inventory_tag_data.FullRowSelect = true;
            this.listview_rfid_inventory_tag_data.GridLines = true;
            this.listview_rfid_inventory_tag_data.HideSelection = false;
            resources.ApplyResources(this.listview_rfid_inventory_tag_data, "listview_rfid_inventory_tag_data");
            this.listview_rfid_inventory_tag_data.Name = "listview_rfid_inventory_tag_data";
            this.listview_rfid_inventory_tag_data.UseCompatibleStateImageBehavior = false;
            this.listview_rfid_inventory_tag_data.View = System.Windows.Forms.View.Details;
            // 
            // column_tag_value
            // 
            resources.ApplyResources(this.column_tag_value, "column_tag_value");
            // 
            // column_tag_rssi
            // 
            resources.ApplyResources(this.column_tag_rssi, "column_tag_rssi");
            // 
            // column_tag_port
            // 
            resources.ApplyResources(this.column_tag_port, "column_tag_port");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_rfid_clear);
            this.panel2.Controls.Add(this.btn_rfid_inventory);
            resources.ApplyResources(this.panel2, "panel2");
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
            this.panel3.Controls.Add(this.tbx_row_tbl_panel);
            this.panel3.Controls.Add(this.tbx_col_tbl_panel);
            this.panel3.Controls.Add(this.btn_tbl_panel);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
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
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listview_rfid_inventory_tag_data);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
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
        private System.Windows.Forms.StatusStrip statusStrip;
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
        private System.Windows.Forms.ListView listview_rfid_inventory_tag_data;
        private System.Windows.Forms.ColumnHeader column_tag_value;
        private System.Windows.Forms.ColumnHeader column_tag_rssi;
        private System.Windows.Forms.ColumnHeader column_tag_port;
        private System.Windows.Forms.ToolStripMenuItem korToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_tbl_panel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbx_row_tbl_panel;
        private System.Windows.Forms.TextBox tbx_col_tbl_panel;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private CsControl.Control.TablePanel tablePanel1;
    }
}