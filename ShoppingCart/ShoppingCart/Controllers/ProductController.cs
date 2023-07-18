//using Microsoft.AspNetCore.Cors.Infrastructure;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using ShoppingCart.Models;
//using ShoppingCart.Service;
//using System.Reflection;

//namespace ShoppingCart.Controllers
//{
//    public class ProductController : Controller
//    {
//        IProductService productService;
//        List<ProductModel> productModelList = new List<ProductModel>();
//        CartModel cartModel = new CartModel();
//        List<CartDetail> cardDetailsList = new List<CartDetail>();
//        public ProductController(IProductService productService)
//        {
//            this.productService = productService;
//        }
//        public IActionResult Index()
//        {
//            try
//            {
//                ViewBag.Item = ItemCount();
//                Product model = new Product();
//                List<ProductModel> productModelList = productService.GetAllProduct();
//                model.Products = productModelList;
//                return View(model);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpGet]
//        public IActionResult AddProductToCart(string productData)
//        {
//            try
//            {
//                var isExist = false;
//                CartDetail productDetail = new CartDetail();
//                if (productData != null && productData.IndexOf(',') > 0)
//                {
//                    string[] paramArray = productData.Split(',');
//                    productDetail.ProductId = Convert.ToInt32(paramArray[0]);
//                    productDetail.ProductName = paramArray[1].ToString();
//                    productDetail.ProductImage = paramArray[2].ToString();
//                    productDetail.Discount = Convert.ToDecimal(paramArray[3]);
//                    productDetail.ProductPrice = Convert.ToDecimal(paramArray[4]);
//                    productDetail.Quantity = 1;
//                }
//                if (HttpContext.Session.GetString("ShoppingCart") != null)
//                {
//                    cartModel = JsonConvert.DeserializeObject<CartModel>(HttpContext.Session.GetString("ShoppingCart"));
//                    var cartDetail = cartModel.CartList.FindAll(x => x.ProductId == productDetail.ProductId).FirstOrDefault();
//                    if (cartDetail != null)
//                    {
//                        cartDetail.Quantity = cartDetail.Quantity + 1;
//                        isExist = true;  // already exists!
//                    }
//                    else
//                        cartModel.CartList.Add(productDetail);
//                }
//                else
//                {
//                    cardDetailsList.Add(productDetail);
//                    cartModel.CartList = cardDetailsList;
//                }
//                string JsonData = JsonConvert.SerializeObject(cartModel);
//                HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(cartModel));
//                if (isExist == true)
//                    return Ok("Exists");
//                else
//                    return Ok("Success");
//            }
//            catch (Exception ex)
//            {
//                return Ok();
//            }
//        }
//        private int ItemCount()
//        {
//            if (HttpContext.Session.GetString("ShoppingCart") != null)
//            {
//                cartModel = JsonConvert.DeserializeObject<CartModel>(HttpContext.Session.GetString("ShoppingCart"));
//               return  cartModel.CartList.Count();
//            }
//            else
//            {
//                return 0;
//            }

//        }

//    }
//}

using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCart.Models;
using ShoppingCart.Service;
using System.Reflection;
using System;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly List<ProductModel> _productModelList = new List<ProductModel>();
        private ShopCart _shoppingCart = new ShopCart();
        private readonly List<CartDetail> _cartDetailsList = new List<CartDetail>();

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            try
            {
                ViewBag.Item = GetCartItemCount();
                Product model = new Product();
                List<ProductModel> productModelList = _productService.GetAllProduct();
                model.Products = productModelList;
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult AddProductToCart(string productData)
        {
            try
            {
                bool isExist = false;
                CartDetail productDetail = new CartDetail();

                if (productData != null && productData.IndexOf(',') > 0)
                {
                    string[] paramArray = productData.Split(',');
                    productDetail.ProductId = Convert.ToInt32(paramArray[0]);
                    productDetail.ProductName = paramArray[1].ToString();
                    productDetail.ProductImage = paramArray[2].ToString();
                    productDetail.Discount = Convert.ToDecimal(paramArray[3]);
                    productDetail.ProductPrice = Convert.ToDecimal(paramArray[4]);
                    productDetail.Quantity = 1;
                }

                if (HttpContext.Session.GetString("ShoppingCart") != null)
                {
                    _shoppingCart = JsonConvert.DeserializeObject<ShopCart>(HttpContext.Session.GetString("ShoppingCart"));
                    var cartDetail = _shoppingCart.CartList.Find(x => x.ProductId == productDetail.ProductId);
                    if (cartDetail != null)
                    {
                        cartDetail.Quantity += 1;
                        isExist = true;  // already exists!
                    }
                    else
                    {
                        _shoppingCart.CartList.Add(productDetail);
                    }
                }
                else
                {
                    _cartDetailsList.Add(productDetail);
                    _shoppingCart.CartList = _cartDetailsList;
                }

                string jsonData = JsonConvert.SerializeObject(_shoppingCart);
                HttpContext.Session.SetString("ShoppingCart", jsonData);

                if (isExist)
                    return Ok("Exists");
                else
                    return Ok("Success");
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }

        private int GetCartItemCount()
        {
            if (HttpContext.Session.GetString("ShoppingCart") != null)
            {
                _shoppingCart = JsonConvert.DeserializeObject<ShopCart>(HttpContext.Session.GetString("ShoppingCart"));
                return _shoppingCart.CartList.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}

