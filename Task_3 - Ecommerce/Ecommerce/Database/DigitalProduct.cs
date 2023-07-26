using Ecommerce.Interfaces;
using Ecommerce.Models;

namespace Ecommerce.Database
{
    public class DigitalProduct : Product
    {
        private List<ProductModel> digitalProducts = new List<ProductModel>();
        public void AddProduct(ProductModel model)
        {
            digitalProducts.Add(model);
        }

        public List<ProductModel> DisplayProducts()
        {
            return digitalProducts;
        }
    }
}
