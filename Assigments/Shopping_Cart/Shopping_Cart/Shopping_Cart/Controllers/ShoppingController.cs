using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Interfaces;
using Shopping_Cart.Models;

namespace Shopping_Cart.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IDiscount _discount;

        public ShoppingController(IDiscount discount)
        {
            _discount= discount;
        }

        public IActionResult Index()
        {
            Customers customer = new Customers { CustomerName = "Sachin" };

            Products product1 = new Products { ProductName = "Iphone 11", ProductPrice = 40000 };
            Products product2 = new Products { ProductName = "Iphone 14", ProductPrice = 65000 };

            customer.ShoppingCart.AddProduct(product1);
            customer.ShoppingCart.AddProduct(product2);

            decimal totalPrice = customer.ShoppingCart.CalculateTotalPrice();
            decimal discountedPrice = _discount.ProductDiscount(totalPrice);

            var viewModel = new CartViewModel
            {
                products = customer.ShoppingCart.products,
                TotalPrice = totalPrice,
                DiscountedPrice = discountedPrice
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddToCart(Products product)
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
                HttpContext.Session.SetObject("Cart", cart);
            }

            cart.AddProduct(product);

            return RedirectToAction("Index");
        }
    }
}
