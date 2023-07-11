namespace Ecommerce.Models


{
    public class ProductModel
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImage { get; set; }
        public float? ProductPrice { get; set; }

        public ProductModel()
        {
            ProductId = Guid.NewGuid().ToString();
        }

    }
}
