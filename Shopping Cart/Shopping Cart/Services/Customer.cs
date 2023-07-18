namespace Shopping_Cart.Services
{
    public class Customer:ICustomer
    {
        public int CoutomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public Customer(int coutomerId, string customerName, string emailId)
        {
            CoutomerId = coutomerId;
            CustomerName = customerName;
            EmailId = emailId;
        }
    }
}
