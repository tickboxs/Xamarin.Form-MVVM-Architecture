using System;

namespace nibble.Events
{
    public class AssetBalanceEventArgs:EventArgs
    {

        public double Balance { get; set; }

        public AssetBalanceEventArgs()
        {

        }

    }
}
