using System;
using Xamarin.Forms;
using nibble.Controls;
using nibble.Droid.Renderers;
using nibble.Droid.Controls;
using Android.Content;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SlidingSegmentView), typeof(SlidingSegmentViewRenderer))]
namespace nibble.Droid.Renderers
{
    public class SlidingSegmentViewRenderer : Xamarin.Forms.Platform.Android.ViewRenderer<SlidingSegmentView,CLSlidingSegmentView>
    {
        public SlidingSegmentViewRenderer(Context context) : base(context)
        {

        }
        
        protected override void OnElementChanged(ElementChangedEventArgs<SlidingSegmentView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
             
            }
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    // Extrac parameters from xaml
                    var configs = e.NewElement.Configs;
                    var unselectTextColor = e.NewElement.UnselectedTextColor;
                    var backgroundColor = e.NewElement.BackgroundColor;
                    var duration = e.NewElement.Duration;

                    // Create Native android control
                    var slidingSegmentView = new CLSlidingSegmentView(Context, configs,backgroundColor,unselectTextColor,duration);
                    SetNativeControl(slidingSegmentView);
                }

            }
        }
    }
}
