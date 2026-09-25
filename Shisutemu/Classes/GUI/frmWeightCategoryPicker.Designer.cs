namespace Classes
{
    partial class frmWeightCategoryPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeightCategoryPicker));
            this.lvwCategories = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlColours = new System.Windows.Forms.ImageList(this.components);
            this.btnUp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grpSelected = new System.Windows.Forms.GroupBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.picBelt = new System.Windows.Forms.PictureBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.imlBelts = new System.Windows.Forms.ImageList(this.components);
            this.grpKey = new System.Windows.Forms.GroupBox();
            this.lblEqual = new System.Windows.Forms.Label();
            this.txtEqual = new System.Windows.Forms.TextBox();
            this.lblOver5Percent = new System.Windows.Forms.Label();
            this.lblWithin5Percent = new System.Windows.Forms.Label();
            this.txtOver5Percent = new System.Windows.Forms.TextBox();
            this.txtWithin5Percent = new System.Windows.Forms.TextBox();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lvwUpperCategory = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlCategories = new System.Windows.Forms.Panel();
            this.lblOtherAgeAndWeightCategories = new System.Windows.Forms.Label();
            this.lblSelectedCategory = new System.Windows.Forms.Label();
            this.grpSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBelt)).BeginInit();
            this.grpKey.SuspendLayout();
            this.pnlCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwCategories
            // 
            this.lvwCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwCategories.FullRowSelect = true;
            this.lvwCategories.Location = new System.Drawing.Point(3, 27);
            this.lvwCategories.MultiSelect = false;
            this.lvwCategories.Name = "lvwCategories";
            this.lvwCategories.Size = new System.Drawing.Size(293, 522);
            this.lvwCategories.SmallImageList = this.imlColours;
            this.lvwCategories.TabIndex = 0;
            this.lvwCategories.UseCompatibleStateImageBehavior = false;
            this.lvwCategories.View = System.Windows.Forms.View.Details;
            this.lvwCategories.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwCategories_ItemSelectionChanged);
            this.lvwCategories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwCategories_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 226;
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
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(936, 419);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(37, 71);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "A";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(311, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // grpSelected
            // 
            this.grpSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSelected.Controls.Add(this.txtWeight);
            this.grpSelected.Controls.Add(this.lblWeight);
            this.grpSelected.Controls.Add(this.picBelt);
            this.grpSelected.Controls.Add(this.lblAge);
            this.grpSelected.Controls.Add(this.txtAge);
            this.grpSelected.Controls.Add(this.txtPersonName);
            this.grpSelected.Controls.Add(this.lblPersonName);
            this.grpSelected.Location = new System.Drawing.Point(936, 13);
            this.grpSelected.Name = "grpSelected";
            this.grpSelected.Size = new System.Drawing.Size(333, 189);
            this.grpSelected.TabIndex = 3;
            this.grpSelected.TabStop = false;
            this.grpSelected.Text = "Selected";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(86, 90);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Size = new System.Drawing.Size(60, 26);
            this.txtWeight.TabIndex = 6;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(7, 93);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(59, 20);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "Weight";
            // 
            // picBelt
            // 
            this.picBelt.Location = new System.Drawing.Point(11, 122);
            this.picBelt.Name = "picBelt";
            this.picBelt.Size = new System.Drawing.Size(263, 50);
            this.picBelt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBelt.TabIndex = 4;
            this.picBelt.TabStop = false;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(7, 61);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(38, 20);
            this.lblAge.TabIndex = 3;
            this.lblAge.Text = "Age";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(86, 58);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(60, 26);
            this.txtAge.TabIndex = 2;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(86, 26);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.ReadOnly = true;
            this.txtPersonName.Size = new System.Drawing.Size(188, 26);
            this.txtPersonName.TabIndex = 1;
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Location = new System.Drawing.Point(7, 26);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(51, 20);
            this.lblPersonName.TabIndex = 0;
            this.lblPersonName.Text = "Name";
            // 
            // imlBelts
            // 
            this.imlBelts.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBelts.ImageStream")));
            this.imlBelts.TransparentColor = System.Drawing.Color.Transparent;
            this.imlBelts.Images.SetKeyName(0, "WhiteBelt.png");
            this.imlBelts.Images.SetKeyName(1, "YellowWhiteBelt.png");
            this.imlBelts.Images.SetKeyName(2, "YellowBelt.png");
            this.imlBelts.Images.SetKeyName(3, "OrangeYellowBelt.png");
            this.imlBelts.Images.SetKeyName(4, "OrangeBelt.png");
            this.imlBelts.Images.SetKeyName(5, "GreenOrangeBelt.png");
            this.imlBelts.Images.SetKeyName(6, "GreenBelt.png");
            this.imlBelts.Images.SetKeyName(7, "BlueGreenBelt.png");
            this.imlBelts.Images.SetKeyName(8, "BlueBelt.png");
            this.imlBelts.Images.SetKeyName(9, "BrownBlueBelt.png");
            this.imlBelts.Images.SetKeyName(10, "BrownBelt.png");
            this.imlBelts.Images.SetKeyName(11, "BlackBelt.png");
            // 
            // grpKey
            // 
            this.grpKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKey.Controls.Add(this.lblEqual);
            this.grpKey.Controls.Add(this.txtEqual);
            this.grpKey.Controls.Add(this.lblOver5Percent);
            this.grpKey.Controls.Add(this.lblWithin5Percent);
            this.grpKey.Controls.Add(this.txtOver5Percent);
            this.grpKey.Controls.Add(this.txtWithin5Percent);
            this.grpKey.Controls.Add(this.txtSelected);
            this.grpKey.Controls.Add(this.lblSelected);
            this.grpKey.Location = new System.Drawing.Point(936, 208);
            this.grpKey.Name = "grpKey";
            this.grpKey.Size = new System.Drawing.Size(333, 168);
            this.grpKey.TabIndex = 4;
            this.grpKey.TabStop = false;
            this.grpKey.Text = "Key";
            // 
            // lblEqual
            // 
            this.lblEqual.AutoSize = true;
            this.lblEqual.Location = new System.Drawing.Point(12, 61);
            this.lblEqual.Name = "lblEqual";
            this.lblEqual.Size = new System.Drawing.Size(50, 20);
            this.lblEqual.TabIndex = 8;
            this.lblEqual.Text = "Equal";
            // 
            // txtEqual
            // 
            this.txtEqual.BackColor = System.Drawing.Color.LightGreen;
            this.txtEqual.Location = new System.Drawing.Point(107, 58);
            this.txtEqual.Name = "txtEqual";
            this.txtEqual.Size = new System.Drawing.Size(162, 26);
            this.txtEqual.TabIndex = 7;
            // 
            // lblOver5Percent
            // 
            this.lblOver5Percent.AutoSize = true;
            this.lblOver5Percent.Location = new System.Drawing.Point(12, 125);
            this.lblOver5Percent.Name = "lblOver5Percent";
            this.lblOver5Percent.Size = new System.Drawing.Size(69, 20);
            this.lblOver5Percent.TabIndex = 6;
            this.lblOver5Percent.Text = "Over 5%";
            // 
            // lblWithin5Percent
            // 
            this.lblWithin5Percent.AutoSize = true;
            this.lblWithin5Percent.Location = new System.Drawing.Point(12, 93);
            this.lblWithin5Percent.Name = "lblWithin5Percent";
            this.lblWithin5Percent.Size = new System.Drawing.Size(80, 20);
            this.lblWithin5Percent.TabIndex = 5;
            this.lblWithin5Percent.Text = "Within 5%";
            // 
            // txtOver5Percent
            // 
            this.txtOver5Percent.BackColor = System.Drawing.Color.Red;
            this.txtOver5Percent.Location = new System.Drawing.Point(107, 122);
            this.txtOver5Percent.Name = "txtOver5Percent";
            this.txtOver5Percent.Size = new System.Drawing.Size(162, 26);
            this.txtOver5Percent.TabIndex = 4;
            // 
            // txtWithin5Percent
            // 
            this.txtWithin5Percent.BackColor = System.Drawing.Color.Orange;
            this.txtWithin5Percent.Location = new System.Drawing.Point(107, 90);
            this.txtWithin5Percent.Name = "txtWithin5Percent";
            this.txtWithin5Percent.Size = new System.Drawing.Size(162, 26);
            this.txtWithin5Percent.TabIndex = 3;
            // 
            // txtSelected
            // 
            this.txtSelected.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtSelected.Location = new System.Drawing.Point(107, 26);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.Size = new System.Drawing.Size(162, 26);
            this.txtSelected.TabIndex = 2;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(12, 29);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(72, 20);
            this.lblSelected.TabIndex = 0;
            this.lblSelected.Text = "Selected";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(164, 573);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 37);
            this.button2.TabIndex = 5;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(936, 496);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 71);
            this.button3.TabIndex = 6;
            this.button3.Text = "V";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lvwUpperCategory
            // 
            this.lvwUpperCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwUpperCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.lvwUpperCategory.Enabled = false;
            this.lvwUpperCategory.FullRowSelect = true;
            this.lvwUpperCategory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwUpperCategory.Location = new System.Drawing.Point(302, 27);
            this.lvwUpperCategory.Name = "lvwUpperCategory";
            this.lvwUpperCategory.Size = new System.Drawing.Size(613, 522);
            this.lvwUpperCategory.SmallImageList = this.imlColours;
            this.lvwUpperCategory.TabIndex = 8;
            this.lvwUpperCategory.UseCompatibleStateImageBehavior = false;
            this.lvwUpperCategory.View = System.Windows.Forms.View.Details;
            this.lvwUpperCategory.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwUpperCategory_ItemSelectionChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 532;
            // 
            // pnlCategories
            // 
            this.pnlCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCategories.AutoScroll = true;
            this.pnlCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCategories.Controls.Add(this.lblOtherAgeAndWeightCategories);
            this.pnlCategories.Controls.Add(this.lblSelectedCategory);
            this.pnlCategories.Controls.Add(this.lvwUpperCategory);
            this.pnlCategories.Controls.Add(this.lvwCategories);
            this.pnlCategories.Location = new System.Drawing.Point(8, 13);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Size = new System.Drawing.Size(922, 554);
            this.pnlCategories.TabIndex = 9;
            // 
            // lblOtherAgeAndWeightCategories
            // 
            this.lblOtherAgeAndWeightCategories.AutoSize = true;
            this.lblOtherAgeAndWeightCategories.Location = new System.Drawing.Point(298, 4);
            this.lblOtherAgeAndWeightCategories.Name = "lblOtherAgeAndWeightCategories";
            this.lblOtherAgeAndWeightCategories.Size = new System.Drawing.Size(248, 20);
            this.lblOtherAgeAndWeightCategories.TabIndex = 10;
            this.lblOtherAgeAndWeightCategories.Text = "Other Age and Weight Categories";
            // 
            // lblSelectedCategory
            // 
            this.lblSelectedCategory.AutoSize = true;
            this.lblSelectedCategory.Location = new System.Drawing.Point(4, 4);
            this.lblSelectedCategory.Name = "lblSelectedCategory";
            this.lblSelectedCategory.Size = new System.Drawing.Size(140, 20);
            this.lblSelectedCategory.TabIndex = 9;
            this.lblSelectedCategory.Text = "Selected Category";
            // 
            // frmWeightCategoryPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 622);
            this.Controls.Add(this.pnlCategories);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.grpKey);
            this.Controls.Add(this.grpSelected);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmWeightCategoryPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weight Category Picker";
            this.Load += new System.EventHandler(this.frmWeightCategoryPicker_Load);
            this.grpSelected.ResumeLayout(false);
            this.grpSelected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBelt)).EndInit();
            this.grpKey.ResumeLayout(false);
            this.grpKey.PerformLayout();
            this.pnlCategories.ResumeLayout(false);
            this.pnlCategories.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwCategories;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpSelected;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.ImageList imlBelts;
        private System.Windows.Forms.PictureBox picBelt;
        private System.Windows.Forms.GroupBox grpKey;
        private System.Windows.Forms.Label lblOver5Percent;
        private System.Windows.Forms.Label lblWithin5Percent;
        private System.Windows.Forms.TextBox txtOver5Percent;
        private System.Windows.Forms.TextBox txtWithin5Percent;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblEqual;
        private System.Windows.Forms.TextBox txtEqual;
        private System.Windows.Forms.ImageList imlColours;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView lvwUpperCategory;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel pnlCategories;
        private System.Windows.Forms.Label lblOtherAgeAndWeightCategories;
        private System.Windows.Forms.Label lblSelectedCategory;
    }
}