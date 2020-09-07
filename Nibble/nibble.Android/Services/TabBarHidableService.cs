using System;
using nibble.Interfaces;
using Xamarin.Forms;
using nibble.Droid.Services;
using nibble.Droid.Renderers;

[assembly: Dependency(typeof(TabBarHidableService))]
namespace nibble.Droid.Services
{
    public class TabBarHidableService: ITabBarHidableService
    {
        public void ShowTabBar()
        {
            MainTabbedPageRenderer.ShowAndroidTabBar();
        }
        public void HideTabBar()
        {
            MainTabbedPageRenderer.HideAndroidTabBar();
        }
    }
}
