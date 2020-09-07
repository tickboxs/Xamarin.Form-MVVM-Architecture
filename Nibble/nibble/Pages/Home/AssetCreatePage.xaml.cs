using System;
using System.Collections.Generic;
using nibble.ViewModels.Home;
using Xamarin.Forms;
using nibble.ViewModels;
using System.Diagnostics;
using nibble.Attributes;

namespace nibble.Pages.Home
{
    [Router(Path = "asset/create")]
    public partial class AssetCreatePage : BaseContentPage<AssetCreatePageViewModel>
    {

        public AssetCreatePage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        void InputNameTapped(System.Object sender, System.EventArgs e)
        {
            VM.InputNameCommand.Execute(null);
        }

        void ChooseTypeTapped(System.Object sender, System.EventArgs e)
        {
            VM.ChooseTypeCommand.Execute(null);
        }

        void InputBalanceTapped(System.Object sender, System.EventArgs e)
        {
            VM.InputBalanceCommand.Execute(null);
        }

    }
}
