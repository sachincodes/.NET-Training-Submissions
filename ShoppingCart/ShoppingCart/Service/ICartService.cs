using ShoppingCart.Models;

namespace ShoppingCart.Service
{
    public interface ICartService
    {
        ShopCart GetCartData();
        ShopCart CalculatePrice(ShopCart model);
    }
}
