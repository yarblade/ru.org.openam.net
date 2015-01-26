namespace OpenAM.Core.Serialization
{
    public interface IXmlSerializer
    {
        byte[] Serialize<T>(T obj);
        T Deserialize<T>(byte[] data);
    }
}