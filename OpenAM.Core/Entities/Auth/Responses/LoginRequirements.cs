using System.Xml.Serialization;
using OpenAM.Core.Entities.Auth.Callbacks;

namespace OpenAM.Core.Entities.Auth.Responses
{
    public class LoginRequirements
    {
        [XmlElement("Callbacks")]
        public CallbackList Callbacks { get; set; }
    }
}