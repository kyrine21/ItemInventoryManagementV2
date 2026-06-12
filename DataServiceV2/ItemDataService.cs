using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ItemModels;

namespace DataServiceV2
{
    public class ItemDataService : InventoryManagementStructure
    {
        List<Items> ItemList = new List<Items>();

        public ItemDataService(){

            Items shampoo = new Items { itemID = 1, itemName = "SHAMPOO", itemCount = 20 };
            Items soap = new Items { itemID = 2, itemName = "SOAP", itemCount = 5 };
            Items toothpaste = new Items { itemID = 3, itemName = "TOOTHPASTE", itemCount = 26 };
            Items deodorant = new Items { itemID = 4, itemName = "DEODORANT", itemCount = 12 };
            Items lotion = new Items { itemID = 5, itemName = "LOTION", itemCount = 2 };

            ItemList.Add(shampoo);
            ItemList.Add(soap);
            ItemList.Add(toothpaste);
            ItemList.Add(deodorant);
            ItemList.Add(lotion);

        }

        public List<Items> getAllItems() => ItemList;

        public void AddItem(Items item) => ItemList.Add(item);

        public void UpdateItem(int itemID, int newCount)
        {
            var item = ItemList.FirstOrDefault(x => x.itemID == itemID);

            if (item != null)
            {
                item.itemCount = newCount;
            }
        }

        public void DeleteItem(int itemID)
        {
            var item = ItemList.FirstOrDefault(x => x.itemID == itemID);

            if (item != null)
            {
                ItemList.Remove(item);
            }
        }
    }

    }

