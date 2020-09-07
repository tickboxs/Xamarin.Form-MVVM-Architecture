using System;
using Xamarin.Forms;
using nibble.Controls;
using nibble.iOS.Renderers;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using nibble.iOS.Controls;

[assembly: ExportRenderer(typeof(SlidingSegmentView), typeof(SlidingSegmentViewRenderer))]
namespace nibble.iOS.Renderers
{
    public class SlidingSegmentViewRenderer: ViewRenderer<SlidingSegmentView,CLSlidingSegmentView>
    {
        CLSlidingSegmentView slidingSegmentView;

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
                    // extract parameters from xaml
                    var configs = e.NewElement.Configs;
                    var unselectTextColor = e.NewElement.UnselectedTextColor;
                    var backgroundColor = e.NewElement.BackgroundColor;
                    var duration = e.NewElement.Duration;

                    // create native ios control
                    slidingSegmentView = new CLSlidingSegmentView(configs, (int index)=> {
                        if (e.NewElement.Command != null)
                        {
                            e.NewElement.Command.Execute(index);
                        }
                    },backgroundColor,unselectTextColor, duration);
                    SetNativeControl(slidingSegmentView);
                }

                // Subscribe and Initialize

            }
        }

    }
}
