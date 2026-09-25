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
using EuroJudo;
//using Judo;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOIHelper;
using Utilities;
using static Utilities.Extensions;

namespace MappingTool
{
    public partial class frmMain : Form
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
        private DataTable ClubSourceData = new DataTable();
        private DataTable RevolutioniseSourceData = new DataTable();

        private List<Judo.Country> Countries = new List<Judo.Country>();
        private List<Judo.SubDivision> SubDivisions = new List<Judo.SubDivision>();
        private List<Judo.Club> Clubs = new List<Judo.Club>();

        private List<Judo.Tournament> EuroJudoTournaments = new List<Judo.Tournament>();
        private List<Event> EuroJudoEvents = new List<Event>();
        private List<WeightCategory> WeightCategories = new List<WeightCategory>();
        private List<Judo.Belt> Belts = new List<Judo.Belt>();

        private bool InitialLoadComplete = false;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmMain()
        {
            InitializeComponent();
        }

        //~frmMain()
        //{
        //    //RevolutioniseSourceData.Dispose();
        //}

        #endregion

        #region Event Handlers

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            DoStartup();
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            DoLoad(filePaths[0]);
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #region Buttons

        private void btnMapColumns_Click(object sender, EventArgs e)
        {
            frmOutputType MappingType = new frmOutputType(RevolutioniseSourceData, Clubs, Belts, Countries, SubDivisions);
            MappingType.Show();
        }

        #endregion

        #region Menu

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
            DoLoad(Properties.Settings.Default.GeneralImportFilename);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void cleanImportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanImportFile();
        }

        private void beltsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBelts();
        }

        private void clubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowClubs();
        }

        private void countriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCountries();
        }

        private void subDivisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSubDivisions();
        }

        #endregion

        #region Tool-strip

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tsbLoad_Click(object sender, EventArgs e)
        {
            DoLoad(Properties.Settings.Default.GeneralImportFilename);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            DoOptions();
        }

        #endregion

        #endregion

        #region Private Methods

        private void DoStartup()
        {
            string CountriesFilename = Properties.Settings.Default.ReferenceCountriesFilename.Trim();
            string SubDivisionsFilename = Properties.Settings.Default.ReferenceSubDivisionsFilename.Trim();
            string ClubsFilename = Properties.Settings.Default.ReferenceClubsFilename.Trim();
            //string TournamentFilename = Properties.Settings.Default.EuroJudoDatabaseFilename.Trim();

            Countries = new List<Judo.Country>();
            SubDivisions = new List<Judo.SubDivision>();
            Clubs = new List<Judo.Club>();
            EuroJudoEvents = new List<Event>();
            WeightCategories = new List<WeightCategory>();

            if (Path.IsPathRooted(CountriesFilename))
            {
            }
            else
            {
                CountriesFilename = System.IO.Path.Combine(Application.StartupPath, CountriesFilename);
            }

            if (Path.IsPathRooted(SubDivisionsFilename))
            {
            }
            else
            {
                SubDivisionsFilename = System.IO.Path.Combine(Application.StartupPath, SubDivisionsFilename);
            }

            if (Path.IsPathRooted(ClubsFilename))
            {
            }
            else
            {
                ClubsFilename = System.IO.Path.Combine(Application.StartupPath, ClubsFilename);
            }

            //lvwDatabaseMappingResults.Items.Clear();

            InitialLoadComplete = false;

            if (CountriesFilename.Length > 0)
            {
                // This requires filepaths to be defined
                Countries = GetCountries(CountriesFilename);

                if (SubDivisionsFilename.Length > 0)
                {
                    // SubDivisions needs Countries to be loaded first
                    SubDivisions = GetSubDivisions(SubDivisionsFilename);

                    Belts = GetEuroJudoBelts();

                    if (ClubsFilename.Length > 0)
                    {
                        Clubs = GetClubs(ClubsFilename);

                    }
                    else
                    {
                        UpdateStatus("Clubs filename is blank", Color.Orange);
                    }
                }
                else
                {
                    UpdateStatus("Sub Divisions filename is blank", Color.Orange);
                }
            }
            else
            {
                UpdateStatus("Countries filename is blank", Color.Orange);
            }

            //** MOVED radEuroJudoSimpleTranslation.Checked = true;
            InitialLoadComplete = false;

            loadToolStripMenuItem.Enabled = InitialLoadComplete;

            UpdateStatus("=======================================", SystemColors.Window);
            UpdateStatus("Idle - load an import file", Color.GreenYellow);
        }

        private void DoOptions()
        {
            UpdateStatus("Loading options screen...", SystemColors.Window);

            frmOptions OptionsForm = new frmOptions();

            DialogResult Result = OptionsForm.ShowDialog();

            if (Result == DialogResult.OK)
            {
                //if (TournamentLoaded)
                //{
                //    MessageBox.Show("The application must now restart.\r\nThis behavior will change in a future version.");
                //    Application.Restart();
                //}
            }

            UpdateStatus("Idle", Color.GreenYellow);
        }

        private List<Judo.Country> GetCountries(string Filename)
        {
            bool Result = false;
            List<Judo.Country> ListResult = new List<Judo.Country>();
            string[] SplitCharacters = new string[] { "," };
            List<string> RowsToIgnore = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Loading Countries...", SystemColors.Window);

            DataTable DataResult = null;
            string TextResult = "";

            (TextResult, Result, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "Countries");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;

            if (Result)
            {
                UpdateStatus("  " + TextResult, Color.GreenYellow);
            }
            else
            {
                UpdateStatus("  " + TextResult, Color.Orange);
            }

            foreach (DataRow Row in DataResult.Rows)
            {
                pbrAuto.Value++;
                pbrAuto.Refresh();

                string Name = Row.ItemArray[0].ToString();
                string Alpha2 = Row.ItemArray[1].ToString();
                string Alpha3 = Row.ItemArray[2].ToString();
                Judo.Country NewCountry = new Judo.Country(Name, Alpha2, Alpha3);
                ListResult.Add(NewCountry);
            }

            pbrAuto.Value = 0;
            UpdateStatus($"  {ListResult.Count} Countries loaded", SystemColors.Window);
            Cursor.Current = Cursors.Default;

            return ListResult;
        }

        private List<Judo.SubDivision> GetSubDivisions(string Filename)
        {
            bool Result = false;
            List<Judo.SubDivision> ListResult = new List<Judo.SubDivision>();
            string[] SplitCharacters = new string[] { "," };
            List<string> RowsToIgnore = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Loading Sub Divisions...", SystemColors.Window);

            DataTable DataResult = null;
            string TextResult = "";

            (TextResult, Result, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "SubDivisions");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;

            if (Result)
            {
                UpdateStatus("  " + TextResult, Color.GreenYellow);
            }
            else
            {
                UpdateStatus("  " + TextResult, Color.Orange);
            }

            foreach (DataRow Row in DataResult.Rows)
            {
                pbrAuto.Value++;
                pbrAuto.Refresh();

                string CountryName = "";
                string Code = "";
                string Name = "";
                string Type = "";

                try
                {
                    CountryName = Row.ItemArray[0].ToString();
                    Code = Row.ItemArray[1].ToString();
                    Name = Row.ItemArray[2].ToString();
                    Type = Row.ItemArray[3].ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"There was an error: {e.Message}");
                }

                Judo.Country Country = Countries.Find(c => Code.StartsWith(c.ISO2Code));

                Judo.SubDivision NewSubDivision = new Judo.SubDivision(Name, Code, Country);
                ListResult.Add(NewSubDivision);
            }

            pbrAuto.Value = 0;
            UpdateStatus($"  {ListResult.Count} Sub Divisions loaded", SystemColors.Window);

            Cursor.Current = Cursors.Default;
            return ListResult;
        }

        private List<Judo.Club> GetClubs(string Filename)
        {
            bool Result = false;
            List<Judo.Club> ListResult = new List<Judo.Club>();
            string[] SplitCharacters = new string[] { "," };
            List<string> RowsToIgnore = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Loading Clubs...", SystemColors.Window);

            DataTable DataResult = null;
            string TextResult = "";

            (TextResult, Result, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "Clubs");

            pbrAuto.Minimum = 0;
            pbrAuto.Maximum = DataResult.Rows.Count;

            if (Result)
            {
                UpdateStatus("  " + TextResult, Color.GreenYellow);
            }
            else
            {
                UpdateStatus("  " + TextResult, Color.Orange);
            }

            foreach (DataRow Row in DataResult.Rows)
            {
                pbrAuto.Value++;
                pbrAuto.Refresh();

                int ID = Convert.ToInt32(Row.ItemArray[0].ToString());
                string Name = Row.ItemArray[1].ToString();
                string CountryCode = Row.ItemArray[2].ToString();
                string SubDivisionCode = Row.ItemArray[3].ToString();
                string Code = Row.ItemArray[4].ToString();

                Judo.Country Country = Countries.Find(c => c.ISO2Code == CountryCode);
                Judo.SubDivision SubDivision = SubDivisions.Find(s => s.Code == SubDivisionCode);
                Judo.Location Location = new Judo.Location(Country, SubDivision);

                Judo.Club NewClub = new Judo.Club(ID, Name, Code, Location);
                ListResult.Add(NewClub);
            }

            pbrAuto.Value = 0;
            UpdateStatus($"  {ListResult.Count} Clubs loaded", SystemColors.Window);

            Cursor.Current = Cursors.Default;

            return ListResult;
        }

        private List<Judo.Belt> GetEuroJudoBelts()
        {
            List<Judo.Belt> Result = new List<Judo.Belt>();
            string[] SplitCharacters = new string[] { "," };

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Loading Belts...", SystemColors.Window);

            for (int i = 0; i < 21; i++)
            {
                Result.Add(new Judo.Belt((Judo.Grade)i));
            }

            pbrAuto.Value = 0;
            UpdateStatus($"  {Result.Count} Belts loaded", SystemColors.Window);

            Cursor.Current = Cursors.Default;

            return Result;
        }

        private void ShowBelts()
        {
            throw new NotImplementedException();
        }

        private void ShowClubs()
        {
            throw new NotImplementedException();
        }

        private void ShowCountries()
        {
            throw new NotImplementedException();
        }

        private void ShowSubDivisions()
        {
            throw new NotImplementedException();
        }

        private void CleanImportFile()
        {
            throw new NotImplementedException();
        }

        private void DoLoad(string Filename)
        {
            bool Result = false;

            Result = GetImportData(Reload: false, Filename: Filename);

            btnMapColumns.Enabled = Result;

            UpdateStatus("Idle - start mapping columns", Color.GreenYellow);
        }

        private bool GetImportData(bool Reload, string Filename)
        {
            bool Result = false;
            DialogResult DiagResult = DialogResult.None;
            frmImport ImportForm = null;

            Cursor.Current = Cursors.WaitCursor;
            Debug.Print($"Inside {CurrentMethodName()}");

            if (Reload)
            {
                DiagResult = DialogResult.OK;
            }
            else
            {
                ImportForm = new frmImport(Filename);

                DiagResult = ImportForm.ShowDialog();
            }

            if (DiagResult == DialogResult.OK)
            {
                Properties.Settings.Default.GeneralImportFilename = ImportForm.ImportFilename;
                Result = LoadCSVDataSource(Properties.Settings.Default.GeneralImportFilename, ref RevolutioniseSourceData);

                #region Deprecated

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

                #endregion

                //AddSourceColumnNamesToComboBox(RevolutioniseSourceData, cmbColumnNamesFromImportData);

                //lstImportedColumnValues.Items.Clear();

                //if (cmbEuroJudoMappingType.Items.Count > 0)
                //{
                //    cmbEuroJudoMappingType.SelectedIndex = 0;
                //}

                //tabExportType.Enabled = true;

                //TournamentLoaded = true;

            }

            Cursor.Current = Cursors.Default;
            return Result;
        }

        private void AddSourceColumnNamesToComboBox(DataTable DataSource, ComboBox Combobox)
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            Combobox.Items.Clear();

            Debug.Print($"...Adding items to Combobox: {Combobox.Name} from {DataSource.TableName}");
            foreach (DataColumn column in DataSource.Columns)
            {
                Combobox.Items.Add(column.ColumnName);
            }
        }

        private bool LoadCSVDataSource(string Filename, ref DataTable TargetDataSource)
        {
            bool Result = false;
            string[] SplitCharacters = new string[] { Properties.Settings.Default.GeneralImportDelimiter };
            List<string> RowsToIgnore = new List<string>();
            string ResultText = "";

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Removing existing data...", SystemColors.Window);

            if (Properties.Settings.Default.GeneralImportRemoveTotalRow)
            {
                RowsToIgnore.Add("Total");
            }

            if (Properties.Settings.Default.GeneralImportRemoveLateFeeTotalRow)
            {
                RowsToIgnore.Add("Late Fee Total");
            }

            UpdateStatus("Loading data...", SystemColors.Window);

            TargetDataSource.BeginLoadData();
            (ResultText, Result, TargetDataSource) = Utilities.Data.GetCSVData(Filename, SplitCharacters, Properties.Settings.Default.GeneralImportHeaders, RowsToIgnore, "ImportFile");
            TargetDataSource.EndLoadData();

            if (Result)
            {
                UpdateStatus("  " + ResultText, Color.GreenYellow);
            }
            else
            {
                UpdateStatus("  " + ResultText, Color.Orange);
            }

            Cursor.Current = Cursors.Default;
            return Result;
        }

        private void DoSave()
        {
            Debug.Print($"Inside {CurrentMethodName()}");

            #region Euro Judo - .xls

            // EuroJudo "Members & Clubs for Import.xls"
            string EuroJudoFilename = Properties.Settings.Default.EuroJudoExportFilename;

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

                    // Loop through all players
                    foreach (DataRow Row in RevolutioniseSourceData.Rows)
                    {

                    }

                    //sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
                    //int rowIndex = 0;
                    //IRow row = sheet1.CreateRow(rowIndex);
                    //row.Height = 30 * 80;
                    //row.CreateCell(0).SetCellValue("this is content");
                    //sheet1.AutoSizeColumn(0);
                    //rowIndex++;


                    //ICellStyle style1 = workbook.CreateCellStyle();
                    //style1.FillForegroundColor = HSSFColor.Blue.Index2;
                    //style1.FillPattern = FillPattern.SolidForeground;

                    //ICellStyle style2 = workbook.CreateCellStyle();
                    //style2.FillForegroundColor = HSSFColor.Yellow.Index2;
                    //style2.FillPattern = FillPattern.SolidForeground;

                    //ICell cell2 = sheet2.CreateRow(0).CreateCell(0);
                    //cell02.CellStyle = style1;
                    //cell02.SetCellValue(0);

                    //cell02 = sheet2.CreateRow(1).CreateCell(0);
                    //cell02.CellStyle = style2;
                    //cell02.SetCellValue(1);

                    workbook.Write(fs);

                }
            }
            catch (UnauthorizedAccessException e)
            {
            }
            catch (Exception e)
            {
            }

            #endregion


            #region IJF - .csv



            #endregion
        }

        private void UpdateStatus(string Text, Color Colour)
        {
            ListViewItem NewItem = new ListViewItem();

            NewItem.BackColor = Colour;
            NewItem.Text = Text;

            lvwStatus.Items.Add(NewItem);
            tslblMain.Text = Text;


            this.Refresh();
        }



        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion


    }
}
