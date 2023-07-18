using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public interface IShoppingCart
    {
        ShoppingCarts GetCartData();
        double CalculatePrice(ShoppingCarts shoppingCarts);
        List<ShoppingCartServices> AddCart(ShoppingCartServices shoppingCart);
    }
}
