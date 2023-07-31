using EFCoreServices;
using EFCoreModels; // Add the appropriate namespace for EFCoreModels
using EFCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ServiceClass _services;

        public HomeController(ILogger<HomeController> logger, ServiceClass services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var courses = _services.GetAllCourses();
            var courseViewModels = courses.Select(c => new CourseViewModel
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName
            }).ToList();

            var viewModel = new AdmissionViewModel
            {
                Courses = courseViewModels,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveAdmission(AdmissionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    StudentName = viewModel.StudentName,
                    Age = viewModel.Age,
                    City= viewModel.City,
                    CourserId = viewModel.SelectCourseId
                };
                _services.AddStudents(student);
            }
            return RedirectToAction("AdmissionForm");
        }


    }
}