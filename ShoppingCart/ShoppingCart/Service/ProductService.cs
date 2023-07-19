using Newtonsoft.Json;
using ShoppingCart.Models;

namespace ShoppingCart.Service
{
    public class ProductService : IProductService
    {
        public ProductService() { }
        public List<ProductModel> GetAllProduct()
        {
            try
            {
                List<ProductModel> productList = GetProduct();
                return productList;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        private List<ProductModel> GetProduct()
        {
            List<ProductModel> productList = new List<ProductModel>();
            productList.Add(new ProductModel
            {
                productId = 1,
                productName = "Dress 1",
                productImage = "/product/dreess1.jpg",
                productAlt = "dress1",
                discount = 5M,
                productPrice = 400.00M,/*'M' suffix to indicate a decimal literal*/

            });
            productList.Add(new ProductModel
            {
                productId = 2,
                productName = "Dress 2",
                productImage = "/product/dress2.jpg",
                productAlt = "Dress",
                discount = 4M,
                productPrice = 400.00M,
            });
            productList.Add(new ProductModel
            {
                productId = 3,
                productName = "Dress 3",
                productImage = "/product/dress3.png",
                discount = 2.5M,
                productPrice = 1200.00M,
            });
           

            productList.Add(new ProductModel
            {
                productId = 5,
                productName = "Watch 1",
                productImage = "/product/watch1.jpg",
                productAlt = "Watch",
                productPrice = 1100.00M,
            });

            productList.Add(new ProductModel
            {
                productId = 6,
                productName = "Watch 2",
                productImage = "/product/watch2.jpg",
                productAlt = "Watch",
                productPrice = 2500.00M
            });

            productList.Add(new ProductModel
            {
                productId = 7,
                productName = "Watch 3",
                productAlt = "Watch",
                productImage = "/product/watch3.jpg",
                productPrice = 3400M
            });
            productList.Add(new ProductModel
            {
                productId = 8,
                productName = "Watch 4",
                productAlt = "Watch",
                productImage = "/product/watch4.jpg",
                productPrice = 300.00M
            });
            return productList;
        }

    }
}

