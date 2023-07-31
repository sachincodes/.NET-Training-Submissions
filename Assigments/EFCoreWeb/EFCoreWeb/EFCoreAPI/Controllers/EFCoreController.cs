using EFCoreServices;
using Microsoft.AspNetCore.Mvc;


namespace EFCoreAPI.Controllers
{
    [ApiController]
    [Route("api/efcore")]
    public class EFCoreController : Controller
    {
        private readonly ServiceClass _services;

        public EFCoreController(ServiceClass services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _services.GetAllStudents();
            return Ok(students);
        }
    }
}
