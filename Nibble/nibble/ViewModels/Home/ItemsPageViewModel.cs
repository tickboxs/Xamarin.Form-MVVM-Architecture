using System;
using nibble.Interfaces;
using nibble.Services;
using System.Collections.Generic;
using nibble.ViewModels;
using nibble.Domains;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using nibble.Pages.Transaction;
using nibble.Pages.Chart;
using nibble.Pages.Home;
using Autofac;
using System.Linq;
using nibble.ViewModels.Transaction;
using nibble.ViewModels.Chart;

namespace nibble.ViewModels.Home
{
    public class ItemsPageViewModel:BaseViewModel
    {
        public IPageService pageService = DIContainer.Current.Resolve<IPageService>();
        public IItemService itemService = DIContainer.Current.Resolve<IItemService>();

        public ICommand LoadItemsCommand { get; private set; }
        public ICommand ItemTappedCommand { get; private set; }

        public ICommand AddItemCommand { get; private set; }
        public ICommand ShowAssetChartCommand { get; private set; }
        public ICommand PullDownRefreshCommand { get; private set; }

        // Pages
        private TransactionPage _transactionPage;

        private string _keyword;
        public string Keyword {
            set
            {
                SetValue(ref _keyword, value);
                OnPropertyChanged(nameof(FilteredItemViewModels));
            }
            get
            {
                return _keyword;
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

        private ObservableCollection<ItemViewModel> _filteredItemViewModels = new ObservableCollection<ItemViewModel>();
        public ObservableCollection<ItemViewModel> FilteredItemViewModels
        {
            get
            {
                if (string.IsNullOrEmpty(Keyword))
                {
                    return ItemViewModels;
                }

                var list = ItemViewModels.Where(itemViewModel => itemViewModel.Name.Contains(Keyword)).ToList();
                return new ObservableCollection<ItemViewModel>(list);
            }
        }

        private ObservableCollection<ItemViewModel> _itemViewModels = new ObservableCollection<ItemViewModel>();
        public ObservableCollection<ItemViewModel> ItemViewModels
        {
            get { return _itemViewModels; }
            set
            {
                _itemViewModels = value;
                OnPropertyChanged(nameof(FilteredItemViewModels));
            }
        }

        public ItemsPageViewModel()
        {
            LoadItemsCommand = new Command(LoadItems);
            ItemTappedCommand = new Command<Item>((Item item) => ItemTapped(item));

            AddItemCommand = new Command(AddItem);
            ShowAssetChartCommand = new Command(ShowAssetChart);
            PullDownRefreshCommand = new Command(LoadItems);
        }

        private void LoadItems()
        {
            IsPullDownRefreshing = true;

            var items = itemService.GetAllItems();
            var itemViewModels = new ObservableCollection<ItemViewModel>();
            foreach (Item item in items)
            {
                int index = items.IndexOf(item); //index 为索引值

                var itemViewModel = new ItemViewModel(item);

                // Set Amount Color
                itemViewModel.AmountColor = GetColorByIndex(index);
                itemViewModels.Add(itemViewModel);
            }

            ItemViewModels = itemViewModels;

            IsPullDownRefreshing = false;

        }

        private async void AddItem()
        {
            //_transactionPage = new TransactionPage();
            //_transactionPage.VM.CreateItemHandler += VM_CreateItemHandler;
            await Router.Navigate("transaction", new TransactionPageViewModel());
        }

        private void VM_CreateItemHandler(object sender, EventArgs e)
        {
            LoadItems();
        }

        private async void ShowAssetChart()
        {
            await Router.Navigate("chart",new ChartPageViewModel());
        }

        private void ItemTapped(Item item) {
            //_transactionPage = new TransactionPage(item);
            //_transactionPage.VM.CreateItemHandler += VM_CreateItemHandler;
            Router.Navigate("transaction", new TransactionPageViewModel(item));
        }

        private string GetColorByIndex(int index)
        {
            if (index % 2 == 0)
            {
                return "Pink";
            }
            else
            {
                return "Blue";
            }
        }

        public override void ViewDidLoad()
        {
            LoadItemsCommand.Execute(null);
        }

        ~ItemsPageViewModel()
        {
            if (_transactionPage != null)
            {
                _transactionPage.VM.CreateItemHandler -= VM_CreateItemHandler;
            }
        }
    }
}
