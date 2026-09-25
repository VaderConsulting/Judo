using Judo;
using Receiver;
using LanguageFile = Scoreboard.LanguageFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using static Utilities.ScoreboardData;
using static Utilities.Enums;
using System.Data;
using Scoreboard;
using Receiver.Core;
using System.Diagnostics;

namespace Scoreboards
{
    public partial class frmMain : Form
    {
        #region Fields

        private static List<Match> Matches = new List<Match>();
        private static UDPListener _Listener = null;
        private static object _Lock = new object();
        private static List<Mat> _Mats = new List<Mat>();
        private static TimeSpan _PreviousUpdate = TimeSpan.MinValue;
        private static Scoreboard.LanguageFile _SelectedLanguage = null;

        #endregion

        #region Constructors

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Destructor

        ~frmMain()
        {
            _Listener.DataReceived -= DataReceived_EventHandler;
        }

        #endregion

        #region Private Methods

        private void DataReceived_EventHandler(object Sender, Receiver.UDPDataReceivedEventArgs e)
        {
            lock (_Lock)
            {
                Match ThisMatch = null;

                if (Matches.Count > 0)
                {
                    ThisMatch = Matches.Find(m =>
                                                  m.EventID == e.ReceivedData.EventID &&
                                                  m.Mat.Number == e.ReceivedData.MatID
                                            );
                }

                //Debug.WriteLine($"Mat {ThisMatch.Mat.Number} state: {ThisMatch.MatchState}");

                
                
                if (e != null && e.ReceivedData.DisplayMode == "Logo")
                {
                    // Does the match already exist?
                    if (ThisMatch != null && Matches.Contains(ThisMatch))
                    {
                        // Yes - remove it
                        bool unused = Matches.Remove(ThisMatch);
                        Debug.WriteLine("Mat " + e.ReceivedData.MatID + " removed.  There are now " + Matches.Count + " matches in the list\n");

                        switch (ThisMatch.Mat.Number)
                        {
                            case 1:
                                judoScoreboard1.Clear();
                                break;
                            case 2:
                                judoScoreboard2.Clear();
                                break;
                            case 3:
                                judoScoreboard3.Clear();
                                break;
                            case 4:
                                judoScoreboard4.Clear();
                                break;
                            case 5:
                                judoScoreboard5.Clear();
                                break;
                            case 6:
                                judoScoreboard6.Clear();
                                break;
                            default:
                                break;
                        }
                    }
                    else if (ThisMatch == null)
                    {
                        // New match being defined

                        this.OnUIThread(() =>
                        {
                            switch (e.ReceivedData.MatID)
                            {
                                case 1:
                                    txtUpcomingMatch1.Text = e.ReceivedData.EventID + " on Mat " + e.ReceivedData.MatID + ". " + e.ReceivedData.AgeGroup + " " + e.ReceivedData.Gender + " " + e.ReceivedData.Category + " Kg " + e.ReceivedData.Round;
                                    break;
                                case 2:
                                    txtUpcomingMatch2.Text = e.ReceivedData.EventID + " on Mat " + e.ReceivedData.MatID + ". " + e.ReceivedData.AgeGroup + " " + e.ReceivedData.Gender + " " + e.ReceivedData.Category + " Kg " + e.ReceivedData.Round;
                                    break;
                                case 3:
                                    txtUpcomingMatch3.Text = e.ReceivedData.EventID + " on Mat " + e.ReceivedData.MatID + ". " + e.ReceivedData.AgeGroup + " " + e.ReceivedData.Gender + " " + e.ReceivedData.Category + " Kg " + e.ReceivedData.Round;
                                    break;
                                case 4:
                                    txtUpcomingMatch4.Text = e.ReceivedData.EventID + " on Mat " + e.ReceivedData.MatID + ". " + e.ReceivedData.AgeGroup + " " + e.ReceivedData.Gender + " " + e.ReceivedData.Category + " Kg " + e.ReceivedData.Round;
                                    break;
                                case 5:
                                    txtUpcomingMatch5.Text = e.ReceivedData.EventID + " on Mat " + e.ReceivedData.MatID + ". " + e.ReceivedData.AgeGroup + " " + e.ReceivedData.Gender + " " + e.ReceivedData.Category + " Kg " + e.ReceivedData.Round;
                                    break;
                                case 6:
                                    txtUpcomingMatch6.Text = e.ReceivedData.EventID + " on Mat " + e.ReceivedData.MatID + ". " + e.ReceivedData.AgeGroup + " " + e.ReceivedData.Gender + " " + e.ReceivedData.Category + " Kg " + e.ReceivedData.Round;
                                    break;
                            }
                        });
                    }
                }
                else if (ThisMatch == null)
                {
                    ThisMatch = UpdateMatch(e.ReceivedData);

                    // Now add this match to the list of matches
                    Matches.Add(ThisMatch);

                    Debug.WriteLine("Mat " + ThisMatch.Mat.Number + " added.  There are now " + Matches.Count + " matches in the list\n");
                    Debug.WriteLine("Mat " + ThisMatch.Mat.Number + " is " + ThisMatch.TimerState + " at " + ThisMatch.Timer);
                }
                else
                {
                    Match unused1 = UpdateMatch(e.ReceivedData);

                    _PreviousUpdate = ThisMatch.Timer;
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            //Debug.WriteLine(judoScoreboard1.Width + ", " + judoScoreboard1.Height);
        }

        private void frmScoreboard_Load(object sender, EventArgs e)
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

            IProtocolFactory factory = new ProtocolFactory();
            //TODO:  Place port into config
            _Listener = new UDPListener(5000);
            _Listener.SetProtocolFactory(factory);

            // Wire up the event handler so we see data as it is received
            _Listener.DataReceived += DataReceived_EventHandler;

            // Start waiting for data
            _Listener.Start();

            // Track the state of the listener
            Task ListenerTask = _Listener.Task;

            //judoScoreboard1.InfoType = Judo.Enums.InformationType.Player;
            //judoScoreboard2.InfoType = Enums.InformationType.Player;
            //judoScoreboard3.InfoType = Enums.InformationType.Player;
            //judoScoreboard4.InfoType = Enums.InformationType.Player;
            //judoScoreboard5.InfoType = Enums.InformationType.Player;
            //judoScoreboard6.InfoType = Enums.InformationType.Player;
        }

        private void judoScoreboard1_Load(object sender, EventArgs e)
        {
        }

        private void judoScoreboard2_Load(object sender, EventArgs e)
        {
        }

        private void judoScoreboard3_Load(object sender, EventArgs e)
        {
        }

        private void judoScoreboard4_Load(object sender, EventArgs e)
        {
        }

        private void judoScoreboard5_Load(object sender, EventArgs e)
        {
        }

        private void judoScoreboard6_Load(object sender, EventArgs e)
        {
        }

        private Match UpdateMatch(ScoreboardData Data)
        {
            Match ThisMatch = new Match(Data);

            Enums.Sex MatchSex;
            if (Data.Gender == "Mens")
            {
                MatchSex = Enums.Sex.Male;
            }
            else
            {
                MatchSex = Enums.Sex.Female;
            }

            Judo.Person WhitePerson = new Judo.Person(new Name(Data.LongNameWhite), MatchSex);
            Judo.Person BluePerson = new Judo.Person(new Name(Data.LongNameBlue), MatchSex);

            Score WhiteScore = new Score(Data.IpponWhite, Data.WazaAriWhite, Data.ShidoWhite, Data.YukoWhite, Data.HansokuMakeWhite);
            Score BlueScore = new Score(Data.IpponBlue, Data.WazaAriBlue, Data.ShidoBlue, Data.YukoBlue, Data.HansokuMakeBlue);

            ThisMatch.Timer = Data.Timer;
            ThisMatch.TimerState = Data.TimerState;

            if (((int)ThisMatch.MatchState) > 1)
            {
                //Match has started
            }

            if (Data.TimerOsaekomiWhite != "00")
            {
                ThisMatch.OsaekomiTimer = new TimeSpan(0, 0, Convert.ToInt32(Data.TimerOsaekomiWhite));
                ThisMatch.OsaekomiTimerState = TimerState.Running;
                ThisMatch.OsaekomiTimerPlayer = Match.PlayerColour.White;
            }
            else if (Data.TimerOsaekomiBlue != "00")
            {
                ThisMatch.OsaekomiTimer = new TimeSpan(0, 0, Convert.ToInt32(Data.TimerOsaekomiBlue));
                ThisMatch.OsaekomiTimerState = TimerState.Running;
                ThisMatch.OsaekomiTimerPlayer = Match.PlayerColour.Blue;
            }
            else
            {
                ThisMatch.OsaekomiTimer = new TimeSpan(0);
                ThisMatch.OsaekomiTimerState = TimerState.Paused;
                ThisMatch.OsaekomiTimerPlayer = Match.PlayerColour.Unknown;
            }

            ThisMatch.WhitePerson = WhitePerson;
            ThisMatch.BluePerson = BluePerson;
            ThisMatch.WhitePerson.Player = new Player(WhitePerson); // new Lazy<Player>(true);
            ThisMatch.BluePerson.Player = new Player(BluePerson); // new Lazy<Player>(true);

            ThisMatch.WhitePerson.Nation = new Nation(Data.NationWhite);
            ThisMatch.BluePerson.Nation = new Nation(Data.NationBlue);

            ThisMatch.WhitePlayerScore = WhiteScore;
            ThisMatch.BluePlayerScore = BlueScore;

            ThisMatch.EventID = Data.EventID;

            //if (ThisMatch.WhitePlayerScore != WhiteScore)
            //{
            ThisMatch.WhitePlayerScore = WhiteScore;

            Debug.WriteLine($"Mat {ThisMatch.Mat.Number}: White score: {WhiteScore} Penalties: {Data.HansokuMakeWhite} {Data.ShidoWhite}");
            //}

            //if (ThisMatch.BluePlayerScore != BlueScore)
            //{
            ThisMatch.BluePlayerScore = BlueScore;

            Debug.WriteLine($"Mat {ThisMatch.Mat.Number}: Blue score: {BlueScore} Penalties: {Data.HansokuMakeBlue} {Data.ShidoBlue}");
            //}

            if (ThisMatch.GoldenScore != Data.GoldenScore)
            {
                ThisMatch.GoldenScore = true;

                Debug.WriteLine("Mat " + ThisMatch.Mat.Number + ": Golden Score");
            }

            if (ThisMatch.TimerState != Data.TimerState)
            {
                ThisMatch.TimerState = Data.TimerState;

                Debug.WriteLine("Mat " + ThisMatch.Mat.Number + ": " + ThisMatch.Timer + " (" + ThisMatch.TimerState + ")");
            }
            else if (ThisMatch.TimerState == TimerState.Running)
            {
                if (_PreviousUpdate != ThisMatch.Timer)
                {
                    if (Data.GoldenScore)
                    {
                        Debug.WriteLine("Mat " + ThisMatch.Mat.Number + ": " + ThisMatch.Timer + " GOLDENSCORE (" + ThisMatch.TimerState + ") ");
                    }
                    else
                    {
                        Debug.WriteLine("Mat " + ThisMatch.Mat.Number + ": " + ThisMatch.Timer + " (" + ThisMatch.TimerState + ") ");
                    }
                }
            }

            switch (ThisMatch.Mat.Number)
            {
                case 1:
                    judoScoreboard1.Update(ThisMatch);
                    break;
                case 2:
                    judoScoreboard2.Update(ThisMatch);
                    break;
                case 3:
                    judoScoreboard3.Update(ThisMatch);
                    break;
                case 4:
                    judoScoreboard4.Update(ThisMatch);
                    break;
                case 5:
                    judoScoreboard5.Update(ThisMatch);
                    break;
                case 6:
                    judoScoreboard6.Update(ThisMatch);
                    break;
                default:
                    break;
            }

            return ThisMatch;

            //Debug.WriteLine(_SelectedLanguage.Strings["Event ID"] + ": " + e.ReceivedData.EventID);
            //Debug.WriteLine(_SelectedLanguage.Strings["Mat Number"] + ": " + e.ReceivedData.MatID);
            //Debug.WriteLine(_SelectedLanguage.Strings["Category"] + ": " + e.ReceivedData.Category + " " + _SelectedLanguage.Strings["Kg"] + " " + _SelectedLanguage.Strings[e.ReceivedData.AgeGroup] + " " + _SelectedLanguage.Strings[e.ReceivedData.Gender] + " " + e.ReceivedData.Round);
            //Debug.WriteLine(_SelectedLanguage.Strings[e.ReceivedData.DisplayMode] + " (" + _SelectedLanguage.Strings[e.ReceivedData.TimerFlag] + ")");
            //Debug.WriteLine(_SelectedLanguage.Strings["White"] + ": " + e.ReceivedData.LongNameWhite + " (" + e.ReceivedData.NationWhite + ")");
            //Debug.WriteLine(_SelectedLanguage.Strings["Blue"] + ": " + e.ReceivedData.LongNameBlue + " (" + e.ReceivedData.NationBlue + ")");

            //Debug.WriteLine(_SelectedLanguage.Strings["White"] + ": " + e.ReceivedData.IpponWhite + " " + e.ReceivedData.WazaAriWhite + " " + e.ReceivedData.ShidoWhite);
            //Debug.WriteLine(_SelectedLanguage.Strings["Blue"] + ": " + e.ReceivedData.IpponBlue + " " + e.ReceivedData.WazaAriBlue + " " + e.ReceivedData.ShidoBlue);

            //Debug.WriteLine(_SelectedLanguage.Strings["Timer"] + ": " + e.ReceivedData.TimerMinute + ":" + e.ReceivedData.TimerSecond);
            //Debug.WriteLine(_SelectedLanguage.Strings["Osaekomi Timer White"] + ": " + e.ReceivedData.TimerOsaekomiWhite);
            //Debug.WriteLine(_SelectedLanguage.Strings["Osaekomi Timer Blue"] + ": " + e.ReceivedData.TimerOsaekomiBlue);

            //Debug.WriteLine(_SelectedLanguage.Strings["Golden Score"] + ": " + e.ReceivedData.GoldenScore);
            //Debug.WriteLine(_SelectedLanguage.Strings["Winner"] + ": " + e.ReceivedData.Winner);

            //Debug.WriteLine("============================================================================");
        }

        #endregion

    }
}
