using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static Ecommerce.AddProduct;
using static Ecommerce.Cart;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        // GET: CartController
        public ActionResult Index()
        {
            /*if (Cart.AddProduct.Count == 0)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }*/
            List<CartModel> products = new List<CartModel>();

            foreach (KeyValuePair<string, CartModel> product in Cart.AddProduct)
            {
                products.Add(product.Value);
            }
            return View(products);
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        public ActionResult AddToCart(string productId, int quantity)
        {
            try
            {
                ProductModel prod =  AddProduct.ProductData[productId];
                CartModel obj = new CartModel();

                obj.ProductId = productId;
                obj.ProductName = prod.ProductName;
                obj.ProductDescription = prod.ProductDescription;
                obj.ProductPrice = prod.ProductPrice;
                obj.Quantity = quantity;
                obj.ProductCode = prod.ProductCode;
                obj.ProductType = prod.ProductType;


                if (Cart.AddProduct.ContainsKey(productId))
                {
                    Cart.AddProduct.Remove(productId);
                }

                Cart.AddProduct.Add(productId, obj);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Item(string productId)
        {
            Cart.AddProduct.Remove(productId);
            return RedirectToAction("Index");
        }

        // POST: CartController/Delete/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
