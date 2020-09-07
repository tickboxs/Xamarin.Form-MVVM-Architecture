using System;
namespace nibble.Domains
{
    public class PieChartData
    {

        public PieChartData(double value)
        {
            Value = value;
        }

        public double Value { private set; get; }
    }
}
