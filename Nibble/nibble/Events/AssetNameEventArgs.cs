using System;

namespace nibble.Events
{
    public class AssetNameEventArgs:EventArgs
    {

        public string Name { get; set; }

        public AssetNameEventArgs()
        {
            
        }
    }
}
