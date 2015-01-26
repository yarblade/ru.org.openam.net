using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Naming.Responses
{
    public class NamingProfile
    {
        [XmlElement("Attribute")]
        public Property[] Attributes { get; set; }
    }
}