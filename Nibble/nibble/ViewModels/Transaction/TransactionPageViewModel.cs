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
using nibble.ViewModels.Transaction;
using nibble.Constants;
using nibble.Pages.Transaction;
using Autofac;
using nibble.Utilities;
using System.Diagnostics;
using System.Globalization;
using nibble.Controls;

namespace nibble.ViewModels.Transaction
{
    public class TransactionPageViewModel : BaseViewModel
    {

        public IPageService pageService = DIContainer.Current.Resolve<IPageService>();
        public IItemService itemService = DIContainer.Current.Resolve<IItemService>();

        public ICommand TapAmountCommand { get; private set; }
        public ICommand TypeChooseCommand { get; private set; }
        public ICommand WriteNoteCommand { get; private set; }
        public ICommand TapCalendarCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand TapSegmentCommand { get; private set; }

        public event EventHandler<EventArgs> CreateItemHandler;

        private long Id { set; get; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetValue(ref _name, value);
                OnPropertyChanged(nameof(NameText));
                OnPropertyChanged(nameof(NameTextColor));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
            }
        }

        public string NameText
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return AppResources.Note;
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

        private ItemType? _type;
        public ItemType? Type
        {
            get
            {
                return _type;
            }
            set
            {
                SetValue(ref _type, value);
                OnPropertyChanged(nameof(TypeName));
                OnPropertyChanged(nameof(TypeTextColor));
                OnPropertyChanged(nameof(TypeImage));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
            }
        }

        public string TypeName
        {
            get
            {
                return ItemTypeToString(Type);
            }
        }

        public string TypeImage
        {
            get
            {
                return ItemTypeToItemImage(Type);
            }
        }
       
        public string TypeTextColor
        {
            get
            {
                return Type == null ? Theme.Silver : Theme.Dark;
            }
        }

        private double _amount;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                SetValue(ref _amount, value);
                OnPropertyChanged(nameof(AmountTextColor));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
            }
        }

        public string AmountTextColor
        {
            get
            {
                return Amount == 0 ? Theme.Silver : Theme.Dark;
            }
        }

        private long _timestamp;
        public long Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                SetValue(ref _timestamp, value);
                OnPropertyChanged(nameof(TimestampTextColor));
                OnPropertyChanged(nameof(TimestampText));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
                OnPropertyChanged(nameof(SaveButtonBackgroundColor));
            }
        }

        public string TimestampText
        {
            get
            { if (Timestamp == 0)
                {
                    return AppResources.Date;
                }
                return DateTimeUtil.UnixTimestampToDateTimeString(Timestamp.ToString());
            }

            set
            { 
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "MM/dd/yyyy hh:mm:ss";
                DateTime dt = Convert.ToDateTime(value, dtFormat);

                Timestamp = DateTimeUtil.DateTimeStringToUnixTimestamp(dt);
            }
        }

        public string TimestampTextColor
        {
            get
            {
                return Timestamp == 0 ? Theme.Silver : Theme.Dark;
            }
        }

        public bool IsSaveButtonEnabled
        {
            get
            {
                return !string.IsNullOrEmpty(Name) && Type != null && Amount != 0 && Timestamp != 0;
            }
        }

        public string SaveButtonBackgroundColor
        {
            get
            {
                return IsSaveButtonEnabled ? Theme.Purple : Theme.Silver;
            }
        }

        private bool IsCreateMode { set; get; }
        public string SaveButtonText
        {
            get
            {
                return IsCreateMode ? AppResources.CreateNow : AppResources.Save;
            }
        }

        public SlidingConfig[] Configs { set; get; } = new SlidingConfig[]
        {
            new SlidingConfig
            {
                Title = "Expense",
                TextColor = Color.White,
                SliderColor = Color.FromHex("#6979F8")
            },
            new SlidingConfig
            {
                Title = "Income",
                TextColor = Color.White,
                SliderColor = Color.FromHex("#FF647C")
            }

        };

        // Pages
        private TransactionNamePage _transactionNamePage;
        private TransactionAmountPage _transactionAmountPage;

        public TransactionPageViewModel(Item item = null)
        {
            if (item != null)
            {
                Id = item.Id;
                Type = item.Type;
                Name = item.Name;
                Amount = item.Amount;
                Timestamp = item.Timestamp;
                IsCreateMode = false;
            }
            else
            {   
                IsCreateMode = true;
            }
            
            TypeChooseCommand = new Command(TypeChoose);
            WriteNoteCommand = new Command(WriteNote);
            TapCalendarCommand = new Command<DateTime>((DateTime date) => TapCalendar(date));
            TapAmountCommand = new Command(TapAmount);
            SaveCommand = new Command(Save);
            TapSegmentCommand = new Command<int>((int index) => TapSegment(index));

        }

        private void TypeChoose()
        {
            string result = Router.Action(
                "actionsheet",
                    new object[] {
                        AppResources.ChooseType,
                        AppResources.Cancel,
                        AppResources.Destruction,
                        new string[] {
                            AppResources.Charity,
                            AppResources.FoodDrink,
                            AppResources.Medicine,
                            AppResources.Salary,
                            AppResources.Cinema } }) as string;
            if (!string.IsNullOrEmpty(AppResources.Cancel) && !string.IsNullOrEmpty(AppResources.Destruction))
            {
                Type = NameToItemType(result);
            }
        }

        private void WriteNote()
        {
            //_transactionNamePage = new TransactionNamePage();
            //_transactionNamePage.VM.NameConfirmedHandler += TransactionNamePage_NameConfirmedHandler;
            pageService.PushAsync(Scene.TransactionName, new TransactionNamePageViewModel());
        }

        private void TransactionNamePage_NameConfirmedHandler(object sender, Events.TransactionNameEventArgs e)
        {
            Name = e.Name;
        }

        private void TapCalendar(DateTime date)
        {
            Timestamp = DateTimeUtil.DateTimeStringToUnixTimestamp(date);
        }

        private void TapAmount()
        {
            //_transactionAmountPage = new TransactionAmountPage(Amount);
            //_transactionAmountPage.AmountConfirmedHandler += TransactionAmountPage_AmountConfirmedHandler;
            pageService.PushAsync(Scene.TransactionAmount,new TransactionAmountPageViewModel(Amount));
        }

        private async void Save()
        {
            if (IsCreateMode)
            {
                itemService.CreateItem(new Item(0, (ItemType)Type, Name, Amount, Timestamp));

            }
            else
            {
                itemService.SaveItem(new Item(Id, (ItemType)Type, Name, Amount, Timestamp));
            }

            Debug.Assert(CreateItemHandler != null, "CreateItemHandler is null,do not to forget to initialize it");
            if (CreateItemHandler != null)
            {
                CreateItemHandler.Invoke(null, null);
            }
            await pageService.PopAsync();

        }

        private void TapSegment(int index)
        {
            Console.WriteLine(index);
        }

        private void TransactionAmountPage_AmountConfirmedHandler(object sender, Events.ItemAmountEventArgs e)
        {
            Amount = e.Amount;
        }

        private ItemType NameToItemType(string name)
        {
            if (name.Equals(AppResources.Charity))
            {
                return ItemType.Charity;
            }
            else if (name.Equals(AppResources.FoodDrink))
            {
                return ItemType.Food;
            }
            else if (name.Equals(AppResources.Medicine))
            {
                return ItemType.Medicine;
            }
            else if (name.Equals(AppResources.Salary))
            {
                return ItemType.Salary;
            }
            else
            {
                return ItemType.Cinema;
            }
        }

        private string ItemTypeToString(ItemType? itemType)
        {
            if (itemType == null)
            {
                return AppResources.Type;
            }

            if (itemType == ItemType.Charity)
            {
                return AppResources.Charity;
            }
            else if (itemType == ItemType.Food)
            {
                return AppResources.FoodDrink;
            }
            else if (itemType == ItemType.Medicine)
            {
                return AppResources.Medicine;
            }
            else if (itemType == ItemType.Salary)
            {
                return AppResources.Salary;
            }
            else
            {
                return AppResources.Cinema;
            }
        }

        private string ItemTypeToItemImage(ItemType? itemType)
        {
            if (itemType == null)
            {
                return "asset_type";
            }

            if (itemType == ItemType.Charity)
            {
                return "charity";
            }
            else if (itemType == ItemType.Food)
            {
                return "food";
            }
            else if (itemType == ItemType.Medicine)
            {
                return "medicine";
            }
            else if (itemType == ItemType.Salary)
            {
                return "salary";
            }
            else
            {
                return "cinema";
            }
        }

        ~TransactionPageViewModel()
        {
            if (_transactionNamePage != null)
            {
                _transactionNamePage.VM.NameConfirmedHandler += TransactionNamePage_NameConfirmedHandler;
            }

            if (_transactionAmountPage != null)
            {
                _transactionAmountPage.AmountConfirmedHandler += TransactionAmountPage_AmountConfirmedHandler;
            }
        }

    }
}
