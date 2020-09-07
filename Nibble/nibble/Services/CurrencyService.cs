using System;
using System.Collections.Generic;
using nibble.Interfaces;
using nibble.Domains;

namespace nibble.Services
{
    public class CurrencyService:ICurrencyService
    {
        public CurrencyService()
        {

        }

        public IList<Currency> GetAllCurrenies()
        {
            return new List<Currency> {
                new Currency
                {
                    Country = "Unitied State Of America",
                    CurrencyName = "Unitied State Of America",
                    Abbr = "ARS"

                },
                new Currency
                {
                    Country = "Kingdom Of England",
                    CurrencyName = "British Pound",
                    Abbr = "GBP"

                },
                new Currency
                {
                    Country = "Japan",
                    CurrencyName = "Japanese Yen",
                    Abbr = "JPY"

                },
                new Currency
                {
                    Country = "United State Of America",
                    CurrencyName = "United State Of America",
                    Abbr = "USD"

                },
                new Currency
                {
                    Country = "",
                    CurrencyName = "",
                    Abbr = ""

                },
                new Currency
                {
                    Country = "India",
                    CurrencyName = "Rupee",
                    Abbr = "INR"

                },
                new Currency
                {
                    Country = "Viet Nam",
                    CurrencyName = "Viet Nam Dong",
                    Abbr = "VND"

                },
                new Currency
                {
                    Country = "China",
                    CurrencyName = "Chinese Yuan",
                    Abbr = "CNY"

                }
            };
        }
    }
}
