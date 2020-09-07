
using Xamarin.Forms;
using nibble.Pages.Main;
using nibble.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Views;
using nibble.Droid.Controls;
using nibble.Droid.Utilities;

// https://github.com/xamarin/Xamarin.Forms/blob/7a52542d50797ccc69ae1d8dd84259190d96bdb4/Xamarin.Forms.Platform.Android/AppCompat/TabbedPageRenderer.cs
// Must using this in case you would like have Android ViewPager Swipable
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

[assembly: ExportRenderer(typeof(MainTabbedPage), typeof(MainTabbedPageRenderer))]
namespace nibble.Droid.Renderers
{
    public class MainTabbedPageRenderer : TabbedPageRenderer
    {
        private static MainTabbedPageRenderer _shared;

        private ViewPager _viewPager;
        private CLMainTabBar TabBar { get; set; }
        private Activity _activity;

        public MainTabbedPageRenderer(Context context) : base(context)
        {
            _activity = context as Activity;
            _shared = this;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            // Disable ViewPager Swipability
            Element.OnThisPlatform().SetIsSwipePagingEnabled(false);

            for (int i = 0; i < (GetChildAt(0) as ViewGroup).ChildCount; i++)
            {
                var view = (GetChildAt(0) as ViewGroup).GetChildAt(i);
                if (view is BottomNavigationView)
                {
                    view.RemoveFromParent();
                }

                else if (view is ViewPager)
                {
                    _viewPager = view as ViewPager;
                }
            }

            TabBar = new CLMainTabBar(_activity, new string[] { "home", "profile" },
                (int index) =>
                {
                    // Change Page Without Animation
                    _viewPager.SetCurrentItem(index, false);
                });

            AddView(TabBar);

        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {

            int BottomTabBar_Height = (TabBar.Visibility == ViewStates.Visible ? 60 : 0);
            base.OnLayout(changed, l, t, r, b - DensityUtil.Dp2px(_activity, BottomTabBar_Height));

            // Layout TabBar
            TabBar.Layout(0, b - DensityUtil.Dp2px(_activity, BottomTabBar_Height), r, b);

        }

        public static void ShowAndroidTabBar()
        {
            _shared.TabBar.Visibility = ViewStates.Visible;
        }

        public static void HideAndroidTabBar()
        {
            _shared.TabBar.Visibility = ViewStates.Invisible;
        }
    }

}
