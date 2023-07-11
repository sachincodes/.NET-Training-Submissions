namespace Ecommerce.Models
{
    public class CustomerModel
    {
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set;}

        public CustomerModel()
        {
            CustomerId = Guid.NewGuid().ToString();
        }
    }
}
