using Grapevine.Core.Shared;
using PlzGrammarCore;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PlzGrammarConsole
{
    class Program
    {
        public static string GetLocalIp()
        {
            string localIp = "127.0.0.1";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                    break;
                }
            }
            return localIp;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string host = EnvironmentVariable.Get<string>("PLZ_SERVER_HOST", defaultValue: GetLocalIp());
            string port = EnvironmentVariable.Get<string>("PLZ_SERVER_PORT", defaultValue: "8089");
            Console.WriteLine($"Server ({host}, {port})"); 

            PlzGrammarServer server = new PlzGrammarServer(host, port);
            server.Start();

            Thread.Sleep(Timeout.Infinite);

            server.Stop();
        }
    }
}
