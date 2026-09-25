using EuroJudo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Utilities.Extensions;

namespace FlagRaising
{
    public partial class frmConfig : Form
    {
        frmDisplay DisplayForm = null;
        List<Country> Countries = new List<Country>();

        public frmConfig()
        {
            InitializeComponent();

            DisplayForm = new frmDisplay();
        }

        private void btnRaise_Click(object sender, EventArgs e)
        {
            if (DisplayForm == null)
            {
                DisplayForm = new frmDisplay();
            }
            else if (DisplayForm.IsDisposed)
            {
                DisplayForm = new frmDisplay();
            }

            Country Country1 = (Country)cmbGold.SelectedItem;
            Country Country2 = (Country)cmbSilver.SelectedItem;
            Country Country3 = (Country)cmbBronze1.SelectedItem;
            Country Country4 = (Country)cmbBronze2.SelectedItem;

            DisplayForm.BackColor = Color.White;

            int TargetScreenNumber = Convert.ToInt32(cmbScreen.SelectedItem) - 1;

            if (DisplayForm.Visible != true)
            {
                DisplayForm.Show();
            }

            DisplayForm.SendToDisplay(TargetScreenNumber);

            DisplayForm.Raise(txtTournament.Text, cmbCategory.Text + " " + cmbDivision.Text, Country1, Country2, Country3, Country4, 50, radSilverSilverBronzeBronze.Checked, -1);

        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            if (DisplayForm != null && !DisplayForm.IsDisposed)
            {
                DisplayForm.Lower(75, 1);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbCategory.Text == "Senior Mens") || (cmbCategory.Text == "Veteran Mens"))
            {
                cmbDivision.Items.Clear();
                cmbDivision.Items.Add("-60Kg");
                cmbDivision.Items.Add("-66Kg");
                cmbDivision.Items.Add("-73Kg");
                cmbDivision.Items.Add("-81Kg");
                cmbDivision.Items.Add("-90Kg");
                cmbDivision.Items.Add("-100Kg");
                cmbDivision.Items.Add("+100Kg");
                cmbDivision.Items.Add("Open");
            }
            if ((cmbCategory.Text == "Senior Womens") || (cmbCategory.Text == "Veteran Womens"))
            {
                cmbDivision.Items.Clear();
                cmbDivision.Items.Add("-48Kg");
                cmbDivision.Items.Add("-52Kg");
                cmbDivision.Items.Add("-57Kg");
                cmbDivision.Items.Add("-63Kg");
                cmbDivision.Items.Add("-70Kg");
                cmbDivision.Items.Add("-78Kg");
                cmbDivision.Items.Add("+78Kg");
                cmbDivision.Items.Add("Open");
            }
            if (cmbCategory.Text == "Junior Mens")
            {
                cmbDivision.Items.Clear();
                cmbDivision.Items.Add("-55Kg");
                cmbDivision.Items.Add("-60Kg");
                cmbDivision.Items.Add("-66Kg");
                cmbDivision.Items.Add("-73Kg");
                cmbDivision.Items.Add("-81Kg");
                cmbDivision.Items.Add("-90Kg");
                cmbDivision.Items.Add("-100Kg");
                cmbDivision.Items.Add("+100Kg");
                cmbDivision.Items.Add("Open");
            }
            if (cmbCategory.Text == "Junior Womens")
            {
                cmbDivision.Items.Clear();
                cmbDivision.Items.Add("-44Kg");
                cmbDivision.Items.Add("-48Kg");
                cmbDivision.Items.Add("-52Kg");
                cmbDivision.Items.Add("-57Kg");
                cmbDivision.Items.Add("-63Kg");
                cmbDivision.Items.Add("-70Kg");
                cmbDivision.Items.Add("-78Kg");
                cmbDivision.Items.Add("+78Kg");
                cmbDivision.Items.Add("Open");
            }
            if (cmbCategory.Text == "Cadet Mens")
            {
                cmbDivision.Items.Clear();
                cmbDivision.Items.Add("-50Kg");
                cmbDivision.Items.Add("-55Kg");
                cmbDivision.Items.Add("-60Kg");
                cmbDivision.Items.Add("-66Kg");
                cmbDivision.Items.Add("-73Kg");
                cmbDivision.Items.Add("-81Kg");
                cmbDivision.Items.Add("-90Kg");
                cmbDivision.Items.Add("+90Kg");
                cmbDivision.Items.Add("Open");
            }
            if (cmbCategory.Text == "Cadet Womens")
            {
                cmbDivision.Items.Clear();
                cmbDivision.Items.Add("-40Kg");
                cmbDivision.Items.Add("-44Kg");
                cmbDivision.Items.Add("-48Kg");
                cmbDivision.Items.Add("-52Kg");
                cmbDivision.Items.Add("-57Kg");
                cmbDivision.Items.Add("-63Kg");
                cmbDivision.Items.Add("-70Kg");
                cmbDivision.Items.Add("+70Kg");
                cmbDivision.Items.Add("Open");
            }
            //tbCategory.Text = cmbSex.SelectedItem.ToString();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            this.cmbCategory.Items.AddRange(new object[]
            {
                @"Cadet Mens",
                @"Cadet Womens",
                @"Junior Mens",
                @"Junior Womens",
                @"Senior Mens",
                @"Senior Womens",
                @"Veteran Mens",
                @"Veteran Womens"
            });

            Countries = GetCountries("Countries.csv");

            foreach (Country c in Countries)
            {
                cmbGold.Items.Add(c);
                cmbSilver.Items.Add(c);
                cmbBronze1.Items.Add(c);
                cmbBronze2.Items.Add(c);
            }

            // What screen is this form on?
            Screen ThisScreen = this.GetScreen();

            int Index = 0;
            bool ComboSet = false;

            if (Screen.AllScreens.Count() > 1)
            {
                foreach (Screen s in Screen.AllScreens)
                {
                    cmbScreen.Items.Add(Index + 1);

                    if (s != ThisScreen && !ComboSet)
                    {
                        cmbScreen.SelectedIndex = Index;
                        ComboSet = true;
                    }

                    Index++;
                }
            }
            else
            {
                cmbScreen.Items.Add("1");

                cmbScreen.SelectedIndex = 0;
            }
        }

        private void radGoldSilverBronzeBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (radGoldSilverBronzeBronze.Checked)
            {
                lblGoldOrSilver.Text = "Gold";
            }
        }

        private void radSilverSilverBronzeBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (radSilverSilverBronzeBronze.Checked)
            {
                lblGoldOrSilver.Text = "Silver";
            }
        }

        private List<Country> GetCountries(string Filename)
        {
            bool Result = false;
            List<Country> ListResult = new List<Country>();
            string[] SplitCharacters = new string[] { "," };
            List<string> RowsToIgnore = null;

            Debug.Print($"Inside {CurrentMethodName()}");

            Cursor.Current = Cursors.WaitCursor;

            DataTable DataResult = null;
            string TextResult = "";

            (TextResult, Result, DataResult) = Utilities.Data.GetCSVData(Filename, SplitCharacters, true, RowsToIgnore, "Countries");

            foreach (DataRow Row in DataResult.Rows)
            {
                string Name = Row.ItemArray[0].ToString();
                string Alpha2 = Row.ItemArray[1].ToString();
                string Alpha3 = Row.ItemArray[2].ToString();
                string IOCCode = Row.ItemArray[3].ToString();
                string Anthem = Row.ItemArray[4].ToString();
                string Flag = Row.ItemArray[5].ToString();

                Country NewCountry = new Country(Name, Alpha2, Alpha3, IOCCode, Flag, Anthem);
                ListResult.Add(NewCountry);
            }

            Cursor.Current = Cursors.Default;

            return ListResult;
        }
    }
}
