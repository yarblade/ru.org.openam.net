using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Session.Responses
{
    [XmlRoot("SessionResponse")]
    public class SessionResponse : ResponseBase
    {
        [XmlElement("GetSession")]
        public GetSession GetSession { get; set; }
    }
}