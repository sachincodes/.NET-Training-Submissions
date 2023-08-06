namespace Web.Models
{
    public class APIRequest
    {
        public readonly HttpClient _client = new HttpClient();

        public HttpResponseMessage GetRequest(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return httpClient.GetAsync(url).Result;
            }
        }
        public HttpClient GetHttpClient()
        {
            return _client;
        }
    }
}
