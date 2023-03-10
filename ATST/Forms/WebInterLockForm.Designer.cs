namespace ATST.Forms.Diagnotics
{
    partial class WebInterLockForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxAPIServer = new ATST.Forms.Diagnotics.MaskedComboBox();
            this.cbxGatheringServer = new ATST.Forms.Diagnotics.MaskedComboBox();
            this.txbGatheringServerPort = new System.Windows.Forms.TextBox();
            this.txbApiServerPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxAPIServer
            // 
            this.cbxAPIServer.FormattingEnabled = true;
            this.cbxAPIServer.Location = new System.Drawing.Point(12, 87);
            this.cbxAPIServer.Name = "cbxAPIServer";
            this.cbxAPIServer.Size = new System.Drawing.Size(157, 20);
            this.cbxAPIServer.TabIndex = 2;
            this.cbxAPIServer.Text = "   .   .   .";
            this.cbxAPIServer.SelectedIndexChanged += new System.EventHandler(this.cbxAPIServer_SelectedIndexChanged);
            this.cbxAPIServer.Enter += new System.EventHandler(this.cbxAPIServer_Enter);
            this.cbxAPIServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxAPIServer_KeyPress_1);
            // 
            // cbxGatheringServer
            // 
            this.cbxGatheringServer.FormattingEnabled = true;
            this.cbxGatheringServer.Location = new System.Drawing.Point(12, 113);
            this.cbxGatheringServer.Name = "cbxGatheringServer";
            this.cbxGatheringServer.Size = new System.Drawing.Size(157, 20);
            this.cbxGatheringServer.TabIndex = 3;
            this.cbxGatheringServer.Text = "   .   .   .";
            // 
            // txbGatheringServerPort
            // 
            this.txbGatheringServerPort.Location = new System.Drawing.Point(12, 39);
            this.txbGatheringServerPort.Name = "txbGatheringServerPort";
            this.txbGatheringServerPort.Size = new System.Drawing.Size(57, 21);
            this.txbGatheringServerPort.TabIndex = 5;
            // 
            // txbApiServerPort
            // 
            this.txbApiServerPort.Location = new System.Drawing.Point(12, 12);
            this.txbApiServerPort.Name = "txbApiServerPort";
            this.txbApiServerPort.Size = new System.Drawing.Size(57, 21);
            this.txbApiServerPort.TabIndex = 4;
            // 
            // WebInterLockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 359);
            this.Controls.Add(this.txbGatheringServerPort);
            this.Controls.Add(this.txbApiServerPort);
            this.Controls.Add(this.cbxGatheringServer);
            this.Controls.Add(this.cbxAPIServer);
            this.Controls.Add(this.btnSave);
            this.Name = "WebInterLockForm";
            this.Text = "WebInterLockForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private MaskedComboBox cbxAPIServer;
        private MaskedComboBox cbxGatheringServer;
        private System.Windows.Forms.TextBox txbGatheringServerPort;
        private System.Windows.Forms.TextBox txbApiServerPort;
    }
}