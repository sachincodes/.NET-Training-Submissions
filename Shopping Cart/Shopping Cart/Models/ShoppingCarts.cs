namespace Shopping_Cart.Models
{
    public class ShoppingCarts
    {
        public double TotalPrice { get; set; }
        public double NetAmount { get; set; }
        public double DiscountAmount { get; set; }
        public int TotalItem { get; set; }
        public List<ShoppingCartDetail> shoppingCartDetails { get; set; }
        public ShoppingCarts()
        {
            shoppingCartDetails = new List<ShoppingCartDetail>();
        }
    }
    public class ShoppingCartDetail
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string? ProductImage { get; set; }
        public int Item { get; set; }

    }
}
