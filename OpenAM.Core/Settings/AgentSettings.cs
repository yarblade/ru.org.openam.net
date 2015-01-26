using System.Collections.Generic;
using OpenAM.Core.Entities;

namespace OpenAM.Core.Settings
{
    public class AgentSettings
    {
        public string ClientIpHeader { get; set; }
        public bool RedirectEnabled { get; set; }
        public string RedirectHost { get; set; }
        public string RedirectProtocol { get; set; }
        public int? RedirectPort { get; set; }
        public string[] LogoutUrls { get; set; }
        public string[] LogoutResetCookies { get; set; }
        public string[] ResetCookies { get; set; }
        public string LoginUrl { get; set; }
        public string AuthCookieName { get; set; }
        public string[] UrlsWithoutAuthorization { get; set; }
        public bool AuthorizationEnabled { get; set; }
        public bool SsoOnly { get; set; }
        public bool IpValidationEnabled { get; set; }
        public bool AnonymousAuthorizationEnabled { get; set; }
        public string AccessDeniedRedirectUrl { get; set; }
        public string LogoutRedirectParam { get; set; }
        public IDictionary<string, string> ProfileAttributes { get; set; }
        public IDictionary<string, string> SessionAttributes { get; set; }
        public FetchMode ProfileFetchMode { get; set; }
        public FetchMode SessionFetchMode { get; set; }
    }
}