using Ecommerce.Models;

namespace Ecommerce
{
    public class AddProduct : Interface.ProductInterface
    {
        
        public static Dictionary<string, ProductModel> ProductData = new Dictionary<string, ProductModel>();

        public void AddProducts(ProductModel collection) {
            ProductData.Add(collection.ProductId, collection);
        }
    }
}
