using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Requests
{
    public class LoginRequestRequest
    {
        [XmlAttribute("authIdentifier")]
        public string AuthIdentifier { get; set; }

        [XmlElement("SubmitRequirements")]
        public SubmitRequirements SubmitRequirements { get; set; }
    }
}
