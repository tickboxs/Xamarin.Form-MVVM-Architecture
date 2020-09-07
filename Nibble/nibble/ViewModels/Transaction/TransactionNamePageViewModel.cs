using System;
using System.Windows.Input;
using nibble.Events;
using nibble.Interfaces;
using nibble.Services;
using Autofac;
using Xamarin.Forms;
using nibble.Constants;
using System.Diagnostics;

namespace nibble.ViewModels.Transaction
{
    public class TransactionNamePageViewModel:BaseViewModel
    {
        private IPageService _pageService = DIContainer.Current.Resolve<IPageService>();

        public ICommand SaveCommand { get; private set; }

        public event EventHandler<TransactionNameEventArgs> NameConfirmedHandler;

        private string _name;
        public string Name
        {
            set
            {
                SetValue(ref _name, value);
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
            }

            get
            {
                return _name;
            }
        }

        public bool IsSaveButtonEnabled
        {
            get
            {
                return !string.IsNullOrEmpty(Name);
            }
        }

        public string SaveButtonBackgroundColor
        {
            get
            {
                return string.IsNullOrEmpty(Name) ? Theme.Silver : Theme.Purple;
            }
        }

        public TransactionNamePageViewModel()
        {
            SaveCommand = new Command((object sender) => Save(sender));
        }

        private void Save(object sender)
        {
            Debug.Assert(NameConfirmedHandler != null, "NameConfirmedHandler is null,do not to forget to initialize it");
            if (NameConfirmedHandler != null)
            {
                NameConfirmedHandler.Invoke(sender, new TransactionNameEventArgs { Name = Name });
            }
            _pageService.PopAsync();
        }

    }
}
