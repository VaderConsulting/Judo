using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MappingTool
{
    public partial class frmImport : Form
    {
        private string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public string ImportFilename = "";


        public frmImport(string LastFilename)
        {
            InitializeComponent();

            txtFilename.Text = LastFilename;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            ImportFilename = txtFilename.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void BtnEuroJudoImportFileBrowse_Click(object sender, EventArgs e)
        {
            string DefaultFolder = MyDocumentsPath;
            string NewFilename = "";

            if (txtFilename.Text != "")
            {
                DefaultFolder = txtFilename.Text;
            }

            NewFilename = BrowseForFilename(DefaultFolder, Save: false, "csv");

            txtFilename.Text = NewFilename;
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
