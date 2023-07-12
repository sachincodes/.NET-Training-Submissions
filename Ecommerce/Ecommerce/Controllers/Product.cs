using Microsoft.AspNetCore.Mvc;
using Ecommerce.StaticFiles;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class Product : Controller
    {
             public IActionResult Index()
        {
            return View(Store.mycart);
        }

        public IActionResult AddtoCart(Guid id) {
        
           
            Store.mycart.Add(Store.mycartdict[id]);

            Store.TotalPrice += Store.mycartdict[id].Price; 

      

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(Guid id) {
            Console.WriteLine("remove itesm ");
            Store.TotalPrice -= Store.mycartdict[id].Price;
            Store.mycart.Remove(Store.mycartdict[id]);
          
           
            return RedirectToAction("Index");
        
        }
        public IActionResult ApplyDiscount(Guid id )
        {                
         
             IProduct product = Store.mycartdict[id];
            if (product.DiscountApplied == false)
            {
            int DiscountAmount=     product.Discount();
                Store.TotalPrice -= DiscountAmount;
                 product.DiscountApplied = true;    
            }

            return RedirectToAction("Index");

        }
    }
}
