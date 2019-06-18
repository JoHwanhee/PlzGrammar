using System.Collections.Generic;

namespace PlzGrammarCore.Model
{
    class Subscriber
    {
        public string Guid { get; set; }
        public SubscribeTypes SubscribeType { get; set; }
        private Dictionary<SubscribeTypes, string> _idBySubscribeType = new Dictionary<SubscribeTypes, string>();

        public string GetTarget()
        {
#if DEBUG
            return "kikiki0611@gmail.com";
#endif
            return _idBySubscribeType[SubscribeType];
        }
    }
}