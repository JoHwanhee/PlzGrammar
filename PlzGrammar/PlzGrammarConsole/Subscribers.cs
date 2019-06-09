using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlzGrammarConsole
{
    class Subscribers
    {
        public bool IsLoaded { get; } = false;

        private readonly MongoDb _mongoDb = new MongoDb();
        private List<Subscriber> _subscribers = new List<Subscriber>();
        public List<Subscriber> List => _subscribers;

        private bool _runningRecconect = true;
        private bool _runningSync = false;
        private int _reconnectCount = 0;

        public Subscribers()
        {
            StartToSyncData();
            StartToReconnect();
        }

        private void StartToSyncData()
        {
            Task.Factory.StartNew(DoSyncData);

        }
        private void StartToReconnect()
        {
            Task.Factory.StartNew(CheckReconnect);
        }

        private void DoSyncData()
        {
            _runningSync = true;

            while (_runningSync)
            {
                try
                {
                    Load();
                    
                    Thread.Sleep(200);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _runningSync = false;
                }
            }
        }

        private void CheckReconnect()
        {
            while (_runningRecconect && _reconnectCount < 3)
            {
                try
                {
                    if (!_runningSync)
                    {
                        StartToSyncData();
                        _reconnectCount++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _runningRecconect = false;
                }
            }

            // todo : log
        }

        private void Load()
        {
            _subscribers = _mongoDb.GetSubscribers();
        }

        public void PushSubscriberToDb()
        {
            _mongoDb.Push();
        }
    }
};