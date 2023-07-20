using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCart.Models;
using ShoppingCart.Service;
using System.Reflection;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult Index()
        {
            try
            {
                var model = new CartModel();
                model=GetDataFromSession();
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult Index(string button)
        {
            try
            {
                var model = new CartModel();
                if (!string.IsNullOrEmpty(button))
                {
                    if (HttpContext.Session.GetString("ShoppingCart") != null)
                    {
                        bool res = false;
                        int id;
                        model = JsonConvert.DeserializeObject<CartModel>(HttpContext.Session.GetString("ShoppingCart")??string.Empty);
                        res = int.TryParse(button, out id);
                        var deltedItem = model.cartList.Find(x => x.productId == id);
                        if (deltedItem != null)
                        {
                            model.cartList.Remove(deltedItem);
                            HttpContext.Session.Remove("ShoppingCart");
                            string JsonData = JsonConvert.SerializeObject(model);
                            HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(model));
                        }
                    }
                    model = GetDataFromSession();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private CartModel GetDataFromSession()
        {
            var model = new CartModel();
            var customer = new CustomerModel();
            var address = new AddressModel();
            if (HttpContext.Session.GetString("ShoppingCart") != null)
            {
                model = JsonConvert.DeserializeObject<CartModel>(HttpContext.Session.GetString("ShoppingCart") ?? string.Empty);
                model.customer.CustomerName = "Sadiqa Sadaf"??string.Empty;
                model.address.Address = "Dehradun" ?? string.Empty;
                model = cartService.CalculatePrice(model);
                ViewBag.Item = model.cartList.Count();
            }
            return model;
        }
    }
}
