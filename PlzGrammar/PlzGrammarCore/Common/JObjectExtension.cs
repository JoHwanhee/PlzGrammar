using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace PlzGrammarCore.Common
{
    public class JsonUtils
    {
        public static bool TryParse(string jsonString, out JObject result)
        {
            result = null;

            try
            {
                result = JObject.Parse(jsonString);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
