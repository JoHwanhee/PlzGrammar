using System.Collections.Generic;

namespace SendMailServiceConsole
{
    class Subscriber
    {
        private string Guid;
        private SubscribeTypes subscribeType;
        private Dictionary<SubscribeTypes, string> _idBySubscribeType;
    }
}