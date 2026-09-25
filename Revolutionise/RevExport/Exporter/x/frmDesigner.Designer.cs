

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImportBrowse = new System.Windows.Forms.Button();
            this.lblImport = new System.Windows.Forms.Label();
            this.txtImportFilename = new System.Windows.Forms.TextBox();
            this.txtIJFExportFilename = new System.Windows.Forms.TextBox();
            this.btnIJFExportBrowse = new System.Windows.Forms.Button();
            this.lblIJFExportFilename = new System.Windows.Forms.Label();
            this.lblEuroJudoFile = new System.Windows.Forms.Label();
            this.txtEuroJudoExportFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoSaveFileBrowse = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnLoadRevolutioniseData = new System.Windows.Forms.Button();
            this.chkImportHasHeaders = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblInputDelimiter = new System.Windows.Forms.Label();
            this.cmbSplitCharacters = new System.Windows.Forms.ComboBox();
            this.chkRemoveTotalRow = new System.Windows.Forms.CheckBox();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tslblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SourceValueGrid = new Utilities.DataGridViewEx();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabExport = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabEuroJudoWizard = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEuroJudoSubDivisionFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoRegionsFileBrowse = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEuroJudoCountriesFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoCountriesFileBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEuroJudoClubsFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoClubsFileBrowse = new System.Windows.Forms.Button();
            this.btnReloadTournaments = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbEuroJudoTournament = new System.Windows.Forms.ComboBox();
            this.txtEuroJudoDatabaseFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoDatabaseBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.lblMappingTypeHint = new System.Windows.Forms.Label();
            this.cmbEuroJudoMappingType = new System.Windows.Forms.ComboBox();
            this.btnNextMappingType = new System.Windows.Forms.Button();
            this.btnPreviousMappingType = new System.Windows.Forms.Button();
            this.lvwMappingResults = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEditMapping = new System.Windows.Forms.Button();
            this.btnDeleteMapping = new System.Windows.Forms.Button();
            this.btnResetMappings = new System.Windows.Forms.Button();
            this.btnAutoSet = new System.Windows.Forms.Button();
            this.btnManualSet = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.lstImportedColumnValues = new System.Windows.Forms.ListBox();
            this.lstEuroJudoComparisonValue = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbImportedColumnNames = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pbrAuto = new System.Windows.Forms.ProgressBar();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscTournament = new System.Windows.Forms.ToolStripComboBox();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.ssMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourceValueGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabEuroJudoWizard.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportBrowse
            // 
            this.btnImportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportBrowse.Location = new System.Drawing.Point(720, 6);
            this.btnImportBrowse.Name = "btnImportBrowse";
            this.btnImportBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnImportBrowse.TabIndex = 2;
            this.btnImportBrowse.Text = "...";
            this.btnImportBrowse.UseVisualStyleBackColor = true;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(6, 11);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(87, 13);
            this.lblImport.TabIndex = 0;
            this.lblImport.Text = "Revolutionise file";
            // 
            // txtImportFilename
            // 
            this.txtImportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportFilename.Location = new System.Drawing.Point(99, 8);
            this.txtImportFilename.Name = "txtImportFilename";
            this.txtImportFilename.Size = new System.Drawing.Size(615, 20);
            this.txtImportFilename.TabIndex = 1;
            // 
            // txtIJFExportFilename
            // 
            this.txtIJFExportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIJFExportFilename.Location = new System.Drawing.Point(109, 8);
            this.txtIJFExportFilename.Name = "txtIJFExportFilename";
            this.txtIJFExportFilename.Size = new System.Drawing.Size(291, 20);
            this.txtIJFExportFilename.TabIndex = 1;
            // 
            // btnIJFExportBrowse
            // 
            this.btnIJFExportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIJFExportBrowse.Location = new System.Drawing.Point(406, 7);
            this.btnIJFExportBrowse.Name = "btnIJFExportBrowse";
            this.btnIJFExportBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnIJFExportBrowse.TabIndex = 2;
            this.btnIJFExportBrowse.Text = "...";
            this.btnIJFExportBrowse.UseVisualStyleBackColor = true;
            // 
            // lblIJFExportFilename
            // 
            this.lblIJFExportFilename.AutoSize = true;
            this.lblIJFExportFilename.Location = new System.Drawing.Point(6, 12);
            this.lblIJFExportFilename.Name = "lblIJFExportFilename";
            this.lblIJFExportFilename.Size = new System.Drawing.Size(63, 13);
            this.lblIJFExportFilename.TabIndex = 0;
            this.lblIJFExportFilename.Text = "IJF filename";
            // 
            // lblEuroJudoFile
            // 
            this.lblEuroJudoFile.AutoSize = true;
            this.lblEuroJudoFile.Location = new System.Drawing.Point(6, 39);
            this.lblEuroJudoFile.Name = "lblEuroJudoFile";
            this.lblEuroJudoFile.Size = new System.Drawing.Size(79, 13);
            this.lblEuroJudoFile.TabIndex = 3;
            this.lblEuroJudoFile.Text = "Export filename";
            // 
            // txtEuroJudoExportFilename
            // 
            this.txtEuroJudoExportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoExportFilename.Location = new System.Drawing.Point(122, 36);
            this.txtEuroJudoExportFilename.Name = "txtEuroJudoExportFilename";
            this.txtEuroJudoExportFilename.Size = new System.Drawing.Size(555, 20);
            this.txtEuroJudoExportFilename.TabIndex = 4;
            // 
            // btnEuroJudoSaveFileBrowse
            // 
            this.btnEuroJudoSaveFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoSaveFileBrowse.Location = new System.Drawing.Point(683, 35);
            this.btnEuroJudoSaveFileBrowse.Name = "btnEuroJudoSaveFileBrowse";
            this.btnEuroJudoSaveFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoSaveFileBrowse.TabIndex = 5;
            this.btnEuroJudoSaveFileBrowse.Text = "...";
            this.btnEuroJudoSaveFileBrowse.UseVisualStyleBackColor = true;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // btnLoadRevolutioniseData
            // 
            this.btnLoadRevolutioniseData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadRevolutioniseData.BackColor = System.Drawing.Color.GreenYellow;
            this.btnLoadRevolutioniseData.Location = new System.Drawing.Point(670, 32);
            this.btnLoadRevolutioniseData.Name = "btnLoadRevolutioniseData";
            this.btnLoadRevolutioniseData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadRevolutioniseData.TabIndex = 7;
            this.btnLoadRevolutioniseData.Text = "Load";
            this.btnLoadRevolutioniseData.UseVisualStyleBackColor = false;
            this.btnLoadRevolutioniseData.Click += new System.EventHandler(this.btnLoadRevolutioniseData_Click);
            // 
            // chkImportHasHeaders
            // 
            this.chkImportHasHeaders.AutoSize = true;
            this.chkImportHasHeaders.Checked = true;
            this.chkImportHasHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImportHasHeaders.Location = new System.Drawing.Point(6, 36);
            this.chkImportHasHeaders.Name = "chkImportHasHeaders";
            this.chkImportHasHeaders.Size = new System.Drawing.Size(140, 17);
            this.chkImportHasHeaders.TabIndex = 3;
            this.chkImportHasHeaders.Text = "Include Column headers";
            this.chkImportHasHeaders.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(670, 434);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // lblInputDelimiter
            // 
            this.lblInputDelimiter.AutoSize = true;
            this.lblInputDelimiter.Location = new System.Drawing.Point(292, 37);
            this.lblInputDelimiter.Name = "lblInputDelimiter";
            this.lblInputDelimiter.Size = new System.Drawing.Size(74, 13);
            this.lblInputDelimiter.TabIndex = 5;
            this.lblInputDelimiter.Text = "Input Delimiter";
            // 
            // cmbSplitCharacters
            // 
            this.cmbSplitCharacters.FormattingEnabled = true;
            this.cmbSplitCharacters.Items.AddRange(new object[] {
            ",",
            ";",
            "/t"});
            this.cmbSplitCharacters.Location = new System.Drawing.Point(372, 34);
            this.cmbSplitCharacters.Name = "cmbSplitCharacters";
            this.cmbSplitCharacters.Size = new System.Drawing.Size(52, 21);
            this.cmbSplitCharacters.TabIndex = 6;
            // 
            // chkRemoveTotalRow
            // 
            this.chkRemoveTotalRow.AutoSize = true;
            this.chkRemoveTotalRow.Checked = true;
            this.chkRemoveTotalRow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveTotalRow.Location = new System.Drawing.Point(168, 36);
            this.chkRemoveTotalRow.Name = "chkRemoveTotalRow";
            this.chkRemoveTotalRow.Size = new System.Drawing.Size(118, 17);
            this.chkRemoveTotalRow.TabIndex = 4;
            this.chkRemoveTotalRow.Text = "Remove Total Row";
            this.chkRemoveTotalRow.UseVisualStyleBackColor = true;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblMain});
            this.ssMain.Location = new System.Drawing.Point(0, 539);
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
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Location = new System.Drawing.Point(13, 27);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(759, 489);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SourceValueGrid);
            this.tabPage1.Controls.Add(this.chkImportHasHeaders);
            this.tabPage1.Controls.Add(this.cmbSplitCharacters);
            this.tabPage1.Controls.Add(this.btnLoadRevolutioniseData);
            this.tabPage1.Controls.Add(this.chkRemoveTotalRow);
            this.tabPage1.Controls.Add(this.lblInputDelimiter);
            this.tabPage1.Controls.Add(this.lblImport);
            this.tabPage1.Controls.Add(this.txtImportFilename);
            this.tabPage1.Controls.Add(this.btnImportBrowse);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(751, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SourceValueGrid
            // 
            this.SourceValueGrid.AllowUserToAddRows = false;
            this.SourceValueGrid.AllowUserToDeleteRows = false;
            this.SourceValueGrid.AllowUserToOrderColumns = true;
            this.SourceValueGrid.AllowUserToResizeRows = false;
            this.SourceValueGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceValueGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SourceValueGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.SourceValueGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SourceValueGrid.Location = new System.Drawing.Point(8, 61);
            this.SourceValueGrid.MultiSelect = false;
            this.SourceValueGrid.Name = "SourceValueGrid";
            this.SourceValueGrid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SourceValueGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.SourceValueGrid.ShowEditingIcon = false;
            this.SourceValueGrid.Size = new System.Drawing.Size(737, 396);
            this.SourceValueGrid.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabExport);
            this.tabPage2.Controls.Add(this.btnExport);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(751, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabExport
            // 
            this.tabExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabExport.Controls.Add(this.tabPage3);
            this.tabExport.Controls.Add(this.tabPage4);
            this.tabExport.Location = new System.Drawing.Point(6, 6);
            this.tabExport.Name = "tabExport";
            this.tabExport.SelectedIndex = 0;
            this.tabExport.Size = new System.Drawing.Size(742, 422);
            this.tabExport.TabIndex = 0;
            this.tabExport.SelectedIndexChanged += new System.EventHandler(this.TabExport_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblIJFExportFilename);
            this.tabPage3.Controls.Add(this.txtIJFExportFilename);
            this.tabPage3.Controls.Add(this.btnIJFExportBrowse);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(734, 396);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "IJF";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabEuroJudoWizard);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(734, 396);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Euro Judo";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabEuroJudoWizard
            // 
            this.tabEuroJudoWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEuroJudoWizard.Controls.Add(this.tabPage5);
            this.tabEuroJudoWizard.Controls.Add(this.tabPage9);
            this.tabEuroJudoWizard.Location = new System.Drawing.Point(9, 6);
            this.tabEuroJudoWizard.Name = "tabEuroJudoWizard";
            this.tabEuroJudoWizard.SelectedIndex = 0;
            this.tabEuroJudoWizard.Size = new System.Drawing.Size(722, 384);
            this.tabEuroJudoWizard.TabIndex = 0;
            this.tabEuroJudoWizard.SelectedIndexChanged += new System.EventHandler(this.TabEuroJudoWizard_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.txtEuroJudoSubDivisionFilename);
            this.tabPage5.Controls.Add(this.btnEuroJudoRegionsFileBrowse);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.txtEuroJudoCountriesFilename);
            this.tabPage5.Controls.Add(this.btnEuroJudoCountriesFileBrowse);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.txtEuroJudoClubsFilename);
            this.tabPage5.Controls.Add(this.btnEuroJudoClubsFileBrowse);
            this.tabPage5.Controls.Add(this.btnReloadTournaments);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.cmbEuroJudoTournament);
            this.tabPage5.Controls.Add(this.txtEuroJudoDatabaseFilename);
            this.tabPage5.Controls.Add(this.btnEuroJudoDatabaseBrowse);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.lblEuroJudoFile);
            this.tabPage5.Controls.Add(this.txtEuroJudoExportFilename);
            this.tabPage5.Controls.Add(this.btnEuroJudoSaveFileBrowse);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(714, 358);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Setup";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 126);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Sub-Divisions filename";
            // 
            // txtEuroJudoSubDivisionFilename
            // 
            this.txtEuroJudoSubDivisionFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoSubDivisionFilename.Location = new System.Drawing.Point(122, 123);
            this.txtEuroJudoSubDivisionFilename.Name = "txtEuroJudoSubDivisionFilename";
            this.txtEuroJudoSubDivisionFilename.Size = new System.Drawing.Size(555, 20);
            this.txtEuroJudoSubDivisionFilename.TabIndex = 16;
            // 
            // btnEuroJudoRegionsFileBrowse
            // 
            this.btnEuroJudoRegionsFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoRegionsFileBrowse.Location = new System.Drawing.Point(683, 122);
            this.btnEuroJudoRegionsFileBrowse.Name = "btnEuroJudoRegionsFileBrowse";
            this.btnEuroJudoRegionsFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoRegionsFileBrowse.TabIndex = 17;
            this.btnEuroJudoRegionsFileBrowse.Text = "...";
            this.btnEuroJudoRegionsFileBrowse.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Countries filename";
            // 
            // txtEuroJudoCountriesFilename
            // 
            this.txtEuroJudoCountriesFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoCountriesFilename.Location = new System.Drawing.Point(122, 94);
            this.txtEuroJudoCountriesFilename.Name = "txtEuroJudoCountriesFilename";
            this.txtEuroJudoCountriesFilename.Size = new System.Drawing.Size(555, 20);
            this.txtEuroJudoCountriesFilename.TabIndex = 13;
            // 
            // btnEuroJudoCountriesFileBrowse
            // 
            this.btnEuroJudoCountriesFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoCountriesFileBrowse.Location = new System.Drawing.Point(683, 93);
            this.btnEuroJudoCountriesFileBrowse.Name = "btnEuroJudoCountriesFileBrowse";
            this.btnEuroJudoCountriesFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoCountriesFileBrowse.TabIndex = 14;
            this.btnEuroJudoCountriesFileBrowse.Text = "...";
            this.btnEuroJudoCountriesFileBrowse.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clubs filename";
            // 
            // txtEuroJudoClubsFilename
            // 
            this.txtEuroJudoClubsFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoClubsFilename.Location = new System.Drawing.Point(122, 65);
            this.txtEuroJudoClubsFilename.Name = "txtEuroJudoClubsFilename";
            this.txtEuroJudoClubsFilename.Size = new System.Drawing.Size(555, 20);
            this.txtEuroJudoClubsFilename.TabIndex = 7;
            // 
            // btnEuroJudoClubsFileBrowse
            // 
            this.btnEuroJudoClubsFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoClubsFileBrowse.Location = new System.Drawing.Point(683, 64);
            this.btnEuroJudoClubsFileBrowse.Name = "btnEuroJudoClubsFileBrowse";
            this.btnEuroJudoClubsFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoClubsFileBrowse.TabIndex = 8;
            this.btnEuroJudoClubsFileBrowse.Text = "...";
            this.btnEuroJudoClubsFileBrowse.UseVisualStyleBackColor = true;
            // 
            // btnReloadTournaments
            // 
            this.btnReloadTournaments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadTournaments.Location = new System.Drawing.Point(633, 151);
            this.btnReloadTournaments.Name = "btnReloadTournaments";
            this.btnReloadTournaments.Size = new System.Drawing.Size(75, 23);
            this.btnReloadTournaments.TabIndex = 11;
            this.btnReloadTournaments.Text = "Reload";
            this.btnReloadTournaments.UseVisualStyleBackColor = true;
            this.btnReloadTournaments.Visible = false;
            this.btnReloadTournaments.Click += new System.EventHandler(this.BtnReloadTournaments_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Tournament";
            // 
            // cmbEuroJudoTournament
            // 
            this.cmbEuroJudoTournament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEuroJudoTournament.FormattingEnabled = true;
            this.cmbEuroJudoTournament.Location = new System.Drawing.Point(122, 153);
            this.cmbEuroJudoTournament.Name = "cmbEuroJudoTournament";
            this.cmbEuroJudoTournament.Size = new System.Drawing.Size(290, 21);
            this.cmbEuroJudoTournament.TabIndex = 10;
            this.cmbEuroJudoTournament.SelectedIndexChanged += new System.EventHandler(this.CmbEuroJudoTournament_SelectedIndexChanged);
            // 
            // txtEuroJudoDatabaseFilename
            // 
            this.txtEuroJudoDatabaseFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoDatabaseFilename.Location = new System.Drawing.Point(122, 8);
            this.txtEuroJudoDatabaseFilename.Name = "txtEuroJudoDatabaseFilename";
            this.txtEuroJudoDatabaseFilename.Size = new System.Drawing.Size(555, 20);
            this.txtEuroJudoDatabaseFilename.TabIndex = 1;
            // 
            // btnEuroJudoDatabaseBrowse
            // 
            this.btnEuroJudoDatabaseBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoDatabaseBrowse.Location = new System.Drawing.Point(683, 6);
            this.btnEuroJudoDatabaseBrowse.Name = "btnEuroJudoDatabaseBrowse";
            this.btnEuroJudoDatabaseBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoDatabaseBrowse.TabIndex = 2;
            this.btnEuroJudoDatabaseBrowse.Text = "...";
            this.btnEuroJudoDatabaseBrowse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tournament Database";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.lblMappingTypeHint);
            this.tabPage9.Controls.Add(this.cmbEuroJudoMappingType);
            this.tabPage9.Controls.Add(this.btnNextMappingType);
            this.tabPage9.Controls.Add(this.btnPreviousMappingType);
            this.tabPage9.Controls.Add(this.lvwMappingResults);
            this.tabPage9.Controls.Add(this.btnEditMapping);
            this.tabPage9.Controls.Add(this.btnDeleteMapping);
            this.tabPage9.Controls.Add(this.btnResetMappings);
            this.tabPage9.Controls.Add(this.btnAutoSet);
            this.tabPage9.Controls.Add(this.btnManualSet);
            this.tabPage9.Controls.Add(this.label19);
            this.tabPage9.Controls.Add(this.lstImportedColumnValues);
            this.tabPage9.Controls.Add(this.lstEuroJudoComparisonValue);
            this.tabPage9.Controls.Add(this.label21);
            this.tabPage9.Controls.Add(this.cmbImportedColumnNames);
            this.tabPage9.Controls.Add(this.label22);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(714, 358);
            this.tabPage9.TabIndex = 4;
            this.tabPage9.Text = "Mapping";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // lblMappingTypeHint
            // 
            this.lblMappingTypeHint.AutoSize = true;
            this.lblMappingTypeHint.Location = new System.Drawing.Point(214, 11);
            this.lblMappingTypeHint.Name = "lblMappingTypeHint";
            this.lblMappingTypeHint.Size = new System.Drawing.Size(33, 13);
            this.lblMappingTypeHint.TabIndex = 31;
            this.lblMappingTypeHint.Text = "0 of x";
            // 
            // cmbEuroJudoMappingType
            // 
            this.cmbEuroJudoMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEuroJudoMappingType.FormattingEnabled = true;
            this.cmbEuroJudoMappingType.Location = new System.Drawing.Point(43, 7);
            this.cmbEuroJudoMappingType.Name = "cmbEuroJudoMappingType";
            this.cmbEuroJudoMappingType.Size = new System.Drawing.Size(134, 21);
            this.cmbEuroJudoMappingType.TabIndex = 30;
            this.cmbEuroJudoMappingType.SelectedIndexChanged += new System.EventHandler(this.cmbEuroJudoMappingType_SelectedIndexChanged);
            // 
            // btnNextMappingType
            // 
            this.btnNextMappingType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextMappingType.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNextMappingType.Location = new System.Drawing.Point(183, 7);
            this.btnNextMappingType.Name = "btnNextMappingType";
            this.btnNextMappingType.Size = new System.Drawing.Size(25, 21);
            this.btnNextMappingType.TabIndex = 29;
            this.btnNextMappingType.Text = ">";
            this.btnNextMappingType.UseVisualStyleBackColor = false;
            this.btnNextMappingType.Click += new System.EventHandler(this.btnNextMappingType_Click);
            // 
            // btnPreviousMappingType
            // 
            this.btnPreviousMappingType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousMappingType.BackColor = System.Drawing.Color.GreenYellow;
            this.btnPreviousMappingType.Enabled = false;
            this.btnPreviousMappingType.Location = new System.Drawing.Point(12, 7);
            this.btnPreviousMappingType.Name = "btnPreviousMappingType";
            this.btnPreviousMappingType.Size = new System.Drawing.Size(25, 21);
            this.btnPreviousMappingType.TabIndex = 28;
            this.btnPreviousMappingType.Text = "<";
            this.btnPreviousMappingType.UseVisualStyleBackColor = false;
            this.btnPreviousMappingType.Click += new System.EventHandler(this.btnPreviousMappingType_Click);
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
            this.lvwMappingResults.Location = new System.Drawing.Point(12, 188);
            this.lvwMappingResults.MultiSelect = false;
            this.lvwMappingResults.Name = "lvwMappingResults";
            this.lvwMappingResults.Size = new System.Drawing.Size(615, 161);
            this.lvwMappingResults.TabIndex = 22;
            this.lvwMappingResults.UseCompatibleStateImageBehavior = false;
            this.lvwMappingResults.View = System.Windows.Forms.View.Details;
            this.lvwMappingResults.DoubleClick += new System.EventHandler(this.lvwMappingResults_DoubleClick);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Source Value";
            this.columnHeader11.Width = 307;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Destination Value";
            this.columnHeader12.Width = 284;
            // 
            // btnEditMapping
            // 
            this.btnEditMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditMapping.Enabled = false;
            this.btnEditMapping.Location = new System.Drawing.Point(633, 268);
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
            this.btnDeleteMapping.Location = new System.Drawing.Point(633, 326);
            this.btnDeleteMapping.Name = "btnDeleteMapping";
            this.btnDeleteMapping.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMapping.TabIndex = 27;
            this.btnDeleteMapping.Text = "Delete";
            this.btnDeleteMapping.UseVisualStyleBackColor = true;
            // 
            // btnResetMappings
            // 
            this.btnResetMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetMappings.Location = new System.Drawing.Point(633, 297);
            this.btnResetMappings.Name = "btnResetMappings";
            this.btnResetMappings.Size = new System.Drawing.Size(75, 23);
            this.btnResetMappings.TabIndex = 25;
            this.btnResetMappings.Text = "Reset";
            this.btnResetMappings.UseVisualStyleBackColor = true;
            // 
            // btnAutoSet
            // 
            this.btnAutoSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoSet.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAutoSet.Location = new System.Drawing.Point(633, 48);
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
            this.btnManualSet.Location = new System.Drawing.Point(633, 77);
            this.btnManualSet.Name = "btnManualSet";
            this.btnManualSet.Size = new System.Drawing.Size(75, 23);
            this.btnManualSet.TabIndex = 24;
            this.btnManualSet.Text = "Set";
            this.btnManualSet.UseVisualStyleBackColor = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Revolutionise Values";
            // 
            // lstImportedColumnValues
            // 
            this.lstImportedColumnValues.FormattingEnabled = true;
            this.lstImportedColumnValues.Location = new System.Drawing.Point(12, 48);
            this.lstImportedColumnValues.Name = "lstImportedColumnValues";
            this.lstImportedColumnValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstImportedColumnValues.Size = new System.Drawing.Size(300, 134);
            this.lstImportedColumnValues.Sorted = true;
            this.lstImportedColumnValues.TabIndex = 20;
            // 
            // lstEuroJudoComparisonValue
            // 
            this.lstEuroJudoComparisonValue.FormattingEnabled = true;
            this.lstEuroJudoComparisonValue.Location = new System.Drawing.Point(327, 48);
            this.lstEuroJudoComparisonValue.Name = "lstEuroJudoComparisonValue";
            this.lstEuroJudoComparisonValue.Size = new System.Drawing.Size(300, 134);
            this.lstEuroJudoComparisonValue.TabIndex = 19;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(324, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "Database Values";
            // 
            // cmbImportedColumnNames
            // 
            this.cmbImportedColumnNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImportedColumnNames.FormattingEnabled = true;
            this.cmbImportedColumnNames.Location = new System.Drawing.Point(372, 7);
            this.cmbImportedColumnNames.Name = "cmbImportedColumnNames";
            this.cmbImportedColumnNames.Size = new System.Drawing.Size(255, 21);
            this.cmbImportedColumnNames.TabIndex = 16;
            this.cmbImportedColumnNames.SelectedIndexChanged += new System.EventHandler(this.cmbImportedColumnNames_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(324, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 13);
            this.label22.TabIndex = 15;
            this.label22.Text = "Column";
            // 
            // pbrAuto
            // 
            this.pbrAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrAuto.Location = new System.Drawing.Point(13, 518);
            this.pbrAuto.Name = "pbrAuto";
            this.pbrAuto.Size = new System.Drawing.Size(759, 18);
            this.pbrAuto.TabIndex = 2;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.tscTournament});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(784, 27);
            this.mnuMain.TabIndex = 3;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 23);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // tscTournament
            // 
            this.tscTournament.Name = "tscTournament";
            this.tscTournament.Size = new System.Drawing.Size(250, 23);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // frmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pbrAuto);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(800, 3000);
            this.Name = "frmDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RevConvert";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourceValueGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabExport.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabEuroJudoWizard.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportBrowse;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.TextBox txtImportFilename;
        private System.Windows.Forms.TextBox txtIJFExportFilename;
        private System.Windows.Forms.Button btnIJFExportBrowse;
        private System.Windows.Forms.Label lblIJFExportFilename;
        private System.Windows.Forms.Label lblEuroJudoFile;
        private System.Windows.Forms.TextBox txtEuroJudoExportFilename;
        private System.Windows.Forms.Button btnEuroJudoSaveFileBrowse;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button btnExport;
        private Utilities.DataGridViewEx SourceValueGrid;
        private System.Windows.Forms.CheckBox chkImportHasHeaders;
        private System.Windows.Forms.Button btnLoadRevolutioniseData;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Label lblInputDelimiter;
        private System.Windows.Forms.ComboBox cmbSplitCharacters;
        private System.Windows.Forms.CheckBox chkRemoveTotalRow;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabExport;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tslblMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEuroJudoDatabaseBrowse;
        private System.Windows.Forms.TextBox txtEuroJudoDatabaseFilename;
        private System.Windows.Forms.TabControl tabEuroJudoWizard;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbEuroJudoTournament;
        private System.Windows.Forms.Button btnReloadTournaments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEuroJudoClubsFilename;
        private System.Windows.Forms.Button btnEuroJudoClubsFileBrowse;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEuroJudoSubDivisionFilename;
        private System.Windows.Forms.Button btnEuroJudoRegionsFileBrowse;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtEuroJudoCountriesFilename;
        private System.Windows.Forms.Button btnEuroJudoCountriesFileBrowse;
        private System.Windows.Forms.TabPage tabPage9;
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
        private System.Windows.Forms.ComboBox cmbImportedColumnNames;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ProgressBar pbrAuto;
        private System.Windows.Forms.Label lblMappingTypeHint;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscTournament;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}

