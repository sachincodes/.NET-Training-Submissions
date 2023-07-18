using Microsoft.AspNetCore.Cors.Infrastructure;
using Newtonsoft.Json;
using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public class ShoppingCartServices : IShoppingCart
    {
        public List<ShoppingCartServices> AddCart(ShoppingCartServices shoppingCart)
        {
            List<ShoppingCartServices> shoppingCarts = new List<ShoppingCartServices>();
            shoppingCarts.Add(shoppingCart);
            return shoppingCarts;
        }

        public double CalculatePrice(ShoppingCarts shoppingCarts)
        {
            try
            {
                double totalAmount = 0;

                foreach (var item in shoppingCarts.shoppingCartDetails)
                {
                    if (item.Item > 1)
                    {
                        totalAmount += (item.ProductPrice*item.Item);
                    }
                    else
                    {
                        totalAmount += item.ProductPrice;
                    }
                    
                }

                return totalAmount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public ShoppingCarts GetCartData()
        {
            throw new NotImplementedException();
        }
    }
}
