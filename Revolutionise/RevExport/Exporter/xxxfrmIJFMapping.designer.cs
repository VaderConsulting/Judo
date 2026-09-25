

using Utilities;

namespace Rev
{
    partial class xxxfrmIJFMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEuroJudoMapping));
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.trbComparisonMinimum = new System.Windows.Forms.TrackBar();
            this.lstEuroJudoComparisonValue = new System.Windows.Forms.ListBox();
            this.lvwDatabaseMappingResults = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMinComparisonValue = new System.Windows.Forms.Label();
            this.lblMinComparison = new System.Windows.Forms.Label();
            this.btnEditMapping = new System.Windows.Forms.Button();
            this.btnDeleteMapping = new System.Windows.Forms.Button();
            this.btnResetMappings = new System.Windows.Forms.Button();
            this.lblMappingTypeHint = new System.Windows.Forms.Label();
            this.btnAutoSet = new System.Windows.Forms.Button();
            this.btnManualSet = new System.Windows.Forms.Button();
            this.cmbEuroJudoMappingType = new System.Windows.Forms.ComboBox();
            this.btnNextMappingType = new System.Windows.Forms.Button();
            this.cmbTournament = new System.Windows.Forms.ComboBox();
            this.cmbColumnNamesFromImportData = new System.Windows.Forms.ComboBox();
            this.btnPreviousMappingType = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lstImportedColumnValues = new System.Windows.Forms.ListBox();
            this.lblEuroJudoTournament = new System.Windows.Forms.Label();
            this.pbrAuto = new System.Windows.Forms.ProgressBar();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tslblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.radCopyOrTranslate = new System.Windows.Forms.RadioButton();
            this.radMapToDatabaseValue = new System.Windows.Forms.RadioButton();
            this.radNone = new System.Windows.Forms.RadioButton();
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
            this.trbComparisonMinimum.Location = new System.Drawing.Point(416, 62);
            this.trbComparisonMinimum.Maximum = 100;
            this.trbComparisonMinimum.Name = "trbComparisonMinimum";
            this.trbComparisonMinimum.Size = new System.Drawing.Size(124, 25);
            this.trbComparisonMinimum.TabIndex = 20;
            this.trbComparisonMinimum.TickFrequency = 10;
            this.trbComparisonMinimum.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbComparisonMinimum.ValueChanged += new System.EventHandler(this.trbComparisonMinimum_ValueChanged);
            // 
            // lstEuroJudoComparisonValue
            // 
            this.lstEuroJudoComparisonValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEuroJudoComparisonValue.FormattingEnabled = true;
            this.lstEuroJudoComparisonValue.Location = new System.Drawing.Point(294, 147);
            this.lstEuroJudoComparisonValue.Name = "lstEuroJudoComparisonValue";
            this.lstEuroJudoComparisonValue.Size = new System.Drawing.Size(278, 225);
            this.lstEuroJudoComparisonValue.Sorted = true;
            this.lstEuroJudoComparisonValue.TabIndex = 0;
            this.lstEuroJudoComparisonValue.SelectedIndexChanged += new System.EventHandler(this.lstEuroJudoComparisonValue_SelectedIndexChanged);
            // 
            // lvwDatabaseMappingResults
            // 
            this.lvwDatabaseMappingResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDatabaseMappingResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12});
            this.lvwDatabaseMappingResults.FullRowSelect = true;
            this.lvwDatabaseMappingResults.HideSelection = false;
            this.lvwDatabaseMappingResults.Location = new System.Drawing.Point(11, 378);
            this.lvwDatabaseMappingResults.MultiSelect = false;
            this.lvwDatabaseMappingResults.Name = "lvwDatabaseMappingResults";
            this.lvwDatabaseMappingResults.Size = new System.Drawing.Size(561, 361);
            this.lvwDatabaseMappingResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwDatabaseMappingResults.TabIndex = 15;
            this.lvwDatabaseMappingResults.UseCompatibleStateImageBehavior = false;
            this.lvwDatabaseMappingResults.View = System.Windows.Forms.View.Details;
            this.lvwDatabaseMappingResults.SelectedIndexChanged += new System.EventHandler(this.LvwDatabaseMappingResults_SelectedIndexChanged);
            this.lvwDatabaseMappingResults.DoubleClick += new System.EventHandler(this.lvwDatabaseMappingResults_DoubleClick);
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
            this.lblMinComparisonValue.Location = new System.Drawing.Point(546, 69);
            this.lblMinComparisonValue.Name = "lblMinComparisonValue";
            this.lblMinComparisonValue.Size = new System.Drawing.Size(24, 13);
            this.lblMinComparisonValue.TabIndex = 10;
            this.lblMinComparisonValue.Text = "0 %";
            // 
            // lblMinComparison
            // 
            this.lblMinComparison.Location = new System.Drawing.Point(416, 38);
            this.lblMinComparison.Name = "lblMinComparison";
            this.lblMinComparison.Size = new System.Drawing.Size(154, 21);
            this.lblMinComparison.TabIndex = 9;
            this.lblMinComparison.Text = "Min. Comparison Value";
            this.lblMinComparison.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditMapping
            // 
            this.btnEditMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditMapping.Enabled = false;
            this.btnEditMapping.Location = new System.Drawing.Point(416, 745);
            this.btnEditMapping.Name = "btnEditMapping";
            this.btnEditMapping.Size = new System.Drawing.Size(75, 23);
            this.btnEditMapping.TabIndex = 17;
            this.btnEditMapping.Text = "Edit";
            this.btnEditMapping.UseVisualStyleBackColor = true;
            this.btnEditMapping.Visible = false;
            // 
            // btnDeleteMapping
            // 
            this.btnDeleteMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMapping.Enabled = false;
            this.btnDeleteMapping.Location = new System.Drawing.Point(335, 745);
            this.btnDeleteMapping.Name = "btnDeleteMapping";
            this.btnDeleteMapping.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMapping.TabIndex = 16;
            this.btnDeleteMapping.Text = "Delete";
            this.btnDeleteMapping.UseVisualStyleBackColor = true;
            this.btnDeleteMapping.Visible = false;
            this.btnDeleteMapping.Click += new System.EventHandler(this.BtnDeleteMapping_Click);
            // 
            // btnResetMappings
            // 
            this.btnResetMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetMappings.Enabled = false;
            this.btnResetMappings.Location = new System.Drawing.Point(497, 745);
            this.btnResetMappings.Name = "btnResetMappings";
            this.btnResetMappings.Size = new System.Drawing.Size(75, 23);
            this.btnResetMappings.TabIndex = 18;
            this.btnResetMappings.Text = "Reset";
            this.btnResetMappings.UseVisualStyleBackColor = true;
            this.btnResetMappings.Click += new System.EventHandler(this.btnResetMappings_Click);
            // 
            // lblMappingTypeHint
            // 
            this.lblMappingTypeHint.AutoSize = true;
            this.lblMappingTypeHint.Location = new System.Drawing.Point(12, 46);
            this.lblMappingTypeHint.Name = "lblMappingTypeHint";
            this.lblMappingTypeHint.Size = new System.Drawing.Size(58, 13);
            this.lblMappingTypeHint.TabIndex = 2;
            this.lblMappingTypeHint.Text = "Step 0 of x";
            // 
            // btnAutoSet
            // 
            this.btnAutoSet.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAutoSet.Enabled = false;
            this.btnAutoSet.Location = new System.Drawing.Point(497, 93);
            this.btnAutoSet.Name = "btnAutoSet";
            this.btnAutoSet.Size = new System.Drawing.Size(75, 23);
            this.btnAutoSet.TabIndex = 8;
            this.btnAutoSet.Text = "Auto";
            this.btnAutoSet.UseVisualStyleBackColor = false;
            this.btnAutoSet.Click += new System.EventHandler(this.btnAutoSet_Click);
            // 
            // btnManualSet
            // 
            this.btnManualSet.BackColor = System.Drawing.Color.GreenYellow;
            this.btnManualSet.Enabled = false;
            this.btnManualSet.Location = new System.Drawing.Point(416, 93);
            this.btnManualSet.Name = "btnManualSet";
            this.btnManualSet.Size = new System.Drawing.Size(75, 23);
            this.btnManualSet.TabIndex = 14;
            this.btnManualSet.Text = "Set";
            this.btnManualSet.UseVisualStyleBackColor = false;
            this.btnManualSet.Click += new System.EventHandler(this.btnManualSet_Click);
            // 
            // cmbEuroJudoMappingType
            // 
            this.cmbEuroJudoMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEuroJudoMappingType.FormattingEnabled = true;
            this.cmbEuroJudoMappingType.Location = new System.Drawing.Point(118, 41);
            this.cmbEuroJudoMappingType.Name = "cmbEuroJudoMappingType";
            this.cmbEuroJudoMappingType.Size = new System.Drawing.Size(233, 21);
            this.cmbEuroJudoMappingType.TabIndex = 5;
            this.cmbEuroJudoMappingType.SelectedIndexChanged += new System.EventHandler(this.cmbEuroJudoMappingType_SelectedIndexChanged);
            // 
            // btnNextMappingType
            // 
            this.btnNextMappingType.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNextMappingType.Location = new System.Drawing.Point(357, 41);
            this.btnNextMappingType.Name = "btnNextMappingType";
            this.btnNextMappingType.Size = new System.Drawing.Size(25, 23);
            this.btnNextMappingType.TabIndex = 4;
            this.btnNextMappingType.Text = ">";
            this.btnNextMappingType.UseVisualStyleBackColor = false;
            this.btnNextMappingType.Click += new System.EventHandler(this.btnNextMappingType_Click);
            // 
            // cmbTournament
            // 
            this.cmbTournament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTournament.FormattingEnabled = true;
            this.cmbTournament.Location = new System.Drawing.Point(87, 12);
            this.cmbTournament.Name = "cmbTournament";
            this.cmbTournament.Size = new System.Drawing.Size(295, 21);
            this.cmbTournament.TabIndex = 1;
            this.cmbTournament.SelectedIndexChanged += new System.EventHandler(this.cmdTournament_SelectedIndexChanged);
            // 
            // cmbColumnNamesFromImportData
            // 
            this.cmbColumnNamesFromImportData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumnNamesFromImportData.FormattingEnabled = true;
            this.cmbColumnNamesFromImportData.Location = new System.Drawing.Point(87, 70);
            this.cmbColumnNamesFromImportData.Name = "cmbColumnNamesFromImportData";
            this.cmbColumnNamesFromImportData.Size = new System.Drawing.Size(295, 21);
            this.cmbColumnNamesFromImportData.TabIndex = 7;
            this.cmbColumnNamesFromImportData.SelectedIndexChanged += new System.EventHandler(this.cmbColumnNamesFromImportData_SelectedIndexChanged);
            // 
            // btnPreviousMappingType
            // 
            this.btnPreviousMappingType.BackColor = System.Drawing.Color.GreenYellow;
            this.btnPreviousMappingType.Enabled = false;
            this.btnPreviousMappingType.Location = new System.Drawing.Point(87, 41);
            this.btnPreviousMappingType.Name = "btnPreviousMappingType";
            this.btnPreviousMappingType.Size = new System.Drawing.Size(25, 23);
            this.btnPreviousMappingType.TabIndex = 3;
            this.btnPreviousMappingType.Text = "<";
            this.btnPreviousMappingType.UseVisualStyleBackColor = false;
            this.btnPreviousMappingType.Click += new System.EventHandler(this.btnPreviousMappingType_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 74);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "Column";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 131);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "Import file Values";
            // 
            // lstImportedColumnValues
            // 
            this.lstImportedColumnValues.FormattingEnabled = true;
            this.lstImportedColumnValues.Location = new System.Drawing.Point(11, 147);
            this.lstImportedColumnValues.Name = "lstImportedColumnValues";
            this.lstImportedColumnValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstImportedColumnValues.Size = new System.Drawing.Size(277, 225);
            this.lstImportedColumnValues.Sorted = true;
            this.lstImportedColumnValues.TabIndex = 12;
            this.lstImportedColumnValues.SelectedIndexChanged += new System.EventHandler(this.lstImportedColumnValues_SelectedIndexChanged);
            this.lstImportedColumnValues.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstImportedColumnValues_MouseDoubleClick);
            // 
            // lblEuroJudoTournament
            // 
            this.lblEuroJudoTournament.AutoSize = true;
            this.lblEuroJudoTournament.Location = new System.Drawing.Point(6, 15);
            this.lblEuroJudoTournament.Name = "lblEuroJudoTournament";
            this.lblEuroJudoTournament.Size = new System.Drawing.Size(64, 13);
            this.lblEuroJudoTournament.TabIndex = 0;
            this.lblEuroJudoTournament.Text = "Tournament";
            // 
            // pbrAuto
            // 
            this.pbrAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrAuto.Location = new System.Drawing.Point(12, 774);
            this.pbrAuto.Name = "pbrAuto";
            this.pbrAuto.Size = new System.Drawing.Size(560, 18);
            this.pbrAuto.TabIndex = 3;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblMain});
            this.ssMain.Location = new System.Drawing.Point(0, 795);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(584, 22);
            this.ssMain.TabIndex = 4;
            // 
            // tslblMain
            // 
            this.tslblMain.Name = "tslblMain";
            this.tslblMain.Size = new System.Drawing.Size(26, 17);
            this.tslblMain.Text = "Idle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Database Values";
            // 
            // radCopyOrTranslate
            // 
            this.radCopyOrTranslate.AutoSize = true;
            this.radCopyOrTranslate.Location = new System.Drawing.Point(206, 96);
            this.radCopyOrTranslate.Name = "radCopyOrTranslate";
            this.radCopyOrTranslate.Size = new System.Drawing.Size(104, 17);
            this.radCopyOrTranslate.TabIndex = 22;
            this.radCopyOrTranslate.Text = "Copy / Translate";
            this.radCopyOrTranslate.UseVisualStyleBackColor = true;
            this.radCopyOrTranslate.CheckedChanged += new System.EventHandler(this.radCopyOrTranslate_CheckedChanged);
            // 
            // radMapToDatabaseValue
            // 
            this.radMapToDatabaseValue.AutoSize = true;
            this.radMapToDatabaseValue.Checked = true;
            this.radMapToDatabaseValue.Location = new System.Drawing.Point(87, 96);
            this.radMapToDatabaseValue.Name = "radMapToDatabaseValue";
            this.radMapToDatabaseValue.Size = new System.Drawing.Size(104, 17);
            this.radMapToDatabaseValue.TabIndex = 23;
            this.radMapToDatabaseValue.TabStop = true;
            this.radMapToDatabaseValue.Text = "Map to Db value";
            this.radMapToDatabaseValue.UseVisualStyleBackColor = true;
            this.radMapToDatabaseValue.CheckedChanged += new System.EventHandler(this.radMapToDatabaseValue_CheckedChanged);
            // 
            // radNone
            // 
            this.radNone.AutoSize = true;
            this.radNone.Location = new System.Drawing.Point(331, 96);
            this.radNone.Name = "radNone";
            this.radNone.Size = new System.Drawing.Size(51, 17);
            this.radNone.TabIndex = 24;
            this.radNone.Text = "None";
            this.radNone.UseVisualStyleBackColor = true;
            this.radNone.CheckedChanged += new System.EventHandler(this.radNone_CheckedChanged);
            // 
            // frmEuroJudoMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 817);
            this.Controls.Add(this.radNone);
            this.Controls.Add(this.radMapToDatabaseValue);
            this.Controls.Add(this.radCopyOrTranslate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstEuroJudoComparisonValue);
            this.Controls.Add(this.lvwDatabaseMappingResults);
            this.Controls.Add(this.trbComparisonMinimum);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.lblMinComparisonValue);
            this.Controls.Add(this.lblMinComparison);
            this.Controls.Add(this.pbrAuto);
            this.Controls.Add(this.btnEditMapping);
            this.Controls.Add(this.btnDeleteMapping);
            this.Controls.Add(this.lblEuroJudoTournament);
            this.Controls.Add(this.btnResetMappings);
            this.Controls.Add(this.lstImportedColumnValues);
            this.Controls.Add(this.lblMappingTypeHint);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnAutoSet);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnManualSet);
            this.Controls.Add(this.btnPreviousMappingType);
            this.Controls.Add(this.cmbEuroJudoMappingType);
            this.Controls.Add(this.cmbColumnNamesFromImportData);
            this.Controls.Add(this.btnNextMappingType);
            this.Controls.Add(this.cmbTournament);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(600, 3000);
            this.MinimumSize = new System.Drawing.Size(555, 600);
            this.Name = "frmEuroJudoMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Euro Judo Mapping";
            this.Load += new System.EventHandler(this.frmEuroJudoMapping_Load);
            this.Shown += new System.EventHandler(this.frmEuroJudoMapping_Shown);
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
        private System.Windows.Forms.ComboBox cmbEuroJudoMappingType;
        private System.Windows.Forms.Button btnNextMappingType;
        private System.Windows.Forms.Button btnPreviousMappingType;
        private System.Windows.Forms.ListView lvwDatabaseMappingResults;
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
        private System.Windows.Forms.ComboBox cmbColumnNamesFromImportData;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ProgressBar pbrAuto;
        private System.Windows.Forms.Label lblMappingTypeHint;
        private System.Windows.Forms.Label lblEuroJudoTournament;
        private System.Windows.Forms.ComboBox cmbTournament;
        private System.Windows.Forms.Label lblMinComparisonValue;
        private System.Windows.Forms.Label lblMinComparison;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tslblMain;
        private System.Windows.Forms.TrackBar trbComparisonMinimum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radMapToDatabaseValue;
        private System.Windows.Forms.RadioButton radCopyOrTranslate;
        private System.Windows.Forms.RadioButton radNone;
    }
}

