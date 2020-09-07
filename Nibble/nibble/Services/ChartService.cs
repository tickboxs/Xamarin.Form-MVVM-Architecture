using System;
using System.Collections.Generic;
using nibble.Domains;
using nibble.Interfaces;

namespace nibble.Services
{
    public class ChartService:IChartService
    {
        // Currently Use Random Number to Simulate Data Change
        public IList<BarChartData> GetBarChartData()
        {
            return new List<BarChartData>
            {
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000),
                new BarChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000),1583218360000)
            };

        }

        public IList<PieChartData> GetPieChartData()
        {
            return new List<PieChartData>
            {
                new PieChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 100)),
                new PieChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 100)),
                new PieChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 100)),
                new PieChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 100)),
                new PieChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 100)),
                new PieChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 100)),
                new PieChartData(new Random(Guid.NewGuid().GetHashCode()).Next(1, 100))
            };
        }
    }
}
