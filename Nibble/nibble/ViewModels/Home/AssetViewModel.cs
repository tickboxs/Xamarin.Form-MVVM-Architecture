using System;
using nibble.Domains;
using nibble.Constants;

namespace nibble.ViewModels.Home
{
    public class AssetViewModel
    {
        public AssetType Type { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string TypeImage
        {
            get
            {
                switch (Type)
                {
                    case AssetType.Bitcoin:
                        return "bitcoin";
                    case AssetType.Card:
                        return "card";
                    case AssetType.Cash:
                        return "cash";
                    case AssetType.Property:
                        return "property";
                    default:
                        return "bitcoin";
                }

            }
        }

        public string BalanceWithCurrencySign
        {
            get
            {
                return "$" + Balance;
            }
        }


        public AssetViewModel(Asset asset)
        {
            Type = asset.Type;
            Name = asset.Name;
            Balance = asset.Balance;
        }
    }
}
