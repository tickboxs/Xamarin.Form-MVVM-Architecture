using System;
using nibble.Domains;
using nibble.Constants;
using nibble.Utilities;

namespace nibble.ViewModels.Home
{
    public class ItemViewModel
    {
        public ItemViewModel(Item item)
        {
            Id = item.Id;
            Type = item.Type;
            Name = item.Name;
            Timestamp = item.Timestamp;
            Amount = item.Amount;

        }

        public long Id { set; get; }
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public long Timestamp{ get; set; }

        public string AmountColor { get; set; }
        public string TypeImage
        {
            get
            {
                switch (Type)
                {
                    case ItemType.Charity:
                        return "charity";
                    case ItemType.Cinema:
                        return "cinema";
                    case ItemType.Food:
                        return "food";
                    case ItemType.Medicine:
                        return "medicine";
                    case ItemType.Salary:
                        return "salary";
                    default:
                        return "charity";
                }

            }
        }

        public string AmountWithCurrencySign
        {
            get
            {
                return "$" + Amount;
            }
        }

        public string Date
        {
            get
            {
                return DateTimeUtil.UnixTimestampToDateTimeString(Timestamp.ToString());
        
            }
        }

        public Item ToItem()
        {
            return new Item(Id, Type, Name, Amount, Timestamp);
        }

    }
}
