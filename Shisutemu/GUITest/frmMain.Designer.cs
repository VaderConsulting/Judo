namespace GUITest
{
    partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.lblAgeCategories = new System.Windows.Forms.Label();
			this.lblWeightCategories = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lstMats = new System.Windows.Forms.ListBox();
			this.lblMats = new System.Windows.Forms.Label();
			this.lvwWeightCategories = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvwAgeCategories = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvwPeople = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imlColours = new System.Windows.Forms.ImageList(this.components);
			this.btnClubs = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblAgeCategories
			// 
			this.lblAgeCategories.AutoSize = true;
			this.lblAgeCategories.Location = new System.Drawing.Point(9, 8);
			this.lblAgeCategories.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblAgeCategories.Name = "lblAgeCategories";
			this.lblAgeCategories.Size = new System.Drawing.Size(79, 13);
			this.lblAgeCategories.TabIndex = 4;
			this.lblAgeCategories.Text = "Age Categories";
			// 
			// lblWeightCategories
			// 
			this.lblWeightCategories.AutoSize = true;
			this.lblWeightCategories.Location = new System.Drawing.Point(255, 8);
			this.lblWeightCategories.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWeightCategories.Name = "lblWeightCategories";
			this.lblWeightCategories.Size = new System.Drawing.Size(94, 13);
			this.lblWeightCategories.TabIndex = 5;
			this.lblWeightCategories.Text = "Weight Categories";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(504, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "People";
			// 
			// lstMats
			// 
			this.lstMats.FormattingEnabled = true;
			this.lstMats.Location = new System.Drawing.Point(755, 23);
			this.lstMats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.lstMats.Name = "lstMats";
			this.lstMats.Size = new System.Drawing.Size(67, 108);
			this.lstMats.TabIndex = 8;
			this.lstMats.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMats_MouseDoubleClick);
			// 
			// lblMats
			// 
			this.lblMats.AutoSize = true;
			this.lblMats.Location = new System.Drawing.Point(757, 6);
			this.lblMats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblMats.Name = "lblMats";
			this.lblMats.Size = new System.Drawing.Size(30, 13);
			this.lblMats.TabIndex = 9;
			this.lblMats.Text = "Mats";
			// 
			// lvwWeightCategories
			// 
			this.lvwWeightCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lvwWeightCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lvwWeightCategories.FullRowSelect = true;
			this.lvwWeightCategories.Location = new System.Drawing.Point(257, 23);
			this.lvwWeightCategories.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.lvwWeightCategories.MultiSelect = false;
			this.lvwWeightCategories.Name = "lvwWeightCategories";
			this.lvwWeightCategories.Size = new System.Drawing.Size(247, 433);
			this.lvwWeightCategories.TabIndex = 11;
			this.lvwWeightCategories.UseCompatibleStateImageBehavior = false;
			this.lvwWeightCategories.View = System.Windows.Forms.View.Details;
			this.lvwWeightCategories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwWeightCategories_MouseDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 200;
			// 
			// lvwAgeCategories
			// 
			this.lvwAgeCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lvwAgeCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
			this.lvwAgeCategories.FullRowSelect = true;
			this.lvwAgeCategories.Location = new System.Drawing.Point(8, 23);
			this.lvwAgeCategories.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.lvwAgeCategories.Name = "lvwAgeCategories";
			this.lvwAgeCategories.Size = new System.Drawing.Size(247, 433);
			this.lvwAgeCategories.TabIndex = 12;
			this.lvwAgeCategories.UseCompatibleStateImageBehavior = false;
			this.lvwAgeCategories.View = System.Windows.Forms.View.Details;
			this.lvwAgeCategories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwAgeCategories_MouseDoubleClick);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 200;
			// 
			// lvwPeople
			// 
			this.lvwPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lvwPeople.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
			this.lvwPeople.FullRowSelect = true;
			this.lvwPeople.Location = new System.Drawing.Point(507, 23);
			this.lvwPeople.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.lvwPeople.Name = "lvwPeople";
			this.lvwPeople.Size = new System.Drawing.Size(247, 433);
			this.lvwPeople.SmallImageList = this.imlColours;
			this.lvwPeople.TabIndex = 13;
			this.lvwPeople.UseCompatibleStateImageBehavior = false;
			this.lvwPeople.View = System.Windows.Forms.View.Details;
			this.lvwPeople.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwPeople_MouseDoubleClick);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Name";
			this.columnHeader3.Width = 200;
			// 
			// imlColours
			// 
			this.imlColours.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlColours.ImageStream")));
			this.imlColours.TransparentColor = System.Drawing.Color.Transparent;
			this.imlColours.Images.SetKeyName(0, "White.png");
			this.imlColours.Images.SetKeyName(1, "YellowWhite.png");
			this.imlColours.Images.SetKeyName(2, "Yellow.png");
			this.imlColours.Images.SetKeyName(3, "OrangeYellow.png");
			this.imlColours.Images.SetKeyName(4, "Orange.png");
			this.imlColours.Images.SetKeyName(5, "GreenOrange.png");
			this.imlColours.Images.SetKeyName(6, "Green.png");
			this.imlColours.Images.SetKeyName(7, "BlueGreen.png");
			this.imlColours.Images.SetKeyName(8, "Blue.png");
			this.imlColours.Images.SetKeyName(9, "BrownBlue.png");
			this.imlColours.Images.SetKeyName(10, "Brown.png");
			this.imlColours.Images.SetKeyName(11, "Black.png");
			// 
			// btnClubs
			// 
			this.btnClubs.Location = new System.Drawing.Point(758, 136);
			this.btnClubs.Name = "btnClubs";
			this.btnClubs.Size = new System.Drawing.Size(64, 39);
			this.btnClubs.TabIndex = 14;
			this.btnClubs.Text = "Clubs";
			this.btnClubs.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(829, 462);
			this.Controls.Add(this.btnClubs);
			this.Controls.Add(this.lvwPeople);
			this.Controls.Add(this.lvwAgeCategories);
			this.Controls.Add(this.lvwWeightCategories);
			this.Controls.Add(this.lblMats);
			this.Controls.Add(this.lstMats);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblWeightCategories);
			this.Controls.Add(this.lblAgeCategories);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Test";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAgeCategories;
        private System.Windows.Forms.Label lblWeightCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMats;
        private System.Windows.Forms.Label lblMats;
        private System.Windows.Forms.ListView lvwWeightCategories;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvwAgeCategories;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvwPeople;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imlColours;
		private System.Windows.Forms.Button btnClubs;
	}
}

