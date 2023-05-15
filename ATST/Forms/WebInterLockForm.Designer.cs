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
            this.btnStart = new System.Windows.Forms.Button();
            this.listViewDeviceList = new System.Windows.Forms.ListView();
            this.colDeviceId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 232);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(220, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // listViewDeviceList
            // 
            this.listViewDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDeviceId,
            this.colDeviceName});
            this.listViewDeviceList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewDeviceList.FullRowSelect = true;
            this.listViewDeviceList.GridLines = true;
            this.listViewDeviceList.HideSelection = false;
            this.listViewDeviceList.Location = new System.Drawing.Point(12, 12);
            this.listViewDeviceList.Name = "listViewDeviceList";
            this.listViewDeviceList.Size = new System.Drawing.Size(220, 214);
            this.listViewDeviceList.TabIndex = 8;
            this.listViewDeviceList.UseCompatibleStateImageBehavior = false;
            this.listViewDeviceList.View = System.Windows.Forms.View.Details;
            this.listViewDeviceList.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listViewDeviceList_RetrieveVirtualItem);
            this.listViewDeviceList.SelectedIndexChanged += new System.EventHandler(this.listViewDeviceList_SelectedIndexChanged);
            this.listViewDeviceList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewDeviceList_MouseDoubleClick);
            // 
            // colDeviceId
            // 
            this.colDeviceId.Text = "DeviceId";
            this.colDeviceId.Width = 110;
            // 
            // colDeviceName
            // 
            this.colDeviceName.Text = "DeviceName";
            this.colDeviceName.Width = 110;
            // 
            // WebInterLockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 274);
            this.Controls.Add(this.listViewDeviceList);
            this.Controls.Add(this.btnStart);
            this.Name = "WebInterLockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WebInterLockForm";
            this.Load += new System.EventHandler(this.WebInterLockForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ColumnHeader colDeviceId;
        private System.Windows.Forms.ColumnHeader colDeviceName;
        public System.Windows.Forms.ListView listViewDeviceList;
    }
}