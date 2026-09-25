using EuroJudo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Utilities.Extensions;

namespace FlagRaising
{
    public partial class frmDisplay : Form
    {
        private float VerticalPosition = 999f;         // Position of the Gold flag
        private float VerticalOffset = -0.5f;          // Vertical position changes by -0.5% every timer interval
        private float VerticalPositionPercentage = 100;
        private float GoldOffsetPercentage = 0;
        private float SilverOffsetPercentage = 10;
        private float BronzeOffsetPercentage = 20;
        private bool TwoSilverMedals = false;

        public frmDisplay()
        {
            InitializeComponent();

            // Prevent flashing
            picSilver.DoubleBuffered(true);
            picGold.DoubleBuffered(true);
            picBronze1.DoubleBuffered(true);
            picBronze2.DoubleBuffered(true);
        }

        private void frmDisplay_Load(object sender, EventArgs e)
        {           
            CalculateVerticalPosition();

            this.WindowState = FormWindowState.Maximized;
        }

        private void tmrMovement_Tick(object sender, EventArgs e)
        {
            CalculateVerticalPosition();

            SetVerticalPosition();
        }

        private void CalculateVerticalPosition()
        {
            int FormHeight = pnlGold.Height;
            float PositionAsPercentage = FormHeight * (VerticalPosition / 100);

            VerticalPositionPercentage = VerticalPositionPercentage + VerticalOffset;  // y position as a percentage

            VerticalPosition = FormHeight * (VerticalPositionPercentage / 100);

            if (VerticalPositionPercentage <= 0)
            {
                tmrMovement.Enabled = false;
                VerticalPositionPercentage = 0;

                OnTopReached();
            }
            else if (VerticalPositionPercentage >= 100f)
            {
                tmrMovement.Enabled = false;
                VerticalPositionPercentage = 100;

                OnBottomReached();
            }
        }

        private void SetVerticalPosition()
        {
            if (TwoSilverMedals)
            {
                GoldOffsetPercentage = SilverOffsetPercentage;
            }
            else
            {
                GoldOffsetPercentage = 0;
            }

            float GoldOffset = (GoldOffsetPercentage / 100) * pnlGold.Height;
            float SilverOffset = (SilverOffsetPercentage / 100) * pnlGold.Height;
            float BronzeOffset = (BronzeOffsetPercentage / 100) * pnlGold.Height;
            float GoldY = VerticalPosition + GoldOffset;
            float SilverY = VerticalPosition + SilverOffset;
            float BronzeY = VerticalPosition + BronzeOffset;

            picGold.Location = new Point(3, (int)GoldY);
            picSilver.Location = new Point(3, (int)SilverY);
            picBronze1.Location = new Point(3, (int)BronzeY);
            picBronze2.Location = picBronze1.Location;

            Debug.Print($"Offsets: Gold={GoldOffset}, Silver={SilverOffset}, Bronze={BronzeOffset}, Positions: Gold={GoldY}, Silver={SilverY}, Bronze={BronzeY}");
        }

        public void Raise(string TournamentName, string Details, Country GoldMedalist, Country SilverMedalist, Country BronzeMedalist1, Country BronzeMedalist2, int Speed = 30, bool TwoSilver = false, float Resolution = -0.5f)
        {
            lblTournamentName.Text = TournamentName;
            lblDetails.Text = Details;
            TwoSilverMedals = TwoSilver;

            VerticalOffset = Resolution;

            CalculateVerticalPosition();
            SetVerticalPosition();

            string[] AllResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            if (GoldMedalist != null)
            {
                try
                {
                    string GoldResourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().Single(str => str.EndsWith(GoldMedalist.FlagFilename));

                    if (GoldResourceName != null)
                    {
                        System.IO.Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream(GoldResourceName);
                        Image img = Image.FromStream(strm);

                        picGold.Image = img;
                    }
                }
                catch
                {
                }
            }

            if (SilverMedalist != null)
            {
                try
                {
                    string SilverResourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().Single(str => str.EndsWith(SilverMedalist.FlagFilename));

                    if (SilverResourceName != null)
                    {
                        System.IO.Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream(SilverResourceName);
                        Image img = Image.FromStream(strm);

                        picSilver.Image = img;
                    }
                }
                catch
                {
                }
            }

            if (BronzeMedalist1 != null)
            {
                try
                {
                    string Bronze1ResourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().Single(str => str.EndsWith(BronzeMedalist1.FlagFilename));

                    if (Bronze1ResourceName != null)
                    {
                        System.IO.Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream(Bronze1ResourceName);
                        Image img = Image.FromStream(strm);

                        picBronze1.Image = img;
                    }
                }
                catch
                {
                }
            }

            if (BronzeMedalist2 != null)
            {
                try
                {
                    string Bronze2ResourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().Single(str => str.EndsWith(BronzeMedalist2.FlagFilename));

                    if (Bronze2ResourceName != null)
                    {
                        System.IO.Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream(Bronze2ResourceName);
                        Image img = Image.FromStream(strm);

                        picBronze2.Image = img;
                    }
                }
                catch
                {
                }
            }

            picGold.Visible = true;
            picSilver.Visible = true;
            picBronze1.Visible = true;
            picBronze2.Visible = true;

            tmrMovement.Interval = Speed;
            tmrMovement.Enabled = true;

            //FadeFromBlack();

            tmrMovement.Start();
        }

        public void Lower(int Speed = 50, float Resolution = 0.5f)
        {
            VerticalOffset = Resolution;

            CalculateVerticalPosition();
            SetVerticalPosition();

            picGold.Visible = true;
            picSilver.Visible = true;
            picBronze1.Visible = true;
            picBronze2.Visible = true;

            tmrMovement.Interval = Speed;
            tmrMovement.Enabled = true;
            tmrMovement.Start();
        }

        private void frmDisplay_Resize(object sender, EventArgs e)
        {
            CalculateVerticalPosition();
            SetVerticalPosition();
        }

        private void OnTopReached()
        {

        }

        private void OnBottomReached()
        {
            //FadeToBlack();
        }

        private void FadeToBlack()
        {
            int ShadeR = 255;
            int ShadeG = 255;
            int ShadeB = 255;

            for (int i = 0; i < 254; i++)
            {
                ShadeR--;
                this.BackColor = Color.FromArgb(ShadeR, ShadeG, ShadeB);

                ShadeG--;
                this.BackColor = Color.FromArgb(ShadeR, ShadeG, ShadeB);

                ShadeB--;
                this.BackColor = Color.FromArgb(ShadeR, ShadeG, ShadeB);

                Application.DoEvents();
            }
        }

        private void FadeFromBlack()
        {
            int ShadeR = 0;
            int ShadeG = 0;
            int ShadeB = 0;

            for (int i = 254; i > 0; i--)
            {
                ShadeR++;
                this.BackColor = Color.FromArgb(ShadeR, ShadeG, ShadeB);

                ShadeG++;
                this.BackColor = Color.FromArgb(ShadeR, ShadeG, ShadeB);

                ShadeB++;
                this.BackColor = Color.FromArgb(ShadeR, ShadeG, ShadeB);

                Application.DoEvents();
            }
        }
    }
}
