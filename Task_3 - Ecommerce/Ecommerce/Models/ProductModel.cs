using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models


{
    public class ProductModel
    {
        [Key]
        [Required]
        public string ProductId { get; set; } = "";
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductDescription { get; set; }
        [Required]
        public float ProductPrice { get; set; } = 0;

        public ProductModel()
        {
            ProductId = Guid.NewGuid().ToString();
        }

    }
}
