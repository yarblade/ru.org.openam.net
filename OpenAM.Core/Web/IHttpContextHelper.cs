using System;
using System.Security.Principal;
using System.Web;
using OpenAM.Core.Entities;
using OpenAM.Core.Entities.Session;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Web
{
    public interface IHttpContextHelper
    {
        Uri GetRequestUrl(HttpContextBase context);
        string GetClientIp(HttpContextBase context, string clientIpHeader);
        void LogoutUser(HttpContextBase context, IPrincipal user, Uri url, AgentSettings settings);
        bool CanAuthorizeUser(HttpContextBase context, IPrincipal user, Uri url, AgentSettings settings, string host);
        void AuthorizeUser(HttpContextBase context, IPrincipal user, Session session, Uri url, AgentSettings settings, string authCookie);
    }
}