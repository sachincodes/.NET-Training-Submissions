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
                model.customer.CustomerName = "Sadiqa";
                model.address.Address = "Dehradun";
                model.cartList = GetCartList();
                decimal totalPrice =0,totalDiscount =0, netAmount = 0 ;
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
                throw;
            }
        }

        public CartModel CalculatePrice(CartModel model)
        {
            try
            {
                Decimal totalPrice = 0,totalDiscount =0,netAmount = 0;
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
                throw;
            }
        }
        private List<CartDetail> GetCartList()
        {
            List<CartDetail> cartList = new List<CartDetail>();
            cartList.Add(new CartDetail
            {
                productId = 1,
                productName = "LV Luggage Bag",
                productImage = "/product/luggage-bags.jpg",
                productAlt = "Luggage Bag",
                discount = decimal.Parse("5"),
                productPrice = decimal.Parse("589000"),
                quantity=1
            });
            cartList.Add(new CartDetail
            {
                productId = 2,
                productName = "Sling Bag",
                productImage = "/product/sling-bag.png",
                productAlt = "Sling Bag",
                discount = decimal.Parse("4"),
                productPrice = decimal.Parse("345600"),
            });
            return cartList;
        }
    }
}
