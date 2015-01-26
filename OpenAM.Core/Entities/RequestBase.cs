using System.Xml.Serialization;

namespace OpenAM.Core.Entities
{
    public abstract class RequestBase
    {
        protected RequestBase(RequestType type)
        {
            Type = type;
        }

        [XmlIgnore]
        public RequestType Type { get; private set; }
    }
}