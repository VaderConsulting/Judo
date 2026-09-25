using EuroJudo;

using Judo;

using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Utilities;

using static NPOIHelper.Extensions;
using static Utilities.Extensions;
using static Utilities.Transform;

namespace MappingTool
{
    public partial class frmMapping : Form
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        public enum MappingMode
        {
            None,
            Euro_Judo,
            IJF,
            EuroJudo_And_IJF
        }

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private MappingMode _MappingMode = MappingMode.None;

        private DataTable _CountrySourceData = new DataTable();
        private DataTable _SubDivisionSourceData = new DataTable();
        private DataTable _RevolutioniseSourceData = new DataTable();
        private DataTable _ClubSourceData = new DataTable();

        private List<Country> _Countries = new List<Country>();
        private List<SubDivision> _SubDivisions = new List<SubDivision>();
        private List<Tournament> _EuroJudoTournaments = new List<Tournament>();
        private List<Tournament> _IJFTournaments = new List<Tournament>();

        private List<Event> _EJEvents = new List<Event>();
        private List<EuroJudo.WeightCategory> _WeightCategories = new List<EuroJudo.WeightCategory>();
        private List<Club> _Clubs = new List<Club>();
        private List<Belt> _Belts = new List<Belt>();

        private List<StringToObjectMapping<Event>> _EventMappings = new List<StringToObjectMapping<Event>>();
        private List<StringToObjectMapping<EuroJudo.WeightCategory>> _EuroJudoWeightCategoryMappings = new List<StringToObjectMapping<EuroJudo.WeightCategory>>();
        private List<StringToObjectMapping<Judo.WeightCategory>> _IJFWeightCategoryMappings = new List<StringToObjectMapping<Judo.WeightCategory>>();
        private List<StringToObjectMapping<Club>> _ClubMappings = new List<StringToObjectMapping<Club>>();
        private List<StringToObjectMapping<string>> _MemberIDMappings = new List<StringToObjectMapping<string>>();
        private List<StringToObjectMapping<DateTime>> _DateOfBirthMappings = new List<StringToObjectMapping<DateTime>>();
        private List<StringToObjectMapping<Judo.Gender>> _GenderMappings = new List<StringToObjectMapping<Judo.Gender>>();
        private List<StringToObjectMapping<Belt>> _BeltMappings = new List<StringToObjectMapping<Belt>>();
        private List<StringToObjectMapping<string>> _LastNameMappings = new List<StringToObjectMapping<string>>();
        private List<StringToObjectMapping<string>> _FirstNameMappings = new List<StringToObjectMapping<string>>();
        private List<StringToObjectMapping<EuroJudo.Function>> _EuroJudoFunctionMappings = new List<StringToObjectMapping<EuroJudo.Function>>();
        private List<StringToObjectMapping<IJF.Function>> _IJFFunctionMappings = new List<StringToObjectMapping<IJF.Function>>();
        private List<StringToObjectMapping<string>> _IJFPhotoMappings = new List<StringToObjectMapping<string>>();

        private Tournament _SelectedEuroJudoTournament = null;
        private Tournament _SelectedIJFTournament = null;
        private Judo.DataColumnType _CurrentMappingType = Judo.DataColumnType.Unknown;
        private Judo.DataColumnType _PreviousMappingType = Judo.DataColumnType.Unknown;
        private int _MappingMultipleItemCount = 0;

        private frmDataInfo _DataInfoForm = new frmDataInfo();
        private bool _PersonFirstNameMapped = false;
        private bool _PersonSurnameMapped = false;
        private bool _PersonGenderMapped = false;
        private bool _PersonDateOfBirthMapped = false;
        private bool _PersonClubMapped = false;

        //private bool InitialLoadComplete = false;
        //private bool TournamentLoaded = false;

        //private bool EventSourceLoaded = false;
        //private bool WeightSourceLoaded = false;
        //private bool ClubSourceLoaded = false;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmMapping(MappingMode Mode, DataTable SourceData, List<Club> ClubData, List<Belt> BeltData, List<Country> CountryData, List<SubDivision> SubDivisionData)
        {
            InitializeComponent();

            _MappingMode = Mode;

            _RevolutioniseSourceData = SourceData;
            _Clubs = ClubData;
            _Belts = BeltData;
            _Countries = CountryData;
            _SubDivisions = SubDivisionData;

        }

        #endregion

        #region Event Handlers

        private void frmMapping_Load(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            switch (_MappingMode)
            {
                case MappingMode.None:
                    // Should never happen
                    break;
                case MappingMode.Euro_Judo:
                    // Start at 0 because we don't want "Unknown"
                    for (int i = 0; i < Enum.GetValues(typeof(Judo.DataColumnType)).Length - 1; i++)
                    {
                        string ThisEnumName = Enum.GetName(typeof(Judo.DataColumnType), i);

                        if (!ThisEnumName.StartsWith("IJF"))
                        {
                            cmbMappingType.Items.Add(ThisEnumName);
                        }
                    }
                    break;
                case MappingMode.IJF:
                    // Start at 0 because we don't want "Unknown"
                    for (int i = 0; i < Enum.GetValues(typeof(Judo.DataColumnType)).Length - 1; i++)
                    {
                        string ThisEnumName = Enum.GetName(typeof(Judo.DataColumnType), i);

                        if (!ThisEnumName.StartsWith("EuroJudo"))
                        {
                            cmbMappingType.Items.Add(ThisEnumName);
                        }
                    }
                    break;
                case MappingMode.EuroJudo_And_IJF:
                    // Start at 0 because we don't want "Unknown"
                    for (int i = 0; i < Enum.GetValues(typeof(Judo.DataColumnType)).Length - 1; i++)
                    {
                        string ThisEnumName = Enum.GetName(typeof(Judo.DataColumnType), i);

                        cmbMappingType.Items.Add(ThisEnumName);
                    }
                    break;
            }

            btnPreviousMappingType.Enabled = false;
            btnNextMappingType.Enabled = true;

        }

        private void frmMapping_Shown(object sender, EventArgs e)
        {
            bool Result = false;

            switch (_MappingMode)
            {
                case MappingMode.None:
                    // Should never happen
                    break;
                case MappingMode.Euro_Judo:
                    cmbEuroJudoTournamentName.Enabled = true;
                    cmbIJFTournamentName.Enabled = false;

                    Result = SetupMappingForEuroJudo();

                    break;
                case MappingMode.IJF:
                    cmbEuroJudoTournamentName.Enabled = false;
                    cmbIJFTournamentName.Enabled = true;

                    Result = SetupMappingForIJF();

                    break;
                case MappingMode.EuroJudo_And_IJF:
                    cmbEuroJudoTournamentName.Enabled = true;
                    cmbIJFTournamentName.Enabled = true;

                    Result = SetupMappingForEuroJudo() && SetupMappingForIJF();

                    break;
            }

            if (Result)
            {
                DoStartup();
                btnExport.Enabled = true;
            }
            else
            {

            }
        }

        private void frmMapping_Move(object sender, EventArgs e)
        {
            SetDataInfoLocation();
        }

        private void frmMapping_Resize(object sender, EventArgs e)
        {
            SetDataInfoLocation();
        }

        private void frmMapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            _DataInfoForm.Close();
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

            if (radNone.Checked)
            {
                DialogResult dResult = MessageBox.Show("Do you really want to set all values to [NONE]?", "Confirmation required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dResult == DialogResult.No)
                {
                    radCopyOrTranslate.Checked = true;
                }
            }

            MapValuesAutomatically(lstImportedColumnValues, lstComparisonValue, lvwMappingResults, _CurrentMappingType);
            EnableDisableSave();

            EnableDisableResetButton();

            EnableDisablePrevNextButtons();

            EnableDisableAutoButton();

            Cursor.Current = Cursors.Default;
        }

        private void btnPreviousMappingType_Click(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            if (cmbMappingType.SelectedIndex > 0)
            {
                cmbMappingType.SelectedIndex--;
            }
        }

        private void btnNextMappingType_Click(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            if (cmbMappingType.SelectedIndex < cmbMappingType.Items.Count - 1)
            {
                cmbMappingType.SelectedIndex++;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            DoSave();

            DoPhotos();
        }

        private void btnResetMappings_Click(object sender, EventArgs e)
        {
            if (_CurrentMappingType != Judo.DataColumnType.Unknown)
            {
                _MappingMultipleItemCount = 0;

                EnableDisablePrevNextButtons();
                ResetCurrentMappings();
                SetMappingType();
            }

            EnableDisableAutoButton();
        }

        private void btnManualSet_Click(object sender, EventArgs e)
        {
            List<int> SelectedIndices = new List<int>();
            MethodType SelectedMethodType = MethodType.Unknown;
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
                int DatabaseValueIndex = lstComparisonValue.SelectedIndex;
                bool AllowInTransformEdits = false;

                (SelectedMethodType, TransformParameters, AllowInTransformEdits) = GetCurrentMethodTypeAndParameters();

                if (SelectedMethodType == MethodType.Unknown)
                {
                    return;
                }

                switch (_CurrentMappingType)
                {
                    case DataColumnType.Unknown:
                        break;
                    case Judo.DataColumnType.EuroJudo_Event:
                        {
                            MapEvent(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                        {
                            MapEuroJudoWeightCategory(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.IJF_WeightCategory:
                        {
                            MapIJFWeightCategory(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.Club:
                        {
                            MapClub(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.MemberID:
                        {
                            MapMemberID(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.DateOfBirth:
                        {
                            MapDateOfBirth(lstImportedColumnValues, lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.Gender:
                        {
                            MapGender(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.EuroJudo_Belt:
                        {
                            MapBelt(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.FirstName:
                        {
                            MapFirstName(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.Surname:
                        {
                            MapLastName(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.EuroJudo_Function:
                        {
                            MapEuroJudoFunction(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case Judo.DataColumnType.IJF_Function:
                        {
                            MapIJFFunction(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                    case DataColumnType.IJF_Photo:
                        {
                            MapPhoto(lstComparisonValue, ColumnIndex - SelectedItemIndex, ValueResults, ColumnValue, DatabaseValueIndex, true, SelectedMethodType, TransformParameters, AllowInTransformEdits);

                            break;
                        }
                }

                if (ValueResults.Count > 0)
                {
                    switch (_CurrentMappingType)
                    {
                        case Judo.DataColumnType.EuroJudo_Event:
                            AddEventComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, Properties.Settings.Default.EuroJudoEventValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.EuroJudo_WeightCategory:
                            AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.IJF_WeightCategory:
                            AddIJFWeightCategoryComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.Club:
                            AddClubComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, Properties.Settings.Default.EuroJudoClubValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.MemberID:
                            AddMemberIDComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.DateOfBirth:
                            AddDateOfBirthComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;

                        case Judo.DataColumnType.Gender:
                            AddGenderComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, Properties.Settings.Default.EuroJudoGenderValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.EuroJudo_Belt:
                            AddBeltComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, Properties.Settings.Default.BeltValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.FirstName:
                            AddFirstNameComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.Surname:
                            AddLastNameComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.EuroJudo_Function:
                            AddEuroJudoFunctionComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, Properties.Settings.Default.EuroJudoFunctionValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.IJF_Function:
                            AddIJFFunctionComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, Properties.Settings.Default.EuroJudoFunctionValueMinimumComparison, SelectedMethodType, TransformParameters);

                            break;
                        case Judo.DataColumnType.IJF_Photo:
                            AddPhotoComparisonResults(ColumnValue, ColumnIndex - SelectedItemIndex, ValueResults, 0, SelectedMethodType, TransformParameters);

                            break;
                    }
                }
            }

            EnableDisableSave();

            EnableDisableResetButton();

            EnableDisablePrevNextButtons();
        }

        private void btnClearColumnSelection_Click(object sender, EventArgs e)
        {
            cmbColumnNamesFromImportData.SelectedIndex = -1;
            lstImportedColumnValues.Items.Clear();
        }

        #endregion

        #region Combo-boxes

        private void cmbEuroJudoTournamentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            _SelectedEuroJudoTournament = (Tournament)cmbEuroJudoTournamentName.SelectedItem;

            Properties.Settings.Default.PreviousEuroJudoTournament = _SelectedEuroJudoTournament.Name;
            Properties.Settings.Default.Save();
        }

        private void cmbIJFTournamentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            _SelectedIJFTournament = (Tournament)cmbIJFTournamentName.SelectedItem;

            Properties.Settings.Default.PreviousIJFTournament = _SelectedIJFTournament.Name;
            Properties.Settings.Default.Save();
        }

        private void cmbMappingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            if (cmbMappingType.SelectedIndex > -1)
            {
                _PreviousMappingType = _CurrentMappingType;
                _CurrentMappingType = (Judo.DataColumnType)Enum.Parse(typeof(Judo.DataColumnType), cmbMappingType.Text);

                SetMappingType();
            }

            EnableDisableSetAndAutoButtons();
            EnableDisablePrevNextButtons();
        }

        private void cmbColumnNamesFromImportData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            switch (_CurrentMappingType)
            {
                case Judo.DataColumnType.Unknown:
                    break;
                case Judo.DataColumnType.EuroJudo_Event:
                    Properties.Settings.Default.PreviousEuroJudoEventTypeColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.EuroJudo_WeightCategory:
                    Properties.Settings.Default.PreviousEuroJudoWeightCategoryColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case DataColumnType.IJF_WeightCategory:
                    Properties.Settings.Default.PreviousIJFWeightCategoryColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.Club:
                    Properties.Settings.Default.PreviousClubColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.MemberID:
                    Properties.Settings.Default.PreviousMemberIDColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.DateOfBirth:
                    Properties.Settings.Default.PreviousDateOfBirthColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.Gender:
                    Properties.Settings.Default.PreviousGenderColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.EuroJudo_Belt:
                    Properties.Settings.Default.PreviousBeltColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.FirstName:
                    Properties.Settings.Default.PreviousFirstNameColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.Surname:
                    Properties.Settings.Default.PreviousSurnameColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case Judo.DataColumnType.EuroJudo_Function:
                    Properties.Settings.Default.PreviousEuroJudoFunctionColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case DataColumnType.IJF_Function:
                    Properties.Settings.Default.PreviousIJFFunctionColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
                case DataColumnType.IJF_Photo:
                    Properties.Settings.Default.PreviousIJFPhotoColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                    break;
            }

            Properties.Settings.Default.Save();

            if (cmbColumnNamesFromImportData.SelectedIndex > -1)
            {
                GetSourceColumnValues(_RevolutioniseSourceData, cmbColumnNamesFromImportData.SelectedIndex, lstImportedColumnValues);
            }

            EnableDisableAutoButton();

        }

        #endregion

        private void lvwMappingResults_DoubleClick(object sender, EventArgs e)
        {
            frmShowMapping MappingForm = null;
            ListViewItem SelectedItem = null;
            ComparisonResult Result = null;
            StringToObjectMapping<Event> EventMapping = null;
            StringToObjectMapping<EuroJudo.WeightCategory> EuroJudoWeightCategoryMapping = null;
            StringToObjectMapping<Judo.WeightCategory> IJFWeightCategoryMapping = null;
            StringToObjectMapping<Club> ClubMapping = null;
            StringToObjectMapping<string> MemberIDMapping = null;
            StringToObjectMapping<DateTime> DateOfBirthMapping = null;
            StringToObjectMapping<Judo.Gender> GenderMapping = null;
            StringToObjectMapping<Belt> BeltMapping = null;
            StringToObjectMapping<string> LastNameMapping = null;
            StringToObjectMapping<string> FirstNameMapping = null;
            StringToObjectMapping<EuroJudo.Function> EuroJudoFunctionMapping = null;
            StringToObjectMapping<IJF.Function> IJFFunctionMapping = null;
            Transform.MethodType TransformType = Transform.MethodType.Database_Mapping;
            StringToObjectMapping<string> PhotoMapping = null;
            int SelectedItemIndex = -1;
            string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            SelectedItem = lvwMappingResults.SelectedItems[0];
            SelectedItemIndex = lvwMappingResults.SelectedItems[0].Index;

            if (SelectedItem.Tag == null)
            {
                // This will happen for previous mapping results
            }

            MappingForm = new frmShowMapping((List<ComparisonResult>)SelectedItem.Tag);

            DialogResult FormResult = MappingForm.ShowDialog();

            if (FormResult == DialogResult.OK)
            {
                Result = MappingForm.SelectedComparisonResult;

                _MappingMultipleItemCount -= 1;
                EnableDisablePrevNextButtons();

                ListViewItem NewItem = null;

                switch (MappingForm.SelectedComparisonResult.MapType)
                {
                    case Judo.DataColumnType.Unknown:
                        break;
                    case Judo.DataColumnType.EuroJudo_Event:
                        {
                            if (Result.Value != null)
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, ((Event)(Result.Value)).Name, ((Event)(Result.Value)).Index.ToString() });

                                TransformType = Transform.MethodType.Database_Mapping;

                                EventMapping = new StringToObjectMapping<Event>(Result.SourceValue, Result.ValueIndex, (Event)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, "[NONE]", "[NONE]" });

                                TransformType = Transform.MethodType.None;

                                EventMapping = new StringToObjectMapping<Event>(Result.SourceValue, Result.ValueIndex, (Event)Result.Value, TransformType, TransformParameters);
                            }

                            if (_EventMappings.Any(x => x.Approximates(EventMapping)))
                            {
                                StringToObjectMapping<Event> MappingToRemove = _EventMappings.Find(x => x.DestinationObject.Name == EventMapping.DestinationObject.Name);
                                _EventMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                        {
                            if (Result.Value != null)
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, ((EuroJudo.WeightCategory)(Result.Value)).Name, ((EuroJudo.WeightCategory)(Result.Value)).Event.Index.ToString() });
                                EuroJudoWeightCategoryMapping = new StringToObjectMapping<EuroJudo.WeightCategory>(Result.SourceValue, Result.ValueIndex, (EuroJudo.WeightCategory)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, "[NONE]" });
                                EuroJudoWeightCategoryMapping = new StringToObjectMapping<EuroJudo.WeightCategory>(Result.SourceValue, Result.ValueIndex, (EuroJudo.WeightCategory)Result.Value, TransformType, TransformParameters);
                            }

                            if (_EuroJudoWeightCategoryMappings.Any(x => x.Approximates(EuroJudoWeightCategoryMapping)))
                            {
                                StringToObjectMapping<EuroJudo.WeightCategory> MappingToRemove = _EuroJudoWeightCategoryMappings.Find(x => x.DestinationObject.Name == EventMapping.DestinationObject.Name);
                                _EuroJudoWeightCategoryMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.IJF_WeightCategory:
                        {
                            if (Result.Value != null)
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, ((Judo.WeightCategory)(Result.Value)).Name });
                                IJFWeightCategoryMapping = new StringToObjectMapping<Judo.WeightCategory>(Result.SourceValue, Result.ValueIndex, (Judo.WeightCategory)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, "[NONE]" });
                                IJFWeightCategoryMapping = new StringToObjectMapping<Judo.WeightCategory>(Result.SourceValue, Result.ValueIndex, (Judo.WeightCategory)Result.Value, TransformType, TransformParameters);
                            }

                            if (_IJFWeightCategoryMappings.Any(x => x.Approximates(IJFWeightCategoryMapping)))
                            {
                                StringToObjectMapping<Judo.WeightCategory> MappingToRemove = _IJFWeightCategoryMappings.Find(x => x.DestinationObject.Name == IJFWeightCategoryMapping.DestinationObject.Name);
                                _IJFWeightCategoryMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.Club:
                        {
                            if (Result.Value != null)
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, ((Club)(Result.Value)).ToString(), ((Club)(Result.Value)).Code });
                                ClubMapping = new StringToObjectMapping<Club>(Result.SourceValue, Result.ValueIndex, (Club)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                Club NoClub = _Clubs.Where(c => c.ID == 0).First();

                                NewItem = new ListViewItem(new string[] { Result.SourceValue, NoClub.Name, NoClub.Code });
                                ClubMapping = new StringToObjectMapping<Club>(Result.SourceValue, Result.ValueIndex, null, TransformType, TransformParameters);
                            }

                            if (_ClubMappings.Any(x => x.Approximates(ClubMapping)))
                            {
                                StringToObjectMapping<Club> MappingToRemove = _ClubMappings.Find(x => x.DestinationObject.Name == ClubMapping.DestinationObject.Name);
                                _ClubMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.MemberID:
                        {
                            NewItem = new ListViewItem(new string[] { Result.SourceValue, ((string)(Result.Value)).ToString(), (string)(Result.Value) });
                            MemberIDMapping = new StringToObjectMapping<string>(Result.SourceValue, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                            if (_MemberIDMappings.Any(x => x.Approximates(MemberIDMapping)))
                            {
                                StringToObjectMapping<string> MappingToRemove = _MemberIDMappings.Find(x => x.DestinationObject == MemberIDMapping.DestinationObject);
                                _MemberIDMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.DateOfBirth:
                        {
                            NewItem = new ListViewItem(new string[] { Result.SourceValue, Result.Value.ToString(), Result.Value.ToString() });
                            DateOfBirthMapping = new StringToObjectMapping<DateTime>(Result.SourceValue, Result.ValueIndex, (DateTime)Result.Value, TransformType, TransformParameters);

                            if (_DateOfBirthMappings.Any(c => c.Approximates(DateOfBirthMapping)))
                            {
                                StringToObjectMapping<DateTime> MappingToRemove = _DateOfBirthMappings.Find(x => x.DestinationObject == DateOfBirthMapping.DestinationObject);
                                _DateOfBirthMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.Gender:
                        {
                            if (Result.TransformMethod != MethodType.None)
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, ((Judo.Gender)(Result.Value)).ToString(), ((Judo.Gender)(Result.Value)).ToString() });
                                GenderMapping = new StringToObjectMapping<Judo.Gender>(Result.SourceValue, Result.ValueIndex, (Judo.Gender)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { "", "[NONE]" });
                                GenderMapping = new StringToObjectMapping<Judo.Gender>(Result.SourceValue, Result.ValueIndex, Judo.Gender.Unknown, TransformType, TransformParameters);
                            }

                            if (_GenderMappings.Any(c => c.Approximates(GenderMapping)))
                            {
                                StringToObjectMapping<Judo.Gender> MappingToRemove = _GenderMappings.Find(x => x.DestinationObject == GenderMapping.DestinationObject);
                                _GenderMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.EuroJudo_Belt:
                        {
                            NewItem = new ListViewItem(new string[] { Result.SourceValue, ((Belt)(Result.Value)).ToString(), ((Belt)(Result.Value)).Rank });
                            BeltMapping = new StringToObjectMapping<Belt>(Result.SourceValue, Result.ValueIndex, (Belt)Result.Value, TransformType, TransformParameters);

                            if (_BeltMappings.Any(c => c.Approximates(BeltMapping)))
                            {
                                StringToObjectMapping<Judo.Belt> MappingToRemove = _BeltMappings.Find(x => x.DestinationObject.Colour == BeltMapping.DestinationObject.Colour);
                                _BeltMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.Surname:
                        {
                            NewItem = new ListViewItem(new string[] { Result.SourceValue, ((string)(Result.Value)).ToString(), ((string)(Result.Value)) });
                            LastNameMapping = new StringToObjectMapping<string>(Result.SourceValue, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                            if (_LastNameMappings.Any(c => c.Approximates(LastNameMapping)))
                            {
                                StringToObjectMapping<string> MappingToRemove = _LastNameMappings.Find(x => x.DestinationObject == LastNameMapping.DestinationObject);
                                _LastNameMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.FirstName:
                        {
                            NewItem = new ListViewItem(new string[] { Result.SourceValue, ((string)(Result.Value)).ToString(), ((string)(Result.Value)) });
                            FirstNameMapping = new StringToObjectMapping<string>(Result.SourceValue, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                            if (_FirstNameMappings.Any(c => c.Approximates(FirstNameMapping)))
                            {
                                StringToObjectMapping<string> MappingToRemove = _FirstNameMappings.Find(x => x.DestinationObject == FirstNameMapping.DestinationObject);
                                _FirstNameMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.EuroJudo_Function:
                        {
                            if (Result.TransformMethod != MethodType.None)
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, ((EuroJudo.Function)(Result.Value)).ToString(), ((EuroJudo.Function)(Result.Value)).ToString() });
                                EuroJudoFunctionMapping = new StringToObjectMapping<EuroJudo.Function>(Result.SourceValue, Result.ValueIndex, (EuroJudo.Function)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { "", "[NONE]" });
                                EuroJudoFunctionMapping = new StringToObjectMapping<EuroJudo.Function>(Result.SourceValue, Result.ValueIndex, EuroJudo.Function.Unknown, TransformType, TransformParameters);
                            }

                            if (_EuroJudoFunctionMappings.Any(c => c.Approximates(EuroJudoFunctionMapping)))
                            {
                                StringToObjectMapping<EuroJudo.Function> MappingToRemove = _EuroJudoFunctionMappings.Find(x => x.DestinationObject == EuroJudoFunctionMapping.DestinationObject);
                                _EuroJudoFunctionMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.IJF_Function:
                        {
                            if (Result.TransformMethod != MethodType.None)
                            {
                                NewItem = new ListViewItem(new string[] { Result.SourceValue, ((IJF.Function)(Result.Value)).ToString(), ((IJF.Function)(Result.Value)).ToString() });
                                IJFFunctionMapping = new StringToObjectMapping<IJF.Function>(Result.SourceValue, Result.ValueIndex, (IJF.Function)Result.Value, TransformType, TransformParameters);
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { "", "[NONE]" });
                                IJFFunctionMapping = new StringToObjectMapping<IJF.Function>(Result.SourceValue, Result.ValueIndex, IJF.Function.Unknown, TransformType, TransformParameters);
                            }

                            if (_IJFFunctionMappings.Any(c => c.Approximates(IJFFunctionMapping)))
                            {
                                StringToObjectMapping<IJF.Function> MappingToRemove = _IJFFunctionMappings.Find(x => x.DestinationObject == IJFFunctionMapping.DestinationObject);
                                _IJFFunctionMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                    case Judo.DataColumnType.IJF_Photo:
                        {
                            NewItem = new ListViewItem(new string[] { Result.SourceValue, ((string)(Result.Value)).ToString(), ((string)(Result.Value)) });
                            PhotoMapping = new StringToObjectMapping<string>(Result.SourceValue, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                            if (_IJFPhotoMappings.Any(c => c.Approximates(PhotoMapping)))
                            {
                                StringToObjectMapping<string> MappingToRemove = _IJFPhotoMappings.Find(x => x.DestinationObject == PhotoMapping.DestinationObject);
                                _IJFPhotoMappings.Remove(MappingToRemove);
                            }

                            break;
                        }
                }

                List<ComparisonResult> NewTag = new List<ComparisonResult>();
                NewTag.Add(MappingForm.SelectedComparisonResult);

                NewItem.Tag = NewTag;
                NewItem.BackColor = lvwMappingResults.BackColor;

                lvwMappingResults.Items.RemoveAt(SelectedItemIndex);
                lvwMappingResults.Items.Insert(SelectedItemIndex, NewItem);
            }
            else if (FormResult == DialogResult.Yes) // The user clicked "Remove"
            {
                Result = ((List<ComparisonResult>)SelectedItem.Tag)[0];

                //Result = MappingForm.SelectedComparisonResult;
                lvwMappingResults.Items.RemoveAt(SelectedItemIndex);

                if (MappingForm.ComparisonValue == null)
                {
                    lstImportedColumnValues.Items.Add("");
                }
                else
                {
                    //lstImportedColumnValues.Items.Add(MappingForm.ComparisonValue);
                    lstImportedColumnValues.Items.Add(Result.SourceValue);
                }

                _MappingMultipleItemCount--;

                switch (MappingForm.MappingType)
                {
                    case Judo.DataColumnType.EuroJudo_Event:
                        if (Result.Value != null)
                        {
                            TransformType = Transform.MethodType.Database_Mapping;

                            EventMapping = new StringToObjectMapping<Event>(Result.SourceValue, Result.ValueIndex, (Event)Result.Value, TransformType, TransformParameters);
                        }
                        else
                        {
                            TransformType = Transform.MethodType.None;

                            EventMapping = new StringToObjectMapping<Event>(Result.SourceValue, Result.ValueIndex, (Event)Result.Value, TransformType, TransformParameters);
                        }

                        if (_EventMappings.Any(x => x.Approximates(EventMapping)))
                        {
                            StringToObjectMapping<Event> MappingToRemove = _EventMappings.Find(x => x.DestinationObject.Name == EventMapping.DestinationObject.Name);
                            _EventMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                        if (Result.Value != null)
                        {
                            EuroJudoWeightCategoryMapping = new StringToObjectMapping<EuroJudo.WeightCategory>(Result.SourceValue, Result.ValueIndex, (EuroJudo.WeightCategory)Result.Value, TransformType, TransformParameters);
                        }
                        else
                        {
                            EuroJudoWeightCategoryMapping = new StringToObjectMapping<EuroJudo.WeightCategory>(Result.SourceValue, Result.ValueIndex, (EuroJudo.WeightCategory)Result.Value, TransformType, TransformParameters);
                        }

                        if (_EuroJudoWeightCategoryMappings.Any(x => x.Approximates(EuroJudoWeightCategoryMapping)))
                        {
                            StringToObjectMapping<EuroJudo.WeightCategory> MappingToRemove = _EuroJudoWeightCategoryMappings.Find(x => x.DestinationObject.Name == EventMapping.DestinationObject.Name);
                            _EuroJudoWeightCategoryMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.IJF_WeightCategory:
                        if (Result.Value != null)
                        {
                            IJFWeightCategoryMapping = new StringToObjectMapping<Judo.WeightCategory>(Result.SourceValue, Result.ValueIndex, (Judo.WeightCategory)Result.Value, TransformType, TransformParameters);
                        }
                        else
                        {
                            IJFWeightCategoryMapping = new StringToObjectMapping<Judo.WeightCategory>(Result.SourceValue, Result.ValueIndex, (Judo.WeightCategory)Result.Value, TransformType, TransformParameters);
                        }

                        if (_IJFWeightCategoryMappings.Any(x => x.Approximates(IJFWeightCategoryMapping)))
                        {
                            StringToObjectMapping<Judo.WeightCategory> MappingToRemove = _IJFWeightCategoryMappings.Find(x => x.DestinationObject.Name == IJFWeightCategoryMapping.DestinationObject.Name);
                            _IJFWeightCategoryMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.Club:
                        if (Result != null && Result.Value != null)
                        {
                            ClubMapping = new StringToObjectMapping<Club>(Result.SourceValue, Result.ValueIndex, (Club)Result.Value, TransformType, TransformParameters);
                        }
                        else
                        {
                            Club NoClub = _Clubs.Where(c => c.ID == 0).First();

                            ClubMapping = new StringToObjectMapping<Club>(Result.SourceValue, Result.ValueIndex, null, TransformType, TransformParameters);
                        }

                        if (_ClubMappings.Any(x => x.Approximates(ClubMapping)))
                        {
                            StringToObjectMapping<Club> MappingToRemove = _ClubMappings.Find(x => x.DestinationObject.Name == ClubMapping.DestinationObject.Name);
                            _ClubMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.MemberID:
                        MemberIDMapping = new StringToObjectMapping<string>(Result.SourceValue, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                        if (_MemberIDMappings.Any(x => x.Approximates(MemberIDMapping)))
                        {
                            StringToObjectMapping<string> MappingToRemove = _MemberIDMappings.Find(x => x.DestinationObject == MemberIDMapping.DestinationObject);
                            _MemberIDMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.DateOfBirth:
                        DateOfBirthMapping = new StringToObjectMapping<DateTime>(Result.SourceValue, Result.ValueIndex, (DateTime)Result.Value, TransformType, TransformParameters);

                        if (_DateOfBirthMappings.Any(c => c.Approximates(DateOfBirthMapping)))
                        {
                            StringToObjectMapping<DateTime> MappingToRemove = _DateOfBirthMappings.Find(x => x.DestinationObject == DateOfBirthMapping.DestinationObject);
                            _DateOfBirthMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.Gender:
                        if (Result.TransformMethod != MethodType.None)
                        {
                            GenderMapping = new StringToObjectMapping<Judo.Gender>(Result.SourceValue, Result.ValueIndex, (Judo.Gender)Result.Value, TransformType, TransformParameters);
                        }
                        else
                        {
                            GenderMapping = new StringToObjectMapping<Judo.Gender>(Result.SourceValue, Result.ValueIndex, Judo.Gender.Unknown, TransformType, TransformParameters);
                        }

                        if (_GenderMappings.Any(c => c.Approximates(GenderMapping)))
                        {
                            StringToObjectMapping<Judo.Gender> MappingToRemove = _GenderMappings.Find(x => x.DestinationObject == GenderMapping.DestinationObject);
                            _GenderMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.EuroJudo_Belt:
                        BeltMapping = new StringToObjectMapping<Belt>(Result.SourceValue, Result.ValueIndex, (Belt)Result.Value, TransformType, TransformParameters);

                        if (_BeltMappings.Any(c => c.Approximates(BeltMapping)))
                        {
                            StringToObjectMapping<Judo.Belt> MappingToRemove = _BeltMappings.Find(x => x.DestinationObject.Colour == BeltMapping.DestinationObject.Colour);
                            _BeltMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.Surname:
                        LastNameMapping = new StringToObjectMapping<string>(Result.SourceValue, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                        if (_LastNameMappings.Any(c => c.Approximates(LastNameMapping)))
                        {
                            StringToObjectMapping<string> MappingToRemove = _LastNameMappings.Find(x => x.DestinationObject == LastNameMapping.DestinationObject);
                            _LastNameMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.FirstName:
                        FirstNameMapping = new StringToObjectMapping<string>(Result.SourceValue, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                        if (_FirstNameMappings.Any(c => c.Approximates(FirstNameMapping)))
                        {
                            StringToObjectMapping<string> MappingToRemove = _FirstNameMappings.Find(x => x.DestinationObject == FirstNameMapping.DestinationObject);
                            _FirstNameMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.EuroJudo_Function:
                        if (Result.TransformMethod != MethodType.None)
                        {
                            EuroJudoFunctionMapping = new StringToObjectMapping<EuroJudo.Function>(Result.SourceValue, Result.ValueIndex, (EuroJudo.Function)Result.Value, TransformType, TransformParameters);
                        }
                        else
                        {
                            EuroJudoFunctionMapping = new StringToObjectMapping<EuroJudo.Function>(Result.SourceValue, Result.ValueIndex, EuroJudo.Function.Unknown, TransformType, TransformParameters);
                        }

                        if (_EuroJudoFunctionMappings.Any(c => c.Approximates(EuroJudoFunctionMapping)))
                        {
                            StringToObjectMapping<EuroJudo.Function> MappingToRemove = _EuroJudoFunctionMappings.Find(x => x.DestinationObject == EuroJudoFunctionMapping.DestinationObject);
                            _EuroJudoFunctionMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.IJF_Function:
                        if (Result.TransformMethod != MethodType.None)
                        {
                            IJFFunctionMapping = new StringToObjectMapping<IJF.Function>(Result.SourceValue, Result.ValueIndex, (IJF.Function)Result.Value, TransformType, TransformParameters);
                        }
                        else
                        {
                            IJFFunctionMapping = new StringToObjectMapping<IJF.Function>(Result.SourceValue, Result.ValueIndex, IJF.Function.Unknown, TransformType, TransformParameters);
                        }

                        if (_IJFFunctionMappings.Any(c => c.Approximates(IJFFunctionMapping)))
                        {
                            StringToObjectMapping<IJF.Function> MappingToRemove = _IJFFunctionMappings.Find(x => x.DestinationObject == IJFFunctionMapping.DestinationObject);
                            _IJFFunctionMappings.Remove(MappingToRemove);
                        }
                        break;
                    case Judo.DataColumnType.IJF_Photo:
                        PhotoMapping = new StringToObjectMapping<string>(Result.SourceValue, Result.ValueIndex, (string)Result.Value, TransformType, TransformParameters);

                        if (_IJFPhotoMappings.Any(c => c.Approximates(PhotoMapping)))
                        {
                            StringToObjectMapping<string> MappingToRemove = _IJFPhotoMappings.Find(x => x.DestinationObject == PhotoMapping.DestinationObject);
                            _IJFPhotoMappings.Remove(MappingToRemove);
                        }
                        break;
                }
            }
            else // Cancel
            {
            }

        }

        private void lvwMappingResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnResetMappings.Enabled = lvwDatabaseMappingResults.SelectedItems.Count > 0;
        }

        private void lvwMappingResults_KeyDown(object sender, KeyEventArgs e)
        {
            //StringToObjectMapping<Event> EventMapping = null;
            //StringToObjectMapping<EuroJudo.WeightCategory> EuroJudoWeightCategoryMapping = null;
            //StringToObjectMapping<Judo.WeightCategory> IJFWeightCategoryMapping = null;
            //StringToObjectMapping<Club> ClubMapping = null;
            //StringToObjectMapping<string> MemberIDMapping = null;
            //StringToObjectMapping<DateTime> DateOfBirthMapping = null;
            //StringToObjectMapping<Judo.Gender> GenderMapping = null;
            //StringToObjectMapping<Belt> BeltMapping = null;
            //StringToObjectMapping<string> LastNameMapping = null;
            //StringToObjectMapping<string> FirstNameMapping = null;
            //StringToObjectMapping<EuroJudo.Function> EuroJudoFunctionMapping = null;
            //StringToObjectMapping<IJF.Function> IJFFunctionMapping = null;
            //StringToObjectMapping<string> PhotoMapping = null;

            int SelectedItemIndex = -1;
            ListViewItem SelectedItem = null;
            ComparisonResult SelectedComparisonResult = null;
            //Transform.MethodType TransformType = Transform.MethodType.Database_Mapping;
            //string[] TransformParameters = { };

            SelectedItem = lvwMappingResults.SelectedItems[0];
            SelectedItemIndex = lvwMappingResults.SelectedItems[0].Index;

            // Valid to continue... ?
            if (e.KeyCode != Keys.Delete || lvwMappingResults.SelectedItems.Count == 0 || SelectedItem.Tag == null)
            {
                return; // No
            }

            SelectedComparisonResult = ((List<ComparisonResult>)SelectedItem.Tag)[0];

            lvwMappingResults.Items.RemoveAt(SelectedItemIndex);

            if (SelectedComparisonResult.SourceValue == null)
            {
                lstImportedColumnValues.Items.Add("");
            }
            else
            {
                lstImportedColumnValues.Items.Add(SelectedComparisonResult.SourceValue);
            }

            _MappingMultipleItemCount--;

            switch (SelectedComparisonResult.MapType)
            {
                case Judo.DataColumnType.EuroJudo_Event:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Database_Mapping, _EventMappings);
                    break;
                case Judo.DataColumnType.EuroJudo_WeightCategory:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Database_Mapping, _EuroJudoWeightCategoryMappings);
                    //if (SelectedComparisonResult.Value != null)
                    //{
                    //    EuroJudoWeightCategoryMapping = new StringToObjectMapping<EuroJudo.WeightCategory>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (EuroJudo.WeightCategory)SelectedComparisonResult.Value, TransformType, TransformParameters);
                    //}
                    //else
                    //{
                    //    EuroJudoWeightCategoryMapping = new StringToObjectMapping<EuroJudo.WeightCategory>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (EuroJudo.WeightCategory)SelectedComparisonResult.Value, TransformType, TransformParameters);
                    //}

                    //if (_EuroJudoWeightCategoryMappings.Any(x => x.Approximates(EuroJudoWeightCategoryMapping)))
                    //{
                    //    StringToObjectMapping<EuroJudo.WeightCategory> MappingToRemove = _EuroJudoWeightCategoryMappings.Find(x => x.DestinationObject.Name == EventMapping.DestinationObject.Name);
                    //    _EuroJudoWeightCategoryMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.IJF_WeightCategory:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Database_Mapping, _IJFWeightCategoryMappings);
                    //if (SelectedComparisonResult.Value != null)
                    //{
                    //    IJFWeightCategoryMapping = new StringToObjectMapping<Judo.WeightCategory>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (Judo.WeightCategory)SelectedComparisonResult.Value, TransformType, TransformParameters);
                    //}
                    //else
                    //{
                    //    IJFWeightCategoryMapping = new StringToObjectMapping<Judo.WeightCategory>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (Judo.WeightCategory)SelectedComparisonResult.Value, TransformType, TransformParameters);
                    //}

                    //if (_IJFWeightCategoryMappings.Any(x => x.Approximates(IJFWeightCategoryMapping)))
                    //{
                    //    StringToObjectMapping<Judo.WeightCategory> MappingToRemove = _IJFWeightCategoryMappings.Find(x => x.DestinationObject.Name == IJFWeightCategoryMapping.DestinationObject.Name);
                    //    _IJFWeightCategoryMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.Club:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Database_Mapping, _ClubMappings);
                    //if (SelectedComparisonResult.Value != null)
                    //{
                    //    ClubMapping = new StringToObjectMapping<Club>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (Club)SelectedComparisonResult.Value, TransformType, TransformParameters);
                    //}
                    //else
                    //{
                    //    Club NoClub = _Clubs.Where(c => c.ID == 0).First();

                    //    ClubMapping = new StringToObjectMapping<Club>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, null, TransformType, TransformParameters);
                    //}

                    //if (_ClubMappings.Any(x => x.Approximates(ClubMapping)))
                    //{
                    //    StringToObjectMapping<Club> MappingToRemove = _ClubMappings.Find(x => x.DestinationObject.Name == ClubMapping.DestinationObject.Name);
                    //    _ClubMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.MemberID:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Value_Hash, _MemberIDMappings);
                    //MemberIDMapping = new StringToObjectMapping<string>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (string)SelectedComparisonResult.Value, TransformType, TransformParameters);

                    //if (_MemberIDMappings.Any(x => x.Approximates(MemberIDMapping)))
                    //{
                    //    StringToObjectMapping<string> MappingToRemove = _MemberIDMappings.Find(x => x.DestinationObject == MemberIDMapping.DestinationObject);
                    //    _MemberIDMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.DateOfBirth:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Value_Copy, _DateOfBirthMappings);
                    //DateOfBirthMapping = new StringToObjectMapping<DateTime>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (DateTime)SelectedComparisonResult.Value, TransformType, TransformParameters);

                    //if (_DateOfBirthMappings.Any(c => c.Approximates(DateOfBirthMapping)))
                    //{
                    //    StringToObjectMapping<DateTime> MappingToRemove = _DateOfBirthMappings.Find(x => x.DestinationObject == DateOfBirthMapping.DestinationObject);
                    //    _DateOfBirthMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.Gender:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Database_Mapping, _GenderMappings);
                    //if (SelectedComparisonResult.TransformMethod != MethodType.None)
                    //{
                    //    GenderMapping = new StringToObjectMapping<Judo.Gender>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (Judo.Gender)SelectedComparisonResult.Value, TransformType, TransformParameters);
                    //}
                    //else
                    //{
                    //    GenderMapping = new StringToObjectMapping<Judo.Gender>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, Judo.Gender.Unknown, TransformType, TransformParameters);
                    //}

                    //if (_GenderMappings.Any(c => c.Approximates(GenderMapping)))
                    //{
                    //    StringToObjectMapping<Judo.Gender> MappingToRemove = _GenderMappings.Find(x => x.DestinationObject == GenderMapping.DestinationObject);
                    //    _GenderMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.EuroJudo_Belt:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Database_Mapping, _BeltMappings);
                    //BeltMapping = new StringToObjectMapping<Belt>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (Belt)SelectedComparisonResult.Value, TransformType, TransformParameters);

                    //if (_BeltMappings.Any(c => c.Approximates(BeltMapping)))
                    //{
                    //    StringToObjectMapping<Judo.Belt> MappingToRemove = _BeltMappings.Find(x => x.DestinationObject.Colour == BeltMapping.DestinationObject.Colour);
                    //    _BeltMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.Surname:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Value_Copy, _LastNameMappings);
                    //LastNameMapping = new StringToObjectMapping<string>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (string)SelectedComparisonResult.Value, TransformType, TransformParameters);

                    //if (_LastNameMappings.Any(c => c.Approximates(LastNameMapping)))
                    //{
                    //    StringToObjectMapping<string> MappingToRemove = _LastNameMappings.Find(x => x.DestinationObject == LastNameMapping.DestinationObject);
                    //    _LastNameMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.FirstName:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Value_Copy, _FirstNameMappings);
                    //FirstNameMapping = new StringToObjectMapping<string>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (string)SelectedComparisonResult.Value, TransformType, TransformParameters);

                    //if (_FirstNameMappings.Any(c => c.Approximates(FirstNameMapping)))
                    //{
                    //    StringToObjectMapping<string> MappingToRemove = _FirstNameMappings.Find(x => x.DestinationObject == FirstNameMapping.DestinationObject);
                    //    _FirstNameMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.EuroJudo_Function:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Database_Mapping, _EuroJudoFunctionMappings);
                    //if (SelectedComparisonResult.TransformMethod != MethodType.None)
                    //{
                    //    EuroJudoFunctionMapping = new StringToObjectMapping<EuroJudo.Function>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (EuroJudo.Function)SelectedComparisonResult.Value, TransformType, TransformParameters);
                    //}
                    //else
                    //{
                    //    EuroJudoFunctionMapping = new StringToObjectMapping<EuroJudo.Function>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, EuroJudo.Function.Unknown, TransformType, TransformParameters);
                    //}

                    //if (_EuroJudoFunctionMappings.Any(c => c.Approximates(EuroJudoFunctionMapping)))
                    //{
                    //    StringToObjectMapping<EuroJudo.Function> MappingToRemove = _EuroJudoFunctionMappings.Find(x => x.DestinationObject == EuroJudoFunctionMapping.DestinationObject);
                    //    _EuroJudoFunctionMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.IJF_Function:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Database_Mapping, _IJFFunctionMappings);
                    //if (SelectedComparisonResult.TransformMethod != MethodType.None)
                    //{
                    //    IJFFunctionMapping = new StringToObjectMapping<IJF.Function>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (IJF.Function)SelectedComparisonResult.Value, TransformType, TransformParameters);
                    //}
                    //else
                    //{
                    //    IJFFunctionMapping = new StringToObjectMapping<IJF.Function>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, IJF.Function.Unknown, TransformType, TransformParameters);
                    //}

                    //if (_IJFFunctionMappings.Any(c => c.Approximates(IJFFunctionMapping)))
                    //{
                    //    StringToObjectMapping<IJF.Function> MappingToRemove = _IJFFunctionMappings.Find(x => x.DestinationObject == IJFFunctionMapping.DestinationObject);
                    //    _IJFFunctionMappings.Remove(MappingToRemove);
                    //}
                    break;
                case Judo.DataColumnType.IJF_Photo:
                    RemoveMapping(SelectedComparisonResult, Transform.MethodType.Value_Copy, _IJFPhotoMappings);
                    //PhotoMapping = new StringToObjectMapping<string>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (string)SelectedComparisonResult.Value, TransformType, TransformParameters);

                    //if (_IJFPhotoMappings.Any(c => c.Approximates(PhotoMapping)))
                    //{
                    //    StringToObjectMapping<string> MappingToRemove = _IJFPhotoMappings.Find(x => x.DestinationObject == PhotoMapping.DestinationObject);
                    //    _IJFPhotoMappings.Remove(MappingToRemove);
                    //}
                    break;
            }
        }

        private void lstImportedColumnValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableSetAndAutoButtons();

            UpdateDataInfo();
        }

        private void lstImportedColumnValues_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lstComparisonValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableSetAndAutoButtons();
        }

        private void lstComparisonValue_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            }
        }

        private void trbComparisonMinimum_ValueChanged(object sender, EventArgs e)
        {
            if (trbComparisonMinimum.Enabled)
            {
                lblMinComparisonValue.Text = trbComparisonMinimum.Value.ToString() + " %";

                switch (_CurrentMappingType)
                {
                    case Judo.DataColumnType.Unknown:
                        break;
                    case Judo.DataColumnType.EuroJudo_Event:
                        Properties.Settings.Default.EuroJudoEventValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case Judo.DataColumnType.FirstName:
                        break;
                    case Judo.DataColumnType.Surname:
                        break;
                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                        Properties.Settings.Default.EuroJudoWeightValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case DataColumnType.IJF_WeightCategory:
                        Properties.Settings.Default.IJFWeightValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case Judo.DataColumnType.Club:
                        Properties.Settings.Default.EuroJudoClubValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case Judo.DataColumnType.MemberID:
                        break;
                    case Judo.DataColumnType.DateOfBirth:
                        break;
                    case Judo.DataColumnType.Gender:
                        Properties.Settings.Default.EuroJudoGenderValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case Judo.DataColumnType.EuroJudo_Belt:
                        Properties.Settings.Default.BeltValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case DataColumnType.EuroJudo_Function:
                        Properties.Settings.Default.EuroJudoFunctionValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case DataColumnType.IJF_Function:
                        Properties.Settings.Default.IJFFunctionValueMinimumComparison = trbComparisonMinimum.Value;
                        Properties.Settings.Default.Save();
                        break;
                    case DataColumnType.IJF_Photo:
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
            lstComparisonValue.Enabled = radMapToDatabaseValue.Checked;

            if (radMapToDatabaseValue.Checked)
            {
                //btnManualSet.Enabled = lstEuroJudoComparisonValue.SelectedIndex > -1;
                EnableDisableSetAndAutoButtons();
                //btnAutoSet.Enabled = true;
            }
        }

        private void radCopyOrTranslate_CheckedChanged(object sender, EventArgs e)
        {
            lstComparisonValue.Enabled = radMapToDatabaseValue.Checked;

            if (radCopyOrTranslate.Checked)
            {
                //btnManualSet.Enabled = lstEuroJudoComparisonValue.SelectedIndex > -1;
                EnableDisableSetAndAutoButtons();
                //btnAutoSet.Enabled = true;
            }
        }

        private void radNone_CheckedChanged(object sender, EventArgs e)
        {
            lstComparisonValue.Enabled = radMapToDatabaseValue.Checked;

            if (radNone.Checked)
            {
                //btnManualSet.Enabled = lstEuroJudoComparisonValue.SelectedIndex > -1;
                EnableDisableSetAndAutoButtons();
                //btnAutoSet.Enabled = true;
            }
        }

        #endregion

        #region Private Methods

        private bool SetupMappingForEuroJudo()
        {
            bool Result = false;
            string TournamentFilename = Properties.Settings.Default.EuroJudoDatabaseFilename.Trim();

            if (TournamentFilename.Length > 0)
            {
                _EuroJudoTournaments = GetEuroJudoTournaments(cmbEuroJudoTournamentName, TournamentFilename, Properties.Settings.Default.EuroJudoTournamentQuery);

                // This requires the Tournaments to be loaded
                if (Properties.Settings.Default.PreviousEuroJudoTournament.Trim().Length > 0 && cmbEuroJudoTournamentName.Items.Contains(_EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.PreviousEuroJudoTournament)))
                {
                    cmbEuroJudoTournamentName.SelectedItem = _EuroJudoTournaments.Find(t => t.Name == Properties.Settings.Default.PreviousEuroJudoTournament);
                }
            }
            else
            {
                UpdateStatus("EuroJudo Tournaments filename is blank");
            }

            return _EuroJudoTournaments.Count > 0;
        }

        private bool SetupMappingForIJF()
        {
            bool Result = false;
            string TournamentConnectionString = Properties.Settings.Default.IJFDatabaseConnectionString.Trim();

            if (TournamentConnectionString.Length > 0)
            {
                _IJFTournaments = GetIJFTournaments(cmbIJFTournamentName, TournamentConnectionString, Properties.Settings.Default.IJFTournamentQuery);

                if (_IJFTournaments.Count > 0)
                {
                    // This requires the Tournaments to be loaded
                    if (Properties.Settings.Default.PreviousIJFTournament.Trim().Length > 0 && cmbIJFTournamentName.Items.Contains(_IJFTournaments.Find(t => t.Name == Properties.Settings.Default.PreviousIJFTournament)))
                    {
                        cmbIJFTournamentName.SelectedItem = _IJFTournaments.Find(t => t.Name == Properties.Settings.Default.PreviousIJFTournament);
                    }
                }
                else
                {
                    UpdateStatus("No Tournaments.  Are there any Tournaments defined, and is MySQL running?");
                }
            }
            else
            {
                UpdateStatus("IJF Database Connection string is blank");
            }

            return _IJFTournaments.Count > 0;
        }

        private void DoStartup()
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            List<string> ColumnNames = GetSourceColumnNames(_RevolutioniseSourceData);

            cmbColumnNamesFromImportData.Items.Clear();

            foreach (string column in ColumnNames)
            {
                cmbColumnNamesFromImportData.Items.Add(column);
            }

            lstImportedColumnValues.Items.Clear();

            if (cmbMappingType.Items.Count > 0)
            {
                cmbMappingType.SelectedIndex = 0;
            }

            if (Properties.Settings.Default.GeneralShowDataInfoWindow)
            {
                SetDataInfoLocation();

                _DataInfoForm.Columns = ColumnNames;

                _DataInfoForm.Show();
            }
        }

        private void UpdateDataInfo()
        {
            List<DataRow> Rows = null;
            int CurrentlySelectedColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;

            if (Properties.Settings.Default.GeneralShowDataInfoWindow)
            {
                if (lstImportedColumnValues.SelectedItems.Count == 1)
                {
                    string SelectedValue = lstImportedColumnValues.SelectedItems[0].ToString();

                    Rows = _RevolutioniseSourceData.AsEnumerable().Where(r => r.ItemArray[CurrentlySelectedColumnIndex].ToString() == SelectedValue).ToList<DataRow>();

                    _DataInfoForm.Rows = Rows;
                }
                else
                {
                    _DataInfoForm.Rows = null;
                }
            }
        }

        private void SetDataInfoLocation()
        {
            if (Properties.Settings.Default.GeneralShowDataInfoWindow)
            {
                if (!_DataInfoForm.Created)
                {
                    _DataInfoForm = new frmDataInfo();
                    _DataInfoForm.Visible = true;
                }

                _DataInfoForm.Location = new Point(ClientRectangle.Width + Location.X, Location.Y + Height - _DataInfoForm.Height);
            }
        }

        private List<Tournament> GetEuroJudoTournaments(ComboBox Combobox, string Filename, string Query)
        {
            bool Result = false;
            DataTable DataResult = null;
            string TextResult = "";
            List<Tournament> ListResult = new List<Tournament>();

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;

            UpdateStatus("Loading data...");

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
            UpdateStatus(TextResult);

            Cursor.Current = Cursors.Default;

            return ListResult;
        }

        private List<Tournament> GetIJFTournaments(ComboBox Combobox, string ConnectionString, string Query)
        {
            bool Result = false;
            DataTable DataResult = null;
            string TextResult = "";
            List<Tournament> ListResult = new List<Tournament>();

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;

            UpdateStatus("Loading data...");

            Combobox.Items.Clear();

            (TextResult, Result, DataResult) = Utilities.Data.GetMySQLData(ConnectionString, Query, "IJF_Tournaments");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;

            foreach (DataRow Row in DataResult.Rows)
            {
                pbrAuto.Value++;
                pbrAuto.Refresh();

                string ID = (string)(Row.ItemArray[0].ToString());
                string Name = (string)(Row.ItemArray[1].ToString());
                Tournament ThisTournament = new Tournament(ID, Name);

                Combobox.Items.Add(ThisTournament);

                ListResult.Add(ThisTournament);
            }

            pbrAuto.Value = 0;
            UpdateStatus(TextResult);

            Cursor.Current = Cursors.Default;

            return ListResult;
        }

        private DataTable GetEuroJudoData(string Query, string Filename, Judo.DataColumnType MappingType)
        {
            bool Result = false;

            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Loading...");

            Debug.Print($"Inside {CurrentMethodName()}");

            DataTable DataResult = null;
            string TextResult = "";

            switch (MappingType)
            {
                case Judo.DataColumnType.EuroJudo_Event:
                    (TextResult, Result, DataResult) = Utilities.Data.GetAccessData(Filename, Query, "EuroJudo_Events");
                    break;
                case Judo.DataColumnType.EuroJudo_WeightCategory:
                    (TextResult, Result, DataResult) = Utilities.Data.GetAccessData(Filename, Query, "EuroJudo_WeightCategories");
                    break;
            }

            pbrAuto.Value = 0;
            UpdateStatus(TextResult);

            Cursor.Current = Cursors.Default;

            return DataResult;
        }

        private DataTable GetIJFData(string Query, string ConnectionString, Judo.DataColumnType MappingType)
        {
            bool Result = false;

            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Loading...");

            Debug.Print($"Inside {CurrentMethodName()}");

            DataTable DataResult = null;
            string TextResult = "";

            switch (MappingType)
            {
                case Judo.DataColumnType.IJF_WeightCategory:
                    (TextResult, Result, DataResult) = Utilities.Data.GetMySQLData(ConnectionString, Query, "IJF_WeightCategories");
                    break;
            }

            pbrAuto.Value = 0;
            UpdateStatus(TextResult);

            Cursor.Current = Cursors.Default;

            return DataResult;
        }

        private List<string> GetSourceColumnNames(DataTable DataSource)
        {
            List<string> ColumnNames = new List<string>();

            Debug.Print($"Inside {CurrentMethodName()}");

            foreach (System.Data.DataColumn column in DataSource.Columns)
            {
                ColumnNames.Add(column.ColumnName);
            }

            return ColumnNames;

        }

        private void GetComparisonData()
        {
            DataTable Results = new DataTable();

            Debug.Print($"Inside {CurrentMethodName()}");

            if (_RevolutioniseSourceData != null && _RevolutioniseSourceData.Rows.Count > 0)
            {
                int SelectedColumnIndex = cmbColumnNamesFromImportData.SelectedIndex;
                string SelectedEuroJudoTournamentIndex = "";
                string SelectedIJFTournamentName = "";
                string DbQuery = "";
                string EuroJudoDatabaseFilename = Properties.Settings.Default.EuroJudoDatabaseFilename;
                string IJFDatabaseConnectionString = Properties.Settings.Default.IJFDatabaseConnectionString;

                if (_SelectedEuroJudoTournament != null || _SelectedIJFTournament != null)
                {
                    if (_MappingMode == MappingMode.EuroJudo_And_IJF || _MappingMode == MappingMode.Euro_Judo)
                    {
                        SelectedEuroJudoTournamentIndex = _SelectedEuroJudoTournament.Index.ToString();
                    }

                    if (_MappingMode == MappingMode.EuroJudo_And_IJF || _MappingMode == MappingMode.IJF)
                    {
                        SelectedIJFTournamentName = _SelectedIJFTournament.Name;
                    }
                }
                else
                {
                    return;
                }

                Debug.Print($"...Using ColumnIndex from ComboBox 'cmbColumnNamesFromImportData'");

                if (SelectedColumnIndex > -1)
                {
                    GetSourceColumnValues(_RevolutioniseSourceData, SelectedColumnIndex, lstImportedColumnValues);
                }

                switch (_CurrentMappingType) // (cmbEuroJudoMappingType.SelectedIndex)
                {
                    case DataColumnType.Unknown:
                        break;
                    case Judo.DataColumnType.EuroJudo_Event:
                        DbQuery = Properties.Settings.Default.EuroJudoEventQuery.Replace("##SelectedEuroJudoTournament_Index##", SelectedEuroJudoTournamentIndex);
                        Results = GetEuroJudoData(DbQuery, EuroJudoDatabaseFilename, Judo.DataColumnType.EuroJudo_Event);

                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;

                        FillComparisonListboxWithData(Results, lstComparisonValue, Judo.DataColumnType.EuroJudo_Event);

                        break;
                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                        DbQuery = Properties.Settings.Default.EuroJudoWeightQuery.Replace("##SelectedEuroJudoTournament_Index##", SelectedEuroJudoTournamentIndex);
                        Results = GetEuroJudoData(DbQuery, EuroJudoDatabaseFilename, Judo.DataColumnType.EuroJudo_WeightCategory);

                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;

                        FillComparisonListboxWithData(Results, lstComparisonValue, Judo.DataColumnType.EuroJudo_WeightCategory);

                        break;
                    case Judo.DataColumnType.IJF_WeightCategory:
                        DbQuery = Properties.Settings.Default.IJFWeightQuery.Replace("##SelectedIJFTournament_Name##", SelectedIJFTournamentName);
                        Results = GetIJFData(DbQuery, IJFDatabaseConnectionString, Judo.DataColumnType.IJF_WeightCategory);

                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;

                        FillComparisonListboxWithData(Results, lstComparisonValue, Judo.DataColumnType.IJF_WeightCategory);

                        break;
                    case Judo.DataColumnType.Club: // previously loaded
                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = true;

                        FillComparisonListboxWithData(Results, lstComparisonValue, Judo.DataColumnType.Club);

                        break;
                    case Judo.DataColumnType.MemberID:
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;

                        FillComparisonListboxWithData(null, lstComparisonValue, Judo.DataColumnType.MemberID);
                        break;
                    case Judo.DataColumnType.DateOfBirth:
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;

                        FillComparisonListboxWithData(null, lstComparisonValue, Judo.DataColumnType.DateOfBirth);
                        break;
                    case Judo.DataColumnType.Gender:
                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;

                        FillComparisonListboxWithData(null, lstComparisonValue, Judo.DataColumnType.Gender);
                        break;
                    case Judo.DataColumnType.EuroJudo_Belt:
                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;
                        DataTable BeltTable = _Belts.ToDataTable<Belt>();

                        FillComparisonListboxWithData(BeltTable, lstComparisonValue, Judo.DataColumnType.EuroJudo_Belt);
                        break;
                    case Judo.DataColumnType.Surname:
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;
                        FillComparisonListboxWithData(null, lstComparisonValue, Judo.DataColumnType.Surname);
                        break;
                    case Judo.DataColumnType.FirstName:
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;

                        FillComparisonListboxWithData(null, lstComparisonValue, Judo.DataColumnType.FirstName);
                        break;
                    case Judo.DataColumnType.EuroJudo_Function:
                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;

                        FillComparisonListboxWithData(null, lstComparisonValue, Judo.DataColumnType.EuroJudo_Function);
                        break;
                    case DataColumnType.IJF_Function:
                        if (radCopyOrTranslate.Checked)
                        {
                            radMapToDatabaseValue.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = true;
                        radCopyOrTranslate.Enabled = false;

                        FillComparisonListboxWithData(null, lstComparisonValue, Judo.DataColumnType.IJF_Function);
                        break;
                    case Judo.DataColumnType.IJF_Photo:
                        if (radMapToDatabaseValue.Checked)
                        {
                            radCopyOrTranslate.Checked = true;
                        }

                        radMapToDatabaseValue.Enabled = false;
                        radCopyOrTranslate.Enabled = true;
                        FillComparisonListboxWithData(null, lstComparisonValue, Judo.DataColumnType.IJF_Photo);
                        break;
                    default:
                        break;
                }
            }
        }

        private void GetSourceColumnValues(DataTable DataSource, int ImportFileColumnIndex, ListBox Listbox)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Loading...");

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

        private void FillComparisonListboxWithData(DataTable DataResult, ListBox Listbox, Judo.DataColumnType MappingType)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Loading...");

            Debug.Print($"Inside {CurrentMethodName()}");

            string TextResult = "";
            object NewInstance = null;

            Listbox.Items.Clear();
            Listbox.Refresh();
            Listbox.SuspendDrawing();

            pbrAuto.Minimum = 0;

            switch (MappingType)
            {
                case DataColumnType.Unknown:
                    break;
                case Judo.DataColumnType.EuroJudo_Event:
                    {
                        Listbox.Sorted = true;

                        if (DataResult != null)
                        {
                            pbrAuto.Maximum = DataResult.Rows.Count;

                            foreach (DataRow Row in DataResult.Rows)
                            {
                                int Number = Convert.ToInt32(Row.ItemArray[0].ToString());
                                EuroJudo.Gender sex = (EuroJudo.Gender)Enum.Parse(typeof(EuroJudo.Gender), (string)(Row.ItemArray[1].ToString()));
                                string Name = (string)(Row.ItemArray[2].ToString());

                                pbrAuto.Value++;
                                pbrAuto.Refresh();

                                NewInstance = new Event(Listbox.Items.Count, Number, Name, sex);

                                Listbox.Items.Add(NewInstance);

                                _EJEvents.Add((Event)NewInstance);
                            }
                        }
                        break;
                    }
                case Judo.DataColumnType.EuroJudo_WeightCategory:
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

                                //Debug.Print($"{EventName}, {Name}, {Minimum}, {Maximum}");

                                pbrAuto.Value++;
                                pbrAuto.Refresh();

                                if (_EJEvents.Count > 0)
                                {
                                    NewInstance = new EuroJudo.WeightCategory(ClassNumber, _EJEvents.Find(n => n.Name == EventName), Name, Minimum, Maximum);
                                }
                                else
                                {
                                    NewInstance = new EuroJudo.WeightCategory(ClassNumber, null, EventName + " " + Name, Minimum, Maximum);
                                }

                                Listbox.Items.Add(NewInstance);
                            }
                        }
                        break;
                    }
                case Judo.DataColumnType.IJF_WeightCategory:
                    {
                        Listbox.Sorted = false;

                        if (DataResult != null)
                        {
                            pbrAuto.Maximum = DataResult.Rows.Count;

                            foreach (DataRow Row in DataResult.Rows)
                            {
                                string AgeGroup = (string)(Row.ItemArray[0].ToString()).Capitalise();
                                string EventGender = (string)(Row.ItemArray[1].ToString());  // m or w or m+w
                                string MensWeight = (string)(Row.ItemArray[2].ToString());
                                string WomensWeight = (string)(Row.ItemArray[3].ToString());
                                List<string> MensWeights = new List<string>();
                                List<string> WomensWeights = new List<string>();
                                int Minimum = 0;
                                int Maximum = 0;

                                pbrAuto.Value++;
                                pbrAuto.Refresh();

                                if (AgeGroup.EndsWith("s"))
                                {
                                    AgeGroup = AgeGroup.Substring(0, AgeGroup.Length - 1);
                                }

                                if (EventGender.StartsWith("m") || EventGender.EndsWith("m"))
                                {
                                    MensWeights = MensWeight.Split(',').ToList<string>();
                                }
                                if (EventGender.StartsWith("w") || EventGender.EndsWith("w"))
                                {
                                    WomensWeights = WomensWeight.Split(',').ToList<string>();
                                }

                                foreach (string WeightName in MensWeights)
                                {
                                    if (AgeGroup.ToLower() == "cadet")
                                    {
                                        switch (WeightName.Replace(" kg", "").Trim())
                                        {
                                            case "-50":
                                                Minimum = 0;
                                                Maximum = 50;
                                                break;
                                            case "-55":
                                                Minimum = 50;
                                                Maximum = 55;
                                                break;
                                            case "-60":
                                                Minimum = 55;
                                                Maximum = 60;
                                                break;
                                            case "-66":
                                                Minimum = 60;
                                                Maximum = 66;
                                                break;
                                            case "-73":
                                                Minimum = 66;
                                                Maximum = 73;
                                                break;
                                            case "-81":
                                                Minimum = 73;
                                                Maximum = 81;
                                                break;
                                            case "-90":
                                                Minimum = 81;
                                                Maximum = 90;
                                                break;
                                            case "+90":
                                                Minimum = 90;
                                                Maximum = 255;
                                                break;
                                        }
                                    }
                                    else if (AgeGroup.ToLower() == "junior")
                                    {
                                        switch (WeightName.Replace(" kg", "").Trim())
                                        {
                                            case "-55":
                                                Minimum = 0;
                                                Maximum = 55;
                                                break;
                                            case "-60":
                                                Minimum = 55;
                                                Maximum = 60;
                                                break;
                                            case "-66":
                                                Minimum = 60;
                                                Maximum = 66;
                                                break;
                                            case "-73":
                                                Minimum = 66;
                                                Maximum = 73;
                                                break;
                                            case "-81":
                                                Minimum = 73;
                                                Maximum = 81;
                                                break;
                                            case "-90":
                                                Minimum = 81;
                                                Maximum = 90;
                                                break;
                                            case "-100":
                                                Minimum = 90;
                                                Maximum = 100;
                                                break;
                                            case "+100":
                                                Minimum = 100;
                                                Maximum = 255;
                                                break;
                                        }
                                    }
                                    else if (AgeGroup.ToLower() == "senior")
                                    {
                                        switch (WeightName.Replace(" kg", "").Trim())
                                        {
                                            case "-60":
                                                Minimum = 0;
                                                Maximum = 60;
                                                break;
                                            case "-66":
                                                Minimum = 60;
                                                Maximum = 66;
                                                break;
                                            case "-73":
                                                Minimum = 66;
                                                Maximum = 73;
                                                break;
                                            case "-81":
                                                Minimum = 73;
                                                Maximum = 81;
                                                break;
                                            case "-90":
                                                Minimum = 81;
                                                Maximum = 90;
                                                break;
                                            case "-100":
                                                Minimum = 90;
                                                Maximum = 100;
                                                break;
                                            case "+100":
                                                Minimum = 100;
                                                Maximum = 255;
                                                break;
                                        }
                                    }

                                    NewInstance = new Judo.WeightCategory(AgeGroup.Trim() + " Mens " + WeightName.Trim(), Minimum, Maximum);

                                    Listbox.Items.Add(NewInstance);
                                }

                                foreach (string WeightName in WomensWeights)
                                {
                                    if (AgeGroup.ToLower() == "cadet")
                                    {
                                        switch (WeightName.Replace(" kg", "").Trim())
                                        {
                                            case "-40":
                                                Minimum = 0;
                                                Maximum = 40;
                                                break;
                                            case "-44":
                                                Minimum = 40;
                                                Maximum = 44;
                                                break;
                                            case "-48":
                                                Minimum = 44;
                                                Maximum = 48;
                                                break;
                                            case "-52":
                                                Minimum = 48;
                                                Maximum = 52;
                                                break;
                                            case "-57":
                                                Minimum = 52;
                                                Maximum = 57;
                                                break;
                                            case "-63":
                                                Minimum = 57;
                                                Maximum = 63;
                                                break;
                                            case "-70":
                                                Minimum = 63;
                                                Maximum = 70;
                                                break;
                                            case "+70":
                                                Minimum = 70;
                                                Maximum = 255;
                                                break;
                                        }
                                    }
                                    else if (AgeGroup.ToLower() == "junior")
                                    {
                                        switch (WeightName.Replace(" kg", "").Trim())
                                        {
                                            case "-44":
                                                Minimum = 0;
                                                Maximum = 44;
                                                break;
                                            case "-48":
                                                Minimum = 44;
                                                Maximum = 48;
                                                break;
                                            case "-52":
                                                Minimum = 48;
                                                Maximum = 52;
                                                break;
                                            case "-57":
                                                Minimum = 52;
                                                Maximum = 57;
                                                break;
                                            case "-63":
                                                Minimum = 57;
                                                Maximum = 63;
                                                break;
                                            case "-70":
                                                Minimum = 63;
                                                Maximum = 70;
                                                break;
                                            case "-78":
                                                Minimum = 70;
                                                Maximum = 78;
                                                break;
                                            case "+78":
                                                Minimum = 78;
                                                Maximum = 255;
                                                break;
                                        }
                                    }
                                    else if (AgeGroup.ToLower() == "senior")
                                    {
                                        switch (WeightName.Replace(" kg", "").Trim())
                                        {
                                            case "-48":
                                                Minimum = 0;
                                                Maximum = 48;
                                                break;
                                            case "-52":
                                                Minimum = 48;
                                                Maximum = 52;
                                                break;
                                            case "-57":
                                                Minimum = 52;
                                                Maximum = 57;
                                                break;
                                            case "-63":
                                                Minimum = 57;
                                                Maximum = 63;
                                                break;
                                            case "-70":
                                                Minimum = 63;
                                                Maximum = 70;
                                                break;
                                            case "-78":
                                                Minimum = 70;
                                                Maximum = 78;
                                                break;
                                            case "+78":
                                                Minimum = 78;
                                                Maximum = 255;
                                                break;
                                        }
                                    }

                                    NewInstance = new Judo.WeightCategory(AgeGroup.Trim() + " Womens " + WeightName.Trim(), Minimum, Maximum);

                                    Listbox.Items.Add(NewInstance);
                                }
                            }
                        }
                        break;
                    }
                case Judo.DataColumnType.Club:
                    {
                        Listbox.Sorted = true;

                        pbrAuto.Maximum = _Clubs.Count;

                        // Clubs have already been loaded
                        foreach (Club Club in _Clubs)
                        {
                            pbrAuto.Value++;
                            pbrAuto.Refresh();

                            Listbox.Items.Add(Club);
                        }
                        break;
                    }
                case Judo.DataColumnType.MemberID:
                    {
                        // No conversion
                        break;
                    }
                case Judo.DataColumnType.DateOfBirth:
                    {
                        // No conversion
                        break;
                    }
                case Judo.DataColumnType.Gender:
                    {
                        Listbox.Sorted = true;

                        Listbox.Items.Add(Judo.Gender.Male);
                        Listbox.Items.Add(Judo.Gender.Female);
                        break;
                    }
                case Judo.DataColumnType.EuroJudo_Belt:
                    {
                        Listbox.Sorted = false;

                        foreach (Belt Belt in _Belts)
                        {
                            Listbox.Items.Add(Belt);
                        }

                        break;
                    }
                case Judo.DataColumnType.Surname:
                    {
                        // No conversion
                        break;
                    }
                case Judo.DataColumnType.FirstName:
                    {
                        // No conversion
                        break;
                    }
                case Judo.DataColumnType.EuroJudo_Function:
                    {
                        Listbox.Sorted = false;

                        Listbox.Items.Add(EuroJudo.Function.Competitor);
                        Listbox.Items.Add(EuroJudo.Function.Coach);
                        Listbox.Items.Add(EuroJudo.Function.Referee);
                        Listbox.Items.Add(EuroJudo.Function.Medic);
                        Listbox.Items.Add(EuroJudo.Function.Team_Official);
                        Listbox.Items.Add(EuroJudo.Function.Organizer);
                        Listbox.Items.Add(EuroJudo.Function.EJU_VIP);
                        Listbox.Items.Add(EuroJudo.Function.Press);
                        break;
                    }
                case Judo.DataColumnType.IJF_Function:
                    {
                        Listbox.Sorted = false;

                        Listbox.Items.Add(IJF.Function.Unknown);
                        Listbox.Items.Add(IJF.Function.Competitor);
                        Listbox.Items.Add(IJF.Function.Judoka);
                        Listbox.Items.Add(IJF.Function.Coach);
                        Listbox.Items.Add(IJF.Function.Team_Official);
                        Listbox.Items.Add(IJF.Function.Referee);
                        Listbox.Items.Add(IJF.Function.Doctor);
                        Listbox.Items.Add(IJF.Function.Medic);
                        Listbox.Items.Add(IJF.Function.Physiotherapist);
                        Listbox.Items.Add(IJF.Function.President);
                        Listbox.Items.Add(IJF.Function.Vice_President);
                        Listbox.Items.Add(IJF.Function.General_Secretary);
                        Listbox.Items.Add(IJF.Function.Delegate);
                        Listbox.Items.Add(IJF.Function.Staff);
                        Listbox.Items.Add(IJF.Function.VIP);
                        Listbox.Items.Add(IJF.Function.VVIP);
                        Listbox.Items.Add(IJF.Function.Guest);
                        Listbox.Items.Add(IJF.Function.Spectator);
                        Listbox.Items.Add(IJF.Function.Head_Of_Organisation);
                        Listbox.Items.Add(IJF.Function.Organisation_2);
                        Listbox.Items.Add(IJF.Function.Organisation_3);
                        Listbox.Items.Add(IJF.Function.Press);
                        Listbox.Items.Add(IJF.Function.Press_Photo);
                        Listbox.Items.Add(IJF.Function.Press_TV);
                        Listbox.Items.Add(IJF.Function.Press_TV_Arena);
                        Listbox.Items.Add(IJF.Function.Press_Journalist);
                        Listbox.Items.Add(IJF.Function.Head_Of_Security);
                        Listbox.Items.Add(IJF.Function.Security);
                        Listbox.Items.Add(IJF.Function.Video_Team);
                        break;
                    }
                case DataColumnType.IJF_Photo:
                    // No conversion
                    break;
            }

            pbrAuto.Value = 0;
            Listbox.ResumeDrawing();
            UpdateStatus(TextResult);

            Cursor.Current = Cursors.Default;

        }

        private void MapValuesAutomatically(ListBox ImportedColumnValuesListbox, ListBox ValuesListbox, ListView MappingListview, Judo.DataColumnType MapType)
        {
            Color Colour = MappingListview.BackColor;
            MethodType SelectedMethodType = MethodType.Unknown;
            string[] TransformParameters = { };
            bool AllowInTransformEdits = false;

            Cursor.Current = Cursors.WaitCursor;

            //Debug.Print($"Inside {CurrentMethodName()}");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = ImportedColumnValuesListbox.Items.Count * ValuesListbox.Items.Count;

            (SelectedMethodType, TransformParameters, AllowInTransformEdits) = GetCurrentMethodTypeAndParameters();

            if (SelectedMethodType == MethodType.Unknown)
            {
                return;
            }

            lvwMappingResults.BeginUpdate();
            //lstImportedColumnValues.BeginUpdate();

            for (int ColumnIndex = 0; ColumnIndex < ImportedColumnValuesListbox.Items.Count; ColumnIndex++)
            {
                List<ComparisonResult> ValueResults = new List<ComparisonResult>();

                string ColumnValue = (string)ImportedColumnValuesListbox.Items[ColumnIndex];

                //UpdateStatus($"Searching for '{ColumnValue}'...");

                switch (SelectedMethodType)
                {
                    case MethodType.Database_Mapping:
                        {
                            for (int ValueIndex = 0; ValueIndex < ValuesListbox.Items.Count; ValueIndex++)
                            {
                                if (pbrAuto.Value < pbrAuto.Maximum)
                                {
                                    pbrAuto.Value++;
                                }

                                //Application.DoEvents();

                                switch (MapType)
                                {
                                    case Judo.DataColumnType.Unknown:
                                        {
                                            break;
                                        }
                                    case Judo.DataColumnType.EuroJudo_Event:
                                        {
                                            MapEvent(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            //MapType<Judo.DataColumnType>(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                                        {
                                            MapEuroJudoWeightCategory(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case DataColumnType.IJF_WeightCategory:
                                        {
                                            MapIJFWeightCategory(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.Club:
                                        {
                                            MapClub(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.MemberID:
                                        {
                                            MapMemberID(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.DateOfBirth:
                                        {
                                            MapDateOfBirth(lstImportedColumnValues, ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.Gender:
                                        {
                                            MapGender(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.EuroJudo_Belt:
                                        {
                                            MapBelt(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.FirstName:
                                        {
                                            MapFirstName(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.Surname:
                                        {
                                            MapLastName(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.EuroJudo_Function:
                                        {
                                            MapEuroJudoFunction(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.IJF_Function:
                                        {
                                            MapIJFFunction(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                    case Judo.DataColumnType.IJF_Photo:
                                        {
                                            MapPhoto(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                            break;
                                        }
                                }
                            }

                            if (ValueResults.Count > 0)
                            {
                                switch (MapType)
                                {
                                    case DataColumnType.Unknown:
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Event:
                                        AddEventComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoEventValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                                        AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.IJF_WeightCategory:
                                        AddIJFWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.IJFWeightValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Club:
                                        AddClubComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoClubValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.MemberID:
                                        AddMemberIDComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.DateOfBirth:
                                        AddDateOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Gender:
                                        AddGenderComparisonResults(ColumnValue, ColumnIndex, ValueResults, 100, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Belt:
                                        AddBeltComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.BeltValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.FirstName:
                                        AddFirstNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Surname:
                                        AddLastNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Function:
                                        AddEuroJudoFunctionComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.IJF_Function:
                                        AddIJFFunctionComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.IJF_Photo:
                                        AddPhotoComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                }

                                ColumnIndex--;
                            }
                            break;
                        }
                    case MethodType.None:
                        {
                            int ValueIndex = -1;

                            pbrAuto.Value = ValuesListbox.Items.Count * (ColumnIndex + 1);

                            Application.DoEvents();

                            switch (MapType)
                            {
                                case Judo.DataColumnType.Unknown:
                                    {
                                        break;
                                    }
                                case Judo.DataColumnType.EuroJudo_Event:
                                    {
                                        MapEvent(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.EuroJudo_WeightCategory:
                                    {
                                        MapEuroJudoWeightCategory(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case DataColumnType.IJF_WeightCategory:
                                    {
                                        MapIJFWeightCategory(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.Club:
                                    {
                                        MapClub(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.MemberID:
                                    {
                                        MapMemberID(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.DateOfBirth:
                                    {
                                        MapDateOfBirth(lstImportedColumnValues, ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.Gender:
                                    {
                                        MapGender(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.EuroJudo_Belt:
                                    {
                                        MapBelt(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.FirstName:
                                    {
                                        MapFirstName(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.Surname:
                                    {
                                        MapLastName(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.EuroJudo_Function:
                                    {
                                        MapEuroJudoFunction(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.IJF_Function:
                                    {
                                        MapIJFFunction(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.IJF_Photo:
                                    {
                                        MapPhoto(ValuesListbox, ColumnIndex, ValueResults, null, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                            }

                            if (ValueResults.Count > 0)
                            {
                                switch (MapType)
                                {
                                    case DataColumnType.Unknown:
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Event:
                                        AddEventComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoEventValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                                        AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case DataColumnType.IJF_WeightCategory:
                                        AddIJFWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.IJFWeightValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Club:
                                        AddClubComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoClubValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.MemberID:
                                        AddMemberIDComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.DateOfBirth:
                                        AddDateOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Gender:
                                        AddGenderComparisonResults(ColumnValue, ColumnIndex, ValueResults, 100, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Belt:
                                        AddBeltComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.BeltValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.FirstName:
                                        AddFirstNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Surname:
                                        AddLastNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Function:
                                        AddEuroJudoFunctionComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.IJF_Function:
                                        AddIJFFunctionComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case DataColumnType.IJF_Photo:
                                        AddPhotoComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                }

                                ColumnIndex--;
                            }

                            break;
                        }
                    default:
                        {
                            int ValueIndex = -1;

                            pbrAuto.Value = ValuesListbox.Items.Count * (ColumnIndex + 1);

                            Application.DoEvents();

                            switch (MapType)
                            {
                                case DataColumnType.Unknown:
                                    {
                                        break;
                                    }
                                case Judo.DataColumnType.EuroJudo_Event:
                                    {
                                        MapEvent(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        //MapType<Judo.DataColumnType>(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.EuroJudo_WeightCategory:
                                    {
                                        MapEuroJudoWeightCategory(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case DataColumnType.IJF_WeightCategory:
                                    {
                                        MapIJFWeightCategory(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.Club:
                                    {
                                        MapClub(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.MemberID:
                                    {
                                        MapMemberID(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.DateOfBirth:
                                    {
                                        MapDateOfBirth(lstImportedColumnValues, ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.Gender:
                                    {
                                        MapGender(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.EuroJudo_Belt:
                                    {
                                        MapBelt(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.FirstName:
                                    {
                                        MapFirstName(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.Surname:
                                    {
                                        MapLastName(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.EuroJudo_Function:
                                    {
                                        MapEuroJudoFunction(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.IJF_Function:
                                    {
                                        MapIJFFunction(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                                case Judo.DataColumnType.IJF_Photo:
                                    {
                                        MapPhoto(ValuesListbox, ColumnIndex, ValueResults, ColumnValue, ValueIndex, false, SelectedMethodType, TransformParameters, AllowInTransformEdits);
                                        break;
                                    }
                            }

                            if (ValueResults.Count > 0)
                            {
                                switch (MapType)
                                {
                                    case DataColumnType.Unknown:
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Event:
                                        AddEventComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoEventValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_WeightCategory:
                                        AddEuroJudoWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoWeightValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case DataColumnType.IJF_WeightCategory:
                                        AddIJFWeightCategoryComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Club:
                                        AddClubComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.EuroJudoClubValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.MemberID:
                                        AddMemberIDComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.DateOfBirth:
                                        AddDateOfBirthComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Gender:
                                        AddGenderComparisonResults(ColumnValue, ColumnIndex, ValueResults, 100, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Belt:
                                        AddBeltComparisonResults(ColumnValue, ColumnIndex, ValueResults, Properties.Settings.Default.BeltValueMinimumComparison, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.FirstName:
                                        AddFirstNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.Surname:
                                        AddLastNameComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.EuroJudo_Function:
                                        AddEuroJudoFunctionComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.IJF_Function:
                                        AddIJFFunctionComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                    case Judo.DataColumnType.IJF_Photo:
                                        AddPhotoComparisonResults(ColumnValue, ColumnIndex, ValueResults, 0, SelectedMethodType, TransformParameters);
                                        break;
                                }

                                ColumnIndex--;
                            }

                            break;
                        }
                }
            }

            //lstImportedColumnValues.EndUpdate();
            lvwMappingResults.EndUpdate();

            pbrAuto.Value = 0;
            UpdateStatus("Auto mapping complete");

            Cursor.Current = Cursors.Default;
        }

        #region Map_x

        private Event MapEvent(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            Event NewInstance = null;
            double CommonResult = 0;
            string OriginalValue = ColumnValue;

            if (TransformMethodType == MethodType.None)
            {
                //UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                if (ValueIndex != -1)
                {
                    NewInstance = (Event)DatabaseValuesListbox.Items[ValueIndex];
                }
                else
                {
                    throw new NotImplementedException();
                }
                //UpdateStatus($"Comparing {ColumnValue} with {((Event)NewInstance).ToString()}");
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

                ColumnValue = ColumnValue.Replace("Girls", "Girl");
                ColumnValue = ColumnValue.ToLower().Replace("girl", "Girl");

                ColumnValue = ColumnValue.Replace("Boys", "Boy");
                ColumnValue = ColumnValue.ToLower().Replace("boy", "Boy");

                ColumnValue = ColumnValue.ToLower().Replace("female", "Women");
                ColumnValue = ColumnValue.ToLower().Replace("women", "Women");
                ColumnValue = ColumnValue.ToLower().Replace("woman", "Women");


                ColumnValue = ColumnValue.Replace("Male", "Men");
                ColumnValue = ColumnValue.Replace("Men", "Men");
                ColumnValue = ColumnValue.Replace("Man", "Men");
                ColumnValue = ColumnValue.ToLower().Replace("male", "Men");
                ColumnValue = ColumnValue.ToLower().Replace("man", "Men");

                ColumnValue = ColumnValue.ToLower().Replace("special needs", "No Limits");
                ColumnValue = ColumnValue.ToLower().Replace(" sn ", "No Limits");
            }

            #endregion

            //#region Build list of words to completely ignore

            //List<string> WordsToIgnore = new List<string>();

            //WordsToIgnore.Add("judo");
            //WordsToIgnore.Add("club");
            //WordsToIgnore.Add("academy");

            //#endregion

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    CommonResult = ((Event)NewInstance).Name.CompareWith(ColumnValue);

                    if (CommonResult >= Properties.Settings.Default.EuroJudoEventValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.EuroJudo_Event, (Event)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    if (CommonResult >= Properties.Settings.Default.EuroJudoEventValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.EuroJudo_Event, null, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
            }

            return NewInstance;
        }

        private EuroJudo.WeightCategory MapEuroJudoWeightCategory(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            EuroJudo.WeightCategory NewInstance = null;
            double CommonResult = 0;
            string NewInstanceEventName = "";
            string NewInstanceName = "";
            string OriginalValue = ColumnValue;
            string WeightCategory = ColumnValue;

            if (TransformMethodType == MethodType.None)
            {
                //UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                if (ValueIndex != -1)
                {
                    NewInstance = (EuroJudo.WeightCategory)DatabaseValuesListbox.Items[ValueIndex];
                }
                else
                {
                    throw new NotImplementedException();
                }
                //UpdateStatus($"Comparing {ColumnValue} with {((EuroJudo.WeightCategory)NewInstance).ToString()}");
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
                        NewInstanceEventName = ((EuroJudo.WeightCategory)NewInstance).Event.Name;
                        NewInstanceName = ((EuroJudo.WeightCategory)NewInstance).ToString();
                        CommonResult = NewInstanceName.CompareWith(WeightCategory);
                    }
                    else
                    {
                        CommonResult = ((EuroJudo.WeightCategory)NewInstance).Name.CompareWith(WeightCategory);
                    }

                    if (CommonResult >= Properties.Settings.Default.EuroJudoWeightValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.EuroJudo_WeightCategory, (EuroJudo.WeightCategory)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    if (CommonResult >= Properties.Settings.Default.EuroJudoWeightValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.EuroJudo_WeightCategory, null, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
            }

            return NewInstance;
        }

        private Judo.WeightCategory MapIJFWeightCategory(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            Judo.WeightCategory NewInstance = null;
            double CommonResult = 0;
            string OriginalValue = ColumnValue;
            string WeightCategory = ColumnValue;

            if (TransformMethodType == MethodType.None)
            {
                //UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                if (ValueIndex != -1)
                {
                    NewInstance = (Judo.WeightCategory)DatabaseValuesListbox.Items[ValueIndex];
                }
                else
                {
                    throw new NotImplementedException();
                }
                //UpdateStatus($"Comparing {ColumnValue} with {((Judo.WeightCategory)NewInstance).ToString()}");
            }

            #region Replacement values

            if (ColumnValue != null)
            {
                // Process common values first
                //ColumnValue = ColumnValue.ToLower().Replace("junior", "");
                //ColumnValue = ColumnValue.ToLower().Replace("jnr.", "");
                //ColumnValue = ColumnValue.ToLower().Replace("jnr", "");
                //ColumnValue = ColumnValue.ToLower().Replace("senior", "");
                //ColumnValue = ColumnValue.ToLower().Replace("snr.", "");
                //ColumnValue = ColumnValue.ToLower().Replace("snr", "");
                //ColumnValue = ColumnValue.ToLower().Replace("cad", "");
                //ColumnValue = ColumnValue.ToLower().Replace("cad.", "");

                //// Process females next because "women" contains "men" etc

                //ColumnValue = ColumnValue.Replace("Female", "");
                //ColumnValue = ColumnValue.Replace("Women", "");
                //ColumnValue = ColumnValue.Replace("Woman", "");
                //ColumnValue = ColumnValue.Replace("Girl", "");
                //ColumnValue = ColumnValue.ToLower().Replace("women", "");
                //ColumnValue = ColumnValue.ToLower().Replace("woman", "");
                //ColumnValue = ColumnValue.ToLower().Replace("girls", "");
                //ColumnValue = ColumnValue.ToLower().Replace("girl", "");
                //ColumnValue = ColumnValue.ToLower().Replace("g", "");
                //ColumnValue = ColumnValue.ToLower().Replace("w", "");

                //ColumnValue = ColumnValue.Replace("Male", "");
                //ColumnValue = ColumnValue.Replace("Men", "");
                //ColumnValue = ColumnValue.Replace("Man", "");
                //ColumnValue = ColumnValue.Replace("Boy", "");
                //ColumnValue = ColumnValue.ToLower().Replace("male", "");
                //ColumnValue = ColumnValue.ToLower().Replace("man", "");
                //ColumnValue = ColumnValue.ToLower().Replace("boys", "");
                //ColumnValue = ColumnValue.ToLower().Replace("boy", "");
                //ColumnValue = ColumnValue.ToLower().Replace("b", "");

                if (WeightCategory != null)
                {
                    foreach (string Replacement in Properties.Settings.Default.IJFWeightCategoryOverReplacement)
                    {
                        WeightCategory = WeightCategory.Replace(Replacement, Properties.Settings.Default.IJFWeightCategoryOverValue);
                    }

                    foreach (string Replacement in Properties.Settings.Default.IJFWeightCategoryUnderReplacement)
                    {
                        WeightCategory = WeightCategory.Replace(Replacement, Properties.Settings.Default.IJFWeightCategoryUnderValue);
                    }
                }
            }

            #endregion

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    //if (NewInstance.Event != null)
                    //{
                    //    NewInstanceEventName = ((EuroJudo.WeightCategory)NewInstance).Event.Name;
                    //    NewInstanceName = ((EuroJudo.WeightCategory)NewInstance).ToString();
                    //    CommonResult = NewInstanceName.CompareWith(WeightCategory);
                    //}
                    //else
                    //{
                    CommonResult = ((Judo.WeightCategory)NewInstance).Name.CompareWith(WeightCategory);
                    //}

                    if (CommonResult >= Properties.Settings.Default.IJFWeightValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.IJF_WeightCategory, (Judo.WeightCategory)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    if (CommonResult >= Properties.Settings.Default.IJFWeightValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.IJF_WeightCategory, null, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
            }

            return NewInstance;
        }

        private Club MapClub(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            Club NewInstance = null;
            double CommonResult = 0;
            Club NoClub = _Clubs.Where(c => c.ID == 0).First();

            if (TransformMethodType == MethodType.None)
            {
                //UpdateStatus($"Mapping '{ColumnValue}' to {NoClub.Name}");
            }
            else
            {
                if (ValueIndex != -1)
                {
                    NewInstance = (Club)DatabaseValuesListbox.Items[ValueIndex];
                }
                else
                {
                    return null;

                    //                    throw new NotImplementedException();
                }
                //UpdateStatus($"Comparing {ColumnValue} with {((Club)NewInstance).Name}");
            }

            #region Build list of words to completely ignore

            List<string> WordsToIgnore = new List<string>();

            WordsToIgnore.Add("judo");
            WordsToIgnore.Add("club");
            WordsToIgnore.Add("academy");

            #endregion

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    CommonResult = ((Club)NewInstance).Name.CompareWith(ColumnValue, WordsToIgnore, true);

                    if (CommonResult >= Properties.Settings.Default.EuroJudoClubValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, Judo.DataColumnType.Club, (Club)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    if (CommonResult >= Properties.Settings.Default.EuroJudoClubValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.Club, null, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, Judo.DataColumnType.Club, NoClub, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                default:
                    CommonResult = 100;

                    // TODO: Ask for SubDivision
                    Country ClubCountry = _Countries.Where(c => c.ISO3Code == Properties.Settings.Default.GeneralClubDefaultCountryCode).First();
                    SubDivision State = null;

                    Club NewClub = new Club(_Clubs.Count, ColumnValue.Capitalise(), ColumnValue.Capitalise().ConstantLengthHash(), new Location(ClubCountry, State));

                    // Add this Club to the Club list
                    if (!_Clubs.Contains(NewClub))
                    {
                        _Clubs.Add(NewClub);
                        lstComparisonValue.Items.Add(NewClub);
                    }
                    else
                    {
                        NewClub = _Clubs.Where(c => c.Name.Capitalise() == NewClub.Name.Capitalise() &&
                                                   c.Location.Country.Name == NewClub.Location.Country.Name
                                             ).First();
                    }

                    ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, Judo.DataColumnType.Club, NewClub, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private string MapMemberID(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            string NewInstance = "";
            double CommonResult = 0;

            if (TransformMethodType == MethodType.Database_Mapping)
            {
                NewInstance = (string)DatabaseValuesListbox.Items[ValueIndex];
                CommonResult = ColumnValue.CompareWith(NewInstance);
            }
            else
            {
                NewInstance = Transform.Execute(ColumnValue.Capitalise(), TransformMethodType, TransformParameters);
                CommonResult = 100;
            }

            //UpdateStatus($"Mapping '{ColumnValue}' to '{NewInstance}'");

            ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, Judo.DataColumnType.MemberID, (string)NewInstance, Manual, TransformMethodType, TransformParameters));

            return NewInstance;
        }

        private DateTime MapDateOfBirth(ListBox SourceValuesListbox, ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            DateTime NewInstance = DateTime.MinValue;
            double CommonResult = 0;
            string OriginalValue = ColumnValue;

            //UpdateStatus($"Mapping '{ColumnValue}' to '{NewInstance.ToShortDateString()}'");

            ColumnValue = ColumnValue.ToDate().ToString("dd/MM/yyyy");

            while (ColumnValue == "01/01/0001")
            {
                if (AllowInTransformEdits)
                {
                    frmDate DateForm = new frmDate(OriginalValue);

                    DialogResult Result = DateForm.ShowDialog();

                    if (Result == DialogResult.OK)
                    {
                        ColumnValue = DateForm.Output;

                        //if (DateForm.Save)
                        //{
                        //    int ItemIndex = SourceValuesListbox.FindStringExact(OriginalValue);
                        //    SourceValuesListbox.Items[ItemIndex] = ColumnValue;
                        //}
                    }
                    else
                    {
                        ColumnValue = OriginalValue;
                    }
                }
                else
                {
                    ColumnValue = OriginalValue;
                }
            }

            if (TransformMethodType == MethodType.Database_Mapping)
            {
                NewInstance = (DateTime)DatabaseValuesListbox.Items[ValueIndex];
                CommonResult = 100;
            }
            else
            {
                NewInstance = Transform.Execute(ColumnValue, TransformMethodType, TransformParameters).As<DateTime>(DateTime.MinValue);
                CommonResult = 100;
            }

            ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.DateOfBirth, (DateTime)NewInstance, Manual, TransformMethodType, TransformParameters));

            return NewInstance;
        }

        private Judo.Gender MapGender(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            Judo.Gender NewInstance = Judo.Gender.Unknown;
            double CommonResult = 0;
            string OriginalValue = ColumnValue;

            if (TransformMethodType == MethodType.None)
            {
                //UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                if (ValueIndex != -1)
                {
                    NewInstance = (Judo.Gender)DatabaseValuesListbox.Items[ValueIndex];
                }
                else
                {
                    throw new NotImplementedException();
                }
                //UpdateStatus($"Comparing {ColumnValue} with {((Judo.Gender)NewInstance)}");

            }

            #region Replace common values

            // Process females first because "women" contains "men" etc

            if (DatabaseValuesListbox.FindStringExact(ColumnValue) == -1)
            {
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
            }

            #endregion

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    CommonResult = ((Judo.Gender)NewInstance).ToString().CompareWith(ColumnValue);

                    if (CommonResult >= Properties.Settings.Default.EuroJudoGenderValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.Gender, (Judo.Gender)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.Gender, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.Gender, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private Belt MapBelt(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            Belt NewInstance = null;
            double NameResult = 0.0;
            double ColourResult = 0.0;
            double RankResult = 0.0;
            double InitialResult = 0.0;
            double FinalResult = 0.0;
            string OriginalValue = ColumnValue;

            if (TransformMethodType == MethodType.None)
            {
                //UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                if (ValueIndex != -1)
                {
                    NewInstance = (Belt)DatabaseValuesListbox.Items[ValueIndex];
                }
                else
                {
                    throw new NotImplementedException();
                }
                //UpdateStatus($"Comparing {ColumnValue} with {((Belt)NewInstance).Colour}");
            }

            #region Replace common values

            if (ColumnValue != null)
            {
                // Remove the words "black tip"
                ColumnValue = ColumnValue.Replace("black tip", "");
                ColumnValue = ColumnValue.Replace("Black Tip", "");
                ColumnValue = ColumnValue.Replace("Black tip", "");
                ColumnValue = ColumnValue.Replace("black Tip", "");
                ColumnValue = ColumnValue.Replace("BLACK TIP", "");
                ColumnValue = ColumnValue.Replace("blk tip", "");

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
                ColumnValue = ColumnValue.Replace("eighth", "8th");
                ColumnValue = ColumnValue.Replace("ninth", "9th");
                ColumnValue = ColumnValue.Replace("tenth", "10th");

                ColumnValue = ColumnValue.Replace("First", "1st");
                ColumnValue = ColumnValue.Replace("Second", "2nd");
                ColumnValue = ColumnValue.Replace("Third", "3rd");
                ColumnValue = ColumnValue.Replace("Fourth", "4th");
                ColumnValue = ColumnValue.Replace("Fifth", "5th");
                ColumnValue = ColumnValue.Replace("Sixth", "6th");
                ColumnValue = ColumnValue.Replace("Seventh", "7th");
                ColumnValue = ColumnValue.Replace("Eighth", "8th");
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
                    NameResult = ((Belt)NewInstance).Name.CompareWith(ColumnValue);
                    ColourResult = ((Belt)NewInstance).Colour.CompareWith(ColumnValue);
                    RankResult = ((Belt)NewInstance).Rank.CompareWith(ColumnValue.Replace(" ", "").Trim());

                    #region Compare Name and Colour

                    if (NameResult >= ColourResult)
                    {
                        InitialResult = NameResult;
                    }
                    else if (ColourResult > NameResult)
                    {
                        InitialResult = ColourResult;
                    }
                    else if (double.IsNaN(NameResult) && double.IsNaN(ColourResult))
                    {
                        InitialResult = 0;
                    }
                    else if (double.IsNaN(NameResult))
                    {
                        InitialResult = ColourResult;
                    }
                    else if (double.IsNaN(ColourResult))
                    {
                        InitialResult = NameResult;
                    }
                    else
                    {
                        // Oops
                        Console.WriteLine("What now?");
                    }

                    #endregion

                    #region Compare Highest of Name and Colour result with Rank result

                    if (InitialResult >= RankResult)
                    {
                        FinalResult = InitialResult;
                    }
                    else if (RankResult > InitialResult)
                    {
                        FinalResult = RankResult;
                    }
                    else if (double.IsNaN(InitialResult) && double.IsNaN(RankResult))
                    {
                        FinalResult = 0;
                    }
                    else if (double.IsNaN(InitialResult))
                    {
                        FinalResult = RankResult;
                    }
                    else if (double.IsNaN(RankResult))
                    {
                        FinalResult = InitialResult;
                    }
                    else
                    {
                        // Oops
                        Console.WriteLine("What now?");
                    }

                    #endregion

                    if (FinalResult >= Properties.Settings.Default.BeltValueMinimumComparison || Manual)
                    {
                        //ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, ((Belt)NewInstance).Name, TopResult2, EuroJudo.Column.Belt, (Belt)NewInstance, Manual, TransformMethodType, TransformParameters));
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, FinalResult, Judo.DataColumnType.EuroJudo_Belt, (Belt)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    FinalResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, TopResult2, EuroJudo.Column.Belt, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, FinalResult, Judo.DataColumnType.EuroJudo_Belt, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private string MapFirstName(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            string NewInstance = "";
            double CommonResult = 0;

            if (TransformMethodType == MethodType.Database_Mapping)
            {
                NewInstance = (string)DatabaseValuesListbox.Items[ValueIndex];
                CommonResult = ColumnValue.CompareWith(NewInstance);
            }
            else
            {
                NewInstance = Transform.Execute(ColumnValue.Capitalise(), TransformMethodType, TransformParameters);
                CommonResult = 100;
            }

            //UpdateStatus($"Mapping '{ColumnValue}' to '{NewInstance}'");

            ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, Judo.DataColumnType.FirstName, (string)NewInstance, Manual, TransformMethodType, TransformParameters));

            return NewInstance;
        }

        private string MapLastName(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            string NewInstance = "";
            double CommonResult = 0;

            if (TransformMethodType == MethodType.Database_Mapping)
            {
                NewInstance = (string)DatabaseValuesListbox.Items[ValueIndex];
                CommonResult = ColumnValue.CompareWith(NewInstance);
            }
            else
            {
                NewInstance = Transform.Execute(ColumnValue.Capitalise(), TransformMethodType, TransformParameters);
                CommonResult = 100;
            }

            //UpdateStatus($"Mapping '{ColumnValue}' to '{NewInstance}'");

            ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, Judo.DataColumnType.Surname, (string)NewInstance, Manual, TransformMethodType, TransformParameters));

            return NewInstance;
        }

        private EuroJudo.Function MapEuroJudoFunction(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            EuroJudo.Function NewInstance = EuroJudo.Function.Unknown;
            double CommonResult = 0;
            string OriginalValue = ColumnValue;

            if (TransformMethodType == MethodType.None)
            {
                //UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                if (ValueIndex != -1)
                {
                    NewInstance = (EuroJudo.Function)DatabaseValuesListbox.Items[ValueIndex];
                }
                else
                {
                    throw new NotImplementedException();
                }
                //UpdateStatus($"Comparing {ColumnValue} with {((EuroJudo.Function)NewInstance)}");

            }

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    CommonResult = ((EuroJudo.Function)NewInstance).ToString().CompareWith(ColumnValue);

                    if (CommonResult >= Properties.Settings.Default.EuroJudoFunctionValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.EuroJudo_Function, (EuroJudo.Function)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.Gender, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.EuroJudo_Function, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private IJF.Function MapIJFFunction(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            IJF.Function NewInstance = IJF.Function.Unknown;
            double CommonResult = 0;
            string OriginalValue = ColumnValue;

            if (TransformMethodType == MethodType.None)
            {
                //UpdateStatus($"Mapping '{ColumnValue}' to [NONE]");
            }
            else
            {
                if (ValueIndex != -1)
                {
                    NewInstance = (IJF.Function)DatabaseValuesListbox.Items[ValueIndex];
                }
                else
                {
                    throw new NotImplementedException();
                }
                //UpdateStatus($"Comparing {ColumnValue} with {((IJF.Function)NewInstance)}");

            }

            switch (TransformMethodType)
            {
                case MethodType.Database_Mapping:
                    CommonResult = ((IJF.Function)NewInstance).ToString().CompareWith(ColumnValue);

                    if (CommonResult >= Properties.Settings.Default.IJFFunctionValueMinimumComparison || Manual)
                    {
                        ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.IJF_Function, (IJF.Function)NewInstance, Manual, TransformMethodType, TransformParameters));
                    }
                    break;
                case MethodType.None:
                    CommonResult = 100;

                    //ValueResults.Add(new ComparisonResult(null, ColumnIndex, null, CommonResult, EuroJudo.Column.Gender, null, Manual, TransformMethodType, TransformParameters));
                    ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, Judo.DataColumnType.IJF_Function, null, Manual, TransformMethodType, TransformParameters));
                    break;
            }

            return NewInstance;
        }

        private string MapPhoto(ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool Manual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        {
            string NewInstance = "";
            double CommonResult = 0;

            if (TransformMethodType == MethodType.Database_Mapping)
            {
                NewInstance = (string)DatabaseValuesListbox.Items[ValueIndex];
                CommonResult = ColumnValue.CompareWith(NewInstance);
            }
            else
            {
                NewInstance = Transform.Execute(ColumnValue.Capitalise(), TransformMethodType, TransformParameters);
                CommonResult = 100;
            }

            //UpdateStatus($"Mapping '{ColumnValue}' to '{NewInstance}'");

            ValueResults.Add(new ComparisonResult(ColumnValue, ColumnIndex, CommonResult, Judo.DataColumnType.IJF_Photo, (string)NewInstance, Manual, TransformMethodType, TransformParameters));

            return NewInstance;
        }

        //private object MapType<TEnum>(Enum ColumnType, ListBox DatabaseValuesListbox, int ColumnIndex, List<ComparisonResult> ValueResults, string ColumnValue, int ValueIndex, bool IsManual, Transform.MethodType TransformMethodType, string[] TransformParameters, bool AllowInTransformEdits)
        //{
        //    object NewInstance = default(TEnum);
        //    double CommonResult = 0;
        //    string OriginalValue = ColumnValue;

        //    #region DateTime

        //    if (typeof(TEnum).Name == "DateTime")
        //    {
        //        ColumnValue = ColumnValue.ToDate().ToString("dd/MM/yyyy");

        //        while (ColumnValue == "01/01/0001")
        //        {
        //            if (AllowInTransformEdits)
        //            {
        //                frmDate DateForm = new frmDate(OriginalValue);

        //                DialogResult Result = DateForm.ShowDialog();

        //                if (Result == DialogResult.OK)
        //                {
        //                    ColumnValue = DateForm.Output;
        //                }
        //                else
        //                {
        //                    ColumnValue = OriginalValue;
        //                }
        //            }
        //            else
        //            {
        //                ColumnValue = OriginalValue;
        //            }
        //        }
        //    }

        //    #endregion

        //    switch (TransformMethodType)
        //    {
        //        case MethodType.Database_Mapping:
        //            CommonResult = ((TEnum)NewInstance).ToString().CompareWith(ColumnValue.ToString());

        //            if (CommonResult >= Properties.Settings.Default.IJFFunctionValueMinimumComparison || IsManual)
        //            {
        //                ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, typeof(TEnum), (TEnum)NewInstance, IsManual, TransformMethodType, TransformParameters));
        //            }
        //            break;
        //        case MethodType.None:
        //            CommonResult = 100;

        //            ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, typeof(TEnum), default(TEnum), IsManual, TransformMethodType, TransformParameters));
        //            break;
        //        default:
        //            if (typeof(TEnum).Name == "string")
        //            {
        //                NewInstance = (TEnum)Convert.ChangeType(Transform.Execute(ColumnValue, TransformMethodType, TransformParameters), typeof(TEnum));

        //                CommonResult = 100;
        //            }

        //            ValueResults.Add(new ComparisonResult(OriginalValue, ColumnIndex, CommonResult, typeof(TEnum), (TEnum)NewInstance, IsManual, TransformMethodType, TransformParameters));

        //            break;
        //    }

        //    return NewInstance;
        //}


        #endregion

        #region Add_x_ComparisonResult

        private void AddEventComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Event>> Mappings = new List<StringToObjectMapping<Event>>();
            ListViewItem NewItem = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Event> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<Event>(ColumnValue, Result.ValueIndex, (Event)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _EventMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Event ThisEvent = Mappings[0].DestinationObject; // (Event)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisEvent.Name });
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                NewItem.Tag = TopResults;
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.Remove(ColumnValue);
            }
        }

        private void AddEuroJudoWeightCategoryComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<EuroJudo.WeightCategory>> Mappings = new List<StringToObjectMapping<EuroJudo.WeightCategory>>();
            ListViewItem NewItem = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<EuroJudo.WeightCategory> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<EuroJudo.WeightCategory>(ColumnValue, Result.ValueIndex, (EuroJudo.WeightCategory)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _EuroJudoWeightCategoryMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    EuroJudo.WeightCategory ThisWeightCategory = Mappings[0].DestinationObject;

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

                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);
                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddIJFWeightCategoryComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Judo.WeightCategory>> Mappings = new List<StringToObjectMapping<Judo.WeightCategory>>();
            ListViewItem NewItem = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Judo.WeightCategory> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<Judo.WeightCategory>(ColumnValue, Result.ValueIndex, (Judo.WeightCategory)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _IJFWeightCategoryMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Judo.WeightCategory ThisWeightCategory = Mappings[0].DestinationObject;

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisWeightCategory.Name });

                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);
                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddClubComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Club>> Mappings = new List<StringToObjectMapping<Club>>();
            ListViewItem NewItem = null;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Club> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<Club>(ColumnValue, Result.ValueIndex, (Club)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _ClubMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Club ThisClub = Mappings[0].DestinationObject; // (Club)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisClub.ToString(), ThisClub.Code });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                if (lstImportedColumnValues.Items.Count >= ColumnIndex + 1)
                {
                    lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
                }
            }
        }

        private void AddMemberIDComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<string>> Mappings = new List<StringToObjectMapping<string>>();
            ListViewItem NewItem = null;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<string> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<string>(ColumnValue, Result.ValueIndex, (string)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _MemberIDMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    string ThisMemberID = Mappings[0].DestinationObject; // (string)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisMemberID });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddDateOfBirthComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<DateTime>> Mappings = new List<StringToObjectMapping<DateTime>>();
            ListViewItem NewItem = null;
            string ResultValue = "";

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<DateTime> ThisMapping = null;
                ResultValue = Result.Value.ToString();

                if (SelectedMethodType == MethodType.None)
                {
                    ThisMapping = new StringToObjectMapping<DateTime>(ColumnValue, Result.ValueIndex, DateTime.MinValue, SelectedMethodType, TransformParameters);
                }
                else
                {
                    ThisMapping = new StringToObjectMapping<DateTime>(ColumnValue, Result.ValueIndex, ResultValue.As<DateTime>(DateTime.MinValue), SelectedMethodType, TransformParameters);
                }

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _DateOfBirthMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    DateTime ThisDateOfBirth = Mappings[0].DestinationObject; // (int)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisDateOfBirth.ToShortDateString() });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        //private void AddDayOfBirthComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        //{
        //    List<StringToObjectMapping<int>> Mappings = new List<StringToObjectMapping<int>>();
        //    ListViewItem NewItem = null;
        //    string ResultValue = "";

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

        //    foreach (ComparisonResult Result in TopResults)
        //    {
        //        StringToObjectMapping<int> ThisMapping = null;
        //        ResultValue = Result.Value.ToString();

        //        if (SelectedMethodType == MethodType.None)
        //        {
        //            ThisMapping = new StringToObjectMapping<int>(ColumnValue, Result.ValueIndex, 0, SelectedMethodType, TransformParameters);
        //        }
        //        else
        //        {
        //            ThisMapping = new StringToObjectMapping<int>(ColumnValue, Result.ValueIndex, ResultValue.As<int>(0), SelectedMethodType, TransformParameters);
        //        }

        //        Mappings.Add(ThisMapping);

        //        if (TopResults.Count == 1)
        //        {
        //            DayOfBirthMappings.Add(ThisMapping);
        //        }
        //    }

        //    switch (TopResults.Count)
        //    {
        //        case 0:
        //            break;
        //        case 1:
        //            int ThisDayOfBirth = Mappings[0].DestinationObject; // (int)(TopResults[0].Value);

        //            if (SelectedMethodType != MethodType.None)
        //            {
        //                NewItem = new ListViewItem(new string[] { ColumnValue, ThisDayOfBirth.ToString() });
        //                NewItem.Tag = TopResults;
        //                NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
        //            }
        //            else
        //            {
        //                NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
        //                NewItem.Tag = TopResults;
        //                NewItem.BackColor = Color.LightGray;
        //            }

        //            break;
        //        default: // > 1
        //            NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
        //            NewItem.Tag = TopResults;
        //            NewItem.BackColor = Color.LightSalmon;

        //            MappingMultipleItemCount++;
        //            EnableDisablePrevNextButtons();
        //            break;
        //    }

        //    if (NewItem != null)
        //    {
        //        lvwDatabaseMappingResults.Items.Add(NewItem);

        //        lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
        //    }
        //}

        //private void AddMonthOfBirthComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        //{
        //    List<StringToObjectMapping<int>> Mappings = new List<StringToObjectMapping<int>>();
        //    ListViewItem NewItem = null;
        //    string ResultValue = "";

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

        //    foreach (ComparisonResult Result in TopResults)
        //    {
        //        StringToObjectMapping<int> ThisMapping = null;
        //        ResultValue = Result.Value.ToString();

        //        if (SelectedMethodType == MethodType.None)
        //        {
        //            ThisMapping = new StringToObjectMapping<int>(ColumnValue, Result.ValueIndex, 0, SelectedMethodType, TransformParameters);
        //        }
        //        else
        //        {
        //            ThisMapping = new StringToObjectMapping<int>(ColumnValue, Result.ValueIndex, ResultValue.As<int>(0), SelectedMethodType, TransformParameters);
        //        }

        //        Mappings.Add(ThisMapping);

        //        if (TopResults.Count == 1)
        //        {
        //            MonthOfBirthMappings.Add(ThisMapping);
        //        }
        //    }

        //    switch (TopResults.Count)
        //    {
        //        case 0:
        //            break;
        //        case 1:
        //            int ThisMonthOfBirth = Mappings[0].DestinationObject; // (int)(TopResults[0].Value);

        //            if (SelectedMethodType != MethodType.None)
        //            {
        //                NewItem = new ListViewItem(new string[] { ColumnValue, ThisMonthOfBirth.ToString() });
        //                NewItem.Tag = TopResults;
        //                NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
        //            }
        //            else
        //            {
        //                NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
        //                NewItem.Tag = TopResults;
        //                NewItem.BackColor = Color.LightGray;
        //            }

        //            break;
        //        default: // > 1
        //            NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
        //            NewItem.Tag = TopResults;
        //            NewItem.BackColor = Color.LightSalmon;

        //            MappingMultipleItemCount++;
        //            EnableDisablePrevNextButtons();
        //            break;
        //    }

        //    if (NewItem != null)
        //    {
        //        lvwDatabaseMappingResults.Items.Add(NewItem);

        //        lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
        //    }
        //}

        //private void AddYearOfBirthComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        //{
        //    List<StringToObjectMapping<int>> Mappings = new List<StringToObjectMapping<int>>();
        //    ListViewItem NewItem = null;
        //    string ResultValue = "";

        //    Debug.Print($"Inside {CurrentMethodName()}");

        //    List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

        //    foreach (ComparisonResult Result in TopResults)
        //    {
        //        StringToObjectMapping<int> ThisMapping = null;
        //        ResultValue = Result.Value.ToString();

        //        if (SelectedMethodType == MethodType.None)
        //        {
        //            ThisMapping = new StringToObjectMapping<int>(ColumnValue, Result.ValueIndex, 0, SelectedMethodType, TransformParameters);
        //        }
        //        else
        //        {
        //            ThisMapping = new StringToObjectMapping<int>(ColumnValue, Result.ValueIndex, ResultValue.As<int>(0), SelectedMethodType, TransformParameters);
        //        }

        //        Mappings.Add(ThisMapping);

        //        if (TopResults.Count == 1)
        //        {
        //            YearOfBirthMappings.Add(ThisMapping);
        //        }
        //    }

        //    switch (TopResults.Count)
        //    {
        //        case 0:
        //            break;
        //        case 1:
        //            int ThisYearOfBirth = Mappings[0].DestinationObject; // (int)(TopResults[0].Value);

        //            if (SelectedMethodType != MethodType.None)
        //            {
        //                NewItem = new ListViewItem(new string[] { ColumnValue, ThisYearOfBirth.ToString() });
        //                NewItem.Tag = TopResults;
        //                NewItem.BackColor = lvwDatabaseMappingResults.BackColor;
        //            }
        //            else
        //            {
        //                NewItem = new ListViewItem(new string[] { ColumnValue, "[NONE]" });
        //                NewItem.Tag = TopResults;
        //                NewItem.BackColor = Color.LightGray;
        //            }

        //            break;
        //        default: // > 1
        //            NewItem = new ListViewItem(new string[] { ColumnValue, "Multiple (" + TopResults.Count + ")", "*" });
        //            NewItem.Tag = TopResults;
        //            NewItem.BackColor = Color.LightSalmon;

        //            MappingMultipleItemCount++;
        //            EnableDisablePrevNextButtons();
        //            break;
        //    }

        //    if (NewItem != null)
        //    {
        //        lvwDatabaseMappingResults.Items.Add(NewItem);

        //        lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
        //    }
        //}

        private void AddGenderComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Judo.Gender>> Mappings = new List<StringToObjectMapping<Judo.Gender>>();
            ListViewItem NewItem = null;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Judo.Gender> ThisMapping = null;

                if (Result.Value != null)
                {
                    ThisMapping = new StringToObjectMapping<Judo.Gender>(ColumnValue, Result.ValueIndex, (Judo.Gender)Result.Value, SelectedMethodType, TransformParameters);
                }
                else
                {
                    ThisMapping = new StringToObjectMapping<Judo.Gender>(ColumnValue, Result.ValueIndex, Judo.Gender.Unknown, SelectedMethodType, TransformParameters);
                }

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _GenderMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Judo.Gender ThisGender = Judo.Gender.Unknown;

                    if (SelectedMethodType != MethodType.None)
                    {
                        ThisGender = (Judo.Gender)(TopResults[0].Value);

                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisGender.ToString() });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddBeltComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<Belt>> Mappings = new List<StringToObjectMapping<Belt>>();
            ListViewItem NewItem = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<Belt> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<Belt>(ColumnValue, Result.ValueIndex, (Belt)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _BeltMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    Belt ThisBelt = Mappings[0].DestinationObject; // (Belt)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisBelt.ToString(), ThisBelt.Name });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddFirstNameComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<string>> Mappings = new List<StringToObjectMapping<string>>();
            ListViewItem NewItem = null;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<string> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<string>(ColumnValue, Result.ValueIndex, (string)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _FirstNameMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    string ThisFirstName = Mappings[0].DestinationObject; // (string)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisFirstName });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddLastNameComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<string>> Mappings = new List<StringToObjectMapping<string>>();
            ListViewItem NewItem = null;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<string> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<string>(ColumnValue, Result.ValueIndex, (string)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _LastNameMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    string ThisLastName = Mappings[0].DestinationObject; // (string)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisLastName });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddEuroJudoFunctionComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<EuroJudo.Function>> Mappings = new List<StringToObjectMapping<EuroJudo.Function>>();
            ListViewItem NewItem = null;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<EuroJudo.Function> ThisMapping = null;

                if (SelectedMethodType == MethodType.None)
                {
                    ThisMapping = new StringToObjectMapping<EuroJudo.Function>(ColumnValue, Result.ValueIndex, EuroJudo.Function.Unknown, SelectedMethodType, TransformParameters);
                }
                else
                {
                    ThisMapping = new StringToObjectMapping<EuroJudo.Function>(ColumnValue, Result.ValueIndex, (EuroJudo.Function)Result.Value, SelectedMethodType, TransformParameters);
                }

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _EuroJudoFunctionMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    EuroJudo.Function ThisFunction = EuroJudo.Function.Unknown;

                    if (SelectedMethodType != MethodType.None)
                    {
                        ThisFunction = (EuroJudo.Function)(TopResults[0].Value);

                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisFunction.ToString() });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddIJFFunctionComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<IJF.Function>> Mappings = new List<StringToObjectMapping<IJF.Function>>();
            ListViewItem NewItem = null;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<IJF.Function> ThisMapping = null;

                if (SelectedMethodType == MethodType.None)
                {
                    ThisMapping = new StringToObjectMapping<IJF.Function>(ColumnValue, Result.ValueIndex, IJF.Function.Unknown, SelectedMethodType, TransformParameters);
                }
                else
                {
                    ThisMapping = new StringToObjectMapping<IJF.Function>(ColumnValue, Result.ValueIndex, (IJF.Function)Result.Value, SelectedMethodType, TransformParameters);
                }

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _IJFFunctionMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    IJF.Function ThisFunction = IJF.Function.Unknown;

                    if (SelectedMethodType != MethodType.None)
                    {
                        ThisFunction = (IJF.Function)(TopResults[0].Value);

                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisFunction.ToString() });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        private void AddPhotoComparisonResults(string ColumnValue, int ColumnIndex, List<ComparisonResult> Results, double MinimumComparisonResult, MethodType SelectedMethodType, string[] TransformParameters)
        {
            List<StringToObjectMapping<string>> Mappings = new List<StringToObjectMapping<string>>();
            ListViewItem NewItem = null;
            //string[] TransformParameters = { };

            Debug.Print($"Inside {CurrentMethodName()}");

            List<ComparisonResult> TopResults = Results.Where(r => r.Percentage >= MinimumComparisonResult || r.Manual == true).ToList<ComparisonResult>();

            foreach (ComparisonResult Result in TopResults)
            {
                StringToObjectMapping<string> ThisMapping = null;

                ThisMapping = new StringToObjectMapping<string>(ColumnValue, Result.ValueIndex, (string)Result.Value, SelectedMethodType, TransformParameters);

                Mappings.Add(ThisMapping);

                if (TopResults.Count == 1)
                {
                    _IJFPhotoMappings.Add(ThisMapping);
                }
            }

            switch (TopResults.Count)
            {
                case 0:
                    break;
                case 1:
                    string ThisPhotoPath = Mappings[0].DestinationObject; // (string)(TopResults[0].Value);

                    if (SelectedMethodType != MethodType.None)
                    {
                        NewItem = new ListViewItem(new string[] { ColumnValue, ThisPhotoPath });
                        NewItem.Tag = TopResults;
                        NewItem.BackColor = lvwMappingResults.BackColor;
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

                    _MappingMultipleItemCount++;
                    EnableDisablePrevNextButtons();
                    break;
            }

            if (NewItem != null)
            {
                lvwMappingResults.Items.Add(NewItem);

                lstImportedColumnValues.Items.RemoveAt(ColumnIndex);
            }
        }

        #endregion

        private void ResetCurrentMappings()
        {
            switch (_CurrentMappingType)
            {
                case DataColumnType.Unknown:
                    break;
                case Judo.DataColumnType.EuroJudo_Event:
                    {
                        _EventMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.EuroJudo_WeightCategory:
                    {
                        _EuroJudoWeightCategoryMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.IJF_WeightCategory:
                    {
                        _IJFWeightCategoryMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.Club:
                    {
                        _ClubMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.MemberID:
                    {
                        _MemberIDMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.DateOfBirth:
                    {
                        _DateOfBirthMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.Gender:
                    {
                        _GenderMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.EuroJudo_Belt:
                    {
                        _BeltMappings.Clear();

                        break;
                    }
                case Judo.DataColumnType.FirstName:
                    {
                        _FirstNameMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.Surname:
                    {
                        _LastNameMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.EuroJudo_Function:
                    {
                        _EuroJudoFunctionMappings.Clear();
                        break;
                    }
                case Judo.DataColumnType.IJF_Function:
                    {
                        _IJFFunctionMappings.Clear();
                        break;
                    }
                case DataColumnType.IJF_Photo:
                    {
                        _IJFPhotoMappings.Clear();
                        break;
                    }
            }
        }

        private void SetMappingType()
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            if (_CurrentMappingType == Judo.DataColumnType.Unknown) // (cmbEuroJudoMappingType.SelectedIndex == -1)
            {
                Debug.Print($"...Leaving {CurrentMethodName()}");
                return;
            }

            btnPreviousMappingType.Enabled = !(cmbMappingType.SelectedIndex == 0);
            btnNextMappingType.Enabled = !(cmbMappingType.SelectedIndex == cmbMappingType.Items.Count - 1);

            lstImportedColumnValues.Items.Clear();
            lstComparisonValue.Items.Clear();
            lvwMappingResults.Items.Clear();

            lblMappingTypeHint.Text = "Step " + (cmbMappingType.SelectedIndex + 1).ToString() + " of " + cmbMappingType.Items.Count.ToString();

            switch (_PreviousMappingType)
            {
                case DataColumnType.Unknown:
                    break;
                case Judo.DataColumnType.EuroJudo_Event:
                    {
                        // Save these mappings
                        // NOTE:  FUTURE Enhancement

                        string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoEventMappings.save");

                        _EventMappings.SaveToFile(FullFilename);

                        break;
                    }
                case Judo.DataColumnType.EuroJudo_WeightCategory:
                    {
                        // Save these mappings
                        // NOTE:  FUTURE Enhancement

                        string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoWeightCategoryMappings.save");

                        _EuroJudoWeightCategoryMappings.SaveToFile(FullFilename);

                        break;
                    }
                case Judo.DataColumnType.IJF_WeightCategory:
                    {
                        // Save these mappings
                        // NOTE:  FUTURE Enhancement

                        string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "IJFWeightCategoryMappings.save");

                        _IJFWeightCategoryMappings.SaveToFile(FullFilename);

                        break;
                    }
                case Judo.DataColumnType.Club:
                    {
                        // Save these mappings

                        string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoClubMappings.save");

                        _ClubMappings.SaveToFile(FullFilename);

                        _PersonClubMapped = _ClubMappings.Count > 0;


                        break;
                    }
                case Judo.DataColumnType.MemberID:
                    {
                        break;
                    }
                case Judo.DataColumnType.DateOfBirth:
                    {
                        _PersonDateOfBirthMapped = _DateOfBirthMappings.Count > 0;
                        break;
                    }
                case Judo.DataColumnType.Gender:
                    {
                        _PersonGenderMapped = _GenderMappings.Count > 0;
                        break;
                    }
                case Judo.DataColumnType.EuroJudo_Belt:
                    {
                        // Save these mappings

                        string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoBeltMappings.save");

                        //BeltMappings.SaveToFile(FullFilename);

                        break;
                    }
                case Judo.DataColumnType.FirstName:
                    {
                        _PersonFirstNameMapped = _FirstNameMappings.Count > 0;

                        break;
                    }
                case Judo.DataColumnType.Surname:
                    {
                        _PersonSurnameMapped = _LastNameMappings.Count > 0;
                        break;
                    }
                case Judo.DataColumnType.EuroJudo_Function:
                    {
                        // Save these mappings

                        string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoFunctionMappings.save");

                        _EuroJudoFunctionMappings.SaveToFile(FullFilename);

                        break;
                    }
                case Judo.DataColumnType.IJF_Function:
                    {
                        // Save these mappings

                        string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "IJFFunctionMappings.save");

                        _IJFFunctionMappings.SaveToFile(FullFilename);

                        break;
                    }
                case Judo.DataColumnType.IJF_Photo:
                    {
                        break;
                    }
            }

            switch (_CurrentMappingType)
            {
                case DataColumnType.Unknown:
                    break;
                case DataColumnType.EuroJudo_Event:
                    {
                        trbComparisonMinimum.Enabled = true;
                        trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoEventValueMinimumComparison;

                        if (Properties.Settings.Default.PreviousEuroJudoEventTypeColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousEuroJudoEventTypeColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousEuroJudoEventTypeColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }
                        break;
                    }
                case DataColumnType.EuroJudo_WeightCategory:
                    {
                        trbComparisonMinimum.Enabled = true;
                        trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoWeightValueMinimumComparison;

                        if (Properties.Settings.Default.PreviousEuroJudoWeightCategoryColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousEuroJudoWeightCategoryColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousEuroJudoWeightCategoryColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }
                        break;
                    }
                case DataColumnType.IJF_WeightCategory:
                    {
                        trbComparisonMinimum.Enabled = true;
                        trbComparisonMinimum.Value = (int)Properties.Settings.Default.IJFWeightValueMinimumComparison;

                        if (Properties.Settings.Default.PreviousIJFWeightCategoryColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousIJFWeightCategoryColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousIJFWeightCategoryColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }
                        break;
                    }
                case DataColumnType.Club:
                    {
                        trbComparisonMinimum.Enabled = true;
                        trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoClubValueMinimumComparison;

                        if (Properties.Settings.Default.PreviousClubColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousClubColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousClubColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }
                        break;
                    }
                case DataColumnType.MemberID:
                    {
                        trbComparisonMinimum.Value = 0;
                        trbComparisonMinimum.Enabled = false;
                        lblMinComparisonValue.Text = "-";

                        if (Properties.Settings.Default.PreviousMemberIDColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousMemberIDColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousMemberIDColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }

                        break;
                    }
                case DataColumnType.DateOfBirth:
                    {
                        trbComparisonMinimum.Value = 0;
                        trbComparisonMinimum.Enabled = false;
                        lblMinComparisonValue.Text = "-";

                        if (Properties.Settings.Default.PreviousEuroJudoDayOfBirthColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousDateOfBirthColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousDateOfBirthColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }

                        break;
                    }
                case DataColumnType.Gender:
                    {
                        trbComparisonMinimum.Enabled = true;
                        trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoGenderValueMinimumComparison;

                        if (Properties.Settings.Default.PreviousGenderColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousGenderColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousGenderColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }
                        break;
                    }
                case DataColumnType.EuroJudo_Belt:
                    {
                        trbComparisonMinimum.Enabled = true;
                        trbComparisonMinimum.Value = (int)Properties.Settings.Default.BeltValueMinimumComparison;

                        if (Properties.Settings.Default.PreviousBeltColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousBeltColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousBeltColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }
                        break;
                    }
                case DataColumnType.FirstName:
                    {
                        trbComparisonMinimum.Value = 0;
                        trbComparisonMinimum.Enabled = false;
                        lblMinComparisonValue.Text = "-";

                        if (Properties.Settings.Default.PreviousFirstNameColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousFirstNameColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousFirstNameColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }

                        break;
                    }
                case DataColumnType.Surname:
                    {
                        trbComparisonMinimum.Value = 0;
                        trbComparisonMinimum.Enabled = false;
                        lblMinComparisonValue.Text = "-";

                        if (Properties.Settings.Default.PreviousSurnameColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousSurnameColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousSurnameColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }

                        break;
                    }
                case DataColumnType.EuroJudo_Function:
                    {
                        trbComparisonMinimum.Enabled = true;
                        trbComparisonMinimum.Value = (int)Properties.Settings.Default.EuroJudoFunctionValueMinimumComparison;

                        if (Properties.Settings.Default.PreviousEuroJudoFunctionColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousEuroJudoFunctionColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousEuroJudoFunctionColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }
                        break;
                    }
                case DataColumnType.IJF_Function:
                    {
                        trbComparisonMinimum.Enabled = true;
                        trbComparisonMinimum.Value = (int)Properties.Settings.Default.IJFFunctionValueMinimumComparison;

                        if (Properties.Settings.Default.PreviousIJFFunctionColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousIJFFunctionColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousIJFFunctionColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }
                        break;
                    }
                case DataColumnType.IJF_Photo:
                    {
                        trbComparisonMinimum.Value = 0;
                        trbComparisonMinimum.Enabled = false;
                        lblMinComparisonValue.Text = "-";

                        if (Properties.Settings.Default.PreviousIJFPhotoColumnIndex != -1)
                        {
                            if (cmbColumnNamesFromImportData.Items.Count > 0 && cmbColumnNamesFromImportData.Items.Count >= Properties.Settings.Default.PreviousIJFPhotoColumnIndex + 1)
                            {
                                cmbColumnNamesFromImportData.SelectedIndex = Properties.Settings.Default.PreviousIJFPhotoColumnIndex;
                            }
                        }
                        else
                        {
                            cmbColumnNamesFromImportData.SelectedIndex = -1;
                        }

                        break;
                    }
            }

            GetComparisonData();

            EnableDisableAutoButton();

            if (cmbColumnNamesFromImportData.SelectedIndex != -1)
            {
                ShowExistingMappings(_CurrentMappingType);
            }

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

        private void ShowExistingMappings(Judo.DataColumnType MappingType)
        {
            ListViewItem NewItem = null;

            lvwMappingResults.Items.Clear();

            lvwMappingResults.BeginUpdate();
            lstImportedColumnValues.BeginUpdate();

            switch (_CurrentMappingType)
            {
                case DataColumnType.Unknown:
                    break;
                case Judo.DataColumnType.EuroJudo_Event:
                    {
                        // ******************************************************************************************************
                        // ******************************************************************************************************
                        //
                        // Events are dependent upon the Tournament, so don't load unless the DoSave() function accounts for it
                        //
                        // ******************************************************************************************************
                        // ******************************************************************************************************

                        //if (false)
                        //{
                        //    // We may have previous mappings - if so, set them here
                        //    string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        //    string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoEventMappings.save");
                        //    List<StringToObjectMapping<Event>> PreviousEventMappings = new List<StringToObjectMapping<Event>>();

                        //    if (System.IO.File.Exists(FullFilename))
                        //    {
                        //        PreviousEventMappings = PreviousEventMappings.LoadFromFile(FullFilename);

                        //        if (PreviousEventMappings.Count > 0)
                        //        {
                        //            EventMappings = PreviousEventMappings;
                        //        }
                        //    }
                        //}

                        foreach (StringToObjectMapping<Event> ThisMapping in _EventMappings)
                        {
                            List<ComparisonResult> EventComparisonResults = new List<ComparisonResult>();

                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                ComparisonResult ThisComparisonResult = new ComparisonResult(ThisMapping.SourceValue, ThisMapping.SourceIndex, 100, Judo.DataColumnType.EuroJudo_Event, ThisMapping.DestinationObject, true, MethodType.Database_Mapping, new string[] { });
                                EventComparisonResults.Add(ThisComparisonResult);

                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((Event)ThisMapping.DestinationObject).Name });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                                NewItem.Tag = EventComparisonResults;

                                Debug.WriteLine($"Loaded Event mapping: {ThisMapping.SourceValue} to {ThisMapping.DestinationObject.ToString()}");
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.EuroJudo_WeightCategory:
                    {
                        // ****************************************************************************************************************
                        // ****************************************************************************************************************
                        //
                        // Weight Categories are dependent upon the Tournament, so don't load unless the DoSave() function accounts for it
                        //
                        // ****************************************************************************************************************
                        // ****************************************************************************************************************

                        //if (false)
                        //{
                        //    // We may have previous mappings - if so, set them here
                        //    string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        //    string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoWeightCategoryMappings.save");
                        //    List<StringToObjectMapping<WeightCategory>> PreviousWeightCategoryMappings = new List<StringToObjectMapping<WeightCategory>>();

                        //    if (System.IO.File.Exists(FullFilename))
                        //    {
                        //        PreviousWeightCategoryMappings = PreviousWeightCategoryMappings.LoadFromFile(FullFilename);

                        //        if (PreviousWeightCategoryMappings.Count > 0)
                        //        {
                        //            WeightCategoryMappings = PreviousWeightCategoryMappings;
                        //        }
                        //    }
                        //}

                        foreach (StringToObjectMapping<EuroJudo.WeightCategory> ThisMapping in _EuroJudoWeightCategoryMappings)
                        {
                            List<ComparisonResult> WeightCategoryComparisonResults = new List<ComparisonResult>();

                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                ComparisonResult ThisComparisonResult = new ComparisonResult(ThisMapping.SourceValue, ThisMapping.SourceIndex, 100, Judo.DataColumnType.EuroJudo_WeightCategory, ThisMapping.DestinationObject, true, MethodType.Database_Mapping, new string[] { });
                                WeightCategoryComparisonResults.Add(ThisComparisonResult);

                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((EuroJudo.WeightCategory)ThisMapping.DestinationObject).Name });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                                NewItem.Tag = WeightCategoryComparisonResults;

                                Debug.WriteLine($"Loaded Euro Judo WeightCategory mapping: {ThisMapping.SourceValue} to {ThisMapping.DestinationObject.ToString()}");
                            }


                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.IJF_WeightCategory:
                    {
                        // ****************************************************************************************************************
                        // ****************************************************************************************************************
                        //
                        // Weight Categories are dependent upon the Tournament, so don't load unless the DoSave() function accounts for it
                        //
                        // ****************************************************************************************************************
                        // ****************************************************************************************************************

                        //if (false)
                        //{
                        //    // We may have previous mappings - if so, set them here
                        //    string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        //    string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoWeightCategoryMappings.save");
                        //    List<StringToObjectMapping<WeightCategory>> PreviousWeightCategoryMappings = new List<StringToObjectMapping<WeightCategory>>();

                        //    if (System.IO.File.Exists(FullFilename))
                        //    {
                        //        PreviousWeightCategoryMappings = PreviousWeightCategoryMappings.LoadFromFile(FullFilename);

                        //        if (PreviousWeightCategoryMappings.Count > 0)
                        //        {
                        //            WeightCategoryMappings = PreviousWeightCategoryMappings;
                        //        }
                        //    }
                        //}

                        foreach (StringToObjectMapping<Judo.WeightCategory> ThisMapping in _IJFWeightCategoryMappings)
                        {
                            List<ComparisonResult> WeightCategoryComparisonResults = new List<ComparisonResult>();

                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                ComparisonResult ThisComparisonResult = new ComparisonResult(ThisMapping.SourceValue, ThisMapping.SourceIndex, 100, Judo.DataColumnType.IJF_WeightCategory, ThisMapping.DestinationObject, true, MethodType.Database_Mapping, new string[] { });
                                WeightCategoryComparisonResults.Add(ThisComparisonResult);

                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((Judo.WeightCategory)ThisMapping.DestinationObject).Name });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                                NewItem.Tag = WeightCategoryComparisonResults;

                                Debug.WriteLine($"Loaded IJF WeightCategory mapping: {ThisMapping.SourceValue} to {ThisMapping.DestinationObject.ToString()}");
                            }


                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.Club:
                    {
                        DialogResult LoadPreviousResult = MessageBox.Show("Load previously saved mappings?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (LoadPreviousResult == DialogResult.Yes)
                        {
                            // We may have previous mappings - if so, set them here
                            string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoClubMappings.save");
                            List<StringToObjectMapping<Club>> PreviousClubMappings = new List<StringToObjectMapping<Club>>();

                            if (System.IO.File.Exists(FullFilename))
                            {
                                PreviousClubMappings = PreviousClubMappings.LoadFromFile(FullFilename);

                                if (PreviousClubMappings.Count > 0)
                                {
                                    _ClubMappings = PreviousClubMappings;
                                }
                            }
                        }

                        foreach (StringToObjectMapping<Club> ThisMapping in _ClubMappings)
                        {
                            List<ComparisonResult> ClubComparisonResults = new List<ComparisonResult>();

                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                ComparisonResult ThisComparisonResult = new ComparisonResult(ThisMapping.SourceValue, ThisMapping.SourceIndex, 100, Judo.DataColumnType.Club, ThisMapping.DestinationObject, true, MethodType.Database_Mapping, new string[] { });
                                ClubComparisonResults.Add(ThisComparisonResult);

                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((Club)ThisMapping.DestinationObject).ToString() });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                                NewItem.Tag = ClubComparisonResults;

                                Debug.WriteLine($"Loaded Club mapping: {ThisMapping.SourceValue} to {ThisMapping.DestinationObject.ToString()}");
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.MemberID:
                    {
                        foreach (StringToObjectMapping<string> ThisMapping in _MemberIDMappings)
                        {
                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((string)ThisMapping.DestinationObject) });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.DateOfBirth:
                    {
                        foreach (StringToObjectMapping<DateTime> ThisMapping in _DateOfBirthMappings)
                        {
                            if (ThisMapping.DestinationObject == DateTime.MinValue)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((DateTime)ThisMapping.DestinationObject).ToString() });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.Gender:
                    {
                        foreach (StringToObjectMapping<Judo.Gender> ThisMapping in _GenderMappings)
                        {
                            if (ThisMapping.DestinationObject == Judo.Gender.Unknown)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((Judo.Gender)ThisMapping.DestinationObject).ToString() });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.EuroJudo_Belt:
                    {
                        DialogResult LoadPreviousResult = MessageBox.Show("Load previously saved mappings?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (LoadPreviousResult == DialogResult.Yes)
                        {
                            // We may have previous mappings - if so, set them here
                            string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoBeltMappings.save");
                            List<StringToObjectMapping<Belt>> PreviousBeltMappings = new List<StringToObjectMapping<Belt>>();

                            if (System.IO.File.Exists(FullFilename))
                            {
                                PreviousBeltMappings = PreviousBeltMappings.LoadFromFile(FullFilename);

                                if (PreviousBeltMappings.Count > 0)
                                {
                                    _BeltMappings = PreviousBeltMappings;
                                }
                            }
                        }

                        foreach (StringToObjectMapping<Belt> ThisMapping in _BeltMappings)
                        {
                            List<ComparisonResult> BeltComparisonResults = new List<ComparisonResult>();

                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                ComparisonResult ThisComparisonResult = new ComparisonResult(ThisMapping.SourceValue, ThisMapping.SourceIndex, 100, Judo.DataColumnType.EuroJudo_Belt, ThisMapping.DestinationObject, true, MethodType.Database_Mapping, new string[] { });
                                BeltComparisonResults.Add(ThisComparisonResult);

                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((Belt)ThisMapping.DestinationObject).Rank });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                                NewItem.Tag = BeltComparisonResults;

                                Debug.WriteLine($"Loaded Belt mapping: {ThisMapping.SourceValue} to {ThisMapping.DestinationObject.ToString()}");
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.FirstName:
                    {
                        foreach (StringToObjectMapping<string> ThisMapping in _FirstNameMappings)
                        {
                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((string)ThisMapping.DestinationObject) });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.Surname:
                    {
                        foreach (StringToObjectMapping<string> ThisMapping in _LastNameMappings)
                        {
                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((string)ThisMapping.DestinationObject) });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.EuroJudo_Function:
                    {
                        DialogResult LoadPreviousResult = MessageBox.Show("Load previously saved mappings?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (LoadPreviousResult == DialogResult.Yes)
                        {
                            // We may have previous mappings - if so, set them here
                            string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "EuroJudoFunctionMappings.save");
                            List<StringToObjectMapping<EuroJudo.Function>> PreviousFunctionMappings = new List<StringToObjectMapping<EuroJudo.Function>>();

                            if (System.IO.File.Exists(FullFilename))
                            {
                                PreviousFunctionMappings = PreviousFunctionMappings.LoadFromFile(FullFilename);

                                if (PreviousFunctionMappings.Count > 0)
                                {
                                    _EuroJudoFunctionMappings = PreviousFunctionMappings;
                                }
                            }
                        }

                        foreach (StringToObjectMapping<EuroJudo.Function> ThisMapping in _EuroJudoFunctionMappings)
                        {
                            List<ComparisonResult> FunctionComparisonResults = new List<ComparisonResult>();

                            if (ThisMapping.DestinationObject == EuroJudo.Function.Unknown)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                ComparisonResult ThisComparisonResult = new ComparisonResult(ThisMapping.SourceValue, ThisMapping.SourceIndex, 100, Judo.DataColumnType.EuroJudo_Function, ThisMapping.DestinationObject, true, MethodType.Database_Mapping, new string[] { });
                                FunctionComparisonResults.Add(ThisComparisonResult);

                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((EuroJudo.Function)ThisMapping.DestinationObject).ToString() });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                                NewItem.Tag = FunctionComparisonResults;

                                Debug.WriteLine($"Loaded Euro Judo Function mapping: {ThisMapping.SourceValue} to {ThisMapping.DestinationObject.ToString()}");
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case Judo.DataColumnType.IJF_Function:
                    {
                        DialogResult LoadPreviousResult = MessageBox.Show("Load previously saved mappings?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (LoadPreviousResult == DialogResult.Yes)
                        {
                            // We may have previous mappings - if so, set them here
                            string MyDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            string FullFilename = System.IO.Path.Combine(MyDocumentsFolder, "IJFFunctionMappings.save");
                            List<StringToObjectMapping<IJF.Function>> PreviousFunctionMappings = new List<StringToObjectMapping<IJF.Function>>();

                            if (System.IO.File.Exists(FullFilename))
                            {
                                PreviousFunctionMappings = PreviousFunctionMappings.LoadFromFile(FullFilename);

                                if (PreviousFunctionMappings.Count > 0)
                                {
                                    _IJFFunctionMappings = PreviousFunctionMappings;
                                }
                            }
                        }

                        foreach (StringToObjectMapping<IJF.Function> ThisMapping in _IJFFunctionMappings)
                        {
                            List<ComparisonResult> FunctionComparisonResults = new List<ComparisonResult>();

                            if (ThisMapping.DestinationObject == IJF.Function.Unknown)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                ComparisonResult ThisComparisonResult = new ComparisonResult(ThisMapping.SourceValue, ThisMapping.SourceIndex, 100, Judo.DataColumnType.IJF_Function, ThisMapping.DestinationObject, true, MethodType.Database_Mapping, new string[] { });
                                FunctionComparisonResults.Add(ThisComparisonResult);

                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((IJF.Function)ThisMapping.DestinationObject).ToString() });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                                NewItem.Tag = FunctionComparisonResults;

                                Debug.WriteLine($"Loaded IJF Function mapping: {ThisMapping.SourceValue} to {ThisMapping.DestinationObject.ToString()}");
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
                case DataColumnType.IJF_Photo:
                    {
                        foreach (StringToObjectMapping<string> ThisMapping in _IJFPhotoMappings)
                        {
                            if (ThisMapping.DestinationObject == null)
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, "[NONE]" });
                                NewItem.BackColor = Color.LightGray;
                            }
                            else
                            {
                                NewItem = new ListViewItem(new string[] { ThisMapping.SourceValue, ((string)ThisMapping.DestinationObject) });
                                NewItem.BackColor = lvwMappingResults.BackColor;
                            }

                            if (NewItem != null)
                            {
                                lvwMappingResults.Items.Add(NewItem);

                                lstImportedColumnValues.Items.Remove(ThisMapping.SourceValue);
                            }
                        }

                        break;
                    }
            }

            lstImportedColumnValues.EndUpdate();
            lvwMappingResults.EndUpdate();
        }

        private void RemoveMapping<T>(ComparisonResult SelectedComparisonResult, Transform.MethodType TransformType, List<StringToObjectMapping<T>> MappingList)
        {
            StringToObjectMapping<T> Mapping = null;

            if (SelectedComparisonResult.Value != null)
            {
                Mapping = new StringToObjectMapping<T>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, (T)SelectedComparisonResult.Value, TransformType, null);
            }
            else
            {
                TransformType = Transform.MethodType.None;

                Mapping = new StringToObjectMapping<T>(SelectedComparisonResult.SourceValue, SelectedComparisonResult.ValueIndex, default(T), TransformType, null);
            }

            if (MappingList.Any(x => x.SourceValue.ToString() == Mapping.SourceValue.ToString()))
            {
                StringToObjectMapping<T> MappingToRemove = MappingList.Find(x => x.DestinationObject.ToString() == Mapping.DestinationObject.ToString());
                MappingList.Remove(MappingToRemove);
            }
        }

        private void EnableDisableSetAndAutoButtons()
        {
            btnManualSet.Enabled = (lstImportedColumnValues.SelectedIndices.Count > 0 && lstComparisonValue.SelectedIndices.Count == 1) ||
                                   lstImportedColumnValues.SelectedIndices.Count > 0 && radNone.Checked ||
                                   lstImportedColumnValues.SelectedIndices.Count > 0 && radCopyOrTranslate.Checked;

            btnAutoSet.Enabled = true;
        }

        private void EnableDisableAutoButton()
        {
            btnAutoSet.Enabled = (lstImportedColumnValues.Items.Count > 0 && lstComparisonValue.Items.Count > 0);
        }

        private void EnableDisablePrevNextButtons()
        {
            bool Enable = false;

            if (_MappingMultipleItemCount < 0)
            {
                _MappingMultipleItemCount = 0;
            }

            Enable = _MappingMultipleItemCount == 0 || lstImportedColumnValues.Items.Count == 0;

            btnPreviousMappingType.Enabled = Enable;
            btnNextMappingType.Enabled = Enable;
            cmbMappingType.Enabled = Enable;
            lblMappingIncomplete.Visible = !Enable;
        }

        private void EnableDisableSave()
        {
            //tsbSave.Enabled = (EuroJudoEventMappings.Count > 0) && (EuroJudoWeightCategoryMappings.Count > 0) && (EuroJudoClubMappings.Count > 0);
            //saveToolStripMenuItem.Enabled = tsbSave.Enabled;

        }

        private void EnableDisableResetButton()
        {
            btnResetMappings.Enabled = lvwMappingResults.Items.Count > 0;
        }

        private (MethodType, string[], bool) GetCurrentMethodTypeAndParameters()
        {
            DialogResult dResult = DialogResult.None;
            MethodType Method = MethodType.Unknown;
            bool AllowInTransformEdits = false;
            string[] Parameters = { };

            if (radMapToDatabaseValue.Checked)
            {
                Method = MethodType.Database_Mapping;
            }
            else if (radCopyOrTranslate.Checked)
            {
                frmTranslation TranslationForm = null;
                string ExampleValue = "";

                if (lstImportedColumnValues.Items.Count > 0)
                {
                    if (lstImportedColumnValues.SelectedItems.Count > 0)
                    {
                        ExampleValue = lstImportedColumnValues.SelectedItems[0].ToString();
                    }
                    else
                    {
                        ExampleValue = lstImportedColumnValues.Items[0].ToString();
                    }

                    TranslationForm = new frmTranslation(ExampleValue);

                    dResult = TranslationForm.ShowDialog();

                    if (dResult == DialogResult.OK)
                    {
                        Method = TranslationForm.SelectedMethodType;
                        Parameters = TranslationForm.SelectedTransformParameters;
                        AllowInTransformEdits = TranslationForm.AllowInTransformEdits;
                    }
                }
            }
            else if (radNone.Checked)
            {
                Method = MethodType.None;
            }

            return (Method, Parameters, AllowInTransformEdits);
        }

        private void UpdateStatus(string Text)
        {
            tslblMain.Text = Text;

            ssMain.Refresh();
        }

        private void DoSave()
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            string OriginalCellData = "";
            List<string> RowData = new List<string>();
            List<List<string>> EuroJudoOutput = new List<List<string>>();
            List<string> IJFOutput = new List<string>();
            List<Club> ClubsForExport = new List<Club>();
            List<Location> LocationsForExport = new List<Location>();
            int Counter = 0;
            bool WriteErrors = false;
            string OutputAsString = "";
            bool WriteRowToOutput = true;

            if (_MappingMode == MappingMode.Euro_Judo || _MappingMode == MappingMode.EuroJudo_And_IJF)
            {
                #region EuroJudo

                // Build the columns and rows to save
                foreach (DataRow Row in _RevolutioniseSourceData.Rows)
                {
                    RowData = new List<string>();

                    for (int ColumnIndex = 0; ColumnIndex < 14; ColumnIndex++)
                    {
                        int SourceIndex = -1;

                        switch (ColumnIndex)
                        {
                            case 0: // Member number
                                SourceIndex = Properties.Settings.Default.PreviousMemberIDColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<string> Mapping = _MemberIDMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject);
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }

                                break;
                            case 1: // Club ID number
                                SourceIndex = Properties.Settings.Default.PreviousClubColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Club> Mapping = _ClubMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();


                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.ID.ToString());

                                        // We need to export clubs, so take note of the club now
                                        Club ThisClub = ((Club)Mapping.DestinationObject);

                                        Club ClubInList = null;

                                        if (ClubsForExport.Count > 0)
                                        {
                                            if (ThisClub.Location.SubDivision != null)
                                            {
                                                ClubInList = ClubsForExport.Where(c => c.Name == ThisClub.Name &&
                                                                                  c.Location.SubDivision != null &&
                                                                                  c.Location.SubDivision.Name == ThisClub.Location.SubDivision.Name
                                                                                 ).FirstOrDefault();
                                            }
                                            else
                                            {
                                                ClubInList = ClubsForExport.Where(c => c.Name == ThisClub.Name &&
                                                                                       c.Location.Country.Name == ThisClub.Location.Country.Name
                                                                                 ).FirstOrDefault();
                                            }
                                        }

                                        if (ClubInList == null)
                                        {
                                            ClubsForExport.Add(Mapping.DestinationObject);

                                            // We also need to keep a list of 'Regions'.  Do this now
                                            Location ThisLocation = ThisClub.Location;
                                            string CountryCode = ThisLocation.Country.ISO3Code;
                                            string SubDivisionCode = "";

                                            // Is this country in the list?
                                            Location LocationFromList = LocationsForExport.Where(l => l.Country.ISO3Code == CountryCode).FirstOrDefault();

                                            if (LocationFromList == null) // We didn't find the country
                                            {
                                                LocationsForExport.Add(ThisLocation); // Save this location for later.  It includes the Country and SubDivision
                                            }
                                            else if (ThisLocation.SubDivision != null) // Found the country, now to find out about the SubDivision
                                            {
                                                // Does our location have a subdivision?
                                                SubDivisionCode = ThisLocation.SubDivision.Code;

                                                Location LocationFromListAgain = LocationsForExport.Where(l => l.Country.ISO3Code == CountryCode &&
                                                                                                               l.SubDivision.Code == SubDivisionCode
                                                                                                         ).FirstOrDefault();

                                                if (LocationFromListAgain != null) // Found it - nothing more to do
                                                {
                                                }
                                                else // We didn't find this Country and SubDivision
                                                {
                                                    LocationsForExport.Add(ThisLocation);
                                                }

                                            }
                                            else
                                            {
                                                // The country is already in the list, and there is no SubDivision
                                            }
                                        }
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }

                                }
                                break;
                            case 2: // Club name
                                SourceIndex = Properties.Settings.Default.PreviousClubColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Club> Mapping = _ClubMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.Name.ToString());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }

                                break;
                            case 3: // Club Short
                                SourceIndex = Properties.Settings.Default.PreviousClubColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Club> Mapping = _ClubMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.Code.ToString());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 4: // First name
                                SourceIndex = Properties.Settings.Default.PreviousFirstNameColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<string> Mapping = _FirstNameMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.ToString());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 5: // Suffix
                                RowData.Add("");
                                break;
                            case 6: // Last name
                                SourceIndex = Properties.Settings.Default.PreviousSurnameColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<string> Mapping = _LastNameMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.ToString());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 7: // Genus
                                SourceIndex = Properties.Settings.Default.PreviousGenderColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Judo.Gender> Mapping = _GenderMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null)
                                    {
                                        string ThisGender = Mapping.DestinationObject.ToString();

                                        switch (Mapping.DestinationObject)
                                        {
                                            case Judo.Gender.Male:
                                                RowData.Add(EuroJudo.Gender.M.ToString());
                                                break;
                                            case Judo.Gender.Female:
                                                RowData.Add(EuroJudo.Gender.F.ToString());
                                                break;
                                            default:
                                                RowData.Add("");
                                                break;
                                        }

                                        //if (ThisGender != "Unknown")
                                        //{
                                        //    RowData.Add(ThisGender);
                                        //}
                                        //else
                                        //{
                                        //    RowData.Add("");
                                        //}
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 8: // Day and month of Birth
                                {
                                    SourceIndex = Properties.Settings.Default.PreviousDateOfBirthColumnIndex;

                                    StringToObjectMapping<DateTime> DateMapping = null;

                                    string TheDay = "";
                                    string TheMonth = "";

                                    if (SourceIndex > -1)
                                    {
                                        OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                        DateMapping = _DateOfBirthMappings.Where(y => y.SourceValue == OriginalCellData).FirstOrDefault();

                                        if (DateMapping != null)
                                        {
                                            if (DateMapping.DestinationObject == DateTime.MinValue)
                                            {
                                                TheDay = "";
                                                TheMonth = "";
                                            }
                                            else
                                            {
                                                TheDay = DateMapping.DestinationObject.Day.ToString().PadLeft(2, '0');
                                                TheMonth = DateMapping.DestinationObject.Month.ToString().PadLeft(2, '0');
                                            }
                                        }
                                        else
                                        {
                                            TheDay = "";
                                            TheMonth = "";
                                        }
                                    }

                                    if (TheDay != "" && TheMonth != "" && TheDay != "00" && TheMonth != "00")
                                    {
                                        RowData.Add(TheDay + "/" + TheMonth);
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }

                                    ////////////////////////////////////////////////////////////////////////////////////////////////////////
                                    //SourceIndex = Properties.Settings.Default.LastEuroJudoDayOfBirthColumnIndex;

                                    //StringToObjectMapping<int> DayMapping = null;
                                    //StringToObjectMapping<int> MonthMapping = null;
                                    //string TheDay = "";
                                    //string TheMonth = "";

                                    //if (SourceIndex > -1)
                                    //{
                                    //    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    //    DayMapping = DayOfBirthMappings.Where(y => y.SourceValue == OriginalCellData).FirstOrDefault();

                                    //    if (DayMapping != null)
                                    //    {
                                    //        TheDay = DayMapping.DestinationObject.ToString().PadLeft(2, '0');
                                    //    }
                                    //    else
                                    //    {
                                    //        TheDay = "";
                                    //    }
                                    //}

                                    //SourceIndex = Properties.Settings.Default.LastEuroJudoMonthOfBirthColumnIndex;

                                    //if (SourceIndex > -1)
                                    //{
                                    //    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    //    MonthMapping = MonthOfBirthMappings.Where(y => y.SourceValue == OriginalCellData).FirstOrDefault();

                                    //    if (MonthMapping != null)
                                    //    {
                                    //        TheMonth = MonthMapping.DestinationObject.ToString().PadLeft(2, '0');
                                    //    }
                                    //    else
                                    //    {
                                    //        TheMonth = "";
                                    //    }
                                    //}

                                    //if (TheDay != "" && TheMonth != "" && TheDay != "00" && TheMonth != "00")
                                    //{
                                    //    RowData.Add(TheDay + "/" + TheMonth);
                                    //}
                                    //else
                                    //{
                                    //    RowData.Add("");
                                    //}

                                    break;
                                }
                            case 9: // Year of Birth
                                {
                                    SourceIndex = Properties.Settings.Default.PreviousDateOfBirthColumnIndex;

                                    StringToObjectMapping<DateTime> YearMapping = null;

                                    string TheYear = "";

                                    if (SourceIndex > -1)
                                    {
                                        OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                        YearMapping = _DateOfBirthMappings.Where(y => y.SourceValue == OriginalCellData).FirstOrDefault();

                                        if (YearMapping != null)
                                        {
                                            if (YearMapping.DestinationObject == DateTime.MinValue)
                                            {
                                                TheYear = "";
                                            }
                                            else
                                            {
                                                TheYear = YearMapping.DestinationObject.Year.ToString();
                                            }
                                        }
                                        else
                                        {
                                            TheYear = "";
                                        }
                                    }

                                    if (TheYear != "" && TheYear != "0")
                                    {
                                        RowData.Add(TheYear);
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }

                                    /////////////////////////////////////////////////////////////////////////////
                                    ///SourceIndex = Properties.Settings.Default.LastEuroJudoYearOfBirthColumnIndex;

                                    //if (SourceIndex > -1)
                                    //{
                                    //    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    //    StringToObjectMapping<int> Mapping = YearOfBirthMappings.Where(y => y.SourceValue == OriginalCellData).FirstOrDefault();
                                    //    string TheYear = "";

                                    //    if (Mapping != null)
                                    //    {
                                    //        TheYear = Mapping.DestinationObject.ToString();

                                    //        if (TheYear != "" && TheYear != "0")
                                    //        {
                                    //            RowData.Add(Mapping.DestinationObject.ToString());
                                    //        }
                                    //        else
                                    //        {
                                    //            RowData.Add("");
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        RowData.Add("");
                                    //    }
                                    //}
                                    break;
                                }
                            case 10: // Function
                                SourceIndex = Properties.Settings.Default.PreviousEuroJudoFunctionColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Function> Mapping = _EuroJudoFunctionMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject.ToString() != "Unknown")
                                    {
                                        RowData.Add(Mapping.DestinationObject.ToString());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 11: // Event number
                                SourceIndex = Properties.Settings.Default.PreviousEuroJudoEventTypeColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Event> Mapping = _EventMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.Number.ToString());
                                        Debug.Print($"Event Number Mapping: '{Mapping.DestinationObject.ToString()}' = '{Mapping.DestinationObject.Number.ToString()}'");
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 12: // Weight category
                                SourceIndex = Properties.Settings.Default.PreviousEuroJudoWeightCategoryColumnIndex;

                                if (SourceIndex > 0)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<EuroJudo.WeightCategory> Mapping = _EuroJudoWeightCategoryMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null && Mapping.DestinationObject.Event != null)
                                    {
                                        string WeightCategoryName = "";

                                        if (((EuroJudo.WeightCategory)Mapping.DestinationObject).Maximum < 255)
                                        {
                                            WeightCategoryName = "-" + ((EuroJudo.WeightCategory)Mapping.DestinationObject).Maximum.ToString();
                                        }
                                        else
                                        {
                                            WeightCategoryName = "+" + ((EuroJudo.WeightCategory)Mapping.DestinationObject).Minimum.ToString();
                                        }

                                        RowData.Add(WeightCategoryName);
                                        //RowData.Add(Mapping.DestinationObject.ClassNumber.ToString());
                                        Debug.Print($"Weight Category Mapping: '{Mapping.DestinationObject.ToString()}' = '{Mapping.DestinationObject.ClassNumber.ToString()}'");
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                        }

                    }

                    EuroJudoOutput.Add(RowData);
                }

                // Save file
                string EuroJudoFilename = Properties.Settings.Default.EuroJudoExportFilename;
                int RegionRowNumber = 2;
                int ClubRowNumber = 2;

                try
                {
                    using (FileStream fs = new FileStream(EuroJudoFilename, FileMode.Create, FileAccess.ReadWrite))
                    {

                        IWorkbook workbook = new HSSFWorkbook();

                        ISheet sheet1 = workbook.CreateSheet("Regions");
                        ISheet sheet2 = workbook.CreateSheet("Clubs");
                        ISheet sheet3 = workbook.CreateSheet("Members");
                        ISheet sheet4 = workbook.CreateSheet("Kyu & Dan");

                        sheet1.SetZoom(85, 100); // 85%
                        sheet2.SetZoom(85, 100); // 85%
                        sheet3.SetZoom(85, 100); // 85%
                        sheet4.SetZoom(85, 100); // 85%

                        #region Build a font for the special characters

                        IFont MonotypeSorts = workbook.CreateFont(); // MonotypeSorts
                        MonotypeSorts.Color = HSSFColor.COLOR_NORMAL;
                        MonotypeSorts.IsItalic = false;
                        MonotypeSorts.Underline = FontUnderlineType.None;
                        MonotypeSorts.FontHeightInPoints = 10;
                        MonotypeSorts.FontName = "Monotype Sorts";

                        //bind font with style 1
                        ICellStyle MonotypeSortsStyle = workbook.CreateCellStyle();
                        MonotypeSortsStyle.SetFont(MonotypeSorts);

                        #endregion

                        #region Regions Worksheet

                        sheet1.SetCellValue(1, 0, "Abbreviation");
                        sheet1.SetCellValue(1, 1, "C-4");
                        sheet1.SetCellValue(2, 0, "Country");
                        sheet1.SetCellValue(2, 1, "C-3");
                        sheet1.SetCellValue(3, 0, "Region");
                        sheet1.SetCellValue(3, 1, "C-30");

                        RegionRowNumber = 2;
                        // Now save all the clubs
                        foreach (Location loc in LocationsForExport)
                        {
                            try
                            {
                                sheet1.SetCellValue(1, RegionRowNumber, loc.Country.ISO3Code);
                                sheet1.SetCellValue(2, RegionRowNumber, loc.Country.ISO3Code);

                                if (loc.SubDivision != null)
                                {
                                    sheet1.SetCellValue(3, RegionRowNumber, loc.SubDivision.Code);
                                }
                                else
                                {
                                    sheet1.SetCellValue(3, RegionRowNumber, loc.Country.ISO3Code);
                                }
                            }
                            catch
                            {
                            }
                            RegionRowNumber++;
                        }

                        #endregion

                        #region Clubs Worksheet

                        sheet2.SetCellValue(1, 0, "Club IdNr");
                        sheet2.SetCellValue(1, 1, "N-9");
                        sheet2.SetCellValue(2, 0, "Country Code");
                        sheet2.SetCellValue(2, 1, "C-3");
                        sheet2.SetCellValue(3, 0, "Region Id");
                        sheet2.SetCellValue(3, 1, "C-4");

                        sheet2.SetCellValue(4, 0, "Prefix");
                        sheet2.SetCellValue(4, 1, "C-35");
                        sheet2.SetCellValue(5, 0, "Clubname");
                        sheet2.SetCellValue(5, 1, "C-35");
                        sheet2.SetCellValue(6, 0, "Short");
                        sheet2.SetCellValue(6, 1, "C-4");

                        sheet2.SetCellValue(7, 0, "Person in Charge");
                        sheet2.SetCellValue(7, 1, "C-30");
                        sheet2.SetCellValue(8, 0, "Address");
                        sheet2.SetCellValue(8, 1, "C-35");
                        sheet2.SetCellValue(9, 0, "Zip code");
                        sheet2.SetCellValue(9, 1, "C-15");

                        sheet2.SetCellValue(10, 0, "City");
                        sheet2.SetCellValue(10, 1, "C-30");
                        sheet2.SetCellValue(11, 0, "Phone 1");
                        sheet2.SetCellValue(11, 1, "C-20");
                        sheet2.SetCellValue(12, 0, "Phone 2");
                        sheet2.SetCellValue(12, 1, "C-20");

                        sheet2.SetCellValue(13, 0, "Mobile");
                        sheet2.SetCellValue(13, 1, "C-20");
                        sheet2.SetCellValue(14, 0, "Fax");
                        sheet2.SetCellValue(14, 1, "C-20");
                        sheet2.SetCellValue(15, 0, "e-mail address");
                        sheet2.SetCellValue(15, 1, "C-35");

                        ClubRowNumber = 2;
                        // Now save all the clubs
                        foreach (Club c in ClubsForExport)
                        {
                            try
                            {
                                sheet2.SetCellValue(1, ClubRowNumber, c.ID.ToString());

                                if (c.Location != null)
                                {
                                    if (c.Location.Country != null && c.Location.Country.ISO3Code != null)
                                    {
                                        sheet2.SetCellValue(2, ClubRowNumber, c.Location.Country.ISO3Code);
                                    }

                                    if (c.Location.SubDivision != null && c.Location.SubDivision.Code != null)
                                    {
                                        sheet2.SetCellValue(3, ClubRowNumber, c.Location.SubDivision.Code);
                                    }
                                    else
                                    {
                                        sheet2.SetCellValue(3, ClubRowNumber, c.Location.Country.ISO3Code);
                                    }
                                }
                                //                  4
                                sheet2.SetCellValue(5, ClubRowNumber, c.Name);
                                sheet2.SetCellValue(6, ClubRowNumber, c.Code);
                                //                  7
                                //                  8
                                //                  9
                                //                 10
                                //                 11
                                //                 12
                                //                 13
                                //                 14
                                //                 15
                            }
                            catch
                            {
                            }
                            ClubRowNumber++;
                        }

                        #endregion

                        #region Members Worksheet

                        for (int Column = 2; Column < 19; Column++)
                        {
                            sheet3.SetCellValue(Column, 0, Column + 1);
                        }

                        sheet3.SetCellValue(11, 0, "Competitor");
                        sheet3.SetCellValue(11, 1, "Referee");
                        sheet3.SetCellValue(11, 2, "Coach");
                        sheet3.SetCellValue(11, 3, "Team-Official");
                        sheet3.SetCellValue(11, 4, "Medic");
                        sheet3.SetCellValue(11, 5, "Press");
                        sheet3.SetCellValue(11, 6, "EJU/VIP");
                        sheet3.SetCellValue(11, 7, "Organizer");

                        for (int i = 0; i < 16; i++)
                        {
                            if (i < 6)
                            {
                                sheet3.SetCellValue(18, i, (6 - i).Ordinal() + " kyu");
                            }
                            else
                            {
                                sheet3.SetCellValue(18, i, (i - 5).Ordinal() + " dan");
                            }
                        }

                        sheet3.SetCellValue(1, 16, "Member nr");
                        sheet3.SetCellValue(2, 16, "Club IdNr");
                        sheet3.SetCellValue(3, 16, "Clubname");
                        sheet3.SetCellValue(4, 16, "Club Short");
                        sheet3.SetCellValue(5, 16, "First Name");
                        sheet3.SetCellValue(6, 16, "Suffix");
                        sheet3.SetCellValue(7, 16, "Last Name");
                        sheet3.SetCellValue(8, 16, "Genus");
                        sheet3.SetCellValue(9, 16, "Date of Birth");
                        sheet3.SetCellValue(10, 16, "Year of Birth");
                        sheet3.SetCellValue(11, 16, "Function");
                        sheet3.SetCellValue(12, 16, "Event Nr");
                        sheet3.SetCellValue(13, 16, "Weight cat.");
                        sheet3.SetCellValue(14, 16, "Weight");
                        sheet3.SetCellValue(15, 16, "Citizenship");
                        sheet3.SetCellValue(16, 16, "Seeding");
                        sheet3.SetCellValue(17, 16, "DrawNr");
                        sheet3.SetCellValue(18, 16, "Kyu");

                        sheet3.SetCellValue(1, 17, "C-50");
                        sheet3.SetCellValue(2, 17, "N-9");
                        sheet3.SetCellValue(3, 17, "C-35");
                        sheet3.SetCellValue(4, 17, "C-4");
                        sheet3.SetCellValue(5, 17, "C-25");
                        sheet3.SetCellValue(6, 17, "C-15");
                        sheet3.SetCellValue(7, 17, "C-25");
                        sheet3.SetCellValue(8, 17, "M/F");
                        sheet3.SetCellValue(9, 17, "dd-mm");
                        sheet3.SetCellValue(10, 17, "yyyy");
                        sheet3.SetCellValue(11, 17, "C-20");
                        sheet3.SetCellValue(12, 17, "N-2");
                        sheet3.SetCellValue(13, 17, "C-7");
                        sheet3.SetCellValue(14, 17, "N3.1");
                        sheet3.SetCellValue(15, 17, "C-3");
                        sheet3.SetCellValue(16, 17, "C-2");
                        sheet3.SetCellValue(17, 17, "N-3");
                        sheet3.SetCellValue(18, 17, "C-35");

                        int RowIndex = 18;
                        foreach (List<string> Row in EuroJudoOutput)
                        {
                            if (Row.Count > 0 && Row[0] != null)
                                sheet3.SetCellValue(1, RowIndex, Row[0]);
                            else
                                sheet3.SetCellValue(1, RowIndex, "");
                            if (Row.Count > 1 && Row[1] != null)
                                sheet3.SetCellValue(2, RowIndex, Row[1]);
                            else
                                sheet3.SetCellValue(2, RowIndex, "");
                            if (Row.Count > 2 && Row[2] != null)
                                sheet3.SetCellValue(3, RowIndex, Row[2]);
                            else
                                sheet3.SetCellValue(3, RowIndex, "");
                            if (Row.Count > 3 && Row[3] != null)
                                sheet3.SetCellValue(4, RowIndex, Row[3]);
                            else
                                sheet3.SetCellValue(4, RowIndex, "");
                            if (Row.Count > 4 && Row[4] != null)
                                sheet3.SetCellValue(5, RowIndex, Row[4]);
                            else
                                sheet3.SetCellValue(5, RowIndex, "");
                            if (Row.Count > 5 && Row[5] != null)
                                sheet3.SetCellValue(6, RowIndex, Row[5]);
                            else
                                sheet3.SetCellValue(6, RowIndex, "");
                            if (Row.Count > 6 && Row[6] != null)
                                sheet3.SetCellValue(7, RowIndex, Row[6]);
                            else
                                sheet3.SetCellValue(7, RowIndex, "");
                            if (Row.Count > 7 && Row[7] != null)
                                sheet3.SetCellValue(8, RowIndex, Row[7]);
                            else
                                sheet3.SetCellValue(8, RowIndex, "");
                            if (Row.Count > 8 && Row[8] != null)
                                sheet3.SetCellValue(9, RowIndex, Row[8]);
                            else
                                sheet3.SetCellValue(9, RowIndex, "");
                            if (Row.Count > 9 && Row[9] != null)
                                sheet3.SetCellValue(10, RowIndex, Row[9]);
                            else
                                sheet3.SetCellValue(10, RowIndex, "");
                            if (Row.Count > 10 && Row[10] != null)
                                sheet3.SetCellValue(11, RowIndex, Row[10]);
                            else
                                sheet3.SetCellValue(11, RowIndex, "");
                            if (Row.Count > 11 && Row[11] != null)
                                sheet3.SetCellValue(12, RowIndex, Row[11]);
                            else
                                sheet3.SetCellValue(12, RowIndex, "");
                            if (Row.Count > 12 && Row[12] != null)
                                sheet3.SetCellValue(13, RowIndex, Row[12]);
                            else
                                sheet3.SetCellValue(13, RowIndex, "");


                            RowIndex++;
                        }

                        #endregion

                        #region Kyu & Dan Worksheet

                        sheet4.SetCellValue(0, 0, "Kyu or Dan");
                        sheet4.SetCellValue(1, 0, "Reference");
                        sheet4.SetCellValue(0, 1, "C-4");
                        sheet4.SetCellValue(1, 1, "");


                        for (int i = 2; i < 18; i++)
                        {
                            if (i < 8)
                            {
                                sheet4.SetCellValue(0, i, (8 - i).Ordinal() + " kyu");
                            }
                            else
                            {
                                sheet4.SetCellValue(0, i, (i - 7).Ordinal() + " dan");
                            }

                            sheet4.SetCellValue(1, i, (i - 1));

                        }

                        #endregion

                        workbook.Write(fs);

                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    UpdateStatus($"Error: {e.Message}");
                    WriteErrors = true;
                }
                catch (Exception e)
                {
                    UpdateStatus($"Error: {e.Message}");
                    WriteErrors = true;
                }

                #endregion
            }

            if (_MappingMode == MappingMode.IJF || _MappingMode == MappingMode.EuroJudo_And_IJF)
            {
                #region IJF

                // Build the columns and rows to save
                foreach (DataRow Row in _RevolutioniseSourceData.Rows)
                {
                    RowData = new List<string>();

                    WriteRowToOutput = true;

                    for (int ColumnIndex = 0; ColumnIndex < 12; ColumnIndex++)
                    {
                        int SourceIndex = -1;

                        switch (ColumnIndex)
                        {
                            case 0: // Index
                                RowData.Add("[COUNTER]"); // Counter.ToString());
                                break;
                            case 1: // Tournament ID
                                RowData.Add(_SelectedIJFTournament.ID);
                                break;
                            case 2: // Member number
                                SourceIndex = Properties.Settings.Default.PreviousMemberIDColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<string> Mapping = _MemberIDMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject);
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }

                                break;
                            case 3: // Last name
                                SourceIndex = Properties.Settings.Default.PreviousSurnameColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<string> Mapping = _LastNameMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.ToString().ToUpper());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 4: // First name
                                SourceIndex = Properties.Settings.Default.PreviousFirstNameColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<string> Mapping = _FirstNameMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.ToString());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 5: // Country
                                SourceIndex = Properties.Settings.Default.PreviousClubColumnIndex; // Because club has country

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Club> Mapping = _ClubMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        if (Mapping.DestinationObject.Location != null && Mapping.DestinationObject.Location.Country != null)
                                        {
                                            RowData.Add(Mapping.DestinationObject.Location.Country.ISO3Code);
                                        }
                                        else
                                        {
                                            RowData.Add(Properties.Settings.Default.GeneralClubDefaultCountryCode);
                                        }
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }

                                break;
                            case 6: // Sub Division
                                SourceIndex = Properties.Settings.Default.PreviousClubColumnIndex; // Because club has country

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Club> Mapping = _ClubMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        if (Mapping.DestinationObject.Location != null && Mapping.DestinationObject.Location.SubDivision != null)
                                        {
                                            RowData.Add(Mapping.DestinationObject.Location.SubDivision.Code);
                                        }
                                        else
                                        {
                                            RowData.Add(Properties.Settings.Default.GeneralClubDefaultCountryCode);
                                        }
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }

                                break;
                            case 7: // Club name
                                SourceIndex = Properties.Settings.Default.PreviousClubColumnIndex;

                                if (_ClubMappings.Count > 0)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Club> Mapping = _ClubMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.Name.ToString());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }

                                break;
                            case 8: // Date of Birth
                                {
                                    SourceIndex = Properties.Settings.Default.PreviousDateOfBirthColumnIndex;

                                    StringToObjectMapping<DateTime> DateMapping = null;

                                    string TheDay = "";
                                    string TheMonth = "";
                                    string TheYear = "";

                                    if (SourceIndex > -1)
                                    {
                                        OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                        DateMapping = _DateOfBirthMappings.Where(y => y.SourceValue == OriginalCellData).FirstOrDefault();

                                        if (DateMapping != null)
                                        {
                                            if (DateMapping.DestinationObject == DateTime.MinValue)
                                            {
                                                TheDay = "";
                                                TheMonth = "";
                                                TheYear = "";
                                            }
                                            else
                                            {
                                                TheDay = DateMapping.DestinationObject.Day.ToString().PadLeft(2, '0');
                                                TheMonth = DateMapping.DestinationObject.Month.ToString().PadLeft(2, '0');
                                                TheYear = DateMapping.DestinationObject.Year.ToString();
                                            }
                                        }
                                        else
                                        {
                                            TheDay = "";
                                            TheMonth = "";
                                            TheYear = "";
                                        }
                                    }

                                    if (TheDay != "" && TheMonth != "" && TheDay != "00" && TheMonth != "00" && TheYear != "00" && TheYear != "00")
                                    {
                                        RowData.Add(TheDay + "/" + TheMonth + "/" + TheYear);
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }

                                    break;
                                }
                            case 9: // Function
                                SourceIndex = Properties.Settings.Default.PreviousIJFFunctionColumnIndex;

                                if (_IJFFunctionMappings.Count > 0)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<IJF.Function> Mapping = _IJFFunctionMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null)
                                    {
                                        RowData.Add(Mapping.DestinationObject.ToString());
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }

                                    // Check if we will write this out - If the Function is Unknown, don't write it out
                                    if (Mapping.DestinationObject.ToString() == "Unknown")
                                    {
                                        WriteRowToOutput = false;
                                    }
                                }
                                break;
                            case 10: // Sex
                                SourceIndex = Properties.Settings.Default.PreviousGenderColumnIndex;

                                if (SourceIndex > -1)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Judo.Gender> Mapping = _GenderMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null)
                                    {
                                        string ThisGender = Mapping.DestinationObject.ToString();

                                        switch (Mapping.DestinationObject)
                                        {
                                            case Judo.Gender.Male:
                                                RowData.Add(IJF.Gender.m.ToString());
                                                break;
                                            case Judo.Gender.Female:
                                                RowData.Add(IJF.Gender.w.ToString());
                                                break;
                                            default:
                                                RowData.Add("");
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                            case 11: // Weight category
                                SourceIndex = Properties.Settings.Default.PreviousIJFWeightCategoryColumnIndex;

                                if (SourceIndex > 0)
                                {
                                    OriginalCellData = (string)Row.ItemArray[SourceIndex];
                                    StringToObjectMapping<Judo.WeightCategory> Mapping = _IJFWeightCategoryMappings.Where(m => m.SourceValue == OriginalCellData).FirstOrDefault();

                                    if (Mapping != null && Mapping.DestinationObject != null)
                                    {
                                        string WeightCategoryName = "";

                                        if (((Judo.WeightCategory)Mapping.DestinationObject).Maximum < 255)
                                        {
                                            WeightCategoryName = "-" + ((Judo.WeightCategory)Mapping.DestinationObject).Maximum.ToString();
                                        }
                                        else
                                        {
                                            WeightCategoryName = "+" + ((Judo.WeightCategory)Mapping.DestinationObject).Minimum.ToString();
                                        }

                                        RowData.Add(WeightCategoryName + " kg");
                                        //RowData.Add(Mapping.DestinationObject.ClassNumber.ToString());
                                        Debug.Print($"Weight Category Mapping: '{Mapping.DestinationObject.ToString()}' = '{Mapping.DestinationObject.Name.ToString()}'");
                                    }
                                    else
                                    {
                                        RowData.Add("");
                                    }
                                }
                                break;
                                // The following columns also exist:
                                //   12: [Blank]
                                //   13: Draw 
                                //   14: Place
                                //   15: Old Place
                                //   16: WRL
                                //   17: Ranked
                                //   18: Draw placing
                        }

                    }

                    StringBuilder OutputRow = new StringBuilder();
                    foreach (string Value in RowData)
                    {
                        // OutputRow.Append('"' + Value + '"' + "\t"); // Place double-quotes around each value
                        OutputRow.Append(Value + "\t");
                    }

                    OutputAsString = OutputRow.ToString().Substring(0, OutputRow.Length - 1);

                    if (!IJFOutput.Any(x => x == OutputAsString) && WriteRowToOutput)
                    {
                        // Doesn't already exist in the list - add it to the output
                        IJFOutput.Add(OutputAsString);
                    }
                    else
                    {
                        // Exists
                        Debug.Print(OutputAsString + " is already in the output list, or 'Function' is Unknown");
                    }
                }

                // Save file
                string IJFFolder = Properties.Settings.Default.IJFExportFolder;
                string IJFFilename = Path.Combine(IJFFolder, _SelectedIJFTournament.ID, _SelectedIJFTournament.ID + "_names.txt");

                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(IJFFilename));

                try
                {
                    using (StreamWriter writer = File.CreateText(IJFFilename))
                    {
                        foreach (string Row in IJFOutput)
                        {
                            Counter++;
                            string Output = Row.Replace("[COUNTER]", Counter.ToString());
                            writer.WriteLine(Output);
                        }
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    UpdateStatus($"Error: {e.Message}");
                    WriteErrors = true;
                }
                catch (Exception e)
                {
                    UpdateStatus($"Error: {e.Message}");
                    WriteErrors = true;
                }


                #endregion

            }

            if (WriteErrors)
            {
                UpdateStatus($"Export complete with one or more errors");
            }
            else
            {
                UpdateStatus($"Export complete");
            }
        }

        private void DoPhotos()
        {
            if (_IJFPhotoMappings.Count > 0)
            {
                DialogResult Result = MessageBox.Show("You have photo mappings defined.  Do you want to download these now?",
                                                      "Download",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question,
                                                      MessageBoxDefaultButton.Button1);

                if (Result == DialogResult.Yes)
                {
                    if (Properties.Settings.Default.IJFUserPhotoSaveFolder.Trim().Length > 0)
                    {
                        // Ready to download
                    }
                    else // Can't download yet - there is no IJF Photo Save folder defined
                    {
                        Properties.Settings.Default.IJFUserPhotoSaveFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Ippon.Org");
                        Properties.Settings.Default.Save();

                        MessageBox.Show($"There is no IJF Photo folder defined.  Defaulting to {Properties.Settings.Default.IJFUserPhotoSaveFolder}");
                    }

                    UpdateStatus($"Photo download started..");

                    // Start the download process
                    string OriginalPhotoCellData = "";
                    string OriginalMemberIDCellData = "";
                    string OriginalFirstNameCellData = "";
                    string OriginalSurnameCellData = "";
                    string OriginalClubCellData = "";

                    int PhotoIDIndex = Properties.Settings.Default.PreviousIJFPhotoColumnIndex;
                    int MemberIDIndex = Properties.Settings.Default.PreviousMemberIDColumnIndex;
                    int FirstNameIndex = Properties.Settings.Default.PreviousFirstNameColumnIndex;
                    int SurnameIndex = Properties.Settings.Default.PreviousSurnameColumnIndex;
                    int ClubNameIndex = Properties.Settings.Default.PreviousClubColumnIndex;
                    int Counter = 0;
                    List<Exception> Exceptions = new List<Exception>();

                    if (PhotoIDIndex > -1 && MemberIDIndex > -1)
                    {
                        foreach (DataRow Row in _RevolutioniseSourceData.Rows)
                        {
                            Counter++;

                            UpdateStatus($"Photo {Counter} of {_RevolutioniseSourceData.Rows.Count}");

                            OriginalPhotoCellData = (string)Row.ItemArray[PhotoIDIndex];
                            StringToObjectMapping<string> PhotoMapping = _IJFPhotoMappings.Where(m => m.SourceValue == OriginalPhotoCellData).FirstOrDefault();

                            OriginalMemberIDCellData = (string)Row.ItemArray[MemberIDIndex];
                            StringToObjectMapping<string> MemberIDMapping = _MemberIDMappings.Where(m => m.SourceValue == OriginalMemberIDCellData).FirstOrDefault();

                            OriginalFirstNameCellData = (string)Row.ItemArray[FirstNameIndex];
                            StringToObjectMapping<string> FirstNameMapping = _FirstNameMappings.Where(m => m.SourceValue == OriginalFirstNameCellData).FirstOrDefault();

                            OriginalSurnameCellData = (string)Row.ItemArray[SurnameIndex];
                            StringToObjectMapping<string> SurnameMapping = _LastNameMappings.Where(m => m.SourceValue == OriginalSurnameCellData).FirstOrDefault();

                            OriginalClubCellData = (string)Row.ItemArray[ClubNameIndex];
                            StringToObjectMapping<Club> ClubMapping = _ClubMappings.Where(m => m.SourceValue == OriginalClubCellData).FirstOrDefault();

                            if (PhotoMapping != null && PhotoMapping.DestinationObject != null)
                            {
                                if (MemberIDMapping != null)
                                {
                                    string PhotoPath = PhotoMapping.DestinationObject;
                                    string MemberID = MemberIDMapping.DestinationObject;
                                    string FirstName = FirstNameMapping.DestinationObject;
                                    string Surname = SurnameMapping.DestinationObject;
                                    Club Club = null;
                                    string Country = Properties.Settings.Default.GeneralClubDefaultCountryCode;
                                    string MemberIDFilename = "";
                                    string CountrySubDivisionFilename = "";

                                    if (ClubMapping != null)
                                    {
                                        Club = ClubMapping.DestinationObject;
                                        Country = ClubMapping.DestinationObject.Location.Country.ISO3Code;
                                    }

                                    MemberIDFilename = $"{MemberID}.jpg".ToLower();
                                    CountrySubDivisionFilename = $"{Country}_{Surname}_{FirstName}.jpg".ToLower();

                                    Uri PhotoURI = null;

                                    try
                                    {
                                        PhotoURI = new Uri(PhotoPath);
                                    }
                                    catch (Exception e)
                                    {
                                        Exceptions.Add(e);
                                    }

                                    string UserSaveFilename = "";

                                    if (Properties.Settings.Default.IJFPhotoFilenameIsMemberID)
                                    {
                                        UserSaveFilename = System.IO.Path.Combine(Properties.Settings.Default.IJFUserPhotoSaveFolder, MemberIDFilename);
                                    }
                                    else
                                    {
                                        UserSaveFilename = System.IO.Path.Combine(Properties.Settings.Default.IJFUserPhotoSaveFolder, CountrySubDivisionFilename);
                                    }

                                    try
                                    {
                                        PhotoURI.SaveAsJPG(UserSaveFilename);

                                        if (File.Exists(UserSaveFilename))
                                        {
                                            string SystemSaveFolder = Properties.Settings.Default.IJFSystemPhotoSaveFolder;
                                            File.Copy(UserSaveFilename, System.IO.Path.Combine(SystemSaveFolder, MemberIDFilename));
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Exceptions.Add(e);
                                    }


                                }
                                else // No Member ID for this person
                                {

                                }
                            }
                            else
                            {
                                // No photo for this person
                            }
                        }
                    }

                    UpdateStatus($"Photo download complete");

                    if (Exceptions.Count > 0)
                    {

                    }
                }
                else // No
                {
                    UpdateStatus($"Photo download canceled");
                }
            }
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
        //    UpdateStatus("Loading Events...";
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
        //    UpdateStatus("Loading Weight categories...";
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
        //    UpdateStatus("Loading Clubs...";
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

        //private void AddEventMapping(bool RemoveSourceValue, string SourceValue, int SourceIndex, EuroJudoEvent SelectedEvent, Color Colour)
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

        //private void AddWeightMapping(bool RemoveSourceValue, string SourceValue, int SourceIndex, EuroJudoWeightCategory SelectedWeight, Color Colour)
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

        //private void AddClubMapping(bool RemoveSourceValue, string SourceValue, int SourceIndex, EuroJudoClub SelectedClub, Color Colour)
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
        //            AddEventLikeResults(ColumnValue: ColumnValue, ColumnIndex: ColumnIndex, Results: ValueResults, MinimumComparisonResult: Properties.Settings.Default.EuroJudoEventValueMinimumComparison);
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
        //                AddWeightMapping(RemoveSourceValue: true, SourceValue: ColumnValue, SourceIndex: ValueIndex, ThisCategory, Colour);
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
        //                AddClubMapping(RemoveSourceValue: true, SourceValue: ColumnValue, SourceIndex: ValueIndex, ThisClub, Colour);
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

        //        AddEventMapping(RemoveSourceValue: true, SourceValue: ColumnValue, ValueIndex, ThisEvent, lvwEventMappings.BackColor);
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

        //        AddWeightMapping(RemoveSourceValue: true, SourceValue: ColumnValue, ValueIndex, ThisWeight, lvwWeightMappings.BackColor);
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

        //        AddClubMapping(RemoveSourceValue: true, SourceValue: ColumnValue, ValueIndex, ThisClub, lvwClubMappings.BackColor);
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
