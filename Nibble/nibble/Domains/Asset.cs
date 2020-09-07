using System;
using nibble.Constants;

namespace nibble.Domains
{
    public class Asset
    {
        public Asset(long id, AssetType type, string name, double balance)
        {
            Id = id;
            Type = type;
            Name = name;
            Balance = balance;
        }

        public long Id { get; set; }

        public AssetType Type { get; private set; }

        public string Name { get; private set; }

        public double Balance { get; private set; }
    }
}
