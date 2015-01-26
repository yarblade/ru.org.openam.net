namespace OpenAM.Core.Settings
{
    public class HttpClientSettings
    {
        public string ContentType { get; set; }
        public bool KeepAlive { get; set; }
        public string UserAgent { get; set; }
        public int? Timeout { get; set; }
    }
}
