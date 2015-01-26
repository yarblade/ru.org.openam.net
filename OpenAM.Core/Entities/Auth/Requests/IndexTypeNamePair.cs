using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Requests
{
    public class IndexTypeNamePair
    {
        [XmlAttribute("indexType")]
        public string IndexType { get; set; }

        [XmlElement("IndexName")]
        public string IndexName { get; set; }
    }
}
