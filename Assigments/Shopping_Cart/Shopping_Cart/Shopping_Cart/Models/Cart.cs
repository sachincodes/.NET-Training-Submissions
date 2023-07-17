namespace Shopping_Cart.Models
{
    public class Cart
    {
        public List<Products> products;

        public Cart()
        {
            products = new List<Products>();
        }

        public void AddProduct(Products product)
        {
            products.Add(product);
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (Products product in products)
            {
                totalPrice += product.ProductPrice;
            }
            return totalPrice;
        }


    }
}
