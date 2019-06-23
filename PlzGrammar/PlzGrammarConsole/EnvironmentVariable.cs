using System;

namespace PlzGrammarConsole
{
    class EnvironmentVariable
    {
        public static T Get<T>(string key, string defaultValue="")
        {
            if(string.IsNullOrWhiteSpace(defaultValue))
            {
                defaultValue = "127.0.0.1";
            }

            string host = Environment.GetEnvironmentVariable(key);

            if (string.IsNullOrWhiteSpace(host))
            {
                Environment.SetEnvironmentVariable(key, defaultValue);
                host = Environment.GetEnvironmentVariable(key);
            }
            
            return Converter.ChangeType<T>(host);
        }
    }
}