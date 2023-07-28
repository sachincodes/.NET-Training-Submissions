using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VireshSirTask.Models;
using VireshSirTask.Models.ViewModel;
using VireshSirTask.Services;

namespace VireshSirTask.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentApiController(IStudentService studentservice)
        {
            _studentService = studentservice;
        }

        
        [HttpGet]
        public IEnumerable<StudentView> GetStudents()
        {
            IEnumerable<StudentView> students = _studentService.GetStudentDetails().ToList();

            return students;
        }
        [HttpPost]
        public void SaveToDB([FromBody] StudentView student)
        {
            _studentService.SavetToDB(student);
        }






    }
}
