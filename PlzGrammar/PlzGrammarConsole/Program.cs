using System;

namespace PlzGrammarConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PlzGrammarServer server =new PlzGrammarServer();
            server.Start();
            Console.ReadLine();
            server.Stop();
        }
    }
}
