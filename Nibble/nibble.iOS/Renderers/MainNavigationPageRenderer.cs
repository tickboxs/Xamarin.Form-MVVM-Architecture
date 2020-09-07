using System;
using nibble.Pages.Main;
using Xamarin.Forms;
using nibble.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(MainNavigationPage), typeof(MainNavigationPageRenderer))]
namespace nibble.iOS.Renderers
{
    public class MainNavigationPageRenderer: NavigationRenderer
    {
        public override void PushViewController(UIViewController viewController, bool animated)
        {
            base.PushViewController(viewController, true);
        }
    }

}
