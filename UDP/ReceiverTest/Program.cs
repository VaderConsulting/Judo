using Scoreboard;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal static class Program
    {
        private const int DatagramPort = 4001; //5000;

        private static void Listener(LanguageFile SelectedLanguage)
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

                    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(ReceivedData));
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

        private static void Main()
        {
            frmInput InputForm = new frmInput();

            InputForm.Show();


            //Task.Run(() =>
            //{
            //    string EnglishFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "English.xml");
            //    string JapaneseFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Japanese.xml");
            //    string GermanFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "German.xml");
            //    string SpanishFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Spanish.xml");
            //    string FrenchFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "French.xml");

            //    LanguageFile EnglishLanguage = new LanguageFile(EnglishFilename);
            //    LanguageFile JapaneseLanguage = new LanguageFile(JapaneseFilename);
            //    LanguageFile GermanLanguage = new LanguageFile(GermanFilename);
            //    LanguageFile SpanishLanguage = new LanguageFile(SpanishFilename);
            //    LanguageFile FrenchLanguage = new LanguageFile(FrenchFilename);

            //    Listener(EnglishLanguage);
            //});

            //while (true)
            //{
            //    System.Threading.Thread.Sleep(5);
            //}

            //SendReceive();

            // Raw data is broadcast as ASCII characters.  E.g. A protocol version of 050 is broadcast as 0x30, 0x35, 0x30 (i.e. "050") 
            // The easy way to remember this is to get the number you wish to send (e.g. '1') and prefix a three (i.e. '31').  That is the Hex value for '1'

            //byte[] RawData =
            //{
            //    0x02,                   // Start Token
            //    0x30, 0x35, 0x30,       // Protocol Version
            //    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, // Event ID
            //    0x6d,                   // Gender - 6d or 77 (f or m)
            //    0x20, 0x2d, 0x36, 0x30, // Category
            //    0x63,                   // Age Group (c)
            //    0x31,                   // Round (31, 32, 33, 34, 35, 36)
            //    0x61, 0x62, 0x63,       // Contest ID
            //    0x31,                   // Timer Flag
            //    0x33,                   // Timer minute
            //    0x32, 0x39,             // Timer second
            //    0x41, 0x55, 0x53,       // Nation White
            //    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, // ID White
            //    0x61, 0x62, 0x63, 0x64, // ShortName White
            //    0x00, 0x00, 0x00,       // WRL White
            //    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // LongName White
            //    0x00,                   // Ippon White
            //    0x00,                   // WazaAri White
            //    0x00,                   // Yuko White
            //    0x00,                   // Shido White
            //    0x31, 0x32,             // Osaekomi Timer White
            //    0x00,                   // Team score White
            //    0x41, 0x55, 0x53,       // Nation Blue
            //    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // ID Blue
            //    0x61, 0x62, 0x63, 0x64, // ShortName Blue
            //    0x00, 0x00, 0x00, 0x00, // WRL Blue
            //    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // LongName Blue
            //    0x00,                   // Ippon Blue
            //    0x00,                   // WazaAri Blue
            //    0x00,                   // Yuko Blue
            //    0x00,                   // Shido Blue
            //    0x00, 0x00,             // Osaekomi Timer Blue
            //    0x00,                   // Team score Blue
            //    0x00,                   // Golden Score
            //    0x00,                   // Winner
            //    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // ID Referee
            //    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // ID Judge 1
            //    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // ID Judge 2
            //    0x35,                   // Mat
            //    0x03,                   // Display Mode
            //    0x00, 0x00, 0x00, 0x00, // Not Used
            //    0x03                    // End Token
            //    };

            //Protocol ReceivedData = new Protocol(RawData, true);

            //string ProtocolVersion = ReceivedData.ProtocolVersion;
            //string EventID = ReceivedData.EventID;
            //string Gender = Protocol.FromGender(ReceivedData.Gender);
            //string Category = ReceivedData.Category;
            //string AgeGroup = Protocol.FromAgeGroup(ReceivedData.AgeGroup);
            //string Round = Protocol.FromRound(ReceivedData.Round);
            //string ContestID = ReceivedData.ContestID;
            //string TimerFlag = Protocol.FromTimerFlag(ReceivedData.TimerFlag);
            //string Minute = ReceivedData.TimerMinute;
            //string Second = ReceivedData.TimerSecond;
            //string NationWhite = ReceivedData.NationWhite;
            //string IDWhite = ReceivedData.IDWhite;
            //string ShortNameWhite = ReceivedData.ShortNameWhite;
            //string WRLWhite = ReceivedData.WorldRankingListPositionWhite;
            //string LongNameWhite = ReceivedData.LongNameWhite;
            //string IpponWhite = ReceivedData.IpponWhite;
            //string WazaAriWhite = ReceivedData.WazaAriWhite;
            //string YukoWhite = ReceivedData.YukoWhite;
            //string ShidoWhite = ReceivedData.ShidoWhite;
            //string OsaekomiWhite = ReceivedData.TimerOsaekomiWhite;
            //string TeamScoreWhite = ReceivedData.TeamScoreWhite;
            //string NationBlue = ReceivedData.NationBlue;
            //string IDBlue = ReceivedData.IDBlue;
            //string ShortNameBlue = ReceivedData.ShortNameBlue;
            //string WRLBlue = ReceivedData.WorldRankingListPositionBlue;
            //string LongNameBlue = ReceivedData.LongNameBlue;
            //string IpponBlue = ReceivedData.IpponBlue;
            //string WazaAriBlue = ReceivedData.WazaAriBlue;
            //string YukoBlue = ReceivedData.YukoBlue;
            //string ShidoBlue = ReceivedData.ShidoBlue;
            //string OsaekomiBlue = ReceivedData.TimerOsaekomiBlue;
            //string TeamScoreBlue = ReceivedData.TeamScoreBlue;
            //string GoldenScore = ReceivedData.GoldenScore;
            //string Winner = ReceivedData.Winner;
            //string IDReferee = ReceivedData.IDReferee;
            //string IDJudge1 = ReceivedData.IDJudge1;
            //string IDJudge2 = ReceivedData.IDJudge2;
            //string IDMat = ReceivedData.IDMat;
            //string DisplayMode = Protocol.FromDisplayMode(ReceivedData.DisplayMode);

            //string EnglishFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "English.xml");
            //string JapaneseFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Japanese.xml");
            //string GermanFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "German.xml");
            //string SpanishFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Spanish.xml");
            //string FrenchFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "French.xml");

            //LanguageFile EnglishLanguage = new LanguageFile(EnglishFilename);
            //LanguageFile JapaneseLanguage = new LanguageFile(JapaneseFilename);
            //LanguageFile GermanLanguage = new LanguageFile(GermanFilename);
            //LanguageFile SpanishLanguage = new LanguageFile(SpanishFilename);
            //LanguageFile FrenchLanguage = new LanguageFile(FrenchFilename);

            //Debug.Print(EnglishLanguage.Strings["Display Mode"] + ": " + EnglishLanguage.Strings[DisplayMode]);
            //Debug.Print(JapaneseLanguage.Strings["Display Mode"] + ": " + JapaneseLanguage.Strings[DisplayMode]);
            //Debug.Print(GermanLanguage.Strings["Display Mode"] + ": " + GermanLanguage.Strings[DisplayMode]);
            //Debug.Print(SpanishLanguage.Strings["Display Mode"] + ": " + SpanishLanguage.Strings[DisplayMode]);
            //Debug.Print(FrenchLanguage.Strings["Display Mode"] + ": " + FrenchLanguage.Strings[DisplayMode]);

            //Debug.Print(EnglishLanguage.Strings["Age Group"] + ": " + EnglishLanguage.Strings[AgeGroup]);
            //Debug.Print(JapaneseLanguage.Strings["Age Group"] + ": " + JapaneseLanguage.Strings[AgeGroup]);
            //Debug.Print(GermanLanguage.Strings["Age Group"] + ": " + GermanLanguage.Strings[AgeGroup]);
            //Debug.Print(SpanishLanguage.Strings["Age Group"] + ": " + SpanishLanguage.Strings[AgeGroup]);
            //Debug.Print(FrenchLanguage.Strings["Age Group"] + ": " + FrenchLanguage.Strings[AgeGroup]);
        }

    }
}
