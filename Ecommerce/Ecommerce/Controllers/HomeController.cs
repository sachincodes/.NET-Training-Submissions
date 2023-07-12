using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ecommerce.StaticFiles;
namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IProduct acer = new Laptop();
            acer.Id= Guid.NewGuid();    
            acer.Price = 6000;
            acer.Description = "Acer Aspire 5 is a Gaming laptop with Nvidia GeForce 2500";
            acer.Name = "Acer Aspire 5";
            IProduct IPhone = new IPhone();
            IPhone.Price = 40000;
            IPhone.Id = Guid.NewGuid(); 
            IPhone.Description = "IPhone 13 with ultra wide camera features ";
            IPhone.Name = "IPhone 13";
            Store.myproducts.Clear();
          Store.myproducts.Add(acer);
            Store.myproducts.Add(IPhone);

            Store.mycartdict[acer.Id] = acer;
            Store.mycartdict[IPhone.Id]= IPhone; 
            return View(Store.myproducts);
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