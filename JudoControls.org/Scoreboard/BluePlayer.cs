using Judo;

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace JudoControls.Scoreboard
{
    public partial class BluePlayer : Player
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

        private Nation _PlayerNation = null;
        //private Club _Club = null;
        private Bitmap _NationOrClubFlag = null;
        private string _NationOrClubName = "";
        private Name _PlayerName = null;
        private string _MatchInfo = "";
        private Score _PlayerScore = new Score(0, 0, 0, false);
        private Enums.PlayerColors _PlayerColor = Enums.PlayerColors.Blue;
        private int _PlayerRank = 0;

        #endregion

        #region Properties

        #region Hidden properties

        [Browsable(false)]
        public override Color BackColor
        {
            set
            {
            }
        }

        [Browsable(false)]
        public override Image BackgroundImage
        {
            set
            {
            }
        }

        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            set
            {
            }
        }

        #endregion

        [Category("Appearance"), Description("Blue Player's Nation")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Nation PlayerNation
        {
            get
            {
                return base.PlayerNation;
            }

            set
            {
                base.PlayerNation = value;

                if (base.PlayerNation != null)
                {
                    lblBlueNationName.Text = base.PlayerNation.ThreeLetterCode;
                    lblBlueFlag.BackgroundImage = base.PlayerNation.Flag;

                }
                else
                {
                    lblBlueNationName.Text = "";
                    lblBlueFlag.BackgroundImage = null;
                }

                Refresh();
            }
        }

        [Category("Appearance"), Description("Blue Player's Name")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Name PlayerName
        {
            get
            {
                return base.PlayerName;
            }

            set
            {
                base.PlayerName = value;

                if (base.PlayerName != null)
                {
                    lblBluePlayerName.Text = base.PlayerName.Short;
                }
                else
                {
                    lblBluePlayerName.Text = "";
                }

                Refresh();
            }
        }

        [Category("Appearance"), Description("Match Info text")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string MatchInfo
        {
            get
            {
                return base.MatchInfo;
            }

            set
            {
                base.MatchInfo = value.ToUpper();
                lblBlueInfo.Text = base.MatchInfo;
                Refresh();
            }
        }

        [Category("Appearance"), Description("Blue Player Score")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Score PlayerScore
        {
            get
            {
                return base.PlayerScore;
            }

            set
            {
                base.PlayerScore = value;

                if (base.PlayerScore != null)
                {
                    lblBlueScore.Text = base.PlayerScore.WazaAri.ToString();
                }
                else
                {
                    lblBlueScore.Text = "";
                }

                lblBluePenalty.BackgroundImage = base.PlayerScore.PenaltyImage;

                Refresh();
            }
        }

        [Category("Appearance"), Description("Player Ranking")]
        [Browsable(true), DefaultValue(typeof(int), "0")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override int PlayerRank
        {
            get
            {
                return base.PlayerRank;
            }

            set
            {
                base.PlayerRank = value;

                if (value > 0)
                {
                    lblBlueRank.Text = value.ToString();
                }
                else
                {
                    lblBlueRank.Text = "";
                }

                this.Invalidate(true);
                Refresh();
            }
        }

        #endregion

        #region Constructor and Destructor

        public BluePlayer() : base(Enums.PlayerColors.Blue)
        {
            InitializeComponent();

            lblBlueScore.ForeColor = Color.Cornsilk;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        //public void Clear()
        //{
        //    lblBlueFlag.BackgroundImage = null;
        //    lblBlueNationName.Text = "";
        //    lblBluePlayerName.Text = "";
        //    lblBlueInfo.Text = "";
        //    lblBluePenalty.Text = "";
        //    lblBlueScore.Text = "";
        //    lblBlueRank.Text = "";

        //    base.PlayerNation = null;
        //    base.PlayerName = null;
        //    base.MatchInfo = "";
        //    base.PlayerScore = new Score(0, 0, 0, false);
        //    base.PlayerRank = 0;

        //    lblBlueInfo.BackColor = Color.Transparent;
        //    lblBlueNationName.BackColor = Color.Transparent;
        //    lblBluePenalty.BackColor = Color.Transparent;
        //    lblBluePlayerName.BackColor = Color.Transparent;
        //    lblBlueScore.BackColor = Color.Transparent;
        //    lblBlueFlag.BackColor = Color.Transparent;
        //    lblBlueRank.BackColor = Color.Transparent;
        //}

        #endregion

        #region Classes

        // By convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
