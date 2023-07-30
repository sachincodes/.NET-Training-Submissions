using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Student.Web.UI.Controllers
{
    public class BaseController : Controller
    {
        string apiUrl = ConfigurationManager.AppSettings["baseurl"];
       
        public List<ExpandoObject> GetResult(string apiName)
        {
            List<ExpandoObject> model = new List<ExpandoObject>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(apiName).Result;
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    model = JsonConvert.DeserializeObject<List<ExpandoObject>>(EmpResponse);
                }
                return model;
            }
        }

        public HttpResponseMessage PostData(string jsonData, string apiName)
        {   
            var url = apiUrl+ apiName;
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var client = new HttpClient();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(jsonData, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response =  client.SendAsync(request).Result;
           var result= response.EnsureSuccessStatusCode();
            return result;
        }
    }
}