using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VireshSirTask.Models.ViewModel;
using VireshSirTask.Models;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace VireshSirTask.Controllers
{
    public class StudentController : Controller
    {


            HttpClient _http = new HttpClient();
    
        private readonly MyDbContext _dbContext;
           public StudentController( MyDbContext _dbcontext)
        {
            _http.BaseAddress = new Uri("https://localhost:7052/");
            this._dbContext = _dbcontext;
        }
         
        [HttpGet]
        public  async Task<IActionResult> GetAllStudents()
        {
           
                       
          

            HttpResponseMessage response = await _http.GetAsync("api/StudentApi");

            if (response.IsSuccessStatusCode)
            {
                // Read the content of the response as a string
                string jsonString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to IEnumerable<Student>
                var studentData = JsonConvert.DeserializeObject<IEnumerable<StudentView>>(jsonString);
             
                return View(studentData);
            }
            else
            {
                // Handle the error here
                // For example, you could throw an exception or return an empty IEnumerable<Student>
                return View();
            }
        }


        [HttpPost]

        public async Task<IActionResult> SaveToDB(StudentView student)
        {      
            var content = JsonContent.Create(student);
            var response = await _http.PostAsync("api/StudentApi" , content );

            return RedirectToAction("GetAllStudents");     
        }
    }
}
