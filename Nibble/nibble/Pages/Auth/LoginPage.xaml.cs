using System;
using System.Collections.Generic;
using nibble.ViewModels.Auth;
using Xamarin.Forms;
using nibble.ViewModels;
using System.Diagnostics;
using nibble.Attributes;

namespace nibble.Pages.Auth
{
    [Router(Path="login")]
    public partial class LoginPage : BaseContentPage<LoginPageViewModel>
    {
        public LoginPage(BaseViewModel vm):base(vm)
        {
            InitializeComponent();
        }

    }
}
