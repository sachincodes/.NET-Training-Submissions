using Ecommerce.Interfaces;
using System.Collections.ObjectModel;

namespace Ecommerce.Database
{
    public class DBService
    {
        public Product GetProducts(string type)
        {
            if(type.Equals("digital"))
            return new DigitalProduct();
            else
                return new ProductDatabase();
        }

        public IEnumerable<int> GetList()
        {

            return new Collection<int>();
        }
    }
}
