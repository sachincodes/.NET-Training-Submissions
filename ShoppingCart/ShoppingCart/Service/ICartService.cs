using ShoppingCart.Models;

namespace ShoppingCart.Service
{
    public interface ICartService
    {
        CartModel GetCartData();
        CartModel CalculatePrice(CartModel model);
    }
}
