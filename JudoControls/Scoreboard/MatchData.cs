
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Utilities;

using static Utilities.Enums;

namespace JudoControls.Scoreboard
{
    public partial class MatchData : UserControl
    {
        #region Fields

        private Enums.TimerState _OsaekomiTimerState = Enums.TimerState.Unknown;
        private Enums.HorizontalPosition _ProgressbarPosition = HorizontalPosition.Right;
        private Enums.TimerState _TimerState = Enums.TimerState.Unknown;

        #endregion

        #region Properties

        public string Category
        {
            get
            {
                return lblCategory.Text;
            }
            set
            {
                lblCategory.Text = value;
            }
        }

        public bool GoldenScore
        {
            get
            {
                return lblGoldenScore.Visible;
            }
            set
            {
                lblGoldenScore.Visible = value;
            }
        }

        public Enums.TimerState TimerState
        {
            get
            {
                return _TimerState;
            }
            set
            {
                _TimerState = value;

                switch (value)
                {
                    case Enums.TimerState.Unknown:
                        lblTimer.ForeColor = Color.Gray;
                        break;
                    case Enums.TimerState.Paused:
                        lblTimer.ForeColor = Color.OrangeRed;
                        break;
                    case Enums.TimerState.Running:
                        lblTimer.ForeColor = Color.Lime;
                        break;
                }
            }
        }

        public string OsaekomiTimer
        {
            get
            {
                return lblOsaekomiTimer.Text;
            }
            set
            {
                if (value != lblOsaekomiTimer.Text)
                {
                    lblOsaekomiTimer.Text = value;
                    lblOsaekomiTimer.Visible = value != "00";

                    pbrOsaekomi.Visible = lblOsaekomiTimer.Visible;
                    pbrOsaekomi.Value = Convert.ToInt32(value);

                    lblOsaekomiTimer.Refresh();
                }
            }
        }

        public Enums.TimerState OsaekomiTimerState
        {
            get
            {
                return _OsaekomiTimerState;
            }
            set
            {
                _OsaekomiTimerState = value;
            }
        }

        [Category("Appearance"), Description("Progressbar Position")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public HorizontalPosition ProgressbarPosition
        {
            get
            {
                return _ProgressbarPosition;
            }
            set
            {
                _ProgressbarPosition = value;

                SetProgressbarPosition(_ProgressbarPosition);
            }
        }

        public string Round
        {
            get
            {
                return lblRound.Text;
            }
            set
            {
                lblRound.Text = value;
            }
        }

        public string Timer
        {
            get
            {
                return lblTimer.Text;
            }
            set
            {
                if (value != lblTimer.Text)
                {
                    lblTimer.Text = value;

                    if (GoldenScore)
                    {
                        lblTimer.ForeColor = Color.OrangeRed;
                    }
                    else
                    {
                        lblTimer.ForeColor = Color.Lime;
                    }

                    lblTimer.Refresh();
                }
            }
        }

        #endregion

        #region Constructors

        public MatchData()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void SetProgressbarPosition(HorizontalPosition Alignment)
        {
            switch (Alignment)
            {
                case HorizontalPosition.Left:
                    break;
                case HorizontalPosition.Right:
                    break;
                case HorizontalPosition.None:
                    throw new NotSupportedException();
            }
        }

        #endregion

        #region Public Methods

        public void Clear()
        {
            lblRound.Text = "";
            lblCategory.Text = "";
            lblTimer.Text = "Clear";
            lblOsaekomiTimer.Text = "xx";
        }

        #endregion
    }
}
