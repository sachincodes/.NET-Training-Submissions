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
                model.Customer.Name = "Manisha";
                model.CartList = GetCartList();
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

        public ShopCart CalculatePrice(ShopCart model)
        {
            try
            {
                var totalPrice = Convert.ToDecimal(0);
                var totalDiscount = Convert.ToDecimal(0);
                var netAmount = Convert.ToDecimal(0);
                foreach (var item in model.CartList)
                {
                    var discount = (item.Quantity *item.ProductPrice * item.Discount) / 100;
                    totalDiscount = totalDiscount + discount;
                    totalPrice = totalPrice + item.ProductPrice;
                    netAmount = totalPrice - totalDiscount;
                }
                model.TotalItem = model.CartList.Count();
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
        private List<CartDetail> GetCartList()
        {
            List<CartDetail> cartList = new List<CartDetail>();
            //cartList.Add(new CartDetail
            //{
            //    ProductId = 1,
            //    ProductName = "Android",
            //    ProductImage = "/product/android.jpg",
            //    ProductAlt = "Android Mobile",
            //    Discount = Convert.ToDecimal(5),
            //    ProductPrice = Convert.ToDecimal(40000.00),
            //    Quantity=1
            //});
            //cartList.Add(new CartDetail
            //{
            //    ProductId = 2,
            //    ProductName = "Black Trouser",
            //    ProductImage = "/product/black_trousers.png",
            //    ProductAlt = "Black Trouser",
            //    Discount = Convert.ToDecimal(4),
            //    ProductPrice = Convert.ToDecimal(400.00),
            //});
            return cartList;
        }
    }
}
