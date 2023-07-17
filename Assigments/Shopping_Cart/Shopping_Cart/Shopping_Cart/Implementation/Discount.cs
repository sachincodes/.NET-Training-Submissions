using Shopping_Cart.Interfaces;

namespace Shopping_Cart.Implementation
{
    public class Discount : IDiscount
    {
        public decimal ProductDiscount(decimal amount)
        {
            if (amount >= 100)
            {
                amount *= 0.9m; // 10% discount
            }
            return amount;
        }
    }
}
