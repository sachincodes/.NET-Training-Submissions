using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
using Newtonsoft.Json;
using StudentEntity.Model;
using System;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _baseUrl;
        private readonly IConfiguration _configuration;
        private readonly APIRequest _apiRequest;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, APIRequest apiRequest)
        {
            _logger = logger;
            _configuration = configuration;
            _baseUrl = _configuration.GetValue<string>("BaseURL");
            _apiRequest = apiRequest;
        }

        public IActionResult Index()
        {
            //StudentDetail addmissionViewModel = new StudentDetail();
            List<StudentModel> studentViewModels = new List<StudentModel>();
            HttpResponseMessage response = _apiRequest.GetRequest($"{_baseUrl}/api/student/getAllStudents");
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                if(data != null)
                {
                    studentViewModels = JsonConvert.DeserializeObject<List<StudentModel>>(data) ?? new List<StudentModel>();
                }
            }
            return View(studentViewModels);

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}