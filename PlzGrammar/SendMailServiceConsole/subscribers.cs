using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SendMailServiceConsole
{
    internal class Subscribers
    {
        public bool IsLoaded { get; } = false;

        private readonly MongoDb _mongoDb = new MongoDb();
        private List<Subscriber> _subscribers = new List<Subscriber>();
        public List<Subscriber> List => _subscribers;

        private bool _running = false;

        private Subscribers()
        {
        }

        private void StartSync()
        {
            Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            _running = true;

            while (_running)
            {
                Thread.Sleep(200);
            }
        }

        private void Load()
        {
            _subscribers = _mongoDb.GetSubscribers();
        }
    }
};