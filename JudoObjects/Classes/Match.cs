using System;

using static Classes.Enums;

namespace Classes
{
    public class Match : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "勝負";
        //public const string JAPANESETYPENAME = "Shiai";
        //public const string ENGLISHTYPENAME = "Match";

        #endregion

        #region Delegates

        public delegate void MatchStateChangedHandler(MatchState CurrentState, MatchState NewState, object Sender);
        public delegate void MatchConnectionStateHandler(ConnectionState CurrentState, ConnectionState NewState, object Sender);
        //public delegate void MatchFinishedHandler(object Sender);
        public delegate void MatchScoreChangedHandler(object Sender);

        #endregion

        #region Events

        public event MatchStateChangedHandler MatchStateChanged;
        public event MatchConnectionStateHandler MatchConnectionStateChanged;
        //public event MatchFinishedHandler MatchCompleted;
        public event MatchScoreChangedHandler MatchScoreChanged;

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private Guid _Identifier = Guid.Empty;
        private TimeSpan _ActualDuration = TimeSpan.Zero;
        private Belt _Player1Belt = null;
        private Score _Player1Score = null;
        private Weight _Player1Weight = null;
        private Belt _Player2Belt = null;
        private Score _Player2Score = null;
        private Weight _Player2Weight = null;
        private Person _BlueBelt = null;
        private DateTime _Date = DateTime.MinValue;
        private Division _Division = null;
        private bool _FinalResult = false;
        private bool _goldenPoint = false;
        private Person _person1 = null;
        private Person _person2 = null;
        private Mat _mat = null;
        private TimeSpan _maximumDuration = TimeSpan.Zero;
        private Enums.MatchResult _result = Enums.MatchResult.Unknown;
        private Person _whiteBelt = null;
        private Person _winner = null;
        private Enums.MatchState _state = Enums.MatchState.Unconfigured;
        private System.Collections.Generic.ICollection<ResultCorrectionRequest> _ResultCorrectionRequests = new System.Collections.Generic.List<ResultCorrectionRequest>();

        #endregion

        #region Properties

        public Guid Identifier
        {
            get
            {
                return _Identifier = Guid.Empty;
            }
            set
            {
                _Identifier = value;
            }
        }

        public Person Person1
        {
            get
            {
                return _person1;
            }
            set
            {
                _person1 = value;
            }
        }

        public Person Person2
        {
            get
            {
                return _person2;
            }
            set
            {
                _person2 = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }

        public Belt Player1Belt
        {
            get
            {
                return _Player1Belt;
            }
            set
            {
                _Player1Belt = value;
            }
        }

        public Belt Player2Belt
        {
            get
            {
                return _Player2Belt;
            }
            set
            {
                _Player2Belt = value;
            }
        }

        public Division Division
        {
            get
            {
                return _Division;
            }
            set
            {
                _Division = value;
            }
        }

        public TimeSpan MaximumDuration
        {
            get
            {
                return _maximumDuration;
            }
            set
            {
                _maximumDuration = value;
            }
        }

        public TimeSpan ActualDuration
        {
            get
            {
                return _ActualDuration;
            }
            set
            {
                _ActualDuration = value;
            }
        }

        public Enums.MatchResult Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        public Person Winner
        {
            get
            {
                return _winner;
            }
            set
            {
                _winner = value;
            }
        }

        public Score Player1Score
        {
            get
            {
                return _Player1Score;
            }
            set
            {
                _Player1Score = value;
            }
        }

        public Score Player2Score
        {
            get
            {
                return _Player2Score;
            }
            set
            {
                _Player2Score = value;
            }
        }

        public Weight Person1Weight
        {
            get
            {
                return _Player1Weight;
            }
            set
            {
                _Player1Weight = value;
            }
        }

        public Weight Person2Weight
        {
            get
            {
                return _Player2Weight;
            }
            set
            {
                _Player2Weight = value;
            }
        }

        public Person WhiteBelt
        {
            get
            {
                return _whiteBelt;
            }
            set
            {
                _whiteBelt = value;
            }
        }

        public Person BlueBelt
        {
            get
            {
                return _BlueBelt;
            }
            set
            {
                _BlueBelt = value;
            }
        }

        public bool GoldenPoint
        {
            get
            {
                return _goldenPoint;
            }
            set
            {
                _goldenPoint = value;
            }
        }

        public Mat Mat
        {
            get
            {
                return _mat;
            }
            set
            {
                _mat = value;
            }
        }

        public Enums.MatchState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        /// <summary>
        /// Collection of result correction requests for this match.
        /// </summary>
        public System.Collections.Generic.ICollection<ResultCorrectionRequest> ResultCorrectionRequests
        {
            get
            {
                return _ResultCorrectionRequests;
            }
            set
            {
                _ResultCorrectionRequests = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Match()
        {
        }

        public Match(Person WhiteBeltPerson, Person BlueBeltPerson, TimeSpan Duration, Mat Mat, Division Division)
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = null;

            _person1 = WhiteBeltPerson;
            _Player1Belt = WhiteBeltPerson.Player.Rank.Belt;
            _Player1Weight = WhiteBeltPerson.Player.Weight;
            _Player1Score = new Score();

            _person2 = BlueBeltPerson;
            _Player2Belt = BlueBeltPerson.Player.Rank.Belt;
            _Player2Weight = BlueBeltPerson.Player.Weight;
            _Player2Score = new Score();

            _maximumDuration = Duration;

            _whiteBelt = WhiteBeltPerson;
            _BlueBelt = BlueBeltPerson;

            _Date = DateTime.Now;

            _Division = Division;
            _mat = Mat;

            WireUpEventHandlers();
        }

        #endregion

        #region Event Handlers

        private void _Player1Score_IpponAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_IpponRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_WazaAriAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_WazaAriRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_YukoAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_YukoRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_HansokuMakeAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_HansokuMakeRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_ShidoAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player1Score_ShidoRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_IpponAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_IpponRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_WazaAriAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_WazaAriRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_YukoAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_YukoRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_HansokuMakeAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_HansokuMakeRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_ShidoAdded(object Sender)
        {
            CalculateResult();
        }

        private void _Player2Score_ShidoRemoved(object Sender)
        {
            CalculateResult();
        }

        #endregion

        #region Private Methods

        private void CalculateResult()
        {
            Score Player1StartScore = _Player1Score;
            Score Player1EndScore = Player1StartScore;

            Score Player2StartScore = _Player2Score;
            Score Player2EndScore = Player2StartScore;

            #region Hansoku Make

            if (Player1StartScore.HansokuMake.Count > 0)
            {
                Player2EndScore.Ippon.Clear();
                Player2EndScore.Ippon.Add(1);
            }

            if (Player2StartScore.HansokuMake.Count > 0)
            {
                Player1EndScore.Ippon.Clear();
                Player1EndScore.Ippon.Add(1);
            }

            #endregion

            if ((Player1StartScore != Player1EndScore) || (Player2StartScore != Player2EndScore))
            {
                RaiseMatchScoreChanged();
            }
        }

        private void WireUpEventHandlers()
        {
            _Player1Score.IpponAdded += _Player1Score_IpponAdded;
            _Player1Score.IpponRemoved += _Player1Score_IpponRemoved;
            _Player1Score.WazaAriAdded += _Player1Score_WazaAriAdded;
            _Player1Score.WazaAriRemoved += _Player1Score_WazaAriRemoved;
            _Player1Score.YukoAdded += _Player1Score_YukoAdded;
            _Player1Score.YukoRemoved += _Player1Score_YukoRemoved;
            _Player1Score.HansokuMakeAdded += _Player1Score_HansokuMakeAdded;
            _Player1Score.HansokuMakeRemoved += _Player1Score_HansokuMakeRemoved;
            _Player1Score.ShidoAdded += _Player1Score_ShidoAdded;
            _Player1Score.ShidoRemoved += _Player1Score_ShidoRemoved;

            _Player2Score.IpponAdded += _Player2Score_IpponAdded;
            _Player2Score.IpponRemoved += _Player2Score_IpponRemoved;
            _Player2Score.WazaAriAdded += _Player2Score_WazaAriAdded;
            _Player2Score.WazaAriRemoved += _Player2Score_WazaAriRemoved;
            _Player2Score.YukoAdded += _Player2Score_YukoAdded;
            _Player2Score.YukoRemoved += _Player2Score_YukoRemoved;
            _Player2Score.HansokuMakeAdded += _Player2Score_HansokuMakeAdded;
            _Player2Score.HansokuMakeRemoved += _Player2Score_HansokuMakeRemoved;
            _Player2Score.ShidoAdded += _Player2Score_ShidoAdded;
            _Player2Score.ShidoRemoved += _Player2Score_ShidoRemoved;
        }

        #endregion

        #region Public Methods

        public void Start()
        {
            _FinalResult = false;

            RaiseMatchStateChanged(MatchState.Starting);
            // Do stuff
            RaiseMatchStateChanged(MatchState.Started);
        }

        public void Stop()
        {
            _FinalResult = false;
            CalculateResult();

            RaiseMatchStateChanged(MatchState.Finishing);
            // Check scores
            RaiseMatchStateChanged(MatchState.Finished);
        }

        public void Pause()
        {
            RaiseMatchStateChanged(MatchState.Paused);
        }

        public void Continue()
        {
            RaiseMatchStateChanged(MatchState.Started);
        }

        public void Complete()
        {
            _FinalResult = true;
            CalculateResult();

            RaiseMatchStateChanged(MatchState.Finished);
        }

        public virtual void RaiseMatchStateChanged(MatchState NewState)
        {
            MatchStateChangedHandler Raiser = MatchStateChanged;

            if (Raiser != null)
            {
                Raiser(_state, NewState, this);
            }
        }

        //public virtual void RaiseMatchStopped()
        //{
        //	MatchStoppedHandler Raiser = MatchStopped;

        //	if (Raiser != null)
        //	{
        //		Raiser(this);
        //	}
        //}

        //public virtual void RaiseMatchCompleted()
        //{
        //	MatchFinishedHandler Raiser = MatchCompleted;

        //	if (Raiser != null)
        //	{
        //		Raiser(this);
        //	}
        //}

        public virtual void RaiseMatchScoreChanged()
        {
            MatchScoreChangedHandler Raiser = MatchScoreChanged;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        #endregion



    }
}
