using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Session.Responses
{
    public class Session
    {
        [XmlAttribute("sid")]
        public string SessionId { get; set; }

        [XmlAttribute("stype")]
        public string SessionType { get; set; }

        [XmlAttribute("cid")]
        public string CId { get; set; }

        [XmlAttribute("cdomain")]
        public string CDomain { get; set; }

        [XmlAttribute("maxtime")]
        public int MaxTime { get; set; }

        [XmlAttribute("maxidle")]
        public int MaxIdle { get; set; }

        [XmlAttribute("maxcaching")]
        public int MaxCaching { get; set; }

        [XmlAttribute("timeidle")]
        public int TimeIdle { get; set; }

        [XmlAttribute("timeleft")]
        public int TimeLeft { get; set; }

        [XmlAttribute("state")]
        public string State { get; set; }

        [XmlElement("Property")]
        public Property[] Properties { get; set; }
    }
}
