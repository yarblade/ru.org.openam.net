using System.Xml;
using System.Xml.Serialization;

namespace OpenAM.Core.Entities
{
    public class RequestSet
    {
        [XmlAttribute("vers")]
        public string Version { get; set; }

        [XmlAttribute("svcid")]
        public string ServiceId { get; set; }

        [XmlAttribute("reqid")]
        public int RequestId { get; set; }

        [XmlElement("Request")]
        public XmlCDataSection Request { get; set; }
    }
}