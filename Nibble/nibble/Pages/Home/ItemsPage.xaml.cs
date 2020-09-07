using System;
using System.Collections.Generic;
using nibble.ViewModels.Home;
using Xamarin.Forms;
using nibble.Domains;
using nibble.ViewModels;
using System.Diagnostics;
using nibble.Attributes;

namespace nibble.Pages.Home
{
    [Router(Path = "items")]
    public partial class ItemsPage : BaseContentPage<ItemsPageViewModel>
    {

        public ItemsPage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            var itemViewModel = e.Item as ItemViewModel;
            VM.ItemTappedCommand.Execute(itemViewModel.ToItem());
        }

    }
}
