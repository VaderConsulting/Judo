using Foundation;
using Receiver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Listener
{
    class Program
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

        private static UDPListener _Listener = null;
        private static LanguageFile _SelectedLanguage = null;
        private static List<Mat> _Mats = new List<Mat>();
        private static object _Lock = new object();
        private static List<Match> Matches = new List<Match>();
        private static TimeSpan _PreviousUpdate = TimeSpan.MinValue;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        ~Program()
        {
            _Listener.DataReceived -= new Receiver.UDPListener.DataReceivedEventHandler(DataReceived_EventHandler);
        }

        #endregion

        #region Event Handlers

        private static void DataReceived_EventHandler(object Sender, Receiver.UDPDataReceivedEventArgs e)
        {
            lock (_Lock)
            {


                Match ThisMatch = null;

                if (Matches.Count > 0)
                {
                    ThisMatch = Matches.Find(m => m.EventID == e.ReceivedData.EventID && m.Mat.Number == e.ReceivedData.MatID);
                }

                if (e.ReceivedData.DisplayMode == "Logo")
                {
                    // Does the match already exist?
                    if (ThisMatch != null && Matches.Contains(ThisMatch))
                    {
                        // Yes - remove it
                        Matches.Remove(ThisMatch);
                        Console.WriteLine("Mat " + e.ReceivedData.MatID + " removed.  There are now " + Matches.Count + " matches in the list\n");

                        //switch (ThisMatch.Mat.Number)
                        //{
                        //    case 1:
                        //        judoScoreboard1.Clear();
                        //        break;
                        //    case 2:
                        //        judoScoreboard2.Clear();
                        //        break;
                        //    case 3:
                        //        judoScoreboard3.Clear();
                        //        break;
                        //    case 4:
                        //        judoScoreboard4.Clear();
                        //        break;
                        //    case 5:
                        //        judoScoreboard5.Clear();
                        //        break;
                        //    case 6:
                        //        judoScoreboard6.Clear();
                        //        break;
                        //    default:
                        //        break;
                        //}
                    }
                }
                else if (ThisMatch == null)
                {
                    /// Create a new match
                    // First populate the values that don't change during the match

                    ThisMatch = new Match(e.ReceivedData);

                    Enums.Sex MatchSex = Enums.Sex.Unknown;

                    if (e.ReceivedData.Gender == "Male")
                    {
                        MatchSex = Enums.Sex.Male;
                    }
                    else
                    {
                        MatchSex = Enums.Sex.Female;
                    }

                    ThisMatch.WhitePerson = new Person(new Name(e.ReceivedData.LongNameWhite), MatchSex);
                    ThisMatch.BluePerson = new Person(new Name(e.ReceivedData.LongNameBlue), MatchSex);

                    Score WhiteScore = new Score(e.ReceivedData.IpponWhite, e.ReceivedData.WazaAriWhite, e.ReceivedData.ShidoWhite, e.ReceivedData.HansokuMakeWhite);
                    Score BlueScore = new Score(e.ReceivedData.IpponBlue, e.ReceivedData.WazaAriBlue, e.ReceivedData.ShidoBlue, e.ReceivedData.HansokuMakeBlue);

                    ThisMatch.Timer = e.ReceivedData.Timer;
                    ThisMatch.TimerState = e.ReceivedData.TimerState;

                    // Now add this match to the list of matches

                    Matches.Add(ThisMatch);

                    Console.WriteLine("Mat " + ThisMatch.Mat.Number + " added.  There are now " + Matches.Count + " matches in the list\n");
                    Console.WriteLine("Mat " + ThisMatch.Mat.Number + " is " + ThisMatch.TimerState + " at " + ThisMatch.Timer);

                    //Console.WriteLine(_SelectedLanguage.Strings["Event ID"] + ": " + e.ReceivedData.EventID);
                    //Console.WriteLine(_SelectedLanguage.Strings["Mat Number"] + ": " + e.ReceivedData.MatID);
                    //Console.WriteLine(_SelectedLanguage.Strings["Category"] + ": " + e.ReceivedData.Category + " " + _SelectedLanguage.Strings["Kg"] + " " + _SelectedLanguage.Strings[e.ReceivedData.AgeGroup] + " " + _SelectedLanguage.Strings[e.ReceivedData.Gender] + " " + e.ReceivedData.Round);
                    //Console.WriteLine(_SelectedLanguage.Strings[e.ReceivedData.DisplayMode] + " (" + _SelectedLanguage.Strings[e.ReceivedData.TimerFlag] + ")");
                    //Console.WriteLine(_SelectedLanguage.Strings["White"] + ": " + e.ReceivedData.LongNameWhite + " (" + e.ReceivedData.NationWhite + ")");
                    //Console.WriteLine(_SelectedLanguage.Strings["Blue"] + ": " + e.ReceivedData.LongNameBlue + " (" + e.ReceivedData.NationBlue + ")");

                    //Console.WriteLine(_SelectedLanguage.Strings["White"] + ": " + e.ReceivedData.IpponWhite + " " + e.ReceivedData.WazaAriWhite + " " + e.ReceivedData.ShidoWhite);
                    //Console.WriteLine(_SelectedLanguage.Strings["Blue"] + ": " + e.ReceivedData.IpponBlue + " " + e.ReceivedData.WazaAriBlue + " " + e.ReceivedData.ShidoBlue);

                    //Console.WriteLine(_SelectedLanguage.Strings["Timer"] + ": " + e.ReceivedData.TimerMinute + ":" + e.ReceivedData.TimerSecond);
                    //Console.WriteLine(_SelectedLanguage.Strings["Osaekomi Timer White"] + ": " + e.ReceivedData.TimerOsaekomiWhite);
                    //Console.WriteLine(_SelectedLanguage.Strings["Osaekomi Timer Blue"] + ": " + e.ReceivedData.TimerOsaekomiBlue);

                    //Console.WriteLine(_SelectedLanguage.Strings["Golden Score"] + ": " + e.ReceivedData.GoldenScore);
                    //Console.WriteLine(_SelectedLanguage.Strings["Winner"] + ": " + e.ReceivedData.Winner);

                    //Console.WriteLine("============================================================================");
                }
                else
                {
                    bool MatchUpdate = false;

                    // Update the match details
                    Score WhiteScore = new Score(e.ReceivedData.IpponWhite, e.ReceivedData.WazaAriWhite, e.ReceivedData.ShidoWhite, e.ReceivedData.HansokuMakeWhite);
                    Score BlueScore = new Score(e.ReceivedData.IpponBlue, e.ReceivedData.WazaAriBlue, e.ReceivedData.ShidoBlue, e.ReceivedData.HansokuMakeBlue);

                    ThisMatch.Timer = e.ReceivedData.Timer;
                    //ThisMatch.TimerState = e.ReceivedData.TimerState;

                    if (ThisMatch.WhitePlayerScore != WhiteScore)
                    {
                        ThisMatch.WhitePlayerScore = WhiteScore;

                        Console.WriteLine("Mat " + ThisMatch.Mat.Number + ": White score: " + WhiteScore.ToString());
                        MatchUpdate = true;
                    }

                    if (ThisMatch.BluePlayerScore != BlueScore)
                    {
                        ThisMatch.BluePlayerScore = BlueScore;

                        Console.WriteLine("Mat " + ThisMatch.Mat.Number + ": Blue Score: " + BlueScore.ToString());
                        MatchUpdate = true;
                    }

                    if (ThisMatch.GoldenScore != e.ReceivedData.GoldenScore)
                    {
                        ThisMatch.GoldenScore = true;

                        Console.WriteLine("Mat " + ThisMatch.Mat.Number + ": Golden Score");
                    }

                    if (ThisMatch.TimerState != e.ReceivedData.TimerState)
                    {
                        ThisMatch.TimerState = e.ReceivedData.TimerState;

                        Console.WriteLine("Mat " + ThisMatch.Mat.Number + ": " + ThisMatch.Timer + " (" + ThisMatch.TimerState + ")");
                    }
                    else if (ThisMatch.TimerState == Enums.TimerState.Running)
                    {
                        if (_PreviousUpdate != ThisMatch.Timer)
                        {
                            if (e.ReceivedData.GoldenScore)
                            {
                                Console.WriteLine("Mat " + ThisMatch.Mat.Number + ": " + ThisMatch.Timer + " GOLDENSCORE (" + ThisMatch.TimerState + ") ");
                            }
                            else
                            {
                                Console.WriteLine("Mat " + ThisMatch.Mat.Number + ": " + ThisMatch.Timer + " (" + ThisMatch.TimerState + ") ");
                            }

                        }
                    }

                    _PreviousUpdate = ThisMatch.Timer;
                }


            }
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        static void Main(string[] args)
        {
            // TODO: Place language list into config
            string EnglishFilename = System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().GetModules()[0].Assembly.Location), "English.xml");
            string JapaneseFilename = System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().GetModules()[0].Assembly.Location), "Japanese.xml");
            string GermanFilename = System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().GetModules()[0].Assembly.Location), "German.xml");
            string SpanishFilename = System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().GetModules()[0].Assembly.Location), "Spanish.xml");
            string FrenchFilename = System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().GetModules()[0].Assembly.Location), "French.xml");

            LanguageFile EnglishLanguage = new LanguageFile(EnglishFilename);
            LanguageFile JapaneseLanguage = new LanguageFile(JapaneseFilename);
            LanguageFile GermanLanguage = new LanguageFile(GermanFilename);
            LanguageFile SpanishLanguage = new LanguageFile(SpanishFilename);
            LanguageFile FrenchLanguage = new LanguageFile(FrenchFilename);

            _SelectedLanguage = EnglishLanguage;

            //TODO:  Place port into config
            _Listener = new UDPListener(5000);

            // Wire up the event handler so we see data as it is received
            _Listener.DataReceived += new Receiver.UDPListener.DataReceivedEventHandler(DataReceived_EventHandler);

            // Start waiting for data
            _Listener.Start();

            // Track the state of the listener
            Task ListenerTask = _Listener.Task;

            while (ListenerTask.Status != TaskStatus.RanToCompletion && ListenerTask.Status != TaskStatus.Faulted)
            {
                System.Threading.Thread.Sleep(5);
            }
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}