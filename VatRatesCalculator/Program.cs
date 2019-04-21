using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatRatesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            VatRatesPrinter vatPrinter = new VatRatesPrinter();
            vatPrinter.PrintRates();
        }
    }
}
