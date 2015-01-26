using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Callbacks
{
    public class CallbackList
    {
        [XmlElement("NameCallback")]
        public NameCallback NameCallback { get; set; }

        [XmlElement("PasswordCallback")]
        public PasswordCallback PasswordCallback { get; set; }

        [XmlElement("PagePropertiesCallback")]
        public PagePropertiesCallback PagePropertiesCallback { get; set; }

        [XmlAttribute("length")]
        public int Length { get; set; }
    }
}