using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Naming.Requests
{
    public class NamingRequest : RequestBase
    {
        public NamingRequest() : base(RequestType.Naming)
        {
        }

        [XmlAttribute("reqid")]
        public int RequestId { get; set; }

        [XmlAttribute("vers")]
        public string Version { get; set; }

        [XmlAttribute("sessid")]
        public string SessionId { get; set; }

        [XmlElement("GetNamingProfile")]
        public string NamingProfile { get; set; }
    }
}