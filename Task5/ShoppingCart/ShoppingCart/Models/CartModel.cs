namespace ShoppingCart.Models
{
    public class CartModel
    {
     
        public CustomerModel? customer { get; set; }
        public AddressModel? address { get; set; }
        public decimal allPrice { get; set; }
        public decimal netAmount { get; set; }
        public decimal saveAmount { get; set; }
        public int totalItem { get; set; }
        public List<CartDetail> cartList { get; set; }
        public CartModel() {
            customer=new CustomerModel();
            address=new AddressModel();
            cartList=new List<CartDetail>();
        }
    }
    public class CartDetail
    {
        public int productId { get; set; }
        public string? productName { get; set; }
        public decimal productPrice { get; set; }
        public string? productImage { get; set; }
        public string? productAlt { get; set; }
        public decimal discount { get; set; }
        public decimal discountAmount { get; set; }
        public int quantity { get; set; }
        
    }
}
