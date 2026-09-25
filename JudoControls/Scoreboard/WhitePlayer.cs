using Judo;

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Utilities;

namespace JudoControls.Scoreboard
{
    public partial class WhitePlayer : Players
    {


        #region Events

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
        private Score _PlayerScore = new Score(0, 0, 0, 0, false);
        private Enums.PlayerColors _PlayerColor = Enums.PlayerColors.White;
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

        [Category("Appearance"), Description("White Player's Nation")]
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
                    lblWhiteNationName.Text = base.PlayerNation.ThreeLetterCode;
                    lblWhiteFlag.BackgroundImage = base.PlayerNation.Flag;
                }
                else
                {
                    lblWhiteNationName.Text = "";
                    lblWhiteFlag.BackgroundImage = null;
                }

                Refresh();
            }
        }

        [Category("Appearance"), Description("White Player's Name")]
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
                    lblWhitePlayerName.Text = base.PlayerName.Short;
                }
                else
                {
                    lblWhitePlayerName.Text = "";
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
                lblWhiteInfo.Text = base.MatchInfo;
                Refresh();
            }
        }

        [Category("Appearance"), Description("White Player Score")]
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
                    lblWhiteScore.Text = base.PlayerScore.WazaAri.ToString();
                }
                else
                {
                    lblWhiteScore.Text = "";
                }

                lblWhitePenalty.BackgroundImage = base.PlayerScore.PenaltyImage;

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
                    lblWhiteRank.Text = value.ToString();
                }
                else
                {
                    lblWhiteRank.Text = "";
                }

                this.Invalidate(true);
                Refresh();
            }
        }

        #endregion

        #region Constructor and Destructor

        public WhitePlayer() : base(Enums.PlayerColors.White)
        {
            InitializeComponent();

            lblWhiteScore.ForeColor = Color.Black;
        }

        #endregion


        #region Private Methods

        #endregion

        #region Public Methods

        //public void Clear()
        //{
        //    lblWhiteFlag.BackgroundImage = null;
        //    lblWhiteNationName.Text = "";
        //    lblWhitePlayerName.Text = "";
        //    lblWhiteInfo.Text = "";
        //    lblWhitePenalty.Text = "";
        //    lblWhiteScore.Text = "";
        //    lblWhiteRank.Text = "";

        //    base.PlayerNation = null;
        //    base.PlayerName = null;
        //    base.MatchInfo = "";
        //    base.PlayerScore = new Score(0, 0, 0, false);
        //    base.PlayerRank = 0;

        //    lblWhiteInfo.BackColor = Color.Transparent;
        //    lblWhiteNationName.BackColor = Color.Transparent;
        //    lblWhitePenalty.BackColor = Color.Transparent;
        //    lblWhitePlayerName.BackColor = Color.Transparent;
        //    lblWhiteScore.BackColor = Color.Transparent;
        //    lblWhiteFlag.BackColor = Color.Transparent;
        //    lblWhiteRank.BackColor = Color.Transparent;
        //}

        #endregion

        #region Classes

        // By convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
