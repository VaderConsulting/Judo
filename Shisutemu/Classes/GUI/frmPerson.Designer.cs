namespace Classes
{
    partial class frmPerson
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
			this.lblName = new System.Windows.Forms.Label();
			this.Tips = new System.Windows.Forms.ToolTip(this.components);
			this.lstSystemComments = new System.Windows.Forms.ListBox();
			this.chkFlagged = new System.Windows.Forms.CheckBox();
			this.lblWeightCategory = new System.Windows.Forms.Label();
			this.txtWeightCategory = new System.Windows.Forms.TextBox();
			this.btnBrowseWeightCategories = new System.Windows.Forms.Button();
			this.lblAgeCategory = new System.Windows.Forms.Label();
			this.txtAgeCategory = new System.Windows.Forms.TextBox();
			this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
			this.lblAge = new System.Windows.Forms.Label();
			this.txtAge = new System.Windows.Forms.TextBox();
			this.txtWeight = new System.Windows.Forms.TextBox();
			this.lblWeight = new System.Windows.Forms.Label();
			this.lblClub = new System.Windows.Forms.Label();
			this.txtClub = new System.Windows.Forms.TextBox();
			this.tlpDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblName.BackColor = System.Drawing.SystemColors.Info;
			this.lblName.Location = new System.Drawing.Point(0, 0);
			this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(440, 15);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name";
			// 
			// lstSystemComments
			// 
			this.lstSystemComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstSystemComments.FormattingEnabled = true;
			this.lstSystemComments.Location = new System.Drawing.Point(7, 132);
			this.lstSystemComments.Margin = new System.Windows.Forms.Padding(2);
			this.lstSystemComments.Name = "lstSystemComments";
			this.lstSystemComments.Size = new System.Drawing.Size(428, 121);
			this.lstSystemComments.TabIndex = 1;
			// 
			// chkFlagged
			// 
			this.chkFlagged.AutoCheck = false;
			this.chkFlagged.AutoSize = true;
			this.chkFlagged.Location = new System.Drawing.Point(8, 254);
			this.chkFlagged.Margin = new System.Windows.Forms.Padding(2);
			this.chkFlagged.Name = "chkFlagged";
			this.chkFlagged.Size = new System.Drawing.Size(64, 17);
			this.chkFlagged.TabIndex = 2;
			this.chkFlagged.Text = "Flagged";
			this.chkFlagged.UseVisualStyleBackColor = true;
			// 
			// lblWeightCategory
			// 
			this.lblWeightCategory.AutoSize = true;
			this.lblWeightCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblWeightCategory.Location = new System.Drawing.Point(16, 24);
			this.lblWeightCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWeightCategory.Name = "lblWeightCategory";
			this.lblWeightCategory.Size = new System.Drawing.Size(175, 24);
			this.lblWeightCategory.TabIndex = 3;
			this.lblWeightCategory.Text = "Weight Category";
			this.lblWeightCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtWeightCategory
			// 
			this.txtWeightCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtWeightCategory.Location = new System.Drawing.Point(209, 26);
			this.txtWeightCategory.Margin = new System.Windows.Forms.Padding(2);
			this.txtWeightCategory.Multiline = true;
			this.txtWeightCategory.Name = "txtWeightCategory";
			this.txtWeightCategory.ReadOnly = true;
			this.txtWeightCategory.Size = new System.Drawing.Size(175, 20);
			this.txtWeightCategory.TabIndex = 4;
			this.txtWeightCategory.Text = "--UNKNOWN--";
			// 
			// btnBrowseWeightCategories
			// 
			this.btnBrowseWeightCategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnBrowseWeightCategories.Location = new System.Drawing.Point(402, 26);
			this.btnBrowseWeightCategories.Margin = new System.Windows.Forms.Padding(2);
			this.btnBrowseWeightCategories.Name = "btnBrowseWeightCategories";
			this.btnBrowseWeightCategories.Size = new System.Drawing.Size(23, 20);
			this.btnBrowseWeightCategories.TabIndex = 5;
			this.btnBrowseWeightCategories.Text = "...";
			this.btnBrowseWeightCategories.UseVisualStyleBackColor = true;
			this.btnBrowseWeightCategories.Click += new System.EventHandler(this.btnBrowseWeightCategories_Click);
			// 
			// lblAgeCategory
			// 
			this.lblAgeCategory.AutoSize = true;
			this.lblAgeCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblAgeCategory.Location = new System.Drawing.Point(16, 0);
			this.lblAgeCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblAgeCategory.Name = "lblAgeCategory";
			this.lblAgeCategory.Size = new System.Drawing.Size(175, 24);
			this.lblAgeCategory.TabIndex = 6;
			this.lblAgeCategory.Text = "Age Category";
			this.lblAgeCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAgeCategory
			// 
			this.txtAgeCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAgeCategory.Location = new System.Drawing.Point(209, 2);
			this.txtAgeCategory.Margin = new System.Windows.Forms.Padding(2);
			this.txtAgeCategory.Multiline = true;
			this.txtAgeCategory.Name = "txtAgeCategory";
			this.txtAgeCategory.ReadOnly = true;
			this.txtAgeCategory.Size = new System.Drawing.Size(175, 20);
			this.txtAgeCategory.TabIndex = 7;
			this.txtAgeCategory.Text = "--UNKNOWN--";
			// 
			// tlpDetails
			// 
			this.tlpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpDetails.ColumnCount = 7;
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
			this.tlpDetails.Controls.Add(this.lblAgeCategory, 1, 0);
			this.tlpDetails.Controls.Add(this.btnBrowseWeightCategories, 5, 1);
			this.tlpDetails.Controls.Add(this.txtAgeCategory, 3, 0);
			this.tlpDetails.Controls.Add(this.txtWeightCategory, 3, 1);
			this.tlpDetails.Controls.Add(this.lblWeightCategory, 1, 1);
			this.tlpDetails.Location = new System.Drawing.Point(0, 44);
			this.tlpDetails.Margin = new System.Windows.Forms.Padding(2);
			this.tlpDetails.Name = "tlpDetails";
			this.tlpDetails.RowCount = 4;
			this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tlpDetails.Size = new System.Drawing.Size(442, 70);
			this.tlpDetails.TabIndex = 8;
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Location = new System.Drawing.Point(15, 19);
			this.lblAge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(26, 13);
			this.lblAge.TabIndex = 9;
			this.lblAge.Text = "Age";
			// 
			// txtAge
			// 
			this.txtAge.Location = new System.Drawing.Point(58, 17);
			this.txtAge.Margin = new System.Windows.Forms.Padding(2);
			this.txtAge.Name = "txtAge";
			this.txtAge.ReadOnly = true;
			this.txtAge.Size = new System.Drawing.Size(30, 20);
			this.txtAge.TabIndex = 10;
			// 
			// txtWeight
			// 
			this.txtWeight.Location = new System.Drawing.Point(134, 17);
			this.txtWeight.Margin = new System.Windows.Forms.Padding(2);
			this.txtWeight.Name = "txtWeight";
			this.txtWeight.ReadOnly = true;
			this.txtWeight.Size = new System.Drawing.Size(98, 20);
			this.txtWeight.TabIndex = 11;
			// 
			// lblWeight
			// 
			this.lblWeight.AutoSize = true;
			this.lblWeight.Location = new System.Drawing.Point(90, 19);
			this.lblWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWeight.Name = "lblWeight";
			this.lblWeight.Size = new System.Drawing.Size(41, 13);
			this.lblWeight.TabIndex = 12;
			this.lblWeight.Text = "Weight";
			// 
			// lblClub
			// 
			this.lblClub.AutoSize = true;
			this.lblClub.Location = new System.Drawing.Point(246, 20);
			this.lblClub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblClub.Name = "lblClub";
			this.lblClub.Size = new System.Drawing.Size(28, 13);
			this.lblClub.TabIndex = 13;
			this.lblClub.Text = "Club";
			// 
			// txtClub
			// 
			this.txtClub.Location = new System.Drawing.Point(278, 17);
			this.txtClub.Margin = new System.Windows.Forms.Padding(2);
			this.txtClub.Name = "txtClub";
			this.txtClub.ReadOnly = true;
			this.txtClub.Size = new System.Drawing.Size(157, 20);
			this.txtClub.TabIndex = 14;
			// 
			// frmPerson
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 275);
			this.Controls.Add(this.txtClub);
			this.Controls.Add(this.lblClub);
			this.Controls.Add(this.lblWeight);
			this.Controls.Add(this.txtWeight);
			this.Controls.Add(this.txtAge);
			this.Controls.Add(this.lblAge);
			this.Controls.Add(this.tlpDetails);
			this.Controls.Add(this.chkFlagged);
			this.Controls.Add(this.lstSystemComments);
			this.Controls.Add(this.lblName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPerson";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmPerson_Load);
			this.tlpDetails.ResumeLayout(false);
			this.tlpDetails.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolTip Tips;
        private System.Windows.Forms.ListBox lstSystemComments;
        private System.Windows.Forms.CheckBox chkFlagged;
        private System.Windows.Forms.Label lblWeightCategory;
        private System.Windows.Forms.TextBox txtWeightCategory;
        private System.Windows.Forms.Button btnBrowseWeightCategories;
        private System.Windows.Forms.Label lblAgeCategory;
        private System.Windows.Forms.TextBox txtAgeCategory;
        private System.Windows.Forms.TableLayoutPanel tlpDetails;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblWeight;
		private System.Windows.Forms.Label lblClub;
		private System.Windows.Forms.TextBox txtClub;
	}
}