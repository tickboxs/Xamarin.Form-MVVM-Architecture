using System;
using nibble.Domains;
using nibble.Constants;
using System.Collections.Generic;
using nibble.Interfaces;
using System.Linq;

namespace nibble.Services
{
    public class ItemService:IItemService
    {
        public ItemService()
        {
        }

        private IList<Item> _items = new List<Item>
            {
                new Item(0,ItemType.Charity,"Donate Guard Dog",31428.00,1583134481093),
                new Item(1,ItemType.Food,"Coffee Latte",3456.00,1583134481093),
                new Item(2,ItemType.Medicine,"Peroidc Health",129.00,1583134481093),
                new Item(3,ItemType.Salary,"Salary Month",370.00,1583134481093),
                new Item(4,ItemType.Cinema,"Watch Cinema",400.00,1583134481093)
            };

        public IList<Item> GetAllItems()
        {
            return _items;
        }

        public void CreateItem(Item item)
        {
            var maxId = _items.Max((innerItem) => innerItem.Id);
            item.Id = (maxId + 1);
            _items.Add(item);
        }

        public void SaveItem(Item item)
        {
            
            var selectedItem = _items.First((innerItem) => innerItem.Id == item.Id);
            _items.Remove(selectedItem);
            _items.Add(item);
        }
    }
}
