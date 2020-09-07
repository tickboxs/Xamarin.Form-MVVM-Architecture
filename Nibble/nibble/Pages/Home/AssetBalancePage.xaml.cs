using System;
using System.Collections.Generic;
using nibble.Events;
using Xamarin.Forms;
using nibble.ViewModels.Home;
using nibble.ViewModels;
using System.Diagnostics;
using nibble.Pages;
using nibble.Attributes;

namespace nibble.Pages.Home
{
    [Router(Path = "asset/balance")]
    public partial class AssetBalancePage : BaseContentPage<AssetBalancePageViewModel>
    {

        public AssetBalancePage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            balanceInput.Focus();
        }
    }
}
