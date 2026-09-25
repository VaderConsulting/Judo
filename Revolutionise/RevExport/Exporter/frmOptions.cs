using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using static Utilities.Extensions;

namespace MappingTool
{
    public partial class frmOptions : Form
    {
        private enum BrowseType
        {
            Load,
            Save,
            Folder
        }

        private string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string EuroJudoDbPath = "";
        private bool EuroJudoDatabaseError = false;

        public frmOptions()
        {
            InitializeComponent();
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            txtImportFilename.Text = Properties.Settings.Default.GeneralImportFilename;

            txtEuroJudoClubsFilename.Text = Properties.Settings.Default.ReferenceClubsFilename;
            txtEuroJudoCountriesFilename.Text = Properties.Settings.Default.ReferenceCountriesFilename;
            txtEuroJudoSubDivisionFilename.Text = Properties.Settings.Default.ReferenceSubDivisionsFilename;

            txtEuroJudoDatabaseFilename.Text = Properties.Settings.Default.EuroJudoDatabaseFilename;

            txtIJFExportFolder.Text = Properties.Settings.Default.IJFExportFolder;
            txtEuroJudoExportFilename.Text = Properties.Settings.Default.EuroJudoExportFilename;

            txtEuroJudoEventQuery.Text = Properties.Settings.Default.EuroJudoEventQuery;
            txtEuroJudoTournamentQuery.Text = Properties.Settings.Default.EuroJudoTournamentQuery;
            txtEuroJudoWeightQuery.Text = Properties.Settings.Default.EuroJudoWeightQuery;

            txtIJFDatabaseConnectionString.Text = Properties.Settings.Default.IJFDatabaseConnectionString;
            txtIJFTournamentQuery.Text = Properties.Settings.Default.IJFTournamentQuery;
            txtIJFWeightQuery.Text = Properties.Settings.Default.IJFWeightQuery;
            txtIJFUserPhotoFolder.Text = Properties.Settings.Default.IJFUserPhotoSaveFolder;
            txtIJFSystemPhotoFolder.Text = Properties.Settings.Default.IJFSystemPhotoSaveFolder;

            chkRemoveTotalRow.Checked = Properties.Settings.Default.GeneralImportRemoveTotalRow;
            chkRemoveLateFeeTotalRow.Checked = Properties.Settings.Default.GeneralImportRemoveLateFeeTotalRow;
            chkImportHasHeaders.Checked = Properties.Settings.Default.GeneralImportHeaders;

            txtClubDefaultCountryCode.Text = Properties.Settings.Default.GeneralClubDefaultCountryCode;
            chkShowDataInfoWindow.Checked = Properties.Settings.Default.GeneralShowDataInfoWindow;

            cmbSplitCharacters.Items.Add(",");
            cmbSplitCharacters.Items.Add(";");

            if (Properties.Settings.Default.GeneralImportDelimiter != "")
            {
                cmbSplitCharacters.SelectedItem = Properties.Settings.Default.GeneralImportDelimiter;
            }
            else
            {
                cmbSplitCharacters.SelectedItem = cmbSplitCharacters.Items[0];
            }

            if (Properties.Settings.Default.IJFPhotoFilenameIsMemberID)
            {
                radIJFPictureNameEqualsMemberID.Checked = true;
            }
            else
            {
                radIJFPictureNameEqualsCountryLastFirst.Checked = true;
            }

            // Get default database path for EuroJudo Db...
            EuroJudoDbPath = Utilities.Registry.GetString(RegistryHive.CurrentUser, @"Software\VB and VBA Program Settings\EuroJudo\PathNames", "SystemDBasePath");

            if (Properties.Settings.Default.EuroJudoDatabaseFilename == "")
            {
                if (EuroJudoDbPath != "")
                {
                    txtEuroJudoDatabaseFilename.Text = EuroJudoDbPath + @"Tournaments.mdb";
                }
                else
                {
                    txtEuroJudoDatabaseFilename.Text = "ERROR:  EuroJudo database not found";
                    EuroJudoDatabaseError = true;
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.GeneralImportFilename = txtImportFilename.Text;

                Properties.Settings.Default.ReferenceClubsFilename = txtEuroJudoClubsFilename.Text;
                Properties.Settings.Default.ReferenceCountriesFilename = txtEuroJudoCountriesFilename.Text;
                Properties.Settings.Default.ReferenceSubDivisionsFilename = txtEuroJudoSubDivisionFilename.Text;

                if (!EuroJudoDatabaseError)
                {
                    Properties.Settings.Default.EuroJudoDatabaseFilename = txtEuroJudoDatabaseFilename.Text;
                }

                Properties.Settings.Default.IJFExportFolder = txtIJFExportFolder.Text;
                Properties.Settings.Default.EuroJudoExportFilename = txtEuroJudoExportFilename.Text;

                Properties.Settings.Default.EuroJudoEventQuery = txtEuroJudoEventQuery.Text;
                Properties.Settings.Default.EuroJudoTournamentQuery = txtEuroJudoTournamentQuery.Text;
                Properties.Settings.Default.EuroJudoWeightQuery = txtEuroJudoWeightQuery.Text;

                Properties.Settings.Default.IJFDatabaseConnectionString = txtIJFDatabaseConnectionString.Text;
                Properties.Settings.Default.IJFTournamentQuery = txtIJFTournamentQuery.Text;
                Properties.Settings.Default.IJFWeightQuery = txtIJFWeightQuery.Text;
                Properties.Settings.Default.IJFUserPhotoSaveFolder = txtIJFUserPhotoFolder.Text;
                Properties.Settings.Default.IJFSystemPhotoSaveFolder = txtIJFSystemPhotoFolder.Text;

                Properties.Settings.Default.GeneralImportRemoveTotalRow = chkRemoveTotalRow.Checked;
                Properties.Settings.Default.GeneralImportRemoveLateFeeTotalRow = chkRemoveLateFeeTotalRow.Checked;
                Properties.Settings.Default.GeneralImportHeaders = chkImportHasHeaders.Checked;

                Properties.Settings.Default.GeneralClubDefaultCountryCode = txtClubDefaultCountryCode.Text;
                Properties.Settings.Default.GeneralShowDataInfoWindow = chkShowDataInfoWindow.Checked;

                Properties.Settings.Default.GeneralImportDelimiter = cmbSplitCharacters.SelectedItem.ToString();

                if (radIJFPictureNameEqualsMemberID.Checked)
                {
                    Properties.Settings.Default.IJFPhotoFilenameIsMemberID = true;
                }
                else
                {
                    Properties.Settings.Default.IJFPhotoFilenameIsMemberID = false;
                }

                Properties.Settings.Default.Save();

                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch
            {

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEuroJudoClubsFileBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtEuroJudoClubsFilename.Text != "")
            {
                DefaultFolder = txtEuroJudoClubsFilename.Text;
            }

            NewFilename = BrowseForFileOrFolder(DefaultFolder, BrowseType.Load, DefaultExtension: "csv");

            txtEuroJudoClubsFilename.Text = NewFilename;
        }

        private void BtnEuroJudoCountriesFileBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtEuroJudoCountriesFilename.Text != "")
            {
                DefaultFolder = txtEuroJudoCountriesFilename.Text;
            }

            NewFilename = BrowseForFileOrFolder(DefaultFolder, BrowseType.Load, DefaultExtension: "csv");

            txtEuroJudoCountriesFilename.Text = NewFilename;

        }

        private void BtnEuroJudoSubDivisionsFileBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtEuroJudoSubDivisionFilename.Text != "")
            {
                DefaultFolder = txtEuroJudoSubDivisionFilename.Text;
            }

            NewFilename = BrowseForFileOrFolder(DefaultFolder, BrowseType.Load, DefaultExtension: "csv");

            txtEuroJudoSubDivisionFilename.Text = NewFilename;

        }

        private void BtnEuroJudoSaveFileBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtImportFilename.Text != "")
            {
                DefaultFolder = txtImportFilename.Text;
            }

            NewFilename = BrowseForFileOrFolder(DefaultFolder, BrowseType.Load, DefaultExtension: "csv");

            txtImportFilename.Text = NewFilename;

        }

        private void BtnIJFExportBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtIJFExportFolder.Text != "")
            {
                DefaultFolder = txtIJFExportFolder.Text;
            }

            NewFilename = BrowseForFileOrFolder(DefaultFolder, BrowseType.Folder, DefaultExtension: "");

            txtIJFExportFolder.Text = NewFilename;

        }

        private void BtnEuroJudoDatabaseBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = EuroJudoDbPath;
            string NewFilename = "";

            if (txtEuroJudoDatabaseFilename.Text != "")
            {
                DefaultFolder = txtEuroJudoDatabaseFilename.Text;
            }

            NewFilename = BrowseForFileOrFolder(DefaultFolder, BrowseType.Load, DefaultExtension: "mdb");

            txtEuroJudoDatabaseFilename.Text = NewFilename;

        }

        private void BtnEuroJudoExportBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtEuroJudoExportFilename.Text != "")
            {
                DefaultFolder = txtEuroJudoExportFilename.Text;
            }

            NewFilename = BrowseForFileOrFolder(DefaultFolder, BrowseType.Save, DefaultExtension: "xls");

            txtEuroJudoExportFilename.Text = NewFilename;
        }

        private void btnIJFUserPhotoBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFolder = "";

            if (txtIJFUserPhotoFolder.Text != "")
            {
                DefaultFolder = txtIJFUserPhotoFolder.Text;
            }

            NewFolder = BrowseForFileOrFolder(DefaultFolder, BrowseType.Folder, DefaultExtension: "");

            txtIJFUserPhotoFolder.Text = NewFolder;
        }

        private void btnIJFSystemPhotoBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFolder = "";

            if (txtIJFSystemPhotoFolder.Text != "")
            {
                DefaultFolder = txtIJFSystemPhotoFolder.Text;
            }

            NewFolder = BrowseForFileOrFolder(DefaultFolder, BrowseType.Folder, DefaultExtension: "");

            txtIJFSystemPhotoFolder.Text = NewFolder;
        }

        private string BrowseForFileOrFolder(string RecentPath, BrowseType BrowseType, string DefaultExtension)
        {
            string Result = "";
            FileDialog fd = null;
            FolderBrowserDialog fb = null;

            if (RecentPath.Trim() == "")
            {
                // No recent filename
                RecentPath = MyDocumentsPath;
            }
            else
            {
                // A previous filename was specified
                //DefaultExtension = System.IO.Path.GetExtension(RecentPath);
            }

            switch (BrowseType)
            {
                case BrowseType.Save:
                    {
                        fd = new SaveFileDialog();
                        fd.AddExtension = true;
                        fd.CheckPathExists = false;
                        fd.DefaultExt = DefaultExtension;
                        fd.AutoUpgradeEnabled = true;
                        fd.Title = "Choose a filename to save";
                        fd.ValidateNames = true;

                        if (System.IO.Path.HasExtension(RecentPath))
                        {
                            fd.InitialDirectory = System.IO.Path.GetDirectoryName(RecentPath);
                        }
                        else
                        {
                            fd.InitialDirectory = RecentPath;
                        }

                        DialogResult dResult = fd.ShowDialog();

                        if (dResult == DialogResult.OK)
                        {
                            Result = fd.FileName;
                        }
                        else
                        {
                            Result = RecentPath;
                        }

                        break;
                    }
                case BrowseType.Load:
                    {
                        fd = new OpenFileDialog();
                        fd.CheckPathExists = true;
                        fd.DefaultExt = DefaultExtension;
                        fd.AutoUpgradeEnabled = true;
                        fd.Title = "Choose a filename to load";
                        fd.ValidateNames = true;

                        if (System.IO.Path.HasExtension(RecentPath))
                        {
                            fd.InitialDirectory = System.IO.Path.GetDirectoryName(RecentPath);
                        }
                        else
                        {
                            fd.InitialDirectory = RecentPath;
                        }

                        DialogResult dResult = fd.ShowDialog();

                        if (dResult == DialogResult.OK)
                        {
                            Result = fd.FileName;
                        }
                        else
                        {
                            Result = RecentPath;
                        }

                        break;
                    }
                case BrowseType.Folder:
                    {
                        fb = new FolderBrowserDialog();
                        fb.ShowNewFolderButton = true;
                        fb.Description = "Choose a folder for IJF photo's";

                        fb.RootFolder = Environment.SpecialFolder.MyComputer;

                        DialogResult dResult = fb.ShowDialog();

                        if (dResult == DialogResult.OK)
                        {
                            Result = fb.SelectedPath;
                        }
                        else
                        {
                            Result = RecentPath;
                        }
                        break;
                    }
            }

            return Result;
        }


    }
}
