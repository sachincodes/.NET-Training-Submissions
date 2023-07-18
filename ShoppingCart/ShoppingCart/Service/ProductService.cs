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
                discount = Convert.ToDecimal(5),
                productPrice = Convert.ToDecimal(40000.00),
            });
            productList.Add(new ProductModel
            {
                productId = 2,
                productName = "Dress 2",
                productImage = "/product/dress2.jpg",
                productAlt = "Dress",
                discount = Convert.ToDecimal(4),
                productPrice = Convert.ToDecimal(400.00),
            });
            productList.Add(new ProductModel
            {
                productId = 3,
                productName = "Dress 3",
                productImage = "/product/dress3.png",
                discount = Convert.ToDecimal(2.5),
                productPrice = Convert.ToDecimal(1200.00),
            });
           

            productList.Add(new ProductModel
            {
                productId = 5,
                productName = "Watch 1",
                productImage = "/product/watch1.jpg",
                productAlt = "Watch",
                productPrice = Convert.ToDecimal(1000.00),
            });

            productList.Add(new ProductModel
            {
                productId = 6,
                productName = "Watch 2",
                productImage = "/product/watch2.jpg",
                productAlt = "Watch",
                productPrice = Convert.ToDecimal(250000.00),
            });

            productList.Add(new ProductModel
            {
                productId = 7,
                productName = "Watch 3",
                productAlt = "Watch",
                productImage = "/product/watch3.jpg",
                productPrice = Convert.ToDecimal(630000)
            });
            productList.Add(new ProductModel
            {
                productId = 8,
                productName = "Watch 4",
                productAlt = "Watch",
                productImage = "/product/watch4.jpg",
                productPrice = Convert.ToDecimal(300000)
            });
            return productList;
        }

    }
}

