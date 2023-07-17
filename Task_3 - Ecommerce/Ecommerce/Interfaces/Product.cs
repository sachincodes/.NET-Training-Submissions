using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    interface Product
    {
        void AddProduct(ProductModel model);
        List<ProductModel> DisplayProducts();
    }
}
