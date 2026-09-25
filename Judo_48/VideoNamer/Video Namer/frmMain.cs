using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Namer
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

        private int ContestNumber = 1;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LastFolder != "")
            {
                txtFolder.Text = Properties.Settings.Default.LastFolder;
            }

            GetFiles();

            cmbCompetitors.Items.AddRange(new object[]
            {
                @"Cadet",
                @"Junior",
                @"Senior",
                @"Veteran",
            });

            cmbEventType.SelectedIndex = 0;
            cmbCompetitors.SelectedIndex = 0;
            cmbCountry.SelectedIndex = 0;
            cmbWeightCategory.SelectedIndex = 0;

            txtContestNumber.Text = ContestNumber.ToString();
            txtYear.Text = DateTime.Now.Year.ToString();
            txtNewFilename.Text = GetNewFilename();
        }

        private void btnRenameOrCopy_Click(object sender, EventArgs e)
        {
            string CurrentFilename = "";
            string NewFilename = "";

            Cursor.Current = Cursors.WaitCursor;

            //txtNewFilename.Text = GetNewFilename();

            CurrentFilename = GetCurrentFilename();

            Player.Ctlcontrols.stop();
            NewFilename = System.IO.Path.Combine(txtFolder.Text, txtNewFilename.Text);


            if (chkDeleteOriginal.Checked)
            {
                try
                {
                    System.IO.File.Move(CurrentFilename, NewFilename);
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    System.IO.File.Copy(CurrentFilename, NewFilename);
                    System.IO.File.Move(CurrentFilename, CurrentFilename + ".bak");
                }
                catch
                {
                }
            }
            Cursor.Current = Cursors.Default;

            GetFiles();

            if (lvwFiles.SelectedItems.Count > 0)
            {

                int SelectedIndex = lvwFiles.SelectedIndices[0];

                if (lvwFiles.Items.Count > SelectedIndex + 1)
                {
                    lvwFiles.Items[SelectedIndex].Checked = false;
                    lvwFiles.Items[SelectedIndex + 1].Checked = true;

                    ContestNumber++;
                    txtContestNumber.Text = ContestNumber.ToString();

                    txtNewFilename.Text = GetNewFilename();
                }
            }

            txtNewFilename.Text = CheckFileExists(false);

            chkPartial.Checked = false;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fbdMedia.SelectedPath = txtFolder.Text;
            DialogResult Result = fbdMedia.ShowDialog();

            if (Result == DialogResult.OK)
            {
                txtFolder.Text = fbdMedia.SelectedPath;

                GetFiles();
                txtNewFilename.Text = GetNewFilename();

                Properties.Settings.Default.LastFolder = fbdMedia.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void cmbEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewFilename.Text = GetNewFilename();
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewFilename.Text = GetNewFilename();
        }

        private void cmbCompetitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewFilename.Text = GetNewFilename();

            GetWeightCategories();
        }

        private void cmbWeightCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewFilename.Text = GetNewFilename();
        }

        private void radMale_CheckedChanged(object sender, EventArgs e)
        {

            if (radMale.Checked)
            {
                txtNewFilename.Text = GetNewFilename();
                GetWeightCategories();
            }
        }

        private void radFemale_CheckedChanged(object sender, EventArgs e)
        {

            if (radFemale.Checked)
            {
                txtNewFilename.Text = GetNewFilename();
                GetWeightCategories();
            }
        }

        private void lvwFiles_Resize(object sender, EventArgs e)
        {
            lvwFiles.Columns[0].Width = lvwFiles.Width - 21;
        }

        private void lvwFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PlayerFilename = "";

            if (lvwFiles.SelectedItems.Count > 0)
            {
                txtNewFilename.Text = GetNewFilename();

                Cursor.Current = Cursors.WaitCursor;

                PlayerFilename = GetCurrentFilename();

                try
                {
                    Player.URL = PlayerFilename;
                    Player.settings.autoStart = true;
                }
                catch
                {
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            txtNewFilename.Text = GetNewFilename();
        }

        private void txtContestNumber_TextChanged(object sender, EventArgs e)
        {
            txtNewFilename.Text = GetNewFilename();
        }

        private void txtNewFilename_TextChanged(object sender, EventArgs e)
        {
            txtNewFilename.Text = CheckFileExists(true);
        }

        private void chkDeleteOriginal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeleteOriginal.Checked)
            {
                btnRenameOrCopy.Text = "Rename";
            }
            else
            {
                btnRenameOrCopy.Text = "Copy";
            }
        }

        private void Player_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
            //frmPlayer Player = null;

            //if (lvwFiles.SelectedItems.Count > 0)
            //{
            //    Player = new frmPlayer();

            //    Player.Show();

            //    Player.MediaPlayer.URL = lvwFiles.SelectedItems[0].Text;
            //    Player.MediaPlayer.settings.autoStart = true;
            //}
        }

        private void Player_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Player.Ctlcontrols.pause();
            }
            else if (Player.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                Cursor.Current = Cursors.WaitCursor;

                Player.Ctlcontrols.play();

                Cursor.Current = Cursors.Default;
            }
        }

        private void Player_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Player.Ctlcontrols.pause();
            }
            else if (Player.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                Cursor.Current = Cursors.WaitCursor;

                Player.Ctlcontrols.play();

                Cursor.Current = Cursors.Default;
            }
        }

        private void chkPartial_CheckedChanged(object sender, EventArgs e)
        {
            txtNewFilename.Text = GetNewFilename();
        }

        #endregion

        #region Private Methods

        private string GetNewFilename()
        {
            string Result = "";

            if (lvwFiles.SelectedItems.Count > 0)
            {
                string Gender = radMale.Checked ? "m" : "w";
                string EventType = cmbEventType.Text.ToLower();
                string Country = cmbCountry.Text.ToLower();
                string Competitors = cmbCompetitors.Text.ToLower().Substring(0, 3);
                string Year = txtYear.Text.ToLower();
                string WeightCategory = cmbWeightCategory.Text.ToLower().Replace("+", "p").Replace("-", "0").Replace("kg", "").PadLeft(4, '0');
                string ContestNumber = txtContestNumber.Text.PadLeft(3, '0');
                string Extension = System.IO.Path.GetExtension(GetCurrentFilename());
                string Partial = "";
                string Copy = "";

                Result = EventType + " " +
                         Competitors + " " +
                         Country +
                         Year + " " +
                         Gender + " " +
                         WeightCategory + " " +
                         ContestNumber;

                if (chkPartial.Checked)
                {
                    Partial = "_Partial";
                }

                if (lblFilenameCollision.Visible)
                {
                    Copy = "_Copy";
                }

                Result = Result.Replace(" ", "_") + Partial + Copy + Extension;
            }

            return Result;
        }

        private string GetCurrentFilename()
        {
            string Result = "";

            Result = System.IO.Path.Combine(txtFolder.Text, lvwFiles.SelectedItems[0].Text);

            return Result;
        }

        private void GetFiles()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (txtFolder.Text.Trim().Length > 0)
            {
                lvwFiles.Items.Clear();

                if (System.IO.Directory.Exists(txtFolder.Text))
                {

                }
                else
                {
                    txtFolder.Text = "";
                    return;
                }

                string FolderPath = System.IO.Path.Combine(txtFolder.Text);

                foreach (string Filename in System.IO.Directory.GetFiles(FolderPath))
                {
                    if (System.IO.Path.GetExtension(Filename).ToLower().EndsWith("mp4"))
                    {
                        lvwFiles.Items.Add(System.IO.Path.GetFileName(Filename));
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void GetWeightCategories()
        {
            if (radMale.Checked)
            {
                if ((cmbCompetitors.Text == "Senior") || (cmbCompetitors.Text == "Veteran"))
                {
                    cmbWeightCategory.Items.Clear();
                    cmbWeightCategory.Items.Add("-60Kg");
                    cmbWeightCategory.Items.Add("-66Kg");
                    cmbWeightCategory.Items.Add("-73Kg");
                    cmbWeightCategory.Items.Add("-81Kg");
                    cmbWeightCategory.Items.Add("-90Kg");
                    cmbWeightCategory.Items.Add("-100Kg");
                    cmbWeightCategory.Items.Add("+100Kg");
                    //cmbWeightCategory.Items.Add("Open");
                }
                if (cmbCompetitors.Text == "Junior")
                {
                    cmbWeightCategory.Items.Clear();
                    cmbWeightCategory.Items.Add("-55Kg");
                    cmbWeightCategory.Items.Add("-60Kg");
                    cmbWeightCategory.Items.Add("-66Kg");
                    cmbWeightCategory.Items.Add("-73Kg");
                    cmbWeightCategory.Items.Add("-81Kg");
                    cmbWeightCategory.Items.Add("-90Kg");
                    cmbWeightCategory.Items.Add("-100Kg");
                    cmbWeightCategory.Items.Add("+100Kg");
                    //cmbWeightCategory.Items.Add("Open");
                }
                if (cmbCompetitors.Text == "Cadet")
                {
                    cmbWeightCategory.Items.Clear();
                    cmbWeightCategory.Items.Add("-50Kg");
                    cmbWeightCategory.Items.Add("-55Kg");
                    cmbWeightCategory.Items.Add("-60Kg");
                    cmbWeightCategory.Items.Add("-66Kg");
                    cmbWeightCategory.Items.Add("-73Kg");
                    cmbWeightCategory.Items.Add("-81Kg");
                    cmbWeightCategory.Items.Add("-90Kg");
                    cmbWeightCategory.Items.Add("+90Kg");
                    //cmbWeightCategory.Items.Add("Open");
                }
            }
            else if (radFemale.Checked)
            {
                if ((cmbCompetitors.Text == "Senior") || (cmbCompetitors.Text == "Veteran"))
                {
                    cmbWeightCategory.Items.Clear();
                    cmbWeightCategory.Items.Add("-48Kg");
                    cmbWeightCategory.Items.Add("-52Kg");
                    cmbWeightCategory.Items.Add("-57Kg");
                    cmbWeightCategory.Items.Add("-63Kg");
                    cmbWeightCategory.Items.Add("-70Kg");
                    cmbWeightCategory.Items.Add("-78Kg");
                    cmbWeightCategory.Items.Add("+78Kg");
                    //cmbWeightCategory.Items.Add("Open");
                }
                if (cmbCompetitors.Text == "Junior")
                {
                    cmbWeightCategory.Items.Clear();
                    cmbWeightCategory.Items.Add("-44Kg");
                    cmbWeightCategory.Items.Add("-48Kg");
                    cmbWeightCategory.Items.Add("-52Kg");
                    cmbWeightCategory.Items.Add("-57Kg");
                    cmbWeightCategory.Items.Add("-63Kg");
                    cmbWeightCategory.Items.Add("-70Kg");
                    cmbWeightCategory.Items.Add("-78Kg");
                    cmbWeightCategory.Items.Add("+78Kg");
                    //cmbWeightCategory.Items.Add("Open");
                }
                if (cmbCompetitors.Text == "Cadet")
                {
                    cmbWeightCategory.Items.Clear();
                    cmbWeightCategory.Items.Add("-40Kg");
                    cmbWeightCategory.Items.Add("-44Kg");
                    cmbWeightCategory.Items.Add("-48Kg");
                    cmbWeightCategory.Items.Add("-52Kg");
                    cmbWeightCategory.Items.Add("-57Kg");
                    cmbWeightCategory.Items.Add("-63Kg");
                    cmbWeightCategory.Items.Add("-70Kg");
                    cmbWeightCategory.Items.Add("+70Kg");
                    //cmbWeightCategory.Items.Add("Open");
                }
            }

            cmbWeightCategory.SelectedIndex = 0;
        }

        private string CheckFileExists(bool ShowMessage)
        {
            string FullFilename = System.IO.Path.Combine(txtFolder.Text, txtNewFilename.Text);
            string Result = "";

            Cursor.Current = Cursors.WaitCursor;

            if (System.IO.File.Exists(FullFilename))
            {
                Result = System.IO.Path.GetFileNameWithoutExtension(FullFilename) + "_Copy" + System.IO.Path.GetExtension(FullFilename);

                btnRenameOrCopy.Enabled = false;

                if (ShowMessage)
                {
                    lblFilenameCollision.Visible = true;
                }
            }
            else
            {
                Result = txtNewFilename.Text;

                btnRenameOrCopy.Enabled = true;
                lblFilenameCollision.Visible = false;
            }

            Cursor.Current = Cursors.Default;

            return Result;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
