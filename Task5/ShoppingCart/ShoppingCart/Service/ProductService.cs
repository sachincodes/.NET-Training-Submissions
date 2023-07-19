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
                productName = "Android",
                productImage = "/product/android.jpg",
                productAlt = "Android Mobile",
                discount = Convert.ToDecimal(5),
                productPrice = Convert.ToDecimal(40000.00),
            });
            productList.Add(new ProductModel
            {
                productId = 2,
                productName = "Black Trouser",
                productImage = "/product/black_trousers.png",
                productAlt = "Black Trouser",
                discount = Convert.ToDecimal(4),
                productPrice = Convert.ToDecimal(900.00),
            });
            productList.Add(new ProductModel
            {
                productId = 3,
                productName = "Black Tshirt",
                productImage = "/product/black_tshirt.png",
                discount = Convert.ToDecimal(2.5),
                productPrice = Convert.ToDecimal(1200.00),
            });
            productList.Add(new ProductModel
            {
                productId = 4,
                productName = "Brown Pent",
                productImage = "/product/brown_pent.jpeg",
                productAlt = "Brown Pent",
                discount = Convert.ToDecimal(3.5),
                productPrice = Convert.ToDecimal(1000.00),
            }); ;

            productList.Add(new ProductModel
            {
                productId = 5,
                productName = "IPhone",
                productImage = "/product/iphone.png",
                productAlt = "IPhone",
                productPrice = Convert.ToDecimal(1000.00),
            });

            productList.Add(new ProductModel
            {
                productId = 6,
                productName = "R 15",
                productImage = "/product/r15.jpg",
                productAlt = "R15",
                productPrice = Convert.ToDecimal(250000.00),
            });

            productList.Add(new ProductModel
            {
                productId = 7,
                productName = "Audi q7",
                productAlt = "Audi q7",
                productImage = "/product/audi_q7.jpeg",
                productPrice = Convert.ToDecimal(5000000)
            });
            productList.Add(new ProductModel
            {
                productId = 8,
                productName = "Audi q3",
                productAlt = "Audi q3",
                productImage = "/product/audiq3.jpg",
                productPrice = Convert.ToDecimal(7000000)
            });
            productList.Add(new ProductModel
            {
                productId = 9,
                productName = "BMW X1",
                productAlt = "BMW X1",
                productImage = "/product/bmwX1.jpg",
                productPrice = Convert.ToDecimal(7000000)
            });
            return productList;
        }

    }
}

