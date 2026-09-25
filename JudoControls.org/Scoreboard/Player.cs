using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Judo;

using static Judo.Enums;

namespace JudoControls
{
    public partial class Player : UserControl
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
        //private Bitmap _NationOrClubFlag = null;
        //private string _NationOrClubName = "";
        private Name _PlayerName = null;
        private string _MatchInfo = "";
        private Score _PlayerScore = new Score(0, 0, 0, false);
        private Enums.PlayerColors _PlayerColor = Enums.PlayerColors.None;
        private int _PlayerRank = 0;
        private InformationType _InfoType = InformationType.Player;

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

        [Category("Appearance"), Description("Player's Colour")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PlayerColors PlayerColor
        {
            get
            {
                return _PlayerColor;
            }
            set
            {
                _PlayerColor = value;

                SetColour(_PlayerColor);
            }
        }

        //[Category("Appearance"), Description("Nation's or Club's Name")]
        //[Browsable(true)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public string NationOrClubName
        //{
        //    get
        //    {
        //        return _NationOrClubName;
        //    }

        //    set
        //    {
        //        _NationOrClubName = value;
        //        lblNationName.Text = _NationOrClubName;
        //        Refresh();
        //    }
        //}

        [Category("Appearance"), Description("Player's Nation")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Nation PlayerNation
        {
            get
            {
                return _PlayerNation;
            }

            set
            {
                if (_PlayerNation != value)
                {
                    _PlayerNation = value;

                    switch (PlayerColor)
                    {
                        case PlayerColors.White:
                            if (PlayerNation != null)
                            {
                                lblWhiteNationName.Text = _PlayerNation.ThreeLetterCode;
                                lblWhiteFlag.Image = _PlayerNation.Flag;
                            }
                            else
                            {
                                lblWhiteNationName.Text = "";
                                lblWhiteFlag.Image = null;
                            }
                            break;
                        case PlayerColors.Blue:
                            if (PlayerNation != null)
                            {
                                lblBlueNationName.Text = _PlayerNation.ThreeLetterCode;
                                lblBlueFlag.Image = _PlayerNation.Flag;
                            }
                            else
                            {
                                lblBlueNationName.Text = "";
                                lblBlueFlag.Image = null;
                            }
                            break;
                        case PlayerColors.None:
                            lblWhiteNationName.Text = string.Empty;
                            lblWhiteFlag.Image = null;
                            lblBlueNationName.Text = string.Empty;
                            lblBlueFlag.Image = null;
                            break;
                    }

                    Refresh();
                }
            }
        }

        [Category("Appearance"), Description("Player's Name")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Name PlayerName
        {
            get
            {
                return _PlayerName;
            }

            set
            {
                if (_PlayerName != value)
                {
                    _PlayerName = value;

                    switch (PlayerColor)
                    {
                        case PlayerColors.White:
                            if (_PlayerName != null)
                            {
                                lblWhitePlayerName.Text = _PlayerName.Short;
                            }
                            else
                            {
                                lblWhitePlayerName.Text = "";
                            }
                            break;
                        case PlayerColors.Blue:
                            if (_PlayerName != null)
                            {
                                lblBluePlayerName.Text = _PlayerName.Short;
                            }
                            else
                            {
                                lblBluePlayerName.Text = "";
                            }
                            break;
                        case PlayerColors.None:
                            lblWhitePlayerName.Text = null;
                            lblBluePlayerName.Text = null;
                            break;
                    }

                    Refresh();
                }
            }
        }

        [Category("Appearance"), Description("Match Info text")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual string MatchInfo
        {
            get
            {
                return _MatchInfo;
            }

            set
            {
                _MatchInfo = value.ToUpper();

                switch (PlayerColor)
                {
                    case PlayerColors.White:
                        lblWhiteInfo.Text = _MatchInfo;
                        break;
                    case PlayerColors.Blue:
                        lblBlueInfo.Text = _MatchInfo;
                        break;
                    case PlayerColors.None:
                        lblWhiteInfo.Text = null;
                        lblBlueInfo.Text = null;
                        break;
                }

                Refresh();
            }
        }

        [Category("Appearance"), Description("Player Score")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Score PlayerScore
        {
            get
            {
                return _PlayerScore;
            }

            set
            {
                _PlayerScore = value;

                if (_PlayerScore.HansokuMake)
                {
                    _PlayerScore.PenaltyImage = Properties.Resources.Hansokumake;
                }
                else
                {
                    switch (_PlayerScore.Shido)
                    {
                        case 0:
                            _PlayerScore.PenaltyImage = null;
                            break;
                        case 1:
                            _PlayerScore.PenaltyImage = Properties.Resources._1_Shido;
                            break;
                        case 2:
                            _PlayerScore.PenaltyImage = Properties.Resources._2_Shido;
                            break;
                        case 3:
                            _PlayerScore.PenaltyImage = Properties.Resources.Hansokumake;
                            break;
                    }
                }

                //PlayerScore.PenaltyImage = null;
                switch (PlayerColor)
                {
                    case PlayerColors.White:
                        {
                            if (_PlayerScore.Ippon > 0)
                            {
                                lblWhiteScore.Text = $"{_PlayerScore.Ippon} {_PlayerScore.WazaAri}";
                            }
                            else
                            {
                                lblWhiteScore.Text = _PlayerScore.WazaAri.ToString();
                            }

                            picWhitePenalty.Image = PlayerScore.PenaltyImage;
                            break;
                        }
                    case PlayerColors.Blue:
                        {
                            if (_PlayerScore.Ippon > 0)
                            {
                                lblBlueScore.Text = $"{_PlayerScore.Ippon} {_PlayerScore.WazaAri}";
                            }
                            else
                            {
                                lblBlueScore.Text = _PlayerScore.WazaAri.ToString();
                            }
                            lblBlueScore.Text = _PlayerScore.WazaAri.ToString();
                            picBluePenalty.Image = PlayerScore.PenaltyImage;
                            break;
                        }
                    case PlayerColors.None:
                        {
                            lblWhiteScore.Text = null;
                            lblBlueScore.Text = null;
                            picWhitePenalty.Image = null;
                            picBluePenalty.Image = null;
                            break;
                        }
                }

                Refresh();
            }
        }

        [Category("Appearance"), Description("Player Ranking")]
        [Browsable(true), DefaultValue(typeof(int), "0")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual int PlayerRank
        {
            get
            {
                return _PlayerRank;
            }

            set
            {
                _PlayerRank = value;

                switch (PlayerColor)
                {
                    case PlayerColors.White:
                        lblWhiteRank.Text = value.ToString();

                        if (_PlayerRank == 0)
                        {
                            lblWhiteRank.Visible = false;
                        }
                        else
                        {
                            lblWhiteRank.Visible = true;
                        }
                        break;
                    case PlayerColors.Blue:
                        lblBlueRank.Text = value.ToString();

                        if (_PlayerRank == 0)
                        {
                            lblBlueRank.Visible = false;
                        }
                        else
                        {
                            lblBlueRank.Visible = true;
                        }
                        break;
                    case PlayerColors.None:
                        lblWhiteRank.Text = null;
                        lblBlueRank.Text = null;

                        lblWhiteRank.Visible = false;
                        lblBlueRank.Visible = false;

                        break;
                }



                Refresh();
            }
        }

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

                    switch (InfoType)
                    {
                        case InformationType.Player:
                            lblWhiteNationName.Visible = true;
                            lblBlueNationName.Visible = true;
                            break;
                        case InformationType.Nation:
                            lblWhiteNationName.Visible = false;
                            lblBlueNationName.Visible = false;
                            break;
                    }
                }
            }
        }

        #endregion

        #region Constructor and Destructor

        public Player()
        {
            InitializeComponent();
        }

        public Player(Judo.Enums.PlayerColors Colour)
        {
            InitializeComponent();

            _PlayerColor = Colour;

            SetColour(_PlayerColor);
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        private void SetColour(PlayerColors Colour)
        {
            switch (Colour)
            {
                case Enums.PlayerColors.White:
                    tlpWhiteMain.ForeColor = System.Drawing.Color.Black;
                    lblWhiteNationName.ForeColor = System.Drawing.Color.Black;
                    tlpWhiteMain.Location = new Point(0, 0);
                    tlpWhiteMain.Visible = true;
                    tlpBlueMain.Visible = false;
                    tlpWhiteMain.Dock = DockStyle.Fill;
                    tlpBlueMain.Dock = DockStyle.None;
                    break;
                case Enums.PlayerColors.Blue:
                    tlpBlueMain.ForeColor = System.Drawing.Color.Cornsilk;
                    lblBlueNationName.ForeColor = System.Drawing.Color.Cornsilk;
                    tlpBlueMain.Location = new Point(0, 0);
                    tlpBlueMain.Visible = true;
                    tlpWhiteMain.Visible = false;
                    tlpWhiteMain.Dock = DockStyle.None;
                    tlpBlueMain.Dock = DockStyle.Fill;
                    break;
                default:
                    //BackColor = Color.Transparent;
                    tlpWhiteMain.Visible = false;
                    tlpBlueMain.Visible = false;
                    tlpWhiteMain.Dock = DockStyle.None;
                    tlpBlueMain.Dock = DockStyle.None;
                    break;
            }
        }

        #endregion

        #region Public Methods

        public void Clear()
        {
            lblWhiteFlag.BackgroundImage = null;
            lblWhiteNationName.Text = "";
            lblWhitePlayerName.Text = "";
            lblWhiteInfo.Text = "";
            //lblWhitePenalty.Text = "";
            picWhitePenalty.Image = null;
            lblWhiteScore.Text = "";
            lblWhiteRank.Text = "";

            lblBlueFlag.BackgroundImage = null;
            lblBlueNationName.Text = "";
            lblBluePlayerName.Text = "";
            lblBlueInfo.Text = "";
            //lblBluePenalty.Text = "";
            picBluePenalty.Image = null;
            lblBlueScore.Text = "";
            lblBlueRank.Text = "";

            _PlayerNation = null;
            _PlayerName = null;
            _MatchInfo = "";
            _PlayerScore = new Score(0, 0, 0, false);
            _PlayerRank = 0;
            _PlayerColor = PlayerColors.None;

            SetColour(_PlayerColor);

            lblWhiteInfo.BackColor = Color.Transparent;
            lblWhiteNationName.BackColor = Color.Transparent;
            //lblWhitePenalty.BackColor = Color.Transparent;
            lblWhitePlayerName.BackColor = Color.Transparent;
            lblWhiteScore.BackColor = Color.Transparent;
            lblWhiteFlag.BackColor = Color.Transparent;
            lblWhiteRank.BackColor = Color.Transparent;

            lblBlueInfo.BackColor = Color.Transparent;
            lblBlueNationName.BackColor = Color.Transparent;
            //lblBluePenalty.BackColor = Color.Transparent;
            lblBluePlayerName.BackColor = Color.Transparent;
            lblBlueScore.BackColor = Color.Transparent;
            lblBlueFlag.BackColor = Color.Transparent;
            lblBlueRank.BackColor = Color.Transparent;
        }

        #endregion

        #region Classes

        // By convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
