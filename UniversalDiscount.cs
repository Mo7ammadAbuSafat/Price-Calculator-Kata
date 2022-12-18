using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class UniversalDiscount
    {
        public double Percentage { get; set; }

        public bool IsTaxCalculatedAfter { get; set; }

        public UniversalDiscount(double Percentage, bool IsTaxCalculatedAfter)
        {
            this.Percentage = Percentage;
            this.IsTaxCalculatedAfter = IsTaxCalculatedAfter;
        }
    }
}
