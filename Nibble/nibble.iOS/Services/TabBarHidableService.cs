using System;
using nibble.Interfaces;
using Xamarin.Forms;
using nibble.iOS.Services;
using nibble.iOS.Renderers;

[assembly: Dependency(typeof(TabBarHidableService))]
namespace nibble.iOS.Services
{
    public class TabBarHidableService : ITabBarHidableService
    {
        public void HideTabBar()
        {
            MainTabbedPageRenderer.HideIOSTabBar();
        }

        public void ShowTabBar()
        {
            MainTabbedPageRenderer.ShowIOSTabBar();
        }
    }
}
