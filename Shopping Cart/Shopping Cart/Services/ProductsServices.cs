using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public class ProductsServices : IProducts
    {
        public List<Models.Product> GetAllProduct()
        {
            List<Models.Product> products = GetProduct();
            return products;
        }
        private List<Models.Product> GetProduct()
        {
            List<Models.Product> productList = new List<Models.Product>();
            productList.Add(new Models.Product
            {
                ProductId = 1,
                ProductName = "Earphone",
                ProductImage = "/img/earphone.png",
                ProductPrice = 450,
            });
            productList.Add(new Models.Product
            {
                ProductId = 2,
                ProductName = "Mouse",
                ProductImage = "/img/mouse.jpg",
                ProductPrice = 500,
            });
            productList.Add(new Models.Product
            {
                ProductId = 3,
                ProductName = "Keyboard",
                ProductImage = "/img/keyboard.jpg",
                ProductPrice = 200,
            });


            productList.Add(new Models.Product
            {
                ProductId = 5,
                ProductName = "Watch",
                ProductImage = "/img/watch.jpg",
                ProductPrice = 1500,
            });

            return productList;
        }
    }
}
