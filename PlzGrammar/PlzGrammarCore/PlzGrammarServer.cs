using System;
using Grapevine.Core.Server;
using PlzGrammarCore.DataBase;
using PlzGrammarCore.Model;

namespace PlzGrammarCore
{
    public class PlzGrammarServer
    {
        private RestServer _restServer;
        private string _host;
        private string _port;

        public PlzGrammarServer(string host, string port)
        {
            _host = host;
            _port = port;
        }

        public void Start()
        {
            SendMail();

            _restServer?.Stop();

            if (_restServer == null)
            {
                _restServer = new RestServer
                {
                    Host = _host,
                    Port = _port
                };
            }

            _restServer.LogToConsole().Start();
        }

        public void Stop()
        {
            _restServer.Stop();
            _restServer.Dispose();
        }

        private void SendMail()
        {
            Subscribers subscribers = new Subscribers();

            Subscriber[] subscriberArray = new Subscriber[subscribers.List.Count];
            subscribers.List.CopyTo(subscriberArray);

            MailRepository mailRepository = new MailRepository();
            ContentsManager contentsManager = new ContentsManager();

            foreach (Subscriber subscriber in subscriberArray)
            {
                switch (subscriber.SubscribeType)
                {
                    case SubscribeTypes.None:
                        break;
                    case SubscribeTypes.Email:
                        string toAddress = subscriber.GetTarget();
                        string contents = contentsManager.GetContents(DateTime.Today);

                        mailRepository.Add(Mail.New(contents, toAddress));
                        break;
                    case SubscribeTypes.Kakaotalk:
                        break;
                    case SubscribeTypes.Telegram:
                        break;
                    case SubscribeTypes.Twitter:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            mailRepository.SendAllMails();
        }
    }
}
