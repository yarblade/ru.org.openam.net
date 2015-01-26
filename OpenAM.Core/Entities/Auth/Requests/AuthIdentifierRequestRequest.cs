using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Requests
{
    public class AuthIdentifierRequestRequest
    {
        [XmlAttribute("authIdentifier")]
        public string AuthIdentifier { get; set; }

        [XmlElement("Login")]
        public Login Login { get; set; }
    }
}
