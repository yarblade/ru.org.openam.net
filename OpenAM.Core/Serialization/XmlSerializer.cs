using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace OpenAM.Core.Serialization
{
    public class XmlSerializer : IXmlSerializer
    {
        public byte[] Serialize<T>(T obj)
        {
            var ns = new XmlSerializerNamespaces(new[] { new XmlQualifiedName(string.Empty, string.Empty) });

            using (var ms = new MemoryStream())
            {
                using (var writer = new XmlTextWriter(ms, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    new System.Xml.Serialization.XmlSerializer(typeof (T)).Serialize(writer, obj, ns);

                    return ms.ToArray();
                }
            }
        }

        public T Deserialize<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return (T) new System.Xml.Serialization.XmlSerializer(typeof (T)).Deserialize(ms);
            }
        }
    }
}