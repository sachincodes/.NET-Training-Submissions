namespace Ecommerce.Models
{
    public interface IProduct
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  int  Price { get; set; }

        public bool DiscountApplied { get; set; } 
        public   int  Discount(); 
       
    }
}
