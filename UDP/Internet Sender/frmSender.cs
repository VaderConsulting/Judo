using Scoreboard;

using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

using static Utilities.Extensions;

using LanguageFile = Scoreboard.LanguageFile;

namespace Internet_Sender
{
    public partial class frmSender : Form
    {
        private const int DatagramPort = 5000;
        private LanguageFile SelectedLanguageFile;

        string EnglishFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "", "English.xml");
        string JapaneseFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "", "Japanese.xml");
        string GermanFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "", "German.xml");
        string SpanishFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "", "Spanish.xml");
        string FrenchFilename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "", "French.xml");

        public frmSender()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            Task unused = Task.Run(() =>
            {
                Listener(txtURL.Text, txtOutput);
            });
        }

        private void Listener(string Address, TextBox TextControl = null)
        {
            IPEndPoint ListenerEP = new(Convert.ToInt32(IPAddress.Any.Address), DatagramPort);
            UdpClient listener = new();

            listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            listener.AllowNatTraversal(true);
            listener.EnableBroadcast = true;
            listener.Client.Bind(ListenerEP);

            try
            {
                while (true)
                {
                    byte[] bytes = listener.Receive(ref ListenerEP);

                    Protocol ReceivedData = new(bytes);

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

                    Debug.WriteLine("============================================================================");
                    string RawData = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                    string FormattedData = "";

                    List<KeyValuePair<string, string>> FormattedOutput = new()
                    {
                        new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Event ID"], EventID),
                        new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Mat Number"], IDMat)
                    };

                    if (Gender.Length > 0)
                    {
                        FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Category"], Category + " " + SelectedLanguageFile.Strings["Kg"] + " " + AgeGroup + " " + SelectedLanguageFile.Strings[Gender]));
                    }
                    else
                    {
                        FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Category"], Category + " " + SelectedLanguageFile.Strings["Kg"] + " " + AgeGroup));
                    }
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings[DisplayMode], "(" + SelectedLanguageFile.Strings[TimerFlag] + ")"));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["White Long Name"] + " ", LongNameWhite + " (" + NationWhite + ")"));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Blue Long Name"] + " " + SelectedLanguageFile.Strings["Blue"], LongNameBlue + " (" + NationBlue + ")"));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["White"] + " " + SelectedLanguageFile.Strings["Score"], IpponWhite + " " + WazaAriWhite + " " + ShidoWhite));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Blue"] + " " + SelectedLanguageFile.Strings["Score"], IpponBlue + " " + WazaAriBlue + " " + ShidoBlue));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Timer"], Minute + ":" + Second));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Osaekomi Timer White"], OsaekomiWhite));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Osaekomi Timer Blue"], OsaekomiBlue));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Golden Score"], GoldenScore));
                    FormattedOutput.Add(new KeyValuePair<string, string>(SelectedLanguageFile.Strings["Winner"], Winner));

                    FormattedData = SelectedLanguageFile.Strings["Event ID"] + ": " + EventID + Environment.NewLine;
                    FormattedData += SelectedLanguageFile.Strings["Mat Number"] + ": " + IDMat + Environment.NewLine;

                    if (Gender.Length > 0)
                    {
                        FormattedData += SelectedLanguageFile.Strings["Category"] + ": " + Category + " " + SelectedLanguageFile.Strings["Kg"] + " " + SelectedLanguageFile.Strings[AgeGroup] + " " + SelectedLanguageFile.Strings[Gender] + " " + Round + Environment.NewLine;
                    }
                    else
                    {
                        FormattedData += SelectedLanguageFile.Strings["Category"] + ": " + Category + " " + SelectedLanguageFile.Strings["Kg"] + " " + SelectedLanguageFile.Strings[AgeGroup] + " " + Round + Environment.NewLine;
                    }
                    FormattedData += SelectedLanguageFile.Strings[DisplayMode] + ": (" + SelectedLanguageFile.Strings[TimerFlag] + ")" + Environment.NewLine;
                    FormattedData += SelectedLanguageFile.Strings["White Long Name"] + ": " + LongNameWhite + " (" + NationWhite + ")" + Environment.NewLine;
                    FormattedData += SelectedLanguageFile.Strings["Blue Long Name"] + ": " + LongNameBlue + " (" + NationBlue + ")" + Environment.NewLine;

                    FormattedData += SelectedLanguageFile.Strings["White"] + ": " + IpponWhite + " " + WazaAriWhite + " " + ShidoWhite + Environment.NewLine;
                    FormattedData += SelectedLanguageFile.Strings["Blue"] + ": " + IpponBlue + " " + WazaAriBlue + " " + ShidoBlue + Environment.NewLine;

                    FormattedData += SelectedLanguageFile.Strings["Timer"] + ": " + Minute + ":" + Second + Environment.NewLine;
                    FormattedData += SelectedLanguageFile.Strings["Osaekomi Timer White"] + ": " + OsaekomiWhite + Environment.NewLine;
                    FormattedData += SelectedLanguageFile.Strings["Osaekomi Timer Blue"] + ": " + OsaekomiBlue + Environment.NewLine;

                    FormattedData += SelectedLanguageFile.Strings["Golden Score"] + ": " + GoldenScore + Environment.NewLine;
                    FormattedData += SelectedLanguageFile.Strings["Winner"] + ": " + Winner + Environment.NewLine;

                    string ReceivedOutput;

                    if (radFormatted.Checked)
                    {
                        ReceivedOutput = System.Text.Json.JsonSerializer.Serialize(FormattedData);
                    }
                    else
                    {
                        ReceivedOutput = System.Text.Json.JsonSerializer.Serialize(ReceivedData);
                    }

                    if (TextControl != null)
                    {
                        TextControl.OnUIThread(() =>
                        {
                            TextControl.Text = ReceivedOutput.ReplaceEx("\\r\\n", Environment.NewLine).Replace("\"", "");
                        });

                        if (Address != null && Address.Trim().Length > 0)
                        {
                            Post(Address, ReceivedOutput);
                        }

                    }
                    else
                    {
                        Console.WriteLine(ReceivedOutput);
                    }

                    TextControl.OnUIThread(() =>
                    {
                        picData.Visible = true;

                        tmrData.Stop();
                        tmrData.Enabled = false;
                        tmrData.Interval = 250;
                        tmrData.Enabled = true;
                        tmrData.Start();

                        tmrClear.Stop();
                        tmrClear.Enabled = false;
                        tmrClear.Interval = 5000;
                        tmrClear.Enabled = true;
                        tmrClear.Start();
                    });
                }
            }
            catch (SocketException e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }

        private async void Post(string Address, string Data)
        {
            using (HttpClient client = new())
            {
                client.BaseAddress = new Uri(Address);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(Address, Data);
                    HttpResponseMessage unused = response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"{DateTime.Now}: Successfully sent data");
                    }
                    else
                    {
                        Debug.WriteLine($"{DateTime.Now}: Could not send data");
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"{DateTime.Now}: Exception attempting to send data: {e}");
                }


            }
        }

        private void radRaw_CheckedChanged(object sender, EventArgs e)
        {
            tabLanguage.Enabled = radFormatted.Checked;
        }

        private void radFormatted_CheckedChanged(object sender, EventArgs e)
        {
            tabLanguage.Enabled = radFormatted.Checked;
        }

        private void tabLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabLanguage.SelectedIndex)
            {
                case 0:
                    SelectedLanguageFile = new LanguageFile(EnglishFilename);
                    break;
                case 1:
                    SelectedLanguageFile = new LanguageFile(JapaneseFilename);
                    break;
                case 2:
                    SelectedLanguageFile = new LanguageFile(GermanFilename);
                    break;
                case 3:
                    SelectedLanguageFile = new LanguageFile(SpanishFilename);
                    break;
                case 4:
                    SelectedLanguageFile = new LanguageFile(FrenchFilename);
                    break;
            }
        }

        private void frmSender_Load(object sender, EventArgs e)
        {
            SelectedLanguageFile = new LanguageFile(EnglishFilename);
        }

        private void tmrClear_Tick(object sender, EventArgs e)
        {
            this.OnUIThread(() =>
            {
                tmrClear.Enabled = false;
                txtOutput.Clear();
            });
        }

        private void tmrData_Tick(object sender, EventArgs e)
        {
            this.OnUIThread(() =>
            {
                tmrData.Enabled = false;
                picData.Visible = false;
            });
        }
    }
}