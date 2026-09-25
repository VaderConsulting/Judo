using Receiver;

using System.Threading;

namespace EuroJudoListener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UDPListener Listener = new UDPListener(50228);

            Listener.Start();

            while (true)
            {
                Thread.Sleep(5);
            }
        }
    }
}
