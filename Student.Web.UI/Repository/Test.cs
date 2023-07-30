using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class Test 
    {
        public string GetString()
        {
           var p= System.Configuration.ConfigurationManager.AppSettings["shivam"];
            return p;
        }
    }
}
