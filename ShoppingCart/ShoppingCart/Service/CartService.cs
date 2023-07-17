using ShoppingCart.Models;

namespace ShoppingCart.Service
{
    public class CartService: ICartService
    {
        public CartService() { }
        public CartModel GetCartData()
        {
            try
            {   CartModel model = new CartModel();
                model.customer.CustomerName = "James";
                model.address.Address = "Dehradun";
                model.cartList = GetCartList();
                var totalPrice = Convert.ToDecimal(0);
                var totalDiscount = Convert.ToDecimal(0);
                var netAmount = Convert.ToDecimal(0);
                foreach (var item in model.cartList)
                {
                    var discount = (item.productPrice*item.discount) / 100;
                    totalDiscount = totalDiscount + discount;
                    totalPrice = totalPrice + item.productPrice;
                    netAmount = totalPrice - totalDiscount;
                }
                model.totalItem = model.cartList.Count();
                model.saveAmount = totalDiscount;
                model.netAmount = netAmount;
                model.allPrice = totalPrice;
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CartModel CalculatePrice(CartModel model)
        {
            try
            {
                var totalPrice = Convert.ToDecimal(0);
                var totalDiscount = Convert.ToDecimal(0);
                var netAmount = Convert.ToDecimal(0);
                foreach (var item in model.cartList)
                {
                    var discount = (item.quantity *item.productPrice * item.discount) / 100;
                    totalDiscount = totalDiscount + discount;
                    totalPrice = totalPrice + item.productPrice;
                    netAmount = totalPrice - totalDiscount;
                }
                model.totalItem = model.cartList.Count();
                model.saveAmount = totalDiscount;
                model.netAmount = netAmount;
                model.allPrice = totalPrice;
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
            cartList.Add(new CartDetail
            {
                productId = 1,
                productName = "Android",
                productImage = "/product/android.jpg",
                productAlt = "Android Mobile",
                discount = Convert.ToDecimal(5),
                productPrice = Convert.ToDecimal(40000.00),
                quantity=1
            });
            cartList.Add(new CartDetail
            {
                productId = 2,
                productName = "Black Trouser",
                productImage = "/product/black_trousers.png",
                productAlt = "Black Trouser",
                discount = Convert.ToDecimal(4),
                productPrice = Convert.ToDecimal(400.00),
            });
            return cartList;
        }
    }
}
