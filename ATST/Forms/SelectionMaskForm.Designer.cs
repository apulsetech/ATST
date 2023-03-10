namespace ATST.Forms
{
    partial class SelectionMaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionMaskForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeviewMask = new System.Windows.Forms.TreeView();
            this.btnADD = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbEntry = new System.Windows.Forms.Label();
            this.cbxUseSelectionMask = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxSLFlag = new System.Windows.Forms.ComboBox();
            this.cbxTaget = new System.Windows.Forms.ComboBox();
            this.cbxSession = new System.Windows.Forms.ComboBox();
            this.lbSLFlag = new System.Windows.Forms.Label();
            this.lbTarget = new System.Windows.Forms.Label();
            this.lbSession = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeviewMask);
            this.groupBox1.Controls.Add(this.btnADD);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lbEntry);
            this.groupBox1.Controls.Add(this.cbxUseSelectionMask);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // treeviewMask
            // 
            resources.ApplyResources(this.treeviewMask, "treeviewMask");
            this.treeviewMask.Name = "treeviewMask";
            this.treeviewMask.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeviewMask_AfterCheck);
            this.treeviewMask.DoubleClick += new System.EventHandler(this.treeviewMask_DoubleClick);
            // 
            // btnADD
            // 
            this.btnADD.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btnADD, "btnADD");
            this.btnADD.Name = "btnADD";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbEntry
            // 
            resources.ApplyResources(this.lbEntry, "lbEntry");
            this.lbEntry.Name = "lbEntry";
            // 
            // cbxUseSelectionMask
            // 
            resources.ApplyResources(this.cbxUseSelectionMask, "cbxUseSelectionMask");
            this.cbxUseSelectionMask.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbxUseSelectionMask.Name = "cbxUseSelectionMask";
            this.cbxUseSelectionMask.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxSLFlag);
            this.groupBox2.Controls.Add(this.cbxTaget);
            this.groupBox2.Controls.Add(this.cbxSession);
            this.groupBox2.Controls.Add(this.lbSLFlag);
            this.groupBox2.Controls.Add(this.lbTarget);
            this.groupBox2.Controls.Add(this.lbSession);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // cbxSLFlag
            // 
            this.cbxSLFlag.FormattingEnabled = true;
            resources.ApplyResources(this.cbxSLFlag, "cbxSLFlag");
            this.cbxSLFlag.Name = "cbxSLFlag";
            // 
            // cbxTaget
            // 
            this.cbxTaget.FormattingEnabled = true;
            resources.ApplyResources(this.cbxTaget, "cbxTaget");
            this.cbxTaget.Name = "cbxTaget";
            // 
            // cbxSession
            // 
            this.cbxSession.FormattingEnabled = true;
            resources.ApplyResources(this.cbxSession, "cbxSession");
            this.cbxSession.Name = "cbxSession";
            // 
            // lbSLFlag
            // 
            resources.ApplyResources(this.lbSLFlag, "lbSLFlag");
            this.lbSLFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbSLFlag.Name = "lbSLFlag";
            // 
            // lbTarget
            // 
            resources.ApplyResources(this.lbTarget, "lbTarget");
            this.lbTarget.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTarget.Name = "lbTarget";
            // 
            // lbSession
            // 
            resources.ApplyResources(this.lbSession, "lbSession");
            this.lbSession.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbSession.Name = "lbSession";
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
            // SelectionMaskForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectionMaskForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectionMaskForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbxUseSelectionMask;
        private System.Windows.Forms.Label lbEntry;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbSLFlag;
        private System.Windows.Forms.Label lbTarget;
        private System.Windows.Forms.Label lbSession;
        private System.Windows.Forms.ComboBox cbxSLFlag;
        private System.Windows.Forms.ComboBox cbxTaget;
        private System.Windows.Forms.ComboBox cbxSession;
        private System.Windows.Forms.TreeView treeviewMask;
    }
}