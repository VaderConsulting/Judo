using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using static Utilities.Extensions;
using Designer;

namespace Designer
{
    public partial class frmDesigner : Form
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private DataTable CountrySourceData = new DataTable();
        private DataTable SubDivisionSourceData = new DataTable();

        List<EuroJudoCountry> Countries = new List<EuroJudoCountry>();
        List<EuroJudoSubDivision> SubDivisions = new List<EuroJudoSubDivision>();
        private List<EuroJudoClub> EuroJudoClubs = new List<EuroJudoClub>();

        private DataTable RevolutioniseSourceData = new DataTable();
        private DataTable ClubSourceData = new DataTable();
        private List<EuroJudoTournament> EuroJudoTournaments = new List<EuroJudoTournament>();
        private List<StringToEuroJudoEventMapping> EventMappings = new List<StringToEuroJudoEventMapping>();
        private List<StringToEuroJudoWeightMapping> WeightCategoryMappings = new List<StringToEuroJudoWeightMapping>();
        private List<StringToEuroJudoClubMapping> ClubMappings = new List<StringToEuroJudoClubMapping>();
        private EuroJudoTournament SelectedEuroJudoTournament = null;
        private List<EuroJudoEvent> EuroJudoEvents = new List<EuroJudoEvent>();
        private List<EuroJudoWeightCategory> EuroJudoWeightCategories = new List<EuroJudoWeightCategory>();

        private bool InitialLoadComplete = false;
        private bool TournamentLoaded = false;

        //private bool EventSourceLoaded = false;
        //private bool WeightSourceLoaded = false;
        //private bool ClubSourceLoaded = false;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmDesigner()
        {
            InitializeComponent();
        }

        ~frmDesigner()
        {
            RevolutioniseSourceData.Dispose();
        }

        #endregion

        #region Event Handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            //cmbSplitCharacters.SelectedIndex = 0;

            //Properties.Settings.Default.ImportFilename = Properties.Settings.Default.ImportFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\revolutioniseSPORT-JudoWA-Anothertest.csv
            //txtIJFExportFilename.Text = Properties.Settings.Default.EuroJudoExportFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\ijf.csv

            Debug.Print($"Inside {CurrentMethodName()}");

            cmbEuroJudoMappingType.Items.Add("Event type");
            cmbEuroJudoMappingType.Items.Add("Weight category");
            cmbEuroJudoMappingType.Items.Add("Club");

            btnPreviousMappingType.Enabled = false;
            btnNextMappingType.Enabled = true;

        }

        private void FrmDesigner_Shown(object sender, EventArgs e)
        {
            DoStartup();
        }


        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (tabMain.SelectedIndex)
            //{
            //    case 0: // Import

            //        break;
            //    case 1: // Export

            //        break;
            //}
        }

        private void TabExportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            switch (tabExportType.SelectedIndex)
            {
                case 0: // IJF
                    break;
                case 1: // EuroJudo
                    // Set textbox defaults according to the last values used
                    //txtEuroJudoDatabaseFilename.Text = Properties.Settings.Default.EuroJudoTournamentFilename; // C:\Users\YourUser\OneDrive\Documents\Judo\Tournaments\Tournaments.mdb
                    //txtEuroJudoExportFilename.Text = Properties.Settings.Default.EuroJudoExportFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\euro.xls
                    //txtEuroJudoClubsFilename.Text = Properties.Settings.Default.EuroJudoClubsFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\Clubs.csv
                    //txtEuroJudoCountriesFilename.Text = Properties.Settings.Default.EuroJudoCountriesFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\Countries.csv
                    //txtEuroJudoSubDivisionFilename.Text = Properties.Settings.Default.EuroJudoSubDivisionsFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\SubDivisions.csv

                    //// This requires filepaths to be defined
                    //Countries = GetCountries(Properties.Settings.Default.EuroJudoCountriesFilename);

                    //// SubDivisions needs Countries to be loaded first
                    //SubDivisions = GetSubDivisions(Properties.Settings.Default.EuroJudoSubDivisionsFilename);

                    //EuroJudoTournaments = GetEuroJudoTournaments(tscTournament, Properties.Settings.Default.EuroJudoTournamentQuery);
                    //EuroJudoClubs = GetEuroJudoClubs(Properties.Settings.Default.EuroJudoClubsFilename);

                    //// This requires the Tournaments to be loaded
                    //if (Properties.Settings.Default.LastEuroJudoTournament.Trim().Length > 0 && tscTournament.Items.Contains(EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament)))
                    //{
                    //    tscTournament.SelectedItem = EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament);
                    //}


                    break;
            }
        }

        private void tscTournament_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            SelectedEuroJudoTournament = (EuroJudoTournament)tscTournament.SelectedItem;

            Properties.Settings.Default.LastEuroJudoTournament = SelectedEuroJudoTournament.Name;
            Properties.Settings.Default.Save();

            if (TournamentLoaded)
            {
                MessageBox.Show("The application must now restart.\r\nThis behaviour will change in a future version.");
                Application.Restart();
            }

            //SetMappingType();

            //ClearValues();

            //tscTournament.Enabled = false;
        }

        private void btnPreviousMappingType_Click(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            cmbEuroJudoMappingType.SelectedIndex--;
        }

        private void btnNextMappingType_Click(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            cmbEuroJudoMappingType.SelectedIndex++;
        }

        private void cmbEuroJudoMappingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            if (cmbEuroJudoMappingType.SelectedIndex > -1)
            {
                SetMappingType();
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            // csv
            //List<Person> records = new List<Person>();
            //{
            //    new Person { Id = 1, Name = "one" },
            //};



            // EuroJudo "Members & Clubs for Import.xls"
            string newFile = tscTournament.Text; // xls

            using (FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            {

                IWorkbook workbook = new HSSFWorkbook();

                ISheet sheet1 = workbook.CreateSheet("Sheet1");

                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
                int rowIndex = 0;
                IRow row = sheet1.CreateRow(rowIndex);
                row.Height = 30 * 80;
                row.CreateCell(0).SetCellValue("this is content");
                sheet1.AutoSizeColumn(0);
                rowIndex++;

                ISheet sheet2 = workbook.CreateSheet("Sheet2");
                ICellStyle style1 = workbook.CreateCellStyle();
                style1.FillForegroundColor = HSSFColor.Blue.Index2;
                style1.FillPattern = FillPattern.SolidForeground;

                ICellStyle style2 = workbook.CreateCellStyle();
                style2.FillForegroundColor = HSSFColor.Yellow.Index2;
                style2.FillPattern = FillPattern.SolidForeground;

                ICell cell2 = sheet2.CreateRow(0).CreateCell(0);
                cell2.CellStyle = style1;
                cell2.SetCellValue(0);

                cell2 = sheet2.CreateRow(1).CreateCell(0);
                cell2.CellStyle = style2;
                cell2.SetCellValue(1);

                workbook.Write(fs);
            }
        }

        private void cmbColumnNamesFromImportData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            switch (cmbEuroJudoMappingType.SelectedIndex)
            {
                case 0:
                    Properties.Settings.Default.LastEuroJudoEventTypeColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case 1:
                    Properties.Settings.Default.LastEuroJudoWeightCategoryColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case 2:
                    Properties.Settings.Default.LastEuroJudoClubColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
            }

            Properties.Settings.Default.Save();

            //GetEuroJudoComparisonData();

        }

        private void btnAutoSet_Click(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            switch (cmbEuroJudoMappingType.SelectedIndex)
            {
                case 0: // Event
                    MapValuesAutomatically(lstImportedColumnValues, lstEuroJudoComparisonValue, lvwMappingResults, EuroJudoMappingType.Event);
                    break;
                case 1: // Weight Category
                    MapValuesAutomatically(lstImportedColumnValues, lstEuroJudoComparisonValue, lvwMappingResults, EuroJudoMappingType.WeightCategory);
                    break;
                case 2: // Club
                    MapValuesAutomatically(lstImportedColumnValues, lstEuroJudoComparisonValue, lvwMappingResults, EuroJudoMappingType.Club);
                    break;
            }

            btnResetMappings.Enabled = lvwMappingResults.Items.Count > 0;
        }

        private void lvwMappingResults_DoubleClick(object sender, EventArgs e)
        {
            frmMapping MappingForm = null;
            ListViewItem SelectedItem = lvwMappingResults.SelectedItems[0];
            ComparisonResult Result = null;
            int SelectedItemIndex = lvwMappingResults.SelectedItems[0].Index;

            Debug.Print($"Inside {CurrentMethodName()}");

            MappingForm = new frmMapping((List<ComparisonResult>)SelectedItem.Tag);

            DialogResult FormResult = MappingForm.ShowDialog();

            //Debug.Print($"The User clicked {FormResult.ToString()}");

            if (FormResult == DialogResult.OK)
            {
                Result = MappingForm.SelectedComparisonResult;

                ListViewItem NewItem = null;

                switch (MappingForm.SelectedComparisonResult.MapType)
                {
                    case EuroJudoMappingType.Event:
                        NewItem = new ListViewItem(new string[] { Result.ValueString, ((EuroJudoEvent)(Result.Value)).Name, ((EuroJudoEvent)(Result.Value)).Index.ToString() });
                        break;
                    case EuroJudoMappingType.WeightCategory:
                        NewItem = new ListViewItem(new string[] { Result.ValueString, ((EuroJudoWeightCategory)(Result.Value)).Name, ((EuroJudoWeightCategory)(Result.Value)).Event.Index.ToString() });
                        break;
                    case EuroJudoMappingType.Club:
                        NewItem = new ListViewItem(new string[] { Result.ValueString, ((EuroJudoClub)(Result.Value)).ToString(), ((EuroJudoClub)(Result.Value)).Code });
                        break;
                }

                List<ComparisonResult> NewTag = new List<ComparisonResult>();
                NewTag.Add(MappingForm.SelectedComparisonResult);

                NewItem.Tag = NewTag;
                NewItem.BackColor = lvwMappingResults.BackColor;

                lvwMappingResults.Items.RemoveAt(SelectedItemIndex);
                lvwMappingResults.Items.Insert(SelectedItemIndex, NewItem);
            }
            else if (FormResult == DialogResult.Yes) // The user clicked "None"
            {
                lvwMappingResults.Items.RemoveAt(SelectedItemIndex);

                lstImportedColumnValues.Items.Add(MappingForm.ComparisonValue);
            }
            else // Cancel
            {
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOptions();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImportData(Reload: false);
        }

        private void btnResetMappings_Click(object sender, EventArgs e)
        {
            lvwMappingResults.Items.Clear();

            if (cmbEuroJudoMappingType.SelectedIndex > -1)
            {
                SetMappingType();
            }
        }

        private void BtnDeleteMapping_Click(object sender, EventArgs e)
        {

        }

        private void LvwMappingResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnResetMappings.Enabled = lvwMappingResults.SelectedItems.Count > 0;
        }

        private void btnManualSet_Click(object sender, EventArgs e)
        {
            List<int> SelectedIndices = new List<int>();
            foreach (var x in lstImportedColumnValues.SelectedIndices)
            {
                SelectedIndices.Add((int)x);
            }

            //for (int ColumnIndex = lstImportedColumnValues.SelectedIndex; ColumnIndex < lstImportedColumnValues.SelectedItems.Count; ColumnIndex++)
            for (int SelectedItemIndex = 0; SelectedItemIndex < SelectedIndices.Count; SelectedItemIndex++)
            {
                int ColumnIndex = SelectedIndices[SelectedItemIndex];
                List<ComparisonResult> ValueResults = new List<ComparisonResult>();
                string ColumnValue = (string)lstImportedColumnValues.SelectedItems[0]; // It's always 0 as we remove the previous item
                int EuroJudoValueIndex = lstEuroJudoComparisonValue.SelectedIndex;

                switch (cmbEuroJudoMappingType.SelectedIndex)
                {
                    case 0: // Event
                        //MapEvent(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, lstEuroJudoComparisonValue.SelectedItem.ToString(), EuroJudoValueIndex, true);
                        MapEvent(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true);
                        break;
                    case 1: // Weight Category
                        MapWeightCategory(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true);
                        break;
                    case 2: // Club
                        MapClub(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true);
                        break;
                }

                if (ValueResults.Count > 0)
                {
                    switch (cmbEuroJudoMappingType.SelectedIndex)
                    {
                        case 0:
                            AddEuroJudoComparisonResults(ColumnValue: ColumnValue, ColumnIndex: ColumnIndex, Results: ValueResults, MinimumComparisonResult: Properties.Settings.Default.EuroJudoEventValueMinimumComparison, EuroJudoMappingType.Event);
                            break;
                        case 1:
                            AddEuroJudoComparisonResults(ColumnValue: ColumnValue, ColumnIndex: ColumnIndex, Results: ValueResults, MinimumComparisonResult: Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, EuroJudoMappingType.WeightCategory);
                            break;
                        case 2:
                            AddEuroJudoComparisonResults(ColumnValue: ColumnValue, ColumnIndex: ColumnIndex, Results: ValueResults, MinimumComparisonResult: Properties.Settings.Default.EuroJudoClubValueMinimumComparison, EuroJudoMappingType.Club);
                            break;
                    }

                    //SelectedItemIndex--;
                }
            }

            btnResetMappings.Enabled = lvwMappingResults.Items.Count > 0;
        }

        private void lstImportedColumnValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableSetButton();
        }

        private void lstEuroJudoComparisonValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableSetButton();
        }

        #endregion

        #region Private Methods

        private void DoStartup()
        {
            string CountriesFilename = Properties.Settings.Default.EuroJudoCountriesFilename.Trim();
            string SubDivisionsFilename = Properties.Settings.Default.EuroJudoSubDivisionsFilename.Trim();
            string TournamentFilename = Properties.Settings.Default.EuroJudoDatabaseFilename.Trim();
            string ClubsFilename = Properties.Settings.Default.EuroJudoClubsFilename.Trim();

            Countries = new List<EuroJudoCountry>();
            SubDivisions = new List<EuroJudoSubDivision>();
            EuroJudoClubs = new List<EuroJudoClub>();
            EuroJudoEvents = new List<EuroJudoEvent>();
            EuroJudoWeightCategories = new List<EuroJudoWeightCategory>();
            
            lvwMappingResults.Items.Clear();

            InitialLoadComplete = false;

            if (CountriesFilename.Length > 0)
            {
                // This requires filepaths to be defined
                Countries = GetCountries(CountriesFilename);

                if (SubDivisionsFilename.Length > 0)
                {
                    // SubDivisions needs Countries to be loaded first
                    SubDivisions = GetSubDivisions(SubDivisionsFilename);

                    if (TournamentFilename.Length > 0)
                    {
                        EuroJudoTournaments = GetEuroJudoTournaments(tscTournament, TournamentFilename, Properties.Settings.Default.EuroJudoTournamentQuery);

                        if (ClubsFilename.Length > 0)
                        {
                            EuroJudoClubs = GetEuroJudoClubs(ClubsFilename);

                            // This requires the Tournaments to be loaded
                            if (Properties.Settings.Default.LastEuroJudoTournament.Trim().Length > 0 && tscTournament.Items.Contains(EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament)))
                            {
                                tscTournament.SelectedItem = EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament);
                            }

                            InitialLoadComplete = true;
                        }
                        else
                        {
                            tslblMain.Text = "Clubs filename is blank";
                        }
                    }
                    else
                    {
                        tslblMain.Text = "Tournaments filename is blank";
                    }
                }
                else
                {
                    tslblMain.Text = "Sub Divisions filename is blank";
                }
            }
            else
            {
                tslblMain.Text = "Countries filename is blank";
            }

            loadToolStripMenuItem.Enabled = InitialLoadComplete;
        }

        private void DoOptions()
        {
            frmOptions OptionsForm = new frmOptions();

            DialogResult Result = OptionsForm.ShowDialog();

            if (Result == DialogResult.OK)
            {
                if (TournamentLoaded)
                {
                    MessageBox.Show("The application must now restart.\r\nThis behaviour will change in a future version.");
                    Application.Restart();
                }

                //DoStartup();

                //if (InitialLoadComplete)
                //{
                //    if (TournamentLoaded)
                //    {
                //        TournamentLoaded = false;

                //        cmbEuroJudoMappingType.Items.Clear();

                //        tabExportType.Enabled = false;
                //        tabExportType.SelectedIndex = 0;

                //        LoadImportData(Reload: true);

                //        TournamentLoaded = true;
                //    }
                //}
            }
        }

        private void LoadImportData(bool Reload)
        {
            Cursor.Current = Cursors.WaitCursor;
            DialogResult Result = DialogResult.None;
            frmImport ImportForm = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            if (Reload)
            {
                Result = DialogResult.OK;
            }
            else
            {
                ImportForm = new frmImport(Properties.Settings.Default.ImportFilename);

                Result = ImportForm.ShowDialog();

                Properties.Settings.Default.ImportFilename = ImportForm.ImportFilename;
            }

            if (Result == DialogResult.OK)
            {
                LoadCSVDataSource(Properties.Settings.Default.ImportFilename, ref RevolutioniseSourceData);

                //SourceValueGrid.DataSource = RevolutioniseSourceData;

                //SourceValueGrid.AutoResizeColumns();


                //EuroJudoTournaments = GetEuroJudoTournaments(tscTournament, Properties.Settings.Default.EuroJudoTournamentQuery);

                //// This requires filepaths to be defined
                //Countries = GetCountries(Properties.Settings.Default.EuroJudoCountriesFilename);

                //// SubDivisions needs Countries to be loaded first
                //SubDivisions = GetSubDivisions(Properties.Settings.Default.EuroJudoSubDivisionsFilename);

                //EuroJudoTournaments = GetEuroJudoTournaments(tscTournament, Properties.Settings.Default.EuroJudoTournamentQuery);

                //EuroJudoClubs = GetEuroJudoClubs(Properties.Settings.Default.EuroJudoClubsFilename);

                //// This requires the Tournaments to be loaded
                //if (Properties.Settings.Default.LastEuroJudoTournament.Trim().Length > 0 && tscTournament.Items.Contains(EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament)))
                //{
                //    tscTournament.SelectedItem = EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament);
                //}

                GetSourceColumnNames(RevolutioniseSourceData, cmbColumnNamesFromImportData, lstImportedColumnValues);

                if (cmbEuroJudoMappingType.Items.Count > 0)
                {
                    cmbEuroJudoMappingType.SelectedIndex = 0;
                }

                tabExportType.Enabled = true;

                TournamentLoaded = true;

            }

            Cursor.Current = Cursors.Default;
        }

        private void LoadCSVDataSource(string Filename, ref DataTable TargetDataSource)
        {
            string[] SplitCharacters = new string[] { Properties.Settings.Default.LastImportDelimiter };
            List<string> RowsToIgnore = null;
            string ResultText = "";

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Removing existing data...";

            this.Refresh();

            if (Properties.Settings.Default.RemoveTotalRowFromImport)
            {
                RowsToIgnore = new List<string> { "Total" };
            }
            else
            {
                RowsToIgnore = new List<string>();
            }

            tslblMain.Text = "Loading data...";
            this.Refresh();

            TargetDataSource.BeginLoadData();
            (ResultText, TargetDataSource) = Utilities.Data.GetCSVData(Filename, SplitCharacters, Properties.Settings.Default.ImportFileHasHeaders, RowsToIgnore, "ImportFile");
            TargetDataSource.EndLoadData();

            tslblMain.Text = ResultText;
            this.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void ClearValues()
        {
            //cmbEuroJudoMappingType.Items.Clear();
            //cmbColumnNamesFromImportData.Items.Clear();
            //lvwMappingResults.Items.Clear();

            GetSourceColumnNames(RevolutioniseSourceData, cmbColumnNamesFromImportData, lstImportedColumnValues);

            if (cmbEuroJudoMappingType.Items.Count > 0)
            {
                cmbEuroJudoMappingType.SelectedIndex = 0;
            }
        }

        private void SetMappingType()
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            if (cmbEuroJudoMappingType.SelectedIndex == -1)
            {
                Debug.Print($"...Leaving {CurrentMethodName()}");
                return;
            }

            btnPreviousMappingType.Enabled = !(cmbEuroJudoMappingType.SelectedIndex == 0);
            btnNextMappingType.Enabled = !(cmbEuroJudoMappingType.SelectedIndex == cmbEuroJudoMappingType.Items.Count - 1);

            lstImportedColumnValues.Items.Clear();
            lstEuroJudoComparisonValue.Items.Clear();
            lvwMappingResults.Items.Clear();

            lblMappingTypeHint.Text = "Step " + (cmbEuroJudoMappingType.SelectedIndex + 1).ToString() + " of " + cmbEuroJudoMappingType.Items.Count.ToString();

            switch (cmbEuroJudoMappingType.SelectedIndex)
            {
                case 0: // Event
                    lblMinComparisonValue.Text = Properties.Settings.Default.EuroJudoEventValueMinimumComparison + " %";
                    if (Properties.Settings.Default.LastEuroJudoEventTypeColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoEventTypeColumnIndex)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoEventTypeColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }
                    break;
                case 1: // Weight Category
                    lblMinComparisonValue.Text = Properties.Settings.Default.EuroJudoWeightValueMinimumComparison + " %";
                    if (Properties.Settings.Default.LastEuroJudoWeightCategoryColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoWeightCategoryColumnIndex)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoWeightCategoryColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }
                    break;
                case 2: // Club
                    lblMinComparisonValue.Text = Properties.Settings.Default.EuroJudoClubValueMinimumComparison + " %";
                    if (Properties.Settings.Default.LastEuroJudoClubColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoClubColumnIndex)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoClubColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }
                    break;
            }

            GetEuroJudoComparisonData();
        }

        private void GetSourceColumnNames(DataTable DataSource, ComboBox Combobox, ListBox Listbox)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            Combobox.Items.Clear();

            Debug.Print($"...Adding items to Combobox: {Combobox.Name} from {DataSource.TableName}");
            foreach (DataColumn column in DataSource.Columns)
            {
                Combobox.Items.Add(column.ColumnName);
            }

            Listbox.Items.Clear();
        }

        private void GetSourceColumnValues(DataTable DataSource, int ImportFileColumnIndex, ListBox Listbox)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            //DataTable SourceData = (DataTable)SourceValueGrid.DataSource;
            //string SelectedColumnName = Combobox.Text;
            //int SelectedColumnIndex = Combobox.SelectedIndex;

            Debug.Print($"...Loading data from Import file column {ImportFileColumnIndex}");

            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading...";
            this.Refresh();

            Listbox.SuspendDrawing();
            Listbox.Items.Clear(); //lstImportedColumnValues

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataSource.Rows.Count;

            Debug.Print($"...Adding items to Listbox: {Listbox.Name}");
            if (ImportFileColumnIndex > -1)
            {
                foreach (DataRow Row in DataSource.Rows)
                {
                    pbrAuto.Value++;
                    pbrAuto.Refresh();

                    if (!Listbox.Items.Contains(Row.ItemArray[ImportFileColumnIndex]))
                    {
                        Listbox.Items.Add(Row.ItemArray[ImportFileColumnIndex].ToString());
                    }
                }
            }

            pbrAuto.Value = 0;
            tslblMain.Text = $"Load complete: {DataSource.Rows.Count} rows loaded";
            Listbox.ResumeDrawing();
            this.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private List<EuroJudoTournament> GetEuroJudoTournaments(ComboBox Combobox, string Filename, string Query)
        {
            DataTable DataResult = null;
            string TextResult = "";
            List<EuroJudoTournament> Result = new List<EuroJudoTournament>();

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading data...";
            this.Refresh();

            Combobox.Items.Clear();

            (TextResult, DataResult) = Utilities.Data.GetAccessData(Filename, Query, "EuroJudo_Tournaments");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;

            foreach (DataRow Row in DataResult.Rows)
            {
                pbrAuto.Value++;
                int Index = Convert.ToInt32(Row.ItemArray[0].ToString());
                string Name = (string)(Row.ItemArray[1].ToString());
                EuroJudoTournament ThisTournament = new EuroJudoTournament(Index, Name);

                Combobox.Items.Add(ThisTournament);

                Result.Add(ThisTournament);
            }

            pbrAuto.Value = 0;
            tslblMain.Text = TextResult;
            this.Refresh();
            Cursor.Current = Cursors.Default;

            return Result;
        }

        private DataTable GetEuroJudoData(string Query, string Filename, EuroJudoMappingType MappingType)
        {
            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading...";
            this.Refresh();

            Debug.Print($"Inside {CurrentMethodName()}");

            DataTable DataResult = null;
            string TextResult = "";

            switch (MappingType)
            {
                case EuroJudoMappingType.Event:
                    (TextResult, DataResult) = Utilities.Data.GetAccessData(Filename, Query, "EuroJudo_Events");
                    break;
                case EuroJudoMappingType.WeightCategory:
                    (TextResult, DataResult) = Utilities.Data.GetAccessData(Filename, Query, "EuroJudo_WeightCategories");
                    break;
                case EuroJudoMappingType.Club:
                    {
                        TextResult = "Clubs previously loaded";
                        DataResult = null;

                        //string[] SplitCharacters = new string[] { cmbSplitCharacters.Text };
                        //List<string> RowsToIgnore = null;

                        //if (chkRemoveTotalRow.Checked)
                        //{
                        //    RowsToIgnore = new List<string> { "Total" };
                        //}
                        //else
                        //{
                        //    RowsToIgnore = new List<string>();
                        //}

                        //(TextResult, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, chkImportHasHeaders.Checked, RowsToIgnore);
                    }
                    break;
            }

            pbrAuto.Value = 0;
            tslblMain.Text = TextResult;
            this.Refresh();
            Cursor.Current = Cursors.Default;

            return DataResult;
        }

        private void FillListboxWithData(DataTable DataResult, ListBox Listbox, EuroJudoMappingType MappingType)
        {
            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading...";
            this.Refresh();

            Debug.Print($"Inside {CurrentMethodName()}");

            string TextResult = "";
            object NewInstance = null;

            Listbox.Items.Clear();
            Listbox.Refresh();
            Listbox.SuspendDrawing();

            pbrAuto.Minimum = 0;

            switch (MappingType)
            {
                case EuroJudoMappingType.Event:
                    {
                        if (DataResult != null)
                        {
                            pbrAuto.Maximum = DataResult.Rows.Count;

                            foreach (DataRow Row in DataResult.Rows)
                            {
                                int Number = Convert.ToInt32(Row.ItemArray[0].ToString());
                                Sex sex = (Sex)Enum.Parse(typeof(Sex), (string)(Row.ItemArray[1].ToString()));
                                string Name = (string)(Row.ItemArray[2].ToString());

                                pbrAuto.Value++;

                                NewInstance = new EuroJudoEvent(Listbox.Items.Count, Number, Name, sex);

                                Listbox.Items.Add(NewInstance);

                                EuroJudoEvents.Add((EuroJudoEvent)NewInstance);
                            }
                        }
                    }
                    break;
                case EuroJudoMappingType.WeightCategory:
                    {
                        if (DataResult != null)
                        {
                            pbrAuto.Maximum = DataResult.Rows.Count;

                            foreach (DataRow Row in DataResult.Rows)
                            {
                                int ClassNumber = Convert.ToInt32(Row.ItemArray[0].ToString());
                                string EventName = Row.ItemArray[1].ToString();
                                string Name = (string)(Row.ItemArray[2].ToString());

                                pbrAuto.Value++;

                                if (EuroJudoEvents.Count > 0)
                                {
                                    NewInstance = new EuroJudoWeightCategory(ClassNumber, EuroJudoEvents.Find(n => n.Name == EventName), Name);
                                }
                                else
                                {
                                    NewInstance = new EuroJudoWeightCategory(ClassNumber, null, EventName + " " + Name);
                                }

                                Listbox.Items.Add(NewInstance);
                            }
                        }
                    }
                    break;
                case EuroJudoMappingType.Club:
                    {
                        pbrAuto.Maximum = EuroJudoClubs.Count;

                        // Clubs have already been loaded
                        foreach (EuroJudoClub Club in EuroJudoClubs)
                        {
                            pbrAuto.Value++;

                            Listbox.Items.Add(Club);
                        }
                    }
                    break;
            }

            pbrAuto.Value = 0;
            Listbox.ResumeDrawing();
            tslblMain.Text = TextResult;
            this.Refresh();
            Cursor.Current = Cursors.Default;

        }

        private void AddEuroJudoComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, EuroJudoMappingType MapType)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            switch (MapType)
            {
                case EuroJudoMappingType.Event:
                    AddEuroJudoEventComparisonResults(ColumnValue, ColumnIndex, Results, MinimumComparisonResult);
                    break;
                case EuroJudoMappingType.WeightCategory:
                    AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex, Results, MinimumComparisonResult);
                    break;
                case EuroJudoMappingType.Club:
                    AddEuroJudoClubComparisonResults(ColumnValue, ColumnIndex, Results, MinimumComparisonResult);
                    break;
            }

        }

        private void AddEuroJudoEventComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult)
        {
            List<StringToObjectMapping<EuroJudoEvent>> Mappings = new List<StringToObjectMapping<EuroJudoEvent>>();
            ListViewItem NewItem = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<EuroJudoEvent> ThisMapping = new StringToObjectMapping<EuroJudoEvent>(Result.ValueString, Result.ValueIndex, (EuroJudoEvent)Result.Value);
                Mappings.Add(ThisMapping);
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    EuroJudoEvent ThisEvent = (EuroJudoEvent)(TopResults[0].Value);

                    NewItem = new ListViewItem(new string[] { ColumnValue, ThisEvent.Name });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = lvwMappingResults.BackColor;
                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);
                //lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
                lstImportedColumnValues.Items.Remove(ColumnValue);
            }
        }

        private void AddEuroJudoWeightCategoryComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult)
        {
            List<StringToObjectMapping<EuroJudoWeightCategory>> Mappings = new List<StringToObjectMapping<EuroJudoWeightCategory>>();
            ListViewItem NewItem = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<EuroJudoWeightCategory> ThisMapping = new StringToObjectMapping<EuroJudoWeightCategory>(Result.ValueString, Result.ValueIndex, (EuroJudoWeightCategory)Result.Value);
                Mappings.Add(ThisMapping);
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    EuroJudoWeightCategory ThisWeightCategory = (EuroJudoWeightCategory)(TopResults[0].Value);

                    if (ThisWeightCategory.Event == null)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisWeightCategory.Name });
                    }
                    else
                    {
                        string WeightCategoryEventName = ThisWeightCategory.Event.Name;
                        string WeightCategoryName = ThisWeightCategory.ToString();

                        NewItem = new ListViewItem(new string[] { ColumnValue, WeightCategoryName });
                    }

                    NewItem.Tag = TopResults;
                    NewItem.BackColor = lvwMappingResults.BackColor;
                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);
                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoClubComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult)
        {
            List<StringToObjectMapping<EuroJudoClub>> Mappings = new List<StringToObjectMapping<EuroJudoClub>>();
            ListViewItem NewItem = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<EuroJudoClub> ThisMapping = new StringToObjectMapping<EuroJudoClub>(Result.ValueString, Result.ValueIndex, (EuroJudoClub)Result.Value);
                Mappings.Add(ThisMapping);
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    EuroJudoClub ThisClub = (EuroJudoClub)(TopResults[0].Value);

                    NewItem = new ListViewItem(new string[] { ColumnValue, ThisClub.Name });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = lvwMappingResults.BackColor;
                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void GetEuroJudoComparisonData()
        {
            DataTable Results = new DataTable();

            Debug.Print($"Inside {CurrentMethodName()}");

            if (RevolutioniseSourceData != null && RevolutioniseSourceData.Rows.Count > 0)
            {
                int SelectedColumnIndex = cmbColumnNamesFromImportData.SelectedIndex; // cmbEuroJudoMappingType.SelectedIndex; // cmbImportedColumnNames.SelectedIndex; 
                string SelectedJudoTournamentIndex = SelectedEuroJudoTournament.Index.ToString();
                string DbQuery = "";
                string Filename = Properties.Settings.Default.EuroJudoDatabaseFilename;

                Debug.Print($"...Using ColumnIndex from ComboBox 'cmbColumnNamesFromImportData'");
                GetSourceColumnValues(RevolutioniseSourceData, SelectedColumnIndex, lstImportedColumnValues);

                switch (cmbEuroJudoMappingType.SelectedIndex)
                {
                    case 0: // Event
                        DbQuery = Properties.Settings.Default.EuroJudoEventQuery.Replace("##SelectedEuroJudoTournament_Index##", SelectedJudoTournamentIndex);
                        Results = GetEuroJudoData(DbQuery, Filename, EuroJudoMappingType.Event);

                        FillListboxWithData(Results, lstEuroJudoComparisonValue, EuroJudoMappingType.Event);

                        break;
                    case 1: // Weight Category
                        DbQuery = Properties.Settings.Default.EuroJudoWeightQuery.Replace("##SelectedEuroJudoTournament_Index##", SelectedJudoTournamentIndex);
                        Results = GetEuroJudoData(DbQuery, Filename, EuroJudoMappingType.WeightCategory);

                        FillListboxWithData(Results, lstEuroJudoComparisonValue, EuroJudoMappingType.WeightCategory);

                        break;
                    case 2: // Club
                            // Clubs have already been loaded

                        FillListboxWithData(Results, lstEuroJudoComparisonValue, EuroJudoMappingType.Club);

                        break;
                }
            }
        }

        private List<EuroJudoCountry> GetCountries(string Filename)
        {
            List<EuroJudoCountry> Result = new List<EuroJudoCountry>();
            string[] SplitCharacters = new string[] { "," };
            List<string> RowsToIgnore = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading Countries...";
            this.Refresh();

            DataTable DataResult = null;
            string TextResult = "";

            (TextResult, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "Clubs");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;
            tslblMain.Text = TextResult;

            foreach (DataRow Row in DataResult.Rows)
            {
                string Name = Row.ItemArray[0].ToString();
                string Alpha2 = Row.ItemArray[1].ToString();
                string Alpha3 = Row.ItemArray[2].ToString();
                EuroJudoCountry NewCountry = new EuroJudoCountry(Name, Alpha2, Alpha3);
                Result.Add(NewCountry);

                pbrAuto.Value++;
            }

            pbrAuto.Value = 0;
            tslblMain.Text = $"{Result.Count} Countries loaded";
            this.Refresh();
            Cursor.Current = Cursors.Default;

            return Result;
        }

        private List<EuroJudoSubDivision> GetSubDivisions(string Filename)
        {
            List<EuroJudoSubDivision> Result = new List<EuroJudoSubDivision>();
            string[] SplitCharacters = new string[] { "," };
            List<string> RowsToIgnore = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading SubDivisions...";
            this.Refresh();

            DataTable DataResult = null;
            string TextResult = "";

            (TextResult, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "SubDivisions");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;
            tslblMain.Text = TextResult;

            foreach (DataRow Row in DataResult.Rows)
            {
                string CountryName = Row.ItemArray[0].ToString();
                string Code = Row.ItemArray[1].ToString();
                string Name = Row.ItemArray[2].ToString();
                string Type = Row.ItemArray[3].ToString();
                EuroJudoCountry Country = Countries.Find(c => Code.StartsWith(c.Alpha2Code));

                EuroJudoSubDivision NewSubDivision = new EuroJudoSubDivision(Name, Code, Country);
                Result.Add(NewSubDivision);

                pbrAuto.Value++;
            }

            pbrAuto.Value = 0;
            tslblMain.Text = $"{Result.Count} SubDivisions loaded";
            this.Refresh();
            Cursor.Current = Cursors.Default;
            return Result;
        }

        private List<EuroJudoClub> GetEuroJudoClubs(string Filename)
        {
            List<EuroJudoClub> Result = new List<EuroJudoClub>();
            string[] SplitCharacters = new string[] { "," };
            List<string> RowsToIgnore = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading Clubs...";
            this.Refresh();

            DataTable DataResult = null;
            string TextResult = "";

            (TextResult, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "Clubs");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;
            tslblMain.Text = TextResult;

            foreach (DataRow Row in DataResult.Rows)
            {
                string Name = Row.ItemArray[0].ToString();
                string CountryCode = Row.ItemArray[1].ToString();
                string SubDivisionCode = Row.ItemArray[2].ToString();
                string Code = Row.ItemArray[3].ToString();
                EuroJudoCountry Country = Countries.Find(c => c.Alpha2Code == CountryCode);
                EuroJudoSubDivision SubDivision = SubDivisions.Find(s => s.Code == Country.Alpha2Code + "-" + SubDivisionCode);
                EuroJudoLocation Location = new EuroJudoLocation(Country, SubDivision);

                EuroJudoClub NewClub = new EuroJudoClub(Name, Code, Location);
                Result.Add(NewClub);

                pbrAuto.Value++;
            }

            pbrAuto.Value = 0;
            tslblMain.Text = $"{Result.Count} Clubs loaded";
            this.Refresh();
            Cursor.Current = Cursors.Default;

            return Result;
        }

        private void MapValuesAutomatically(ListBox ImportedColumnValuesListbox, ListBox EuroJudoValuesListbox, ListView MappingListview, EuroJudoMappingType MapType)
        {
            Color Colour = MappingListview.BackColor;

            Debug.Print($"Inside {CurrentMethodName()}");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = ImportedColumnValuesListbox.Items.Count * EuroJudoValuesListbox.Items.Count;

            for (int ColumnIndex = 0; ColumnIndex < ImportedColumnValuesListbox.Items.Count; ColumnIndex++)
            {
                List<ComparisonResult> ValueResults = new List<ComparisonResult>();

                string ColumnValue = (string)ImportedColumnValuesListbox.Items[ColumnIndex];

                for (int EuroJudoValueIndex = 0; EuroJudoValueIndex < EuroJudoValuesListbox.Items.Count; EuroJudoValueIndex++)
                {
                    pbrAuto.Value++;

                    switch (MapType)
                    {
                        case EuroJudoMappingType.Event:
                            {
                                MapEvent(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false);
                                break;
                            }
                        case EuroJudoMappingType.WeightCategory:
                            {
                                MapWeightCategory(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false);
                                break;
                            }
                        case EuroJudoMappingType.Club:
                            {
                                MapClub(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false);
                                break;
                            }
                    }
                }

                if (ValueResults.Count > 0)
                {
                    switch (MapType)
                    {
                        case EuroJudoMappingType.Event:
                            AddEuroJudoComparisonResults(ColumnValue: ColumnValue, ColumnIndex: ColumnIndex, Results: ValueResults, MinimumComparisonResult: Properties.Settings.Default.EuroJudoEventValueMinimumComparison, EuroJudoMappingType.Event);
                            break;
                        case EuroJudoMappingType.WeightCategory:
                            AddEuroJudoComparisonResults(ColumnValue: ColumnValue, ColumnIndex: ColumnIndex, Results: ValueResults, MinimumComparisonResult: Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, EuroJudoMappingType.WeightCategory);
                            break;
                        case EuroJudoMappingType.Club:
                            AddEuroJudoComparisonResults(ColumnValue: ColumnValue, ColumnIndex: ColumnIndex, Results: ValueResults, MinimumComparisonResult: Properties.Settings.Default.EuroJudoClubValueMinimumComparison, EuroJudoMappingType.Club);
                            break;
                    }

                    ColumnIndex--;
                }
            }

            pbrAuto.Value = 0;
            tslblMain.Text = "Auto mapping complete";
        }

        private EuroJudoEvent MapEvent(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int EventIndex, bool Manual)
        {
            EuroJudoEvent NewInstance = (EuroJudoEvent)DatabaseValuesListbox.Items[EventIndex];
            double CommonResult = 0;

            tslblMain.Text = $"Comparing {ColumnValue} with {((EuroJudoEvent)NewInstance).Name}";
            ssMain.Refresh();

            CommonResult = ((EuroJudoEvent)NewInstance).Name.CompareWith(ColumnValue);

            if (CommonResult > Properties.Settings.Default.EuroJudoEventValueMinimumComparison || Manual) //)
            {
                ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, ((EuroJudoEvent)NewInstance).Name, CommonResult, EuroJudoMappingType.Event, (EuroJudoEvent)NewInstance, Manual));
            }

            return NewInstance;
        }

        private EuroJudoWeightCategory MapWeightCategory(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int EventIndex, bool Manual)
        {
            EuroJudoWeightCategory NewInstance = (EuroJudoWeightCategory)DatabaseValuesListbox.Items[EventIndex];
            double CommonResult = 0;

            tslblMain.Text = $"Comparing {ColumnValue} with {((EuroJudoWeightCategory)NewInstance).Name}";
            ssMain.Refresh();

            string WeightCategory = ColumnValue;
            foreach (string Replacement in Properties.Settings.Default.EuroJudoWeightCategoryOverReplacement)
            {
                WeightCategory = WeightCategory.Replace(Replacement, Properties.Settings.Default.EuroJudoWeightCategoryOverValue);
            }

            foreach (string Replacement in Properties.Settings.Default.EuroJudoWeightCategoryUnderReplacement)
            {
                WeightCategory = WeightCategory.Replace(Replacement, Properties.Settings.Default.EuroJudoWeightCategoryUnderValue);
            }

            if (NewInstance.Event != null)
            {
                string NewInstanceEventName = ((EuroJudoWeightCategory)NewInstance).Event.Name;
                string NewInstanceName = ((EuroJudoWeightCategory)NewInstance).ToString();
                CommonResult = NewInstanceName.CompareWith(WeightCategory);
            }
            else
            {
                CommonResult = ((EuroJudoWeightCategory)NewInstance).Name.CompareWith(WeightCategory);
            }

            if (CommonResult > Properties.Settings.Default.EuroJudoWeightValueMinimumComparison || Manual)
            {
                ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, ((EuroJudoWeightCategory)NewInstance).Name, CommonResult, EuroJudoMappingType.WeightCategory, (EuroJudoWeightCategory)NewInstance, Manual));
            }

            return NewInstance;
        }

        private EuroJudoClub MapClub(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int EventIndex, bool Manual)
        {
            EuroJudoClub NewInstance = (EuroJudoClub)DatabaseValuesListbox.Items[EventIndex];
            double CommonResult = 0;

            tslblMain.Text = $"Comparing {ColumnValue} with {((EuroJudoClub)NewInstance).Name}";
            ssMain.Refresh();

            CommonResult = ((EuroJudoClub)NewInstance).Name.CompareWith(ColumnValue);

            if (CommonResult > Properties.Settings.Default.EuroJudoClubValueMinimumComparison || Manual)
            {
                ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, ((EuroJudoClub)NewInstance).Name, CommonResult, EuroJudoMappingType.Club, (EuroJudoClub)NewInstance, Manual));
            }

            return NewInstance;
        }

        private void EnableDisableSetButton()
        {
            btnManualSet.Enabled = (lstImportedColumnValues.SelectedIndices.Count > 0 && lstEuroJudoComparisonValue.SelectedIndices.Count == 1);
        }



        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace



        #endregion

        #region Deprecated

        //private void lvwEventMappings_DoubleClick(object sender, EventArgs e)
        //{
        //    MessageBox.Show("You clicked " + lvwEventMappings.SelectedItems[0].Text);
        //}

        //private void GetEuroJudoEvents()
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    tslblMain.Text = "Loading Events...";
        //    this.Refresh();

        //    DataTable DataResult = null;
        //    string TextResult = "";

        //    //SELECT [Event Nr], Genus, Event FROM [Tournament Data] WHERE [Game Index] = {SelectedEuroJudoTournament.Index} ORDER BY [Event Nr]
        //    string Query = Properties.Settings.Default.EuroJudoEventQuery.Replace("##SelectedEuroJudoTournament_Index##", SelectedEuroJudoTournament.Index.ToString());

        //    (TextResult, DataResult) = Utilities.Data.GetAccessData(txtEuroJudoDatabaseFilename.Text, Query);

        //    lstEuroJudoEvents.Items.Clear();

        //    foreach (DataRow Row in DataResult.Rows)
        //    {
        //        int Number = Convert.ToInt32(Row.ItemArray[0].ToString());
        //        Sex sex = (Sex)Enum.Parse(typeof(Sex), (string)(Row.ItemArray[1].ToString()));
        //        string Name = (string)(Row.ItemArray[2].ToString());

        //        EuroJudoEvent ThisEvent = new EuroJudoEvent(lstEuroJudoEvents.Items.Count, Number, Name, sex);

        //        EuroJudoEvents.Add(ThisEvent);
        //        lstEuroJudoEvents.Items.Add(ThisEvent);
        //    }

        //    tslblMain.Text = TextResult;
        //    this.Refresh();
        //    Cursor.Current = Cursors.Default;
        //}

        //private void GetEuroJudoWeights()
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    tslblMain.Text = "Loading Weight categories...";
        //    this.Refresh();

        //    DataTable DataResult = null;
        //    string TextResult = "";
        //    // $"SELECT `Class Nr`, Event, `Weight Category` FROM `Weight Categories` WHERE `Game Index` = {SelectedEuroJudoTournament.Index} ORDER BY `Class Nr`"
        //    string Query = Properties.Settings.Default.EuroJudoWeightQuery.Replace("##SelectedEuroJudoTournament_Index##", SelectedEuroJudoTournament.Index.ToString());

        //    (TextResult, DataResult) = Utilities.Data.GetAccessData(txtEuroJudoDatabaseFilename.Text, Query);

        //    lstEuroJudoWeights.Items.Clear();

        //    foreach (DataRow Row in DataResult.Rows)
        //    {
        //        int ClassNumber = Convert.ToInt32(Row.ItemArray[0].ToString());
        //        string EventName = Row.ItemArray[1].ToString();
        //        string Name = (string)(Row.ItemArray[2].ToString());

        //        EuroJudoWeightCategory ThisCategory = new EuroJudoWeightCategory(ClassNumber, EuroJudoEvents.Find(n => n.Name == EventName), Name);

        //        lstEuroJudoWeights.Items.Add(ThisCategory);
        //    }

        //    tslblMain.Text = TextResult;
        //    this.Refresh();
        //    Cursor.Current = Cursors.Default;
        //}

        //private void GetEuroJudoClubs(string Filename, ListBox Listbox, ref DataTable Datasource)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    tslblMain.Text = "Loading Clubs...";
        //    this.Refresh();

        //    LoadCSVDataSource(txtEuroJudoClubsFilename.Text, ref ClubSourceData);

        //    lstEuroJudoClubs.Items.Clear();

        //    foreach (DataRow Row in ClubSourceData.Rows)
        //    {
        //        string Name = (string)(Row.ItemArray[0].ToString());
        //        string Country = (string)(Row.ItemArray[1].ToString());
        //        string SubDivision = (string)(Row.ItemArray[2].ToString());
        //        string Code = (string)(Row.ItemArray[3].ToString());

        //        EuroJudoClub ThisClub = new EuroJudoClub(Name, Code, null); // JudoClubs.Find(n => n.Name == Club.Name));

        //        lstEuroJudoClubs.Items.Add(ThisClub);
        //    }

        //    tslblMain.Text = $"Load complete: {ClubSourceData.Rows.Count} rows loaded";
        //    this.Refresh();
        //    Cursor.Current = Cursors.Default;
        //}

        //private void AddEuroJudoEventMapping(bool RemoveSourceValue, string SourceValue, int SourceIndex, EuroJudoEvent SelectedEvent, Color Colour)
        //{
        //    StringToEuroJudoEventMapping ThisMapping = new StringToEuroJudoEventMapping(SourceValue, SourceIndex, SelectedEvent);
        //    ListViewItem NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ThisMapping.DestinationEvent.Name, ThisMapping.DestinationEvent.Number.ToString() });
        //    NewItem.Tag = ThisMapping;
        //    NewItem.BackColor = Colour;

        //    lvwEventMappings.Items.Add(NewItem);
        //    EventMappings.Add(ThisMapping);

        //    if (RemoveSourceValue)
        //    {
        //        lstColumnValuesForEvents.Items.RemoveAt(SourceIndex);
        //    }

        //}

        //private void AddEuroJudoWeightMapping(bool RemoveSourceValue, string SourceValue, int SourceIndex, EuroJudoWeightCategory SelectedWeight, Color Colour)
        //{
        //    StringToEuroJudoWeightMapping ThisMapping = new StringToEuroJudoWeightMapping(SourceValue, SourceIndex, SelectedWeight);
        //    ListViewItem NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ThisMapping.DestinationCategory.ToString(), ThisMapping.DestinationCategory.Event.Number.ToString(), ThisMapping.DestinationCategory.ClassNumber.ToString() });
        //    NewItem.Tag = ThisMapping;
        //    NewItem.BackColor = Colour;

        //    lvwWeightMappings.Items.Add(NewItem);
        //    WeightCategoryMappings.Add(ThisMapping);

        //    if (RemoveSourceValue)
        //    {
        //        lstColumnValuesForWeights.Items.RemoveAt(SourceIndex);
        //    }

        //}

        //private void AddEuroJudoClubMapping(bool RemoveSourceValue, string SourceValue, int SourceIndex, EuroJudoClub SelectedClub, Color Colour)
        //{
        //    StringToEuroJudoClubMapping ThisMapping = new StringToEuroJudoClubMapping(SourceValue, SourceIndex, SelectedClub);
        //    ListViewItem NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ThisMapping.DestinationClub.Name, ThisMapping.DestinationClub.Code.ToString() });
        //    NewItem.Tag = ThisMapping;
        //    NewItem.BackColor = Colour;

        //    lvwClubMappings.Items.Add(NewItem);
        //    ClubMappings.Add(ThisMapping);

        //    if (RemoveSourceValue)
        //    {
        //        lstColumnValuesForClubs.Items.RemoveAt(SourceIndex);
        //    }

        //}

        //private void DeleteEventMapping()
        //{
        //    List<StringToEuroJudoEventMapping> SelectedMaps = new List<StringToEuroJudoEventMapping>();

        //    foreach (ListViewItem MapEntry in lvwEventMappings.SelectedItems)
        //    {
        //        StringToEuroJudoEventMapping ThisMapping = (StringToEuroJudoEventMapping)(MapEntry.Tag);

        //        SelectedMaps.Add(ThisMapping);

        //        lstColumnValuesForEvents.Items.Add(ThisMapping.SourceValue);

        //        lvwEventMappings.Items.Remove(MapEntry);

        //        EventMappings.Remove(ThisMapping);
        //    }

        //    btnDeleteEventMapping.Enabled = lvwEventMappings.SelectedItems.Count > 0;
        //    btnEditEventMapping.Enabled = lvwEventMappings.SelectedItems.Count > 0;
        //}

        //private void DeleteWeightMapping()
        //{
        //    List<StringToEuroJudoWeightMapping> SelectedMaps = new List<StringToEuroJudoWeightMapping>();

        //    foreach (ListViewItem MapEntry in lvwWeightMappings.SelectedItems)
        //    {
        //        StringToEuroJudoWeightMapping ThisMapping = (StringToEuroJudoWeightMapping)(MapEntry.Tag);

        //        SelectedMaps.Add(ThisMapping);

        //        lstColumnValuesForWeights.Items.Add(ThisMapping.SourceValue);

        //        lvwWeightMappings.Items.Remove(MapEntry);

        //        WeightCategoryMappings.Remove(ThisMapping);
        //    }

        //    btnDeleteWeightMapping.Enabled = lvwWeightMappings.SelectedItems.Count > 0;
        //    btnEditWeightMapping.Enabled = lvwWeightMappings.SelectedItems.Count > 0;
        //}

        //private void DeleteClubMapping()
        //{
        //    List<StringToEuroJudoClubMapping> SelectedMaps = new List<StringToEuroJudoClubMapping>();

        //    foreach (ListViewItem MapEntry in lvwClubMappings.SelectedItems)
        //    {
        //        StringToEuroJudoClubMapping ThisMapping = (StringToEuroJudoClubMapping)(MapEntry.Tag);

        //        SelectedMaps.Add(ThisMapping);

        //        lstColumnValuesForClubs.Items.Add(ThisMapping.SourceValue);

        //        lvwClubMappings.Items.Remove(MapEntry);

        //        ClubMappings.Remove(ThisMapping);
        //    }

        //    btnDeleteClubMapping.Enabled = lvwClubMappings.SelectedItems.Count > 0;
        //    btnEditClubMapping.Enabled = lvwClubMappings.SelectedItems.Count > 0;
        //}

        //private void ResetEventMappings()
        //{
        //    lvwEventMappings.Items.Clear();
        //    lstEuroJudoEvents.SelectedItem = null;

        //    EventMappings.Clear();

        //    GetSourceColumnNames(RevolutioniseSourceData, cmbRevColumnsForEvents, lstColumnValuesForEvents);

        //    btnAutoEventMapping.Enabled = true;
        //}

        //private void ResetWeightMappings()
        //{
        //    lvwWeightMappings.Items.Clear();
        //    lstEuroJudoWeights.SelectedItem = null;

        //    WeightCategoryMappings.Clear();

        //    GetSourceColumnNames(RevolutioniseSourceData, cmbRevColumnsForWeights, lstColumnValuesForWeights);

        //    btnAutoWeightMapping.Enabled = true;
        //}

        //private void ResetClubMappings()
        //{
        //    lvwClubMappings.Items.Clear();
        //    lstEuroJudoClubs.SelectedItem = null;

        //    ClubMappings.Clear();

        //    GetSourceColumnNames(ClubSourceData, cmbCsvColumnsForClubs, lstColumnValuesForClubs);

        //    btnAutoClubMapping.Enabled = true;
        //}

        //private void ShowEventValueChoice()
        //{

        //    if (lstColumnValuesForEvents.SelectedItems.Count > 0)
        //    {
        //        if (lstColumnValuesForEvents.SelectedItems.Count == 1)
        //        {
        //            EuroJudoEvent SelectedEvent = ((EuroJudoEvent)(lstEuroJudoEvents.SelectedItem));
        //        }
        //        else
        //        {
        //            btnAutoEventMapping.Enabled = true;
        //        }
        //    }

        //}

        //private void ShowEuroJudoEventChoice()
        //{
        //    EuroJudoEvent SelectedEvent = null;

        //    if (lstEuroJudoEvents.SelectedItems.Count == 0)
        //    {
        //        SelectedEvent = (EuroJudoEvent)lstEuroJudoEvents.SelectedItem;
        //    }
        //}

        //private void ShowClubValueChoice()
        //{
        //    if (lstColumnValuesForClubs.SelectedItems.Count > 0)
        //    {
        //        if (lstColumnValuesForClubs.SelectedItems.Count == 1)
        //        {
        //            EuroJudoClub SelectedClub = ((EuroJudoClub)(lstEuroJudoClubs.SelectedItem));
        //        }
        //        else
        //        {
        //            btnAutoClubMapping.Enabled = true;
        //        }
        //    }
        //}

        //private void MapEventsAutomatically()
        //{
        //    Color Colour = lvwEventMappings.BackColor;

        //    for (int ColumnIndex = 0; ColumnIndex < lstColumnValuesForEvents.Items.Count; ColumnIndex++)
        //    {
        //        List<LikeResult> ValueResults = new List<LikeResult>();

        //        string ColumnValue = (string)lstColumnValuesForEvents.Items[ColumnIndex];

        //        for (int EventIndex = 0; EventIndex < lstEuroJudoEvents.Items.Count; EventIndex++)
        //        {
        //            EuroJudoEvent ThisEvent = (EuroJudoEvent)lstEuroJudoEvents.Items[EventIndex];

        //            tslblMain.Text = $"Comparing {ColumnValue} with {ThisEvent.Name}";
        //            ssMain.Refresh();

        //            double CommonResult = ThisEvent.Name.Like(ColumnValue);

        //            if (CommonResult > 0) //Properties.Settings.Default.EuroJudoEventValueMinimumComparison)
        //            {
        //                ValueResults.Add(new LikeResult(ColumnValue, ColumnIndex, ThisEvent.Name, CommonResult, ThisEvent));
        //            }
        //        }

        //        if (ValueResults.Count > 0)
        //        {
        //            AddEuroJudoEventLikeResults(ColumnValue: ColumnValue, ColumnIndex: ColumnIndex, Results: ValueResults, MinimumComparisonResult: Properties.Settings.Default.EuroJudoEventValueMinimumComparison);
        //        }
        //    }
        //}

        //private void MapWeightsAutomatically()
        //{
        //    Color Colour = lvwWeightMappings.BackColor;

        //    for (int ValueIndex = 0; ValueIndex < lstColumnValuesForWeights.Items.Count; ValueIndex++)
        //    {
        //        string ColumnValue = (string)lstColumnValuesForWeights.Items[ValueIndex];

        //        for (int EventIndex = 0; EventIndex < lstEuroJudoWeights.Items.Count; EventIndex++)
        //        {
        //            EuroJudoWeightCategory ThisCategory = (EuroJudoWeightCategory)lstEuroJudoWeights.Items[EventIndex];

        //            string WeightCategory = ColumnValue;
        //            foreach (string Replacement in Properties.Settings.Default.EuroJudoWeightCategoryOverReplacement)
        //            {
        //                WeightCategory = WeightCategory.Replace(Replacement, Properties.Settings.Default.EuroJudoWeightCategoryOverValue);
        //            }

        //            foreach (string Replacement in Properties.Settings.Default.EuroJudoWeightCategoryUnderReplacement)
        //            {
        //                WeightCategory = WeightCategory.Replace(Replacement, Properties.Settings.Default.EuroJudoWeightCategoryUnderValue);
        //            }

        //            double CommonResult = ThisCategory.ToString().Like(WeightCategory);

        //            if (CommonResult > Properties.Settings.Default.EuroJudoWeightValueMinimumComparison)
        //            {
        //                AddEuroJudoWeightMapping(RemoveSourceValue: true, SourceValue: ColumnValue, SourceIndex: ValueIndex, ThisCategory, Colour);
        //                ValueIndex--;

        //                break;
        //            }
        //        }
        //    }
        //}

        //private void MapClubsAutomatically()
        //{
        //    Color Colour = lvwClubMappings.BackColor;

        //    for (int ValueIndex = 0; ValueIndex < lstColumnValuesForClubs.Items.Count; ValueIndex++)
        //    {
        //        string ColumnValue = (string)lstColumnValuesForClubs.Items[ValueIndex];

        //        for (int ClubIndex = 0; ClubIndex < lstEuroJudoClubs.Items.Count; ClubIndex++)
        //        {
        //            EuroJudoClub ThisClub = (EuroJudoClub)lstEuroJudoClubs.Items[ClubIndex];

        //            double CommonResult = ThisClub.Name.Like(ColumnValue);

        //            if (CommonResult >= Properties.Settings.Default.EuroJudoClubValueMinimumComparison)
        //            {
        //                AddEuroJudoClubMapping(RemoveSourceValue: true, SourceValue: ColumnValue, SourceIndex: ValueIndex, ThisClub, Colour);
        //                ValueIndex--;

        //                break;
        //            }
        //        }
        //    }
        //}

        #region Event Type

        //private void lstColumnValuesForEvents_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowEventValueChoice();
        //}

        //private void lstEuroJudoEvent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowEuroJudoEventChoice();
        //}

        // The following are common...
        //private void CmbRevColumnsForEvents_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetSourceValues(RevolutioniseSourceData, cmbRevColumnsForEvents, lstColumnValuesForEvents);
        //}

        //private void lvwEventMappings_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    btnDeleteEventMapping.Enabled = lvwEventMappings.SelectedItems.Count > 0;
        //    btnEditEventMapping.Enabled = lvwEventMappings.SelectedItems.Count > 0;
        //}

        //private void btnSetEventMapping_Click(object sender, EventArgs e)
        //{
        //    for (int ValueIndex = 0; ValueIndex < lstColumnValuesForEvents.SelectedItems.Count; ValueIndex++)
        //    {
        //        string ColumnValue = (string)lstColumnValuesForEvents.SelectedItems[ValueIndex];
        //        EuroJudoEvent ThisEvent = (EuroJudoEvent)lstEuroJudoEvents.Items[lstEuroJudoEvents.SelectedIndex];

        //        AddEuroJudoEventMapping(RemoveSourceValue: true, SourceValue: ColumnValue, ValueIndex, ThisEvent, lvwEventMappings.BackColor);
        //    }
        //}

        //private void btnAutoEventMapping_Click(object sender, EventArgs e)
        //{
        //    MapEventsAutomatically();
        //}

        //private void btnResetEventMappings_Click(object sender, EventArgs e)
        //{
        //    ResetEventMappings();
        //}

        //private void btnDeleteEventMapping_Click(object sender, EventArgs e)
        //{
        //    DeleteEventMapping();
        //}
        // ... end common

        #endregion

        #region Weight Categories

        //private void CmbRevColumnsForWeights_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetSourceValues(RevolutioniseSourceData, cmbRevColumnsForWeights, lstColumnValuesForWeights);
        //}

        //private void LvwWeightMappings_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    btnDeleteWeightMapping.Enabled = lvwWeightMappings.SelectedItems.Count > 0;
        //    btnEditWeightMapping.Enabled = lvwWeightMappings.SelectedItems.Count > 0;
        //}

        //private void BtnSetWeightMapping_Click(object sender, EventArgs e)
        //{
        //    for (int ValueIndex = 0; ValueIndex < lstColumnValuesForWeights.SelectedItems.Count; ValueIndex++)
        //    {
        //        string ColumnValue = (string)lstColumnValuesForWeights.SelectedItems[ValueIndex];
        //        EuroJudoWeightCategory ThisWeight = (EuroJudoWeightCategory)lstEuroJudoWeights.Items[lstEuroJudoWeights.SelectedIndex];

        //        AddEuroJudoWeightMapping(RemoveSourceValue: true, SourceValue: ColumnValue, ValueIndex, ThisWeight, lvwWeightMappings.BackColor);
        //    }
        //}

        //private void BtnAutoWeightMapping_Click(object sender, EventArgs e)
        //{
        //    MapWeightsAutomatically();
        //}

        //private void BtnResetWeightMappings_Click(object sender, EventArgs e)
        //{
        //    ResetWeightMappings();
        //}

        //private void BtnDeleteWeightMapping_Click(object sender, EventArgs e)
        //{
        //    DeleteWeightMapping();
        //}

        #endregion

        #region Clubs

        //private void LstColumnValuesForClubs_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowClubValueChoice();
        //}

        //private void CmbCsvColumnsForClubs_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetSourceValues(RevolutioniseSourceData, cmbCsvColumnsForClubs, lstColumnValuesForClubs);
        //}

        //private void LvwClubMappings_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    btnDeleteClubMapping.Enabled = lvwClubMappings.SelectedItems.Count > 0;
        //    btnEditClubMapping.Enabled = lvwClubMappings.SelectedItems.Count > 0;
        //}

        //private void BtnSetClubMapping_Click(object sender, EventArgs e)
        //{
        //    for (int ValueIndex = 0; ValueIndex < lstColumnValuesForClubs.SelectedItems.Count; ValueIndex++)
        //    {
        //        string ColumnValue = (string)lstColumnValuesForClubs.SelectedItems[ValueIndex];
        //        EuroJudoClub ThisClub = (EuroJudoClub)lstEuroJudoClubs.Items[lstEuroJudoClubs.SelectedIndex];

        //        AddEuroJudoClubMapping(RemoveSourceValue: true, SourceValue: ColumnValue, ValueIndex, ThisClub, lvwClubMappings.BackColor);
        //    }
        //}

        //private void BtnAutoClubMapping_Click(object sender, EventArgs e)
        //{
        //    MapClubsAutomatically();
        //}

        //private void BtnResetClubMappings_Click(object sender, EventArgs e)
        //{
        //    ResetClubMappings();
        //}

        //private void BtnDeleteClubMapping_Click(object sender, EventArgs e)
        //{
        //    DeleteClubMapping();
        //}

        //private void lstEuroJudoClubs_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    EuroJudoClub SelectedClub = (EuroJudoClub)lstEuroJudoClubs.SelectedItem;

        //    string HelpText = "";

        //    if (SelectedClub != null)
        //    {
        //        if (SelectedClub.Location != null)
        //        {
        //            if (SelectedClub.Location.Country != null && SelectedClub.Location.SubDivision != null)
        //            {
        //                HelpText = $"Club name: {SelectedClub.Name}, Code: {SelectedClub.Code}, Location: {SelectedClub.Location.Country.Alpha2Code}-{SelectedClub.Location.SubDivision.Code}";
        //            }
        //            else
        //            {
        //                HelpText = $"Club name: {SelectedClub.Name}, Code: {SelectedClub.Code}, Location: Unknown";
        //            }
        //        }
        //        else
        //        {
        //            HelpText = $"Club name: {SelectedClub.Name}, Code: {SelectedClub.Code}";
        //        }
        //    }
        //    else
        //    {
        //        HelpText = "Could not determine club";
        //    }

        //    tslblMain.Text = HelpText;
        //}

        #endregion

        #endregion

        private void TsbExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TsbLoad_Click(object sender, EventArgs e)
        {
            LoadImportData(Reload: false);
        }

        private void TsbOptions_Click(object sender, EventArgs e)
        {
            DoOptions();
        }
    }
}
