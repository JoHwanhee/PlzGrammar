using System;
using PlzGrammarCore;

namespace PlzGrammarConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PlzGrammarServer server = new PlzGrammarServer();
            server.Start();
            Console.ReadLine();
            server.Stop();
        }
    }
}
