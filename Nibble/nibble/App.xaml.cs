using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using nibble.Pages.Auth;
using nibble.Pages.Chart;
using nibble.Pages;
using nibble.Pages.Profile;
using nibble.Pages.Home;
using nibble.Pages.Transaction;
using nibble.Interfaces;
using nibble.ViewModels.Auth;
using Autofac;

namespace nibble
{
    public partial class App : Application
    {

        public App()
        {
            // DIContainer Init
            DIContainer.Init();

            // Router Path
            Router.RegisterPaths();

            // Router Action
            Router.RegisterAction("actionsheet", (parameters) =>
            {
                return Router.GetActivePage().DisplayActionSheet(
                    parameters[0] as string,
                    parameters[1] as string,
                    parameters[2] as string,
                    parameters[3] as string);
            });
            Router.RegisterAction("alert", (parameters) =>
            {
                return Router.GetActivePage().DisplayAlert(
                    parameters[0] as string,
                    parameters[1] as string,
                    parameters[2] as string,
                    parameters[3] as string);
            });
            Router.RegisterAction("toast", (parameters) =>
            {
                DependencyService.Get<IToastService>().Toast(
                    parameters[0] as string,
                    (ulong)parameters[1]);
                return null;
            });

            // LoginPage as Default Page
            Router.Switch("login", new LoginPageViewModel());

            // Xaml
            InitializeComponent();
        }

        // App Life Cycle
        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
