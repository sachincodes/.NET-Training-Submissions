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
                productName = "Chanel Bag",
                productImage = "/product/Chanel-bag.png",
                productAlt = "Chanel Bag",
                discount = decimal.Parse("5"),
                productPrice = decimal.Parse("454343"),
            });
            productList.Add(new ProductModel
            {
                productId = 2,
                productName = "Guess Tote Bag",
                productImage = "/product/guess-Tote-bag.png",
                productAlt = "Guess Tote Bag",
                discount = decimal.Parse("4"),
                productPrice = decimal.Parse("43430"),
            });
           
            productList.Add(new ProductModel
            {
                productId = 3,
                productName = "Sneakers White Violet",
                productImage = "/product/sneakers-white-violet.png",
                productAlt = "Sneakers White Violet",
                discount = decimal.Parse("3"),
                productPrice = decimal.Parse("4343460"),
            }); ;

            productList.Add(new ProductModel
            {
                productId = 4,
                productName = "IPhone 14",
                productImage = "/product/iphone-14.png",
                productAlt = "IPhone 14",
                productPrice = decimal.Parse("4545545"),
            });

            productList.Add(new ProductModel
            {
                productId = 5,
                productName = "Chanel Bag",
                productImage = "/product/Chanel-bag.png",
                productAlt = "Chanel Bag",
                discount = decimal.Parse("5"),
                productPrice = decimal.Parse("454343"),
            });
            productList.Add(new ProductModel
            {
                productId = 6,
                productName = "Guess Tote Bag",
                productImage = "/product/guess-Tote-bag.png",
                productAlt = "Guess Tote Bag",
                discount = decimal.Parse("4"),
                productPrice = decimal.Parse("43430"),
            });
          
            productList.Add(new ProductModel
            {
                productId = 7,
                productName = "Sneakers White Violet",
                productImage = "/product/sneakers-white-violet.png",
                productAlt = "Sneakers White Violet",
                discount = decimal.Parse("3"),
                productPrice = decimal.Parse("4343460"),
            }); ;

            productList.Add(new ProductModel
            {
                productId = 8,
                productName = "IPhone 14",
                productImage = "/product/iphone-14.png",
                productAlt = "IPhone 14",
                productPrice = decimal.Parse("4545545"),
            }); ;
            return productList;
        }

    }
}

