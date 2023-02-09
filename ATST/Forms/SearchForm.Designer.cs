namespace ATST.Forms
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listviewDeviceList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnStartSearch
            // 
            resources.ApplyResources(this.btnStartSearch, "btnStartSearch");
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // listviewDeviceList
            // 
            this.listviewDeviceList.FullRowSelect = true;
            this.listviewDeviceList.GridLines = true;
            this.listviewDeviceList.HideSelection = false;
            resources.ApplyResources(this.listviewDeviceList, "listviewDeviceList");
            this.listviewDeviceList.Name = "listviewDeviceList";
            this.listviewDeviceList.UseCompatibleStateImageBehavior = false;
            this.listviewDeviceList.View = System.Windows.Forms.View.Details;
            this.listviewDeviceList.DoubleClick += new System.EventHandler(this.listviewDeviceList_DoubleClick);
            // 
            // SearchForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listviewDeviceList);
            this.Name = "SearchForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listviewDeviceList;
        public System.Windows.Forms.Button btnStartSearch;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.Button btnCancel;
    }
}