namespace Shopping_Cart.Models
{
    public class Customers
    {
        public string CustomerName { get; set; }
        public Cart ShoppingCart { get; set; }

        public Customers()
        {
            ShoppingCart = new Cart(); 
        }
    }
}
