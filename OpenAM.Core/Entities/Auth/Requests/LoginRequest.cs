using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Requests
{
    [XmlRoot("AuthContext")]
    public class LoginRequest : RequestBase
    {
        public LoginRequest() : base(RequestType.Auth)
        {
        }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("Request")]
        public LoginRequestRequest Request { get; set; }
    }
}