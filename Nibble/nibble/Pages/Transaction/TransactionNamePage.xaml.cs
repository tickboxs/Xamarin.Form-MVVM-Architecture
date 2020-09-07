using System;
using System.Collections.Generic;
using nibble.ViewModels.Transaction;
using Xamarin.Forms;
using nibble.Events;
using System.Diagnostics;
using nibble.ViewModels;
using nibble.Attributes;

namespace nibble.Pages.Transaction
{
    [Router(Path = "transaction/name")]
    public partial class TransactionNamePage : BaseContentPage<TransactionNamePageViewModel>
    {

        public TransactionNamePage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            nameEntry.Focus();
        }
    }
}
