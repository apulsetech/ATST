namespace ATST.Forms
{
    partial class ReaderSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReaderSettingForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxContinuousMode = new System.Windows.Forms.CheckBox();
            this.cbxFastID = new System.Windows.Forms.CheckBox();
            this.cbxToggle = new System.Windows.Forms.CheckBox();
            this.cbxChannel = new System.Windows.Forms.CheckBox();
            this.cbxSound = new System.Windows.Forms.CheckBox();
            this.cbxPhase = new System.Windows.Forms.CheckBox();
            this.cbxTrigger = new System.Windows.Forms.CheckBox();
            this.cbxRssi = new System.Windows.Forms.CheckBox();
            this.cbxBeepUniqueOnly = new System.Windows.Forms.CheckBox();
            this.cbxPC = new System.Windows.Forms.CheckBox();
            this.cbxRemoteFilter = new System.Windows.Forms.CheckBox();
            this.cbxFilter = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbTimeout = new System.Windows.Forms.TextBox();
            this.txbInterval = new System.Windows.Forms.TextBox();
            this.lbInterval = new System.Windows.Forms.Label();
            this.lbTimeout = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txbTxOffTime = new System.Windows.Forms.TextBox();
            this.txbTxOnTime = new System.Windows.Forms.TextBox();
            this.lbTxOffTime = new System.Windows.Forms.Label();
            this.lbTxOnTime = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxContinuousMode);
            this.groupBox1.Controls.Add(this.cbxFastID);
            this.groupBox1.Controls.Add(this.cbxToggle);
            this.groupBox1.Controls.Add(this.cbxChannel);
            this.groupBox1.Controls.Add(this.cbxSound);
            this.groupBox1.Controls.Add(this.cbxPhase);
            this.groupBox1.Controls.Add(this.cbxTrigger);
            this.groupBox1.Controls.Add(this.cbxRssi);
            this.groupBox1.Controls.Add(this.cbxBeepUniqueOnly);
            this.groupBox1.Controls.Add(this.cbxPC);
            this.groupBox1.Controls.Add(this.cbxRemoteFilter);
            this.groupBox1.Controls.Add(this.cbxFilter);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cbxContinuousMode
            // 
            resources.ApplyResources(this.cbxContinuousMode, "cbxContinuousMode");
            this.cbxContinuousMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxContinuousMode.Name = "cbxContinuousMode";
            this.cbxContinuousMode.UseVisualStyleBackColor = true;
            this.cbxContinuousMode.CheckedChanged += new System.EventHandler(this.cbxContinuousMode_CheckedChanged);
            // 
            // cbxFastID
            // 
            resources.ApplyResources(this.cbxFastID, "cbxFastID");
            this.cbxFastID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxFastID.Name = "cbxFastID";
            this.cbxFastID.UseVisualStyleBackColor = true;
            this.cbxFastID.CheckedChanged += new System.EventHandler(this.cbxFastID_CheckedChanged);
            // 
            // cbxToggle
            // 
            resources.ApplyResources(this.cbxToggle, "cbxToggle");
            this.cbxToggle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxToggle.Name = "cbxToggle";
            this.cbxToggle.UseVisualStyleBackColor = true;
            this.cbxToggle.CheckedChanged += new System.EventHandler(this.cbxToggle_CheckedChanged);
            // 
            // cbxChannel
            // 
            resources.ApplyResources(this.cbxChannel, "cbxChannel");
            this.cbxChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxChannel.Name = "cbxChannel";
            this.cbxChannel.UseVisualStyleBackColor = true;
            this.cbxChannel.CheckedChanged += new System.EventHandler(this.cbxChannel_CheckedChanged);
            // 
            // cbxSound
            // 
            resources.ApplyResources(this.cbxSound, "cbxSound");
            this.cbxSound.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxSound.Name = "cbxSound";
            this.cbxSound.UseVisualStyleBackColor = true;
            this.cbxSound.CheckedChanged += new System.EventHandler(this.cbxSound_CheckedChanged);
            // 
            // cbxPhase
            // 
            resources.ApplyResources(this.cbxPhase, "cbxPhase");
            this.cbxPhase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxPhase.Name = "cbxPhase";
            this.cbxPhase.UseVisualStyleBackColor = true;
            this.cbxPhase.CheckedChanged += new System.EventHandler(this.cbxPhase_CheckedChanged);
            // 
            // cbxTrigger
            // 
            resources.ApplyResources(this.cbxTrigger, "cbxTrigger");
            this.cbxTrigger.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxTrigger.Name = "cbxTrigger";
            this.cbxTrigger.UseVisualStyleBackColor = true;
            this.cbxTrigger.CheckedChanged += new System.EventHandler(this.cbxTrigger_CheckedChanged);
            // 
            // cbxRssi
            // 
            resources.ApplyResources(this.cbxRssi, "cbxRssi");
            this.cbxRssi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxRssi.Name = "cbxRssi";
            this.cbxRssi.UseVisualStyleBackColor = true;
            this.cbxRssi.CheckedChanged += new System.EventHandler(this.cbxRssi_CheckedChanged);
            // 
            // cbxBeepUniqueOnly
            // 
            resources.ApplyResources(this.cbxBeepUniqueOnly, "cbxBeepUniqueOnly");
            this.cbxBeepUniqueOnly.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxBeepUniqueOnly.Name = "cbxBeepUniqueOnly";
            this.cbxBeepUniqueOnly.UseVisualStyleBackColor = true;
            this.cbxBeepUniqueOnly.CheckedChanged += new System.EventHandler(this.cbxBeepUniqueOnly_CheckedChanged);
            // 
            // cbxPC
            // 
            resources.ApplyResources(this.cbxPC, "cbxPC");
            this.cbxPC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxPC.Name = "cbxPC";
            this.cbxPC.UseVisualStyleBackColor = true;
            this.cbxPC.CheckedChanged += new System.EventHandler(this.cbxPC_CheckedChanged);
            // 
            // cbxRemoteFilter
            // 
            resources.ApplyResources(this.cbxRemoteFilter, "cbxRemoteFilter");
            this.cbxRemoteFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxRemoteFilter.Name = "cbxRemoteFilter";
            this.cbxRemoteFilter.UseVisualStyleBackColor = true;
            this.cbxRemoteFilter.CheckedChanged += new System.EventHandler(this.cbxRemoteFilter_CheckedChanged);
            // 
            // cbxFilter
            // 
            resources.ApplyResources(this.cbxFilter, "cbxFilter");
            this.cbxFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.UseVisualStyleBackColor = true;
            this.cbxFilter.CheckedChanged += new System.EventHandler(this.cbxFilter_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbTimeout);
            this.groupBox2.Controls.Add(this.txbInterval);
            this.groupBox2.Controls.Add(this.lbInterval);
            this.groupBox2.Controls.Add(this.lbTimeout);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // txbTimeout
            // 
            resources.ApplyResources(this.txbTimeout, "txbTimeout");
            this.txbTimeout.Name = "txbTimeout";
            this.txbTimeout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txbTimeout_MouseClick);
            this.txbTimeout.TextChanged += new System.EventHandler(this.txbTimeout_TextChanged);
            this.txbTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTimeout_KeyPress);
            this.txbTimeout.Leave += new System.EventHandler(this.txbTimeout_Leave);
            // 
            // txbInterval
            // 
            resources.ApplyResources(this.txbInterval, "txbInterval");
            this.txbInterval.Name = "txbInterval";
            this.txbInterval.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txbInterval_MouseClick);
            this.txbInterval.TextChanged += new System.EventHandler(this.txbInterval_TextChanged);
            this.txbInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbInterval_KeyPress);
            this.txbInterval.Leave += new System.EventHandler(this.txbInterval_Leave);
            // 
            // lbInterval
            // 
            resources.ApplyResources(this.lbInterval, "lbInterval");
            this.lbInterval.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbInterval.Name = "lbInterval";
            // 
            // lbTimeout
            // 
            resources.ApplyResources(this.lbTimeout, "lbTimeout");
            this.lbTimeout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTimeout.Name = "lbTimeout";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txbTxOffTime);
            this.groupBox3.Controls.Add(this.txbTxOnTime);
            this.groupBox3.Controls.Add(this.lbTxOffTime);
            this.groupBox3.Controls.Add(this.lbTxOnTime);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // txbTxOffTime
            // 
            resources.ApplyResources(this.txbTxOffTime, "txbTxOffTime");
            this.txbTxOffTime.Name = "txbTxOffTime";
            this.txbTxOffTime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txbTxOffTime_MouseClick);
            this.txbTxOffTime.TextChanged += new System.EventHandler(this.txbTxOffTime_TextChanged);
            this.txbTxOffTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTxOffTime_KeyPress);
            this.txbTxOffTime.Leave += new System.EventHandler(this.txbTxOffTime_Leave);
            // 
            // txbTxOnTime
            // 
            resources.ApplyResources(this.txbTxOnTime, "txbTxOnTime");
            this.txbTxOnTime.Name = "txbTxOnTime";
            this.txbTxOnTime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txbTxOnTime_MouseClick);
            this.txbTxOnTime.TextChanged += new System.EventHandler(this.txbTxOnTime_TextChanged);
            this.txbTxOnTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTxOnTime_KeyPress);
            this.txbTxOnTime.Leave += new System.EventHandler(this.txbTxOnTime_Leave);
            // 
            // lbTxOffTime
            // 
            resources.ApplyResources(this.lbTxOffTime, "lbTxOffTime");
            this.lbTxOffTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTxOffTime.Name = "lbTxOffTime";
            // 
            // lbTxOnTime
            // 
            resources.ApplyResources(this.lbTxOnTime, "lbTxOnTime");
            this.lbTxOnTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTxOnTime.Name = "lbTxOnTime";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ReaderSettingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReaderSettingForm";
            this.Load += new System.EventHandler(this.ReaderSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxContinuousMode;
        private System.Windows.Forms.CheckBox cbxFastID;
        private System.Windows.Forms.CheckBox cbxToggle;
        private System.Windows.Forms.CheckBox cbxChannel;
        private System.Windows.Forms.CheckBox cbxSound;
        private System.Windows.Forms.CheckBox cbxPhase;
        private System.Windows.Forms.CheckBox cbxTrigger;
        private System.Windows.Forms.CheckBox cbxRssi;
        private System.Windows.Forms.CheckBox cbxBeepUniqueOnly;
        private System.Windows.Forms.CheckBox cbxPC;
        private System.Windows.Forms.CheckBox cbxRemoteFilter;
        private System.Windows.Forms.CheckBox cbxFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbInterval;
        private System.Windows.Forms.Label lbTimeout;
        private System.Windows.Forms.Label lbTxOffTime;
        private System.Windows.Forms.Label lbTxOnTime;
        private System.Windows.Forms.TextBox txbInterval;
        private System.Windows.Forms.TextBox txbTxOffTime;
        private System.Windows.Forms.TextBox txbTxOnTime;
        private System.Windows.Forms.TextBox txbTimeout;
    }
}