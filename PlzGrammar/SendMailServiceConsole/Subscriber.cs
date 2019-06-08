using System.Collections.Generic;

namespace SendMailServiceConsole
{
    class Subscriber
    {
        public string Guid { get; set; }
        public SubscribeTypes SubscribeType { get; set; }
        private Dictionary<SubscribeTypes, string> _idBySubscribeType;

        public string GetTarget()
        {
#if DEBUG
            return "kikiki0611@gmail.com";
#endif
            return _idBySubscribeType[SubscribeType];
        }
    }
}