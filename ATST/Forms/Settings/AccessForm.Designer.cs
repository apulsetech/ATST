namespace ATST.Forms.Settings
{
    partial class AccessForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxSerial = new System.Windows.Forms.ComboBox();
            this.lbSerial = new System.Windows.Forms.Label();
            this.btnDeviceSearch = new System.Windows.Forms.Button();
            this.cbxAntennaPort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnEthernet = new System.Windows.Forms.RadioButton();
            this.rbtnSerial = new System.Windows.Forms.RadioButton();
            this.lbAddress = new System.Windows.Forms.Label();
            this.ipAddressMiniBox1 = new UserControls.Controls.IpAddressMiniBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbGatheringServerPort = new System.Windows.Forms.TextBox();
            this.txbApiServerPort = new System.Windows.Forms.TextBox();
            this.ipAddressComboBox2 = new UserControls.Controls.IpAddressComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ipAddressComboBox1 = new UserControls.Controls.IpAddressComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtnServerLinkageNonChecked = new System.Windows.Forms.RadioButton();
            this.rbtnServerLinkageChecked = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.65803F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.34197F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(287, 435);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 130);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(3, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apulsetechnology";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "RFID Warehouse Management System";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "ATST";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxSerial);
            this.panel2.Controls.Add(this.lbSerial);
            this.panel2.Controls.Add(this.btnDeviceSearch);
            this.panel2.Controls.Add(this.cbxAntennaPort);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.rbtnEthernet);
            this.panel2.Controls.Add(this.rbtnSerial);
            this.panel2.Controls.Add(this.lbAddress);
            this.panel2.Controls.Add(this.ipAddressMiniBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 78);
            this.panel2.TabIndex = 1;
            // 
            // cbxSerial
            // 
            this.cbxSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSerial.FormattingEnabled = true;
            this.cbxSerial.Location = new System.Drawing.Point(94, 22);
            this.cbxSerial.Name = "cbxSerial";
            this.cbxSerial.Size = new System.Drawing.Size(120, 23);
            this.cbxSerial.TabIndex = 11;
            this.cbxSerial.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.cbxSerial.TextChanged += new System.EventHandler(this.cbxSerial_TextChanged);
            // 
            // lbSerial
            // 
            this.lbSerial.AutoSize = true;
            this.lbSerial.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lbSerial.Location = new System.Drawing.Point(25, 23);
            this.lbSerial.Name = "lbSerial";
            this.lbSerial.Size = new System.Drawing.Size(44, 19);
            this.lbSerial.TabIndex = 10;
            this.lbSerial.Text = "Serial";
            this.lbSerial.Click += new System.EventHandler(this.lbSerial_Click);
            // 
            // btnDeviceSearch
            // 
            this.btnDeviceSearch.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.btnDeviceSearch.Location = new System.Drawing.Point(220, 22);
            this.btnDeviceSearch.Name = "btnDeviceSearch";
            this.btnDeviceSearch.Size = new System.Drawing.Size(45, 20);
            this.btnDeviceSearch.TabIndex = 6;
            this.btnDeviceSearch.Text = "Search";
            this.btnDeviceSearch.UseVisualStyleBackColor = true;
            this.btnDeviceSearch.Click += new System.EventHandler(this.btnDeviceSearch_Click);
            // 
            // cbxAntennaPort
            // 
            this.cbxAntennaPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAntennaPort.FormattingEnabled = true;
            this.cbxAntennaPort.Location = new System.Drawing.Point(94, 49);
            this.cbxAntennaPort.Name = "cbxAntennaPort";
            this.cbxAntennaPort.Size = new System.Drawing.Size(120, 23);
            this.cbxAntennaPort.TabIndex = 4;
            this.cbxAntennaPort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cbxAntennaPort.TextChanged += new System.EventHandler(this.cbxAntennaPort_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(25, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ant. Port";
            // 
            // rbtnEthernet
            // 
            this.rbtnEthernet.AutoSize = true;
            this.rbtnEthernet.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnEthernet.Location = new System.Drawing.Point(114, 3);
            this.rbtnEthernet.Name = "rbtnEthernet";
            this.rbtnEthernet.Size = new System.Drawing.Size(69, 17);
            this.rbtnEthernet.TabIndex = 1;
            this.rbtnEthernet.TabStop = true;
            this.rbtnEthernet.Text = "Ethernet";
            this.rbtnEthernet.UseVisualStyleBackColor = true;
            this.rbtnEthernet.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnSerial
            // 
            this.rbtnSerial.AutoSize = true;
            this.rbtnSerial.Checked = true;
            this.rbtnSerial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSerial.Location = new System.Drawing.Point(19, 3);
            this.rbtnSerial.Name = "rbtnSerial";
            this.rbtnSerial.Size = new System.Drawing.Size(53, 17);
            this.rbtnSerial.TabIndex = 0;
            this.rbtnSerial.TabStop = true;
            this.rbtnSerial.Text = "Serial";
            this.rbtnSerial.UseVisualStyleBackColor = true;
            this.rbtnSerial.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lbAddress.Location = new System.Drawing.Point(25, 23);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(58, 19);
            this.lbAddress.TabIndex = 1;
            this.lbAddress.Text = "Address";
            this.lbAddress.Visible = false;
            // 
            // ipAddressMiniBox1
            // 
            this.ipAddressMiniBox1.Location = new System.Drawing.Point(94, 22);
            this.ipAddressMiniBox1.Name = "ipAddressMiniBox1";
            this.ipAddressMiniBox1.Size = new System.Drawing.Size(123, 21);
            this.ipAddressMiniBox1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbGatheringServerPort);
            this.panel3.Controls.Add(this.txbApiServerPort);
            this.panel3.Controls.Add(this.ipAddressComboBox2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.ipAddressComboBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.rbtnServerLinkageNonChecked);
            this.panel3.Controls.Add(this.rbtnServerLinkageChecked);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 223);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 120);
            this.panel3.TabIndex = 2;
            // 
            // txbGatheringServerPort
            // 
            this.txbGatheringServerPort.Enabled = false;
            this.txbGatheringServerPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbGatheringServerPort.Location = new System.Drawing.Point(220, 92);
            this.txbGatheringServerPort.Name = "txbGatheringServerPort";
            this.txbGatheringServerPort.Size = new System.Drawing.Size(46, 23);
            this.txbGatheringServerPort.TabIndex = 12;
            this.txbGatheringServerPort.TextChanged += new System.EventHandler(this.txbGatheringServerPort_TextChanged);
            // 
            // txbApiServerPort
            // 
            this.txbApiServerPort.Enabled = false;
            this.txbApiServerPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbApiServerPort.Location = new System.Drawing.Point(220, 46);
            this.txbApiServerPort.Name = "txbApiServerPort";
            this.txbApiServerPort.Size = new System.Drawing.Size(45, 23);
            this.txbApiServerPort.TabIndex = 11;
            this.txbApiServerPort.TextChanged += new System.EventHandler(this.txbApiServerPort_TextChanged);
            // 
            // ipAddressComboBox2
            // 
            this.ipAddressComboBox2.Enabled = false;
            this.ipAddressComboBox2.Location = new System.Drawing.Point(54, 92);
            this.ipAddressComboBox2.Name = "ipAddressComboBox2";
            this.ipAddressComboBox2.Size = new System.Drawing.Size(160, 21);
            this.ipAddressComboBox2.TabIndex = 10;
            this.ipAddressComboBox2.Load += new System.EventHandler(this.ipAddressComboBox2_Load);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(24, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 28);
            this.label6.TabIndex = 9;
            this.label6.Text = "Gathering Server Uri/Port";
            // 
            // ipAddressComboBox1
            // 
            this.ipAddressComboBox1.Enabled = false;
            this.ipAddressComboBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ipAddressComboBox1.Location = new System.Drawing.Point(54, 46);
            this.ipAddressComboBox1.Name = "ipAddressComboBox1";
            this.ipAddressComboBox1.Size = new System.Drawing.Size(160, 21);
            this.ipAddressComboBox1.TabIndex = 8;
            this.ipAddressComboBox1.Load += new System.EventHandler(this.ipAddressComboBox1_Load);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(25, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Api Server Uri/Port";
            // 
            // rbtnServerLinkageNonChecked
            // 
            this.rbtnServerLinkageNonChecked.AutoSize = true;
            this.rbtnServerLinkageNonChecked.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnServerLinkageNonChecked.Location = new System.Drawing.Point(19, 3);
            this.rbtnServerLinkageNonChecked.Name = "rbtnServerLinkageNonChecked";
            this.rbtnServerLinkageNonChecked.Size = new System.Drawing.Size(99, 17);
            this.rbtnServerLinkageNonChecked.TabIndex = 7;
            this.rbtnServerLinkageNonChecked.Text = "Server Linkage";
            this.rbtnServerLinkageNonChecked.UseVisualStyleBackColor = true;
            this.rbtnServerLinkageNonChecked.CheckedChanged += new System.EventHandler(this.ServerLinkage_CheckedChanged);
            this.rbtnServerLinkageNonChecked.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnServerLinkage_MouseClick);
            // 
            // rbtnServerLinkageChecked
            // 
            this.rbtnServerLinkageChecked.AutoSize = true;
            this.rbtnServerLinkageChecked.Checked = true;
            this.rbtnServerLinkageChecked.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnServerLinkageChecked.Location = new System.Drawing.Point(19, 3);
            this.rbtnServerLinkageChecked.Name = "rbtnServerLinkageChecked";
            this.rbtnServerLinkageChecked.Size = new System.Drawing.Size(99, 17);
            this.rbtnServerLinkageChecked.TabIndex = 13;
            this.rbtnServerLinkageChecked.TabStop = true;
            this.rbtnServerLinkageChecked.Text = "Server Linkage";
            this.rbtnServerLinkageChecked.UseVisualStyleBackColor = true;
            this.rbtnServerLinkageChecked.CheckedChanged += new System.EventHandler(this.ServerLinkage_CheckedChanged);
            this.rbtnServerLinkageChecked.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnServerLinkageChecked_MouseClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 349);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(281, 83);
            this.panel4.TabIndex = 3;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(18, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(247, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(18, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "CONNECT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.pictureBox1.Image = global::ATST.Properties.Resources.ATWS_로그인페이지_그래픽이미지_1;
            this.pictureBox1.Location = new System.Drawing.Point(296, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 435);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AccessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccessForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccessForm_FormClosed);
            this.Load += new System.EventHandler(this.AccessForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnSerial;
        private System.Windows.Forms.RadioButton rbtnEthernet;
        private System.Windows.Forms.Button btnDeviceSearch;
        private System.Windows.Forms.ComboBox cbxAntennaPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbSerial;
        private System.Windows.Forms.RadioButton rbtnServerLinkageNonChecked;
        private System.Windows.Forms.Label label5;
        private UserControls.Controls.IpAddressComboBox ipAddressComboBox2;
        private System.Windows.Forms.Label label6;
        private UserControls.Controls.IpAddressComboBox ipAddressComboBox1;
        private System.Windows.Forms.TextBox txbGatheringServerPort;
        private System.Windows.Forms.TextBox txbApiServerPort;
        private UserControls.Controls.IpAddressMiniBox ipAddressMiniBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxSerial;
        private System.Windows.Forms.RadioButton rbtnServerLinkageChecked;
    }
}