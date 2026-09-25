using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Extensions;

namespace Scoreboard
{
    public static class Conversion
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        //public enum Gender : int
        //{
        //    Female,
        //    Male
        //}

        //public enum AgeGroup : int
        //{
        //    Cadets,
        //    Juniors,
        //    Seniors
        //}

        //public enum Round : int
        //{
        //    Elimination,
        //    PoolFinal,
        //    Repecharge,
        //    SemiFinal,
        //    Bronze,
        //    Final
        //}

        //public enum DisplayMode : int
        //{
        //    Logo,
        //    InfoContest,
        //    InfoWhite,
        //    InfoBlue,
        //    InfoBoth,
        //    Scoreboard
        //}

        //public enum TimerFlag : int
        //{
        //    Stopped,
        //    Running
        //}

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructor and Destructor

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        //public static string FromGender(string Value)
        //{
        //    switch (Value.ToUpper())
        //    {
        //        case "M":
        //            return "Men";
        //        case "W":
        //            return "Women";
        //        default:
        //            return "Other (" + Value + ")";
        //    }
        //}

        //public static string FromAgeGroup(string Value)
        //{
        //    switch (Value.ToUpper())
        //    {
        //        case "S":
        //            return "Seniors";
        //        case "J":
        //            return "Juniors";
        //        case "C":
        //            return "Cadets";
        //        default:
        //            return "Other (" + Value + ")";
        //    }
        //}

        //public static string FromRound(string Value)
        //{
        //    switch (Value.ToUpper())
        //    {
        //        case "1":
        //            return "Elimination";
        //        case "2":
        //            return "Quarter Final";
        //        case "3":
        //            return "Repecharge";
        //        case "4":
        //            return "Semi-Final";
        //        case "5":
        //            return "Bronze";
        //        case "6":
        //            return "Final";
        //        default:
        //            return "Other (" + Value + ")";
        //    }
        //}

        //public static string FromDisplayMode(string Value)
        //{
        //    switch (Value.ToUpper())
        //    {
        //        case "1":
        //            return "Logo";
        //        case "2":
        //            return "Info contest";
        //        case "3":
        //            return "Info white";
        //        case "4":
        //            return "Info blue";
        //        case "5":
        //            return "Info both";
        //        case "6":
        //            return "Scoreboard";
        //        default:
        //            return "Other (" + Value + ")";
        //    }
        //}

        //public static string FromTimerFlag(string Value)
        //{
        //    switch (Value.ToUpper())
        //    {
        //        case "0":
        //            return "Stopped";
        //        case "1":
        //            return "Running";
        //        default:
        //            return "Other (" + Value + ")";
        //    }
        //}

        //public static string ToGender(string Value)
        //{
        //    switch (Value)
        //    {
        //        case "Men":
        //            return "m";
        //        case "Women":
        //            return "w";
        //        default:
        //            return Value;
        //    }
        //}

        //public static string ToAgeGroup(string Value)
        //{
        //    switch (Value)
        //    {
        //        case "Seniors":
        //            return "s";
        //        case "Juniors":
        //            return "j";
        //        case "Cadets":
        //            return "c";
        //        default:
        //            return Value;
        //    }
        //}

        //public static string ToRound(string Value)
        //{
        //    switch (Value)
        //    {
        //        case "Elimination":
        //            return "1";
        //        case "Quarter Final":
        //            return "2";
        //        case "Repecharge":
        //            return "3";
        //        case "Semi-Final":
        //            return "4";
        //        case "Bronze":
        //            return "5";
        //        case "Final":
        //            return "6";
        //        default:
        //            return Value;
        //    }
        //}

        //public static string ToDisplayMode(string Value)
        //{
        //    switch (Value)
        //    {
        //        case "Logo":
        //            return "1";
        //        case "Info contest":
        //            return "2";
        //        case "Info white":
        //            return "3";
        //        case "Info blue":
        //            return "4";
        //        case "Info both":
        //            return "5";
        //        case "Scoreboard":
        //            return "6";
        //        default:
        //            return Value;
        //    }
        //}

        //public static string ToTimerFlag(string Value)
        //{
        //    switch (Value)
        //    {
        //        case "Stopped":
        //            return "0";
        //        case "Running":
        //            return "1";
        //        default:
        //            return Value;
        //    }
        //}

        //public static string ToGender(Gender Value)
        //{
        //    switch (Value)
        //    {
        //        case Gender.Male:
        //            return "m";
        //        case Gender.Female:
        //            return "w";
        //        default:
        //            return "";
        //    }
        //}

        //public static string ToAgeGroup(AgeGroup Value)
        //{
        //    switch (Value)
        //    {
        //        case AgeGroup.Seniors:
        //            return "s";
        //        case AgeGroup.Juniors:
        //            return "j";
        //        case AgeGroup.Cadets:
        //            return "c";
        //        default:
        //            return "";
        //    }
        //}

        //public static string ToRound(Round Value)
        //{
        //    switch (Value)
        //    {
        //        case Round.Elimination:
        //            return "1";
        //        case Round.PoolFinal:
        //            return "2";
        //        case Round.Repecharge:
        //            return "3";
        //        case Round.SemiFinal:
        //            return "4";
        //        case Round.Bronze:
        //            return "5";
        //        case Round.Final:
        //            return "6";
        //        default:
        //            return "";
        //    }
        //}

        //public static string ToDisplayMode(DisplayMode Value)
        //{
        //    switch (Value)
        //    {
        //        case DisplayMode.Logo:
        //            return "1";
        //        case DisplayMode.InfoContest:
        //            return "2";
        //        case DisplayMode.InfoWhite:
        //            return "3";
        //        case DisplayMode.InfoBlue:
        //            return "4";
        //        case DisplayMode.InfoBoth:
        //            return "5";
        //        case DisplayMode.Scoreboard:
        //            return "6";
        //        default:
        //            return "";
        //    }
        //}

        //public static string ToTimerFlag(TimerFlag Value)
        //{
        //    switch (Value)
        //    {
        //        case TimerFlag.Stopped:
        //            return "0";
        //        case TimerFlag.Running:
        //            return "1";
        //        default:
        //            return "";
        //    }
        //}

        #endregion

        #region Classes

        // By convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
