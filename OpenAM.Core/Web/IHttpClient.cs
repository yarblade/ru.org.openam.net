namespace OpenAM.Core.Web
{
    public interface IHttpClient
    {
        byte[] Get(string url);
        byte[] Post(string url, byte[] data);
        byte[] Put(string url, byte[] data);
        byte[] Delete(string url, byte[] data);
    }
}
