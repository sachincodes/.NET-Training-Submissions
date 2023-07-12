namespace Ecommerce.Models
{
    public class IPhone :IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DiscountApplied { get; set; } = false;
        public int Price { get; set; }
        private int discount = 5; 
        public  int  Discount()
        {   int d= (this.Price * discount) / 100; ;
            this.Price = this.Price - d;
            return d; 
        }
    }
}
