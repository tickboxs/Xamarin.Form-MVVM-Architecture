using System;
using System.Collections.Generic;
using nibble.Domains;

namespace nibble.Interfaces
{
    public interface ICurrencyService
    {
        IList<Currency> GetAllCurrenies();
    }
}
