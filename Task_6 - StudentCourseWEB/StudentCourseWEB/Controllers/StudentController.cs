using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentCourseWEB.Data;
using StudentCourseWEB.Models;
using StudentCourseWEB.Services;
using StudentCourseWEB.ViewModels;
using System;
using System.Text.Json;

namespace StudentCourseWEB.Controllers
{
    public class StudentController : Controller
    {

        HttpClient _client = new HttpClient();

        public StudentController()
        {
            _client.BaseAddress = new Uri("https://localhost:7030");
        }
        public IActionResult Index()
        {
            try
            {
                HttpResponseMessage result = _client.GetAsync("api/StudentApi").Result;
                string jsonContent = result.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<IEnumerable<StudentViewModel>>(jsonContent);

                return View(list);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            HttpResponseMessage result = _client.GetAsync("api/CourseApi").Result;
            string jsonContent = result.Content.ReadAsStringAsync().Result;
            var courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jsonContent);

            //ViewBag.Courses = courses;
            ViewData["Courses"] = courses;
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            var result = _client.PostAsJsonAsync<StudentViewModel>("api/StudentApi", student).Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            TempData["error"] = "Error";
            return View("Index");
        }
    }
}
