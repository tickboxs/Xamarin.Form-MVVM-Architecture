using System;
using System.Collections.Generic;
using System.Diagnostics;
using nibble.ViewModels;
using nibble.ViewModels.Profile;
using nibble.Attributes;
using Xamarin.Forms;

namespace nibble.Pages.Profile
{
    [Router(Path = "profile")]
    public partial class ProfilePage : BaseContentPage<ProfilePageViewModel>
    {

        public ProfilePage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
