namespace MappingTool
{
    partial class frmDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDate));
            this.lblInputValue = new System.Windows.Forms.Label();
            this.txtInputValue = new System.Windows.Forms.TextBox();
            this.lblOutputValue = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.mskDate = new System.Windows.Forms.MaskedTextBox();
            this.btnNone = new System.Windows.Forms.Button();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblInputValue
            // 
            this.lblInputValue.AutoSize = true;
            this.lblInputValue.Location = new System.Drawing.Point(12, 15);
            this.lblInputValue.Name = "lblInputValue";
            this.lblInputValue.Size = new System.Drawing.Size(61, 13);
            this.lblInputValue.TabIndex = 0;
            this.lblInputValue.Text = "Input Value";
            // 
            // txtInputValue
            // 
            this.txtInputValue.Location = new System.Drawing.Point(87, 12);
            this.txtInputValue.Name = "txtInputValue";
            this.txtInputValue.ReadOnly = true;
            this.txtInputValue.Size = new System.Drawing.Size(105, 20);
            this.txtInputValue.TabIndex = 1;
            this.txtInputValue.TabStop = false;
            this.txtInputValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOutputValue
            // 
            this.lblOutputValue.AutoSize = true;
            this.lblOutputValue.Location = new System.Drawing.Point(12, 42);
            this.lblOutputValue.Name = "lblOutputValue";
            this.lblOutputValue.Size = new System.Drawing.Size(69, 13);
            this.lblOutputValue.TabIndex = 2;
            this.lblOutputValue.Text = "Output Value";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(117, 95);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // mskDate
            // 
            this.mskDate.Location = new System.Drawing.Point(87, 38);
            this.mskDate.Mask = "00/00/0000";
            this.mskDate.Name = "mskDate";
            this.mskDate.Size = new System.Drawing.Size(105, 20);
            this.mskDate.TabIndex = 3;
            this.mskDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskDate.ValidatingType = typeof(System.DateTime);
            // 
            // btnNone
            // 
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNone.Location = new System.Drawing.Point(15, 95);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(75, 23);
            this.btnNone.TabIndex = 5;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Checked = true;
            this.chkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSave.Location = new System.Drawing.Point(87, 65);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(51, 17);
            this.chkSave.TabIndex = 4;
            this.chkSave.Text = "Save";
            this.chkSave.UseVisualStyleBackColor = true;
            this.chkSave.Visible = false;
            // 
            // frmDate
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNone;
            this.ClientSize = new System.Drawing.Size(204, 130);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.mskDate);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblOutputValue);
            this.Controls.Add(this.txtInputValue);
            this.Controls.Add(this.lblInputValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter a valid date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputValue;
        private System.Windows.Forms.TextBox txtInputValue;
        private System.Windows.Forms.Label lblOutputValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.MaskedTextBox mskDate;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.CheckBox chkSave;
    }
}