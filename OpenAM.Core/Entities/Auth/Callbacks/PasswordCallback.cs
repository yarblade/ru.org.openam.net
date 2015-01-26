using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Callbacks
{
    public class PasswordCallback : CallbackBase
    {
        [XmlAttribute("echoPassword")]
        public string EchoPassword { get; set; }

        [XmlElement("Prompt")]
        public string Prompt { get; set; }

        [XmlElement("Value")]
        public string Value { get; set; }
    }
}