using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorServer
{
    internal class Motor
    {
        public string RegNum { get; set; }

        public string Type { get; set; }

        public int Kms { get; set; }

        public int Fee { get; set; }

        public bool IsRented { get; set; }

        public Motor(string regNum, string type, int kms, int fee)
        {
            RegNum = regNum;
            Type = type;
            Kms = kms;
            Fee = fee;
            IsRented = false;
        }

        public override string ToString()
        {
            return $"{RegNum}\t{Type}\t{Kms}kms\t{Fee}Ft/km\tCurrently rented: {IsRented}";
        }
    }
}
