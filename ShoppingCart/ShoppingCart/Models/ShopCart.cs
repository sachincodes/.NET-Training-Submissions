namespace ShoppingCart.Models
{
    public class ShopCart
    {
        public ShopCart()
        {
            Customer = new CustomerModel();
            CartList = new List<CartDetail>();
        }
        public CustomerModel? Customer { get; set; }
        public decimal Price { get; set; }
        public decimal NetAmount { get; set; }
        public decimal SaveAmount { get; set; }
        public int TotalItem { get; set; }
        public List<CartDetail> CartList { get; set; }
        
    }
    public class CartDetail
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductImage { get; set; }
        public string? ProductAlt { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int Quantity { get; set; }
        
    }
}
