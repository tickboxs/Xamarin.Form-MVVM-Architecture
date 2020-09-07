using System;
using nibble.Domains;
using System.Collections.Generic;

namespace nibble.Interfaces
{
    public interface IItemService
    {
        IList<Item> GetAllItems();
        void CreateItem(Item item);
        void SaveItem(Item item);
    }
}
