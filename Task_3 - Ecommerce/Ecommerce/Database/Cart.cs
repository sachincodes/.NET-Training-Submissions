using Ecommerce.Models;

namespace Ecommerce.Database
{
    public class Cart : Interfaces.Cart
    {
        public static List<ProductModel> CartItems = new List<ProductModel>();
        public static Dictionary<string, int> quantity = new Dictionary<string, int>();

        public void AddToCart(ProductModel input, int ProductQuantity)
        {
            if (Cart.quantity.ContainsKey(input.ProductId))
            {
                Cart.quantity.Remove(input.ProductId);
                Cart.CartItems.Remove(ProductDatabase.ProductDict[input.ProductId]);
            }
            Cart.CartItems.Add(ProductDatabase.ProductDict[input.ProductId]);
            Cart.quantity.Add(input.ProductId, ProductQuantity);
        }

        public void RemoveFromCart(string ProductId)
        {
            Cart.CartItems.Remove(ProductDatabase.ProductDict[ProductId]);
            Cart.quantity.Remove(ProductId);
        }
    }
}
