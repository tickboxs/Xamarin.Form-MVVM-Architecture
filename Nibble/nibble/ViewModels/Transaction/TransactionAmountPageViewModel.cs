using System;
using nibble.Constants;

namespace nibble.ViewModels.Transaction
{
    public class TransactionAmountPageViewModel: BaseViewModel
    {

        private double _amount;
        public double Amount
        {
            set
            {
                SetValue(ref _amount, value);
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
            }

            get
            {
                return _amount;
            }
        }

        public string AmountTextColor
        {
            get
            {
                return Amount == 0 ? Theme.Silver : Theme.Dark;
            }
        }

        public bool IsSaveButtonEnabled
        {
            get
            {
                return Amount != 0;
            }
        }

        public string SaveButtonBackgroundColor
        {
            get
            {
                return Amount == 0 ? Theme.Silver : Theme.Purple;
            }
        }

        public TransactionAmountPageViewModel(double amount)
        {
            Amount = amount;
        }

    }
}
