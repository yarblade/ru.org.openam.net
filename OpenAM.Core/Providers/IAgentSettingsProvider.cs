using OpenAM.Core.Entities;
using OpenAM.Core.Entities.Naming;
using OpenAM.Core.Settings;

namespace OpenAM.Core
{
    public interface IAgentSettingsProvider
    {
        AgentSettings Get(Naming naming);
    }
}