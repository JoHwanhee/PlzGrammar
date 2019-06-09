using SendMailServiceConsole;

namespace PlzGrammarConsole
{
    class Mail
    {
        public MailProperties Properties;
        private readonly MailService _mailService = MailService.Instance;

        public void Send()
        {
            _mailService.Send(this);
        }

        public static Mail New(string contents, string to)
        {
            var mail = new Mail
            {
                Properties = new MailProperties
                {
                    Subject = "Test",
                    Contents = contents,
                    From = "kikiki0611@gmail.com",
                    To = to
                }
            };
            
            return mail;
        }

        public static void Load()
        {

        }
    }
}