using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;
using PacketDotNet.Ieee80211;

namespace Replay
{
    /// <summary>
    /// Reads a Wireshark capture file and replays UDP packets over a selected network interface
    /// </summary>
    public class PcapReplay
    {
        #region Fields

        private string _pcapFilePath;
        private string _selectedInterfaceName;
        private IPAddress _destinationIP;
        private int _destinationPort;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _preserveOriginalTiming = true;
        private bool _loopPlayback = false;
        private double _speedFactor = 1.0;

        #endregion

        #region Properties

        /// <summary>
        /// Path to the PCAP file to replay
        /// </summary>
        public string PcapFilePath
        {
            get
            {
                return _pcapFilePath;
            }
            set
            {
                _pcapFilePath = value;
            }
        }

        /// <summary>
        /// Name of the network interface to use for sending packets
        /// </summary>
        public string SelectedInterfaceName
        {
            get
            {
                return _selectedInterfaceName;
            }
            set
            {
                _selectedInterfaceName = value;
            }
        }

        /// <summary>
        /// Destination IP address for replayed packets
        /// </summary>
        public IPAddress DestinationIP
        {
            get
            {
                return _destinationIP;
            }
            set
            {
                _destinationIP = value;
            }
        }

        /// <summary>
        /// Destination port for replayed packets
        /// </summary>
        public int DestinationPort
        {
            get
            {
                return _destinationPort;
            }
            set
            {
                _destinationPort = value;
            }
        }

        /// <summary>
        /// Whether to preserve the original timing between packets
        /// </summary>
        public bool PreserveOriginalTiming
        {
            get
            {
                return _preserveOriginalTiming;
            }
            set
            {
                _preserveOriginalTiming = value;
            }
        }

        /// <summary>
        /// Whether to loop the playback continuously
        /// </summary>
        public bool LoopPlayback
        {
            get
            {
                return _loopPlayback;
            }
            set
            {
                _loopPlayback = value;
            }
        }

        /// <summary>
        /// Speed factor for playback (e.g., 2.0 = twice as fast)
        /// </summary>
        public double SpeedFactor
        {
            get
            {
                return _speedFactor;
            }
            set
            {
                _speedFactor = Math.Max(0.1, value);
            } // Prevent extremely slow playback
        }

        #endregion

        #region Events

        /// <summary>
        /// Event raised when a packet is sent
        /// </summary>
        public event EventHandler<PacketSentEventArgs> PacketSent;

        /// <summary>
        /// Event raised when playback completes
        /// </summary>
        public event EventHandler PlaybackCompleted;

        /// <summary>
        /// Event raised when an error occurs during playback
        /// </summary>
        public event EventHandler<ErrorEventArgs> PlaybackError;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the PcapReplay class
        /// </summary>
        public PcapReplay()
        {
            _destinationIP = IPAddress.Broadcast; // Default to broadcast (255.255.255.255)
            _destinationPort = 5000; // Default port for your UDP listener
        }

        /// <summary>
        /// Creates a new instance of the PcapReplay class with specified file and interface
        /// </summary>
        /// <param name="pcapFilePath">Path to the PCAP file</param>
        /// <param name="interfaceName">Name of the network interface to use</param>
        /// <param name="destinationIP">Destination IP address</param>
        /// <param name="destinationPort">Destination port</param>
        public PcapReplay(string pcapFilePath, string interfaceName, IPAddress destinationIP, int destinationPort)
        {
            _pcapFilePath = pcapFilePath;
            _selectedInterfaceName = interfaceName;
            _destinationIP = destinationIP;
            _destinationPort = destinationPort;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of available network interfaces
        /// </summary>
        /// <returns>List of available network interfaces</returns>
        public static List<NetworkInterfaceInfo> GetAvailableInterfaces()
        {
            List<NetworkInterfaceInfo> result = new List<NetworkInterfaceInfo>();

            try
            {
                // Get all devices
                CaptureDeviceList devices = CaptureDeviceList.Instance;

                foreach (ILiveDevice? device in devices)
                {
                    if (device is LibPcapLiveDevice liveDevice)
                    {
                        // Add device information to the list
                        NetworkInterfaceInfo info = new NetworkInterfaceInfo
                        {
                            Name = liveDevice.Name,
                            Description = liveDevice.Description,
                            Addresses = liveDevice.Addresses
                                .Where(a => a.Addr?.type == Sockaddr.AddressTypes.AF_INET_AF_INET6)
                                .Select(a => a.Addr.ToString())
                                .ToList()
                        };

                        result.Add(info);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting network interfaces: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Starts replaying packets from the PCAP file
        /// </summary>
        /// <returns>Task representing the replay operation</returns>
        public Task StartReplayAsync()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            return Task.Run(() => ReplayPcapFile(_cancellationTokenSource.Token), _cancellationTokenSource.Token);
        }

        /// <summary>
        /// Stops the current replay operation
        /// </summary>
        public void StopReplay()
        {
            _cancellationTokenSource?.Cancel();
        }

        /// <summary>
        /// Analyzes the PCAP file to extract relevant statistics
        /// </summary>
        /// <returns>Information about the PCAP file contents</returns>
        public PcapFileInfo AnalyzePcapFile()
        {
            PcapFileInfo info = new PcapFileInfo();

            try
            {
                using (CaptureFileReaderDevice reader = new CaptureFileReaderDevice(_pcapFilePath))
                {
                    reader.Open();

                    // Read the first packet to get start time
                    PacketCapture packetCapture;
                    GetPacketStatus status = reader.GetNextPacket(out packetCapture);

                    if (status == GetPacketStatus.PacketRead)
                    {
                        // Convert PacketCapture to RawCapture to get the data we need
                        RawCapture rawPacket = packetCapture.GetPacket();
                        info.StartTime = rawPacket.Timeval.Date;
                        info.UdpPacketCount = 0;
                        info.TotalPacketCount = 0;

                        // Reset to beginning
                        reader.Close();
                        reader.Open();

                        // Analyze all packets
                        while ((status = reader.GetNextPacket(out packetCapture)) == GetPacketStatus.PacketRead)
                        {
                            // Rename here to avoid rawPacket collision
                            RawCapture capture = packetCapture.GetPacket();
                            info.TotalPacketCount++;

                            // Parse the packet using PacketDotNet
                            Packet packet = Packet.ParsePacket(capture.LinkLayerType, capture.Data);

                            // Try IPv4 first
                            IPv4Packet ipPacket = packet.Extract<IPv4Packet>();
                            if (ipPacket == null)
                            {
                                // Not IPv4 → skip
                                continue;
                            }

                            // Then try UDP
                            UdpPacket udpPacket = packet.Extract<UdpPacket>();
                            if (udpPacket == null)
                            {
                                // Not UDP → skip
                                continue;
                            }

                            // We know it’s UDP over IPv4
                            info.UdpPacketCount++;

                            // Record last packet time
                            info.EndTime = capture.Timeval.Date;

                            // Build and record unique endpoint
                            string endpoint = $"{ipPacket.SourceAddress}:{udpPacket.SourcePort} -> " +
                                              $"{ipPacket.DestinationAddress}:{udpPacket.DestinationPort}";
                            if (!info.UniqueUdpEndpoints.Contains(endpoint))
                            {
                                info.UniqueUdpEndpoints.Add(endpoint);
                            }
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                OnPlaybackError(new ErrorEventArgs(ex));
            }

            return info;
        }

        private void ReplayPcapFile(CancellationToken cancellationToken)
        {
            try
            {
                // Find the specified interface
                LibPcapLiveDevice sendDevice = null;
                foreach (ILiveDevice? device in CaptureDeviceList.Instance)
                {
                    if (device is LibPcapLiveDevice liveDevice && liveDevice.Name == _selectedInterfaceName)
                    {
                        sendDevice = liveDevice;
                        break;
                    }
                }

                if (sendDevice == null)
                {
                    throw new ArgumentException($"Interface '{_selectedInterfaceName}' not found");
                }

                // Open the sending device
                sendDevice.Open();

                // Setup UDP client for sending packets
                using (UdpClient udpClient = new UdpClient())
                {
                    // Continue playback until cancelled or completed (and not looping)
                    do
                    {
                        using (CaptureFileReaderDevice reader = new CaptureFileReaderDevice(_pcapFilePath))
                        {
                            reader.Open();
                            DateTime? previousPacketTime = null;

                            // Get the first packet with the new API
                            PacketCapture packetCapture;
                            GetPacketStatus status = reader.GetNextPacket(out packetCapture);

                            // Read and replay each packet
                            while (status == GetPacketStatus.PacketRead)
                            {
                                // Check for cancellation 
                                if (cancellationToken.IsCancellationRequested)
                                {
                                    break;
                                }

                                // Convert the PacketCapture to a RawCapture
                                RawCapture rawPacket = packetCapture.GetPacket();

                                // Parse the packet
                                Packet packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

                                // Try to extract the UDP packet using the Extract method
                                UdpPacket udpPacket = packet.Extract<UdpPacket>();
                                if (udpPacket != null)
                                {
                                    // Apply timing delay if preserving original timing
                                    if (_preserveOriginalTiming && previousPacketTime != null)
                                    {
                                        TimeSpan delay = rawPacket.Timeval.Date - previousPacketTime.Value;
                                        // Apply speed factor
                                        int delayMs = (int)(delay.TotalMilliseconds / _speedFactor);

                                        if (delayMs > 0)
                                        {
                                            Task.Delay(delayMs, cancellationToken).Wait(cancellationToken);
                                        }
                                    }

                                    // Remember timestamp for next packet timing
                                    previousPacketTime = rawPacket.Timeval.Date;

                                    // Extract the payload
                                    byte[] payload = udpPacket.PayloadData;

                                    if (payload != null && payload.Length > 0)
                                    {
                                        try
                                        {
                                            // Extract original destination from the packet
                                            // Use the Extract method instead of direct casting
                                            IPv4Packet ipPacket = packet.Extract<PacketDotNet.IPv4Packet>();
                                            bool wasOriginallyBroadcast = false;

                                            if (ipPacket != null)
                                            {
                                                // Check if original packet was a broadcast
                                                string destIp = ipPacket.DestinationAddress.ToString();
                                                wasOriginallyBroadcast = destIp.EndsWith(".255") ||
                                                                         destIp == "255.255.255.255";
                                            }

                                            // Handle based on whether it was a broadcast or not
                                            if (wasOriginallyBroadcast)
                                            {
                                                // For broadcast packets, use broadcast option
                                                udpClient.EnableBroadcast = true;

                                                // Use the specified broadcast address
                                                // This could be 255.255.255.255 or a subnet broadcast
                                                // Send to the specified destination port
                                                //udpClient.Send(payload, payload.Length, new IPEndPoint(_destinationIP, _destinationPort));

                                                // Send to the original destination port
                                                int targetPort = udpPacket.DestinationPort;
                                                var endpoint = new IPEndPoint(_destinationIP, targetPort);
                                                udpClient.Send(payload, payload.Length, endpoint);
                                            }
                                            else
                                            {
                                                // For unicast packets, just send to destination
                                                udpClient.Send(payload, payload.Length, new IPEndPoint(_destinationIP, _destinationPort));
                                            }

                                            // Raise packet sent event
                                            OnPacketSent(new PacketSentEventArgs(
                                                payload.Length,
                                                rawPacket.Timeval.Date,
                                                udpPacket.SourcePort,
                                                udpPacket.DestinationPort,
                                                payload,
                                                wasOriginallyBroadcast
                                            ));
                                        }
                                        catch (Exception ex)
                                        {
                                            OnPlaybackError(new ErrorEventArgs(ex));
                                        }
                                    }
                                }

                                // Get the next packet
                                status = reader.GetNextPacket(out packetCapture);
                            }

                            reader.Close();

                            // Check if playback was stopped by cancellation
                            if (cancellationToken.IsCancellationRequested)
                            {
                                break;
                            }
                        }
                    } while (_loopPlayback && !cancellationToken.IsCancellationRequested);
                }

                sendDevice.Close();

                // Raise completion event if not cancelled
                if (!cancellationToken.IsCancellationRequested)
                {
                    OnPlaybackCompleted(EventArgs.Empty);
                }
            }
            catch (OperationCanceledException)
            {
                // Normal cancellation, no need to report error
            }
            catch (Exception ex)
            {
                OnPlaybackError(new ErrorEventArgs(ex));
            }
        }

        protected virtual void OnPacketSent(PacketSentEventArgs e)
        {
            PacketSent?.Invoke(this, e);
        }

        protected virtual void OnPlaybackCompleted(EventArgs e)
        {
            PlaybackCompleted?.Invoke(this, e);
        }

        protected virtual void OnPlaybackError(ErrorEventArgs e)
        {
            PlaybackError?.Invoke(this, e);
        }

        #endregion
    }

    #region Support Classes

    /// <summary>
    /// Contains information about a network interface
    /// </summary>
    public class NetworkInterfaceInfo
    {
        /// <summary>
        /// System name of the interface
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Human-readable description of the interface
        /// </summary>
        public string Description
        {
            get; set;
        }

        /// <summary>
        /// IP addresses associated with the interface
        /// </summary>
        public List<string> Addresses { get; set; } = new List<string>();

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        public override string ToString()
        {
            return $"{Description} ({Name})";
        }
    }

    /// <summary>
    /// Contains information about a sent packet
    /// </summary>
    public class PacketSentEventArgs : EventArgs
    {
        /// <summary>
        /// Size of the packet in bytes
        /// </summary>
        public int PacketSize
        {
            get;
        }

        /// <summary>
        /// Timestamp of the original packet
        /// </summary>
        public DateTime OriginalTimestamp
        {
            get;
        }

        /// <summary>
        /// Source port of the original packet
        /// </summary>
        public ushort SourcePort
        {
            get;
        }

        /// <summary>
        /// Destination port of the original packet
        /// </summary>
        public ushort DestinationPort
        {
            get;
        }

        /// <summary>
        /// Payload data of the packet
        /// </summary>
        public byte[] Payload
        {
            get;
        }

        /// <summary>
        /// Whether the original packet was a broadcast packet
        /// </summary>
        public bool WasBroadcast
        {
            get;
        }

        /// <summary>
        /// Creates a new instance of the PacketSentEventArgs class
        /// </summary>
        public PacketSentEventArgs(int packetSize, DateTime originalTimestamp, ushort sourcePort, ushort destinationPort, byte[] payload, bool wasBroadcast = false)
        {
            PacketSize = packetSize;
            OriginalTimestamp = originalTimestamp;
            SourcePort = sourcePort;
            DestinationPort = destinationPort;
            Payload = payload;
            WasBroadcast = wasBroadcast;
        }
    }

    /// <summary>
    /// Contains information about a PCAP file
    /// </summary>
    public class PcapFileInfo
    {
        /// <summary>
        /// Start time of the first packet in the file
        /// </summary>
        public DateTime StartTime
        {
            get; set;
        }

        /// <summary>
        /// End time of the last packet in the file
        /// </summary>
        public DateTime EndTime
        {
            get; set;
        }

        /// <summary>
        /// Total number of packets in the file
        /// </summary>
        public int TotalPacketCount
        {
            get; set;
        }

        /// <summary>
        /// Number of UDP packets in the file
        /// </summary>
        public int UdpPacketCount
        {
            get; set;
        }

        /// <summary>
        /// Unique UDP endpoints found in the file
        /// </summary>
        public List<string> UniqueUdpEndpoints { get; set; } = new List<string>();

        /// <summary>
        /// Duration of the capture
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return EndTime - StartTime;
            }
        }
    }

    /// <summary>
    /// Contains information about an error that occurred during playback
    /// </summary>
    public class ErrorEventArgs : EventArgs
    {
        /// <summary>
        /// The exception that occurred
        /// </summary>
        public Exception Exception
        {
            get;
        }

        /// <summary>
        /// Creates a new instance of the ErrorEventArgs class
        /// </summary>
        public ErrorEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }

    #endregion
}