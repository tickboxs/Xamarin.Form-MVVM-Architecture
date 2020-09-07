using System;
using System.Collections.Generic;
using nibble.Events;
using Xamarin.Forms;
using nibble.ViewModels.Home;
using nibble.ViewModels;
using System.Diagnostics;
using nibble.Attributes;

namespace nibble.Pages.Home
{
    [Router(Path = "asset/name")]
    public partial class AssetNamePage : BaseContentPage<AssetNamePageViewModel>
    {

        public AssetNamePage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            nameEntry.Focus();
        }
    }
}
