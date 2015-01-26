using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Naming.Responses
{
    public class NamingResponse : ResponseBase
    {
        [XmlAttribute("reqid")]
        public int RequestId { get; set; }

        [XmlElement("GetNamingProfile")]
        public NamingProfile NamingProfile { get; set; }
    }
}