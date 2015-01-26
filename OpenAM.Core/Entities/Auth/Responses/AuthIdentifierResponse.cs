using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Responses
{
    [XmlRoot("AuthContext")]
    public class AuthIdentifierResponse : ResponseBase
    {
        [XmlElement("Response")]
        public AuthIdentifierResponseResponse Response { get; set; }
    }
}
