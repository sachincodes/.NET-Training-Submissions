
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCart.Models;
using ShoppingCart.Service;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            ShopCart model = GetDataFromSession();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string button)
        {
            ShopCart model = GetDataFromSession();

            if (!string.IsNullOrEmpty(button) && model != null)
            {
                if (model.CartList != null)
                {
                    bool res = int.TryParse(button, out int id);
                    var deletedItem = model.CartList.Find(x => x.ProductId == id);

                    if (deletedItem != null)
                    {
                        model.CartList.Remove(deletedItem);
                        HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(model));
                    }
                }
            }

            return View(model);
        }

        private ShopCart GetDataFromSession()
        {
            string? sessionData = HttpContext.Session.GetString("ShoppingCart");
            ShopCart? model = string.IsNullOrEmpty(sessionData)
                ? new ShopCart()
                : JsonConvert.DeserializeObject<ShopCart>(sessionData);

            if (model != null && model.Customer != null)
            {
                model.Customer.Name = "Manisha";
                model = cartService.CalculatePrice(model);
                ViewBag.Item = model.CartList?.Count ?? 0;
            }

            return model;
        }

    }
}
