using Judo;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    public class UDPListener
    {
        #region Constants

        #endregion

        #region Delegates

        public delegate void DataReceivedEventHandler(object Sender, UDPDataReceivedEventArgs e);

        #endregion

        #region Events

        public event DataReceivedEventHandler DataReceived;

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private int _DatagramPort = 4001;
        //private LanguageFile _SelectedLanguage = null;
        private Task _Task = null;

        private ScoreboardData _ReceivedData = null;

        private string _ProtocolVersion = "";
        private string _DisplayMode = "";

        private string _NationWhite = "";
        private string _IDWhite = "";
        private string _ShortNameWhite = "";
        private string _WRLWhite = "";
        private string _LongNameWhite = "";
        private string _IpponWhite = "";
        private string _WazaAriWhite = "";
        private string _YukoWhite = "";
        private string _ShidoWhite = "";
        private string _OsaekomiWhite = "";
        private string _TeamScoreWhite = "";

        private string _NationBlue = "";
        private string _IDBlue = "";
        private string _ShortNameBlue = "";
        private string _WRLBlue = "";
        private string _LongNameBlue = "";
        private string _IpponBlue = "";
        private string _WazaAriBlue = "";
        private string _YukoBlue = "";
        private string _ShidoBlue = "";
        private string _OsaekomiBlue = "";
        private string _TeamScoreBlue = "";

        private string _EventID = "";
        private string _Gender = "";
        private string _Category = "";
        private string _AgeGroup = "";
        private string _Round = "";
        private string _ContestID = "";
        private string _TimerFlag = "";
        private string _Minute = "";
        private string _Second = "";
        private string _GoldenScore = "";
        private string _Winner = "";
        private string _IDReferee = "";
        private string _IDJudge1 = "";
        private string _IDJudge2 = "";
        private string _IDMat = "";

        #endregion

        #region Properties

        public Task Task
        {
            get
            {
                return _Task;
            }
        }

        public ScoreboardData ReceivedData
        {
            get
            {
                return _ReceivedData;
            }

            set
            {
                _ReceivedData = value;
            }
        }

        public string ProtocolVersion
        {
            get
            {
                return _ProtocolVersion;
            }
            set
            {
                _ProtocolVersion = value;
            }
        }

        public string DisplayMode
        {
            get
            {
                return _DisplayMode;
            }
            set
            {
                _DisplayMode = value;
            }
        }

        public string NationWhite
        {
            get
            {
                return _NationWhite;
            }

            set
            {
                _NationWhite = value;
            }
        }

        public string IDWhite
        {
            get
            {
                return _IDWhite;
            }
            set
            {
                _IDWhite = value;
            }
        }

        public string ShortNameWhite
        {
            get
            {
                return _ShortNameWhite;
            }
            set
            {
                _ShortNameWhite = value;
            }
        }

        public string WRLWhite
        {
            get
            {
                return _WRLWhite;
            }
            set
            {
                _WRLWhite = value;
            }
        }

        public string LongNameWhite
        {
            get
            {
                return _LongNameWhite;
            }
            set
            {
                _LongNameWhite = value;
            }
        }

        public string IpponWhite
        {
            get
            {
                return _IpponWhite;
            }
            set
            {
                _IpponWhite = value;
            }
        }

        public string WazaAriWhite
        {
            get
            {
                return _WazaAriWhite;
            }
            set
            {
                _WazaAriWhite = value;
            }
        }

        public string YukoWhite
        {
            get
            {
                return _YukoWhite;
            }
            set
            {
                _YukoWhite = value;
            }
        }

        public string ShidoWhite
        {
            get
            {
                return _ShidoWhite;
            }
            set
            {
                _ShidoWhite = value;
            }
        }

        public string OsaekomiWhite
        {
            get
            {
                return _OsaekomiWhite;
            }
            set
            {
                _OsaekomiWhite = value;
            }
        }

        public string TeamScoreWhite
        {
            get
            {
                return _TeamScoreWhite;
            }
            set
            {
                _TeamScoreWhite = value;
            }
        }

        public string NationBlue
        {
            get
            {
                return _NationBlue;
            }
            set
            {
                _NationBlue = value;
            }
        }

        public string IDBlue
        {
            get
            {
                return _IDBlue;
            }
            set
            {
                _IDBlue = value;
            }
        }

        public string ShortNameBlue
        {
            get
            {
                return _ShortNameBlue;
            }
            set
            {
                _ShortNameBlue = value;
            }
        }

        public string WRLBlue
        {
            get
            {
                return _WRLBlue;
            }
            set
            {
                _WRLBlue = value;
            }
        }

        public string LongNameBlue
        {
            get
            {
                return _LongNameBlue;
            }
            set
            {
                _LongNameBlue = value;
            }
        }

        public string IpponBlue
        {
            get
            {
                return _IpponBlue;
            }
            set
            {
                _IpponBlue = value;
            }
        }

        public string WazaAriBlue
        {
            get
            {
                return _WazaAriBlue;
            }
            set
            {
                _WazaAriBlue = value;
            }
        }

        public string YukoBlue
        {
            get
            {
                return _YukoBlue;
            }
            set
            {
                _YukoBlue = value;
            }
        }

        public string ShidoBlue
        {
            get
            {
                return _ShidoBlue;
            }
            set
            {
                _ShidoBlue = value;
            }
        }

        public string OsaekomiBlue
        {
            get
            {
                return _OsaekomiBlue;
            }
            set
            {
                _OsaekomiBlue = value;
            }
        }

        public string TeamScoreBlue
        {
            get
            {
                return _TeamScoreBlue;
            }
            set
            {
                _TeamScoreBlue = value;
            }
        }

        public string EventID
        {
            get
            {
                return _EventID;
            }
            set
            {
                _EventID = value;
            }
        }

        public string Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }

        public string AgeGroup
        {
            get
            {
                return _AgeGroup;
            }
            set
            {
                _AgeGroup = value;
            }
        }

        public string Round
        {
            get
            {
                return _Round;
            }
            set
            {
                _Round = value;
            }
        }

        public string ContestID
        {
            get
            {
                return _ContestID;
            }
            set
            {
                _ContestID = value;
            }
        }

        public string TimerFlag
        {
            get
            {
                return _TimerFlag;
            }
            set
            {
                _TimerFlag = value;
            }
        }

        public string Minute
        {
            get
            {
                return _Minute;
            }
            set
            {
                _Minute = value;
            }
        }

        public string Second
        {
            get
            {
                return _Second;
            }
            set
            {
                _Second = value;
            }
        }

        public string GoldenScore
        {
            get
            {
                return _GoldenScore;
            }
            set
            {
                _GoldenScore = value;
            }
        }

        public string Winner
        {
            get
            {
                return _Winner;
            }
            set
            {
                _Winner = value;
            }
        }

        public string IDReferee
        {
            get
            {
                return _IDReferee;
            }
            set
            {
                _IDReferee = value;
            }
        }

        public string IDJudge1
        {
            get
            {
                return _IDJudge1;
            }
            set
            {
                _IDJudge1 = value;
            }
        }

        public string IDJudge2
        {
            get
            {
                return _IDJudge2;
            }
            set
            {
                _IDJudge2 = value;
            }
        }

        public string IDMat
        {
            get
            {
                return _IDMat;
            }
            set
            {
                _IDMat = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public UDPListener(int DatagramPort)
        {
            _DatagramPort = DatagramPort;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public void Start()
        {
            _Task = Task.Run(() =>
            {
                IPEndPoint ListenerEP = new IPEndPoint(IPAddress.Any, _DatagramPort);
                UdpClient UDPProtocol = new UdpClient();

                UDPProtocol.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                UDPProtocol.AllowNatTraversal(true);
                UDPProtocol.EnableBroadcast = true;
                UDPProtocol.Client.Bind(ListenerEP);

                try
                {
                    while (true)
                    {
                        byte[] bytes = UDPProtocol.Receive(ref ListenerEP);

                        _ReceivedData = new ScoreboardData(bytes);

                        Console.WriteLine("Received data");

                        string RawData = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                        OnDataReceived(this, new UDPDataReceivedEventArgs(_ReceivedData));
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    UDPProtocol.Close();
                }
            });
        }

        public virtual void OnDataReceived(object Sender, UDPDataReceivedEventArgs e)
        {
            // This is necessary to allow derived classes to raise the event
            DataReceived?.Invoke(this, e);
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
