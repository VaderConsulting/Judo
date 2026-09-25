using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Judo.Enums;

namespace JudoControls.Scoreboard
{
    public partial class MatchData : UserControl
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

        private Judo.Enums.TimerState _TimerState = Judo.Enums.TimerState.Unknown;
        private Judo.Enums.TimerState _OsaekomiTimerState = Judo.Enums.TimerState.Unknown;
        private Judo.Enums.HorizontalPosition _ProgressbarPosition = HorizontalPosition.Right;

        #endregion

        #region Properties

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

                    lblOsaekomiTimer.Refresh();
                }
            }
        }

        public Judo.Enums.TimerState TimerState
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
                    case Judo.Enums.TimerState.Unknown:
                        lblTimer.ForeColor = Color.Gray;
                        break;
                    case Judo.Enums.TimerState.Paused:
                        lblTimer.ForeColor = Color.OrangeRed;
                        break;
                    case Judo.Enums.TimerState.Running:
                        lblTimer.ForeColor = Color.Lime;
                        break;
                }
            }
        }

        public Judo.Enums.TimerState OsaekomiTimerState
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

        

        #endregion

        #region Constructors and Destructor

        public MatchData()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

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

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion
    }
}
