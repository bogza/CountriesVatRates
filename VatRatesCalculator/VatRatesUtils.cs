using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatRatesCalculator.Model;

namespace VatRatesCalculator
{
    public static class VatRatesUtils
    {
        internal static List<CountryStandardVat> GetCountryAndVatInfo(RootObject vatRates)
        {
            List<CountryStandardVat> countryStandardVats = new List<CountryStandardVat>();
            foreach (Rate rate in vatRates.rates)
            {
                CountryStandardVat countryStandardVat = VatRatesUtils.GetCountryStandardVatByValidDate(rate);
                countryStandardVats.Add(countryStandardVat);
            }

            return countryStandardVats;
        }

        private static CountryStandardVat GetCountryStandardVatByValidDate(Rate rate)
        {
            CountryStandardVat countryStandardVat = new CountryStandardVat { Name = rate.name };

            Period closestValidPeriod = GetClosestValidPeriod(rate.periods);
            countryStandardVat.StandardVat = closestValidPeriod.rates.standard;

            return countryStandardVat;
        }        

        private static Period GetClosestValidPeriod(List<Period> periods)
        {
            Period validPeriod = new Period();

            if (periods.Any())
            {
                periods = periods.OrderByDescending(p => p.effective_from).ToList();
                foreach (Period period in periods)
                {
                    if (period.effective_from.Substring(0, 4) == "0000")
                    {
                        period.effective_from = period.effective_from.Replace("0000", "0001");
                    }
                    bool parseOk = DateTime.TryParse(period.effective_from, out DateTime effectivity);
                    if (parseOk && effectivity <= DateTime.Today)
                    {
                        validPeriod = period;
                        break;
                    }
                }
            }

            return validPeriod;
        }

        internal static List<CountryStandardVat> GetTopThreeCheapestVats(List<CountryStandardVat> countryStandardVats)
        {
            return countryStandardVats.OrderBy(c => c.StandardVat).ToList().Take(3).ToList();
        }

        internal static List<CountryStandardVat> GetTopThreeMostExpensiveVats(List<CountryStandardVat> countryStandardVats)
        {
            return countryStandardVats.OrderByDescending(c => c.StandardVat).ToList().Take(3).ToList();
        }
    }
}
