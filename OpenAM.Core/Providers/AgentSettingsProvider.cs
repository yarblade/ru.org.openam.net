using OpenAM.Core.Entities.Session.Requests;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Providers
{
    public class AgentSettingsProvider : IDataProvider<AgentSettings>
    {
        private readonly IDataProvider<Session> _sessionProvider;

        public AgentSettingsProvider(IDataProvider<Session> sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public AgentSettings Get()
        {
            var session = _sessionProvider.Get();

            return new AgentSettings();
        }
    }
}