using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenAM.Core.Serialization
{
    public class BaseTypeXmlSerializer<TBase, TDerived> : IXmlSerializable
        where TDerived : TBase
    {
        public BaseTypeXmlSerializer()
        {
        }

        public BaseTypeXmlSerializer(TBase data)
        {
            Data = data;
        }

        public TBase Data { get; private set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Data = (TBase)new System.Xml.Serialization.XmlSerializer(typeof(TDerived)).Deserialize(reader);
        }

        public void WriteXml(XmlWriter writer)
        {
            new System.Xml.Serialization.XmlSerializer(typeof(TDerived)).Serialize(writer, Data);
        }

        public static implicit operator TBase(BaseTypeXmlSerializer<TBase, TDerived> o)
        {
            return o.Data;
        }

        public static implicit operator BaseTypeXmlSerializer<TBase, TDerived>(TBase o)
        {
            return o == null ? null : new BaseTypeXmlSerializer<TBase, TDerived>(o);
        }
    }
}