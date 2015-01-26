using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using log4net;
using OpenAM.Core.Entities;
using OpenAM.Core.Entities.Session;
using OpenAM.Core.Providers;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Web
{
    public class HttpContextHelper : IHttpContextHelper
    {
        private readonly ILog _log;
        private readonly IPolicyProvider _policyProvider;

        public HttpContextHelper(IPolicyProvider policyProvider, ILog log)
        {
            _policyProvider = policyProvider;
            _log = log;
        }

        public Uri GetRequestUrl(HttpContextBase context)
        {
            if (context == null || context.Request == null || context.Request.Url == null)
            {
                throw new ArgumentException("HttpContext hasn't request url.");
            }

            return context.Request.Url;
        }

        public string GetClientIp(HttpContextBase context, string clientIpHeader)
        {
            var userIp = context.Request.UserHostAddress;
            if (!string.IsNullOrWhiteSpace(clientIpHeader))
            {
                if (clientIpHeader.StartsWith("HTTP_"))
                {
                    if (context.Request.ServerVariables.Count > 0)
                    {
                        userIp = context.Request.ServerVariables[clientIpHeader];
                    }
                }
                else
                {
                    userIp = context.Request.Headers[clientIpHeader];
                }
            }

            if (userIp != null && userIp.Contains(","))
            {
                userIp = userIp.Substring(0, userIp.IndexOf(",", StringComparison.Ordinal));
            }

            return userIp;
        }

        public void LogoutUser(HttpContextBase context, IPrincipal user, Uri url, AgentSettings settings)
        {
            var userId = user != null ? user.Identity.Name : null;
            var statusCode = user != null ? 403 : 401;
            var redirectUrl = user != null ? settings.AccessDeniedRedirectUrl : settings.LoginUrl;

            _log.InfoFormat("User {0} was denied access to {1} ({2})", userId, url.AbsoluteUri, statusCode);

            if (redirectUrl != null)
            {
                if (!string.IsNullOrWhiteSpace(settings.LogoutRedirectParam))
                {
                    redirectUrl += string.Format("{0}{1}={2}", redirectUrl.Contains("?") ? "&" : "?", settings.LogoutRedirectParam, HttpUtility.UrlPathEncode(url.AbsoluteUri));
                }

                context.Response.Redirect(redirectUrl);
            }
            else
            {
                context.Response.StatusCode = statusCode;
                context.Response.End();
            }
        }

        public bool CanAuthorizeUser(HttpContextBase context, IPrincipal user, Uri url, AgentSettings settings, string host)
        {
            if (user != null)
            {
                if (settings.SsoOnly)
                {
                    _log.InfoFormat("User {0} was not autorized to {1}", user.Identity.Name, url.AbsoluteUri);
                    return true;
                }

                var policy = _policyProvider.GetPolicy(url, settings);
                if (policy != null && policy.AllowedMethods != null && policy.AllowedMethods.Contains(context.Request.HttpMethod))
                {
                    FetchContextAndRequest(context, settings.ProfileAttributes, policy.Properties, settings.ProfileFetchMode);
                    _log.InfoFormat("User {0} was autorized to {1}", user.Identity.Name, url.AbsoluteUri);
                    return true;
                }

                if (settings.IpValidationEnabled && host != GetClientIp(context, settings.ClientIpHeader))
                {
                    return false;
                }
            }

            return false;
        }

        public void AuthorizeUser(HttpContextBase context, IPrincipal user, Session session, Uri url, AgentSettings settings, string authCookie)
        {
            context.User = user;
            FetchContextAndRequest(context, settings.SessionAttributes, session.Properties, settings.SessionFetchMode);
            context.Items["am_auth_cookie"] = authCookie;

            _log.InfoFormat("User {0} was allowed access to {1}", user.Identity.Name, url.AbsoluteUri);
        }

        private void FetchContextAndRequest(HttpContextBase context, IDictionary<string, string> attributes, IDictionary<string, string> properties, FetchMode fetchMode)
        {
            if (attributes == null)
            {
                return;
            }

            foreach (var attribute in attributes.Where(x => properties.ContainsKey(x.Key)))
            {
                var value = properties[attribute.Key];

                context.Items[attribute.Value] = value;
                if (fetchMode == FetchMode.Header)
                {
                    context.Request.ServerVariables[attribute.Value] = value;
                }
                else if (fetchMode == FetchMode.Cookie)
                {
                    context.Request.Cookies.Set(new HttpCookie(attribute.Value, value));
                }
            }
        }
    }
}