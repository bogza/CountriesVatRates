using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VatRatesCalculator.Model;

namespace VatRatesCalculator
{
    public static class VatRatesReader
    {
        internal static RootObject ReadRatesfromURL(string _vatURL)
        {
            string jsonString = string.Empty;

            using (WebClient wc = new WebClient())
            {
                jsonString = wc.DownloadString(_vatURL);
            }

            var vatRates = JsonConvert.DeserializeObject<RootObject>(jsonString);

            return vatRates;
        }
    }
}
