using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace nibble.Interfaces
{
    public abstract class IChart
    {
        public abstract void Draw(SKPaintSurfaceEventArgs args);
        protected SKColor GetColorByIndex(int index)
        {
            var colorIndex = index % 7;
            switch (colorIndex)
            {
                case 0:
                    return SKColors.Red;
                case 1:
                    return SKColors.Green;
                case 2:
                    return SKColors.Blue;
                case 3:
                    return SKColors.Magenta;
                case 4:
                    return SKColors.Cyan;
                case 5:
                    return SKColors.Brown;
                case 6:
                    return SKColors.Gray;
                default:
                    return SKColors.Red;
            }

        }
    }
}
