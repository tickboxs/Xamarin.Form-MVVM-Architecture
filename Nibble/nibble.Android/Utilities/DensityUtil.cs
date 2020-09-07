using System;
using Android.Content;

namespace nibble.Droid.Utilities
{
    public class DensityUtil
    {

        public static int Dp2px(Context context, float dpValue)
        {
            float scale = context.Resources.DisplayMetrics.Density;
            return (int)(dpValue * scale + 0.5f);
        }


        public static int Px2dp(Context context, float pxValue)
        {
            float scale = context.Resources.DisplayMetrics.Density;
            return (int)(pxValue / scale + 0.5f);
        } 

    }
}
