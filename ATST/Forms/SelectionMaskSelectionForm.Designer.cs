namespace ATST.Forms
{
    partial class SelectionMaskSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionMaskSelectionForm));
            this.lbBank = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbTarget = new System.Windows.Forms.Label();
            this.lbAction = new System.Windows.Forms.Label();
            this.lbOffset = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbMask = new System.Windows.Forms.Label();
            this.cbxBank = new System.Windows.Forms.ComboBox();
            this.cbxTarget = new System.Windows.Forms.ComboBox();
            this.cbxAction = new System.Windows.Forms.ComboBox();
            this.txbOffset = new System.Windows.Forms.TextBox();
            this.txbLength = new System.Windows.Forms.TextBox();
            this.txbMask = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbBank
            // 
            resources.ApplyResources(this.lbBank, "lbBank");
            this.lbBank.Name = "lbBank";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbTarget
            // 
            resources.ApplyResources(this.lbTarget, "lbTarget");
            this.lbTarget.Name = "lbTarget";
            // 
            // lbAction
            // 
            resources.ApplyResources(this.lbAction, "lbAction");
            this.lbAction.Name = "lbAction";
            // 
            // lbOffset
            // 
            resources.ApplyResources(this.lbOffset, "lbOffset");
            this.lbOffset.Name = "lbOffset";
            // 
            // lbLength
            // 
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Name = "lbLength";
            // 
            // lbMask
            // 
            resources.ApplyResources(this.lbMask, "lbMask");
            this.lbMask.Name = "lbMask";
            // 
            // cbxBank
            // 
            resources.ApplyResources(this.cbxBank, "cbxBank");
            this.cbxBank.FormattingEnabled = true;
            this.cbxBank.Name = "cbxBank";
            this.cbxBank.SelectedIndexChanged += new System.EventHandler(this.cbxBank_SelectedIndexChanged);
            // 
            // cbxTarget
            // 
            resources.ApplyResources(this.cbxTarget, "cbxTarget");
            this.cbxTarget.FormattingEnabled = true;
            this.cbxTarget.Name = "cbxTarget";
            this.cbxTarget.SelectedIndexChanged += new System.EventHandler(this.cbxTarget_SelectedIndexChanged);
            // 
            // cbxAction
            // 
            resources.ApplyResources(this.cbxAction, "cbxAction");
            this.cbxAction.FormattingEnabled = true;
            this.cbxAction.Name = "cbxAction";
            this.cbxAction.SelectedIndexChanged += new System.EventHandler(this.cbxAction_SelectedIndexChanged);
            // 
            // txbOffset
            // 
            resources.ApplyResources(this.txbOffset, "txbOffset");
            this.txbOffset.Name = "txbOffset";
            this.txbOffset.TextChanged += new System.EventHandler(this.txbOffset_TextChanged);
            this.txbOffset.Enter += new System.EventHandler(this.txbOffset_Enter);
            this.txbOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbOffset_KeyPress);
            this.txbOffset.Leave += new System.EventHandler(this.txbOffset_Leave);
            // 
            // txbLength
            // 
            resources.ApplyResources(this.txbLength, "txbLength");
            this.txbLength.Name = "txbLength";
            this.txbLength.TextChanged += new System.EventHandler(this.txbLength_TextChanged);
            this.txbLength.Enter += new System.EventHandler(this.txbLength_Enter);
            this.txbLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbLength_KeyPress);
            this.txbLength.Leave += new System.EventHandler(this.txbLength_Leave);
            // 
            // txbMask
            // 
            resources.ApplyResources(this.txbMask, "txbMask");
            this.txbMask.Name = "txbMask";
            this.txbMask.TextChanged += new System.EventHandler(this.txbMask_TextChanged);
            this.txbMask.Enter += new System.EventHandler(this.txbMask_Enter);
            this.txbMask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbMask_KeyPress);
            this.txbMask.Leave += new System.EventHandler(this.txbMask_Leave);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Name = "label7";
            // 
            // SelectionMaskSelectionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbMask);
            this.Controls.Add(this.txbLength);
            this.Controls.Add(this.txbOffset);
            this.Controls.Add(this.cbxAction);
            this.Controls.Add(this.cbxTarget);
            this.Controls.Add(this.cbxBank);
            this.Controls.Add(this.lbMask);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.lbOffset);
            this.Controls.Add(this.lbAction);
            this.Controls.Add(this.lbTarget);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbBank);
            this.Name = "SelectionMaskSelectionForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectionMaskSelectionForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBank;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbTarget;
        private System.Windows.Forms.Label lbAction;
        private System.Windows.Forms.Label lbOffset;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Label lbMask;
        private System.Windows.Forms.ComboBox cbxBank;
        private System.Windows.Forms.ComboBox cbxTarget;
        private System.Windows.Forms.ComboBox cbxAction;
        private System.Windows.Forms.TextBox txbOffset;
        private System.Windows.Forms.TextBox txbLength;
        private System.Windows.Forms.TextBox txbMask;
        private System.Windows.Forms.Label label7;
    }
}