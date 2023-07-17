namespace Shopping_Cart.Models
{
    public class CartViewModel
    {
        public List<Products> products { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
