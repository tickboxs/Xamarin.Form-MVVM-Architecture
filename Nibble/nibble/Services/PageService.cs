

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using nibble.Interfaces;
using nibble.Pages.Auth;
using nibble.Pages.Chart;
using nibble.Pages.Home;
using nibble.Pages.Main;
using nibble.Pages.Profile;
using nibble.Pages.Transaction;
using nibble.ViewModels;


namespace nibble.Services
{
    // Replace This With Better Router
    public class PageService : IPageService
    {
        // Manually Control Push Stack Depth
        private int _pushDepth = 0;

        private Page GetActivePage()
        {
            var mainPage = Application.Current.MainPage;

            //if current mainPage is tabbedPage
            if (mainPage is TabbedPage)
            {
                return ((TabbedPage)mainPage).CurrentPage;
            }
            // else mainPage is not tabbedPage
            else
            {
                return Application.Current.MainPage;
            }
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await GetActivePage().DisplayAlert(title, message, ok, cancel);
        }

        public void PushDepthDescrease()
        {
            _pushDepth -= 1;
            if (_pushDepth <= 0)
            {
                DependencyService.Get<ITabBarHidableService>().ShowTabBar();
            }
            else
            {
                DependencyService.Get<ITabBarHidableService>().HideTabBar();
            }
        }

        public async Task PopAsync()
        {
            await GetActivePage().Navigation.PopAsync();
        }

        public async Task PushAsync(Scene scene,BaseViewModel vm)
        {
            _pushDepth += 1;
            DependencyService.Get<ITabBarHidableService>().HideTabBar();
            await GetActivePage().Navigation.PushAsync(getPageByScene(scene,vm));
        }

        public void SwitchAsync(Scene scene,BaseViewModel vm)
        {
            Application.Current.MainPage = getPageByScene(scene,vm);
        }

        public Task<string> DisplaActionSheet(string title, string cancel, string destruction, string[] buttons)
        {
            return GetActivePage().DisplayActionSheet(title,cancel, destruction, buttons);
        }


        private Page getPageByScene(Scene scene,BaseViewModel vm)
        {
            Page page;
            switch (scene)
            {
                case Scene.AssetBalance:
                    page = new AssetBalancePage(vm);
                    break;
                case Scene.AssetCreate:
                    page = new AssetCreatePage(vm);
                    break;
                case Scene.AssetName:
                    page = new AssetNamePage(vm);
                    break;
                case Scene.ChartExpense:
                    page = new ChartExpensePage(vm);
                    break;
                case Scene.ChartIncome:
                    page = new ChartIncomePage(vm);
                    break;
                case Scene.Home:
                    page = new HomePage(vm);
                    break;
                case Scene.Items:
                    page = new ItemsPage(vm);
                    break;
                case Scene.Login:
                    page = new LoginPage(vm);
                    break;
                case Scene.Profile:
                    page = new ProfilePage(vm);
                    break;
                case Scene.Transaction:
                    page = new TransactionPage(vm);
                    break;
                case Scene.TransactionAmount:
                    page = new TransactionAmountPage(vm);
                    break;
                case Scene.TransactionName:
                    page = new TransactionNamePage(vm);
                    break;
                case Scene.MainTabbed:
                    page = new MainTabbedPage(vm);
                    break;
                case Scene.Chart:
                    page = new ChartPage(vm);
                    break;
                default:
                    page = new TransactionNamePage(vm);
                    break;
            }

            return page;
        }

        public async Task PushAsync(Page page)
        {
            _pushDepth += 1;
            DependencyService.Get<ITabBarHidableService>().HideTabBar();
            await GetActivePage().Navigation.PushAsync(page);
        }

        public void SwitchAsync(Page page)
        {
            Application.Current.MainPage = page;
        }
    }
}
