using System;

namespace SendMailServiceConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MailRepository mailRepository = new MailRepository();
            mailRepository.Add(Mail.New());
            mailRepository.SendAllMails();
        }
    }
}
