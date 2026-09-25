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
using static NPOIHelper.Extensions;
using Rev;
using EuroJudo;
using static Utilities.Transform;

namespace Rev
{
    public partial class xxxfrmIJFMapping : Form
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
        private DataTable RevolutioniseSourceData = new DataTable();
        private DataTable ClubSourceData = new DataTable();

        private List<Country> Countries = new List<Country>();
        private List<SubDivision> SubDivisions = new List<SubDivision>();
        private List<Tournament> Tournaments = new List<Tournament>();

        private List<Event> Events = new List<Event>();
        private List<WeightCategory> WeightCategories = new List<WeightCategory>();
        private List<Club> Clubs = new List<Club>();
        private List<Belt> Belts = new List<Belt>();

        private List<StringToObjectMapping<Event>> EventMappings = new List<StringToObjectMapping<Event>>();
        private List<StringToObjectMapping<WeightCategory>> WeightCategoryMappings = new List<StringToObjectMapping<WeightCategory>>();
        private List<StringToObjectMapping<Club>> ClubMappings = new List<StringToObjectMapping<Club>>();
        private List<StringToObjectMapping<string>> MemberIDMappings = new List<StringToObjectMapping<string>>();
        private List<StringToObjectMapping<int>> DayOfBirthMappings = new List<StringToObjectMapping<int>>();
        private List<StringToObjectMapping<int>> MonthOfBirthMappings = new List<StringToObjectMapping<int>>();
        private List<StringToObjectMapping<int>> YearOfBirthMappings = new List<StringToObjectMapping<int>>();
        private List<StringToObjectMapping<Gender>> EuroJudoGenderMappings = new List<StringToObjectMapping<Gender>>();
        private List<StringToObjectMapping<Belt>> BeltMappings = new List<StringToObjectMapping<Belt>>();
        private List<StringToObjectMapping<string>> LastNameMappings = new List<StringToObjectMapping<string>>();
        private List<StringToObjectMapping<string>> FirstNameMappings = new List<StringToObjectMapping<string>>();

        private Tournament SelectedTournament = null;
        private EuroJudo.Column CurrentMappingType = EuroJudo.Column.Unknown;

        private bool InitialLoadComplete = false;
        //private bool TournamentLoaded = false;

        //private bool EventSourceLoaded = false;
        //private bool WeightSourceLoaded = false;
        //private bool ClubSourceLoaded = false;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public xxxfrmIJFMapping(DataTable SourceData, List<Club> ClubData, List<Belt> BeltData, List<Country> CountryData, List<SubDivision> SubDivisionData)
        {
            InitializeComponent();

            RevolutioniseSourceData = SourceData;
            Clubs = ClubData;
            Belts = BeltData;
            Countries = CountryData;
            SubDivisions = SubDivisionData;

        }

        //~FrmIJFMapping()
        //{
        //    RevolutioniseSourceData.Dispose();
        //}

        #endregion

        #region Event Handlers

        private void frmEuroJudoMapping_Load(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            // Start at 0 because we don't want "Unknown"
            for (int i = 0; i < Enum.GetValues(typeof(EuroJudo.Column)).Length - 1; i++)
            {
                string ThisEnumName = Enum.GetName(typeof(EuroJudo.Column), i);

                cmbEuroJudoMappingType.Items.Add(ThisEnumName);
            }

            //cmbEuroJudoMappingType.Items.Add("Event type");
            //cmbEuroJudoMappingType.Items.Add("Weight category");
            //cmbEuroJudoMappingType.Items.Add("Club");
            //cmbEuroJudoMappingType.Items.Add("Member ID");
            //cmbEuroJudoMappingType.Items.Add("Date of Birth");
            //cmbEuroJudoMappingType.Items.Add("Gender");
            //cmbEuroJudoMappingType.Items.Add("Belt");

            btnPreviousMappingType.Enabled = false;
            btnNextMappingType.Enabled = true;

        }

        private void frmEuroJudoMapping_Shown(object sender, EventArgs e)
        {
            string TournamentFilename = Properties.Settings.Default.EuroJudoDatabaseFilename.Trim();

            if (TournamentFilename.Length > 0)
            {
                Tournaments = GetEuroJudoTournaments(cmbTournament, TournamentFilename, Properties.Settings.Default.EuroJudoTournamentQuery);

                // This requires the Tournaments to be loaded
                if (Properties.Settings.Default.LastEuroJudoTournament.Trim().Length > 0 && cmbTournament.Items.Contains(Tournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament)))
                {
                    cmbTournament.SelectedItem = Tournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament);
                }
            }
            else
            {
                tslblMain.Text = "Tournaments filename is blank";
            }

            DoStartup();
        }

        //private void TabExportType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    //switch (tabExportType.SelectedIndex)
        //    //{
        //    //    case 0: // IJF
        //    //        break;
        //    //    case 1: // EuroJudo
        //    //        // Set textbox defaults according to the last values used
        //    //        //txtEuroJudoDatabaseFilename.Text = Properties.Settings.Default.EuroJudoTournamentFilename; // C:\Users\YourUser\OneDrive\Documents\Judo\Tournaments\Tournaments.mdb
        //    //        //txtEuroJudoExportFilename.Text = Properties.Settings.Default.EuroJudoExportFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\euro.xls
        //    //        //txtEuroJudoClubsFilename.Text = Properties.Settings.Default.EuroJudoClubsFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\Clubs.csv
        //    //        //txtEuroJudoCountriesFilename.Text = Properties.Settings.Default.EuroJudoCountriesFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\Countries.csv
        //    //        //txtEuroJudoSubDivisionFilename.Text = Properties.Settings.Default.EuroJudoSubDivisionsFilename; // C:\Users\YourUser\OneDrive\VS Projects\Revolutionise\Samples\SubDivisions.csv

        //    //        //// This requires filepaths to be defined
        //    //        //Countries = GetCountries(Properties.Settings.Default.EuroJudoCountriesFilename);

        //    //        //// SubDivisions needs Countries to be loaded first
        //    //        //SubDivisions = GetSubDivisions(Properties.Settings.Default.EuroJudoSubDivisionsFilename);

        //    //        //EuroJudoTournaments = GetEuroJudoTournaments(tscTournament, Properties.Settings.Default.EuroJudoTournamentQuery);
        //    //        //EuroJudoClubs = GetEuroJudoClubs(Properties.Settings.Default.EuroJudoClubsFilename);

        //    //        //// This requires the Tournaments to be loaded
        //    //        //if (Properties.Settings.Default.LastEuroJudoTournament.Trim().Length > 0 && tscTournament.Items.Contains(EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament)))
        //    //        //{
        //    //        //    tscTournament.SelectedItem = EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament);
        //    //        //}


        //    //        break;
        //    //}
        //}

        //private void tabValueType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    EnableDisableSetButton();
        //    EnableDisableAutoButton();
        //}

        #region Buttons

        private void btnAutoSet_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Debug.Print($"Inside {CurrentMethodName()}");

            MapValuesAutomatically(lstImportedColumnValues, lstEuroJudoComparisonValue, lvwDatabaseMappingResults, CurrentMappingType);

            EnableDisableSave();

            EnableDisableResetButton();

            Cursor.Current = Cursors.Default;
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

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            // csv
            //List<Person> records = new List<Person>();
            //{
            //    new Person { Id = 1, Name = "one" },
            //};



            // EuroJudo "Members & Clubs for Import.xls"
            string newFile = cmbTournament.Text; // xls

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

        private void BtnDeleteMapping_Click(object sender, EventArgs e)
        {

        }

        private void btnResetMappings_Click(object sender, EventArgs e)
        {
            lvwDatabaseMappingResults.Items.Clear();

            if (CurrentMappingType != EuroJudo.Column.Unknown)
            //if (cmbEuroJudoMappingType.SelectedIndex > -1)
            {
                SetMappingType();
            }
        }

        private void btnManualSet_Click(object sender, EventArgs e)
        {
            List<int> SelectedIndices = new List<int>();
            MethodType SelectedMethodType = MethodType.None;
            string[] TransformParameters = { };

            foreach (var x in lstImportedColumnValues.SelectedIndices)
            {
                SelectedIndices.Add((int)x);
            }

            for (int SelectedItemIndex = 0; SelectedItemIndex < SelectedIndices.Count; SelectedItemIndex++)
            {
                int ColumnIndex = SelectedIndices[SelectedItemIndex];
                List<ComparisonResult> ValueResults = new List<ComparisonResult>();
                string ColumnValue = (string)lstImportedColumnValues.SelectedItems[0]; // It's always 0 as we remove the current item at the end of the loop
                int EuroJudoValueIndex = lstEuroJudoComparisonValue.SelectedIndex;

                (SelectedMethodType, TransformParameters) = GetCurrentMethodTypeAndParameters();

                switch (CurrentMappingType)
                {
                    case EuroJudo.Column.Event:
                        MapEvent(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.WeightCategory:
                        MapWeightCategory(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.Club:
                        MapClub(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.MemberID:
                        MapMemberID(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.DayOfBirth:
                        MapDayOfBirth(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.MonthOfBirth:
                        MapMonthOfBirth(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.YearOfBirth:
                        MapYearOfBirth(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.Gender:
                        MapGender(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.Belt:
                        MapBelt(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.FirstName:
                        MapFirstName(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                    case EuroJudo.Column.LastName:
                        MapLastName(lstEuroJudoComparisonValue, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, true, SelectedMethodType, TransformParameters);

                        break;
                }

                if (ValueResults.Count > 0)
                {
                    switch (CurrentMappingType)
                    {
                        case EuroJudo.Column.Event:
                            AddEuroJudoEventComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoEventValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.WeightCategory:
                            AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.Club:
                            AddEuroJudoClubComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoClubValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.MemberID:
                            AddEuroJudoMemberIDComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.DayOfBirth:
                            AddEuroJudoDayOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.MonthOfBirth:
                            AddEuroJudoMonthOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.YearOfBirth:
                            AddEuroJudoYearOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.Gender:
                            AddEuroJudoGenderComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoGenderValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.Belt:
                            AddEuroJudoBeltComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoBeltValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.FirstName:
                            AddEuroJudoFirstNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                        case EuroJudo.Column.LastName:
                            AddEuroJudoLastNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                    }
                }
            }

            EnableDisableSave();

            EnableDisableResetButton();
        }

        #endregion

        #region Comboboxes

        private void cmdTournament_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            SelectedTournament = (Tournament)cmbTournament.SelectedItem;

            Properties.Settings.Default.LastEuroJudoTournament = SelectedTournament.Name;
            Properties.Settings.Default.Save();

            //if (TournamentLoaded)
            //{
            //MessageBox.Show("The application must now restart.\r\nThis behaviour will change in a future version.");
            //Application.Restart();
            //}

            //SetMappingType();

            //ClearValues();

            //tscTournament.Enabled = false;
        }

        private void cmbEuroJudoMappingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            if (cmbEuroJudoMappingType.SelectedIndex > -1)
            {
                CurrentMappingType = (EuroJudo.Column)cmbEuroJudoMappingType.SelectedIndex;

                SetMappingType();
            }

            EnableDisableSetButton();
        }

        private void cmbColumnNamesFromImportData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            switch (CurrentMappingType) //(cmbEuroJudoMappingType.SelectedIndex)
            {
                case EuroJudo.Column.Event:
                    Properties.Settings.Default.LastEuroJudoEventTypeColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.WeightCategory:
                    Properties.Settings.Default.LastEuroJudoWeightCategoryColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.Club:
                    Properties.Settings.Default.LastEuroJudoClubColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.MemberID:
                    Properties.Settings.Default.LastEuroJudoMemberIDColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.DayOfBirth:
                    Properties.Settings.Default.LastEuroJudoDayOfBirthColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.MonthOfBirth:
                    Properties.Settings.Default.LastEuroJudoMonthOfBirthColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.YearOfBirth:
                    Properties.Settings.Default.LastEuroJudoYearOfBirthColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.Gender:
                    Properties.Settings.Default.LastEuroJudoGenderColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.Belt:
                    Properties.Settings.Default.LastEuroJudoBeltColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.FirstName:
                    Properties.Settings.Default.LastEuroJudoFirstNameColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case EuroJudo.Column.LastName:
                    Properties.Settings.Default.LastEuroJudoLastNameColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Column.Unknown:
                    break;
            }

            Properties.Settings.Default.Save();

            if (cmbColumnNamesFromImportData.SelectedIndex > -1)
            {
                GetSourceColumnValues(RevolutioniseSourceData, cmbColumnNamesFromImportData.SelectedIndex, lstImportedColumnValues);
            }

            EnableDisableAutoButton();

        }

        #endregion

        private void lvwDatabaseMappingResults_DoubleClick(object sender, EventArgs e)
        {
            frmShowMapping MappingForm = null;
            ListViewItem SelectedItem = lvwDatabaseMappingResults.SelectedItems[0];
            ComparisonResult Result = null;
            int SelectedItemIndex = lvwDatabaseMappingResults.SelectedItems[0].Index;
            StringToObjectMapping<Event> EventMapping = null;
            StringToObjectMapping<WeightCategory> WeightCategoryMapping = null;
            StringToObjectMapping<Club> ClubMapping = null;
            StringToObjectMapping<string> MemberIDMapping = null;
            StringToObjectMapping<int> DayOfBirthMapping = null;
            StringToObjectMapping<int> MonthOfBirthMapping = null;
            StringToObjectMapping<int> YearOfBirthMapping = null;
            StringToObjectMapping<Gender> GenderMapping = null;
            StringToObjectMapping<Belt> BeltMapping = null;
            StringToObjectMapping<string> LastNameMapping = null;
            StringToObjectMapping<string> FirstNameMapping = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            MappingForm = new frmShowMapping((List<ComparisonResult>)SelectedItem.Tag);

            DialogResult FormResult = MappingForm.ShowDialog();

            if (FormResult == DialogResult.OK)
            {
                Result = MappingForm.SelectedComparisonResult;

                ListViewItem NewItem = null;

                switch (MappingForm.SelectedComparisonResult.MapType)
                {
                    case EuroJudo.Column.Event:
                        {
                            if (Result.Value != null)
                            {
                                NewItem = new ListViewItem(new string[] { (string)Result.Value, ((Event)(Result.Value)).Name, ((Event)(Result.Value)).Index.ToString() });

                                TransformType = Transform.MethodType.Database_Mapping;

                                EventMapping = new StringToObjectMapping<Event>((string)Result.Value, Result.ValueIndex, (Event)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { (string)Result.Value, "[NONE]", "[NONE]" });

                                TransformType = Transform.MethodType.None;

                                EventMapping = new StringToObjectMapping<Event>((string)Result.Value, Result.ValueIndex, (Event)Result.Value, TransformType, TransformParameters);
                            }

                            if (!EventMappings.Contains(EventMapping))
                            {
                                EventMappings.Add(EventMapping);
                            }

                            break;
                        }
                    case EuroJudo.Column.WeightCategory:
                        {
                            if (Result.Value != null)
                            {
                                NewItem = new ListViewItem(new string[] { (string)Result.Value, ((WeightCategory)(Result.Value)).Name, ((WeightCategory)(Result.Value)).Event.Index.ToString() });
                                WeightCategoryMapping = new StringToObjectMapping<WeightCategory>((string)Result.Value, Result.ValueIndex, (WeightCategory)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { (string)Result.Value, ((WeightCategory)(Result.Value)).Name, ((WeightCategory)(Result.Value)).Event.Index.ToString() });
                                WeightCategoryMapping = new StringToObjectMapping<WeightCategory>((string)Result.Value, Result.ValueIndex, (WeightCategory)Result.Value, TransformType, TransformParameters);
                            }

                            if (!WeightCategoryMappings.Contains(WeightCategoryMapping))
                            {
                                WeightCategoryMappings.Add(WeightCategoryMapping);
                            }

                            break;
                        }
                    case EuroJudo.Column.Club:
                        {
                            NewItem = new ListViewItem(new string[] { (string)Result.Value, ((Club)(Result.Value)).ToString(), ((Club)(Result.Value)).Code });
                            ClubMapping = new StringToObjectMapping<Club>((string)Result.Value, Result.ValueIndex, (Club)Result.Value, TransformType, TransformParameters);

                            if (!ClubMappings.Contains(ClubMapping))
                            {
                                ClubMappings.Add(ClubMapping);
                            }

                            break;
                        }
                    ///
                    case EuroJudo.Column.MemberID:
                        NewItem = new ListViewItem(new string[] { (string)Result.Value, ((string)(Result.Value)).ToString(), (string)(Result.Value) });
                        MemberIDMapping = new StringToObjectMapping<string>((string)Result.Value, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                        if (!MemberIDMappings.Contains(MemberIDMapping))
                        {
                            MemberIDMappings.Add(MemberIDMapping);
                        }

                        break;
                    case EuroJudo.Column.DayOfBirth:
                        NewItem = new ListViewItem(new string[] { (string)Result.Value, ((int)(Result.Value)).ToString(), (string)(Result.Value) });
                        DayOfBirthMapping = new StringToObjectMapping<int>((string)Result.Value, Result.ValueIndex, (int)Result.Value, TransformType, TransformParameters);

                        if (!DayOfBirthMappings.Contains(DayOfBirthMapping))
                        {
                            DayOfBirthMappings.Add(DayOfBirthMapping);
                        }

                        break;
                    case EuroJudo.Column.MonthOfBirth:
                        NewItem = new ListViewItem(new string[] { (string)Result.Value, ((int)(Result.Value)).ToString(), (string)(Result.Value) });
                        MonthOfBirthMapping = new StringToObjectMapping<int>((string)Result.Value, Result.ValueIndex, (int)Result.Value, TransformType, TransformParameters);

                        if (!MonthOfBirthMappings.Contains(MonthOfBirthMapping))
                        {
                            MonthOfBirthMappings.Add(MonthOfBirthMapping);
                        }

                        break;
                    case EuroJudo.Column.YearOfBirth:
                        NewItem = new ListViewItem(new string[] { (string)Result.Value, ((int)(Result.Value)).ToString(), (string)(Result.Value) });
                        YearOfBirthMapping = new StringToObjectMapping<int>((string)Result.Value, Result.ValueIndex, (int)Result.Value, TransformType, TransformParameters);

                        if (!YearOfBirthMappings.Contains(YearOfBirthMapping))
                        {
                            YearOfBirthMappings.Add(YearOfBirthMapping);
                        }

                        break;
                    case EuroJudo.Column.Gender:
                        if (Result.TransformMethod != MethodType.None)
                        {
                            NewItem = new ListViewItem(new string[] { (string)Result.Value, ((Gender)(Result.Value)).ToString(), ((Gender)(Result.Value)).ToString() });
                            GenderMapping = new StringToObjectMapping<Gender>((string)Result.Value, Result.ValueIndex, (Gender)Result.Value, TransformType, TransformParameters);
                        }
                        else
                        {
                            NewItem = new ListViewItem(new string[] { "", "[NONE]" });
                            GenderMapping = new StringToObjectMapping<Gender>((string)Result.Value, Result.ValueIndex, Gender.Unknown, TransformType, TransformParameters);
                        }

                        if (!EuroJudoGenderMappings.Contains(GenderMapping))
                        {
                            EuroJudoGenderMappings.Add(GenderMapping);
                        }

                        break;
                    case EuroJudo.Column.Belt:
                        {
                            NewItem = new ListViewItem(new string[] { (string)Result.Value, ((Belt)(Result.Value)).ToString(), ((Belt)(Result.Value)).Name });
                            BeltMapping = new StringToObjectMapping<Belt>((string)Result.Value, Result.ValueIndex, (Belt)Result.Value, TransformType, TransformParameters);

                            if (!BeltMappings.Contains(BeltMapping))
                            {
                                BeltMappings.Add(BeltMapping);
                            }

                            break;
                        }
                    case EuroJudo.Column.LastName:
                        NewItem = new ListViewItem(new string[] { (string)Result.Value, ((string)(Result.Value)).ToString(), ((string)(Result.Value)) });
                        LastNameMapping = new StringToObjectMapping<string>((string)Result.Value, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                        if (!LastNameMappings.Contains(LastNameMapping))
                        {
                            LastNameMappings.Add(LastNameMapping);
                        }

                        break;
                    case EuroJudo.Column.FirstName:
                        NewItem = new ListViewItem(new string[] { (string)Result.Value, ((string)(Result.Value)).ToString(), ((string)(Result.Value)) });
                        FirstNameMapping = new StringToObjectMapping<string>((string)Result.Value, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                        if (!FirstNameMappings.Contains(FirstNameMapping))
                        {
                            FirstNameMappings.Add(FirstNameMapping);
                        }

                        break;
                }

                List<ComparisonResult> NewTag = new List<ComparisonResult>();
                NewTag.Add(MappingForm.SelectedComparisonResult);

                NewItem.Tag = NewTag;
                NewItem.BackColor = lvwDatabaseMappingResults.BackColor;

                lvwDatabaseMappingResults.Items.RemoveAt(SelectedItemIndex);
                lvwDatabaseMappingResults.Items.Insert(SelectedItemIndex, NewItem);
            }
            else if (FormResult == DialogResult.Yes) // The user clicked "None"
            {
                lvwDatabaseMappingResults.Items.RemoveAt(SelectedItemIndex);

                if (MappingForm.ComparisonValue == null)
                {
                    lstImportedColumnValues.Items.Add("");
                }
                else
                {
                    lstImportedColumnValues.Items.Add(MappingForm.ComparisonValue);
                }

                switch (MappingForm.MappingType)
                {
                    case EuroJudo.Column.Event:
                        if (EventMappings.Contains(EventMapping))
                        {
                            EventMappings.Remove(EventMapping);
                        }
                        break;
                    case EuroJudo.Column.WeightCategory:
                        if (WeightCategoryMappings.Contains(WeightCategoryMapping))
                        {
                            WeightCategoryMappings.Remove(WeightCategoryMapping);
                        }
                        break;
                    case EuroJudo.Column.Club:
                        if (ClubMappings.Contains(ClubMapping))
                        {
                            ClubMappings.Remove(ClubMapping);
                        }
                        break;
                    case EuroJudo.Column.MemberID:
                        if (MemberIDMappings.Contains(MemberIDMapping))
                        {
                            MemberIDMappings.Remove(MemberIDMapping);
                        }
                        break;
                    case EuroJudo.Column.DayOfBirth:
                        if (DayOfBirthMappings.Contains(DayOfBirthMapping))
                        {
                            DayOfBirthMappings.Remove(DayOfBirthMapping);
                        }
                        break;
                    case EuroJudo.Column.MonthOfBirth:
                        if (MonthOfBirthMappings.Contains(MonthOfBirthMapping))
                        {
                            MonthOfBirthMappings.Remove(MonthOfBirthMapping);
                        }
                        break;
                    case EuroJudo.Column.YearOfBirth:
                        if (YearOfBirthMappings.Contains(YearOfBirthMapping))
                        {
                            YearOfBirthMappings.Remove(YearOfBirthMapping);
                        }
                        break;
                    case EuroJudo.Column.Gender:
                        if (EuroJudoGenderMappings.Contains(GenderMapping))
                        {
                            EuroJudoGenderMappings.Remove(GenderMapping);
                        }
                        break;
                    case EuroJudo.Column.Belt:
                        if (BeltMappings.Contains(BeltMapping))
                        {
                            BeltMappings.Remove(BeltMapping);
                        }
                        break;
                    case EuroJudo.Column.LastName:
                        if (LastNameMappings.Contains(LastNameMapping))
                        {
                            LastNameMappings.Remove(LastNameMapping);
                        }
                        break;
                    case EuroJudo.Column.FirstName:
                        if (FirstNameMappings.Contains(FirstNameMapping))
                        {
                            FirstNameMappings.Remove(FirstNameMapping);
                        }
                        break;
                }
            }
            else // Cancel
            {
            }

        }

        private void LvwDatabaseMappingResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnResetMappings.Enabled = lvwDatabaseMappingResults.SelectedItems.Count > 0;
        }

        private void lstImportedColumnValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableSetButton();
        }

        private void lstImportedColumnValues_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lstEuroJudoComparisonValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableSetButton();
        }

        private void trbComparisonMinimum_ValueChanged(object sender, EventArgs e)
        {
            if (trbComparisonMinimum.Enabled)
            {
                lblMinComparisonValue.Text = trbComparisonMinimum.Value.ToString() + " %";

                switch (CurrentMappingType)
                {
                    case Column.Unknown:
                        break;
                    case Column.Event:
                        Properties.Settings.Default.EuroJudoEventValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case Column.FirstName:
                        break;
                    case Column.LastName:
                        break;
                    case Column.WeightCategory:
                        Properties.Settings.Default.EuroJudoWeightValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case Column.Club:
                        Properties.Settings.Default.EuroJudoClubValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case Column.MemberID:
                        break;
                    case Column.DayOfBirth:
                        break;
                    case Column.MonthOfBirth:
                        break;
                    case Column.YearOfBirth:
                        break;
                    case Column.Gender:
                        Properties.Settings.Default.EuroJudoGenderValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case Column.Belt:
                        Properties.Settings.Default.EuroJudoBeltValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                }
            }
            else
            {
                lblMinComparisonValue.Text = "-";
            }
        }

        private void radMapToDatabaseValue_CheckedChanged(object sender, EventArgs e)
        {
            lstEuroJudoComparisonValue.Enabled = radMapToDatabaseValue.Checked;

            if (radMapToDatabaseValue.Checked)
            {
                //btnManualSet.Enabled = lstEuroJudoComparisonValue.SelectedIndex > -1;
                EnableDisableSetButton();
                btnAutoSet.Enabled = true;
            }
        }

        private void radCopyOrTranslate_CheckedChanged(object sender, EventArgs e)
        {
            lstEuroJudoComparisonValue.Enabled = radMapToDatabaseValue.Checked;

            if (radCopyOrTranslate.Checked)
            {
                //btnManualSet.Enabled = lstEuroJudoComparisonValue.SelectedIndex > -1;
                EnableDisableSetButton();
                btnAutoSet.Enabled = true;
            }
        }

        private void radNone_CheckedChanged(object sender, EventArgs e)
        {
            lstEuroJudoComparisonValue.Enabled = radMapToDatabaseValue.Checked;

            if (radNone.Checked)
            {
                //btnManualSet.Enabled = lstEuroJudoComparisonValue.SelectedIndex > -1;
                EnableDisableSetButton();
                btnAutoSet.Enabled = true;
            }
        }

        #endregion

        #region Private Methods

        private void DoStartup()
        {
            GetSourceColumnNames(RevolutioniseSourceData, cmbColumnNamesFromImportData, lstImportedColumnValues);

            //string CountriesFilename = Properties.Settings.Default.CountriesFilename.Trim();
            //string SubDivisionsFilename = Properties.Settings.Default.SubDivisionsFilename.Trim();
            //string TournamentFilename = Properties.Settings.Default.EuroJudoDatabaseFilename.Trim();
            //string ClubsFilename = Properties.Settings.Default.ClubsFilename.Trim();

            //Countries = new List<Country>();
            //SubDivisions = new List<SubDivision>();
            //EuroJudoClubs = new List<Club>();
            //EuroJudoEvents = new List<Event>();
            //EuroJudoWeightCategories = new List<WeightCategory>();

            //lvwDatabaseMappingResults.Items.Clear();

            //InitialLoadComplete = false;

            //if (CountriesFilename.Length > 0)
            //{
            //    // This requires filepaths to be defined
            //    Countries = GetCountries(CountriesFilename);

            //    if (SubDivisionsFilename.Length > 0)
            //    {
            //        // SubDivisions needs Countries to be loaded first
            //        SubDivisions = GetSubDivisions(SubDivisionsFilename);

            //        if (TournamentFilename.Length > 0)
            //        {
            //            EuroJudoTournaments = GetEuroJudoTournaments(cmbTournament, TournamentFilename, Properties.Settings.Default.EuroJudoTournamentQuery);

            //            if (ClubsFilename.Length > 0)
            //            {
            //                EuroJudoClubs = GetEuroJudoClubs(ClubsFilename);

            //                // This requires the Tournaments to be loaded
            //                if (Properties.Settings.Default.LastEuroJudoTournament.Trim().Length > 0 && cmbTournament.Items.Contains(EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament)))
            //                {
            //                    cmbTournament.SelectedItem = EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament);
            //                }

            //                EuroJudoBelts = GetEuroJudoBelts();

            //                InitialLoadComplete = true;
            //            }
            //            else
            //            {
            //                tslblMain.Text = "Clubs filename is blank";
            //            }
            //        }
            //        else
            //        {
            //            tslblMain.Text = "Tournaments filename is blank";
            //        }
            //    }
            //    else
            //    {
            //        tslblMain.Text = "Sub Divisions filename is blank";
            //    }
            //}
            //else
            //{
            //    tslblMain.Text = "Countries filename is blank";
            //}

            ////** MOVED radEuroJudoSimpleTranslation.Checked = true;

            ////loadToolStripMenuItem.Enabled = InitialLoadComplete;
        }

        //private void DoOptions()
        //{
        //    frmOptions OptionsForm = new frmOptions();

        //    DialogResult Result = OptionsForm.ShowDialog();

        //    if (Result == DialogResult.OK)
        //    {
        //        if (TournamentLoaded)
        //        {
        //            MessageBox.Show("The application must now restart.\r\nThis behaviour will change in a future version.");
        //            Application.Restart();
        //        }
        //    }
        //}

        //private void CleanImportFile()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ShowBelts()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ShowClubs()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ShowCountries()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ShowSubDivisions()
        //{
        //    throw new NotImplementedException();
        //}

        private List<Tournament> GetEuroJudoTournaments(ComboBox Combobox, string Filename, string Query)
        {
            bool Result = false;
            DataTable DataResult = null;
            string TextResult = "";
            List<Tournament> ListResult = new List<Tournament>();

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading data...";
            this.Refresh();

            Combobox.Items.Clear();

            (TextResult, Result, DataResult) = Utilities.Data.GetAccessData(Filename, Query, "EuroJudo_Tournaments");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;

            foreach (DataRow Row in DataResult.Rows)
            {
                pbrAuto.Value++;
                pbrAuto.Refresh();
                int Index = Convert.ToInt32(Row.ItemArray[0].ToString());
                string Name = (string)(Row.ItemArray[1].ToString());
                Tournament ThisTournament = new Tournament(Index, Name);

                Combobox.Items.Add(ThisTournament);

                ListResult.Add(ThisTournament);
            }

            pbrAuto.Value = 0;
            tslblMain.Text = TextResult;
            this.Refresh();
            Cursor.Current = Cursors.Default;

            return ListResult;
        }

        //private List<Country> GetCountries(string Filename)
        //{
        //    bool Result = false;
        //    List<Country> ListResult = new List<Country>();
        //    string[] SplitCharacters = new string[] { "," };
        //    List<string> RowsToIgnore = null;

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    Cursor.Current = Cursors.WaitCursor;
        //    tslblMain.Text = "Loading Countries...";
        //    this.Refresh();

        //    DataTable DataResult = null;
        //    string TextResult = "";

        //    (TextResult, Result, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "Clubs");

        //    pbrAuto.Minimum = 0;
        //    pbrAuto.Maximum = DataResult.Rows.Count;
        //    tslblMain.Text = TextResult;

        //    foreach (DataRow Row in DataResult.Rows)
        //    {
        //        pbrAuto.Value++;
        //        pbrAuto.Refresh();

        //        string Name = Row.ItemArray[0].ToString();
        //        string Alpha2 = Row.ItemArray[1].ToString();
        //        string Alpha3 = Row.ItemArray[2].ToString();
        //        Country NewCountry = new Country(Name, Alpha2, Alpha3);
        //        ListResult.Add(NewCountry);
        //    }

        //    pbrAuto.Value = 0;
        //    UpdateStatus($"{ListResult.Count} Countries loaded";
        //    this.Refresh();
        //    Cursor.Current = Cursors.Default;

        //    return ListResult;
        //}

        //private List<SubDivision> GetSubDivisions(string Filename)
        //{
        //    bool Result = false;
        //    List<SubDivision> ListResult = new List<SubDivision>();
        //    string[] SplitCharacters = new string[] { "," };
        //    List<string> RowsToIgnore = null;

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    Cursor.Current = Cursors.WaitCursor;
        //    tslblMain.Text = "Loading SubDivisions...";
        //    this.Refresh();

        //    DataTable DataResult = null;
        //    string TextResult = "";

        //    (TextResult, Result, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "SubDivisions");

        //    pbrAuto.Minimum = 0;
        //    pbrAuto.Maximum = DataResult.Rows.Count;
        //    tslblMain.Text = TextResult;

        //    foreach (DataRow Row in DataResult.Rows)
        //    {
        //        pbrAuto.Value++;
        //        pbrAuto.Refresh();

        //        string CountryName = Row.ItemArray[0].ToString();
        //        string Code = Row.ItemArray[1].ToString();
        //        string Name = Row.ItemArray[2].ToString();
        //        string Type = Row.ItemArray[3].ToString();
        //        Country Country = Countries.Find(c => Code.StartsWith(c.Alpha2Code));

        //        SubDivision NewSubDivision = new SubDivision(Name, Code, Country);
        //        ListResult.Add(NewSubDivision);
        //    }

        //    pbrAuto.Value = 0;
        //    UpdateStatus($"{ListResult.Count} SubDivisions loaded";
        //    this.Refresh();
        //    Cursor.Current = Cursors.Default;
        //    return ListResult;
        //}

        //private List<Club> GetEuroJudoClubs(string Filename)
        //{
        //    bool Result = false;
        //    List<Club> ListResult = new List<Club>();
        //    string[] SplitCharacters = new string[] { "," };
        //    List<string> RowsToIgnore = null;

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    Cursor.Current = Cursors.WaitCursor;
        //    tslblMain.Text = "Loading Clubs...";
        //    this.Refresh();

        //    DataTable DataResult = null;
        //    string TextResult = "";

        //    (TextResult, Result, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "Clubs");

        //    pbrAuto.Minimum = 0;
        //    pbrAuto.Maximum = DataResult.Rows.Count;
        //    tslblMain.Text = TextResult;

        //    foreach (DataRow Row in DataResult.Rows)
        //    {
        //        pbrAuto.Value++;
        //        pbrAuto.Refresh();

        //        int ID = Convert.ToInt32(Row.ItemArray[0].ToString());
        //        string Name = Row.ItemArray[1].ToString();
        //        string CountryCode = Row.ItemArray[2].ToString();
        //        string SubDivisionCode = Row.ItemArray[3].ToString();
        //        string Code = Row.ItemArray[4].ToString();

        //        Country Country = Countries.Find(c => c.Alpha2Code == CountryCode);
        //        SubDivision SubDivision = SubDivisions.Find(s => s.Code == Country.Alpha2Code + "-" + SubDivisionCode);
        //        Location Location = new Location(Country, SubDivision);

        //        Club NewClub = new Club(ID, Name, Code, Location);
        //        ListResult.Add(NewClub);
        //    }

        //    pbrAuto.Value = 0;
        //    UpdateStatus($"{ListResult.Count} Clubs loaded";
        //    this.Refresh();
        //    Cursor.Current = Cursors.Default;

        //    return ListResult;
        //}

        //private List<Belt> GetEuroJudoBelts()
        //{
        //    List<Belt> Result = new List<Belt>();
        //    string[] SplitCharacters = new string[] { "," };

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    Cursor.Current = Cursors.WaitCursor;
        //    tslblMain.Text = "Loading Belts...";
        //    this.Refresh();

        //    for (int i = 1; i < 21; i++)
        //    {
        //        Result.Add(new Belt((Grade)i));
        //    }

        //    pbrAuto.Value = 0;
        //    UpdateStatus($"{Result.Count} Belts loaded";
        //    this.Refresh();
        //    Cursor.Current = Cursors.Default;

        //    return Result;
        //}

        private DataTable GetEuroJudoData(string Query, string Filename, EuroJudo.Column MappingType)
        {
            bool Result = false;

            Cursor.Current = Cursors.WaitCursor;
            tslblMain.Text = "Loading...";
            this.Refresh();

            Debug.Print($"Inside {CurrentMethodName()}");

            DataTable DataResult = null;
            string TextResult = "";

            switch (MappingType)
            {
                case EuroJudo.Column.Event:
                    (TextResult, Result, DataResult) = Utilities.Data.GetAccessData(Filename, Query, "EuroJudo_Events");
                    break;
                case EuroJudo.Column.WeightCategory:
                    (TextResult, Result, DataResult) = Utilities.Data.GetAccessData(Filename, Query, "EuroJudo_WeightCategories");
                    break;
                    //case EuroJudoMappingType.Club:
                    //    {
                    //        TextResult = "Clubs previously loaded";
                    //        DataResult = null;

                    //        //string[] SplitCharacters = new string[] { cmbSplitCharacters.Text };
                    //        //List<string> RowsToIgnore = null;

                    //        //if (chkRemoveTotalRow.Checked)
                    //        //{
                    //        //    RowsToIgnore = new List<string> { "Total" };
                    //        //}
                    //        //else
                    //        //{
                    //        //    RowsToIgnore = new List<string>();
                    //        //}

                    //        //(TextResult, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, chkImportHasHeaders.Checked, RowsToIgnore);
                    //    }
                    //    break;
                    //case EuroJudo.MappingType.Belt:
                    //    for (int i = 0; i < 21; i++)
                    //    {
                    //        EuroJudoBelts.Add(new Belt((Grade)i));
                    //    }
                    //    break;
            }

            pbrAuto.Value = 0;
            tslblMain.Text = TextResult;
            this.Refresh();
            Cursor.Current = Cursors.Default;

            return DataResult;
        }

        //private void GetImportData(bool Reload)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    DialogResult Result = DialogResult.None;
        //    frmImport ImportForm = null;

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    if (Reload)
        //    {
        //        Result = DialogResult.OK;
        //    }
        //    else
        //    {
        //        ImportForm = new frmImport(Properties.Settings.Default.ImportFilename);

        //        Result = ImportForm.ShowDialog();

        //        Properties.Settings.Default.ImportFilename = ImportForm.ImportFilename;
        //    }

        //    if (Result == DialogResult.OK)
        //    {
        //        LoadCSVDataSource(Properties.Settings.Default.ImportFilename, ref RevolutioniseSourceData);

        //        //SourceValueGrid.DataSource = RevolutioniseSourceData;

        //        //SourceValueGrid.AutoResizeColumns();


        //        //EuroJudoTournaments = GetEuroJudoTournaments(tscTournament, Properties.Settings.Default.EuroJudoTournamentQuery);

        //        //// This requires filepaths to be defined
        //        //Countries = GetCountries(Properties.Settings.Default.EuroJudoCountriesFilename);

        //        //// SubDivisions needs Countries to be loaded first
        //        //SubDivisions = GetSubDivisions(Properties.Settings.Default.EuroJudoSubDivisionsFilename);

        //        //EuroJudoTournaments = GetEuroJudoTournaments(tscTournament, Properties.Settings.Default.EuroJudoTournamentQuery);

        //        //EuroJudoClubs = GetEuroJudoClubs(Properties.Settings.Default.EuroJudoClubsFilename);

        //        //// This requires the Tournaments to be loaded
        //        //if (Properties.Settings.Default.LastEuroJudoTournament.Trim().Length > 0 && tscTournament.Items.Contains(EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament)))
        //        //{
        //        //    tscTournament.SelectedItem = EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.LastEuroJudoTournament);
        //        //}

        //        GetSourceColumnNames(RevolutioniseSourceData, cmbColumnNamesFromImportData, lstImportedColumnValues);

        //        if (cmbEuroJudoMappingType.Items.Count > 0)
        //        {
        //            cmbEuroJudoMappingType.SelectedIndex = 0;
        //        }

        //        //tabExportType.Enabled = true;

        //        TournamentLoaded = true;

        //    }

        //    Cursor.Current = Cursors.Default;
        //}

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

        private void GetEuroJudoComparisonData()
        {
            DataTable Results = new DataTable();

            Debug.Print($"Inside {CurrentMethodName()}");

            if (RevolutioniseSourceData != null && RevolutioniseSourceData.Rows.Count > 0)
            {
                int SelectedColumnIndex = cmbColumnNamesFromImportData.SelectedIndex; // cmbEuroJudoMappingType.SelectedIndex; // cmbImportedColumnNames.SelectedIndex; 
                string SelectedJudoTournamentIndex = "";
                string DbQuery = "";
                string Filename = Properties.Settings.Default.EuroJudoDatabaseFilename;

                if (SelectedTournament != null)
                {
                    SelectedJudoTournamentIndex = SelectedTournament.Index.ToString();
                }
                else
                {
                    return;
                }

                Debug.Print($"...Using ColumnIndex from ComboBox 'cmbColumnNamesFromImportData'");

                if (SelectedColumnIndex > -1)
                {
                    GetSourceColumnValues(RevolutioniseSourceData, SelectedColumnIndex, lstImportedColumnValues);
                }

                switch (CurrentMappingType) // (cmbEuroJudoMappingType.SelectedIndex)
                {
                    case EuroJudo.Column.Event: // 0: // Event
                        DbQuery = Properties.Settings.Default.EuroJudoEventQuery.Replace("##SelectedEuroJudoTournament_Index##", SelectedJudoTournamentIndex);
                        Results = GetEuroJudoData(DbQuery, Filename, EuroJudo.Column.Event);

                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;

                        FillComparisonListboxWithData(Results, lstEuroJudoComparisonValue, EuroJudo.Column.Event);

                        break;
                    case EuroJudo.Column.WeightCategory: // 1: // Weight Category
                        DbQuery = Properties.Settings.Default.EuroJudoWeightQuery.Replace("##SelectedEuroJudoTournament_Index##", SelectedJudoTournamentIndex);
                        Results = GetEuroJudoData(DbQuery, Filename, EuroJudo.Column.WeightCategory);

                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;

                        FillComparisonListboxWithData(Results, lstEuroJudoComparisonValue, EuroJudo.Column.WeightCategory);

                        break;
                    case EuroJudo.Column.Club: // 2: // Club - (previously loaded)
                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = true;

                        FillComparisonListboxWithData(Results, lstEuroJudoComparisonValue, EuroJudo.Column.Club);

                        break;
                    case EuroJudo.Column.MemberID: // 3: // Member ID
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;

                        FillComparisonListboxWithData(null, lstEuroJudoComparisonValue, EuroJudo.Column.MemberID);
                        break;
                    case EuroJudo.Column.DayOfBirth:
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;
                        FillComparisonListboxWithData(null, lstEuroJudoComparisonValue, EuroJudo.Column.DayOfBirth);
                        break;
                    case EuroJudo.Column.MonthOfBirth:
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;
                        FillComparisonListboxWithData(null, lstEuroJudoComparisonValue, EuroJudo.Column.MonthOfBirth);
                        break;
                    case EuroJudo.Column.YearOfBirth:
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;
                        FillComparisonListboxWithData(null, lstEuroJudoComparisonValue, EuroJudo.Column.YearOfBirth);
                        break;
                    case EuroJudo.Column.Gender: // 5: // Gender
                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;
                        //Results = typeof(Sex).ToDataTable("Key", "Value");
                        //DataTable SexEnum = Results.AsEnumerable().Where(r => r.ItemArray[0].ToString().Length == 1).CopyToDataTable();
                        FillComparisonListboxWithData(null, lstEuroJudoComparisonValue, EuroJudo.Column.Gender);
                        break;
                    case EuroJudo.Column.Belt: // 6: // Belt
                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;
                        //Results = typeof(Belt).ToDataTable("Key", "Value");
                        DataTable BeltTable = Belts.ToDataTable<Belt>();
                        FillComparisonListboxWithData(BeltTable, lstEuroJudoComparisonValue, EuroJudo.Column.Belt);
                        break;
                    case EuroJudo.Column.LastName: // 7
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;
                        FillComparisonListboxWithData(null, lstEuroJudoComparisonValue, EuroJudo.Column.LastName);
                        break;
                    case EuroJudo.Column.FirstName: // 8
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;
                        FillComparisonListboxWithData(null, lstEuroJudoComparisonValue, EuroJudo.Column.FirstName);
                        break;
                }
            }
        }

        private void GetSourceColumnValues(DataTable DataSource, int ImportFileColumnIndex, ListBox Listbox)
        {
            Debug.Print($"Inside {CurrentMethodName()}");
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
            UpdateStatus($"Load complete: {DataSource.Rows.Count} rows loaded");
            Listbox.ResumeDrawing();
            this.Refresh();
            Cursor.Current = Cursors.Default;
        }

        //private void LoadCSVDataSource(string Filename, ref DataTable TargetDataSource)
        //{
        //    string[] SplitCharacters = new string[] { Properties.Settings.Default.ImportDelimiter };
        //    List<string> RowsToIgnore = null;
        //    string ResultText = "";

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    Cursor.Current = Cursors.WaitCursor;
        //    tslblMain.Text = "Removing existing data...";

        //    this.Refresh();

        //    if (Properties.Settings.Default.ImportRemoveTotalRow)
        //    {
        //        RowsToIgnore = new List<string> { "Total" };
        //    }
        //    else
        //    {
        //        RowsToIgnore = new List<string>();
        //    }

        //    tslblMain.Text = "Loading data...";
        //    this.Refresh();

        //    TargetDataSource.BeginLoadData();
        //    (ResultText, TargetDataSource) = Utilities.Data.GetCSVData(Filename, SplitCharacters, Properties.Settings.Default.ImportHeaders, RowsToIgnore, "ImportFile");
        //    TargetDataSource.EndLoadData();

        //    tslblMain.Text = ResultText;
        //    this.Refresh();
        //    Cursor.Current = Cursors.Default;
        //}

        private void FillComparisonListboxWithData(DataTable DataResult, ListBox Listbox, EuroJudo.Column MappingType)
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
                case EuroJudo.Column.Event:
                    {
                        Listbox.Sorted = true;

                        if (DataResult != null)
                        {
                            pbrAuto.Maximum = DataResult.Rows.Count;

                            foreach (DataRow Row in DataResult.Rows)
                            {
                                int Number = Convert.ToInt32(Row.ItemArray[0].ToString());
                                Gender sex = (Gender)Enum.Parse(typeof(Gender), (string)(Row.ItemArray[1].ToString()));
                                string Name = (string)(Row.ItemArray[2].ToString());

                                pbrAuto.Value++;
                                pbrAuto.Refresh();

                                NewInstance = new Event(Listbox.Items.Count, Number, Name, sex);

                                Listbox.Items.Add(NewInstance);

                                Events.Add((Event)NewInstance);
                            }
                        }
                        break;
                    }
                case EuroJudo.Column.WeightCategory:
                    {
                        Listbox.Sorted = true;

                        if (DataResult != null)
                        {
                            pbrAuto.Maximum = DataResult.Rows.Count;

                            foreach (DataRow Row in DataResult.Rows)
                            {
                                int ClassNumber = Convert.ToInt32(Row.ItemArray[0].ToString());
                                string EventName = Row.ItemArray[1].ToString();
                                string Name = (string)(Row.ItemArray[2].ToString());
                                int Minimum = Convert.ToInt32(Row.ItemArray[3]);
                                int Maximum = Convert.ToInt32(Row.ItemArray[4]);

                                pbrAuto.Value++;
                                pbrAuto.Refresh();

                                if (Events.Count > 0)
                                {
                                    NewInstance = new WeightCategory(ClassNumber, Events.Find(n => n.Name == EventName), Name, Minimum, Maximum);
                                }
                                else
                                {
                                    NewInstance = new WeightCategory(ClassNumber, null, EventName + " " + Name, Minimum, Maximum);
                                }

                                Listbox.Items.Add(NewInstance);
                            }
                        }
                        break;
                    }
                case EuroJudo.Column.Club:
                    {
                        Listbox.Sorted = true;

                        pbrAuto.Maximum = Clubs.Count;

                        // Clubs have already been loaded
                        foreach (Club Club in Clubs)
                        {
                            pbrAuto.Value++;
                            pbrAuto.Refresh();

                            Listbox.Items.Add(Club);
                        }
                        break;
                    }
                case EuroJudo.Column.MemberID:
                    {
                        // No conversion
                        break;
                    }
                case EuroJudo.Column.DayOfBirth:
                    {
                        // No conversion
                        break;
                    }
                case EuroJudo.Column.MonthOfBirth:
                    {
                        // No conversion
                        break;
                    }
                case EuroJudo.Column.YearOfBirth:
                    {
                        // No conversion
                        break;
                    }
                case EuroJudo.Column.Gender:
                    {
                        Listbox.Sorted = true;

                        Listbox.Items.Add(Gender.M);
                        Listbox.Items.Add(Gender.F);
                        break;
                    }
                case EuroJudo.Column.Belt:
                    {
                        Listbox.Sorted = false;

                        foreach (Belt Belt in Belts)
                        {
                            Listbox.Items.Add(Belt);
                        }

                        break;
                    }
                case EuroJudo.Column.LastName:
                    {
                        // No conversion
                        break;
                    }
                case EuroJudo.Column.FirstName:
                    {
                        // No conversion
                        break;
                    }
            }

            pbrAuto.Value = 0;
            Listbox.ResumeDrawing();
            tslblMain.Text = TextResult;
            this.Refresh();
            Cursor.Current = Cursors.Default;

        }

        private void MapValuesAutomatically(ListBox ImportedColumnValuesListbox, ListBox EuroJudoValuesListbox, ListView MappingListview, EuroJudo.Column MapType)
        {
            Color Colour = MappingListview.BackColor;
            MethodType SelectedMethodType = MethodType.None;
            string[] TransformParameters = { };

            Cursor.Current = Cursors.WaitCursor;

            Debug.Print($"Inside {CurrentMethodName()}");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = ImportedColumnValuesListbox.Items.Count * EuroJudoValuesListbox.Items.Count;

            (SelectedMethodType, TransformParameters) = GetCurrentMethodTypeAndParameters();

            for (int ColumnIndex = 0; ColumnIndex < ImportedColumnValuesListbox.Items.Count; ColumnIndex++)
            {
                List<ComparisonResult> ValueResults = new List<ComparisonResult>();

                string ColumnValue = (string)ImportedColumnValuesListbox.Items[ColumnIndex];

                switch (SelectedMethodType)
                {
                    case MethodType.Value_Copy:
                        {
                            int EuroJudoValueIndex = -1;

                            pbrAuto.Value = EuroJudoValuesListbox.Items.Count * (ColumnIndex + 1);

                            Application.DoEvents();

                            //Debug.Print($"{pbrAuto.Value} / {pbrAuto.Maximum}");

                            switch (MapType)
                            {
                                case EuroJudo.Column.Event:
                                    {
                                        MapEvent(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.WeightCategory:
                                    {
                                        MapWeightCategory(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.Club:
                                    {
                                        MapClub(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.MemberID:
                                    {
                                        MapMemberID(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.DayOfBirth:
                                    {
                                        MapDayOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.MonthOfBirth:
                                    {
                                        MapMonthOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.YearOfBirth:
                                    {
                                        MapYearOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.Gender:
                                    {
                                        MapGender(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.Belt:
                                    {
                                        MapBelt(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.FirstName:
                                    {
                                        MapFirstName(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.LastName:
                                    {
                                        MapLastName(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                            }

                            if (ValueResults.Count > 0)
                            {
                                switch (MapType)
                                {
                                    case EuroJudo.Column.Event:
                                        AddEuroJudoEventComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoEventValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.WeightCategory:
                                        AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Club:
                                        AddEuroJudoClubComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoClubValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.MemberID:
                                        AddEuroJudoMemberIDComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.DayOfBirth:
                                        AddEuroJudoDayOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.MonthOfBirth:
                                        AddEuroJudoMonthOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.YearOfBirth:
                                        AddEuroJudoYearOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Gender:
                                        AddEuroJudoGenderComparisonResults(ColumnValue, ColumnIndex, ValueResults, 100, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Belt:
                                        AddEuroJudoBeltComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoBeltValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.FirstName:
                                        AddEuroJudoFirstNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.LastName:
                                        AddEuroJudoLastNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                }

                                ColumnIndex--;
                            }

                            break;
                        }
                    case MethodType.Database_Mapping:
                        {
                            for (int EuroJudoValueIndex = 0; EuroJudoValueIndex < EuroJudoValuesListbox.Items.Count; EuroJudoValueIndex++)
                            {
                                if (pbrAuto.Value < pbrAuto.Maximum)
                                {
                                    pbrAuto.Value++;
                                }

                                Application.DoEvents();

                                //Debug.Print($"{pbrAuto.Value} / {pbrAuto.Maximum}");

                                switch (MapType)
                                {
                                    case EuroJudo.Column.Event:
                                        {
                                            MapEvent(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.WeightCategory:
                                        {
                                            MapWeightCategory(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.Club:
                                        {
                                            MapClub(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.MemberID:
                                        {
                                            MapMemberID(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.DayOfBirth:
                                        {
                                            MapDayOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.MonthOfBirth:
                                        {
                                            MapMonthOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.YearOfBirth:
                                        {
                                            MapYearOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.Gender:
                                        {
                                            MapGender(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.Belt:
                                        {
                                            MapBelt(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.FirstName:
                                        {
                                            MapFirstName(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                    case EuroJudo.Column.LastName:
                                        {
                                            MapLastName(EuroJudoValuesListbox, ColumnIndex, ValueResults, ColumnValue, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                            break;
                                        }
                                }
                            }

                            if (ValueResults.Count > 0)
                            {
                                switch (MapType)
                                {
                                    case EuroJudo.Column.Event:
                                        AddEuroJudoEventComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoEventValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.WeightCategory:
                                        AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Club:
                                        AddEuroJudoClubComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoClubValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.MemberID:
                                        AddEuroJudoMemberIDComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.DayOfBirth:
                                        AddEuroJudoDayOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.MonthOfBirth:
                                        AddEuroJudoMonthOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.YearOfBirth:
                                        AddEuroJudoYearOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Gender:
                                        AddEuroJudoGenderComparisonResults(ColumnValue, ColumnIndex, ValueResults, 100, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Belt:
                                        AddEuroJudoBeltComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoBeltValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.FirstName:
                                        AddEuroJudoFirstNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.LastName:
                                        AddEuroJudoLastNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                }

                                ColumnIndex--;
                            }
                            break;
                        }
                    case MethodType.None:
                        {
                            int EuroJudoValueIndex = -1;

                            pbrAuto.Value = EuroJudoValuesListbox.Items.Count * (ColumnIndex + 1);

                            Application.DoEvents();

                            //Debug.Print($"{pbrAuto.Value} / {pbrAuto.Maximum}");

                            switch (MapType)
                            {
                                case EuroJudo.Column.Event:
                                    {
                                        MapEvent(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.WeightCategory:
                                    {
                                        MapWeightCategory(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.Club:
                                    {
                                        MapClub(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.MemberID:
                                    {
                                        MapMemberID(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.DayOfBirth:
                                    {
                                        MapDayOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.MonthOfBirth:
                                    {
                                        MapMonthOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.YearOfBirth:
                                    {
                                        MapYearOfBirth(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.Gender:
                                    {
                                        MapGender(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.Belt:
                                    {
                                        MapBelt(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.FirstName:
                                    {
                                        MapFirstName(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                                case EuroJudo.Column.LastName:
                                    {
                                        MapLastName(EuroJudoValuesListbox, ColumnIndex, ValueResults, null, EuroJudoValueIndex, false, SelectedMethodType, TransformParameters);
                                        break;
                                    }
                            }

                            if (ValueResults.Count > 0)
                            {
                                switch (MapType)
                                {
                                    case EuroJudo.Column.Event:
                                        AddEuroJudoEventComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoEventValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.WeightCategory:
                                        AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Club:
                                        AddEuroJudoClubComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoClubValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.MemberID:
                                        AddEuroJudoMemberIDComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.DayOfBirth:
                                        AddEuroJudoDayOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.MonthOfBirth:
                                        AddEuroJudoMonthOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.YearOfBirth:
                                        AddEuroJudoYearOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Gender:
                                        AddEuroJudoGenderComparisonResults(ColumnValue, ColumnIndex, ValueResults, 100, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.Belt:
                                        AddEuroJudoBeltComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoBeltValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.FirstName:
                                        AddEuroJudoFirstNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case EuroJudo.Column.LastName:
                                        AddEuroJudoLastNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                }

                                ColumnIndex--;
                            }

                            break;
                        }
                }


            }

            pbrAuto.Value = 0;
            tslblMain.Text = "Auto mapping complete";

            Cursor.Current = Cursors.Default;
        }

        #region Map_x

        private Event MapEvent(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            Event NewInstance = null;
            double CommonResult = 0;
            string OriginalValue = ColumnValue;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (Event)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((Event)NewInstance).ToString()}");
            }

            #region Replace common values

            if (ColumnValue != null)
            {
                // Process common values first
                ColumnValue = ColumnValue.ToLower().Replace("junior ", "Junior ");
                ColumnValue = ColumnValue.ToLower().Replace("jnr. ", "Junior ");
                ColumnValue = ColumnValue.ToLower().Replace("jnr ", "Junior ");
                ColumnValue = ColumnValue.ToLower().Replace("senior ", "Senior ");
                ColumnValue = ColumnValue.ToLower().Replace("snr. ", "Senior ");
                ColumnValue = ColumnValue.ToLower().Replace("snr ", "Senior ");
                ColumnValue = ColumnValue.ToLower().Replace("cad ", "Cadet ");
                ColumnValue = ColumnValue.ToLower().Replace("cad. ", "Cadet ");

                // Process females next because "women" contains "men" etc

                ColumnValue = ColumnValue.Replace("Female", "Womens");
                ColumnValue = ColumnValue.Replace("Women", "Womens");
                ColumnValue = ColumnValue.Replace("Woman", "Womens");
                ColumnValue = ColumnValue.Replace("Girl", "Girls");
                ColumnValue = ColumnValue.ToLower().Replace("female", "Womens");
                ColumnValue = ColumnValue.ToLower().Replace("women", "Womens");
                ColumnValue = ColumnValue.ToLower().Replace("woman", "Womems");
                ColumnValue = ColumnValue.ToLower().Replace("girls", "Girls");
                ColumnValue = ColumnValue.ToLower().Replace("girl", "Girls");
                //ColumnValue = ColumnValue.ToLower().Replace("g", "Girls");
                ColumnValue = ColumnValue.ToLower().Replace("w", "Girls");

                ColumnValue = ColumnValue.Replace("Male", "Mens");
                ColumnValue = ColumnValue.Replace("Men", "Mens");
                ColumnValue = ColumnValue.Replace("Man", "Mens");
                ColumnValue = ColumnValue.Replace("Boy", "Mens");
                ColumnValue = ColumnValue.ToLower().Replace("male", "Mens");
                ColumnValue = ColumnValue.ToLower().Replace("man", "Mens");
                ColumnValue = ColumnValue.ToLower().Replace("boys", "Mens");
                ColumnValue = ColumnValue.ToLower().Replace("boy", "Mens");
                ColumnValue = ColumnValue.ToLower().Replace("b", "Mens");
            }

            #endregion

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    CommonResult = ((Event)NewInstance).Name.CompareWith(ColumnValue);

                    if (CommonResult >= Properties.Settings.Default.EuroJudoEventValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, ((Event)NewInstance).Name, CommonResult, EuroJudo.Column.Event, (Event)NewInstance, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.Event, (Event)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    if (CommonResult >= Properties.Settings.Default.EuroJudoEventValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.Event, null, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.Event, null, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
            }

            return NewInstance;
        }

        private WeightCategory MapWeightCategory(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            WeightCategory NewInstance = null;
            double CommonResult = 0;
            string NewInstanceEventName = "";
            string NewInstanceName = "";
            string OriginalValue = ColumnValue;
            string WeightCategory = ColumnValue;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (WeightCategory)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((WeightCategory)NewInstance).ToString()}");
            }

            #region Replacement values

            if (ColumnValue != null)
            {
                // Process common values first
                ColumnValue = ColumnValue.ToLower().Replace("junior", "Junior");
                ColumnValue = ColumnValue.ToLower().Replace("jnr.", "Junior");
                ColumnValue = ColumnValue.ToLower().Replace("jnr", "Junior");
                ColumnValue = ColumnValue.ToLower().Replace("senior", "Senior");
                ColumnValue = ColumnValue.ToLower().Replace("snr.", "Senior");
                ColumnValue = ColumnValue.ToLower().Replace("snr", "Senior");
                ColumnValue = ColumnValue.ToLower().Replace("cad", "Cadet");
                ColumnValue = ColumnValue.ToLower().Replace("cad.", "Cadet");

                // Process females next because "women" contains "men" etc

                ColumnValue = ColumnValue.Replace("Female", "Womens");
                ColumnValue = ColumnValue.Replace("Women", "Womens");
                ColumnValue = ColumnValue.Replace("Woman", "Womens");
                ColumnValue = ColumnValue.Replace("Girl", "Girls");
                ColumnValue = ColumnValue.ToLower().Replace("women", "Womens");
                ColumnValue = ColumnValue.ToLower().Replace("woman", "Womens");
                ColumnValue = ColumnValue.ToLower().Replace("girls", "Girls");
                ColumnValue = ColumnValue.ToLower().Replace("girl", "Girls");
                ColumnValue = ColumnValue.ToLower().Replace("g", "Girls");
                ColumnValue = ColumnValue.ToLower().Replace("w", "Womens");

                ColumnValue = ColumnValue.Replace("Male", "Mens");
                ColumnValue = ColumnValue.Replace("Men", "Mens");
                ColumnValue = ColumnValue.Replace("Man", "Mens");
                ColumnValue = ColumnValue.Replace("Boy", "Boys");
                ColumnValue = ColumnValue.ToLower().Replace("male", "Mens");
                ColumnValue = ColumnValue.ToLower().Replace("man", "Mens");
                ColumnValue = ColumnValue.ToLower().Replace("boys", "Boys");
                ColumnValue = ColumnValue.ToLower().Replace("boy", "Boys");
                ColumnValue = ColumnValue.ToLower().Replace("b", "Boys");

                if (WeightCategory != null)
                {
                    foreach (string Replacement in Properties.Settings.Default.EuroJudoWeightCategoryOverReplacement)
                    {
                        WeightCategory = WeightCategory.Replace(Replacement, Properties.Settings.Default.EuroJudoWeightCategoryOverValue);
                    }

                    foreach (string Replacement in Properties.Settings.Default.EuroJudoWeightCategoryUnderReplacement)
                    {
                        WeightCategory = WeightCategory.Replace(Replacement, Properties.Settings.Default.EuroJudoWeightCategoryUnderValue);
                    }
                }
            }

            #endregion

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    if (NewInstance.Event != null)
                    {
                        NewInstanceEventName = ((WeightCategory)NewInstance).Event.Name;
                        NewInstanceName = ((WeightCategory)NewInstance).ToString();
                        CommonResult = NewInstanceName.CompareWith(WeightCategory);
                    }
                    else
                    {
                        CommonResult = ((WeightCategory)NewInstance).Name.CompareWith(WeightCategory);
                    }

                    if (CommonResult >= Properties.Settings.Default.EuroJudoWeightValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, ((WeightCategory)NewInstance).Name, CommonResult, EuroJudo.Column.WeightCategory, (WeightCategory)NewInstance, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.WeightCategory, (WeightCategory)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    if (CommonResult >= Properties.Settings.Default.EuroJudoWeightValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.WeightCategory, null, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.WeightCategory, null, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
            }

            return NewInstance;
        }

        private Club MapClub(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            Club NewInstance = null;
            double CommonResult = 0;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (Club)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((Club)NewInstance).Name}");
            }

            switch (TransformMethodType)
            {
                case MethodType.Value_Copy:
                    CommonResult = 100;

                    Country Australia = Countries.Where(c => c.Name == "Australia").First();
                    SubDivision State = null;

                    Club NewClub = new Club(Clubs.Count, ColumnValue, Guid.NewGuid().ToString(), new Location(Australia, State));

                    // Add this Club to the Club list
                    if (!Clubs.Contains(NewClub))
                    {
                        Clubs.Add(NewClub);
                        lstEuroJudoComparisonValue.Items.Add(NewClub);
                    }
                    else
                    {
                        NewClub = Clubs.Where(c => c.Name == NewClub.Name &&
                                                   c.Location.Country.Name == NewClub.Location.Country.Name
                                             ).First();
                    }

                    //ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, NewClub.Name, CommonResult, EuroJudo.Column.Club, NewClub, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.Club, NewClub, Manual, TransformMethodType, TransformParameters));
                    break;
                case MethodType.Database_Mapping:
                    CommonResult = ((Club)NewInstance).Name.CompareWith(ColumnValue);

                    if (CommonResult >= Properties.Settings.Default.EuroJudoClubValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, ((Club)NewInstance).Name, CommonResult, EuroJudo.Column.Club, (Club)NewInstance, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.Club, (Club)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    if (CommonResult >= Properties.Settings.Default.EuroJudoClubValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.Club, null, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.Club, null, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
            }

            return NewInstance;
        }

        private string MapMemberID(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            string NewInstance = "";
            double CommonResult = 0;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (string)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((string)NewInstance)}");
            }

            switch (TransformMethodType)
            {
                case MethodType.Value_Copy:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, ((string)NewInstance), CommonResult, EuroJudo.Column.MemberID, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.MemberID, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, (null), CommonResult, EuroJudo.Column.MemberID, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.MemberID, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private int MapDayOfBirth(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            int NewInstance = -1;
            double CommonResult = 0;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (int)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((int)NewInstance)}");
            }

            switch (TransformMethodType)
            {
                case MethodType.Value_Copy:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, (NewInstance.ToString()), CommonResult, EuroJudo.Column.DayOfBirth, (int)NewInstance, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.DayOfBirth, (int)NewInstance, Manual, TransformMethodType, TransformParameters));
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.DayOfBirth, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.DayOfBirth, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private int MapMonthOfBirth(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            int NewInstance = -1;
            double CommonResult = 0;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (int)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((int)NewInstance)}");
            }

            switch (TransformMethodType)
            {
                case MethodType.Value_Copy:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, (NewInstance.ToString()), CommonResult, EuroJudo.Column.MonthOfBirth, (int)NewInstance, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.MonthOfBirth, (int)NewInstance, Manual, TransformMethodType, TransformParameters));
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.MonthOfBirth, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.MonthOfBirth, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private int MapYearOfBirth(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            int NewInstance = -1;
            double CommonResult = 0;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (int)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((int)NewInstance)}");
            }

            switch (TransformMethodType)
            {
                case MethodType.Value_Copy:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, (NewInstance.ToString()), CommonResult, EuroJudo.Column.YearOfBirth, (int)NewInstance, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.YearOfBirth, (int)NewInstance, Manual, TransformMethodType, TransformParameters));
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.YearOfBirth, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.YearOfBirth, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private Gender MapGender(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            Gender NewInstance = Gender.Unknown;
            double CommonResult = 0;
            string OriginalValue = ColumnValue;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (Gender)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((Gender)NewInstance)}");
            }

            #region Replace common values

            // Process females first because "women" contains "men" etc

            if (ColumnValue != null)
            {
                ColumnValue = ColumnValue.Replace("Female", "F");
                ColumnValue = ColumnValue.Replace("Women", "F");
                ColumnValue = ColumnValue.Replace("Woman", "F");
                ColumnValue = ColumnValue.Replace("Girls", "F");
                ColumnValue = ColumnValue.Replace("Girl", "F");
                ColumnValue = ColumnValue.ToLower().Replace("female", "F");
                ColumnValue = ColumnValue.ToLower().Replace("women", "F");
                ColumnValue = ColumnValue.ToLower().Replace("woman", "F");
                ColumnValue = ColumnValue.ToLower().Replace("girls", "F");
                ColumnValue = ColumnValue.ToLower().Replace("girl", "F");
                ColumnValue = ColumnValue.ToLower().Replace("g", "F");
                ColumnValue = ColumnValue.ToLower().Replace("w", "F");

                ColumnValue = ColumnValue.Replace("Male", "M");
                ColumnValue = ColumnValue.Replace("Men", "M");
                ColumnValue = ColumnValue.Replace("Man", "M");
                ColumnValue = ColumnValue.Replace("Boys", "M");
                ColumnValue = ColumnValue.Replace("Boy", "M");
                ColumnValue = ColumnValue.ToLower().Replace("male", "M");
                ColumnValue = ColumnValue.ToLower().Replace("man", "M");
                ColumnValue = ColumnValue.ToLower().Replace("boys", "M");
                ColumnValue = ColumnValue.ToLower().Replace("boy", "M");
                ColumnValue = ColumnValue.ToLower().Replace("b", "M");
            }

            #endregion

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    CommonResult = ((Gender)NewInstance).ToString().CompareWith(ColumnValue);

                    if (CommonResult >= Properties.Settings.Default.EuroJudoGenderValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, (NewInstance.ToString()), CommonResult, EuroJudo.Column.Gender, (Gender)NewInstance, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.Gender, (Gender)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.Gender, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.Gender, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private Belt MapBelt(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            Belt NewInstance = null;
            double CommonResult1 = 0.0;
            double CommonResult2 = 0.0;
            double CommonResult3 = 0.0;
            double TopResult1 = 0.0;
            double TopResult2 = 0.0;
            string OriginalValue = ColumnValue;

            if (ValueIndex == -1)
            {
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (Belt)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((Belt)NewInstance).Colour}");
            }

            #region Replace common values

            if (ColumnValue != null)
            {
                // Remove the word "belt"
                ColumnValue = ColumnValue.Replace("Belt", "");
                ColumnValue = ColumnValue.Replace("belt", "");
                ColumnValue = ColumnValue.Replace("BELT", "");

                // Remove age category
                ColumnValue = ColumnValue.Replace("Senior", "");
                ColumnValue = ColumnValue.Replace("senior", "");
                ColumnValue = ColumnValue.Replace("Snr.", "");
                ColumnValue = ColumnValue.Replace("Snr", "");
                ColumnValue = ColumnValue.Replace("snr.", "");
                ColumnValue = ColumnValue.Replace("snr", "");
                ColumnValue = ColumnValue.Replace("SNR.", "");
                ColumnValue = ColumnValue.Replace("SNR", "");

                ColumnValue = ColumnValue.Replace("Junior", "");
                ColumnValue = ColumnValue.Replace("junior", "");
                ColumnValue = ColumnValue.Replace("Jnr.", "");
                ColumnValue = ColumnValue.Replace("Jnr", "");
                ColumnValue = ColumnValue.Replace("jnr.", "");
                ColumnValue = ColumnValue.Replace("jnr", "");
                ColumnValue = ColumnValue.Replace("JNR.", "");
                ColumnValue = ColumnValue.Replace("JNR", "");

                ColumnValue = ColumnValue.Replace("Cadet", "");
                ColumnValue = ColumnValue.Replace("cadet", "");
                ColumnValue = ColumnValue.Replace("cad.", "");
                ColumnValue = ColumnValue.Replace("Cad.", "");
                ColumnValue = ColumnValue.Replace("cad", "");

                // numbers
                ColumnValue = ColumnValue.Replace("1 st", "1st");
                ColumnValue = ColumnValue.Replace("2 nd", "2nd");
                ColumnValue = ColumnValue.Replace("3 rd", "3rd");
                ColumnValue = ColumnValue.Replace("4 th", "4th");
                ColumnValue = ColumnValue.Replace("5 th", "5th");
                ColumnValue = ColumnValue.Replace("6 th", "6th");
                ColumnValue = ColumnValue.Replace("7 th", "7th");
                ColumnValue = ColumnValue.Replace("8 th", "8th");
                ColumnValue = ColumnValue.Replace("9 th", "9th");
                ColumnValue = ColumnValue.Replace("10 th", "10th");

                ColumnValue = ColumnValue.Replace("1 ST", "1st");
                ColumnValue = ColumnValue.Replace("2 ND", "2nd");
                ColumnValue = ColumnValue.Replace("3 RD", "3rd");
                ColumnValue = ColumnValue.Replace("4 TH", "4th");
                ColumnValue = ColumnValue.Replace("5 TH", "5th");
                ColumnValue = ColumnValue.Replace("6 TH", "6th");
                ColumnValue = ColumnValue.Replace("7 TH", "7th");
                ColumnValue = ColumnValue.Replace("8 TH", "8th");
                ColumnValue = ColumnValue.Replace("9 TH", "9th");
                ColumnValue = ColumnValue.Replace("10 TH", "10th");

                // Remove all strange combinations of "Dan"
                ColumnValue = ColumnValue.Replace("dan", "Dan");
                ColumnValue = ColumnValue.Replace("DAN", "Dan");
                ColumnValue = ColumnValue.Replace("-Dan", " Dan");

                ColumnValue = ColumnValue.Replace("first", "1st");
                ColumnValue = ColumnValue.Replace("second", "2nd");
                ColumnValue = ColumnValue.Replace("third", "3rd");
                ColumnValue = ColumnValue.Replace("fourth", "4th");
                ColumnValue = ColumnValue.Replace("fifth", "5th");
                ColumnValue = ColumnValue.Replace("sixth", "6th");
                ColumnValue = ColumnValue.Replace("seventh", "7th");
                ColumnValue = ColumnValue.Replace("eigth", "8th");
                ColumnValue = ColumnValue.Replace("ninth", "9th");
                ColumnValue = ColumnValue.Replace("tenth", "10th");

                ColumnValue = ColumnValue.Replace("First", "1st");
                ColumnValue = ColumnValue.Replace("Second", "2nd");
                ColumnValue = ColumnValue.Replace("Third", "3rd");
                ColumnValue = ColumnValue.Replace("Fourth", "4th");
                ColumnValue = ColumnValue.Replace("Fifth", "5th");
                ColumnValue = ColumnValue.Replace("Sixth", "6th");
                ColumnValue = ColumnValue.Replace("Seventh", "7th");
                ColumnValue = ColumnValue.Replace("Eigth", "8th");
                ColumnValue = ColumnValue.Replace("Ninth", "9th");
                ColumnValue = ColumnValue.Replace("Tenth", "10th");

                ColumnValue = ColumnValue.Replace("FIRST", "1st");
                ColumnValue = ColumnValue.Replace("SECOND", "2nd");
                ColumnValue = ColumnValue.Replace("THIRD", "3rd");
                ColumnValue = ColumnValue.Replace("FOURTH", "4th");
                ColumnValue = ColumnValue.Replace("FIFTH", "5th");
                ColumnValue = ColumnValue.Replace("SIXTH", "6th");
                ColumnValue = ColumnValue.Replace("SEVENTH", "7th");
                ColumnValue = ColumnValue.Replace("EIGHTH", "8th");
                ColumnValue = ColumnValue.Replace("NINTH", "9th");
                ColumnValue = ColumnValue.Replace("TENTH", "10th");

                ColumnValue = ColumnValue.Replace("1 Dan", "1st Dan");
                ColumnValue = ColumnValue.Replace("2 Dan", "2nd Dan");
                ColumnValue = ColumnValue.Replace("3 Dan", "3rd Dan");
                ColumnValue = ColumnValue.Replace("4 Dan", "4th Dan");
                ColumnValue = ColumnValue.Replace("5 Dan", "5th Dan");
                ColumnValue = ColumnValue.Replace("6 Dan", "6th Dan");
                ColumnValue = ColumnValue.Replace("7 Dan", "7th Dan");
                ColumnValue = ColumnValue.Replace("8 Dan", "8th Dan");
                ColumnValue = ColumnValue.Replace("9 Dan", "9th Dan");
                ColumnValue = ColumnValue.Replace("10 Dan", "10th Dan");

                ColumnValue = ColumnValue.Replace("1Dan", "1st Dan");
                ColumnValue = ColumnValue.Replace("2Dan", "2nd Dan");
                ColumnValue = ColumnValue.Replace("3Dan", "3rd Dan");
                ColumnValue = ColumnValue.Replace("4Dan", "4th Dan");
                ColumnValue = ColumnValue.Replace("5Dan", "5th Dan");
                ColumnValue = ColumnValue.Replace("6Dan", "6th Dan");
                ColumnValue = ColumnValue.Replace("7Dan", "7th Dan");
                ColumnValue = ColumnValue.Replace("8Dan", "8th Dan");
                ColumnValue = ColumnValue.Replace("9Dan", "9th Dan");
                ColumnValue = ColumnValue.Replace("10Dan", "10th Dan");

                // Now for Kyu grades
                ColumnValue = ColumnValue.Replace("kyu", "Kyu");
                ColumnValue = ColumnValue.Replace("KYU", "Kyu");

                ColumnValue = ColumnValue.Replace("1 Kyu", "1st Kyu");
                ColumnValue = ColumnValue.Replace("2 Kyu", "2nd Kyu");
                ColumnValue = ColumnValue.Replace("3 Kyu", "3rd Kyu");
                ColumnValue = ColumnValue.Replace("4 Kyu", "4th Kyu");
                ColumnValue = ColumnValue.Replace("5 Kyu", "5th Kyu");
                ColumnValue = ColumnValue.Replace("6 Kyu", "6th Kyu");

                ColumnValue = ColumnValue.Replace("1 kyu", "1st Kyu");
                ColumnValue = ColumnValue.Replace("2 kyu", "2nd Kyu");
                ColumnValue = ColumnValue.Replace("3 kyu", "3rd Kyu");
                ColumnValue = ColumnValue.Replace("4 kyu", "4th Kyu");
                ColumnValue = ColumnValue.Replace("5 kyu", "5th Kyu");
                ColumnValue = ColumnValue.Replace("6 kyu", "6th Kyu");

                ColumnValue = ColumnValue.Replace("1Kyu", "1st Kyu");
                ColumnValue = ColumnValue.Replace("2Kyu", "2nd Kyu");
                ColumnValue = ColumnValue.Replace("3Kyu", "3rd Kyu");
                ColumnValue = ColumnValue.Replace("4Kyu", "4th Kyu");
                ColumnValue = ColumnValue.Replace("5Kyu", "5th Kyu");
                ColumnValue = ColumnValue.Replace("6Kyu", "6th Kyu");

                ColumnValue = ColumnValue.Replace("1kyu", "1st Kyu");
                ColumnValue = ColumnValue.Replace("2kyu", "2nd Kyu");
                ColumnValue = ColumnValue.Replace("3kyu", "3rd Kyu");
                ColumnValue = ColumnValue.Replace("4kyu", "4th Kyu");
                ColumnValue = ColumnValue.Replace("5kyu", "5th Kyu");
                ColumnValue = ColumnValue.Replace("6kyu", "6th Kyu");

                // Hyphens must be replaced with slashes
                ColumnValue = ColumnValue.Replace(",", " / ");
                ColumnValue = ColumnValue.Replace("-", " / ");
                ColumnValue = ColumnValue.Replace("–", " / "); // <== This is the elongated "hyphen" from MS Word

                // Any slash may not have spaces around it like we expect
                ColumnValue = ColumnValue.Replace("/", " / ");
                ColumnValue = ColumnValue.Replace(@"\", " / ");

                // People also like to enter plus and ampersand
                ColumnValue = ColumnValue.Replace("+", " / ");
                ColumnValue = ColumnValue.Replace(@"&", " / ");

                // Sometimes they hit ? instead of /
                ColumnValue = ColumnValue.Replace("?", " / ");

                // We don't take Black tips into account
                ColumnValue = ColumnValue.ToLower().Replace("black tip", "");
                ColumnValue = ColumnValue.ToLower().Replace("blk tip", "");

                ColumnValue = ColumnValue.ToLower().Replace("blk", "black");

                if (ColumnValue.Contains("/") && ColumnValue.Contains("Black"))
                {
                    ColumnValue = ColumnValue.Replace("Black", "");
                    ColumnValue = ColumnValue.Replace("tip", "");
                    ColumnValue = ColumnValue.Replace("Tip", "");
                    ColumnValue = ColumnValue.Replace("TIP", "");
                    ColumnValue = ColumnValue.Replace("/", "");
                    ColumnValue = ColumnValue.Trim();
                }

                if (ColumnValue.Trim() == "/" || ColumnValue.Trim().ToLower() == "nil" || ColumnValue.Trim() == "?" || ColumnValue.Trim().ToLower() == "none")
                {
                    ColumnValue = "White";
                }

                // Replace any doubled-up instances of spaces with a single space
                while (ColumnValue.Contains("  "))
                {
                    ColumnValue = ColumnValue.Replace("  ", " ");
                }
            }

            #endregion

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    CommonResult1 = ((Belt)NewInstance).Name.CompareWith(ColumnValue);
                    CommonResult2 = ((Belt)NewInstance).Colour.CompareWith(ColumnValue);
                    CommonResult3 = ((Belt)NewInstance).Rank.CompareWith(ColumnValue.Replace(" ", "").Trim());

                    #region Compare 1 and 2

                    if (CommonResult1 >= CommonResult2)
                    {
                        TopResult1 = CommonResult1;
                    }
                    else if (CommonResult2 > CommonResult1)
                    {
                        TopResult1 = CommonResult2;
                    }
                    else if (double.IsNaN(CommonResult1) && double.IsNaN(CommonResult2))
                    {
                        TopResult1 = 0;
                    }
                    else if (double.IsNaN(CommonResult1))
                    {
                        TopResult1 = CommonResult2;
                    }
                    else if (double.IsNaN(CommonResult2))
                    {
                        TopResult1 = CommonResult1;
                    }

                    #endregion

                    #region Compare Highest of 1st and 2nd results with 3rd result

                    if (TopResult1 >= CommonResult3)
                    {
                        TopResult2 = TopResult1;
                    }
                    else if (CommonResult3 > TopResult1)
                    {
                        TopResult2 = CommonResult3;
                    }
                    else if (double.IsNaN(TopResult1) && double.IsNaN(CommonResult3))
                    {
                        TopResult2 = 0;
                    }
                    else if (double.IsNaN(TopResult1))
                    {
                        TopResult2 = CommonResult3;
                    }
                    else if (double.IsNaN(CommonResult3))
                    {
                        TopResult2 = TopResult1;
                    }

                    #endregion

                    if (TopResult2 >= Properties.Settings.Default.EuroJudoBeltValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, ((Belt)NewInstance).Name, TopResult2, EuroJudo.Column.Belt, (Belt)NewInstance, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, TopResult2, EuroJudo.Column.Belt, (Belt)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    TopResult2 = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, TopResult2, EuroJudo.Column.Belt, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, TopResult2, EuroJudo.Column.Belt, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private string MapFirstName(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            string NewInstance = "";
            double CommonResult = 0;

            if (ValueIndex == -1)
            {
                NewInstance = ColumnValue.Capitalise();
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (string)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((string)NewInstance)}");
            }

            CommonResult = 100;

            switch (TransformMethodType)
            {
                case MethodType.Value_Copy:
                    //ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, ((string)NewInstance), CommonResult, EuroJudo.Column.FirstName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.FirstName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    break;
                case MethodType.None:
                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, ((string)NewInstance), CommonResult, EuroJudo.Column.FirstName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.FirstName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private string MapLastName(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters)
        {
            string NewInstance = "";
            double CommonResult = 0;

            if (ValueIndex == -1)
            {
                NewInstance = ColumnValue.Capitalise();
                UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                NewInstance = (string)DatabaseValuesListbox.Items[ValueIndex];
                UpdateStatus($"Comparing {ColumnValue} with {((string)NewInstance)}");

            }

            CommonResult = 100;

            switch (TransformMethodType)
            {
                case MethodType.Value_Copy:
                    //ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, ((string)NewInstance), CommonResult, EuroJudo.Column.LastName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.LastName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    break;
                case MethodType.None:
                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, ((string)NewInstance), CommonResult, EuroJudo.Column.LastName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, EuroJudo.Column.LastName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        #endregion

        #region AddEuroJudo_x_ComparisonResult

        private void AddEuroJudoEventComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Event>> Mappings = new List<StringToObjectMapping<Event>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Event> ThisMapping = new StringToObjectMapping<Event>((string)Result.Value, Result.ValueIndex, (Event)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    EventMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Event ThisEvent = (Event)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisEvent.Name });
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                NewItem.Tag = TopResults;
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.Remove(ColumnValue);
            }
        }

        private void AddEuroJudoWeightCategoryComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<WeightCategory>> Mappings = new List<StringToObjectMapping<WeightCategory>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<WeightCategory> ThisMapping = new StringToObjectMapping<WeightCategory>((string)Result.Value, Result.ValueIndex, (WeightCategory)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    WeightCategoryMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    WeightCategory ThisWeightCategory = (WeightCategory)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
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

                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.BackColor = Color.LightGray;
                    }

                    NewItem.Tag = TopResults;

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);
                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoClubComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Club>> Mappings = new List<StringToObjectMapping<Club>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Club> ThisMapping = new StringToObjectMapping<Club>((string)Result.Value, Result.ValueIndex, (Club)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    ClubMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Club ThisClub = (Club)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisClub.ToString(), ThisClub.Code });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                if (lstImportedColumnValues.Items.Count >= ColumnIndex + 1)
                {
                    lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
                }
            }
        }

        private void AddEuroJudoMemberIDComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<string>> Mappings = new List<StringToObjectMapping<string>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<string> ThisMapping = new StringToObjectMapping<string>((string)Result.Value, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    MemberIDMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    string ThisMemberID = (string)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisMemberID });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoDayOfBirthComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<int>> Mappings = new List<StringToObjectMapping<int>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<int> ThisMapping = new StringToObjectMapping<int>((string)Result.Value, Result.ValueIndex, (int)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    DayOfBirthMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    int ThisDayOfBirth = (int)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisDayOfBirth.ToString() });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoMonthOfBirthComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<int>> Mappings = new List<StringToObjectMapping<int>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<int> ThisMapping = new StringToObjectMapping<int>((string)Result.Value, Result.ValueIndex, (int)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    MonthOfBirthMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    int ThisMonthOfBirth = (int)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisMonthOfBirth.ToString() });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoYearOfBirthComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<int>> Mappings = new List<StringToObjectMapping<int>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<int> ThisMapping = new StringToObjectMapping<int>((string)Result.Value, Result.ValueIndex, (int)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    YearOfBirthMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    int ThisYearOfBirth = (int)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisYearOfBirth.ToString() });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoGenderComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Gender>> Mappings = new List<StringToObjectMapping<Gender>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Gender> ThisMapping = null;

                if ((string)Result.Value != null)
                {
                    ThisMapping = new StringToObjectMapping<Gender>((string)Result.Value, Result.ValueIndex, (Gender)Result.Value, TransformType, TransformParameters);
                }
                else
                {
                    ThisMapping = new StringToObjectMapping<Gender>((string)Result.Value, Result.ValueIndex, Gender.Unknown, TransformType, TransformParameters);
                }

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    EuroJudoGenderMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Gender ThisGender = Gender.Unknown;

                    if (SelectedMethodType != MethodType.None)
                    {
                        ThisGender = (Gender)(TopResults[0].Value);

                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisGender.ToString() });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoBeltComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Belt>> Mappings = new List<StringToObjectMapping<Belt>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Belt> ThisMapping = new StringToObjectMapping<Belt>((string)Result.Value, Result.ValueIndex, (Belt)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    BeltMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Belt ThisBelt = (Belt)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisBelt.ToString(), ThisBelt.Name });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoFirstNameComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<string>> Mappings = new List<StringToObjectMapping<string>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<string> ThisMapping = new StringToObjectMapping<string>((string)Result.Value, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    FirstNameMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    string ThisFirstName = (string)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisFirstName });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoLastNameComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<string>> Mappings = new List<StringToObjectMapping<string>>();
            ListViewItem NewItem = null;
            Transform.MethodType TransformType = Transform.MethodType.None;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<string> ThisMapping = new StringToObjectMapping<string>((string)Result.Value, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);
                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    LastNameMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    string ThisLastName = (string)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisLastName });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
                    }
                    else
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = Color.LightGray;
                    }

                    break;
                default: // > 1
                    NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
                    NewItem.Tag = TopResults;
                    NewItem.BackColor = Color.LightSalmon;
                    break;
            }

            if (NewItem != null)
            {
                lvwDatabaseMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        //private void ClearValues()
        //{
        //    //cmbEuroJudoMappingType.Items.Clear();
        //    //cmbColumnNamesFromImportData.Items.Clear();
        //    //lvwDatabaseMappingResults.Items.Clear();

        //    GetSourceColumnNames(RevolutioniseSourceData, cmbColumnNamesFromImportData, lstImportedColumnValues);

        //    if (cmbEuroJudoMappingType.Items.Count > 0)
        //    {
        //        cmbEuroJudoMappingType.SelectedIndex = 0;
        //    }
        //}

        private void SetMappingType()
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            if (CurrentMappingType == EuroJudo.Column.Unknown) // (cmbEuroJudoMappingType.SelectedIndex == -1)
            {
                Debug.Print($"...Leaving {CurrentMethodName()}");
                return;
            }

            btnPreviousMappingType.Enabled = !(cmbEuroJudoMappingType.SelectedIndex == 0);
            btnNextMappingType.Enabled = !(cmbEuroJudoMappingType.SelectedIndex == cmbEuroJudoMappingType.Items.Count - 1);

            lstImportedColumnValues.Items.Clear();
            lstEuroJudoComparisonValue.Items.Clear();
            lvwDatabaseMappingResults.Items.Clear();

            lblMappingTypeHint.Text = "Step " + (cmbEuroJudoMappingType.SelectedIndex + 1).ToString() + " of " + cmbEuroJudoMappingType.Items.Count.ToString();

            switch (CurrentMappingType)
            {
                case EuroJudo.Column.Event:
                    trbComparisonMinimum.Enabled = true;
                    trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoEventValueMinimumComparison;

                    if (Properties.Settings.Default.LastEuroJudoEventTypeColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoEventTypeColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoEventTypeColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }
                    break;
                case EuroJudo.Column.WeightCategory:
                    trbComparisonMinimum.Enabled = true;
                    trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoWeightValueMinimumComparison;

                    if (Properties.Settings.Default.LastEuroJudoWeightCategoryColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoWeightCategoryColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoWeightCategoryColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }
                    break;
                case EuroJudo.Column.Club:
                    trbComparisonMinimum.Enabled = true;
                    trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoClubValueMinimumComparison;

                    if (Properties.Settings.Default.LastEuroJudoClubColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoClubColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoClubColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }
                    break;
                case EuroJudo.Column.MemberID:
                    trbComparisonMinimum.Value = 0;
                    trbComparisonMinimum.Enabled = false;
                    lblMinComparisonValue.Text = "-";

                    if (Properties.Settings.Default.LastEuroJudoMemberIDColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoMemberIDColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoMemberIDColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }

                    try
                    {

                        //if (Properties.Settings.Default.LastEuroJudoMemberIDTranslationType > -1)
                        //{
                        //    lvwTransformationType.Items[Properties.Settings.Default.LastEuroJudoMemberIDTranslationType].Selected = true;
                        //}
                        //else
                        //{

                        //}
                    }
                    catch
                    {
                    }

                    break;
                case EuroJudo.Column.DayOfBirth:
                    trbComparisonMinimum.Value = 0;
                    trbComparisonMinimum.Enabled = false;
                    lblMinComparisonValue.Text = "-";

                    if (Properties.Settings.Default.LastEuroJudoDayOfBirthColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoDayOfBirthColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoDayOfBirthColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }

                    //if (Properties.Settings.Default.LastEuroJudoDayOfBirthTranslationType > -1)
                    //{
                    //    lvwTransformationType.Items[Properties.Settings.Default.LastEuroJudoDayOfBirthTranslationType].Selected = true;
                    //}
                    //else
                    //{

                    //}

                    break;
                case EuroJudo.Column.MonthOfBirth:
                    trbComparisonMinimum.Value = 0;
                    trbComparisonMinimum.Enabled = false;
                    lblMinComparisonValue.Text = "-";

                    if (Properties.Settings.Default.LastEuroJudoMonthOfBirthColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoMonthOfBirthColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoMonthOfBirthColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }

                    //if (Properties.Settings.Default.LastEuroJudoMonthOfBirthTranslationType > -1)
                    //{
                    //    lvwTransformationType.Items[Properties.Settings.Default.LastEuroJudoMonthOfBirthTranslationType].Selected = true;
                    //}
                    //else
                    //{

                    //}

                    break;
                case EuroJudo.Column.YearOfBirth:
                    trbComparisonMinimum.Value = 0;
                    trbComparisonMinimum.Enabled = false;
                    lblMinComparisonValue.Text = "-";

                    if (Properties.Settings.Default.LastEuroJudoYearOfBirthColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoYearOfBirthColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoYearOfBirthColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }

                    //if (Properties.Settings.Default.LastEuroJudoYearOfBirthTranslationType > -1)
                    //{
                    //    lvwTransformationType.Items[Properties.Settings.Default.LastEuroJudoYearOfBirthTranslationType].Selected = true;
                    //}
                    //else
                    //{

                    //}

                    break;
                case EuroJudo.Column.Gender:
                    trbComparisonMinimum.Enabled = true;
                    trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoGenderValueMinimumComparison;

                    if (Properties.Settings.Default.LastEuroJudoGenderColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoGenderColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoGenderColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }
                    break;
                case EuroJudo.Column.Belt:
                    trbComparisonMinimum.Enabled = true;
                    trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoBeltValueMinimumComparison;

                    if (Properties.Settings.Default.LastEuroJudoBeltColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoBeltColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoBeltColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }
                    break;
                case EuroJudo.Column.FirstName:
                    trbComparisonMinimum.Value = 0;
                    trbComparisonMinimum.Enabled = false;
                    lblMinComparisonValue.Text = "-";

                    if (Properties.Settings.Default.LastEuroJudoFirstNameColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoFirstNameColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoFirstNameColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }

                    //if (Properties.Settings.Default.LastEuroJudoFirstNameTranslationType > -1)
                    //{
                    //    lvwTransformationType.Items[Properties.Settings.Default.LastEuroJudoFirstNameTranslationType].Selected = true;
                    //}
                    //else
                    //{

                    //}

                    break;
                case EuroJudo.Column.LastName:
                    trbComparisonMinimum.Value = 0;
                    trbComparisonMinimum.Enabled = false;
                    lblMinComparisonValue.Text = "-";

                    if (Properties.Settings.Default.LastEuroJudoLastNameColumnIndex != -1)
                    {
                        if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.LastEuroJudoLastNameColumnIndex + 1)
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.LastEuroJudoLastNameColumnIndex;
                        }
                    }
                    else
                    {
                        cmbColumnNamesFromImportData.SelectedIndex = -1;
                    }

                    //if (Properties.Settings.Default.LastEuroJudoLastNameTranslationType > -1)
                    //{
                    //    lvwTransformationType.Items[Properties.Settings.Default.LastEuroJudoLastNameTranslationType].Selected = true;
                    //}
                    //else
                    //{

                    //}

                    break;
            }

            GetEuroJudoComparisonData();

            EnableDisableAutoButton();

            string Value = "";

            if (lstImportedColumnValues.Items.Count == 0)
            {
                return;
            }

            if (lstImportedColumnValues.SelectedItem == null)
            {
                Value = lstImportedColumnValues.Items[0].ToString();
            }
            else
            {
                Value = lstImportedColumnValues.SelectedItem.ToString();
            }

        }

        private void EnableDisableSetButton()
        {
            //if (tabValueType.SelectedIndex == 0)
            //{
            btnManualSet.Enabled = (lstImportedColumnValues.SelectedIndices.Count > 0 && lstEuroJudoComparisonValue.SelectedIndices.Count == 1) ||
                                   lstImportedColumnValues.SelectedIndices.Count > 0 && radNone.Checked ||
                                   lstImportedColumnValues.SelectedIndices.Count > 0 && radCopyOrTranslate.Checked;
            //}
            //else
            //{
            //    btnManualSet.Enabled = (lvwTransformationType.SelectedIndices.Count == 1);
            //}
        }

        private void EnableDisableAutoButton()
        {
            //if (tabValueType.SelectedIndex == 0)
            //{
            btnAutoSet.Enabled = (lstImportedColumnValues.Items.Count > 0 && lstEuroJudoComparisonValue.Items.Count > 0);
            //}
            //else
            //{
            //    btnAutoSet.Enabled = false;
            //}
        }

        private void EnableDisableSave()
        {
            //tsbSave.Enabled = (EuroJudoEventMappings.Count > 0) && (EuroJudoWeightCategoryMappings.Count > 0) && (EuroJudoClubMappings.Count > 0);
            //saveToolStripMenuItem.Enabled = tsbSave.Enabled;
        }

        private void EnableDisableResetButton()
        {
            btnResetMappings.Enabled = lvwDatabaseMappingResults.Items.Count > 0;
        }

        private (MethodType, string[]) GetCurrentMethodTypeAndParameters()
        {
            MethodType Result = MethodType.None;
            string[] TransformParameters = { };

            if (radMapToDatabaseValue.Checked)
            {
                Result = MethodType.Database_Mapping;
            }
            else if (radCopyOrTranslate.Checked)
            {
                Result = MethodType.Value_Copy;
            }
            else if (radNone.Checked)
            {
                Result = MethodType.None;
            }
            //if (tabValueType.SelectedIndex == 0)
            //{
            //    Result = MethodType.None;
            //}
            //else
            //{
            //    if (radEuroJudoSimpleTranslation.Checked)
            //    {
            //        switch (lvwTransformationType.SelectedIndices[0])
            //        {
            //            case 0:
            //                Result = MethodType.None;
            //                TransformParameters = new string[] { };
            //                break;
            //            case 1:
            //                Result = MethodType.Value_RemoveAlphaChars;
            //                TransformParameters = new string[] { };
            //                break;
            //            case 2:
            //                Result = MethodType.Value_RemoveNumericChars;
            //                TransformParameters = new string[] { };
            //                break;
            //            case 3:
            //                Result = MethodType.Value_Lowercase;
            //                TransformParameters = new string[] { };
            //                break;
            //            case 4:
            //                Result = MethodType.Value_Uppercase;
            //                TransformParameters = new string[] { };
            //                break;
            //            case 5:
            //                Result = MethodType.Value_Capitalise;
            //                TransformParameters = new string[] { };
            //                break;
            //        }
            //    }
            //    else if (radEuroJudoCharacterTranslation.Checked)
            //    {
            //        switch (lvwTransformationType.SelectedIndices[0])
            //        {
            //            case 0:
            //                Result = MethodType.Character_RemoveChar;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 1:
            //                Result = MethodType.Length_RemoveLeftChars;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 2:
            //                Result = MethodType.Length_RemoveRightChars;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 3:
            //                Result = MethodType.Character_SwitchLeftTwoValues;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 4:
            //                Result = MethodType.Character_SwitchRightTwoValues;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 5:
            //                Result = MethodType.Character_SwitchLeftAndRightValues;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 6:
            //                Result = MethodType.Character_FirstValue;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 7:
            //                Result = MethodType.Character_SecondValue;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 8:
            //                Result = MethodType.Character_ThirdValue;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 9:
            //                Result = MethodType.Character_LeftTwoValues;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //            case 10:
            //                Result = MethodType.Character_RightTwoValues;
            //                TransformParameters = new string[] { txtEuroJudoTransformCharacter.Text };
            //                break;
            //        }
            //    }
            //    else if (radEuroJudoLengthTranslation.Checked)
            //    {
            //        switch (lvwTransformationType.SelectedIndices[0])
            //        {
            //            case 0:
            //                Result = MethodType.Length_RemoveLeftChars;
            //                TransformParameters = new string[] { nudEuroJudoTransformCount.Value.ToString() };
            //                break;
            //            case 1:
            //                Result = MethodType.Length_RemoveRightChars;
            //                TransformParameters = new string[] { nudEuroJudoTransformCount.Value.ToString() };
            //                break;
            //        }
            //    }
            //    else if (radEuroJudoSubstringTranslation.Checked)
            //    {
            //        switch (lvwTransformationType.SelectedIndices[0])
            //        {
            //            case 0:
            //                Result = MethodType.Substring_RemoveChars;
            //                TransformParameters = new string[] { nudEuroJudoTransformStart.Value.ToString(), nudEuroJudoTransformCount.Value.ToString() };
            //                break;
            //            case 1:
            //                Result = MethodType.Substring_ExtractChars;
            //                TransformParameters = new string[] { nudEuroJudoTransformStart.Value.ToString(), nudEuroJudoTransformCount.Value.ToString() };
            //                break;
            //        }
            //    }
            //}

            return (Result, TransformParameters);
        }

        private void UpdateStatus(string Text)
        {
            tslblMain.Text = Text;

            ssMain.Refresh();
        }

        //private void DoSave()
        //{
        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    #region Euro Judo - .xls

        //    // EuroJudo "Members & Clubs for Import.xls"
        //    string EuroJudoFilename = Properties.Settings.Default.EuroJudoExportFilename;

        //    try
        //    {
        //        using (FileStream fs = new FileStream(EuroJudoFilename, FileMode.Create, FileAccess.ReadWrite))
        //        {

        //            IWorkbook workbook = new HSSFWorkbook();

        //            ISheet sheet1 = workbook.CreateSheet("Regions");
        //            ISheet sheet2 = workbook.CreateSheet("Clubs");
        //            ISheet sheet3 = workbook.CreateSheet("Members");
        //            ISheet sheet4 = workbook.CreateSheet("Kyu & Dan");

        //            sheet1.SetZoom(85, 100); // 85%
        //            sheet2.SetZoom(85, 100); // 85%
        //            sheet3.SetZoom(85, 100); // 85%
        //            sheet4.SetZoom(85, 100); // 85%

        //            #region Build a font for the special characters

        //            IFont MonotypeSorts = workbook.CreateFont(); // MonotypeSorts
        //            MonotypeSorts.Color = HSSFColor.COLOR_NORMAL;
        //            MonotypeSorts.IsItalic = false;
        //            MonotypeSorts.Underline = FontUnderlineType.None;
        //            MonotypeSorts.FontHeightInPoints = 10;
        //            MonotypeSorts.FontName = "Monotype Sorts";

        //            //bind font with style 1
        //            ICellStyle MonotypeSortsStyle = workbook.CreateCellStyle();
        //            MonotypeSortsStyle.SetFont(MonotypeSorts);

        //            #endregion

        //            #region Regions Worksheet

        //            sheet1.SetCellValue(1, 0, "Abbreviation");
        //            sheet1.SetCellValue(1, 1, "C-4");
        //            sheet1.SetCellValue(2, 0, "Country");
        //            sheet1.SetCellValue(2, 1, "C-3");
        //            sheet1.SetCellValue(3, 0, "Region");
        //            sheet1.SetCellValue(3, 1, "C-30");

        //            #endregion

        //            #region Clubs Worksheet

        //            sheet2.SetCellValue(1, 0, "Club IdNr");
        //            sheet2.SetCellValue(1, 1, "N-9");
        //            sheet2.SetCellValue(2, 0, "Country Code");
        //            sheet2.SetCellValue(2, 1, "C-3");
        //            sheet2.SetCellValue(3, 0, "Region Id");
        //            sheet2.SetCellValue(3, 1, "C-4");

        //            sheet2.SetCellValue(4, 0, "Prefix");
        //            sheet2.SetCellValue(4, 1, "C-35");
        //            sheet2.SetCellValue(5, 0, "Clubname");
        //            sheet2.SetCellValue(5, 1, "C-35");
        //            sheet2.SetCellValue(6, 0, "Short");
        //            sheet2.SetCellValue(6, 1, "C-4");

        //            sheet2.SetCellValue(7, 0, "Person in Charge");
        //            sheet2.SetCellValue(7, 1, "C-30");
        //            sheet2.SetCellValue(8, 0, "Address");
        //            sheet2.SetCellValue(8, 1, "C-35");
        //            sheet2.SetCellValue(9, 0, "Zip code");
        //            sheet2.SetCellValue(9, 1, "C-15");

        //            sheet2.SetCellValue(10, 0, "City");
        //            sheet2.SetCellValue(10, 1, "C-30");
        //            sheet2.SetCellValue(11, 0, "Phone 1");
        //            sheet2.SetCellValue(11, 1, "C-20");
        //            sheet2.SetCellValue(12, 0, "Phone 2");
        //            sheet2.SetCellValue(12, 1, "C-20");

        //            sheet2.SetCellValue(13, 0, "Mobile");
        //            sheet2.SetCellValue(13, 1, "C-20");
        //            sheet2.SetCellValue(14, 0, "Fax");
        //            sheet2.SetCellValue(14, 1, "C-20");
        //            sheet2.SetCellValue(15, 0, "e-mail address");
        //            sheet2.SetCellValue(15, 1, "C-35");


        //            #endregion

        //            #region Members Worksheet

        //            for (int Column = 2; Column < 19; Column++)
        //            {
        //                sheet3.SetCellValue(Column, 0, Column + 1);
        //            }

        //            sheet3.SetCellValue(11, 0, "Competitor");
        //            sheet3.SetCellValue(11, 1, "Referee");
        //            sheet3.SetCellValue(11, 2, "Coach");
        //            sheet3.SetCellValue(11, 3, "Team-Official");
        //            sheet3.SetCellValue(11, 4, "Medic");
        //            sheet3.SetCellValue(11, 5, "Press");
        //            sheet3.SetCellValue(11, 6, "EJU/VIP");
        //            sheet3.SetCellValue(11, 7, "Organizer");

        //            for (int i = 0; i < 16; i++)
        //            {
        //                if (i < 6)
        //                {
        //                    sheet3.SetCellValue(18, i, (6 - i).Ordinal() + " kyu");
        //                }
        //                else
        //                {
        //                    sheet3.SetCellValue(18, i, (i - 5).Ordinal() + " dan");
        //                }
        //            }

        //            sheet3.SetCellValue(1, 16, "Member nr");
        //            sheet3.SetCellValue(2, 16, "Club IdNr");
        //            sheet3.SetCellValue(3, 16, "Clubname");
        //            sheet3.SetCellValue(4, 16, "Club Short");
        //            sheet3.SetCellValue(5, 16, "First Name");
        //            sheet3.SetCellValue(6, 16, "Suffix");
        //            sheet3.SetCellValue(7, 16, "Last Name");
        //            sheet3.SetCellValue(8, 16, "Genus");
        //            sheet3.SetCellValue(9, 16, "Date of Birth");
        //            sheet3.SetCellValue(10, 16, "Year of Birth");
        //            sheet3.SetCellValue(11, 16, "Function");
        //            sheet3.SetCellValue(12, 16, "Event Nr");
        //            sheet3.SetCellValue(13, 16, "Weight cat.");
        //            sheet3.SetCellValue(14, 16, "Weight");
        //            sheet3.SetCellValue(15, 16, "Citizenship");
        //            sheet3.SetCellValue(16, 16, "Seeding");
        //            sheet3.SetCellValue(17, 16, "DrawNr");
        //            sheet3.SetCellValue(18, 16, "Kyu");

        //            sheet3.SetCellValue(1, 17, "C-50");
        //            sheet3.SetCellValue(2, 17, "N-9");
        //            sheet3.SetCellValue(3, 17, "C-35");
        //            sheet3.SetCellValue(4, 17, "C-4");
        //            sheet3.SetCellValue(5, 17, "C-25");
        //            sheet3.SetCellValue(6, 17, "C-15");
        //            sheet3.SetCellValue(7, 17, "C-25");
        //            sheet3.SetCellValue(8, 17, "M/F");
        //            sheet3.SetCellValue(9, 17, "dd-mm");
        //            sheet3.SetCellValue(10, 17, "yyyy");
        //            sheet3.SetCellValue(11, 17, "C-20");
        //            sheet3.SetCellValue(12, 17, "N-2");
        //            sheet3.SetCellValue(13, 17, "C-7");
        //            sheet3.SetCellValue(14, 17, "N3.1");
        //            sheet3.SetCellValue(15, 17, "C-3");
        //            sheet3.SetCellValue(16, 17, "C-2");
        //            sheet3.SetCellValue(17, 17, "N-3");
        //            sheet3.SetCellValue(18, 17, "C-35");

        //            #endregion

        //            #region Kyu & Dan Worksheet

        //            sheet4.SetCellValue(0, 0, "Kyu or Dan");
        //            sheet4.SetCellValue(1, 0, "Reference");
        //            sheet4.SetCellValue(0, 1, "C-4");
        //            sheet4.SetCellValue(1, 1, "");


        //            for (int i = 2; i < 18; i++)
        //            {
        //                if (i < 8)
        //                {
        //                    sheet4.SetCellValue(0, i, (8 - i).Ordinal() + " kyu");
        //                }
        //                else
        //                {
        //                    sheet4.SetCellValue(0, i, (i - 7).Ordinal() + " dan");
        //                }

        //                sheet4.SetCellValue(1, i, (i - 1));

        //            }

        //            #endregion

        //            // Loop through all players
        //            foreach (DataRow Row in RevolutioniseSourceData.Rows)
        //            {

        //            }

        //            //sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
        //            //int rowIndex = 0;
        //            //IRow row = sheet1.CreateRow(rowIndex);
        //            //row.Height = 30 * 80;
        //            //row.CreateCell(0).SetCellValue("this is content");
        //            //sheet1.AutoSizeColumn(0);
        //            //rowIndex++;


        //            //ICellStyle style1 = workbook.CreateCellStyle();
        //            //style1.FillForegroundColor = HSSFColor.Blue.Index2;
        //            //style1.FillPattern = FillPattern.SolidForeground;

        //            //ICellStyle style2 = workbook.CreateCellStyle();
        //            //style2.FillForegroundColor = HSSFColor.Yellow.Index2;
        //            //style2.FillPattern = FillPattern.SolidForeground;

        //            //ICell cell2 = sheet2.CreateRow(0).CreateCell(0);
        //            //cell02.CellStyle = style1;
        //            //cell02.SetCellValue(0);

        //            //cell02 = sheet2.CreateRow(1).CreateCell(0);
        //            //cell02.CellStyle = style2;
        //            //cell02.SetCellValue(1);

        //            workbook.Write(fs);

        //        }
        //    }
        //    catch (UnauthorizedAccessException e)
        //    {
        //    }
        //    catch (Exception e)
        //    {
        //    }

        //    #endregion


        //    #region IJF - .csv



        //    #endregion
        //}

        #endregion

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

        //    UpdateStatus($"Load complete: {ClubSourceData.Rows.Count} rows loaded";
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

        //            UpdateStatus($"Comparing {ColumnValue} with {ThisEvent.Name}";

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


    }
}
