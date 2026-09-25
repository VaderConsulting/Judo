using Scoreboard;

using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleTest
{
    public partial class frmInput : Form
    {
        private const int DatagramPort = 4001; //5000;

        public frmInput()
        {
            InitializeComponent();
        }

        private void frmInput_Load(object sender, EventArgs e)
        {

        }

        private static void Listener(LanguageFile SelectedLanguage, TextBox Output = null)
        {
            IPEndPoint ListenerEP = new IPEndPoint(IPAddress.Any, DatagramPort);
            UdpClient listener = new UdpClient();

            listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            listener.AllowNatTraversal(true);
            listener.EnableBroadcast = true;
            listener.Client.Bind(ListenerEP);

            try
            {
                while (true)
                {
                    byte[] bytes = listener.Receive(ref ListenerEP);

                    Protocol ReceivedData = new Protocol(bytes);

                    string ProtocolVersion = ReceivedData.ProtocolVersion;
                    string DisplayMode = Protocol.FromDisplayMode(ReceivedData.DisplayMode);

                    string NationWhite = ReceivedData.NationWhite;
                    string IDWhite = ReceivedData.IDWhite;
                    string ShortNameWhite = ReceivedData.ShortNameWhite;
                    string WRLWhite = ReceivedData.WorldRankingListPositionWhite;
                    string LongNameWhite = ReceivedData.LongNameWhite;
                    string IpponWhite = ReceivedData.IpponWhite;
                    string WazaAriWhite = ReceivedData.WazaAriWhite;
                    string YukoWhite = ReceivedData.YukoWhite;
                    string ShidoWhite = Protocol.FromShido(ReceivedData.ShidoWhite);
                    string OsaekomiWhite = ReceivedData.TimerOsaekomiWhite;
                    string TeamScoreWhite = ReceivedData.TeamScoreWhite;

                    string NationBlue = ReceivedData.NationBlue;
                    string IDBlue = ReceivedData.IDBlue;
                    string ShortNameBlue = ReceivedData.ShortNameBlue;
                    string WRLBlue = ReceivedData.WorldRankingListPositionBlue;
                    string LongNameBlue = ReceivedData.LongNameBlue;
                    string IpponBlue = ReceivedData.IpponBlue;
                    string WazaAriBlue = ReceivedData.WazaAriBlue;
                    string YukoBlue = ReceivedData.YukoBlue;
                    string ShidoBlue = Protocol.FromShido(ReceivedData.ShidoBlue);
                    string OsaekomiBlue = ReceivedData.TimerOsaekomiBlue;
                    string TeamScoreBlue = ReceivedData.TeamScoreBlue;

                    string EventID = ReceivedData.EventID;
                    string Gender = Protocol.FromGender(ReceivedData.Gender);
                    string Category = ReceivedData.Category;
                    string AgeGroup = Protocol.FromAgeGroup(ReceivedData.AgeGroup);
                    string Round = Protocol.FromRound(ReceivedData.Round);
                    string ContestID = ReceivedData.ContestID;
                    string TimerFlag = Protocol.FromTimerFlag(ReceivedData.TimerFlag);
                    string Minute = ReceivedData.TimerMinute;
                    string Second = ReceivedData.TimerSecond;
                    string GoldenScore = ReceivedData.GoldenScore;
                    string Winner = Protocol.FromWinner(ReceivedData.Winner);
                    string IDReferee = ReceivedData.IDReferee;
                    string IDJudge1 = ReceivedData.IDJudge1;
                    string IDJudge2 = ReceivedData.IDJudge2;
                    string IDMat = ReceivedData.IDMat;

                    Console.WriteLine("============================================================================");
                    string RawData = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    //Console.WriteLine(RawData);

                    //if (Round != "")
                    //{
                    //    Round = SelectedLanguage.Strings[Round];
                    //}
                    //else
                    //{
                    //}

                    //Console.WriteLine(SelectedLanguage.Strings["Event ID"] + ": " + EventID);
                    //Console.WriteLine(SelectedLanguage.Strings["Mat Number"] + ": " + IDMat);
                    //Console.WriteLine(SelectedLanguage.Strings["Category"] + ": " + Category + " " + SelectedLanguage.Strings["Kg"] + " " + SelectedLanguage.Strings[AgeGroup] + " " + SelectedLanguage.Strings[Gender] + " " + Round);
                    //Console.WriteLine(SelectedLanguage.Strings[DisplayMode] + " (" + SelectedLanguage.Strings[TimerFlag] + ")");
                    //Console.WriteLine(SelectedLanguage.Strings["White"] + ": " + LongNameWhite + " (" + NationWhite + ")");
                    //Console.WriteLine(SelectedLanguage.Strings["Blue"] + ": " + LongNameBlue + " (" + NationBlue + ")");

                    //Console.WriteLine(SelectedLanguage.Strings["White"] + ": " + IpponWhite + " " + WazaAriWhite + " " + ShidoWhite);
                    //Console.WriteLine(SelectedLanguage.Strings["Blue"] + ": " + IpponBlue + " " + WazaAriBlue + " " + ShidoBlue);

                    //Console.WriteLine(SelectedLanguage.Strings["Timer"] + ": " + Minute + ":" + Second);
                    //Console.WriteLine(SelectedLanguage.Strings["Osaekomi Timer White"] + ": " + OsaekomiWhite);
                    //Console.WriteLine(SelectedLanguage.Strings["Osaekomi Timer Blue"] + ": " + OsaekomiBlue);

                    //Console.WriteLine(SelectedLanguage.Strings["Golden Score"] + ": " + GoldenScore);
                    //Console.WriteLine(SelectedLanguage.Strings["Winner"] + ": " + Winner);

                    string TextOutput = System.Text.Json.JsonSerializer.Serialize(ReceivedData);

                    if (Output != null)
                    {
                        Output.Text = TextOutput;
                    }

                    Console.WriteLine(TextOutput);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }

        private static void SendReceive()
        {
            UdpClient UDP = new UdpClient();
            UDP.Client.Bind(new IPEndPoint(IPAddress.Any, DatagramPort));

            IPEndPoint ReceiveEndpoint = new IPEndPoint(0, 0);
            var unused = Task.Run(() =>
            {
                while (true)
                {
                    byte[] ReceivedBytes = UDP.Receive(ref ReceiveEndpoint);
                    Console.WriteLine(Encoding.UTF8.GetString(ReceivedBytes));
                }
            });

            while (true)
            {
                //byte[] data = DateTime.Now.ToString().ToByteArray();
                //UDP.Send(data, data.Length, IPAddress.Broadcast.ToString(), DatagramPort);

                System.Threading.Thread.Sleep(500);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var unused = Task.Run(() =>
            {
                string EnglishFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "English.xml");
                string JapaneseFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Japanese.xml");
                string GermanFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "German.xml");
                string SpanishFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Spanish.xml");
                string FrenchFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "French.xml");

                LanguageFile EnglishLanguage = new LanguageFile(EnglishFilename);
                LanguageFile JapaneseLanguage = new LanguageFile(JapaneseFilename);
                LanguageFile GermanLanguage = new LanguageFile(GermanFilename);
                LanguageFile SpanishLanguage = new LanguageFile(SpanishFilename);
                LanguageFile FrenchLanguage = new LanguageFile(FrenchFilename);

                Listener(EnglishLanguage);
            });

            while (true)
            {
                System.Threading.Thread.Sleep(5);
            }
        }
    }
}
