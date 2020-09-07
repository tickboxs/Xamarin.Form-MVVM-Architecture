using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using nibble.ViewModels;
using Xamarin.Forms;
using nibble.Services;
using nibble.Pages.Home;
using nibble.Interfaces;
using nibble.Pages.Main;
using nibble.Pages.Chart;
using nibble.Constants;
using nibble.Events;
using Autofac;
using System.Diagnostics;

namespace nibble.ViewModels.Home
{
    public class AssetBalancePageViewModel:BaseViewModel
    {
        private IPageService _pageService = DIContainer.Current.Resolve<IPageService>();

        public event EventHandler<AssetBalanceEventArgs> BalanceConfirmedHandler;

        private double _balance;
        public double Balance
        {
            get {

                return _balance;
            }
            set
            {
                SetValue(ref _balance, value);
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
                OnPropertyChanged(nameof(BalanceTextColor));
            }
        }

        public string BalanceTextColor
        {
            get
            {
                return Balance == 0 ? Theme.Silver : Theme.Dark;
            }
        }

        public bool IsSaveButtonEnabled
        {
            get
            {
                return Balance != 0;
            }
        }

        public string SaveButtonBackgroundColor
        {
            get
            {
                return IsSaveButtonEnabled ? Theme.Purple : Theme.Silver;
            }
        }

        public ICommand SaveCommand { get; private set; }


        public AssetBalancePageViewModel(double balance)
        {
            Balance = balance;
            SaveCommand = new Command((object sender) => Save(sender));
        }

        private void Save(object sender)
        {
            Debug.Assert(BalanceConfirmedHandler != null, "BalanceConfirmedHandler is null,do not to forget to initialize it");
            if (BalanceConfirmedHandler != null)
            {
                BalanceConfirmedHandler.Invoke(sender, new AssetBalanceEventArgs { Balance = Balance });
            }
            Router.Pop();
        }
    }
}
