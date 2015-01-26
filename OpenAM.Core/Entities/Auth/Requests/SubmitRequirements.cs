using System.Xml.Serialization;
using OpenAM.Core.Entities.Auth.Callbacks;

namespace OpenAM.Core.Entities.Auth.Requests
{
    public class SubmitRequirements
    {
        [XmlElement("Callbacks")]
        public CallbackList Callbacks { get; set; }
    }
}