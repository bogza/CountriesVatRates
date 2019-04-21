using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatRatesCalculator.Model
{
    public class Period
    {
        public string effective_from { get; set; }
        public Rates rates { get; set; }
    }
}
