using ShoppingCart.Models;

namespace ShoppingCart.Service
{
    public class CartService: ICartService
    {
        public CartService() { }
        public ShopCart GetCartData()
        {
            try
            {
                ShopCart model = new ShopCart();
                model.Customer.Name = "Manisha" ;
                model.CartList = new List<CartDetail>();
                decimal totalPrice = 0;
                decimal totalDiscount = 0;
                decimal netAmount = 0;

                foreach (var item in model.CartList)
                {
                    decimal discount = (item.ProductPrice * item.Discount) / 100;
                    totalDiscount += discount;
                    totalPrice += item.ProductPrice;
                }

                netAmount = totalPrice - totalDiscount;

                model.TotalItem = model.CartList.Count;
                model.SaveAmount = totalDiscount;
                model.NetAmount = netAmount;
                model.Price = totalPrice;

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ShopCart CalculatePrice(ShopCart cart)
        {
            try
            {
                decimal totalPrice = 0;
                decimal totalDiscount = 0;
                decimal netAmount = 0;

                foreach (var item in cart.CartList)
                {
                    decimal discount = (item.Quantity * item.ProductPrice * item.Discount) / 100;
                    totalDiscount += discount;
                    totalPrice += item.ProductPrice;
                }

                netAmount = totalPrice - totalDiscount;

                cart.TotalItem = cart.CartList.Count;
                cart.SaveAmount = totalDiscount;
                cart.NetAmount = netAmount;
                cart.Price = totalPrice;

                return cart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
