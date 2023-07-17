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
            //function to display list of products
            ProductDatabase obj = new ProductDatabase();
            return View(obj.DisplayProducts());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel model)
        {
            //Method to add Product
            new ProductDatabase().AddProduct(model);
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
            return View(ProductDatabase.ProductDict[ProductId]);
        }

        [HttpPost]
        public IActionResult AddedToCart(ProductModel input, int ProductQuantity)
        {
            //Cart.CartItems.Add(ProductDatabase.ProductDict[input.ProductId]);
            //Cart.quantity.Add(input.ProductId, ProductQuantity);
            new Cart().AddToCart(input, ProductQuantity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RemoveItem(string ProductId)
        {
            //Cart.CartItems.Remove(ProductDatabase.ProductDict[ProductId]);
            //Cart.quantity.Remove(ProductId);
            new Cart().RemoveFromCart(ProductId);
            return RedirectToAction("Index");
        }

    }
}
