using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace RssReader.Utils
{
    public static class XMLDownloader
    {
        public static async Task<T> GetRssFeedAsync<T>(string url) where T : new()
        {
            //var uri = new Uri(url);

            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");

            //    var response = await client.GetAsync(uri)
            //       //.ContinueWith(t => t.Result.Content.ReadAsAsync<T>())
            //       .ContinueWith(t => t.Result.Content.ReadAsStringAsync())
            //       .Unwrap();

            //    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            //    using (StringReader reader = new StringReader(response))
            //    {
            //        var result = (T)serializer.Deserialize(reader);

            //        return result;
            //    }
            //}

            byte[] data;
            using (WebClient client = new WebClient())
            {
                Uri uriPath = new Uri(url);
                data = await client.DownloadDataTaskAsync(uriPath);
            }

            var toRet = DeserializeFromBytes<T>(data);
            return toRet;
        }

        public static T DeserializeFromBytes<T>(byte[] xml) where T : new()
        {
            T result;

            using (MemoryStream stream = new MemoryStream(xml))
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    result = (T)serializer.Deserialize(reader);
                }
            }

            return result;
        }
    }
}