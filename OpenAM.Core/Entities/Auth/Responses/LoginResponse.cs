using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Responses
{
    [XmlRoot("AuthContext")]
    public class LoginResponse : ResponseBase
    {
        [XmlElement("Response")]
        public LoginResponseResponse Response { get; set; }
    }
}