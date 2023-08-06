using System.Net.Http.Headers;
using System.Text;

namespace Web.Models.Helper
{
    public class Helper
    {
        public static IConfiguration Configuration;
        public static readonly HttpClient _client = new HttpClient();
        public static void SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static HttpClient GetHttpClient()
        {
            return _client;
        }
        public static HttpResponseMessage ClientGetRequest(string url)
        {
            var client = GetHttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = client.SendAsync(request).GetAwaiter().GetResult();
            return response;
        }
        //public static HttpResponseMessage PostRequest(string url, string values)
        //{
        //    var client = GetHttpClient();

        //    var request = new HttpRequestMessage(HttpMethod.Post, url);
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    request.Content = new StringContent(values, Encoding.UTF8);
        //    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    var response = client.SendAsync(request).GetAwaiter().GetResult();
        //    return response;
        //}

    }
}
