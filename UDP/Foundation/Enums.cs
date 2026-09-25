using System;

namespace Judo
{
    public class Enums
    {


        //public enum MatchResult : int
        //{
        //    Unknown = 0,
        //    YuseiGachi = 1,   // Win by decision
        //    KikenGachi = 2,   // Win by withdrawal 
        //    FusenGachi = 3,   // Win by default (i.e. "walk-on")
        //    Fushogachi = 4,   // Win due to injury
        //    Hansokugachi = 5, // Win due to penalty
        //    Shikakugachi = 6, // Win due to disqualification
        //    HikeWake = 99     // Draw
        //}

        //public enum MatchState : int
        //{
        //    Unknown = -3,
        //    Unconfigured = -2,
        //    Configuring = -1,
        //    ////////////////////////////
        //    Ready = 0,
        //    Starting = 1,
        //    Playing = 2,
        //    Pausing = 3,
        //    Paused = 4,
        //    Continuing = 5,
        //    ////////////////////////////
        //    GoldenScoreReady = 6,
        //    GoldenScoreStarting = 7,
        //    GoldenScoreStarted = 8,
        //    GoldenScorePaused = 9,
        //    GoldenScoreCompleting = 10,
        //    ////////////////////////////
        //    Completing = 11,
        //    Completed = 12
        //}

        public enum TimerState : int
        {
            Unknown = 0,
            Running = 1,
            Paused = 2
        }

        public enum ConnectionState : int
        {
            Unknown = 0,
            Disconnected = 1,
            Connecting = 2,
            Connected = 3,
            Disconnecting = 4
        }

        /// <summary>Enum of Player colours</summary> 
        public enum PlayerColors : int
        {
            None = 0,
            White = 1,
            Blue = 2
        }

        public enum InformationType : int
        {
            Player = 0,
            Nation = 1
        }

        public enum HorizontalPosition : int
        {
            None = 0,
            Left = 1,
            Right = 2
        }
    }
}
