using System.Xml.Serialization;

namespace OpenAM.Core.Entities
{
    public class Property
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}