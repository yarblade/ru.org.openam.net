using System;
using OpenAM.Core.Entities;
using OpenAM.Core.Entities.Policy;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Providers
{
    public interface IPolicyProvider
    {
        Policy GetPolicy(Uri url, AgentSettings settings);
    }
}