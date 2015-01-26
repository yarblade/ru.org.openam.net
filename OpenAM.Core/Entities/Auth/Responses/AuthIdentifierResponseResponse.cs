using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Responses
{
    public class AuthIdentifierResponseResponse
    {
        [XmlAttribute("authIdentifier")]
        public string AuthIdentifier { get; set; }

        [XmlElement("GetRequirements")]
        public LoginRequirements Requirements { get; set; }
    }
}
