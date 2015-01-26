using System.Collections.Generic;

namespace OpenAM.Core.Entities.Session
{
    public class Session
    {
        public Session(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }

        public string UserId { get; set; }

        public string Host { get; set; }

        public IDictionary<string, string> Properties { get; set; }
    }
}
