

using Utilities;

namespace MappingTool
{
    partial class frmMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapping));
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.trbComparisonMinimum = new System.Windows.Forms.TrackBar();
            this.lstComparisonValue = new System.Windows.Forms.ListBox();
            this.lvwMappingResults = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMinComparisonValue = new System.Windows.Forms.Label();
            this.lblMinComparison = new System.Windows.Forms.Label();
            this.btnResetMappings = new System.Windows.Forms.Button();
            this.lblMappingTypeHint = new System.Windows.Forms.Label();
            this.btnAutoSet = new System.Windows.Forms.Button();
            this.btnManualSet = new System.Windows.Forms.Button();
            this.cmbMappingType = new System.Windows.Forms.ComboBox();
            this.btnNextMappingType = new System.Windows.Forms.Button();
            this.cmbEuroJudoTournamentName = new System.Windows.Forms.ComboBox();
            this.cmbColumnNamesFromImportData = new System.Windows.Forms.ComboBox();
            this.btnPreviousMappingType = new System.Windows.Forms.Button();
            this.lblColumn = new System.Windows.Forms.Label();
            this.lblImportFileValues = new System.Windows.Forms.Label();
            this.lstImportedColumnValues = new System.Windows.Forms.ListBox();
            this.lblEuroJudoTournament = new System.Windows.Forms.Label();
            this.pbrAuto = new System.Windows.Forms.ProgressBar();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tslblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDatabaseValues = new System.Windows.Forms.Label();
            this.radCopyOrTranslate = new System.Windows.Forms.RadioButton();
            this.radMapToDatabaseValue = new System.Windows.Forms.RadioButton();
            this.radNone = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblMappingIncomplete = new System.Windows.Forms.Label();
            this.cmbIJFTournamentName = new System.Windows.Forms.ComboBox();
            this.lblIJFTournament = new System.Windows.Forms.Label();
            this.btnClearColumnSelection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbComparisonMinimum)).BeginInit();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // trbComparisonMinimum
            // 
            this.trbComparisonMinimum.AutoSize = false;
            this.trbComparisonMinimum.LargeChange = 10;
            this.trbComparisonMinimum.Location = new System.Drawing.Point(416, 89);
            this.trbComparisonMinimum.Maximum = 100;
            this.trbComparisonMinimum.Name = "trbComparisonMinimum";
            this.trbComparisonMinimum.Size = new System.Drawing.Size(124, 25);
            this.trbComparisonMinimum.TabIndex = 10;
            this.trbComparisonMinimum.TickFrequency = 10;
            this.trbComparisonMinimum.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbComparisonMinimum.ValueChanged += new System.EventHandler(this.trbComparisonMinimum_ValueChanged);
            // 
            // lstComparisonValue
            // 
            this.lstComparisonValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstComparisonValue.FormattingEnabled = true;
            this.lstComparisonValue.Location = new System.Drawing.Point(294, 173);
            this.lstComparisonValue.Name = "lstComparisonValue";
            this.lstComparisonValue.Size = new System.Drawing.Size(278, 199);
            this.lstComparisonValue.Sorted = true;
            this.lstComparisonValue.TabIndex = 22;
            this.lstComparisonValue.SelectedIndexChanged += new System.EventHandler(this.lstComparisonValue_SelectedIndexChanged);
            this.lstComparisonValue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstComparisonValue_MouseUp);
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
            this.lvwMappingResults.Location = new System.Drawing.Point(11, 378);
            this.lvwMappingResults.MultiSelect = false;
            this.lvwMappingResults.Name = "lvwMappingResults";
            this.lvwMappingResults.Size = new System.Drawing.Size(561, 361);
            this.lvwMappingResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwMappingResults.TabIndex = 23;
            this.lvwMappingResults.UseCompatibleStateImageBehavior = false;
            this.lvwMappingResults.View = System.Windows.Forms.View.Details;
            this.lvwMappingResults.SelectedIndexChanged += new System.EventHandler(this.lvwMappingResults_SelectedIndexChanged);
            this.lvwMappingResults.DoubleClick += new System.EventHandler(this.lvwMappingResults_DoubleClick);
            this.lvwMappingResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwMappingResults_KeyDown);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Source Value";
            this.columnHeader11.Width = 279;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Destination Value";
            this.columnHeader12.Width = 251;
            // 
            // lblMinComparisonValue
            // 
            this.lblMinComparisonValue.AutoSize = true;
            this.lblMinComparisonValue.Location = new System.Drawing.Point(546, 96);
            this.lblMinComparisonValue.Name = "lblMinComparisonValue";
            this.lblMinComparisonValue.Size = new System.Drawing.Size(24, 13);
            this.lblMinComparisonValue.TabIndex = 13;
            this.lblMinComparisonValue.Text = "0 %";
            // 
            // lblMinComparison
            // 
            this.lblMinComparison.Location = new System.Drawing.Point(416, 65);
            this.lblMinComparison.Name = "lblMinComparison";
            this.lblMinComparison.Size = new System.Drawing.Size(154, 21);
            this.lblMinComparison.TabIndex = 5;
            this.lblMinComparison.Text = "Min. Comparison Value";
            this.lblMinComparison.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnResetMappings
            // 
            this.btnResetMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetMappings.Enabled = false;
            this.btnResetMappings.Location = new System.Drawing.Point(416, 769);
            this.btnResetMappings.Name = "btnResetMappings";
            this.btnResetMappings.Size = new System.Drawing.Size(75, 23);
            this.btnResetMappings.TabIndex = 26;
            this.btnResetMappings.Text = "Reset";
            this.btnResetMappings.UseVisualStyleBackColor = true;
            this.btnResetMappings.Click += new System.EventHandler(this.btnResetMappings_Click);
            // 
            // lblMappingTypeHint
            // 
            this.lblMappingTypeHint.AutoSize = true;
            this.lblMappingTypeHint.Location = new System.Drawing.Point(6, 69);
            this.lblMappingTypeHint.Name = "lblMappingTypeHint";
            this.lblMappingTypeHint.Size = new System.Drawing.Size(58, 13);
            this.lblMappingTypeHint.TabIndex = 4;
            this.lblMappingTypeHint.Text = "Step 0 of x";
            // 
            // btnAutoSet
            // 
            this.btnAutoSet.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAutoSet.Location = new System.Drawing.Point(497, 120);
            this.btnAutoSet.Name = "btnAutoSet";
            this.btnAutoSet.Size = new System.Drawing.Size(75, 23);
            this.btnAutoSet.TabIndex = 18;
            this.btnAutoSet.Text = "Auto";
            this.btnAutoSet.UseVisualStyleBackColor = false;
            this.btnAutoSet.Click += new System.EventHandler(this.btnAutoSet_Click);
            // 
            // btnManualSet
            // 
            this.btnManualSet.BackColor = System.Drawing.Color.GreenYellow;
            this.btnManualSet.Enabled = false;
            this.btnManualSet.Location = new System.Drawing.Point(416, 120);
            this.btnManualSet.Name = "btnManualSet";
            this.btnManualSet.Size = new System.Drawing.Size(75, 23);
            this.btnManualSet.TabIndex = 17;
            this.btnManualSet.Text = "Set";
            this.btnManualSet.UseVisualStyleBackColor = false;
            this.btnManualSet.Click += new System.EventHandler(this.btnManualSet_Click);
            // 
            // cmbMappingType
            // 
            this.cmbMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMappingType.FormattingEnabled = true;
            this.cmbMappingType.Location = new System.Drawing.Point(127, 66);
            this.cmbMappingType.Name = "cmbMappingType";
            this.cmbMappingType.Size = new System.Drawing.Size(224, 21);
            this.cmbMappingType.TabIndex = 7;
            this.cmbMappingType.SelectedIndexChanged += new System.EventHandler(this.cmbMappingType_SelectedIndexChanged);
            // 
            // btnNextMappingType
            // 
            this.btnNextMappingType.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNextMappingType.Location = new System.Drawing.Point(357, 66);
            this.btnNextMappingType.Name = "btnNextMappingType";
            this.btnNextMappingType.Size = new System.Drawing.Size(25, 23);
            this.btnNextMappingType.TabIndex = 8;
            this.btnNextMappingType.Text = ">";
            this.btnNextMappingType.UseVisualStyleBackColor = false;
            this.btnNextMappingType.Click += new System.EventHandler(this.btnNextMappingType_Click);
            // 
            // cmbEuroJudoTournamentName
            // 
            this.cmbEuroJudoTournamentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEuroJudoTournamentName.FormattingEnabled = true;
            this.cmbEuroJudoTournamentName.Location = new System.Drawing.Point(127, 12);
            this.cmbEuroJudoTournamentName.Name = "cmbEuroJudoTournamentName";
            this.cmbEuroJudoTournamentName.Size = new System.Drawing.Size(443, 21);
            this.cmbEuroJudoTournamentName.TabIndex = 1;
            this.cmbEuroJudoTournamentName.SelectedIndexChanged += new System.EventHandler(this.cmbEuroJudoTournamentName_SelectedIndexChanged);
            // 
            // cmbColumnNamesFromImportData
            // 
            this.cmbColumnNamesFromImportData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumnNamesFromImportData.FormattingEnabled = true;
            this.cmbColumnNamesFromImportData.Location = new System.Drawing.Point(127, 95);
            this.cmbColumnNamesFromImportData.Name = "cmbColumnNamesFromImportData";
            this.cmbColumnNamesFromImportData.Size = new System.Drawing.Size(224, 21);
            this.cmbColumnNamesFromImportData.TabIndex = 11;
            this.cmbColumnNamesFromImportData.SelectedIndexChanged += new System.EventHandler(this.cmbColumnNamesFromImportData_SelectedIndexChanged);
            // 
            // btnPreviousMappingType
            // 
            this.btnPreviousMappingType.BackColor = System.Drawing.Color.GreenYellow;
            this.btnPreviousMappingType.Enabled = false;
            this.btnPreviousMappingType.Location = new System.Drawing.Point(96, 66);
            this.btnPreviousMappingType.Name = "btnPreviousMappingType";
            this.btnPreviousMappingType.Size = new System.Drawing.Size(25, 23);
            this.btnPreviousMappingType.TabIndex = 6;
            this.btnPreviousMappingType.Text = "<";
            this.btnPreviousMappingType.UseVisualStyleBackColor = false;
            this.btnPreviousMappingType.Click += new System.EventHandler(this.btnPreviousMappingType_Click);
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(6, 98);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(42, 13);
            this.lblColumn.TabIndex = 9;
            this.lblColumn.Text = "Column";
            // 
            // lblImportFileValues
            // 
            this.lblImportFileValues.AutoSize = true;
            this.lblImportFileValues.Location = new System.Drawing.Point(12, 157);
            this.lblImportFileValues.Name = "lblImportFileValues";
            this.lblImportFileValues.Size = new System.Drawing.Size(87, 13);
            this.lblImportFileValues.TabIndex = 19;
            this.lblImportFileValues.Text = "Import file Values";
            // 
            // lstImportedColumnValues
            // 
            this.lstImportedColumnValues.FormattingEnabled = true;
            this.lstImportedColumnValues.Location = new System.Drawing.Point(11, 173);
            this.lstImportedColumnValues.Name = "lstImportedColumnValues";
            this.lstImportedColumnValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstImportedColumnValues.Size = new System.Drawing.Size(277, 199);
            this.lstImportedColumnValues.Sorted = true;
            this.lstImportedColumnValues.TabIndex = 21;
            this.lstImportedColumnValues.SelectedIndexChanged += new System.EventHandler(this.lstImportedColumnValues_SelectedIndexChanged);
            this.lstImportedColumnValues.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstImportedColumnValues_MouseDoubleClick);
            // 
            // lblEuroJudoTournament
            // 
            this.lblEuroJudoTournament.AutoSize = true;
            this.lblEuroJudoTournament.Location = new System.Drawing.Point(6, 15);
            this.lblEuroJudoTournament.Name = "lblEuroJudoTournament";
            this.lblEuroJudoTournament.Size = new System.Drawing.Size(115, 13);
            this.lblEuroJudoTournament.TabIndex = 0;
            this.lblEuroJudoTournament.Text = "Euro Judo Tournament";
            // 
            // pbrAuto
            // 
            this.pbrAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrAuto.Location = new System.Drawing.Point(12, 745);
            this.pbrAuto.Name = "pbrAuto";
            this.pbrAuto.Size = new System.Drawing.Size(560, 18);
            this.pbrAuto.TabIndex = 24;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblMain});
            this.ssMain.Location = new System.Drawing.Point(0, 795);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(584, 22);
            this.ssMain.TabIndex = 28;
            // 
            // tslblMain
            // 
            this.tslblMain.Name = "tslblMain";
            this.tslblMain.Size = new System.Drawing.Size(26, 17);
            this.tslblMain.Text = "Idle";
            // 
            // lblDatabaseValues
            // 
            this.lblDatabaseValues.AutoSize = true;
            this.lblDatabaseValues.Location = new System.Drawing.Point(291, 157);
            this.lblDatabaseValues.Name = "lblDatabaseValues";
            this.lblDatabaseValues.Size = new System.Drawing.Size(88, 13);
            this.lblDatabaseValues.TabIndex = 20;
            this.lblDatabaseValues.Text = "Database Values";
            // 
            // radCopyOrTranslate
            // 
            this.radCopyOrTranslate.AutoSize = true;
            this.radCopyOrTranslate.Location = new System.Drawing.Point(242, 121);
            this.radCopyOrTranslate.Name = "radCopyOrTranslate";
            this.radCopyOrTranslate.Size = new System.Drawing.Size(104, 17);
            this.radCopyOrTranslate.TabIndex = 15;
            this.radCopyOrTranslate.Text = "Copy / Translate";
            this.radCopyOrTranslate.UseVisualStyleBackColor = true;
            this.radCopyOrTranslate.CheckedChanged += new System.EventHandler(this.radCopyOrTranslate_CheckedChanged);
            // 
            // radMapToDatabaseValue
            // 
            this.radMapToDatabaseValue.AutoSize = true;
            this.radMapToDatabaseValue.Checked = true;
            this.radMapToDatabaseValue.Location = new System.Drawing.Point(127, 121);
            this.radMapToDatabaseValue.Name = "radMapToDatabaseValue";
            this.radMapToDatabaseValue.Size = new System.Drawing.Size(104, 17);
            this.radMapToDatabaseValue.TabIndex = 14;
            this.radMapToDatabaseValue.TabStop = true;
            this.radMapToDatabaseValue.Text = "Map to Db value";
            this.radMapToDatabaseValue.UseVisualStyleBackColor = true;
            this.radMapToDatabaseValue.CheckedChanged += new System.EventHandler(this.radMapToDatabaseValue_CheckedChanged);
            // 
            // radNone
            // 
            this.radNone.AutoSize = true;
            this.radNone.Location = new System.Drawing.Point(357, 121);
            this.radNone.Name = "radNone";
            this.radNone.Size = new System.Drawing.Size(51, 17);
            this.radNone.TabIndex = 16;
            this.radNone.Text = "None";
            this.radNone.UseVisualStyleBackColor = true;
            this.radNone.CheckedChanged += new System.EventHandler(this.radNone_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(497, 769);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 27;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblMappingIncomplete
            // 
            this.lblMappingIncomplete.AutoSize = true;
            this.lblMappingIncomplete.ForeColor = System.Drawing.Color.Red;
            this.lblMappingIncomplete.Location = new System.Drawing.Point(12, 774);
            this.lblMappingIncomplete.Name = "lblMappingIncomplete";
            this.lblMappingIncomplete.Size = new System.Drawing.Size(102, 13);
            this.lblMappingIncomplete.TabIndex = 25;
            this.lblMappingIncomplete.Text = "Mapping incomplete";
            this.lblMappingIncomplete.Visible = false;
            // 
            // cmbIJFTournamentName
            // 
            this.cmbIJFTournamentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIJFTournamentName.FormattingEnabled = true;
            this.cmbIJFTournamentName.Location = new System.Drawing.Point(127, 39);
            this.cmbIJFTournamentName.Name = "cmbIJFTournamentName";
            this.cmbIJFTournamentName.Size = new System.Drawing.Size(443, 21);
            this.cmbIJFTournamentName.TabIndex = 3;
            this.cmbIJFTournamentName.SelectedIndexChanged += new System.EventHandler(this.cmbIJFTournamentName_SelectedIndexChanged);
            // 
            // lblIJFTournament
            // 
            this.lblIJFTournament.AutoSize = true;
            this.lblIJFTournament.Location = new System.Drawing.Point(6, 42);
            this.lblIJFTournament.Name = "lblIJFTournament";
            this.lblIJFTournament.Size = new System.Drawing.Size(81, 13);
            this.lblIJFTournament.TabIndex = 2;
            this.lblIJFTournament.Text = "IJF Tournament";
            // 
            // btnClearColumnSelection
            // 
            this.btnClearColumnSelection.Location = new System.Drawing.Point(357, 93);
            this.btnClearColumnSelection.Name = "btnClearColumnSelection";
            this.btnClearColumnSelection.Size = new System.Drawing.Size(41, 23);
            this.btnClearColumnSelection.TabIndex = 12;
            this.btnClearColumnSelection.Text = "Clear";
            this.btnClearColumnSelection.UseVisualStyleBackColor = true;
            this.btnClearColumnSelection.Click += new System.EventHandler(this.btnClearColumnSelection_Click);
            // 
            // frmMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 817);
            this.Controls.Add(this.lblIJFTournament);
            this.Controls.Add(this.cmbIJFTournamentName);
            this.Controls.Add(this.lblMappingIncomplete);
            this.Controls.Add(this.btnClearColumnSelection);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.radNone);
            this.Controls.Add(this.radMapToDatabaseValue);
            this.Controls.Add(this.radCopyOrTranslate);
            this.Controls.Add(this.lblDatabaseValues);
            this.Controls.Add(this.lstComparisonValue);
            this.Controls.Add(this.lvwMappingResults);
            this.Controls.Add(this.trbComparisonMinimum);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.lblMinComparisonValue);
            this.Controls.Add(this.lblMinComparison);
            this.Controls.Add(this.pbrAuto);
            this.Controls.Add(this.lblEuroJudoTournament);
            this.Controls.Add(this.btnResetMappings);
            this.Controls.Add(this.lstImportedColumnValues);
            this.Controls.Add(this.lblMappingTypeHint);
            this.Controls.Add(this.lblImportFileValues);
            this.Controls.Add(this.btnAutoSet);
            this.Controls.Add(this.lblColumn);
            this.Controls.Add(this.btnManualSet);
            this.Controls.Add(this.btnPreviousMappingType);
            this.Controls.Add(this.cmbMappingType);
            this.Controls.Add(this.cmbColumnNamesFromImportData);
            this.Controls.Add(this.btnNextMappingType);
            this.Controls.Add(this.cmbEuroJudoTournamentName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(600, 3000);
            this.MinimumSize = new System.Drawing.Size(555, 600);
            this.Name = "frmMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMapping_FormClosing);
            this.Load += new System.EventHandler(this.frmMapping_Load);
            this.Shown += new System.EventHandler(this.frmMapping_Shown);
            this.Move += new System.EventHandler(this.frmMapping_Move);
            this.Resize += new System.EventHandler(this.frmMapping_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbComparisonMinimum)).EndInit();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.ComboBox cmbMappingType;
        private System.Windows.Forms.Button btnNextMappingType;
        private System.Windows.Forms.Button btnPreviousMappingType;
        private System.Windows.Forms.ListView lvwMappingResults;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button btnResetMappings;
        private System.Windows.Forms.Button btnAutoSet;
        private System.Windows.Forms.Button btnManualSet;
        private System.Windows.Forms.Label lblImportFileValues;
        private System.Windows.Forms.ListBox lstImportedColumnValues;
        private System.Windows.Forms.ListBox lstComparisonValue;
        private System.Windows.Forms.ComboBox cmbColumnNamesFromImportData;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.ProgressBar pbrAuto;
        private System.Windows.Forms.Label lblMappingTypeHint;
        private System.Windows.Forms.Label lblEuroJudoTournament;
        private System.Windows.Forms.ComboBox cmbEuroJudoTournamentName;
        private System.Windows.Forms.Label lblMinComparisonValue;
        private System.Windows.Forms.Label lblMinComparison;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tslblMain;
        private System.Windows.Forms.TrackBar trbComparisonMinimum;
        private System.Windows.Forms.Label lblDatabaseValues;
        private System.Windows.Forms.RadioButton radMapToDatabaseValue;
        private System.Windows.Forms.RadioButton radCopyOrTranslate;
        private System.Windows.Forms.RadioButton radNone;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblMappingIncomplete;
        private System.Windows.Forms.Label lblIJFTournament;
        private System.Windows.Forms.ComboBox cmbIJFTournamentName;
        private System.Windows.Forms.Button btnClearColumnSelection;
    }
}

