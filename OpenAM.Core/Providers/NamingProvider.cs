using System;
using System.Linq;
using OpenAM.Core.Constants;
using OpenAM.Core.Entities.Naming;
using OpenAM.Core.Entities.Naming.Requests;
using OpenAM.Core.Entities.Naming.Responses;

namespace OpenAM.Core.Providers
{
    public class NamingProvider : IDataProvider<Naming>
    {
        private readonly IDataProvider<int> _requestIdProvider;
        private readonly IGenericResponseProvider _responseProvider;
        private readonly string _url;

        public NamingProvider(IDataProvider<int> requestIdProvider, IGenericResponseProvider responseProvider, string url)
        {
            _requestIdProvider = requestIdProvider;
            _responseProvider = responseProvider;
            _url = url;
        }

        public Naming Get()
        {
            var requestId = _requestIdProvider.Get();
            var response = _responseProvider.Get<NamingRequest, NamingResponse>(
                new NamingRequest
                {
                    RequestId = requestId,
                    Version = NamingConstants.Version
                });

            if (response.NamingProfile == null)
            {
                throw new InvalidOperationException("NamingProfile can't be null.");
            }

            return new Naming
            {
                AuthUrl = GetAttributeValue(response.NamingProfile, NamingConstants.AuthAttributeName),
                SessionUrl = GetAttributeValue(response.NamingProfile, NamingConstants.SessionAttributeName),
                IdentityUrl = GetAttributeValue(response.NamingProfile, NamingConstants.IdentityAttributeName),
                PolicyUrl = GetAttributeValue(response.NamingProfile, NamingConstants.PolicyAttributeName)
            };
        }

        private string GetAttributeValue(NamingProfile profile, string name)
        {
            var attribute = profile.Attributes.SingleOrDefault(x => x.Name == name);
            if (attribute == null)
            {
                throw new InvalidOperationException(string.Format("Can't find attribute '{0}'.", name));
            }

            return attribute.Value.Replace("%protocol://%host:%port%uri", _url);
        }
    }
}