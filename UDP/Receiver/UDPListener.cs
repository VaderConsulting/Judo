using Judo;

using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Utilities;

namespace Receiver.Core
{
    public class UDPListener
    {
        public delegate void DataReceivedEventHandler(object Sender, UDPDataReceivedEventArgs e);

        #region Events

        public event EventHandler<UDPDataReceivedEventArgs> DataReceived;

        #endregion

        #region Fields

        private IProtocolFactory _protocolFactory;
        private string _AgeGroup = "";
        private string _Category = "";
        private string _ContestID = "";
        private int _DatagramPort = 5000;  // Changed from 4001 to 5000
        private string _DisplayMode = "";
        private string _EventID = "";
        private string _Gender = "";
        private string _GoldenScore = "";
        private string _IDBlue = "";
        private string _IDJudge1 = "";
        private string _IDJudge2 = "";
        private string _IDMat = "";
        private string _IDReferee = "";
        private string _IDWhite = "";
        private string _IpponBlue = "";
        private string _IpponWhite = "";
        private string _LongNameBlue = "";
        private string _LongNameWhite = "";
        private string _Minute = "";
        private string _NationBlue = "";
        private string _NationWhite = "";
        private string _OsaekomiBlue = "";
        private string _OsaekomiWhite = "";
        private string _ProtocolVersion = "";
        private ScoreboardData _ReceivedData = null;
        private string _Round = "";
        private string _Second = "";
        private string _ShidoBlue = "";
        private string _ShidoWhite = "";
        private string _ShortNameBlue = "";
        private string _ShortNameWhite = "";
        private Task _Task = null;
        private string _TeamScoreBlue = "";
        private string _TeamScoreWhite = "";
        private string _TimerFlag = "";
        private string _WazaAriBlue = "";
        private string _WazaAriWhite = "";
        private string _Winner = "";
        private string _WRLBlue = "";
        private string _WRLWhite = "";
        private string _YukoBlue = "";
        private string _YukoWhite = "";

        #endregion

        #region Properties

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

        public Task Task
        {
            get
            {
                return _Task;
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

        #endregion

        #region Constructors

        public UDPListener(int DatagramPort, IProtocolFactory protocolFactory)
        {
            _DatagramPort = DatagramPort;
            _protocolFactory = protocolFactory;
        }

        // Keep the old constructor for backward compatibility
        public UDPListener(int DatagramPort)
        {
            _DatagramPort = DatagramPort;

            // Don't create ProtocolFactory here - it must be injected
            //_protocolFactory = new ProtocolFactory();
        }

        #endregion

        #region Public Methods

        public void SetProtocolFactory(IProtocolFactory protocolFactory)
        {
            _protocolFactory = protocolFactory;
        }

        public virtual void OnDataReceived(object Sender, UDPDataReceivedEventArgs e)
        {
            DataReceived?.Invoke(this, e);
        }

        public void Start()
        {
            if (_protocolFactory == null)
            {
                throw new InvalidOperationException("ProtocolFactory must be set before starting the listener.");
            }

            Debug.WriteLine($"Starting UDP listener on port {_DatagramPort}");

            _Task = Task.Run(() =>
            {
                IPEndPoint ListenerEP = new IPEndPoint(IPAddress.Any, _DatagramPort);
                UdpClient UDPProtocol = new UdpClient();

                Debug.WriteLine($"Binding to {ListenerEP}");

                try
                {
                    UDPProtocol.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    UDPProtocol.AllowNatTraversal(true);
                    UDPProtocol.EnableBroadcast = true;
                    UDPProtocol.Client.Bind(ListenerEP);

                    Debug.WriteLine("UDP listener started, waiting for messages...");

                    while (true)
                    {
                        // Add timeout to show listener is alive
                        if (UDPProtocol.Client.Poll(5000000, SelectMode.SelectRead)) // 5 seconds
                        {
                            byte[] bytes = UDPProtocol.Receive(ref ListenerEP);
                            Debug.WriteLine($"Received {bytes.Length} bytes from {ListenerEP}");

                            string preview = Encoding.UTF8.GetString(bytes);
                            Debug.WriteLine($"Message preview: {preview.Substring(0, Math.Min(100, preview.Length))}...");

                            try
                            {
                                IScoreboardProtocol protocol = _protocolFactory.CreateProtocol(bytes);
                                if (protocol != null)
                                {
                                    _ReceivedData = new ScoreboardData(protocol);

                                    if (_ReceivedData != null)
                                    {

                                        Debug.WriteLine($"Successfully parsed message - DisplayMode: {_ReceivedData.DisplayMode}");

                                        OnDataReceived(this, new UDPDataReceivedEventArgs(_ReceivedData));
                                    }
                                }
                            }
                            catch (InvalidOperationException ex)
                            {
                                Debug.WriteLine($"Non-scoreboard message: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Error processing data: {ex.Message}");
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Still listening... (no data received in last 5 seconds)");
                        }
                    }
                }
                catch (SocketException e)
                {
                    Debug.WriteLine($"Socket error: {e}");
                }
                finally
                {
                    UDPProtocol.Close();
                }
            });
        }        
        
        #endregion

    }
}