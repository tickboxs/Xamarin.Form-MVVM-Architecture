using System;
using nibble.Domains;
using System.Collections.Generic;

namespace nibble.Interfaces
{
    public interface IChartService
    {
        IList<BarChartData> GetBarChartData();
        IList<PieChartData> GetPieChartData();
    }
}
