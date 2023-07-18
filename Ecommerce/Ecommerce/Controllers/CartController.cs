using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.AddProduct;
using static Ecommerce.Cart;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        // GET: CartController
        public ActionResult Index()
        {
            if (Cart.AddProduct.Count == 0)
            {
                return NotFound("No Products");
            }
            List<ProductModel> products = new List<ProductModel>();

            foreach (KeyValuePair<string, ProductModel> product in Cart.AddProduct)
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

        // GET: CartController/Create
/*        public IActionResult AddToCart()
        {
            return View();
        }
*/
        // POST: CartController/Create
        [HttpPost]
        public ActionResult AddToCart(string productId)
        {
            try
            {
                Cart.AddProduct.Add(productId, AddProduct.ProductData[productId]);
                return RedirectToAction("Index");
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
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
        }
    }
}
