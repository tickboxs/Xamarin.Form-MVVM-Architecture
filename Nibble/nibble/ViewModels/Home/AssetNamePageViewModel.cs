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
    public class AssetNamePageViewModel: BaseViewModel
    {
        private IPageService _pageService = DIContainer.Current.Resolve<IPageService>();

        public event EventHandler<AssetNameEventArgs> NameConfirmedHandler;
        public ICommand SaveCommand { get; private set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetValue(ref _name, value);
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
            }
        }

        private void Save(object sender)
        {
            Debug.Assert(NameConfirmedHandler != null, "NameConfirmedHandler is null,do not to forget to initialize it");
            if (NameConfirmedHandler != null)
            {
                NameConfirmedHandler.Invoke(sender, new AssetNameEventArgs { Name = Name });
            }
            Router.Pop();
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
                return IsSaveButtonEnabled ? Theme.Purple : Theme.Silver;
            }
        }

        public AssetNamePageViewModel(string name)
        {
            Name = name;
            SaveCommand = new Command((object sender) => Save(sender));
        }
    }
}
