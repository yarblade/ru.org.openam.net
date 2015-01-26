using System;
using OpenAM.Core.Entities;
using OpenAM.Core.Serialization;
using OpenAM.Core.Web;

namespace OpenAM.Core.Providers
{
    public class GenericResponseProvider : IGenericResponseProvider
    {
        private readonly IHttpClient _client;
        private readonly IRequestSerializer _requestSerializer;
        private readonly IResponseSerializer _responseSerializer;
        private readonly string _url;

        public GenericResponseProvider(
            IRequestSerializer requestSerializer,
            IHttpClient client,
            IResponseSerializer responseSerializer,
            string url)
        {
            _requestSerializer = requestSerializer;
            _client = client;
            _responseSerializer = responseSerializer;
            _url = url;
        }

        public TResponse Get<TRequest, TResponse>(TRequest request)
            where TRequest : RequestBase
            where TResponse : ResponseBase
        {
            var data = _client.Post(_url, _requestSerializer.Serialize(request));
            var response = _responseSerializer.Deserialize<TResponse>(data);
            if (response == null)
            {
                throw new InvalidOperationException("Can't deserialize response.");
            }

            return response;
        }
    }
}