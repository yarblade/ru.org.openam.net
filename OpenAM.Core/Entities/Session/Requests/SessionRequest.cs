using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Session.Requests
{
    [XmlRoot("SessionRequest")]
    public class SessionRequest:RequestBase
    {
        public SessionRequest() : base(RequestType.Session)
        {
        }

        [XmlAttribute("reqid")]
        public int RequestId { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("GetSession")]
        public Session Session { get; set; }
    }
}
