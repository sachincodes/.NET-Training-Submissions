using Microsoft.AspNetCore.Mvc;
using AzaxTask.Models;

namespace AzaxTask.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Student()
        {
            return View();
        }

        public IActionResult GetStudentData()
        {
            var students = new List<StudentModel>
            {
                new StudentModel
                {
                    Id = 1,
                    Name = "Vikash Kumar",
                    Description = "A talented student."
                },
                new StudentModel
                {
                    Id = 2,
                    Name = "Aman Singh",
                    Description = "Extraordinary Guy."
                },

                new StudentModel
                {
                    Id = 3,
                    Name = "Manisha",
                    Description = "Extraordinary Girl."
                },

                new StudentModel
                {
                    Id = 4,
                    Name = "AbhisheK Baliyan",
                    Description = "Superb UI Guy"
                },

                new StudentModel
                {
                    Id = 5,
                    Name = "Mukul Pundir",
                    Description = "Superb React Native Guy"
                },

                new StudentModel
                {
                    Id = 6,
                    Name = "Bhupendra Mall",
                    Description = "Javascript Developer"
                },

                new StudentModel
                {
                    Id = 7,
                    Name = "Subodh",
                    Description = "Awesome UI Developer"
                },

                new StudentModel
                {
                    Id = 8,
                    Name = "Saurabh",
                    Description = "Awesome java Developer"
                },

                 new StudentModel
                {
                    Id = 9,
                    Name = "Anant",
                    Description = "Good Java Developer"
                },

                 new StudentModel
                {
                    Id = 10,
                    Name = "Pankaj",
                    Description = "Java Developer"
                },

                 new StudentModel
                {
                    Id = 11,
                    Name = "Shivam",
                    Description = "Backend Developer"
                },

                  new StudentModel
                {
                    Id = 12,
                    Name = "Ishan",
                    Description = "UI Developer"
                },

                  new StudentModel
                {
                    Id = 13,
                    Name = "Mayank",
                    Description = "UI Developer"
                },
            };

            return new JsonResult(students);
        }
    }
}
