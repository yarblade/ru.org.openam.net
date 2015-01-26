using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Callbacks
{
    public class NameCallback : CallbackBase
    {
        [XmlElement("Prompt")]
        public string Prompt { get; set; }

        [XmlElement("Value")]
        public string Value { get; set; }
    }
}
