using Ecommerce.Models;

namespace Ecommerce.StaticFiles
{
  static  public class Store
    { 

      public static List<IProduct>myproducts = new List<IProduct>();
        public static List<IProduct> mycart = new List<IProduct>();
             public static Dictionary<Guid, IProduct>mycartdict= new Dictionary<Guid, IProduct>() ; 
        public static  int TotalPrice=0 ; 

        }

         
    }

