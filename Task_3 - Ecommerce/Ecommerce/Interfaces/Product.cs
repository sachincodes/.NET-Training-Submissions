using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface Product
    {
        void AddProduct(ProductModel model);
        List<ProductModel> DisplayProducts();
    }
}
