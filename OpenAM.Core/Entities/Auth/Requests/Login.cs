using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Requests
{
    public class Login
    {
        [XmlAttribute("orgName")]
        public string OrgName { get; set; }

        [XmlElement("IndexTypeNamePair")]
        public IndexTypeNamePair IndexTypeNamePair { get; set; }
    }
}
