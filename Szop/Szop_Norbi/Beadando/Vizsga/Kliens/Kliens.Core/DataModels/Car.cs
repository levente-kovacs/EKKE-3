using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.Core
{
    public class Car
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string vin { get; set; }
        public string color { get; set; }
        public int modelYear { get; set; }
        public int numOfCylinders { get; set; }
        public int engineDisplacement { get; set; }
        public string fuel { get; set; }
        public int user_id { get; set; }
    }
}
