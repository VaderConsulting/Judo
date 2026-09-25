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

namespace Designer
{
    public partial class frmOptions : Form
    {
        private string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string EuroJudoDbPath = "";

        public frmOptions()
        {
            InitializeComponent();
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            txtEuroJudoClubsFilename.Text = Properties.Settings.Default.EuroJudoClubsFilename;
            txtEuroJudoCountriesFilename.Text = Properties.Settings.Default.EuroJudoCountriesFilename;
            txtEuroJudoDatabaseFilename.Text = Properties.Settings.Default.EuroJudoDatabaseFilename;
            txtEuroJudoImportFilename.Text = Properties.Settings.Default.ImportFilename;
            txtEuroJudoSubDivisionFilename.Text = Properties.Settings.Default.EuroJudoSubDivisionsFilename;
            txtIJFExportFilename.Text = Properties.Settings.Default.IJFExportFilename;
            txtMinEventComparisonResult.Text = Properties.Settings.Default.EuroJudoEventValueMinimumComparison.ToString();
            txtMinWeightCategoryComparisonResult.Text = Properties.Settings.Default.EuroJudoWeightValueMinimumComparison.ToString();
            txtMinClubComparisonResult.Text = Properties.Settings.Default.EuroJudoClubValueMinimumComparison.ToString();

            chkRemoveTotalRow.Checked = Properties.Settings.Default.RemoveTotalRowFromImport;
            chkImportHasHeaders.Checked = Properties.Settings.Default.ImportFileHasHeaders;

            cmbSplitCharacters.Items.Add(",");
            cmbSplitCharacters.Items.Add(";");

            if (Properties.Settings.Default.LastImportDelimiter != "")
            {
                cmbSplitCharacters.SelectedItem = Properties.Settings.Default.LastImportDelimiter;
            }
            else
            {
                cmbSplitCharacters.SelectedItem = cmbSplitCharacters.Items[0];
            }

            // Get default database path for EuroJudo Db...
            EuroJudoDbPath = Utilities.Registry.GetString(RegistryHive.CurrentUser, @"Software\VB and VBA Program Settings\EuroJudo\PathNames", "SystemDBasePath").ToString();

            if (Properties.Settings.Default.EuroJudoDatabaseFilename == "")
            {
                if (EuroJudoDbPath != "")
                {
                    txtEuroJudoDatabaseFilename.Text = EuroJudoDbPath + @"Tournaments.mdb";
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.EuroJudoClubsFilename = txtEuroJudoClubsFilename.Text;
                Properties.Settings.Default.EuroJudoCountriesFilename = txtEuroJudoCountriesFilename.Text;
                Properties.Settings.Default.EuroJudoDatabaseFilename = txtEuroJudoDatabaseFilename.Text;
                Properties.Settings.Default.EuroJudoExportFilename = txtEuroJudoImportFilename.Text;
                Properties.Settings.Default.EuroJudoSubDivisionsFilename = txtEuroJudoSubDivisionFilename.Text;
                Properties.Settings.Default.IJFExportFilename = txtIJFExportFilename.Text;
                Properties.Settings.Default.EuroJudoEventValueMinimumComparison = Convert.ToDouble(txtMinEventComparisonResult.Text);
                Properties.Settings.Default.EuroJudoWeightValueMinimumComparison = Convert.ToDouble(txtMinWeightCategoryComparisonResult.Text);
                Properties.Settings.Default.EuroJudoClubValueMinimumComparison = Convert.ToDouble(txtMinClubComparisonResult.Text);

                Properties.Settings.Default.RemoveTotalRowFromImport = chkRemoveTotalRow.Checked;
                Properties.Settings.Default.ImportFileHasHeaders = chkImportHasHeaders.Checked;

                Properties.Settings.Default.LastImportDelimiter = cmbSplitCharacters.SelectedItem.ToString();

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

            NewFilename = BrowseForFilename(DefaultFolder, Save: false, "csv");

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

            NewFilename = BrowseForFilename(DefaultFolder, Save: false, "csv");

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

            NewFilename = BrowseForFilename(DefaultFolder, Save: false, "csv");

            txtEuroJudoSubDivisionFilename.Text = NewFilename;

        }

        private void BtnEuroJudoSaveFileBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtEuroJudoImportFilename.Text != "")
            {
                DefaultFolder = txtEuroJudoImportFilename.Text;
            }

            NewFilename = BrowseForFilename(DefaultFolder, Save: false, "csv");

            txtEuroJudoImportFilename.Text = NewFilename;

        }

        private void BtnIJFExportBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtIJFExportFilename.Text != "")
            {
                DefaultFolder = txtIJFExportFilename.Text;
            }

            NewFilename = BrowseForFilename(DefaultFolder, Save: true, "csv");

            txtIJFExportFilename.Text = NewFilename;

        }

        private void BtnEuroJudoDatabaseBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = EuroJudoDbPath;
            string NewFilename = "";

            if (txtEuroJudoDatabaseFilename.Text != "")
            {
                DefaultFolder = txtEuroJudoDatabaseFilename.Text;
            }

            NewFilename = BrowseForFilename(DefaultFolder, Save: false, "mdb");

            txtEuroJudoDatabaseFilename.Text = NewFilename;

        }

        private string BrowseForFilename(string RecentPath, bool Save, string DefaultExtension)
        {
            string Result = "";
            FileDialog fd = null;

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

            if (Save)
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
            }
            else
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

            return Result;
        }

        
    }
}
