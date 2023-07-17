namespace ShoppingCart.Models
{
    public class Product
    {
        public Product() { }
       public List<ProductModel> Products { get; set;}
    }
    public class ProductModel
    {
        public int productId { get; set; }
        public string? productName { get; set; }
        public decimal productPrice { get; set; }
        public string? productImage { get; set; }
        public string? productAlt { get; set; }
        public decimal discount { get; set; }
    }
}
