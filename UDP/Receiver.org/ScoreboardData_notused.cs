using System;

namespace Receiver
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

        public enum GenderEnum : int
        {
            Womens,
            Mens
        }

        public enum AgeGroupEnum : int
        {
            Cadet,
            Junior,
            Senior
        }

        public enum RoundEnum : int
        {
            Elimination,
            PoolFinal,
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
            Scoreboard
        }

        public enum TimerFlagEnum : int
        {
            Stopped,
            Running
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
        private UDPSegment _StartTokenSegment = new UDPSegment(0);
        private UDPSegment _ProtocolVersionSegment = new UDPSegment(1, 3);
        private UDPSegment _EventIDSegment = new UDPSegment(4, 23);
        private UDPSegment _GenderSegment = new UDPSegment(24);
        private UDPSegment _CategorySegment = new UDPSegment(25, 28);
        private UDPSegment _AgeGroupSegment = new UDPSegment(29);
        private UDPSegment _RoundSegment = new UDPSegment(30);
        private UDPSegment _ContestIDSegment = new UDPSegment(31, 33);
        private UDPSegment _TimerFlagSegment = new UDPSegment(34);
        private UDPSegment _TimerMinuteSegment = new UDPSegment(35);
        private UDPSegment _TimerSecondSegment = new UDPSegment(36, 37);
        private UDPSegment _NationWhiteSegment = new UDPSegment(40, 38);
        private UDPSegment _IDWhiteSegment = new UDPSegment(55, 41);
        private UDPSegment _ShortNameWhiteSegment = new UDPSegment(59, 56);
        private UDPSegment _WorldRankingListPositionWhiteSegment = new UDPSegment(62, 60);
        private UDPSegment _LongNameWhiteSegment = new UDPSegment(92, 63);
        private UDPSegment _IpponWhiteSegment = new UDPSegment(93);
        private UDPSegment _YukoWhiteSegment = new UDPSegment(94);
        private UDPSegment _WazaAriWhiteSegment = new UDPSegment(95);
        private UDPSegment _ShidoWhiteSegment = new UDPSegment(96);
        private UDPSegment _TimerOsaekomiWhiteSegment = new UDPSegment(97, 98);
        private UDPSegment _TeamScoreWhiteSegment = new UDPSegment(99);
        private UDPSegment _NationBlueSegment = new UDPSegment(100, 102);
        private UDPSegment _IDBlueSegment = new UDPSegment(103, 117);
        private UDPSegment _ShortNameBlueSegment = new UDPSegment(118, 121);
        private UDPSegment _WorldRankingListPositionBlueSegment = new UDPSegment(122, 124);
        private UDPSegment _LongNameBlueSegment = new UDPSegment(125, 154);
        private UDPSegment _IpponBlueSegment = new UDPSegment(155);
        private UDPSegment _YukoBlueSegment = new UDPSegment(156);
        private UDPSegment _WazaAriBlueSegment = new UDPSegment(157);
        private UDPSegment _ShidoBlueSegment = new UDPSegment(158);
        private UDPSegment _TimerOsaekomiBlueSegment = new UDPSegment(159, 160);
        private UDPSegment _TeamScoreBlueSegment = new UDPSegment(161);
        private UDPSegment _GoldenScoreSegment = new UDPSegment(162);
        private UDPSegment _WinnerSegment = new UDPSegment(163);
        private UDPSegment _IDRefereeSegment = new UDPSegment(164, 178);
        private UDPSegment _IDJudge1Segment = new UDPSegment(179, 193);
        private UDPSegment _IDJudge2Segment = new UDPSegment(194, 208);
        private UDPSegment _IDMatSegment = new UDPSegment(209);
        private UDPSegment _DisplayModeSegment = new UDPSegment(210);
        private UDPSegment _NotUsedSegment = new UDPSegment(211, 214);
        private UDPSegment _EndTokenSegment = new UDPSegment(215);

        private byte[] _Data = null;

        private Person WhitePerson = null;
        private Person BluePerson = null;
        private Person Referee = null;
        private Person Judge1 = null;
        private Person Judge2 = null;
        private Mat _Mat = null;
        private Score _Score = null;
        private Match _Match = null;

        #endregion

        #region Properties

        public string StartToken
        {
            get
            {
                byte[] Bytes = new byte[_StartTokenSegment.Length];
                Array.Copy(_Data, _StartTokenSegment.StartPosition, Bytes, 0, _StartTokenSegment.Length);

                return System.Text.Encoding.Default.GetString(Bytes);
            }
        }

        public string ProtocolVersion
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

        public string IpponWhite
        {
            get
            {
                return _Data.ToText(_IpponWhiteSegment.StartPosition, _IpponWhiteSegment.Length);
            }
        }

        public string WazaAriWhite
        {
            get
            {
                return _Data.ToText(_WazaAriWhiteSegment.StartPosition, _WazaAriWhiteSegment.Length);
            }
        }

        public string YukoWhite
        {
            get
            {
                return _Data.ToText(_YukoWhiteSegment.StartPosition, _YukoWhiteSegment.Length);
            }
        }

        public string ShidoWhite
        {
            get
            {
                return FromShido(_Data.ToText(_ShidoWhiteSegment.StartPosition, _ShidoWhiteSegment.Length));
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

        public string IpponBlue
        {
            get
            {
                return _Data.ToText(_IpponBlueSegment.StartPosition, _IpponBlueSegment.Length);
            }
        }

        public string WazaAriBlue
        {
            get
            {
                return _Data.ToText(_WazaAriBlueSegment.StartPosition, _WazaAriBlueSegment.Length);
            }
        }

        public string YukoBlue
        {
            get
            {
                return _Data.ToText(_YukoBlueSegment.StartPosition, _YukoBlueSegment.Length);
            }
        }

        public string ShidoBlue
        {
            get
            {
                return FromShido(_Data.ToText(_ShidoBlueSegment.StartPosition, _ShidoBlueSegment.Length));
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

        public string GoldenScore
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

        public string IDReferee
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

        public string IDMat
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

        public string EndToken
        {
            get
            {
                return _Data.ToText(_EndTokenSegment.StartPosition, _EndTokenSegment.Length);
            }
        }

        #endregion

        #region Constructors and Destructor

        public ScoreboardData(byte[] Data, bool AllowInvalidData = false)
        {
            if (Data.Length != ProtocolLength && !AllowInvalidData)
            {
                throw new InvalidOperationException("The data length is incorrect.  Exactly " + ProtocolLength.ToString() + " bytes must be specified");
            }

            _Data = Data;

            if (StartToken != '2'.ToString() && !AllowInvalidData)
            {
                throw new InvalidOperationException("The StartToken is incorrect.");
            }

            if (EndToken != '3'.ToString() && !AllowInvalidData)
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

        #endregion

        #region Public Methods

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
                case "1":
                    return "Elimination";
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
                case "Elimination":
                    return "1";
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

        public static string ToGender(GenderEnum Value)
        {
            switch (Value)
            {
                case GenderEnum.Mens:
                    return "m";
                case GenderEnum.Womens:
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
                case RoundEnum.Elimination:
                    return "1";
                case RoundEnum.PoolFinal:
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
