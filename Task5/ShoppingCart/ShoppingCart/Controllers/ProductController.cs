using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCart.Models;
using ShoppingCart.Service;
using System.Reflection;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;
        List<ProductModel> productModelList = new List<ProductModel>();
        CartModel cartModel = new CartModel();
        List<CartDetail> cardDetailsList = new List<CartDetail>();
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.Item = ItemCount();
                Product model = new Product();
                List<ProductModel> productModelList = productService.GetAllProduct();
                model.Products = productModelList;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult AddDataToSession(string paramValue)
        {
            try
            {
                var isExist = false;
                CartDetail modelDtl = new CartDetail();
                if (paramValue != null && paramValue.IndexOf('|') > 0)
                {
                    string[] paramArray = paramValue.Split('|');
                    modelDtl.productId = Convert.ToInt32(paramArray[0]);
                    modelDtl.productName = paramArray[1].ToString();
                    modelDtl.productImage = paramArray[2].ToString();
                    modelDtl.discount = decimal.Parse(paramArray[3]);
                    modelDtl.productPrice = decimal.Parse(paramArray[4]);
                    modelDtl.quantity = 1;
                }
                if (HttpContext.Session.GetString("ShoppingCart") != null)
                {
                    cartModel = JsonConvert.DeserializeObject<CartModel>(HttpContext.Session.GetString("ShoppingCart"));
                    var cartDetail = cartModel.cartList.FindAll(x => x.productId == modelDtl.productId).FirstOrDefault();
                    if (cartDetail != null)
                    {
                        cartDetail.quantity = cartDetail.quantity + 1;
                        isExist = true;  // A for already exists!
                    }
                    else
                        cartModel.cartList.Add(modelDtl);
                }
                else
                {
                    cardDetailsList.Add(modelDtl);
                    cartModel.cartList = cardDetailsList;
                }
                string JsonData = JsonConvert.SerializeObject(cartModel);
                HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(cartModel));
                if (isExist == true)
                    return Ok("A");
                else
                    return Ok("Success");
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
        private int ItemCount()
        {
            if (HttpContext.Session.GetString("ShoppingCart") != null)
            {
                cartModel = JsonConvert.DeserializeObject<CartModel>(HttpContext.Session.GetString("ShoppingCart"));
               return  cartModel.cartList.Count();
            }
            else
            {
                return 0;
            }

        }

    }
}
