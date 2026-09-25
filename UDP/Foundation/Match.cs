using static Utilities.Enums;
using static Utilities.ScoreboardData;
using System;
//using static Judo.ScoreboardData;
using Utilities;

namespace Judo
{
    public class Match
    {
        #region Enums

        public enum PlayerColour : int
        {
            Unknown = -1,
            White = 0,
            Blue = 1
        }

        #endregion

        public delegate void MatchConnectionStateHandler(ConnectionState CurrentState, ConnectionState NewState, object Sender);

        public delegate void MatchFinishedHandler(object Sender);

        public delegate void MatchScoreChangedHandler(object Sender);

        public delegate void MatchStateChangedHandler(MatchState CurrentState, MatchState NewState, object Sender);

        #region Events

        //public event MatchConnectionStateHandler MatchConnectionStateChanged;
        //public event MatchFinishedHandler MatchCompleted;
        public event MatchScoreChangedHandler MatchScoreChanged;

        public event MatchStateChangedHandler MatchStateChanged;

        #endregion

        #region Fields

        private TimeSpan _ActualDuration = TimeSpan.Zero;
        private string _AgeGroup = "";
        private Person _BluePerson = new Person();
        private Belt _BluePlayerBelt = null;       // Stored for historical record-keeping
        private Score _BluePlayerScore = null;
        private Weight _BluePlayerWeight = null;   // Stored for historical record-keeping
        private string _Category = "";
        private DateTime _Date = DateTime.MinValue;
        private string _EventID = "";

        //private bool _FinalResult = false;
        private bool _GoldenScore = false;
        private Guid _Identifier = Guid.Empty;
        private Mat _Mat = null;
        private MatchState _MatchState = MatchState.Unconfigured;
        private TimeSpan _MaximumDuration = TimeSpan.Zero;
        private TimeSpan _OsaekomiTimer = TimeSpan.Zero;
        private PlayerColour _OsaekomiTimerPlayer = PlayerColour.Unknown;
        private TimerState _OsaekomiTimerState = TimerState.Unknown;
        private MatchResult _Result = MatchResult.Unknown;
        private RoundEnum _Round = RoundEnum.RoundRobin;
        private string _Sex = "";
        private TimeSpan _Timer = TimeSpan.Zero;
        private TimerState _TimerState = TimerState.Unknown;
        private Person _WhitePerson = new Person();
        private Belt _WhitePlayerBelt = null;       // Stored for historical record-keeping
        private Score _WhitePlayerScore = null;
        private Weight _WhitePlayerWeight = null;   // Stored for historical record-keeping
        private Person _Winner = null;

        #endregion

        #region Properties

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

        public string AgeGroup
        {
            get
            {
                return _AgeGroup;
            }
            set
            {
                _AgeGroup = value;
            }
        }

        public Person BluePerson
        {
            get
            {
                return _BluePerson;
            }
            set
            {
                _BluePerson = value;
            }
        }

        [Obsolete("Stored for historical record-keeping")]
        public Belt BluePlayerBelt
        {
            get
            {
                return _BluePlayerBelt;
            }
            set
            {
                _BluePlayerBelt = value;
            }
        }

        public Score BluePlayerScore
        {
            get
            {
                return _BluePlayerScore;
            }
            set
            {
                _BluePlayerScore = value;
            }
        }

        [Obsolete("Stored for historical record-keeping")]
        public Weight BluePlayerWeight
        {
            get
            {
                return _BluePlayerWeight;
            }
            set
            {
                _BluePlayerWeight = value;
            }
        }

        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
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

        public string EventID
        {
            get
            {
                return _EventID;
            }
            set
            {
                _EventID = value;
            }
        }

        public bool GoldenScore
        {
            get
            {
                return _GoldenScore;
            }
            set
            {
                _GoldenScore = value;
            }
        }

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

        public Mat Mat
        {
            get
            {
                return _Mat;
            }
            set
            {
                _Mat = value;
            }
        }

        public MatchState MatchState
        {
            get
            {
                return _MatchState;
            }
            set
            {
                _MatchState = value;
            }
        }

        public TimeSpan MaximumDuration
        {
            get
            {
                return _MaximumDuration;
            }
            set
            {
                _MaximumDuration = value;
            }
        }

        public TimeSpan OsaekomiTimer
        {
            get
            {
                return _OsaekomiTimer;
            }
            set
            {
                _OsaekomiTimer = value;
            }
        }

        public PlayerColour OsaekomiTimerPlayer
        {
            get
            {
                return _OsaekomiTimerPlayer;
            }
            set
            {
                _OsaekomiTimerPlayer = value;
            }
        }

        public TimerState OsaekomiTimerState
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

        public MatchResult Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
            }
        }

        public RoundEnum Round
        {
            get
            {
                return _Round;
            }
            set
            {
                _Round = value;
            }
        }

        public string Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }

        public TimeSpan Timer
        {
            get
            {
                return _Timer;
            }
            set
            {
                _Timer = value;
            }
        }

        public TimerState TimerState
        {
            get
            {
                return _TimerState;
            }
            set
            {
                _TimerState = value;
            }
        }

        public Person WhitePerson
        {
            get
            {
                return _WhitePerson;
            }
            set
            {
                _WhitePerson = value;
            }
        }

        [Obsolete("Stored for historical record-keeping")]
        public Belt WhitePlayerBelt
        {
            get
            {
                return _WhitePlayerBelt;
            }
            set
            {
                _WhitePlayerBelt = value;
            }
        }

        public Score WhitePlayerScore
        {
            get
            {
                return _WhitePlayerScore;
            }
            set
            {
                _WhitePlayerScore = value;
            }
        }

        [Obsolete("Stored for historical record-keeping")]
        public Weight WhitePlayerWeight
        {
            get
            {
                return _WhitePlayerWeight;
            }
            set
            {
                _WhitePlayerWeight = value;
            }
        }

        public Person Winner
        {
            get
            {
                return _Winner;
            }
            set
            {
                _Winner = value;
            }
        }

        #endregion

        #region Constructors

        public Match(Person WhiteBeltPerson, Person BlueBeltPerson, TimeSpan Duration, Mat Mat, RoundEnum Round)
        {
            _WhitePerson = WhiteBeltPerson;
            //_WhitePlayerBelt = WhiteBeltPerson.Player.Value.Rank.Belt;// Stored for historical record-keeping
            _WhitePlayerBelt = WhiteBeltPerson.Player.Rank.Belt;// Stored for historical record-keeping
            //_WhitePlayerWeight = WhiteBeltPerson.Player.Value.Weight; // Stored for historical record-keeping
            _WhitePlayerWeight = WhiteBeltPerson.Player.Weight; // Stored for historical record-keeping
            _WhitePlayerScore = new Score();

            _BluePerson = BlueBeltPerson;
            //_BluePlayerBelt = BlueBeltPerson.Player.Value.Rank.Belt;// Stored for historical record-keeping
            _BluePlayerBelt = BlueBeltPerson.Player.Rank.Belt;// Stored for historical record-keeping
            //_BluePlayerWeight = BlueBeltPerson.Player.Value.Weight; // Stored for historical record-keeping
            _BluePlayerWeight = BlueBeltPerson.Player.Weight; // Stored for historical record-keeping
            _BluePlayerScore = new Score();

            _MaximumDuration = Duration;

            _Date = DateTime.UtcNow;

            _Round = Round;
            _Mat = Mat;

            WireUpEventHandlers();
        }

        public Match(ScoreboardData Data)
        {
            _Mat = new Mat();

            _EventID = Data.EventID;
            _Mat.Number = Data.MatID;
            _Timer = Data.Timer;
            _Sex = Data.Gender;
            _AgeGroup = Data.AgeGroup;

            Sex MatchSex;
            if (Data.Gender == "Mens")
            {
                MatchSex = Enums.Sex.Male;
            }
            else
            {
                MatchSex = Enums.Sex.Female;
            }

            WhitePerson = new Person(new Name(Data.LongNameWhite), MatchSex);
            BluePerson = new Person(new Name(Data.LongNameBlue), MatchSex);

            WhitePerson.Nation = new Nation(Data.NationWhite);
            BluePerson.Nation = new Nation(Data.NationBlue);

            _WhitePlayerScore = new Score(Data.IpponWhite, Data.WazaAriWhite, Data.ShidoWhite, Data.YukoWhite, Data.HansokuMakeWhite);
            _BluePlayerScore = new Score(Data.IpponBlue, Data.WazaAriBlue, Data.ShidoBlue, Data.YukoBlue, Data.HansokuMakeBlue);
            _GoldenScore = Data.GoldenScore;

            if (Data.TimerOsaekomiWhite != "00")
            {
                _OsaekomiTimer = new TimeSpan(0, 0, Convert.ToInt32(Data.TimerOsaekomiWhite));
                _OsaekomiTimerState = TimerState.Running;
                _OsaekomiTimerPlayer = PlayerColour.White;
            }
            else if (Data.TimerOsaekomiBlue != "00")
            {
                _OsaekomiTimer = new TimeSpan(0, 0, Convert.ToInt32(Data.TimerOsaekomiBlue));
                _OsaekomiTimerState = TimerState.Running;
                _OsaekomiTimerPlayer = PlayerColour.Blue;
            }
            else
            {
                _OsaekomiTimer = new TimeSpan();
                _OsaekomiTimerState = TimerState.Paused;
                _OsaekomiTimerPlayer = PlayerColour.Unknown;
            }

            switch (Data.Round)
            {
                case "Round Robin":
                    _Round = RoundEnum.RoundRobin;
                    break;
                case "Elimination Round 1":
                    _Round = RoundEnum.Elimination1;
                    break;
                case "Elimination Round 2":
                    _Round = RoundEnum.Elimination2;
                    break;
                case "Elimination Round 3":
                    _Round = RoundEnum.Elimination3;
                    break;
                case "Elimination Round 4":
                    _Round = RoundEnum.Elimination4;
                    break;
                case "Quarter Final":
                    _Round = RoundEnum.QuarterFinal;
                    break;
                case "Repecharge":
                    _Round = RoundEnum.Repecharge;
                    break;
                case "Semi Final":
                    _Round = RoundEnum.SemiFinal;
                    break;
                case "Bronze":
                    _Round = RoundEnum.Bronze;
                    break;
                case "Final":
                    _Round = RoundEnum.Final;
                    break;
            }

            _Category = Data.Category.Replace("k", "").Trim();
        }

        #endregion

        public static bool operator !=(Match x, Match y)
        {
            return !(x == y);
        }

        public static bool operator ==(Match x, Match y)
        {
            if (x is null)
            {
                if (y is null)
                {
                    return true;
                }

                return false;
            }

            return x.Equals(y);
        }

        #region Private Methods

        private void CalculateResult()
        {
            Score WhitePlayerStartScore = _WhitePlayerScore;
            Score WhitePlayerEndScore = WhitePlayerStartScore;

            Score BluePlayerStartScore = _BluePlayerScore;
            Score BluePlayerEndScore = BluePlayerStartScore;

            #region Hansoku Make

            if (WhitePlayerStartScore.HansokuMake && BluePlayerStartScore.HansokuMake)  // Cater for both players receiving Hansoku make
            {
                BluePlayerEndScore.Ippon = 0;
                WhitePlayerEndScore.Ippon = 0;
            }
            else if (WhitePlayerStartScore.HansokuMake)
            {
                BluePlayerEndScore.Ippon = 1;
            }
            else if (BluePlayerStartScore.HansokuMake)
            {
                WhitePlayerEndScore.Ippon = 1;
            }

            #endregion

            if ((WhitePlayerStartScore != WhitePlayerEndScore) || (BluePlayerStartScore != BluePlayerEndScore))
            {
                RaiseMatchScoreChanged();
            }
        }

        private void WireUpEventHandlers()
        {
            _WhitePlayerScore.IpponAdded += _WhitePlayerScore_IpponAdded;
            _WhitePlayerScore.IpponRemoved += _WhitePlayerScore_IpponRemoved;
            _WhitePlayerScore.WazaAriAdded += _WhitePlayerScore_WazaAriAdded;
            _WhitePlayerScore.WazaAriRemoved += _WhitePlayerScore_WazaAriRemoved;
            _WhitePlayerScore.YukoAdded += _WhitePlayerScore_YukoAdded;
            _WhitePlayerScore.YukoRemoved += _WhitePlayerScore_YukoRemoved;
            _WhitePlayerScore.HansokuMakeAdded += _WhitePlayerScore_HansokuMakeAdded;
            _WhitePlayerScore.HansokuMakeRemoved += _WhitePlayerScore_HansokuMakeRemoved;
            _WhitePlayerScore.ShidoAdded += _WhitePlayerScore_ShidoAdded;
            _WhitePlayerScore.ShidoRemoved += _WhitePlayerScore_ShidoRemoved;

            _BluePlayerScore.IpponAdded += _BluePlayerScore_IpponAdded;
            _BluePlayerScore.IpponRemoved += _BluePlayerScore_IpponRemoved;
            _BluePlayerScore.WazaAriAdded += _BluePlayerScore_WazaAriAdded;
            _BluePlayerScore.WazaAriRemoved += _BluePlayerScore_WazaAriRemoved;
            _BluePlayerScore.YukoAdded += _WhitePlayerScore_YukoAdded;
            _BluePlayerScore.YukoRemoved += _WhitePlayerScore_YukoRemoved;
            _BluePlayerScore.HansokuMakeAdded += _BluePlayerScore_HansokuMakeAdded;
            _BluePlayerScore.HansokuMakeRemoved += _BluePlayerScore_HansokuMakeRemoved;
            _BluePlayerScore.ShidoAdded += _BluePlayerScore_ShidoAdded;
            _BluePlayerScore.ShidoRemoved += _BluePlayerScore_ShidoRemoved;
        }

        private void _BluePlayerScore_HansokuMakeAdded(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_HansokuMakeRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_IpponAdded(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_IpponRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_ShidoAdded(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_ShidoRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_WazaAriAdded(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_WazaAriRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_YukoAdded(object Sender)
        {
            CalculateResult();
        }

        private void _BluePlayerScore_YukoRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_HansokuMakeAdded(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_HansokuMakeRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_IpponAdded(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_IpponRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_ShidoAdded(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_ShidoRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_WazaAriAdded(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_WazaAriRemoved(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_YukoAdded(object Sender)
        {
            CalculateResult();
        }

        private void _WhitePlayerScore_YukoRemoved(object Sender)
        {
            CalculateResult();
        }

        #endregion

        #region Public Methods

        public void Complete()
        {
            //_FinalResult = true;
            CalculateResult();

            RaiseMatchStateChanged(MatchState.Completed);
        }

        public void Continue()
        {
            RaiseMatchStateChanged(MatchState.Playing);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Match)
            {
                return false;
            }

            Match other = obj as Match;

            if (_EventID != other.EventID || _Mat != other.Mat)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Pause()
        {
            RaiseMatchStateChanged(MatchState.Paused);
        }

        public virtual void RaiseMatchScoreChanged()
        {
            MatchScoreChanged?.Invoke(this);
        }

        public virtual void RaiseMatchStateChanged(MatchState NewState)
        {
            MatchStateChanged?.Invoke(_MatchState, NewState, this);
        }

        public void Start()
        {
            //_FinalResult = false;

            RaiseMatchStateChanged(MatchState.Starting);
            // Do stuff
            RaiseMatchStateChanged(MatchState.Playing);
        }

        public void Stop()
        {
            //_FinalResult = false;
            CalculateResult();

            RaiseMatchStateChanged(MatchState.Completing);
            // Check scores
            RaiseMatchStateChanged(MatchState.Completed);
        }

        #endregion
    }
}
