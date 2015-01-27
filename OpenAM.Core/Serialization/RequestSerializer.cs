using System.Text;
using System.Xml;
using OpenAM.Core.Constants;
using OpenAM.Core.Entities;
using OpenAM.Core.Entities.Naming.Requests;
using OpenAM.Core.Providers;

namespace OpenAM.Core.Serialization
{
    public class RequestSerializer : IRequestSerializer
    {
        private readonly IDataProvider<int> _requestIdProvider;
        private readonly IXmlSerializer _serializer;

        public RequestSerializer(IDataProvider<int> requestIdProvider, IXmlSerializer serializer)
        {
            _requestIdProvider = requestIdProvider;
            _serializer = serializer;
        }

        public byte[] Serialize<T>(T obj) where T : RequestBase
        {
            var xml = Encoding.UTF8.GetString(_serializer.Serialize(obj));

            var set = new RequestSet
            {
                RequestId = _requestIdProvider.Get(),
                ServiceId = obj is NamingRequest ? NamingConstants.ServiceId : obj.Type.ToString().ToLowerInvariant(),
                Version = RequestConstants.Version,
                Request = new XmlDocument().CreateCDataSection(xml)
            };

            return _serializer.Serialize(set);
        }
    }
}