using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Extensions;

namespace ConsoleTest
{
    internal class Program
    {
        //private const int DatagramPort = 5000;

        public enum DataType
        {
            Scoreboard = 0
        }

        private static void StartSender(DataType type, int DatagramPort = 5000)
        {
            IPEndPoint SenderEP = new IPEndPoint(IPAddress.Broadcast, DatagramPort);

            switch (type)
            {
                case DataType.Scoreboard:
                    {
                        UdpClient sender = new UdpClient();

                        sender.MulticastLoopback = true;
                        sender.ExclusiveAddressUse = false;
                        sender.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                        sender.Client.Bind(SenderEP);

                        //sender.AllowNatTraversal(true);
                        //sender.EnableBroadcast = true;



                        //sender.Client.Connect(SenderEP);

                        try
                        {
                            while (true)
                            {
                                Console.WriteLine("sending...");
                                string Message = "Test string";
                                sender.Send(Message.ToByteArray(), Message.Length, SenderEP);


                                Console.WriteLine($"Sent message: " + Message);
                            }
                        }
                        catch (SocketException e)
                        {
                            Console.WriteLine(e);
                        }
                        finally
                        {
                            sender.Close();
                        }

                        break;
                    }
            }
        }

        private static void Main()
        {
            StartSender(DataType.Scoreboard, 5000);
        }
    }
}
