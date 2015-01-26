using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Session.Responses
{
    public class GetSession
    {
        [XmlElement("Session")]
        public Session Session { get; set; }
    }
}
