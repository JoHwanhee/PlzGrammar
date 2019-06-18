using System.Collections.Generic;
using PlzGrammarCore.Model;

namespace PlzGrammarCore.DataBase
{
    class MailRepository
    {
        private readonly List<Mail> _mails = new List<Mail>();

        public void SendAllMails()
        {
           
            foreach (var mail in _mails)
            {
                mail.Send();
            }
        }

        public void Add(Mail mail)
        {
            _mails.Add(mail);
        }
    }
}