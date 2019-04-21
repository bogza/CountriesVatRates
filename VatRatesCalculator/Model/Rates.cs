using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatRatesCalculator.Model
{
    public class Rates
    {
        public double super_reduced { get; set; }
        public double reduced { get; set; }
        public double standard { get; set; }
        public double? reduced1 { get; set; }
        public double? reduced2 { get; set; }
        public double? parking { get; set; }
    }
}
