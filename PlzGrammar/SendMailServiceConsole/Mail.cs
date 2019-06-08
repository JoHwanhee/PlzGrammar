namespace SendMailServiceConsole
{
    class Mail
    {
        public MailProperties Properties;
        private readonly MailService _mailService = MailService.Instance;

        public void Send()
        {
            _mailService.Send(this);
        }

        public static Mail New()
        {
            var mail = new Mail
            {
                Properties = new MailProperties
                {
                    Subject = "Test",
                    Contents = "Test",
                    From = "kikiki0611@gmail.com",
                    To = "kikiki0611@gmail.com"
                }
            };
            
            return mail;
        }

        public static void Load()
        {

        }
    }
}