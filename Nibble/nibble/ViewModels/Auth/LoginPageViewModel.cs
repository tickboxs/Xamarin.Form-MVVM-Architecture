
using System.Windows.Input;
using Xamarin.Forms;
using nibble.Interfaces;
using nibble.Pages.Main;
using nibble.ViewModels.Main;
using Autofac;
using System;

namespace nibble.ViewModels.Auth
{
    public class LoginPageViewModel:BaseViewModel
    {
        public IPageService pageService = DIContainer.Current.Resolve<IPageService>();

        public LoginPageViewModel()
        {
            LoginWithAppleCommand = new Command(LoginWithApple);
            LoginWithGoogleCommand = new Command(LoginWithGoogle);
            LoginWithFaceBookCommand = new Command(LoginWithFaceBook);
            NotLoginCommand = new Command(NotLogin);
        }

        public ICommand LoginWithFaceBookCommand { get; private set; }
        public ICommand LoginWithGoogleCommand { get; private set; }
        public ICommand LoginWithAppleCommand { get; private set; }
        public ICommand NotLoginCommand { get; private set; }

        private void LoginWithFaceBook()
        {
            Router.Switch("main", new MainTabbedPageViewModel());
        }

        private void LoginWithGoogle()
        {
            Router.Switch("main", new MainTabbedPageViewModel());
        }

        private void LoginWithApple()
        {
            Router.Switch("main", new MainTabbedPageViewModel());
        }

        private void NotLogin()
        {
            Router.Switch("main", new MainTabbedPageViewModel());
        }
    }
}
