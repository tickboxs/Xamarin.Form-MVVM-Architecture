using System;
using Xamarin.Forms;
using nibble.Pages.Main;
using nibble.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using nibble.iOS.Controls;
using UIKit;
using System.Diagnostics;
using CoreGraphics;
using Foundation;

[assembly: ExportRenderer(typeof(MainTabbedPage), typeof(MainTabbedPageRenderer))]
namespace nibble.iOS.Renderers
{
    public class MainTabbedPageRenderer : TabbedRenderer
    {
        private static MainTabbedPageRenderer _shared;
        public MainTabbedPageRenderer():base()
        {
            _shared = this;
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
                
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Replace native tabBar with CLMainTabBar
            SetValueForKeyPath(new CLMainTabBar(), new NSString("tabBar"));

            TabBar.Translucent = false;
        }


        public static void HideIOSTabBar()
        {
            _shared.TabBar.Hidden = true;
        }

        public static void ShowIOSTabBar()
        {
            _shared.TabBar.Hidden = false;
        }


    }
}
