using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping_Cart.Models;
using Shopping_Cart.Services;

namespace Shopping_Cart.Controllers
{
    public class ShoppingController : Controller
    {
        ProductsServices products=new ProductsServices();
        ShoppingCartServices shoppingCart = new ShoppingCartServices();
        ShoppingCarts shoppingCarts = new ShoppingCarts();
        List<ShoppingCartDetail> shoppingCartDetails = new List<ShoppingCartDetail>();
        // GET: ShoppingController
        public ActionResult Index()
        {

            ViewBag.Item = ItemCount();
            var product = products.GetAllProduct();
            return View(product);
        }
        public ActionResult AddtoCart(int productId,string productName,string productImage,double productPrice)
        {
            try
            {
                var isExist = false;
                ShoppingCartDetail model = new ShoppingCartDetail();
                model.ProductId = productId;
                model.ProductName = productName;
                model.ProductImage = productImage;
                model.ProductPrice = productPrice;
                model.Item = 1;

                if (HttpContext.Session.GetString("ShoppingCart") != null)
                {
                    shoppingCarts = JsonConvert.DeserializeObject<ShoppingCarts>(HttpContext.Session.GetString("ShoppingCart"));
                    var cartDetail = shoppingCarts.shoppingCartDetails.FindAll(x => x.ProductId == model.ProductId).FirstOrDefault();
                    if (cartDetail != null)
                    {
                        cartDetail.Item = cartDetail.Item + 1;
                    }
                    else
                        shoppingCarts.shoppingCartDetails.Add(model);
                }
                else
                {
                    shoppingCartDetails.Add(model);
                    shoppingCarts.shoppingCartDetails = shoppingCartDetails;
                }
                string JsonData = JsonConvert.SerializeObject(shoppingCarts);
                HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(shoppingCarts));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
        public IActionResult GetCart()
        {

            try
            {
                var model = new ShoppingCarts();
                model = GetDataFromSession();
                return View("AddCart",model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ShoppingCarts GetDataFromSession()
        {
            var model = new ShoppingCarts();
            if (HttpContext.Session.GetString("ShoppingCart") != null)
            {
                model = JsonConvert.DeserializeObject<ShoppingCarts>(HttpContext.Session.GetString("ShoppingCart") ?? string.Empty);
                model.TotalPrice = shoppingCart.CalculatePrice(model);
                if (model.TotalPrice >= 500)
                {
                    model.DiscountAmount = 100;
                    model.NetAmount = model.TotalPrice - model.DiscountAmount;
                }
                else
                {
                    model.DiscountAmount = 0;
                    model.NetAmount = model.TotalPrice;
                }
                
            }
            ViewBag.Item = model.shoppingCartDetails.Count();
            return model;
        }
        public int ItemCount()
        {
            if (HttpContext.Session.GetString("ShoppingCart") != null)
            {
                shoppingCarts = JsonConvert.DeserializeObject<ShoppingCarts>(HttpContext.Session.GetString("ShoppingCart"));
                int item = 0;
                foreach (var model in shoppingCarts.shoppingCartDetails)
                {
                    item += model.Item;
                }
                return item;

            }
            else
            {
                return 0;
            }
        }

    }
}
