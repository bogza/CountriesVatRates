using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VatRatesCalculator.Model;

namespace VatRatesCalculator
{
    public class VatRatesPrinter
    {
        readonly string _vatURL = ConfigurationManager.AppSettings["VatRatesURL"];

        internal void PrintRates()
        {
            RootObject vatRates = VatRatesReader.ReadRatesfromURL(_vatURL);

            List<CountryStandardVat> countryStandardVats = VatRatesUtils.GetCountryAndVatInfo(vatRates);            

            var cheapestVats = VatRatesUtils.GetTopThreeCheapestVats(countryStandardVats);
            Console.WriteLine($"Top {cheapestVats.Count} cheapest VATs:");
            foreach (var vat in cheapestVats)
            {
                Console.WriteLine($"Country: {vat.Name} - Standard VAT: {vat.StandardVat}");
            }

            var expensveVats = VatRatesUtils.GetTopThreeMostExpensiveVats(countryStandardVats);
            Console.WriteLine($"Top {expensveVats.Count()} most expensive VATs:");
            foreach (var vat in expensveVats)
            {
                Console.WriteLine($"Country: {vat.Name} - Standard VAT: {vat.StandardVat}");
            }

            Console.ReadLine();
        }
    }
}
