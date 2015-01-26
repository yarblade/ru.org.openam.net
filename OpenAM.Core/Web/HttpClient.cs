using System;
using System.IO;
using System.Net;
using OpenAM.Core.Exceptions;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Web
{
    public class HttpClient : IHttpClient
    {
        private readonly HttpClientSettings _settings;

        public HttpClient()
        {
        }

        public HttpClient(HttpClientSettings settings)
        {
            _settings = settings;
        }

        public byte[] Get(string url)
        {
            return SendRequest("GET", url, null);
        }

        public byte[] Post(string url, byte[] data)
        {
            return SendRequest("POST", url, data);
        }

        public byte[] Put(string url, byte[] data)
        {
            return SendRequest("PUT", url, data);
        }

        public byte[] Delete(string url, byte[] data)
        {
            return SendRequest("DELETE", url, data);
        }

        private byte[] SendRequest(string method, string url, byte[] data)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = method;
            request.AllowAutoRedirect = false;

            if (data != null)
            {
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            if (_settings != null)
            {
                request.ContentType = _settings.ContentType;
                request.KeepAlive = _settings.KeepAlive;
                request.UserAgent = _settings.UserAgent;
                request.Timeout = _settings.Timeout ?? request.Timeout;
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse) request.GetResponse();

                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            stream.CopyTo(ms);

                            return ms.ToArray();
                        }
                    }
                    else
                    {
                        throw new HttpClientException(string.Format("Unable to get response from '{0}' url", url), response.StatusCode);
                    }
                }
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response as HttpWebResponse;
                if (errorResponse != null)
                {
                    using (var stream = errorResponse.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var message = reader.ReadToEnd();

                                throw new HttpClientException(url + Environment.NewLine + ex.Message, errorResponse.StatusCode, ex) { Response = message };
                            }
                        }
                    }
                }

                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }
    }
}
