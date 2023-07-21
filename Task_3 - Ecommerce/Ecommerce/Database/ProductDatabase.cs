
using Ecommerce.Models;

namespace Ecommerce.Database
{
    public class ProductDatabase : Interfaces.Product
    {
        public static Dictionary<string, ProductModel> ProductDict = new Dictionary<string, ProductModel>();

        public void AddProduct(ProductModel model)
        {
            ProductDatabase.ProductDict.Add(model.ProductId, model);
        }


        public List<ProductModel> DisplayProducts()
        {
            List<ProductModel> products = new List<ProductModel>();

            foreach (KeyValuePair<string, ProductModel> prod in ProductDict)
            {
                products.Add(prod.Value);
            }
            return products;
        }
    }

}
