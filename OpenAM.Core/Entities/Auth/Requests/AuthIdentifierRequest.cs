using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Requests
{
    [XmlRoot("AuthContext")]
    public class AuthIdentifierRequest : RequestBase
    {
        public AuthIdentifierRequest() : base(RequestType.Auth)
        {
        }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("Request")]
        public AuthIdentifierRequestRequest Request { get; set; }
    }
}