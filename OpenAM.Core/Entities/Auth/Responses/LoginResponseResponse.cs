using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Responses
{
    public class LoginResponseResponse
    {
        [XmlElement("LoginStatus")]
        public LoginStatus LoginStatus { get; set; }
    }
}
