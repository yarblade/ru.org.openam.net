using System.Xml.Serialization;

namespace OpenAM.Core.Entities
{
    public abstract class ResponseBase
    {
        [XmlAttribute("vers")]
        public string Version { get; set; }
    }
}