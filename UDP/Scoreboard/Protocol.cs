using System;

using Utilities;

namespace Scoreboard
{
    public abstract class Protocol : IScoreboardProtocol
    {
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
            RoundRobin,
            Elimination1,
            Elimination2,
            Elimination3,
            Elimination4,
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

        #region Abstract Properties

        public abstract string StartToken
        {
            get;
        }
        public abstract string ProtocolVersion
        {
            get;
        }
        public abstract string EventID
        {
            get;
        }
        public abstract string Gender
        {
            get;
        }
        public abstract string Category
        {
            get;
        }
        public abstract string AgeGroup
        {
            get;
        }
        public abstract string Round
        {
            get;
        }
        public abstract string ContestID
        {
            get;
        }
        public abstract string TimerFlag
        {
            get;
        }
        public abstract string TimerMinute
        {
            get;
        }
        public abstract string TimerSecond
        {
            get;
        }
        public abstract string NationWhite
        {
            get;
        }
        public abstract string IDWhite
        {
            get;
        }
        public abstract string ShortNameWhite
        {
            get;
        }
        public abstract string WorldRankingListPositionWhite
        {
            get;
        }
        public abstract string LongNameWhite
        {
            get;
        }
        public abstract string IpponWhite
        {
            get;
        }
        public abstract string WazaAriWhite
        {
            get;
        }
        public abstract string YukoWhite
        {
            get;
        }
        public abstract string ShidoWhite
        {
            get;
        }
        public abstract string TimerOsaekomiWhite
        {
            get;
        }
        public abstract string TeamScoreWhite
        {
            get;
        }
        public abstract string NationBlue
        {
            get;
        }
        public abstract string IDBlue
        {
            get;
        }
        public abstract string ShortNameBlue
        {
            get;
        }
        public abstract string WorldRankingListPositionBlue
        {
            get;
        }
        public abstract string LongNameBlue
        {
            get;
        }
        public abstract string IpponBlue
        {
            get;
        }
        public abstract string WazaAriBlue
        {
            get;
        }
        public abstract string YukoBlue
        {
            get;
        }
        public abstract string ShidoBlue
        {
            get;
        }
        public abstract string TimerOsaekomiBlue
        {
            get;
        }
        public abstract string TeamScoreBlue
        {
            get;
        }
        public abstract string GoldenScore
        {
            get;
        }
        public abstract string Winner
        {
            get;
        }
        public abstract string IDReferee
        {
            get;
        }
        public abstract string IDJudge1
        {
            get;
        }
        public abstract string IDJudge2
        {
            get;
        }
        public abstract string IDMat
        {
            get;
        }
        public abstract string DisplayMode
        {
            get;
        }
        public abstract string OsaekomiTimerFlag
        {
            get;
        }
        public abstract string EndToken
        {
            get;
        }

        #endregion

        #region Static Conversion Methods

        public static string FromGender(string Value)
        {
            switch (Value.ToUpper())
            {
                case "M":
                case "1": // JSON uses "1" for men
                    return "Mens";
                case "W":
                case "0": // JSON uses "0" for women
                    return "Womens";
                default:
                    return ""; // "Other (" + Value + ")";
            }
        }

        public static string FromAgeGroup(string Value)
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

        public static string FromRound(string Value)
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

        public static string FromDisplayMode(string Value)
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

        public static string FromTimerFlag(string Value)
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

        public static string FromOsaekomiTimerFlag(string Value)
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

        public static string FromWinner(string Value)
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

        public static string FromShido(string Value)
        {
            switch (Value.ToUpper())
            {
                case "H":
                    return "Hansoku make";
                default:
                    return Value;
            }
        }

        // Include all the "To" methods as well...
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

        // ... (other To methods)

        #endregion
    }
}