using Grapevine.Core.Shared;
using PlzGrammarCore;
using System;
using System.Threading;

namespace PlzGrammarConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string host = EnvironmentVariable.Get<string>("PLZ_SERVER_HOST", defaultValue: "127.0.0.1");
            string port = EnvironmentVariable.Get<string>("PLZ_SERVER_PORT", defaultValue: "8089");
            Console.WriteLine($"Server ({host}, {port})");

            PlzGrammarServer server = new PlzGrammarServer(host, port);
            server.Start();

            Thread.Sleep(Timeout.Infinite);

            server.Stop();
        }
    }
}
