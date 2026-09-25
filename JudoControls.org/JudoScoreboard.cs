using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Judo;

using Utilities;

using static Judo.Enums;
using static Utilities.Extensions;

namespace JudoControls
{
    public partial class JudoScoreboard : UserControl
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

        //private Font _CategoryNameFont = null;
        //private Font _CategoryDescriptionFont = null;
        //private Font _WeightFont = null;
        //private Font _PlayerSurnameFont = null;
        //private Font _NationNameFont = null;
        //private Font _WazaAriFont = null;
        //private Font _ShidoFont = null;
        //private Font _IpponFont = null;
        //private Font _MainTimerFont = null;
        //private Font _OsaekomiTimerFont = null;
        //private Color _Player1Colour = Color.White;
        //private Color _Player1BGColour = Color.RoyalBlue;
        //private Color _Player2Colour = Color.RoyalBlue;
        //private Color _Player2BGColour = Color.White;
        //private Color _ShidoTextColor = Color.Red;
        //private Color _CategoryTextColor = Color.Lime;
        //private Color _WeightTextColor = Color.Yellow;
        //private Color _GoldenScoreTextColor = Color.Gold;
        //private Color _IpponTextColor = Color.Black;
        //private Color _MainTimerTextColor1 = Color.Lime;
        //private Color _MainTimerTextColor2 = Color.OrangeRed;
        //private Color _IpponBGColor = Color.LimeGreen;
        private Match _PreviousMatchData = null;
        private InformationType _InfoType = InformationType.Player;

        #endregion

        #region Properties

        [Obsolete("Don't use yet")]
        [Category("Appearance"), Description("Information type to display")]
        [Browsable(true), DefaultValue(typeof(Enums.InformationType), "0")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual InformationType InfoType
        {
            get
            {
                return _InfoType;
            }

            set
            {
                if (InfoType != _InfoType)
                {
                    _InfoType = InfoType;

                    WhitePlayer.InfoType = InfoType;
                    BluePlayer.InfoType = InfoType;
                }
            }
        }

        #endregion

        #region Constructors and Destructor

        public JudoScoreboard()
        {
            InitializeComponent();

            //SetupFonts();
        }

        #endregion

        #region Event Handlers

        private void JudoScoreboard_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #endregion

        #region Private Methods

        //private void SetupFonts()
        //{
        //    //_CategoryNameFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //    //_CategoryDescriptionFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //    //_WeightFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //    //_PlayerSurnameFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //    //_NationNameFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //    ////_WazaAriFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //    ////_ShidoFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //    ////_IpponFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //    //_MainTimerFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Bold, GraphicsUnit.Point);
        //    //_OsaekomiTimerFont = new System.Drawing.Font(this.Font.Name, 40, FontStyle.Regular, GraphicsUnit.Point);
        //}

        //private void DrawText(string Text, StringAlignment Alignment, Font Font, Color Colour, PictureBox Picture)
        //{
        //    Picture.Image = TextDrawing.DrawTextToBitmap(Text, Alignment, Font, Colour, TextDrawing.DrawMethod.LargestNoWrap, new RectangleF(0, 0, Picture.Width, Picture.Height));
        //}

        //private void DrawText(string Text, StringAlignment Alignment, Font Font, Color Colour, LabelEx Label)
        //{
        //    Label.Text = Text;
        //}

        #endregion

        #region Public Methods

        public void Clear()
        {
            this.OnUIThread(() =>
            {
                //WhitePlayer.Clear();
                //BluePlayer.Clear();
                btnClose.Visible = false;
                lblMat.Image = null;

                //WhitePlayer.Clear();
                //BluePlayer.Clear();
                //MatchData.Clear();
                //picRound.Image = null;
                //picGoldenScore.Image = null;
                //picTimer.Image = null;
                //picCategory.Image = null;
                //picTimer.Image = null;
                //picOsaekomiTimer.Image = null;
                //pbrOsaekomi.Visible = false;

                tlpMain.Visible = false;
            });
        }

        public void Update(Match MatchData)
        {
            this.OnUIThread(() =>
            {
                btnClose.Visible = true;
                if (((int)MatchData.MatchState) > 1)
                {

                }


                //MatchData
                //if ((_PreviousMatchData == null) || (_PreviousMatchData.EventID != MatchData.EventID))
                //{
                lblMat.Text = MatchData.EventID + ": Mat " + MatchData.Mat.Number + ". " + MatchData.AgeGroup + " " + MatchData.Sex;
                //}

                //if ((_PreviousMatchData == null) || (_PreviousMatchData.WhitePerson.Name.Short != MatchData.WhitePerson.Name.Short))
                //{
                WhitePlayer.PlayerName = new Name(MatchData.WhitePerson.Name.First, MatchData.WhitePerson.Name.Last);
                WhitePlayer.PlayerNation = MatchData.WhitePerson.Nation;
                WhitePlayer.PlayerRank = MatchData.WhitePerson.Player.WRLPosition;

                WhitePlayer.PlayerNation.Flag = MatchData.WhitePerson.Nation.Flag;
                //}

                //if ((_PreviousMatchData == null) || (_PreviousMatchData.BluePerson.Name.Short != MatchData.BluePerson.Name.Short))
                //{
                BluePlayer.PlayerName = new Name(MatchData.BluePerson.Name.First, MatchData.BluePerson.Name.Last);
                BluePlayer.PlayerNation = MatchData.BluePerson.Nation;
                BluePlayer.PlayerRank = MatchData.BluePerson.Player.WRLPosition;

                BluePlayer.PlayerNation.Flag = MatchData.BluePerson.Nation.Flag;
                //}

                //if ((_PreviousMatchData == null) || (_PreviousMatchData.WhitePlayerScore != MatchData.WhitePlayerScore))
                //{
                WhitePlayer.PlayerScore = MatchData.WhitePlayerScore;

                WhitePlayer.PlayerScore.Ippon = MatchData.WhitePlayerScore.Ippon;
                BluePlayer.PlayerScore.Ippon = MatchData.BluePlayerScore.Ippon;

                //}

                //if ((_PreviousMatchData == null) || (_PreviousMatchData.BluePlayerScore != MatchData.BluePlayerScore))
                //{
                BluePlayer.PlayerScore = MatchData.BluePlayerScore;
                //}

                #region Name

                //DrawText(MatchData.WhitePerson.Name.Short, StringAlignment.Near, _PlayerSurnameFont, _Player2Colour, picWhiteName);

                //DrawText(MatchData.BluePerson.Name.Short, StringAlignment.Near, _PlayerSurnameFont, _Player1Colour, picBlueName);

                //#endregion

                //#region Penalty

                //if (MatchData.BluePlayerScore.Shido == 1)
                //{
                //    picWhiteShido.Image = Properties.Resources._1_Shido;
                //    picWhiteShido.Visible = true;
                //}
                //else if (MatchData.BluePlayerScore.Shido == 2)
                //{
                //    picWhiteShido.Image = Properties.Resources._2_Shido;
                //    picWhiteShido.Visible = true;
                //}
                //else if (MatchData.BluePlayerScore.HansokuMake)
                //{
                //    picWhiteShido.Image = Properties.Resources.Hansokumake;
                //    picWhiteShido.Visible = true;
                //}
                //else
                //{
                //    picWhiteShido.Visible = false;
                //}

                //if (MatchData.BluePlayerScore.Shido == 1)
                //{
                //    picBlueShido.Image = Properties.Resources._1_Shido;
                //    picBlueShido.Visible = true;
                //}
                //else if (MatchData.BluePlayerScore.Shido == 2)
                //{
                //    picBlueShido.Image = Properties.Resources._2_Shido;
                //    picBlueShido.Visible = true;
                //}
                //else if (MatchData.BluePlayerScore.HansokuMake)
                //{
                //    picBlueShido.Image = Properties.Resources.Hansokumake;
                //    picBlueShido.Visible = true;
                //}
                //else
                //{
                //    picBlueShido.Visible = false;
                //}

                //#endregion

                //#region Nation

                //if (MatchData.WhitePerson.Nation.ThreeLetterCode != "")
                //{
                //    White.PlayerNation.ThreeLetterCode = MatchData.WhitePerson.Nation.ThreeLetterCode;


                //    //if (MatchData.WhitePerson.Nation.Flag != null)
                //    //{
                //    //    lblWhiteFlag.BackgroundImage = MatchData.WhitePerson.Nation.Flag;
                //    //    lblWhiteFlag.Visible = true;
                //    //}
                //    //else
                //    //{
                //    //    lblWhiteFlag.Visible = false;
                //    //}
                //}

                //if (MatchData.BluePerson.Nation.ThreeLetterCode != "")
                //{
                //    Blue.PlayerNation.ThreeLetterCode = MatchData.BluePerson.Nation.ThreeLetterCode;
                //    //DrawText(MatchData.BluePerson.Nation.ThreeLetterCode, StringAlignment.Center, _NationNameFont, _Player1Colour, picBlueNationName);

                //    //if (MatchData.BluePerson.Nation.Flag != null)
                //    //{
                //    //    picBlueFlag.Image = MatchData.BluePerson.Nation.Flag;
                //    //    picBlueFlag.Visible = true;
                //    //}
                //    //else
                //    //{
                //    //    picBlueFlag.Visible = false;
                //    //}
                //}

                //#endregion

                //#region Score

                //if (MatchData.BluePlayerScore.Ippon > 0 || MatchData.BluePlayerScore.Ippon > 0)
                //{
                //    if (MatchData.BluePlayerScore.Ippon > 0)
                //    {
                //        if (MatchData.BluePlayerScore.HansokuMake)
                //        {
                //            DrawText("WINNER", StringAlignment.Center, _PlayerSurnameFont, _Player2Colour, picWhiteWinner);
                //            picBlueWinner.Image = null;
                //            picBlueScore.Image = null;
                //            picWhiteShido.Image = null;
                //        }
                //        else
                //        {
                //            DrawText("IPPON", StringAlignment.Center, _PlayerSurnameFont, _Player2Colour, picWhiteWinner);
                //            picBlueWinner.Image = null;
                //            picWhiteScore.Image = null;
                //        }

                //        picWhiteScore.Image = null;
                //    }

                //    if (MatchData.BluePlayerScore.Ippon > 0)
                //    {
                //        if (MatchData.BluePlayerScore.HansokuMake)
                //        {
                //            DrawText("WINNER", StringAlignment.Center, _PlayerSurnameFont, _Player1Colour, picBlueWinner);
                //            picWhiteWinner.Image = null;
                //            picWhiteScore.Image = null;
                //            picBlueShido.Image = null;
                //        }
                //        else
                //        {
                //            DrawText("IPPON", StringAlignment.Center, _PlayerSurnameFont, _Player1Colour, picBlueWinner);
                //            picWhiteWinner.Image = null;
                //            picBlueScore.Image = null;
                //        }

                //        picBlueScore.Image = null;
                //    }
                //}
                //else
                //{
                //    picWhiteWinner.Image = null;
                //    picBlueWinner.Image = null;

                //    DrawText(MatchData.BluePlayerScore.WazaAri.ToString(), StringAlignment.Center, _PlayerSurnameFont, _Player2Colour, picWhiteScore);
                //    DrawText(MatchData.BluePlayerScore.WazaAri.ToString(), StringAlignment.Center, _PlayerSurnameFont, _Player1Colour, picBlueScore);
                //}

                #endregion

                this.MatchData.Timer = MatchData.Timer.Minutes.ToString().PadLeft(2, ' ') + ":" + MatchData.Timer.Seconds.ToString().PadLeft(2, '0');
                this.MatchData.TimerState = MatchData.TimerState;
                this.MatchData.OsaekomiTimerState = MatchData.OsaekomiTimerState;
                this.MatchData.GoldenScore = MatchData.GoldenScore;

                //if ((_PreviousMatchData == null) || (_PreviousMatchData.EventID != MatchData.EventID))
                //{
                #region Timers



                //if (MatchData.TimerState == Enums.TimerState.Running)
                //{
                //    this.MatchData.Timer = MatchData.Timer.Minutes.ToString().PadLeft(2, ' ') + ":" + MatchData.Timer.Seconds.ToString().PadLeft(2, '0');
                //    //DrawText(MatchData.Timer.Minutes.ToString().PadLeft(2, ' ') + ":" + MatchData.Timer.Seconds.ToString().PadLeft(2, '0'), StringAlignment.Center, _MainTimerFont, _MainTimerTextColor1, picTimer);
                //}
                //else
                //{
                //    DrawText(MatchData.Timer.Minutes.ToString().PadLeft(2, ' ') + ":" + MatchData.Timer.Seconds.ToString().PadLeft(2, '0'), StringAlignment.Center, _MainTimerFont, _MainTimerTextColor2, picTimer);
                //}

                this.MatchData.OsaekomiTimer = MatchData.OsaekomiTimer.Seconds.ToString().PadLeft(2, '0');

                //if (MatchData.OsaekomiTimerState == Enums.TimerState.Running)
                //{
                //    if (MatchData.OsaekomiTimerPlayer == Match.PlayerColour.White)
                //    {
                //        if (MatchData.BluePlayerScore.WazaAri > 0)
                //        {
                //            pbrOsaekomi.Maximum = 20; // Should be 10;
                //            pbrOsaekomi.Value = MatchData.OsaekomiTimer.Seconds;
                //            pbrOsaekomi.Visible = true;
                //        }
                //        else
                //        {
                //            pbrOsaekomi.Maximum = 20;
                //            pbrOsaekomi.Value = MatchData.OsaekomiTimer.Seconds;
                //            pbrOsaekomi.Visible = true;
                //        }


                //        //DrawText(MatchData.OsaekomiTimer.Seconds.ToString(), StringAlignment.Center, _OsaekomiTimerFont, Color.White, picOsaekomiTimer);
                //    }
                //    else if (MatchData.OsaekomiTimerPlayer == Match.PlayerColour.Blue)
                //    {
                //        if (MatchData.BluePlayerScore.WazaAri > 0)
                //        {
                //            pbrOsaekomi.Maximum = 20; // Should be 10;
                //            pbrOsaekomi.Value = MatchData.OsaekomiTimer.Seconds;
                //            pbrOsaekomi.Visible = true;
                //        }
                //        else
                //        {
                //            pbrOsaekomi.Maximum = 20;
                //            pbrOsaekomi.Value = MatchData.OsaekomiTimer.Seconds;
                //            pbrOsaekomi.Visible = true;
                //        }

                //        DrawText(MatchData.OsaekomiTimer.Seconds.ToString().PadLeft(2, '0'), StringAlignment.Center, _OsaekomiTimerFont, Color.RoyalBlue, picOsaekomiTimer);
                //    }
                //}
                //else
                //{
                //    pbrOsaekomi.Value = 0;
                //    pbrOsaekomi.Visible = false;
                //    picOsaekomiTimer.Image = null;
                //}

                #endregion

                #region Golden Score



                //if (MatchData.GoldenScore)
                //{
                //    DrawText("GS", StringAlignment.Near, _CategoryNameFont, _GoldenScoreTextColor, picGoldenScore);
                //}
                //else
                //{
                //    picGoldenScore.Image = null;
                //}

                #endregion

                #region Round

                switch (MatchData.Round)
                {
                    case ScoreboardData.RoundEnum.RoundRobin:
                        this.MatchData.Round = "Round Robin";
                        //DrawText("Round Robin", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.Elimination1:
                        this.MatchData.Round = "Elimination Round 1";
                        //DrawText("Elimination Round 1", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.Elimination2:
                        this.MatchData.Round = "Elimination Round 2";
                        //DrawText("Elimination Round 2", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.Elimination3:
                        this.MatchData.Round = "Elimination Round 3";
                        //DrawText("Elimination Round 3", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.Elimination4:
                        this.MatchData.Round = "Elimination Round 4";
                        //DrawText("Elimination Round 4", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.QuarterFinal:
                        this.MatchData.Round = "Quarter Final";
                        //DrawText("Quarter Final", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.Repecharge:
                        this.MatchData.Round = "Repecharge";
                        //DrawText("Repecharge", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.SemiFinal:
                        this.MatchData.Round = "Semi Final";
                        //DrawText("Semi Final", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.Bronze:
                        this.MatchData.Round = "Bronze";
                        //DrawText("Bronze", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                    case ScoreboardData.RoundEnum.Final:
                        this.MatchData.Round = "Final";
                        //DrawText("Final", StringAlignment.Center, _CategoryNameFont, _CategoryTextColor, picRound);
                        break;
                }


                #endregion

                #region Weight

                this.MatchData.Category = MatchData.Category + " kg";
                //DrawText(MatchData.Category + " kg", StringAlignment.Center, _WeightFont, _WeightTextColor, picCategory);

                #endregion

                //}

                _PreviousMatchData = MatchData;

                tlpMain.Visible = true;
            });
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion


    }
}
