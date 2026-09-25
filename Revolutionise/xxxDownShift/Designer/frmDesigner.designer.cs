

using Utilities;

namespace Designer
{
    partial class frmDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesigner));
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnExport = new System.Windows.Forms.Button();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tslblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabExportType = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnEditMapping = new System.Windows.Forms.Button();
            this.btnDeleteMapping = new System.Windows.Forms.Button();
            this.lvwMappingResults = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnResetMappings = new System.Windows.Forms.Button();
            this.lblMappingTypeHint = new System.Windows.Forms.Label();
            this.btnAutoSet = new System.Windows.Forms.Button();
            this.btnManualSet = new System.Windows.Forms.Button();
            this.cmbEuroJudoMappingType = new System.Windows.Forms.ComboBox();
            this.btnNextMappingType = new System.Windows.Forms.Button();
            this.lstEuroJudoComparisonValue = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tscTournament = new System.Windows.Forms.ComboBox();
            this.cmbColumnNamesFromImportData = new System.Windows.Forms.ComboBox();
            this.btnPreviousMappingType = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lstImportedColumnValues = new System.Windows.Forms.ListBox();
            this.lblEuroJudoTournament = new System.Windows.Forms.Label();
            this.pbrAuto = new System.Windows.Forms.ProgressBar();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMinComparison = new System.Windows.Forms.Label();
            this.lblMinComparisonValue = new System.Windows.Forms.Label();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsbLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.tabExportType.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(697, 470);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // ssMain
            // 
            this.ssMain.Location = new System.Drawing.Point(0, 520);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(784, 22);
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "Main";
            // 
            // tslblMain
            // 
            this.tslblMain.Name = "tslblMain";
            this.tslblMain.Size = new System.Drawing.Size(26, 17);
            this.tslblMain.Text = "Idle";
            // 
            // tabExportType
            // 
            this.tabExportType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabExportType.Controls.Add(this.tabPage3);
            this.tabExportType.Controls.Add(this.tabPage4);
            this.tabExportType.Enabled = false;
            this.tabExportType.Location = new System.Drawing.Point(12, 52);
            this.tabExportType.Name = "tabExportType";
            this.tabExportType.SelectedIndex = 0;
            this.tabExportType.Size = new System.Drawing.Size(760, 412);
            this.tabExportType.TabIndex = 0;
            this.tabExportType.SelectedIndexChanged += new System.EventHandler(this.TabExportType_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(752, 411);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "IJF";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lblMinComparisonValue);
            this.tabPage4.Controls.Add(this.lblMinComparison);
            this.tabPage4.Controls.Add(this.btnEditMapping);
            this.tabPage4.Controls.Add(this.btnDeleteMapping);
            this.tabPage4.Controls.Add(this.lvwMappingResults);
            this.tabPage4.Controls.Add(this.btnResetMappings);
            this.tabPage4.Controls.Add(this.lblMappingTypeHint);
            this.tabPage4.Controls.Add(this.btnAutoSet);
            this.tabPage4.Controls.Add(this.btnManualSet);
            this.tabPage4.Controls.Add(this.cmbEuroJudoMappingType);
            this.tabPage4.Controls.Add(this.btnNextMappingType);
            this.tabPage4.Controls.Add(this.lstEuroJudoComparisonValue);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.tscTournament);
            this.tabPage4.Controls.Add(this.cmbColumnNamesFromImportData);
            this.tabPage4.Controls.Add(this.btnPreviousMappingType);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.lstImportedColumnValues);
            this.tabPage4.Controls.Add(this.lblEuroJudoTournament);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(752, 386);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Euro Judo";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnEditMapping
            // 
            this.btnEditMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditMapping.Enabled = false;
            this.btnEditMapping.Location = new System.Drawing.Point(671, 327);
            this.btnEditMapping.Name = "btnEditMapping";
            this.btnEditMapping.Size = new System.Drawing.Size(75, 23);
            this.btnEditMapping.TabIndex = 26;
            this.btnEditMapping.Text = "Edit";
            this.btnEditMapping.UseVisualStyleBackColor = true;
            this.btnEditMapping.Visible = false;
            // 
            // btnDeleteMapping
            // 
            this.btnDeleteMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMapping.Enabled = false;
            this.btnDeleteMapping.Location = new System.Drawing.Point(671, 298);
            this.btnDeleteMapping.Name = "btnDeleteMapping";
            this.btnDeleteMapping.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMapping.TabIndex = 27;
            this.btnDeleteMapping.Text = "Delete";
            this.btnDeleteMapping.UseVisualStyleBackColor = true;
            this.btnDeleteMapping.Visible = false;
            this.btnDeleteMapping.Click += new System.EventHandler(this.BtnDeleteMapping_Click);
            // 
            // lvwMappingResults
            // 
            this.lvwMappingResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMappingResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12});
            this.lvwMappingResults.FullRowSelect = true;
            this.lvwMappingResults.HideSelection = false;
            this.lvwMappingResults.Location = new System.Drawing.Point(9, 267);
            this.lvwMappingResults.MultiSelect = false;
            this.lvwMappingResults.Name = "lvwMappingResults";
            this.lvwMappingResults.Size = new System.Drawing.Size(656, 112);
            this.lvwMappingResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwMappingResults.TabIndex = 22;
            this.lvwMappingResults.UseCompatibleStateImageBehavior = false;
            this.lvwMappingResults.View = System.Windows.Forms.View.Details;
            this.lvwMappingResults.SelectedIndexChanged += new System.EventHandler(this.LvwMappingResults_SelectedIndexChanged);
            this.lvwMappingResults.DoubleClick += new System.EventHandler(this.lvwMappingResults_DoubleClick);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Source Value";
            this.columnHeader11.Width = 327;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Destination Value";
            this.columnHeader12.Width = 305;
            // 
            // btnResetMappings
            // 
            this.btnResetMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetMappings.Enabled = false;
            this.btnResetMappings.Location = new System.Drawing.Point(671, 356);
            this.btnResetMappings.Name = "btnResetMappings";
            this.btnResetMappings.Size = new System.Drawing.Size(75, 23);
            this.btnResetMappings.TabIndex = 25;
            this.btnResetMappings.Text = "Reset";
            this.btnResetMappings.UseVisualStyleBackColor = true;
            this.btnResetMappings.Click += new System.EventHandler(this.btnResetMappings_Click);
            // 
            // lblMappingTypeHint
            // 
            this.lblMappingTypeHint.AutoSize = true;
            this.lblMappingTypeHint.Location = new System.Drawing.Point(8, 38);
            this.lblMappingTypeHint.Name = "lblMappingTypeHint";
            this.lblMappingTypeHint.Size = new System.Drawing.Size(58, 13);
            this.lblMappingTypeHint.TabIndex = 31;
            this.lblMappingTypeHint.Text = "Step 0 of x";
            // 
            // btnAutoSet
            // 
            this.btnAutoSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoSet.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAutoSet.Location = new System.Drawing.Point(342, 62);
            this.btnAutoSet.Name = "btnAutoSet";
            this.btnAutoSet.Size = new System.Drawing.Size(75, 23);
            this.btnAutoSet.TabIndex = 23;
            this.btnAutoSet.Text = "Auto";
            this.btnAutoSet.UseVisualStyleBackColor = false;
            this.btnAutoSet.Click += new System.EventHandler(this.btnAutoSet_Click);
            // 
            // btnManualSet
            // 
            this.btnManualSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualSet.BackColor = System.Drawing.Color.GreenYellow;
            this.btnManualSet.Enabled = false;
            this.btnManualSet.Location = new System.Drawing.Point(673, 111);
            this.btnManualSet.Name = "btnManualSet";
            this.btnManualSet.Size = new System.Drawing.Size(75, 23);
            this.btnManualSet.TabIndex = 24;
            this.btnManualSet.Text = "Set";
            this.btnManualSet.UseVisualStyleBackColor = false;
            this.btnManualSet.Click += new System.EventHandler(this.btnManualSet_Click);
            // 
            // cmbEuroJudoMappingType
            // 
            this.cmbEuroJudoMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEuroJudoMappingType.FormattingEnabled = true;
            this.cmbEuroJudoMappingType.Location = new System.Drawing.Point(118, 34);
            this.cmbEuroJudoMappingType.Name = "cmbEuroJudoMappingType";
            this.cmbEuroJudoMappingType.Size = new System.Drawing.Size(187, 21);
            this.cmbEuroJudoMappingType.TabIndex = 30;
            this.cmbEuroJudoMappingType.SelectedIndexChanged += new System.EventHandler(this.cmbEuroJudoMappingType_SelectedIndexChanged);
            // 
            // btnNextMappingType
            // 
            this.btnNextMappingType.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNextMappingType.Location = new System.Drawing.Point(311, 34);
            this.btnNextMappingType.Name = "btnNextMappingType";
            this.btnNextMappingType.Size = new System.Drawing.Size(25, 21);
            this.btnNextMappingType.TabIndex = 29;
            this.btnNextMappingType.Text = ">";
            this.btnNextMappingType.UseVisualStyleBackColor = false;
            this.btnNextMappingType.Click += new System.EventHandler(this.btnNextMappingType_Click);
            // 
            // lstEuroJudoComparisonValue
            // 
            this.lstEuroJudoComparisonValue.FormattingEnabled = true;
            this.lstEuroJudoComparisonValue.Location = new System.Drawing.Point(342, 111);
            this.lstEuroJudoComparisonValue.Name = "lstEuroJudoComparisonValue";
            this.lstEuroJudoComparisonValue.Size = new System.Drawing.Size(325, 147);
            this.lstEuroJudoComparisonValue.Sorted = true;
            this.lstEuroJudoComparisonValue.TabIndex = 19;
            this.lstEuroJudoComparisonValue.SelectedIndexChanged += new System.EventHandler(this.lstEuroJudoComparisonValue_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(339, 95);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "Database Values";
            // 
            // tscTournament
            // 
            this.tscTournament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscTournament.FormattingEnabled = true;
            this.tscTournament.Location = new System.Drawing.Point(87, 6);
            this.tscTournament.Name = "tscTournament";
            this.tscTournament.Size = new System.Drawing.Size(249, 21);
            this.tscTournament.TabIndex = 9;
            this.tscTournament.SelectedIndexChanged += new System.EventHandler(this.tscTournament_SelectedIndexChanged);
            // 
            // cmbColumnNamesFromImportData
            // 
            this.cmbColumnNamesFromImportData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumnNamesFromImportData.FormattingEnabled = true;
            this.cmbColumnNamesFromImportData.Location = new System.Drawing.Point(87, 63);
            this.cmbColumnNamesFromImportData.Name = "cmbColumnNamesFromImportData";
            this.cmbColumnNamesFromImportData.Size = new System.Drawing.Size(249, 21);
            this.cmbColumnNamesFromImportData.TabIndex = 16;
            this.cmbColumnNamesFromImportData.SelectedIndexChanged += new System.EventHandler(this.cmbColumnNamesFromImportData_SelectedIndexChanged);
            // 
            // btnPreviousMappingType
            // 
            this.btnPreviousMappingType.BackColor = System.Drawing.Color.GreenYellow;
            this.btnPreviousMappingType.Enabled = false;
            this.btnPreviousMappingType.Location = new System.Drawing.Point(87, 34);
            this.btnPreviousMappingType.Name = "btnPreviousMappingType";
            this.btnPreviousMappingType.Size = new System.Drawing.Size(25, 21);
            this.btnPreviousMappingType.TabIndex = 28;
            this.btnPreviousMappingType.Text = "<";
            this.btnPreviousMappingType.UseVisualStyleBackColor = false;
            this.btnPreviousMappingType.Click += new System.EventHandler(this.btnPreviousMappingType_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 13);
            this.label22.TabIndex = 15;
            this.label22.Text = "Column";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 95);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Import file Values";
            // 
            // lstImportedColumnValues
            // 
            this.lstImportedColumnValues.FormattingEnabled = true;
            this.lstImportedColumnValues.Location = new System.Drawing.Point(11, 111);
            this.lstImportedColumnValues.Name = "lstImportedColumnValues";
            this.lstImportedColumnValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstImportedColumnValues.Size = new System.Drawing.Size(325, 147);
            this.lstImportedColumnValues.Sorted = true;
            this.lstImportedColumnValues.TabIndex = 20;
            this.lstImportedColumnValues.SelectedIndexChanged += new System.EventHandler(this.lstImportedColumnValues_SelectedIndexChanged);
            // 
            // lblEuroJudoTournament
            // 
            this.lblEuroJudoTournament.AutoSize = true;
            this.lblEuroJudoTournament.Location = new System.Drawing.Point(6, 9);
            this.lblEuroJudoTournament.Name = "lblEuroJudoTournament";
            this.lblEuroJudoTournament.Size = new System.Drawing.Size(64, 13);
            this.lblEuroJudoTournament.TabIndex = 10;
            this.lblEuroJudoTournament.Text = "Tournament";
            // 
            // pbrAuto
            // 
            this.pbrAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrAuto.Location = new System.Drawing.Point(13, 499);
            this.pbrAuto.Name = "pbrAuto";
            this.pbrAuto.Size = new System.Drawing.Size(759, 18);
            this.pbrAuto.TabIndex = 2;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(784, 24);
            this.mnuMain.TabIndex = 3;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Enabled = false;
            this.loadToolStripMenuItem.Image = global::Designer.Properties.Resources.realvista_general_folder_32;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.ToolTipText = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Designer.Properties.Resources.realvista_development_exit_32;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::Designer.Properties.Resources.realvista_development_configuration_32;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.ToolTipText = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // lblMinComparison
            // 
            this.lblMinComparison.AutoSize = true;
            this.lblMinComparison.Location = new System.Drawing.Point(424, 66);
            this.lblMinComparison.Name = "lblMinComparison";
            this.lblMinComparison.Size = new System.Drawing.Size(118, 13);
            this.lblMinComparison.TabIndex = 32;
            this.lblMinComparison.Text = "Min. Comparison Value:";
            // 
            // lblMinComparisonValue
            // 
            this.lblMinComparisonValue.AutoSize = true;
            this.lblMinComparisonValue.Location = new System.Drawing.Point(549, 66);
            this.lblMinComparisonValue.Name = "lblMinComparisonValue";
            this.lblMinComparisonValue.Size = new System.Drawing.Size(24, 13);
            this.lblMinComparisonValue.TabIndex = 33;
            this.lblMinComparisonValue.Text = "0 %";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.toolStripSeparator1,
            this.tsbLoad,
            this.tsbOptions});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(784, 25);
            this.tsMain.TabIndex = 4;
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = global::Designer.Properties.Resources.realvista_development_exit_32;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(23, 22);
            this.tsbExit.Text = "toolStripButton1";
            this.tsbExit.ToolTipText = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.TsbExit_Click);
            // 
            // tsbLoad
            // 
            this.tsbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoad.Image = global::Designer.Properties.Resources.realvista_general_folder_32;
            this.tsbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(23, 22);
            this.tsbLoad.Text = "Load";
            this.tsbLoad.Click += new System.EventHandler(this.TsbLoad_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOptions.Image = global::Designer.Properties.Resources.realvista_development_configuration_32;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(23, 22);
            this.tsbOptions.Text = "Options";
            this.tsbOptions.Click += new System.EventHandler(this.TsbOptions_Click);
            // 
            // frmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 542);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tabExportType);
            this.Controls.Add(this.pbrAuto);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(800, 3000);
            this.Name = "frmDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FrmDesigner_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.tabExportType.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.TabControl tabExportType;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tslblMain;
        private System.Windows.Forms.ComboBox cmbEuroJudoMappingType;
        private System.Windows.Forms.Button btnNextMappingType;
        private System.Windows.Forms.Button btnPreviousMappingType;
        private System.Windows.Forms.ListView lvwMappingResults;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button btnEditMapping;
        private System.Windows.Forms.Button btnDeleteMapping;
        private System.Windows.Forms.Button btnResetMappings;
        private System.Windows.Forms.Button btnAutoSet;
        private System.Windows.Forms.Button btnManualSet;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListBox lstImportedColumnValues;
        private System.Windows.Forms.ListBox lstEuroJudoComparisonValue;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbColumnNamesFromImportData;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ProgressBar pbrAuto;
        private System.Windows.Forms.Label lblMappingTypeHint;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label lblEuroJudoTournament;
        private System.Windows.Forms.ComboBox tscTournament;
        private System.Windows.Forms.Label lblMinComparisonValue;
        private System.Windows.Forms.Label lblMinComparison;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.ToolStripButton tsbOptions;
    }
}

