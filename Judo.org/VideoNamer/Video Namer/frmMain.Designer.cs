namespace Video_Namer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblEventType = new System.Windows.Forms.Label();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblNewfilename = new System.Windows.Forms.Label();
            this.txtNewFilename = new System.Windows.Forms.TextBox();
            this.cmbCompetitors = new System.Windows.Forms.ComboBox();
            this.lblCompetitors = new System.Windows.Forms.Label();
            this.btnRenameOrCopy = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fbdMedia = new System.Windows.Forms.FolderBrowserDialog();
            this.radMale = new System.Windows.Forms.RadioButton();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.cmbWeightCategory = new System.Windows.Forms.ComboBox();
            this.lblWeightCat = new System.Windows.Forms.Label();
            this.lblContestNumber = new System.Windows.Forms.Label();
            this.txtContestNumber = new System.Windows.Forms.TextBox();
            this.lblFilenameCollision = new System.Windows.Forms.Label();
            this.chkDeleteOriginal = new System.Windows.Forms.CheckBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.grpGender = new System.Windows.Forms.GroupBox();
            this.chkPartial = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwFiles
            // 
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFiles.FullRowSelect = true;
            this.lvwFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwFiles.HideSelection = false;
            this.lvwFiles.Location = new System.Drawing.Point(0, 0);
            this.lvwFiles.MultiSelect = false;
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(252, 263);
            this.lvwFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwFiles.TabIndex = 0;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.SelectedIndexChanged += new System.EventHandler(this.lvwFiles_SelectedIndexChanged);
            this.lvwFiles.Resize += new System.EventHandler(this.lvwFiles_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 362;
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(9, 92);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(28, 13);
            this.lblFiles.TabIndex = 21;
            this.lblFiles.Text = "Files";
            // 
            // lblEventType
            // 
            this.lblEventType.AutoSize = true;
            this.lblEventType.Location = new System.Drawing.Point(12, 13);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(58, 13);
            this.lblEventType.TabIndex = 0;
            this.lblEventType.Text = "Event type";
            // 
            // cmbEventType
            // 
            this.cmbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Items.AddRange(new object[] {
            "Cont Cup"});
            this.cmbEventType.Location = new System.Drawing.Point(12, 29);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(114, 21);
            this.cmbEventType.TabIndex = 4;
            this.cmbEventType.SelectedIndexChanged += new System.EventHandler(this.cmbEventType_SelectedIndexChanged);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(252, 13);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 2;
            this.lblCountry.Text = "Country";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Items.AddRange(new object[] {
            "Aus"});
            this.cmbCountry.Location = new System.Drawing.Point(255, 29);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(139, 21);
            this.cmbCountry.TabIndex = 5;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged);
            // 
            // lblNewfilename
            // 
            this.lblNewfilename.AutoSize = true;
            this.lblNewfilename.Location = new System.Drawing.Point(258, 53);
            this.lblNewfilename.Name = "lblNewfilename";
            this.lblNewfilename.Size = new System.Drawing.Size(71, 13);
            this.lblNewfilename.TabIndex = 14;
            this.lblNewfilename.Text = "New filename";
            // 
            // txtNewFilename
            // 
            this.txtNewFilename.Location = new System.Drawing.Point(258, 69);
            this.txtNewFilename.Name = "txtNewFilename";
            this.txtNewFilename.Size = new System.Drawing.Size(332, 20);
            this.txtNewFilename.TabIndex = 17;
            this.txtNewFilename.TextChanged += new System.EventHandler(this.txtNewFilename_TextChanged);
            // 
            // cmbCompetitors
            // 
            this.cmbCompetitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompetitors.FormattingEnabled = true;
            this.cmbCompetitors.Location = new System.Drawing.Point(135, 29);
            this.cmbCompetitors.Name = "cmbCompetitors";
            this.cmbCompetitors.Size = new System.Drawing.Size(114, 21);
            this.cmbCompetitors.TabIndex = 9;
            this.cmbCompetitors.SelectedIndexChanged += new System.EventHandler(this.cmbCompetitors_SelectedIndexChanged);
            // 
            // lblCompetitors
            // 
            this.lblCompetitors.AutoSize = true;
            this.lblCompetitors.Location = new System.Drawing.Point(132, 13);
            this.lblCompetitors.Name = "lblCompetitors";
            this.lblCompetitors.Size = new System.Drawing.Size(62, 13);
            this.lblCompetitors.TabIndex = 1;
            this.lblCompetitors.Text = "Competitors";
            // 
            // btnRenameOrCopy
            // 
            this.btnRenameOrCopy.BackColor = System.Drawing.Color.GreenYellow;
            this.btnRenameOrCopy.Location = new System.Drawing.Point(596, 67);
            this.btnRenameOrCopy.Name = "btnRenameOrCopy";
            this.btnRenameOrCopy.Size = new System.Drawing.Size(75, 23);
            this.btnRenameOrCopy.TabIndex = 18;
            this.btnRenameOrCopy.Text = "Copy";
            this.btnRenameOrCopy.UseVisualStyleBackColor = false;
            this.btnRenameOrCopy.Click += new System.EventHandler(this.btnRenameOrCopy_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(217, 67);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(35, 23);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // fbdMedia
            // 
            this.fbdMedia.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdMedia.ShowNewFolderButton = false;
            // 
            // radMale
            // 
            this.radMale.AutoSize = true;
            this.radMale.Checked = true;
            this.radMale.Location = new System.Drawing.Point(6, 19);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(48, 17);
            this.radMale.TabIndex = 0;
            this.radMale.TabStop = true;
            this.radMale.Text = "Male";
            this.radMale.UseVisualStyleBackColor = true;
            this.radMale.CheckedChanged += new System.EventHandler(this.radMale_CheckedChanged);
            // 
            // radFemale
            // 
            this.radFemale.AutoSize = true;
            this.radFemale.Location = new System.Drawing.Point(60, 19);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(59, 17);
            this.radFemale.TabIndex = 1;
            this.radFemale.Text = "Female";
            this.radFemale.UseVisualStyleBackColor = true;
            this.radFemale.CheckedChanged += new System.EventHandler(this.radFemale_CheckedChanged);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(12, 69);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(199, 20);
            this.txtFolder.TabIndex = 15;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(12, 53);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(65, 13);
            this.lblFolder.TabIndex = 13;
            this.lblFolder.Text = "Folder name";
            // 
            // Player
            // 
            this.Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(0, 0);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(652, 263);
            this.Player.TabIndex = 0;
            this.Player.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.Player_ClickEvent);
            this.Player.DoubleClickEvent += new AxWMPLib._WMPOCXEvents_DoubleClickEventHandler(this.Player_DoubleClickEvent);
            this.Player.KeyDownEvent += new AxWMPLib._WMPOCXEvents_KeyDownEventHandler(this.Player_KeyDownEvent);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(397, 13);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(400, 29);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(61, 20);
            this.txtYear.TabIndex = 10;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // cmbWeightCategory
            // 
            this.cmbWeightCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeightCategory.FormattingEnabled = true;
            this.cmbWeightCategory.Items.AddRange(new object[] {
            "Cad",
            "Jun",
            "Sen"});
            this.cmbWeightCategory.Location = new System.Drawing.Point(596, 29);
            this.cmbWeightCategory.Name = "cmbWeightCategory";
            this.cmbWeightCategory.Size = new System.Drawing.Size(114, 21);
            this.cmbWeightCategory.TabIndex = 11;
            this.cmbWeightCategory.SelectedIndexChanged += new System.EventHandler(this.cmbWeightCategory_SelectedIndexChanged);
            // 
            // lblWeightCat
            // 
            this.lblWeightCat.AutoSize = true;
            this.lblWeightCat.Location = new System.Drawing.Point(596, 13);
            this.lblWeightCat.Name = "lblWeightCat";
            this.lblWeightCat.Size = new System.Drawing.Size(86, 13);
            this.lblWeightCat.TabIndex = 7;
            this.lblWeightCat.Text = "Weight Category";
            // 
            // lblContestNumber
            // 
            this.lblContestNumber.AutoSize = true;
            this.lblContestNumber.Location = new System.Drawing.Point(716, 14);
            this.lblContestNumber.Name = "lblContestNumber";
            this.lblContestNumber.Size = new System.Drawing.Size(43, 13);
            this.lblContestNumber.TabIndex = 8;
            this.lblContestNumber.Text = "Contest";
            // 
            // txtContestNumber
            // 
            this.txtContestNumber.Location = new System.Drawing.Point(716, 29);
            this.txtContestNumber.Name = "txtContestNumber";
            this.txtContestNumber.Size = new System.Drawing.Size(61, 20);
            this.txtContestNumber.TabIndex = 12;
            this.txtContestNumber.TextChanged += new System.EventHandler(this.txtContestNumber_TextChanged);
            // 
            // lblFilenameCollision
            // 
            this.lblFilenameCollision.AutoSize = true;
            this.lblFilenameCollision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilenameCollision.ForeColor = System.Drawing.Color.Red;
            this.lblFilenameCollision.Location = new System.Drawing.Point(776, 72);
            this.lblFilenameCollision.Name = "lblFilenameCollision";
            this.lblFilenameCollision.Size = new System.Drawing.Size(107, 13);
            this.lblFilenameCollision.TabIndex = 20;
            this.lblFilenameCollision.Text = "Filename collision";
            this.lblFilenameCollision.Visible = false;
            // 
            // chkDeleteOriginal
            // 
            this.chkDeleteOriginal.AutoSize = true;
            this.chkDeleteOriginal.Location = new System.Drawing.Point(677, 71);
            this.chkDeleteOriginal.Name = "chkDeleteOriginal";
            this.chkDeleteOriginal.Size = new System.Drawing.Size(93, 17);
            this.chkDeleteOriginal.TabIndex = 19;
            this.chkDeleteOriginal.Text = "Delete original";
            this.chkDeleteOriginal.UseVisualStyleBackColor = true;
            this.chkDeleteOriginal.CheckedChanged += new System.EventHandler(this.chkDeleteOriginal_CheckedChanged);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(9, 108);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvwFiles);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.Player);
            this.splitContainer.Size = new System.Drawing.Size(908, 263);
            this.splitContainer.SplitterDistance = 252;
            this.splitContainer.TabIndex = 22;
            // 
            // grpGender
            // 
            this.grpGender.Controls.Add(this.radMale);
            this.grpGender.Controls.Add(this.radFemale);
            this.grpGender.Location = new System.Drawing.Point(467, 13);
            this.grpGender.Name = "grpGender";
            this.grpGender.Size = new System.Drawing.Size(123, 48);
            this.grpGender.TabIndex = 6;
            this.grpGender.TabStop = false;
            this.grpGender.Text = "Gender";
            // 
            // chkPartial
            // 
            this.chkPartial.AutoSize = true;
            this.chkPartial.Location = new System.Drawing.Point(783, 31);
            this.chkPartial.Name = "chkPartial";
            this.chkPartial.Size = new System.Drawing.Size(55, 17);
            this.chkPartial.TabIndex = 23;
            this.chkPartial.Text = "Partial";
            this.chkPartial.UseVisualStyleBackColor = true;
            this.chkPartial.CheckedChanged += new System.EventHandler(this.chkPartial_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 383);
            this.Controls.Add(this.chkPartial);
            this.Controls.Add(this.grpGender);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.chkDeleteOriginal);
            this.Controls.Add(this.lblFilenameCollision);
            this.Controls.Add(this.txtContestNumber);
            this.Controls.Add(this.lblContestNumber);
            this.Controls.Add(this.cmbWeightCategory);
            this.Controls.Add(this.lblWeightCat);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnRenameOrCopy);
            this.Controls.Add(this.cmbCompetitors);
            this.Controls.Add(this.lblCompetitors);
            this.Controls.Add(this.txtNewFilename);
            this.Controls.Add(this.lblNewfilename);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.cmbEventType);
            this.Controls.Add(this.lblEventType);
            this.Controls.Add(this.lblFiles);
            this.Name = "frmMain";
            this.Text = "Video Namer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.grpGender.ResumeLayout(false);
            this.grpGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblEventType;
        private System.Windows.Forms.ComboBox cmbEventType;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label lblNewfilename;
        private System.Windows.Forms.TextBox txtNewFilename;
        private System.Windows.Forms.ComboBox cmbCompetitors;
        private System.Windows.Forms.Label lblCompetitors;
        private System.Windows.Forms.Button btnRenameOrCopy;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdMedia;
        private System.Windows.Forms.RadioButton radMale;
        private System.Windows.Forms.RadioButton radFemale;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lblFolder;
        private AxWMPLib.AxWindowsMediaPlayer Player;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox cmbWeightCategory;
        private System.Windows.Forms.Label lblWeightCat;
        private System.Windows.Forms.Label lblContestNumber;
        private System.Windows.Forms.TextBox txtContestNumber;
        private System.Windows.Forms.Label lblFilenameCollision;
        private System.Windows.Forms.CheckBox chkDeleteOriginal;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox grpGender;
        private System.Windows.Forms.CheckBox chkPartial;
    }
}

