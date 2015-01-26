using System.Text;
using OpenAM.Core.Entities;

namespace OpenAM.Core.Serialization
{
    public class ResponseSerializer : IResponseSerializer
    {
        private readonly IXmlSerializer _serializer;

        public ResponseSerializer(IXmlSerializer serializer)
        {
            _serializer = serializer;
        }

        public T Deserialize<T>(byte[] data) where T : ResponseBase
        {
            var responseSet = _serializer.Deserialize<ResponseSet>(data);
            var response = _serializer.Deserialize<T>(Encoding.UTF8.GetBytes(responseSet.Response.Value));

            return response;
        }
    }
}