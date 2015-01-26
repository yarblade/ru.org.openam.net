using OpenAM.Core.Entities.Auth;

namespace OpenAM.Core.Settings
{
    public class SessionProviderSettings
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string IndexName { get; set; }

        public AuthType AuthType { get; set; }

        public string OrgName { get; set; }
    }
}
