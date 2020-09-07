using System;
using System.Collections.Generic;
using System.Diagnostics;
using nibble.Events;
using nibble.ViewModels;
using nibble.ViewModels.Transaction;
using Xamarin.Forms;
using nibble.Attributes;

namespace nibble.Pages.Transaction
{
    [Router(Path="transaction/amount")]
    public partial class TransactionAmountPage : BaseContentPage<TransactionAmountPageViewModel>
    {

        public TransactionAmountPage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }


        public event EventHandler<ItemAmountEventArgs> AmountConfirmedHandler;


        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            AmountConfirmedHandler.Invoke(sender, new ItemAmountEventArgs
            {
                Amount = VM.Amount
            });
            Navigation.PopAsync();

        }

        protected override void OnAppearing()
        {
            amountInput.Focus();
        }
    }
}
