using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public interface IProducts
    {
        public List<Models.Product> GetAllProduct();
    }
}
