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
using nibble.Domains;
using nibble.Constants;
using Autofac;
using System.Diagnostics;

namespace nibble.ViewModels.Home
{
    public class AssetCreatePageViewModel:BaseViewModel
    {
        public IPageService pageService = DIContainer.Current.Resolve<IPageService>();
        public IAssetService assetService = DIContainer.Current.Resolve<IAssetService>();

        public event EventHandler<EventArgs> CreateAssetHandler;
        
        private bool IsCreateMode { get; set; }

        // Pages
        private AssetNamePage _assetNamePage;
        private AssetBalancePage _assetBalancePage;


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetValue(ref _name, value);
                OnPropertyChanged(nameof(NameString));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
                OnPropertyChanged(nameof(NameTextColor));
            }
        }

        public string NameString
        {
            get
            {
                if (Name == null)
                {
                    return AppResources.Name;
                }
                else
                {
                    return Name;
                }
            }
        }

        public string NameTextColor
        {
            get
            {
                return string.IsNullOrEmpty(Name) ? Theme.Silver : Theme.Dark;
            }
        }

        private AssetType? _type;
        public AssetType? Type
        {
            get
            {
                return _type;
            }
            set
            {
                SetValue(ref _type, value);
                OnPropertyChanged(nameof(TypeName));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
                OnPropertyChanged(nameof(TypeTextColor));
                OnPropertyChanged(nameof(TypeImage));
            }
        }

        public string TypeName
        {
            get
            {
                return AssetTypeToString(Type);
            }
        }

        public string TypeTextColor
        {
            get
            {
                return Type == null ? Theme.Silver : Theme.Dark;
            }
        }

        public string TypeImage
        {
            get
            {
                return AssetTypeToAssetImage(Type);
            }
        }

        private double _balance;
        public double Balance
        {
            get { return _balance; }
            set
            {
                SetValue(ref _balance, value);
                OnPropertyChanged(nameof(BalanceString));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
                OnPropertyChanged(nameof(BalanceTextColor));
            }
        }

        public string BalanceString
        {
            get
            {
                if (Balance == 0)
                {
                    return AppResources.Balance;
                }
                else
                {
                    return Balance.ToString();
                }
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
                return !string.IsNullOrEmpty(Name) && (Type != null) && (Balance != 0);
            }
        }

        public string SaveButtonBackgroundColor
        {
            get
            {
                return IsSaveButtonEnabled ? Theme.Purple : Theme.Silver;
            }
        }

        public string SaveButtonName
        {
            get
            {
                return IsCreateMode ? AppResources.CreateNow : AppResources.Save;
            }
        }

        public AssetCreatePageViewModel()
        {
            IsCreateMode = false;

            InputNameCommand = new Command(InputName);
            ChooseTypeCommand = new Command(ChooseType);
            InputBalanceCommand = new Command(InputBalance);
            SaveCommand = new Command(Save);
        }

        public AssetCreatePageViewModel(Asset asset):this()
        {
            
            IsCreateMode = true;

            Type = asset.Type;
            Name = asset.Name;
            Balance = asset.Balance;
        }

        public ICommand InputNameCommand { get; private set; }
        public ICommand ChooseTypeCommand { get; private set; }
        public ICommand InputBalanceCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        private async void InputName()
        {
            //_assetNamePage = new AssetNamePage(Name);
            //_assetNamePage.VM.NameConfirmedHandler += AssetNamePage_NameConfirmedHandler;
            Router.Navigate("asset/name", new AssetNamePageViewModel(Name));
        }

        private void AssetNamePage_NameConfirmedHandler(object sender, Events.AssetNameEventArgs e)
        { 
            Name = e.Name;
        }

        private async void ChooseType()
        {
            string result = Router.Action(
                "actionsheet",
                new object[] {
                    AppResources.ChooseType,
                    AppResources.Cancel,
                    AppResources.Destruction,
                    new string[] {
                        AppResources.Cash,
                        AppResources.Card,
                        AppResources.Bitcoin,
                        AppResources.Property } }) as string;
            if (!result.Equals(AppResources.Cancel) &&
                !result.Equals(AppResources.Destruction))
            {

                Type = NameToAssetType(result);
            }

        }

        private async void InputBalance()
        {
            //_assetBalancePage = new AssetBalancePage(Balance);
            //_assetBalancePage.VM.BalanceConfirmedHandler += AssetBalancePage_BalanceConfirmedHandler;

            await Router.Navigate("asset/balance", new AssetBalancePageViewModel(Balance));
        }

        private void AssetBalancePage_BalanceConfirmedHandler(object sender, Events.AssetBalanceEventArgs e)
        {
            Balance = e.Balance;
        }

        private async void Save()
        {

            assetService.CreateAsset(new Asset(0, (AssetType)Type, Name,Balance));

            Debug.Assert(CreateAssetHandler != null, "CreateAssetHandler is null,do not to forget to initialize it");
            if (CreateAssetHandler != null)
            {
                CreateAssetHandler.Invoke(null, null);
            }
            
            await Router.Pop();
        }

        private AssetType NameToAssetType(string name)
        {
            if (name.Equals(AppResources.Cash))
            {
                return AssetType.Cash;
            }
            else if (name.Equals(AppResources.Card))
            {
                return AssetType.Card;
            }
            else if (name.Equals(AppResources.Bitcoin))
            {
                return AssetType.Bitcoin;
            }
            else
            {
                return AssetType.Property;
            }
        }

        private string AssetTypeToString(AssetType? assetType)
        {
            if (assetType == null)
            {
                return AppResources.Type;
            }

            if (assetType == AssetType.Cash)
            {
                return AppResources.Cash;
            }
            else if (assetType == AssetType.Card)
            {
                return AppResources.Card;
            }
            else if (assetType == AssetType.Bitcoin)
            {
                return AppResources.Bitcoin;
            }
            else
            {
                return AppResources.Property;
            }
        }

        private string AssetTypeToAssetImage(AssetType? assetType)
        {
            if (assetType == null)
            {
                return "asset_type";
            }

            if (assetType == AssetType.Cash)
            {
                return "cash";
            }
            else if (assetType == AssetType.Card)
            {
                return "card";
            }
            else if (assetType == AssetType.Bitcoin)
            {
                return "bitcoin";
            }
            else
            {
                return "property";
            }
        }

        ~AssetCreatePageViewModel()
        {
            if (_assetNamePage != null)
            {
                //_assetNamePage.VM.NameConfirmedHandler -= AssetNamePage_NameConfirmedHandler;
            }

            if (_assetBalancePage != null)

            {
                //_assetBalancePage.VM.BalanceConfirmedHandler -= AssetBalancePage_BalanceConfirmedHandler;
            }
            
        }
    }
}
