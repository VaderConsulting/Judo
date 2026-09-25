using System;
using System.Net;
using System.Threading.Tasks;

using Replay;

namespace Replay
{
    /// <summary>
    /// Example program showing how to use the PcapReplay class
    /// </summary>
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Judo Scoreboard PCAP Replay Utility");
            Console.WriteLine("==================================");

            try
            {
                DebugWrite("Getting available network interfaces...");
                List<NetworkInterfaceInfo> interfaces = PcapReplay.GetAvailableInterfaces();
                if (interfaces.Count == 0)
                {
                    Console.WriteLine("No network interfaces found.");
                    return;
                }

                Console.WriteLine("\nAvailable Network Interfaces:");
                for (int i = 0; i < interfaces.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {interfaces[i].Description}");
                    foreach (string address in interfaces[i].Addresses)
                    {
                        Console.WriteLine($"   - {address}");
                    }
                }

                Console.Write("\nSelect interface (number): ");
                string? interfaceInput = Console.ReadLine();
                if (!int.TryParse(interfaceInput, out int interfaceIndex)
                    || interfaceIndex < 1
                    || interfaceIndex > interfaces.Count)
                {
                    Console.WriteLine("Invalid selection. Using first interface.");
                    interfaceIndex = 1;
                }

                NetworkInterfaceInfo selectedInterface = interfaces[interfaceIndex - 1];
                Console.WriteLine($"Selected: {selectedInterface.Description}");

                Console.Write("\nEnter path to PCAP file: ");
                string? rawPcapPath = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(rawPcapPath))
                {
                    Console.WriteLine("No file specified. Exiting.");
                    return;
                }

                // Strip any surrounding quotes and whitespace
                string pcapFilePath = rawPcapPath.Trim().Trim('"');

                if (!System.IO.File.Exists(pcapFilePath))
                {
                    Console.WriteLine($"File not found: {pcapFilePath}");
                    return;
                }

                PcapReplay pcapReplay = new PcapReplay
                {
                    PcapFilePath = pcapFilePath,
                    SelectedInterfaceName = selectedInterface.Name,
                    DestinationIP = IPAddress.Broadcast,
                    DestinationPort = 8888
                };

                Console.Write("\nEnter destination IP (default: 255.255.255.255 for broadcast): ");
                string? destinationIp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(destinationIp))
                {
                    if (IPAddress.TryParse(destinationIp, out IPAddress ip))
                    {
                        pcapReplay.DestinationIP = ip;
                    }
                    else
                    {
                        Console.WriteLine("Invalid IP address. Using broadcast.");
                        pcapReplay.DestinationIP = IPAddress.Broadcast;
                    }
                }

                Console.Write($"Enter destination port (default: {pcapReplay.DestinationPort}): ");
                string? portInput = Console.ReadLine();
                if (int.TryParse(portInput, out int port) && port > 0 && port < 65536)
                {
                    pcapReplay.DestinationPort = port;
                }

                Console.Write("Preserve original timing between packets? (Y/n): ");
                string? timingInput = Console.ReadLine();
                pcapReplay.PreserveOriginalTiming = !timingInput.Trim().Equals("n", StringComparison.OrdinalIgnoreCase);

                if (pcapReplay.PreserveOriginalTiming)
                {
                    Console.Write("Playback speed factor (e.g., 1.0 for normal, 2.0 for double speed): ");
                    string? speedInput = Console.ReadLine();
                    if (double.TryParse(speedInput, out double speedFactor) && speedFactor > 0)
                    {
                        pcapReplay.SpeedFactor = speedFactor;
                    }
                }

                Console.Write("Loop playback? (y/N): ");
                string? loopInput = Console.ReadLine();
                pcapReplay.LoopPlayback = loopInput.Trim().Equals("y", StringComparison.OrdinalIgnoreCase);

                Console.WriteLine("\nAnalyzing PCAP file...");
                PcapFileInfo fileInfo;
                try
                {
                    fileInfo = pcapReplay.AnalyzePcapFile();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DEBUG] Error analyzing PCAP: {ex}");
                    return;
                }

                Console.WriteLine($"Total Packets: {fileInfo.TotalPacketCount}");
                Console.WriteLine($"UDP Packets:   {fileInfo.UdpPacketCount}");
                Console.WriteLine($"Duration:      {fileInfo.Duration}");
                Console.WriteLine($"Endpoints:     {fileInfo.UniqueUdpEndpoints.Count}");
                foreach (string endpoint in fileInfo.UniqueUdpEndpoints)
                {
                    Console.WriteLine($"  - {endpoint}");
                }

                pcapReplay.PacketSent += (sender, e) =>
                {
                    string broadcastIndicator = e.WasBroadcast ? " [BROADCAST]" : string.Empty;
                    Console.WriteLine($"Sent packet: {e.PacketSize} bytes from port {e.SourcePort} to port {e.DestinationPort}{broadcastIndicator} [Original: {e.OriginalTimestamp}]");
                };

                pcapReplay.PlaybackCompleted += (sender, e) => Console.WriteLine("Playback completed.");

                pcapReplay.PlaybackError += (sender, e) => Console.WriteLine($"Error during playback: {e.Exception}");

                Console.WriteLine("\nStarting playback...");
                Console.WriteLine($"Target: {pcapReplay.DestinationIP}:{pcapReplay.DestinationPort}");
                Console.WriteLine("Press any key to stop...");

                Task playbackTask = null!;
                try
                {
                    playbackTask = pcapReplay.StartReplayAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DEBUG] Failed to start replay: {ex}");
                    return;
                }

                Console.ReadKey(true);

                DebugWrite("Stopping playback...");
                pcapReplay.StopReplay();

                try
                {
                    await playbackTask;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DEBUG] Playback task error: {ex}");
                }

                Console.WriteLine("Playback stopped. Press any key to exit.");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FATAL] Unhandled exception: {ex}");
            }
        }

        private static void DebugWrite(string message)
        {
            Console.WriteLine($"[DEBUG] {message}");
        }
    }
}