using System;
using System.Linq;
using OpenAM.Core.Entities;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Web
{
    public class UrlHelper : IUrlHelper
    {
        public bool RedirectIsNeeded(Uri url, AgentSettings settings)
        {
            return !string.IsNullOrEmpty(settings.RedirectHost) && !url.Host.Equals(settings.RedirectHost) && settings.RedirectEnabled;
        }

        public string GetRedirectUrl(Uri url, AgentSettings settings)
        {
            return new UriBuilder(settings.RedirectProtocol ?? url.Scheme, settings.RedirectHost, settings.RedirectPort ?? url.Port, url.PathAndQuery).ToString();
        }

        public bool LogoutIsNeeded(Uri url, AgentSettings settings)
        {
            return settings.LogoutUrls.Any(x => new Uri(x).AbsoluteUri == url.AbsoluteUri);
        }

        public bool AuthorizationIsNeeded(Uri url, AgentSettings settings)
        {
            foreach (var u in settings.UrlsWithoutAuthorization)
            {
                if (u.EndsWith("*") && url.AbsoluteUri.StartsWith(u.Substring(0, u.Length - 1), StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                
                if (url.AbsoluteUri.Equals(u, StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
