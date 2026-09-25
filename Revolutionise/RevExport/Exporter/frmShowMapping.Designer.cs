namespace MappingTool
{
    partial class frmShowMapping
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
            this.lvwMapping = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblValueText = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwMapping
            // 
            this.lvwMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwMapping.FullRowSelect = true;
            this.lvwMapping.HideSelection = false;
            this.lvwMapping.Location = new System.Drawing.Point(13, 39);
            this.lvwMapping.Name = "lvwMapping";
            this.lvwMapping.Size = new System.Drawing.Size(439, 366);
            this.lvwMapping.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwMapping.TabIndex = 2;
            this.lvwMapping.UseCompatibleStateImageBehavior = false;
            this.lvwMapping.View = System.Windows.Forms.View.Details;
            this.lvwMapping.SelectedIndexChanged += new System.EventHandler(this.lvwMapping_SelectedIndexChanged);
            this.lvwMapping.DoubleClick += new System.EventHandler(this.lvwMapping_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Output Value";
            this.columnHeader1.Width = 315;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Match %";
            this.columnHeader2.Width = 96;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.GreenYellow;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(377, 411);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblValueText
            // 
            this.lblValueText.AutoSize = true;
            this.lblValueText.Location = new System.Drawing.Point(13, 13);
            this.lblValueText.Name = "lblValueText";
            this.lblValueText.Size = new System.Drawing.Size(119, 13);
            this.lblValueText.TabIndex = 0;
            this.lblValueText.Text = "Imported Column Value:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(138, 13);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(39, 13);
            this.lblValue.TabIndex = 1;
            this.lblValue.Text = "Value";
            // 
            // lblHint
            // 
            this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(13, 416);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(24, 13);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "Idle";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(296, 411);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(215, 411);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmShowMapping
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 441);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblValueText);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lvwMapping);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(480, 2000);
            this.MinimumSize = new System.Drawing.Size(480, 240);
            this.Name = "frmShowMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapping";
            this.Load += new System.EventHandler(this.frmMapping_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwMapping;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblValueText;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCancel;
    }
}