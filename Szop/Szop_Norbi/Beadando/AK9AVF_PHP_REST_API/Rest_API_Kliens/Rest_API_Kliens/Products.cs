using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_API_Kliens
{
     public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public int user_id { get; set; }

    }
}
