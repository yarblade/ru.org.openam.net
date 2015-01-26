using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Responses
{
    public class LoginStatus
    {
        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("ssoToken")]
        public string SsoToken { get; set; }

        [XmlAttribute("successURL")]
        public string SuccessUrl { get; set; }

        [XmlElement("Subject")]
        public string Subject { get; set; }
    }
}
