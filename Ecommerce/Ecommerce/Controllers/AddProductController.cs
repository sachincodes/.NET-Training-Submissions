using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.AddProduct;
namespace Ecommerce.Controllers
{
    public class AddProductController : Controller
    {
        // GET: AddProductController
        public ActionResult Index()
        {
            if (AddProduct.ProductData.Count == 0)
            {
                return NotFound("No Products");
            }
            List<ProductModel> products = new List<ProductModel>();

            foreach (KeyValuePair<string, ProductModel> product in AddProduct.ProductData)
            {
                products.Add(product.Value);
            }
            return View(products);
        }

        // GET: AddProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddProductController/Create
        [HttpPost]
        public ActionResult Create(ProductModel collection)
        {
            try
            {
                new AddProduct().AddProducts(collection);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                return View();
            }
        }

        // GET: AddProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddProductController/Edit/5
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

        // GET: AddProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddProductController/Delete/5
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
