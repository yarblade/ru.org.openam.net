using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Session.Requests
{
    public class Session
    {
        [XmlAttribute("reset")]
        public string Reset { get; set; }

        [XmlElement("SessionID")]
        public string SessionId { get; set; }
    }
}
