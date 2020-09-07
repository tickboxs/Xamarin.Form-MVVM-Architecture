using System;
using System.Collections.Generic;
using nibble.ViewModels.Home;
using nibble.Pages.Chart;
using nibble.ViewModels;
using Xamarin.Forms;
using System.Diagnostics;
using nibble.Attributes;

namespace nibble.Pages.Home
{
    [Router(Path = "home")]
    public partial class HomePage : BaseContentPage<HomePageViewModel>
    { 

        public HomePage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        void ListView_AssetTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            VM.AssetTappedCommand.Execute(null);
        }

    }
}
