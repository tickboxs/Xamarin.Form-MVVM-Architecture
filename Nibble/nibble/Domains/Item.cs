using System;
using nibble.Constants;

namespace nibble.Domains
{
    public class Item
    {

        public Item(long id, ItemType type, string name, double amount, long timestamp)
        {
            Id = id;
            Type = type;
            Name = name;
            Amount = amount;
            Timestamp = timestamp;
        }

        public long Id { set; get; }

        public ItemType Type { get; private set; }

        public string Name { get; private  set; }

        public double Amount { get; private set; }

        public long Timestamp { get; private set; }
    }
}
