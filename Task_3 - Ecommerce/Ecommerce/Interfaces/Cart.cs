using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    interface Cart
    {
        void AddToCart(ProductModel input, int ProductQuantity);
        void RemoveFromCart(string ProductId);
    }
}
