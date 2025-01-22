using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public static class CohenSutherlandHelper
    {
        public const byte INSIDE = 0; //0000
        public const byte LEFT = 1;   //0001
        public const byte RIGHT = 2;  //0010
        public const byte TOP = 4;    //0100
        public const byte BOTTOM = 8; //1000

    }
}
