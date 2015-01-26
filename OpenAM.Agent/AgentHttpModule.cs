using System.Web;
using log4net;
using OpenAM.Core;
using OpenAM.Core.Exceptions;
using OpenAM.Core.Providers;
using OpenAM.Core.Web;

namespace OpenAM.Agent
{
    public class AgentHttpModule : BaseHttpModule
    {
        private readonly INamingProvider _namingProvider;
        private readonly IAgentSettingsProvider _settingsProvider;
        private readonly IHttpContextHelper _contextHelper;
        private readonly IUrlHelper _urlHelper;
        private readonly ICookieHelper _cookieHelper;
        private readonly IUserProvider _userProvider;
        private readonly ISessionProvider _sessionProvider;
        private readonly IPolicyProvider _policyProvider;
        private readonly ILog _log;

        public AgentHttpModule(
            INamingProvider namingProvider,
            IAgentSettingsProvider settingsProvider,
            IHttpContextHelper contextHelper,
            IUrlHelper urlHelper,
            ICookieHelper cookieHelper,
            IUserProvider userProvider,
            ISessionProvider sessionProvider,
            IPolicyProvider policyProvider,
            IExceptionShield shield,
            ILog log) : base(shield)
        {
            _namingProvider = namingProvider;
            _settingsProvider = settingsProvider;
            _contextHelper = contextHelper;
            _urlHelper = urlHelper;
            _cookieHelper = cookieHelper;
            _userProvider = userProvider;
            _sessionProvider = sessionProvider;
            _policyProvider = policyProvider;
            _log = log;
        }

        public override void OnBeginRequest(HttpContextBase context)
        {
            var settings = _settingsProvider.Get(_namingProvider.GetNaming());
            var url = _contextHelper.GetRequestUrl(context);

            _log.Debug(string.Format("Begin request url: {0} ip: {1}", url.AbsoluteUri, _contextHelper.GetClientIp(context, settings.ClientIpHeader)));
        }

        public override void OnAuthenticateRequest(HttpContextBase context)
        {
            var naming = _namingProvider.GetNaming();
            var settings = _settingsProvider.Get(naming);
            var url = _contextHelper.GetRequestUrl(context);
            var authCookie = _cookieHelper.GetCookieValue(context.Request, settings.AuthCookieName);
            
            if (_urlHelper.RedirectIsNeeded(url, settings))
            {
                context.Response.Redirect(_urlHelper.GetRedirectUrl(url, settings));
                return;
            }

            if (_urlHelper.LogoutIsNeeded(url, settings))
            {
                _log.InfoFormat("Logout {0}", url.AbsoluteUri);
                _cookieHelper.ResetCookies(context.Response, settings.LogoutResetCookies);
                context.Response.Redirect(settings.LoginUrl);
                return;
            }

            if (!_urlHelper.AuthorizationIsNeeded(url, settings))
            {
                context.User = settings.AuthorizationEnabled
                    ? _userProvider.GetUser(_sessionProvider.GetSession(authCookie))
                    : _userProvider.GetAnonymousUser();

                _log.InfoFormat("Free access allowed to {0}", url.AbsoluteUri);
                return;
            }

            var session = _sessionProvider.GetSession(authCookie);
            var user = _userProvider.GetUser(session);
            
            if (_contextHelper.CanAuthorizeUser(context, user, url, settings, session.Host))
            {
                _contextHelper.AuthorizeUser(context, user, session, url, settings, authCookie);
            }
            else
            {
                if (settings.AnonymousAuthorizationEnabled)
                {
                    context.User = _userProvider.GetAnonymousUser();
                    _log.InfoFormat("Anonymous access allowed to {0}", url.AbsoluteUri);
                }
                else
                {
                    _cookieHelper.ResetCookies(context.Response, settings.ResetCookies);
                    _contextHelper.LogoutUser(context,user, url, settings);
                }
            }
        }

        public override void OnEndRequest(HttpContextBase context)
        {
            _log.Debug("End request.");
        }
    }
}
