using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Ecommerce.AddProduct;


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
           /* if (AddProduct.ProductData.Count == 0)
            {
                return View("Index");
            }*/
            List<ProductModel> products = new List<ProductModel>();

            foreach (KeyValuePair<string, ProductModel> product in AddProduct.ProductData)
            {
                products.Add(product.Value);
            }
            return View(products);
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