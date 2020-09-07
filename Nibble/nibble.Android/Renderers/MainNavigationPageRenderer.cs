using System;
using nibble.Pages.Main;
using nibble.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Content;

[assembly: ExportRenderer(typeof(MainNavigationPage), typeof(MainNavigationPageRenderer))]
namespace nibble.Droid.Renderers
{
    public class MainNavigationPageRenderer: NavigationPageRenderer
    {
        public MainNavigationPageRenderer(Context context) : base(context)
        {

        }
    }
}
