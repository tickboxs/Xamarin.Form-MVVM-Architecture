using System;
using Xamarin.Forms;
using nibble.Pages.Chart;
using nibble.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using Masonry;

// Base UIViewController For Pages
[assembly: ExportRenderer(typeof(ChartIncomePage), typeof(ContentPageRenderer))]
[assembly: ExportRenderer(typeof(ChartPage), typeof(ContentPageRenderer))]
namespace nibble.iOS.Renderers
{
    public class ContentPageRenderer : PageRenderer
    {
        public ContentPageRenderer()
        {

        }

    }
}
