using System.Xml;
using System.Xml.Serialization;

namespace OpenAM.Core.Entities
{
    public class ResponseSet : ResponseBase
    {
        [XmlAttribute("svcid")]
        public string ServiceId { get; set; }

        [XmlAttribute("reqid")]
        public int RequestId { get; set; }

        [XmlElement("Response")]
        public XmlCDataSection Response { get; set; }
    }
}