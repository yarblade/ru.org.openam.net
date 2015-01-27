using System;
using OpenAM.Core.Entities.Policy;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Providers
{
    public class PolicyProvider : IPolicyProvider
    {
        public Policy GetPolicy(Uri url, AgentSettings settings)
        {
            return new Policy();
        }
    }
}
