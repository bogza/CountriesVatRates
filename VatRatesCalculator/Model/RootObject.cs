using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatRatesCalculator.Model
{
    public class RootObject
    {
        public string details { get; set; }
        public object version { get; set; }
        public List<Rate> rates { get; set; }
    }
}
