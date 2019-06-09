using System;

namespace PlzGrammarConsole
{
    class MailService
    {
        private static readonly Lazy<MailService> Lazy =
            new Lazy<MailService>(() => new MailService());

        public static MailService Instance => Lazy.Value;

        private MailService()
        {
        }

        private readonly Gmail _gmail = new Gmail();
        public void Send(Mail mail)
        {
            _gmail.SendEmail(mail);
        }
    }
}