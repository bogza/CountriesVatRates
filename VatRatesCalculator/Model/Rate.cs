using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatRatesCalculator.Model
{
    public class Rate
    {
        public string name { get; set; }
        public string code { get; set; }
        public string country_code { get; set; }
        public List<Period> periods { get; set; }
    }
}
