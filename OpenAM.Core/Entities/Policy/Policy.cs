using System.Collections.Generic;

namespace OpenAM.Core.Entities.Policy
{
    public class Policy
    {
        public string[] AllowedMethods { get; set; }

        public IDictionary<string, string> Properties { get; set; }
    }
}
