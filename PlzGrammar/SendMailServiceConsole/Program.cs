using System;

namespace SendMailServiceConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Subscribers subscribers = new Subscribers();

            Subscriber[] subscriberArray = new Subscriber[subscribers.List.Count];
            subscribers.List.CopyTo(subscriberArray);

            MailRepository mailRepository = new MailRepository();
            ContentsManager contentsManager = new ContentsManager();

            foreach (var subscriber in subscriberArray)
            {
                switch (subscriber.SubscribeType)
                {
                    case SubscribeTypes.None:
                        break;
                    case SubscribeTypes.Email:
                        var toAddress = subscriber.GetTarget();
                        var contents = contentsManager.GetContents(DateTime.Today);

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
