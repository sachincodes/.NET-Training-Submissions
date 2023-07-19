using ShoppingCart.Models;

namespace ShoppingCart.Service
{
    public interface IProductService
    {
        List<ProductModel> GetAllProduct();
    }
}
