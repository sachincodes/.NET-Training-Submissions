namespace Ecommerce.Models
{
    public class CartModel
    {
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Quantity { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductType { get; set; }
        public string? ProductCode { get; set; }
        public int? ProductPrice { get; set; }
    }
}
