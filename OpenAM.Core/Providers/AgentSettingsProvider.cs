using OpenAM.Core.Entities.Naming;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Providers
{
    public class AgentSettingsProvider : IAgentSettingsProvider
    {
        private readonly ISessionProvider _sessionProvider;

        public AgentSettingsProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public AgentSettings Get(Naming naming)
        {
            var session = _sessionProvider.GetSession(naming);

            return new AgentSettings();
        }
    }
}
