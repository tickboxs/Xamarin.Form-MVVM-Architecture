using System;
using System.Collections.Generic;
using nibble.ViewModels.Transaction;
using XamForms.Controls;
using nibble.Domains;
using Xamarin.Forms;
using nibble.ViewModels;
using System.Diagnostics;
using nibble.Attributes;

namespace nibble.Pages.Transaction
{
    [Router(Path = "transaction")]
    public partial class TransactionPage : BaseContentPage<TransactionPageViewModel>
    {
        public TransactionPage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        void Type_Tapped(System.Object sender, System.EventArgs e)
        {
            VM.TypeChooseCommand.Execute(null);
        }

        void Note_Tapped(System.Object sender, System.EventArgs e)
        {
            VM.WriteNoteCommand.Execute(null);
        }

        // Calendar Popped Up
        async void Calendar_Tapped(System.Object sender, System.EventArgs e)
        {
            // Custom Animation
            //CalendarContainer.IsVisible = true;
            //Calendar.TranslationY = Calendar.Height;
            //await CalendarCover.FadeTo(0.4);
            //await Calendar.TranslateTo(0, 0);

        }

        async void Calendar_DateClicked(System.Object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            //// Custom Animation
            //await Calendar.TranslateTo(0, Calendar.Height);
            //await CalendarCover.FadeTo(0);
            //Calendar.TranslationY = 0;
            //CalendarContainer.IsVisible = false;

            //VM.TapCalendarCommand.Execute(null);
        }

        void Amount_Tapped(System.Object sender, System.EventArgs e)
        {
            VM.TapAmountCommand.Execute(null);
        }

    }
}
