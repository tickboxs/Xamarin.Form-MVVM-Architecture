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
using System.Collections.Generic;
using nibble.Domains;
using nibble.ViewModels.Home;
using Autofac;
using System.Linq;
using nibble.ViewModels.Chart;

namespace nibble.ViewModels.Home
{
    public class HomePageViewModel : BaseViewModel
    {
        public IPageService pageService = DIContainer.Current.Resolve<IPageService>();
        public IAssetService assetService = DIContainer.Current.Resolve<IAssetService>();

        // Pages
        private AssetCreatePage _assetCreatePage;

        // Search Keyword
        private string _keyword;
        public string Keyword
        {
            get
            {
                return _keyword;
            }
            set
            {
                SetValue(ref _keyword, value);
                OnPropertyChanged(nameof(FilteredAssetViewModels));
            }
        }

        private bool _isPullDownRefreshing;
        public bool IsPullDownRefreshing
        {
            get
            {
                return _isPullDownRefreshing;
            }
            set
            {
                SetValue(ref _isPullDownRefreshing, value);
            }
        }

        private ObservableCollection<AssetViewModel> _filteredAssetViewModels = new ObservableCollection<AssetViewModel>();
        public ObservableCollection<AssetViewModel> FilteredAssetViewModels
        {
            get {
                if (string.IsNullOrEmpty(Keyword))
                {
                    return AssetViewModels;
                }

                var list = AssetViewModels.Where(assetViewModel => assetViewModel.Name.Contains(Keyword)).ToList();
                return new ObservableCollection<AssetViewModel>(list);
            }
        }


        private ObservableCollection<AssetViewModel> _assetViewModels = new ObservableCollection<AssetViewModel>();
        public ObservableCollection<AssetViewModel> AssetViewModels
        {
            get { return _assetViewModels; }
            set
            {
                _assetViewModels = value;
                OnPropertyChanged(nameof(FilteredAssetViewModels));
            }
        }

        public HomePageViewModel()
        {
            AddAssetCommand = new Command(AddAsset);
            ShowAssetChartCommand = new Command(ShowAssetChart);
            CreateNowCommand = new Command(CreateNow);
            AssetTappedCommand = new Command(AssetTapped);
            LoadAssetsCommand = new Command(LoadAssets);
            PullDownRefreshCommand = new Command(LoadAssets);
        }

        public ICommand AddAssetCommand { get; private set; }
        public ICommand ShowAssetChartCommand { get; private set; }
        public ICommand CreateNowCommand { get; private set; }
        public ICommand AssetTappedCommand { get; private set; }
        public ICommand LoadAssetsCommand { get; private set; }
        public ICommand PullDownRefreshCommand { get; private set; }
        
        private async void AddAsset()
        {
            //    _assetCreatePage = new AssetCreatePage();
            //    _assetCreatePage.VM.CreateAssetHandler += VM_CreateAssetHandler;
            await pageService.PushAsync(Scene.AssetCreate, new AssetCreatePageViewModel());
        }

        private void VM_CreateAssetHandler(object sender, EventArgs e)
        {
            LoadAssets();
        }

        private async void ShowAssetChart()
        {
            await Router.Navigate("chart", new ChartPageViewModel());
        }

        private async void CreateNow()
        {
            //TODO:show list and hide empty view placeholder
        }

        private async void AssetTapped()
        {
            await pageService.PushAsync(Scene.Items, new ItemsPageViewModel());
        }

        private void LoadAssets()
        { 
            IsPullDownRefreshing = true;

            var assets = assetService.GetAllAssets();
            var assetViewModels = new ObservableCollection<AssetViewModel>();
            foreach (Asset asset in assets)
            {
                var assetViewModel = new AssetViewModel(asset);
                assetViewModels.Add(assetViewModel);
            }

            AssetViewModels = assetViewModels;

            IsPullDownRefreshing = false;


        }

        public override void ViewDidLoad()
        {
            // Load Assets Only Once
            LoadAssetsCommand.Execute(null);
        }

        ~HomePageViewModel()
        {
            if(_assetCreatePage != null)
            {
                _assetCreatePage.VM.CreateAssetHandler -= VM_CreateAssetHandler;
            }
        }
    }
}
