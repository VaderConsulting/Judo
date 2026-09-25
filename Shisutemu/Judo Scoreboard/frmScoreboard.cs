using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace Judo_Scoreboard
{
    public partial class frmScoreboard : Form
    {
        #region Constants

        const StringAlignment _CenterAlignment = StringAlignment.Center;
        const StringAlignment _LeftAlignment = StringAlignment.Near;
        const StringAlignment _RightAlignment = StringAlignment.Far;

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

        TimeSpan _MainInterval = new TimeSpan();
        TimeSpan _SecondaryInterval = new TimeSpan();
        ClientServer.Server _Server = null;
        Task _ServerTask = null;
        int _MatNumber = 1;
        bool _Loaded = false;
        int _ScoreInterval = 2000;  // This is the time that the last score is shown (mS)
        //bool _MatchInProgress = false;

        Font _CategoryNameFont = null;
        Font _CategoryDescriptionFont = null;
        Font _CategoryWeightFont = null;
        Font _PlayerSurnameFont = null;
        Font _ClubNameFont = null;
        Font _WazaAriFont = null;
        Font _ShidoFont = null;
        Font _IpponFont = null;
        Font _MainTimerFont = null;
        Font _OsaekomiTimerFont = null;
        Color _Player1Colour = Color.White;
        Color _Player1BGColour = Color.Blue;
        Color _Player2Colour = Color.Blue;
        Color _Player2BGColour = Color.White;
        Color _ShidoTextColor = Color.Red;
        Color _CategoryTextColor = Color.Black;
        Color _GoldenScoreTextColor = Color.Black;
        Color _IpponTextColor = Color.Black;
        Color _MainTimerTextColor = Color.LimeGreen;
        Color _IpponBGColor = Color.LimeGreen;

        StringAlignment _ScoreAlignment = _CenterAlignment;
        StringAlignment _WazaAriAlignment = _RightAlignment;
        StringAlignment _ShidoAlignment = _RightAlignment;

        int _Player1IpponCount = 0;
        int _Player1WazaAriCount = 0;
        int _Player1ShidoCount = 0;

        int _Player2IpponCount = 0;
        int _Player2WazaAriCount = 0;
        int _Player2ShidoCount = 0;

        int _MaxIpponCount = 1;
        int _MaxShidoCount = 3;
        int _MaxWazaAriCount = 2;

        string _IpponText = "     Ippon      ";
        string _WazaAriText = "    Waza Ari    ";
        string _ShidoText = "     Shido      ";


        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmScoreboard()
        {
            InitializeComponent();

            SetupFonts();

            pnlPlayer1.BackColor = _Player1Colour;
            pnlPlayer2.BackColor = _Player2Colour;

            _Server = new ClientServer.Server();



        }

        #endregion

        #region Event Handlers

        private void frmScoreboard_Load(object sender, EventArgs e)
        {

        }

        private void frmScoreboard_Resize(object sender, EventArgs e)
        {
            if (_Loaded)
            {
                Setup();
            }
        }

        private void frmScoreboard_Shown(object sender, EventArgs e)
        {
            _Loaded = true;

            Setup();

        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            _MainInterval = _MainInterval.Subtract(new TimeSpan(0, 0, 1));

            string MainTimerText = Convert.ToInt16(_MainInterval.Minutes).ToString().PadLeft(2, ' ') + ":" + Convert.ToInt16(_MainInterval.Seconds).ToString().PadLeft(2, '0'); // " 3:24";

            UpdateMainTimer(MainTimerText);
        }

        private void tmrSecondary_Tick(object sender, EventArgs e)
        {
            string OsaekomiTimerText = Convert.ToInt16(_SecondaryInterval.Minutes).ToString().PadLeft(2, ' ') + ":" + Convert.ToInt16(_SecondaryInterval.Seconds).ToString().PadLeft(2, '0'); // " 0:00";

            UpdateOsaekomiTimer(OsaekomiTimerText);
        }

        private void pnlMenu_MouseLeave(object sender, EventArgs e)
        {
            //btnConnect.Visible = false;
        }

        private void pnlMenu_MouseEnter(object sender, EventArgs e)
        {
            //btnConnect.Visible = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _ServerTask = _Server.Start("net.tcp://localhost/Mat/" + _MatNumber.ToString(), ClientServer.Server.ServiceType.Mat);
        }

        private void picPlayer1Score_Click(object sender, EventArgs e)
        {
            if (_Player1IpponCount < _MaxIpponCount && _Player2IpponCount < _MaxIpponCount)
            {
                AddPlayer1Ippon();
            }
        }

        private void picPlayer1WazaAri_Click(object sender, EventArgs e)
        {
            if (_Player1WazaAriCount < _MaxWazaAriCount && _Player1IpponCount < _MaxIpponCount && _Player2IpponCount < _MaxIpponCount)
            {
                AddPlayer1WazaAri();
            }
        }

        private void picPlayer1Shido_Click(object sender, EventArgs e)
        {
            if (_Player1ShidoCount < _MaxShidoCount && _Player1IpponCount < _MaxIpponCount && _Player2IpponCount < _MaxIpponCount)
            {
                AddPlayer1Shido();
            }
        }

        private void picPlayer2Score_Click(object sender, EventArgs e)
        {
            if (_Player1IpponCount < _MaxIpponCount && _Player2IpponCount < _MaxIpponCount)
            {
                AddPlayer2Ippon();
            }
        }

        private void picPlayer2WazaAri_Click(object sender, EventArgs e)
        {
            if (_Player2WazaAriCount < _MaxWazaAriCount && _Player1IpponCount < _MaxIpponCount && _Player2IpponCount < _MaxIpponCount)
            {
                AddPlayer2WazaAri();
            }
        }

        private void picPlayer2Shido_Click(object sender, EventArgs e)
        {
            if (_Player2ShidoCount < _MaxShidoCount && _Player1IpponCount < _MaxIpponCount && _Player2IpponCount < _MaxIpponCount)
            {
                AddPlayer2Shido();
            }
        }

        private void tmrPlayer1Score_Tick(object sender, EventArgs e)
        {
            UpdatePlayer1Score("");

            tmrPlayer1Score.Enabled = false;
        }

        private void tmrPlayer2Score_Tick(object sender, EventArgs e)
        {
            UpdatePlayer2Score("");

            tmrPlayer2Score.Enabled = false;
        }

        private void picMainTimer_Click(object sender, EventArgs e)
        {
            tmrMain.Enabled = !tmrMain.Enabled;
        }

        private void btnResetTimer_Click(object sender, EventArgs e)
        {
            SetupNewMatch();
        }

        #endregion

        #region Private Methods

        private void Setup()
        {


            SetupNewMatch();

            _MainInterval = new TimeSpan(0, 4, 0);  // 4 minutes
            _SecondaryInterval = new TimeSpan(0, 0, 0); // Zero - this one counts up

            string MainTimerText = Convert.ToInt16(_MainInterval.Minutes).ToString().PadLeft(2, ' ') + ":" + Convert.ToInt16(_MainInterval.Seconds).ToString().PadLeft(2, '0'); // " 3:24";
            string OsaekomiTimerText = Convert.ToInt16(_SecondaryInterval.Minutes).ToString().PadLeft(2, ' ') + ":" + Convert.ToInt16(_SecondaryInterval.Seconds).ToString().PadLeft(2, '0'); // " 0:00";

            UpdateMainTimer(MainTimerText);
            UpdateOsaekomiTimer(OsaekomiTimerText);
        }

        private void SetupFonts()
        {
            _CategoryNameFont = new System.Drawing.Font(this.Font.Name, 20, FontStyle.Regular, GraphicsUnit.Point);
            _CategoryDescriptionFont = new System.Drawing.Font(this.Font.Name, 10, FontStyle.Regular, GraphicsUnit.Point);
            _CategoryWeightFont = new System.Drawing.Font(this.Font.Name, 12, FontStyle.Regular, GraphicsUnit.Point);
            _PlayerSurnameFont = new System.Drawing.Font(this.Font.Name, 20, FontStyle.Regular, GraphicsUnit.Point);
            _ClubNameFont = new System.Drawing.Font(this.Font.Name, 12, FontStyle.Regular, GraphicsUnit.Point);
            _WazaAriFont = new System.Drawing.Font(this.Font.Name, 12, FontStyle.Regular, GraphicsUnit.Point);
            _ShidoFont = new System.Drawing.Font(this.Font.Name, 12, FontStyle.Regular, GraphicsUnit.Point);
            _IpponFont = new System.Drawing.Font(this.Font.Name, 12, FontStyle.Regular, GraphicsUnit.Point);
            _MainTimerFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Bold, GraphicsUnit.Point);
            _OsaekomiTimerFont = new System.Drawing.Font(this.Font.Name, 10, FontStyle.Regular, GraphicsUnit.Point);
        }

        //private void SetSurnames(string Player1Surname, string Player2Surname)
        //{
        //    picPlayer1Surname.Image = TextDrawing.DrawTextToBitmap(Player1Surname, _LeftAlignment, _PlayerSurnameFont, Color.Blue, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1Surname.Width, picPlayer1Surname.Height));
        //    picPlayer2Surname.Image = TextDrawing.DrawTextToBitmap(Player2Surname, _LeftAlignment, _PlayerSurnameFont, Color.White, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2Surname.Width, picPlayer2Surname.Height));
        //}

        //private void SetClubnames(string Player1ClubName, string Player2ClubName)
        //{
        //    picPlayer1ClubName.Image = TextDrawing.DrawTextToBitmap(Player1ClubName, _LeftAlignment, _ClubNameFont, Color.Blue, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picPlayer1ClubName.Width, picPlayer1ClubName.Height));
        //    picPlayer2ClubName.Image = TextDrawing.DrawTextToBitmap(Player2ClubName, _LeftAlignment, _ClubNameFont, Color.White, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picPlayer2ClubName.Width, picPlayer2ClubName.Height));
        //}

        //private void SetAllText(string CategoryName, string CategoryDescription, string CategoryWeight, bool SpecialNeeds, string Player1Surname, string Player2Surname, string Player1ClubNameText, string Player2ClubNameText, int Player1WazaAriCount, int Player2WazaAriCount, int Player1ShidoCount, int Player2ShidoCount, bool GoldenScore)
        //{
        //    picPlayer1Surname.Image = TextDrawing.DrawTextToBitmap(Player1Surname, _LeftAlignment, _PlayerSurnameFont, _Player1BGColour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1Surname.Width, picPlayer1Surname.Height));
        //    picPlayer2Surname.Image = TextDrawing.DrawTextToBitmap(Player2Surname, _LeftAlignment, _PlayerSurnameFont, _Player2BGColour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2Surname.Width, picPlayer2Surname.Height));

        //    picPlayer1ClubName.Image = TextDrawing.DrawTextToBitmap(Player1ClubNameText, _LeftAlignment, _ClubNameFont, _Player1BGColour, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picPlayer1ClubName.Width, picPlayer1ClubName.Height));
        //    picPlayer2ClubName.Image = TextDrawing.DrawTextToBitmap(Player2ClubNameText, _LeftAlignment, _ClubNameFont, _Player2BGColour, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picPlayer2ClubName.Width, picPlayer2ClubName.Height));

        //    picPlayer1WazaAri.Image = TextDrawing.DrawTextToBitmap(Player1WazaAriCount.ToString(), _LeftAlignment, _WazaAriFont, _Player1BGColour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1WazaAri.Width, picPlayer1WazaAri.Height));
        //    picPlayer2WazaAri.Image = TextDrawing.DrawTextToBitmap(Player2WazaAriCount.ToString(), _LeftAlignment, _WazaAriFont, _Player2BGColour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2WazaAri.Width, picPlayer2WazaAri.Height));

        //    picPlayer1Shido.Image = TextDrawing.DrawTextToBitmap(Player1ShidoCount.ToString(), _RightAlignment, _ShidoFont, _ShidoTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1Shido.Width, picPlayer1Shido.Height));
        //    picPlayer2Shido.Image = TextDrawing.DrawTextToBitmap(Player2ShidoCount.ToString(), _RightAlignment, _ShidoFont, _ShidoTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2Shido.Width, picPlayer2Shido.Height));

        //    picSpecialNeeds.Visible = SpecialNeeds;
        //    picCategoryName.Image = TextDrawing.DrawTextToBitmap(CategoryName, _CenterAlignment, _CategoryNameFont, _CategoryTextColor, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picCategoryName.Width, picCategoryName.Height));
        //    picCategoryDescription.Image = TextDrawing.DrawTextToBitmap(CategoryDescription, _CenterAlignment, _CategoryDescriptionFont, _CategoryTextColor, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picCategoryDescription.Width, picCategoryDescription.Height));
        //    picCategoryWeight.Image = TextDrawing.DrawTextToBitmap(CategoryWeight, _CenterAlignment, _CategoryWeightFont, _CategoryTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picCategoryWeight.Width, picCategoryWeight.Height));

        //    UpdatePlayer1Score("Shido");
        //    UpdatePlayer2Score("Shido");

        //    if (GoldenScore)
        //    {
        //        picGoldenScore.Visible = true;
        //        picGoldenScore.Image = TextDrawing.DrawTextToBitmap("Golden Score", _CenterAlignment, _CategoryWeightFont, Color.Black, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picGoldenScore.Width, picGoldenScore.Height));
        //    }
        //    else
        //    {
        //        picGoldenScore.Visible = false;
        //    }
        //}

        private void SetupNewMatch()
        {
            string CategoryName = "Master Women";
            string CategoryDescription = "(Special Needs) Half-Heavy Weight";
            string CategoryWeight = "<60Kg";

            _Player1IpponCount = 0;
            _Player1WazaAriCount = 0;
            _Player1ShidoCount = 0;

            _Player2IpponCount = 0;
            _Player2WazaAriCount = 0;
            _Player2ShidoCount = 0;

            SetCategory(CategoryName, CategoryDescription, CategoryWeight, true);
            AddPlayer1("Smith", "SouthWest Judo Academy");
            AddPlayer2("Bloggs", "Kano Judo Schools");

            ResetMainTimer();
            SetGoldenScore(false);

            tmrPlayer1Score.Interval = _ScoreInterval;
            tmrPlayer2Score.Interval = _ScoreInterval;

            UpdatePlayer1Score("");
            UpdatePlayer2Score("");

            picPlayer1Surname.BackColor = _Player2BGColour;
            picPlayer2Surname.BackColor = _Player1BGColour;
        }

        private void ResetMainTimer()
        {
            picPlayer1WazaAri.Image = TextDrawing.DrawTextToBitmap(_Player1WazaAriCount.ToString(), _WazaAriAlignment, _WazaAriFont, _Player1BGColour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1WazaAri.Width, picPlayer1WazaAri.Height));
            picPlayer2WazaAri.Image = TextDrawing.DrawTextToBitmap(_Player2WazaAriCount.ToString(), _WazaAriAlignment, _WazaAriFont, _Player2BGColour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2WazaAri.Width, picPlayer2WazaAri.Height));

            picPlayer1Shido.Image = TextDrawing.DrawTextToBitmap(_Player1ShidoCount.ToString(), _ShidoAlignment, _ShidoFont, _ShidoTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1Shido.Width, picPlayer1Shido.Height));
            picPlayer2Shido.Image = TextDrawing.DrawTextToBitmap(_Player2ShidoCount.ToString(), _ShidoAlignment, _ShidoFont, _ShidoTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2Shido.Width, picPlayer2Shido.Height));

        }

        private void UpdatePlayer1Score(string Player1ScoreText)
        {
            picPlayer1Score.Image = TextDrawing.DrawTextToBitmap(Player1ScoreText, _ScoreAlignment, _IpponFont, _IpponTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1Score.Width, picPlayer1Score.Height));
            picPlayer1WazaAri.Image = TextDrawing.DrawTextToBitmap(_Player1WazaAriCount.ToString(), _WazaAriAlignment, _WazaAriFont, _Player1BGColour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1WazaAri.Width, picPlayer1WazaAri.Height));
            picPlayer1Shido.Image = TextDrawing.DrawTextToBitmap(_Player1ShidoCount.ToString(), _ShidoAlignment, _ShidoFont, _ShidoTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1Shido.Width, picPlayer1Shido.Height));

            if (_Player1IpponCount > 0 || _Player1WazaAriCount > 0 || _Player1ShidoCount > 0)
            {
                tmrPlayer1Score.Stop();
                tmrPlayer1Score.Interval = _ScoreInterval;
                tmrPlayer1Score.Enabled = true;
            }
        }

        private void UpdatePlayer2Score(string Player2ScoreText)
        {
            picPlayer2Score.Image = TextDrawing.DrawTextToBitmap(Player2ScoreText, _ScoreAlignment, _IpponFont, _IpponTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2Score.Width, picPlayer2Score.Height));
            picPlayer2WazaAri.Image = TextDrawing.DrawTextToBitmap(_Player2WazaAriCount.ToString(), _WazaAriAlignment, _WazaAriFont, _Player2BGColour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2WazaAri.Width, picPlayer2WazaAri.Height));
            picPlayer2Shido.Image = TextDrawing.DrawTextToBitmap(_Player2ShidoCount.ToString(), _ShidoAlignment, _ShidoFont, _ShidoTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2Shido.Width, picPlayer2Shido.Height));

            if (_Player2IpponCount > 0 || _Player2WazaAriCount > 0 || _Player2ShidoCount > 0)
            {
                tmrPlayer2Score.Stop();
                tmrPlayer2Score.Interval = _ScoreInterval;
                tmrPlayer2Score.Enabled = true;
            }
        }

        private void UpdateMainTimer(string Text)
        {
            this.OnUIThread(() =>
            {
                picMainTimer.Image = TextDrawing.DrawTextToBitmap(Text, _CenterAlignment, _MainTimerFont, _MainTimerTextColor, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picMainTimer.Width, picMainTimer.Height));
            });

        }

        private void UpdateOsaekomiTimer(string Text)
        {
            this.OnUIThread(() =>
            {
                picOsaekomiText.Image = TextDrawing.DrawTextToBitmap("Osaekomi", _CenterAlignment, _OsaekomiTimerFont, Color.Blue, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picOsaekomiText.Width, picOsaekomiText.Height));
                picOsaekomiTimer.Image = TextDrawing.DrawTextToBitmap(Text, _CenterAlignment, _OsaekomiTimerFont, Color.Black, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picOsaekomiTimer.Width, picOsaekomiTimer.Height));
            });

        }

        private void AddPlayer1(string Player1Surname, string Player1ClubName)
        {
            picPlayer1Surname.Image = TextDrawing.DrawTextToBitmap(Player1Surname, _LeftAlignment, _PlayerSurnameFont, Color.Blue, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer1Surname.Width, picPlayer1Surname.Height));
            picPlayer1ClubName.Image = TextDrawing.DrawTextToBitmap(Player1ClubName, _LeftAlignment, _ClubNameFont, Color.Blue, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picPlayer1ClubName.Width, picPlayer1ClubName.Height));

        }

        private void AddPlayer2(string Player2Surname, string Player2ClubName)
        {
            picPlayer2Surname.Image = TextDrawing.DrawTextToBitmap(Player2Surname, _LeftAlignment, _PlayerSurnameFont, Color.White, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picPlayer2Surname.Width, picPlayer2Surname.Height));
            picPlayer2ClubName.Image = TextDrawing.DrawTextToBitmap(Player2ClubName, _LeftAlignment, _ClubNameFont, Color.White, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picPlayer2ClubName.Width, picPlayer2ClubName.Height));

        }

        private void SetCategory(string CategoryName, string CategoryDescription, string CategoryWeight, bool SpecialNeeds)
        {
            picSpecialNeeds.Visible = SpecialNeeds;
            picCategoryName.Image = TextDrawing.DrawTextToBitmap(CategoryName, _CenterAlignment, _CategoryNameFont, _CategoryTextColor, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picCategoryName.Width, picCategoryName.Height));
            picCategoryDescription.Image = TextDrawing.DrawTextToBitmap(CategoryDescription, _CenterAlignment, _CategoryDescriptionFont, _CategoryTextColor, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picCategoryDescription.Width, picCategoryDescription.Height));
            picCategoryWeight.Image = TextDrawing.DrawTextToBitmap(CategoryWeight, _CenterAlignment, _CategoryWeightFont, _CategoryTextColor, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, picCategoryWeight.Width, picCategoryWeight.Height));

        }

        private void SetGoldenScore(bool Enable)
        {
            if (Enable)
            {
                picGoldenScore.Visible = true;
                picGoldenScore.Image = TextDrawing.DrawTextToBitmap("Golden Score", _CenterAlignment, _CategoryWeightFont, _GoldenScoreTextColor, TextDrawing.DrawMethod.LargestWrap, new RectangleF(0, 0, picGoldenScore.Width, picGoldenScore.Height));
            }
            else
            {
                picGoldenScore.Visible = false;
            }
        }

        #endregion

        #region Public Methods

        public void AddPlayer1Ippon()
        {
            _Player1IpponCount++;
            UpdatePlayer1Score(_IpponText);

            if (_Player1IpponCount == _MaxIpponCount)
            {
                picPlayer1Surname.BackColor = _IpponBGColor;
                tmrPlayer1Score.Stop();
            }
        }

        public void AddPlayer1WazaAri()
        {
            _Player1WazaAriCount++;
            UpdatePlayer1Score(_WazaAriText);

            if (_Player1WazaAriCount == _MaxWazaAriCount)
            {
                AddPlayer1Ippon();
            }
        }

        public void AddPlayer1Shido()
        {
            _Player1ShidoCount++;
            UpdatePlayer1Score(_ShidoText);

            if (_Player1ShidoCount == _MaxShidoCount)
            {
                AddPlayer2Ippon();
            }
        }

        public void AddPlayer2Ippon()
        {
            _Player2IpponCount++;
            UpdatePlayer2Score(_IpponText);

            if (_Player2IpponCount == _MaxIpponCount)
            {
                picPlayer2Surname.BackColor = _IpponBGColor;
                tmrPlayer2Score.Stop();
            }
        }

        public void AddPlayer2WazaAri()
        {
            _Player2WazaAriCount++;
            UpdatePlayer2Score(_WazaAriText);

            if (_Player2WazaAriCount == _MaxWazaAriCount)
            {
                AddPlayer2Ippon();
            }
        }

        public void AddPlayer2Shido()
        {
            _Player2ShidoCount++;
            UpdatePlayer2Score(_ShidoText);

            if (_Player2ShidoCount == _MaxShidoCount)
            {
                AddPlayer1Ippon();
            }
        }


        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

        
    }
}
