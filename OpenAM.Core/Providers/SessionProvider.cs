using System;
using System.Linq;
using OpenAM.Core.Constants;
using OpenAM.Core.Entities.Auth.Callbacks;
using OpenAM.Core.Entities.Auth.Requests;
using OpenAM.Core.Entities.Auth.Responses;
using OpenAM.Core.Entities.Naming;
using OpenAM.Core.Entities.Session.Requests;
using OpenAM.Core.Entities.Session.Responses;
using OpenAM.Core.Settings;
using Session = OpenAM.Core.Entities.Session.Session;

namespace OpenAM.Core.Providers
{
    public class SessionProvider : ISessionProvider
    {
        private readonly IRequestIdProvider _requestIdProvider;
        private readonly IGenericResponseProvider _responseProvider;
        private readonly SessionProviderSettings _settings;

        public SessionProvider(
            IRequestIdProvider requestIdProvider,
            IGenericResponseProvider responseProvider,
            SessionProviderSettings settings)
        {
            _requestIdProvider = requestIdProvider;
            _responseProvider = responseProvider;
            _settings = settings;
        }

        public Session GetSession(string authCookie)
        {
            if (authCookie == null)
            {
                return null;
            }

            return new Session(authCookie);
        }

        public Session GetSession(Naming naming)
        {
            var response = _responseProvider.Get<AuthIdentifierRequest, AuthIdentifierResponse>(
                new AuthIdentifierRequest
                {
                    Version = AuthConstants.Version,
                    Request = new AuthIdentifierRequestRequest
                    {
                        AuthIdentifier = AuthConstants.EmptyAuthIdentifier,
                        Login = new Login
                        {
                            OrgName = _settings.OrgName,
                            IndexTypeNamePair = new IndexTypeNamePair
                            {
                                IndexName = _settings.IndexName,
                                IndexType = _settings.AuthType.ToString().ToLowerInvariant()
                            }
                        }
                    }
                });

            var loginResponse = _responseProvider.Get<LoginRequest, LoginResponse>(
                new LoginRequest
                {
                    Version = AuthConstants.Version,
                    Request = new LoginRequestRequest
                    {
                        AuthIdentifier = response.Response.AuthIdentifier,
                        SubmitRequirements = new SubmitRequirements
                        {
                            Callbacks = new CallbackList
                            {
                                NameCallback = new NameCallback { Value = _settings.Login, Prompt = string.Empty },
                                PasswordCallback = new PasswordCallback { Value = _settings.Password, Prompt = string.Empty, EchoPassword = "True" },
                                Length = 2
                            }
                        }
                    }
                });

            var token = loginResponse.Response != null && loginResponse.Response.LoginStatus != null ? loginResponse.Response.LoginStatus.SsoToken : null;
            if (token == null)
            {
                throw new InvalidOperationException("SSO token can't be null.");
            }

            var sessionResponse = _responseProvider.Get<SessionRequest, SessionResponse>(
                new SessionRequest
                {
                    RequestId = _requestIdProvider.GetRequestId(),
                    Version = RequestConstants.Version,
                    Session = new Entities.Session.Requests.Session
                    {
                        Reset = "True",
                        SessionId = token
                    }
                });

            return new Session(token)
            {
                Properties = sessionResponse.GetSession.Session.Properties.ToDictionary(x => x.Name, x => x.Value)
            };
        }
    }
}