using System;
namespace nibble.Domains
{
    public class BarChartData:PieChartData
    {
        public BarChartData(double value,long timestamp):base(value)
        {
            Timestamp = timestamp;
        }

        public long Timestamp { private set; get; }
    }
}
