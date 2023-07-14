using Ecommerce.Database;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>();

            foreach (KeyValuePair <string, ProductModel> prod in ProductDatabase.ProductDict)
            {
                products.Add(prod.Value);
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel model)
        {
            ProductDatabase.ProductDict.Add(model.ProductId, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CartList()
        {
            return View(Cart.CartItems);
        }

        [HttpGet]
        public IActionResult AddedToCart(string ProductId)
        {
             Cart.CartItems.Add(ProductDatabase.ProductDict[ProductId]);
            return RedirectToAction("Index");
        }


    }
}
