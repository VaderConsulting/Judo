using System;

using Utilities;

namespace Judo
{
    public class ScoreboardData
    {
        #region Constants

        private const int ProtocolLength = 216;

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        //public enum GenderEnum : int
        //{
        //    Womens,
        //    Mens
        //}

        public enum AgeGroupEnum : int
        {
            Cadet,
            Junior,
            Senior
        }

        public enum RoundEnum : int
        {
            RoundRobin,
            Elimination1,
            Elimination2,
            Elimination3,
            Elimination4,
            QuarterFinal,
            Repecharge,
            SemiFinal,
            Bronze,
            Final
        }

        public enum DisplayModeEnum : int
        {
            Logo,
            ContestInfo,
            WhiteInfo,
            BlueInfo,
            BothInfo,
            Scoreboard,
            Countdown,
            LastCall
        }

        public enum TimerFlagEnum : int
        {
            Stopped,
            Running
        }

        public enum OsaekomiTimerFlagEnum : int
        {
            Stopped,
            White,
            Blue
        }

        public enum WinnerEnum : int
        {
            None,
            White,
            Blue
        }

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        // Note that start and end can be transposed - the Segment class works it out
        private Segment _StartTokenSegment = new Segment(0);
        private Segment _ProtocolVersionSegment = new Segment(1, 3);
        private Segment _EventIDSegment = new Segment(4, 23);
        private Segment _GenderSegment = new Segment(24);
        private Segment _CategorySegment = new Segment(25, 28);
        private Segment _AgeGroupSegment = new Segment(29);
        private Segment _RoundSegment = new Segment(30);
        private Segment _ContestIDSegment = new Segment(31, 33);
        private Segment _TimerFlagSegment = new Segment(34);
        private Segment _TimerMinuteSegment = new Segment(35);
        private Segment _TimerSecondSegment = new Segment(36, 37);
        private Segment _NationWhiteSegment = new Segment(40, 38);
        private Segment _IDWhiteSegment = new Segment(55, 41);
        private Segment _ShortNameWhiteSegment = new Segment(59, 56);
        private Segment _WorldRankingListPositionWhiteSegment = new Segment(62, 60);
        private Segment _LongNameWhiteSegment = new Segment(92, 63);
        private Segment _IpponWhiteSegment = new Segment(93);
        private Segment _YukoWhiteSegment = new Segment(94);
        private Segment _WazaAriWhiteSegment = new Segment(95);
        private Segment _ShidoWhiteSegment = new Segment(96);
        private Segment _TimerOsaekomiWhiteSegment = new Segment(97, 98);
        private Segment _TeamScoreWhiteSegment = new Segment(99);
        private Segment _NationBlueSegment = new Segment(100, 102);
        private Segment _IDBlueSegment = new Segment(103, 117);
        private Segment _ShortNameBlueSegment = new Segment(118, 121);
        private Segment _WorldRankingListPositionBlueSegment = new Segment(122, 124);
        private Segment _LongNameBlueSegment = new Segment(125, 154);
        private Segment _IpponBlueSegment = new Segment(155);
        private Segment _YukoBlueSegment = new Segment(156);
        private Segment _WazaAriBlueSegment = new Segment(157);
        private Segment _ShidoBlueSegment = new Segment(158);
        private Segment _TimerOsaekomiBlueSegment = new Segment(159, 160);
        private Segment _TeamScoreBlueSegment = new Segment(161);
        private Segment _GoldenScoreSegment = new Segment(162);
        private Segment _WinnerSegment = new Segment(163);
        private Segment _IDRefereeSegment = new Segment(164, 178);
        private Segment _IDJudge1Segment = new Segment(179, 193);
        private Segment _IDJudge2Segment = new Segment(194, 208);
        private Segment _IDMatSegment = new Segment(209);
        private Segment _DisplayModeSegment = new Segment(210);
        private Segment _OsaekomiTimerFlagSegment = new Segment(211);
        private Segment _NotUsedSegment = new Segment(212, 214);
        private Segment _EndTokenSegment = new Segment(215);

        private byte[] _Data = null;

        #endregion

        #region Properties

        private string StartToken
        {
            get
            {
                //byte[] Bytes = new byte[_StartTokenSegment.Length];
                //Array.Copy(_Data, _StartTokenSegment.StartPosition, Bytes, 0, _StartTokenSegment.Length);

                //return System.Text.Encoding.Default.GetString(Bytes);

                return _Data[_StartTokenSegment.StartPosition].ToString();
            }
        }

        private string ProtocolVersion
        {
            get
            {
                return _Data.ToText(_ProtocolVersionSegment.StartPosition, _ProtocolVersionSegment.Length);
            }
        }

        public string EventID
        {
            get
            {
                return _Data.ToText(_EventIDSegment.StartPosition, _EventIDSegment.Length);
            }
        }

        public string Gender
        {
            get
            {
                return FromGender(_Data.ToText(_GenderSegment.StartPosition, _GenderSegment.Length));
            }
        }

        public string Gender_Raw
        {
            get
            {
                return _Data.ToText(_GenderSegment.StartPosition, _GenderSegment.Length);
            }
        }

        public string Category
        {
            get
            {
                return _Data.ToText(_CategorySegment.StartPosition, _CategorySegment.Length);
            }
        }

        public string AgeGroup
        {
            get
            {
                return FromAgeGroup(_Data.ToText(_AgeGroupSegment.StartPosition, _AgeGroupSegment.Length));
            }
        }

        public string AgeGroup_Raw
        {
            get
            {
                return _Data.ToText(_AgeGroupSegment.StartPosition, _AgeGroupSegment.Length);
            }
        }

        public string Round
        {
            get
            {
                return FromRound(_Data.ToText(_RoundSegment.StartPosition, _RoundSegment.Length));
            }
        }

        public string Round_Raw
        {
            get
            {
                return _Data.ToText(_RoundSegment.StartPosition, _RoundSegment.Length);
            }
        }

        public string ContestID
        {
            get
            {
                return _Data.ToText(_ContestIDSegment.StartPosition, _ContestIDSegment.Length);
            }
        }

        public string TimerFlag
        {
            get
            {
                return FromTimerFlag(_Data.ToText(_TimerFlagSegment.StartPosition, _TimerFlagSegment.Length));
            }
        }

        public string OsaekomiTimerFlag
        {
            get
            {
                return FromOsaekomiTimerFlag(_Data.ToText(_OsaekomiTimerFlagSegment.StartPosition, _OsaekomiTimerFlagSegment.Length));
            }
        }

        public Enums.TimerState TimerState
        {
            get
            {
                switch (FromTimerFlag(_Data.ToText(_TimerFlagSegment.StartPosition, _TimerFlagSegment.Length)))
                {
                    case "Stopped":
                        return Enums.TimerState.Paused;
                    //break;
                    case "Running":
                        return Enums.TimerState.Running;
                    //break;
                    default:
                        return Enums.TimerState.Unknown;
                }
            }
        }

        public string TimerFlag_Raw
        {
            get
            {
                return _Data.ToText(_TimerFlagSegment.StartPosition, _TimerFlagSegment.Length);
            }
        }

        public string TimerMinute
        {
            get
            {
                return _Data.ToText(_TimerMinuteSegment.StartPosition, _TimerMinuteSegment.Length);
            }
        }

        public string TimerSecond
        {
            get
            {
                return _Data.ToText(_TimerSecondSegment.StartPosition, _TimerSecondSegment.Length);
            }
        }

        public TimeSpan Timer
        {
            get
            {
                return new TimeSpan(0, Convert.ToInt32(TimerMinute), Convert.ToInt32(TimerSecond));
            }
        }

        public string NationWhite
        {
            get
            {
                return _Data.ToText(_NationWhiteSegment.StartPosition, _NationWhiteSegment.Length);
            }
        }

        public string IDWhite
        {
            get
            {
                return _Data.ToText(_IDWhiteSegment.StartPosition, _IDWhiteSegment.Length);
            }
        }

        public string ShortNameWhite
        {
            get
            {
                return _Data.ToText(_ShortNameWhiteSegment.StartPosition, _ShortNameWhiteSegment.Length);
            }
        }

        public string WorldRankingListPositionWhite
        {
            get
            {
                return _Data.ToText(_WorldRankingListPositionWhiteSegment.StartPosition, _WorldRankingListPositionWhiteSegment.Length);
            }
        }

        public string LongNameWhite
        {
            get
            {
                return _Data.ToText(_LongNameWhiteSegment.StartPosition, _LongNameWhiteSegment.Length);
            }
        }

        public int IpponWhite
        {
            get
            {
                return Convert.ToInt32(_Data.ToText(_IpponWhiteSegment.StartPosition, _IpponWhiteSegment.Length));
            }
        }

        public int WazaAriWhite
        {
            get
            {
                return Convert.ToInt32(_Data.ToText(_WazaAriWhiteSegment.StartPosition, _WazaAriWhiteSegment.Length));
            }
        }

        private int YukoWhite
        {
            get
            {
                return Convert.ToInt32(_Data.ToText(_YukoWhiteSegment.StartPosition, _YukoWhiteSegment.Length));
            }
        }

        public int ShidoWhite
        {
            get
            {
                string Shido = FromShido(_Data.ToText(_ShidoWhiteSegment.StartPosition, _ShidoWhiteSegment.Length));

                if (Shido != "Hansoku make")
                {
                    return Convert.ToInt32(Shido);
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool HansokuMakeWhite
        {
            get
            {
                string Shido = FromShido(_Data.ToText(_ShidoWhiteSegment.StartPosition, _ShidoWhiteSegment.Length));

                if (Shido == "3")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ShidoWhite_Raw
        {
            get
            {
                return _Data.ToText(_ShidoWhiteSegment.StartPosition, _ShidoWhiteSegment.Length);
            }
        }

        public string TimerOsaekomiWhite
        {
            get
            {
                return _Data.ToText(_TimerOsaekomiWhiteSegment.StartPosition, _TimerOsaekomiWhiteSegment.Length);
            }
        }

        public string TeamScoreWhite
        {
            get
            {
                return _Data.ToText(_TeamScoreWhiteSegment.StartPosition, _TeamScoreWhiteSegment.Length);
            }
        }

        public string NationBlue
        {
            get
            {
                return _Data.ToText(_NationBlueSegment.StartPosition, _NationBlueSegment.Length);
            }
        }

        public string IDBlue
        {
            get
            {
                return _Data.ToText(_IDBlueSegment.StartPosition, _IDBlueSegment.Length);
            }
        }

        public string ShortNameBlue
        {
            get
            {
                return _Data.ToText(_ShortNameBlueSegment.StartPosition, _ShortNameBlueSegment.Length);
            }
        }

        public string WorldRankingListPositionBlue
        {
            get
            {
                return _Data.ToText(_WorldRankingListPositionBlueSegment.StartPosition, _WorldRankingListPositionBlueSegment.Length);
            }
        }

        public string LongNameBlue
        {
            get
            {
                return _Data.ToText(_LongNameBlueSegment.StartPosition, _LongNameBlueSegment.Length);
            }
        }

        public int IpponBlue
        {
            get
            {
                return Convert.ToInt32(_Data.ToText(_IpponBlueSegment.StartPosition, _IpponBlueSegment.Length));
            }
        }

        public int WazaAriBlue
        {
            get
            {
                return Convert.ToInt32(_Data.ToText(_WazaAriBlueSegment.StartPosition, _WazaAriBlueSegment.Length));
            }
        }

        private int YukoBlue
        {
            get
            {
                return Convert.ToInt32(_Data.ToText(_YukoBlueSegment.StartPosition, _YukoBlueSegment.Length));
            }
        }

        public int ShidoBlue
        {
            get
            {
                string Shido = FromShido(_Data.ToText(_ShidoBlueSegment.StartPosition, _ShidoBlueSegment.Length));

                if (Shido != "Hansoku make")
                {
                    return Convert.ToInt32(Shido);
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool HansokuMakeBlue
        {
            get
            {
                string Shido = FromShido(_Data.ToText(_ShidoBlueSegment.StartPosition, _ShidoBlueSegment.Length));

                if (Shido == "3")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ShidoBlue_Raw
        {
            get
            {
                return _Data.ToText(_ShidoBlueSegment.StartPosition, _ShidoBlueSegment.Length);
            }
        }

        public string TimerOsaekomiBlue
        {
            get
            {
                return _Data.ToText(_TimerOsaekomiBlueSegment.StartPosition, _TimerOsaekomiBlueSegment.Length);
            }
        }

        public string TeamScoreBlue
        {
            get
            {
                return _Data.ToText(_TeamScoreBlueSegment.StartPosition, _TeamScoreBlueSegment.Length);
            }
        }

        public bool GoldenScore
        {
            get
            {
                return _Data.ToText(_GoldenScoreSegment.StartPosition, _GoldenScoreSegment.Length) == "1";
            }
        }

        public string GoldenScore_Raw
        {
            get
            {
                return _Data.ToText(_GoldenScoreSegment.StartPosition, _GoldenScoreSegment.Length);
            }
        }

        public string Winner
        {
            get
            {
                return FromWinner(_Data.ToText(_WinnerSegment.StartPosition, _WinnerSegment.Length));
            }
        }

        public string Winner_Raw
        {
            get
            {
                return _Data.ToText(_WinnerSegment.StartPosition, _WinnerSegment.Length);
            }
        }

        public string RefereeID
        {
            get
            {
                return _Data.ToText(_IDRefereeSegment.StartPosition, _IDRefereeSegment.Length);
            }
        }

        public string IDJudge1
        {
            get
            {
                return _Data.ToText(_IDJudge1Segment.StartPosition, _IDJudge1Segment.Length);
            }
        }

        public string IDJudge2
        {
            get
            {
                return _Data.ToText(_IDJudge2Segment.StartPosition, _IDJudge2Segment.Length);
            }
        }

        public int MatID
        {
            get
            {
                return Convert.ToInt32(_Data.ToText(_IDMatSegment.StartPosition, _IDMatSegment.Length));
            }
        }

        public string IDMat_Raw
        {
            get
            {
                return _Data.ToText(_IDMatSegment.StartPosition, _IDMatSegment.Length);
            }
        }

        public string DisplayMode
        {
            get
            {
                return FromDisplayMode(_Data.ToText(_DisplayModeSegment.StartPosition, _DisplayModeSegment.Length));
            }
        }

        public string DisplayMode_Raw
        {
            get
            {
                return _Data.ToText(_DisplayModeSegment.StartPosition, _DisplayModeSegment.Length);
            }
        }

        private string EndToken
        {
            get
            {
                return _Data[_EndTokenSegment.StartPosition].ToString();
                //return _Data.ToText(_EndTokenSegment.StartPosition, _EndTokenSegment.Length);
            }
        }

        #endregion

        #region Constructors and Destructor

        public ScoreboardData(byte[] Data)
        {
            _Data = Data;

            if (Data.Length != ProtocolLength)
            {
                throw new InvalidOperationException("The data length is incorrect.  Exactly " + ProtocolLength.ToString() + " bytes must be specified");
            }

            if (StartToken != "2")
            {
                throw new InvalidOperationException("The StartToken is incorrect.");
            }

            if (EndToken != "3")
            {
                throw new InvalidOperationException("The EndToken is incorrect.");
            }
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        private string TextFromByte(byte[] InputBytes, int Start, int Length)
        {
            byte[] Bytes = new byte[Length];
            string Result = "";
            Array.Copy(InputBytes, Start, Bytes, 0, Length);

            for (int i = 0; i < Length; i++)
            {
                if (Bytes[i] != 0)
                {
                    Result += ((char)Bytes[i]).ToString();
                }
            }

            return (Result).Trim();
        }

        private static string FromGender(string Value)
        {
            switch (Value.ToUpper())
            {
                case "M":
                    return "Mens";
                case "W":
                    return "Womens";
                default:
                    return ""; // "Other (" + Value + ")";
            }
        }

        private static string FromAgeGroup(string Value)
        {
            switch (Value.ToUpper())
            {
                case "S":
                    return "Senior";
                case "J":
                    return "Junior";
                case "C":
                    return "Cadet";
                default:
                    return ""; // "Other (" + Value + ")";
            }
        }

        private static string FromRound(string Value)
        {
            switch (Value.ToUpper())
            {
                case "0":
                    return "Round Robin";
                case "1":
                    return "Elimination round 1";
                case "2":
                    return "Elimination round 2";
                case "3":
                    return "Elimination round 3";
                case "4":
                    return "Elimination round 4";
                case "Q":
                    return "Quarter Final";
                case "R":
                    return "Repecharge";
                case "S":
                    return "Semi Final";
                case "B":
                    return "Bronze";
                case "F":
                    return "Final";
                default:
                    return ""; // "Other (" + Value + ")";
            }
        }

        private static string FromDisplayMode(string Value)
        {
            switch (Value.ToUpper())
            {
                case "1":
                    return "Logo";
                case "2":
                    return "Contest Info";
                case "3":
                    return "White Info";
                case "4":
                    return "Blue Info";
                case "5":
                    return "Both Info";
                case "6":
                    return "Scoreboard";
                case "C":
                    return "Countdown";
                case "L":
                    return "Last Call";
                default:
                    return ""; // "Other (" + Value + ")";
            }
        }

        private static string FromTimerFlag(string Value)
        {
            switch (Value.ToUpper())
            {
                case "0":
                    return "Stopped";
                case "1":
                    return "Running";
                default:
                    return ""; // "Other (" + Value + ")";
            }
        }

        private static string FromOsaekomiTimerFlag(string Value)
        {
            switch (Value.ToUpper())
            {
                case "0":
                    return "Stopped";
                case "W":
                    return "Osaekomi White";
                case "B":
                    return "Osaekomi Blue";
                default:
                    return ""; // "Other (" + Value + ")";
            }
        }

        private static string FromWinner(string Value)
        {
            switch (Value.ToUpper())
            {
                case "0":
                    return "-";
                case "W":
                    return "White";
                case "B":
                    return "Blue";
                default:
                    return ""; // "Other (" + Value + ")";
            }
        }

        private static string FromShido(string Value)
        {
            switch (Value.ToUpper())
            {
                case "H":
                    return "Hansoku make";
                default:
                    return Value;
            }
        }

        #endregion

        #region Public Methods

        public static string ToGender(string Value)
        {
            switch (Value)
            {
                case "Mens":
                    return "m";
                case "Womens":
                    return "w";
                default:
                    return Value;
            }
        }

        public static string ToAgeGroup(string Value)
        {
            switch (Value)
            {
                case "Senior":
                    return "s";
                case "Junior":
                    return "j";
                case "Cadet":
                    return "c";
                default:
                    return Value;
            }
        }

        public static string ToRound(string Value)
        {
            switch (Value)
            {
                case "Round Robin":
                    return "0";
                case "Elimination round 1":
                    return "1";
                case "Elimination round 2":
                    return "2";
                case "Elimination round 3":
                    return "3";
                case "Elimination round 4":
                    return "4";
                case "Quarter Final":
                    return "Q";
                case "Repecharge":
                    return "R";
                case "Semi-Final":
                    return "S";
                case "Bronze":
                    return "B";
                case "Final":
                    return "F";
                default:
                    return Value;
            }
        }

        public static string ToDisplayMode(string Value)
        {
            switch (Value)
            {
                case "Logo":
                    return "1";
                case "Contest Info":
                    return "2";
                case "White Info":
                    return "3";
                case "Blue Info":
                    return "4";
                case "Both Info":
                    return "5";
                case "Scoreboard":
                    return "6";
                case "Countdown":
                    return "C";
                case "Last Call":
                    return "L";
                default:
                    return Value;
            }
        }

        public static string ToTimerFlag(string Value)
        {
            switch (Value)
            {
                case "Stopped":
                    return "0";
                case "Running":
                    return "1";
                default:
                    return Value;
            }
        }

        public static string ToWinner(string Value)
        {
            switch (Value)
            {
                case "None":
                    return "0";
                case "White":
                    return "W";
                case "Blue":
                    return "B";
                default:
                    return Value;
            }
        }

        public static string ToShido(string Value)
        {
            switch (Value)
            {
                case "Hansoku make":
                    return "H";
                default:
                    return Value;
            }
        }

        public static string ToGender(Enums.Sex Value)
        {
            switch (Value)
            {
                case Enums.Sex.Male:
                    return "m";
                case Enums.Sex.Female:
                    return "w";
                default:
                    return "";
            }
        }

        public static string ToAgeGroup(AgeGroupEnum Value)
        {
            switch (Value)
            {
                case AgeGroupEnum.Senior:
                    return "s";
                case AgeGroupEnum.Junior:
                    return "j";
                case AgeGroupEnum.Cadet:
                    return "c";
                default:
                    return "";
            }
        }

        public static string ToRound(RoundEnum Value)
        {
            switch (Value)
            {
                case RoundEnum.RoundRobin:
                    return "0";
                case RoundEnum.Elimination1:
                    return "1";
                case RoundEnum.Elimination2:
                    return "2";
                case RoundEnum.Elimination3:
                    return "3";
                case RoundEnum.Elimination4:
                    return "4";
                case RoundEnum.QuarterFinal:
                    return "Q";
                case RoundEnum.Repecharge:
                    return "R";
                case RoundEnum.SemiFinal:
                    return "S";
                case RoundEnum.Bronze:
                    return "B";
                case RoundEnum.Final:
                    return "F";
                default:
                    return "";
            }
        }

        public static string ToDisplayMode(DisplayModeEnum Value)
        {
            switch (Value)
            {
                case DisplayModeEnum.Logo:
                    return "1";
                case DisplayModeEnum.ContestInfo:
                    return "2";
                case DisplayModeEnum.WhiteInfo:
                    return "3";
                case DisplayModeEnum.BlueInfo:
                    return "4";
                case DisplayModeEnum.BothInfo:
                    return "5";
                case DisplayModeEnum.Scoreboard:
                    return "6";
                default:
                    return "";
            }
        }

        public static string ToTimerFlag(TimerFlagEnum Value)
        {
            switch (Value)
            {
                case TimerFlagEnum.Stopped:
                    return "0";
                case TimerFlagEnum.Running:
                    return "1";
                default:
                    return "";
            }
        }

        public static string ToOsaekomiTimerFlag(OsaekomiTimerFlagEnum Value)
        {
            switch (Value)
            {
                case OsaekomiTimerFlagEnum.Stopped:
                    return "0";
                case OsaekomiTimerFlagEnum.White:
                    return "W";
                case OsaekomiTimerFlagEnum.Blue:
                    return "B";
                default:
                    return "";
            }
        }

        public static string ToWinner(WinnerEnum Value)
        {
            switch (Value)
            {
                case WinnerEnum.None:
                    return "0";
                case WinnerEnum.White:
                    return "W";
                case WinnerEnum.Blue:
                    return "B";
                default:
                    return "";
            }
        }

        #endregion

        #region Classes

        // Normally, all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
