namespace Shopping_Cart.Services
{
    public interface ICustomer
    {
        public int CoutomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }

    }
}
