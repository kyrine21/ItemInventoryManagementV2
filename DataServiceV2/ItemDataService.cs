using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ItemModels;

namespace DataServiceV2
{
    public class ItemDataService
    {
         List<Items> ItemList = new List<Items>();

        public ItemDataService(){
        
            Items shampoo = new Items { itemName = "SHAMPOO", itemCount = 20 };
            Items soap = new Items { itemName = "SOAP", itemCount = 5 };
            Items toothpaste = new Items { itemName = "TOOTHPASTE", itemCount = 26 };
            Items deodorant = new Items { itemName = "DEODORANT", itemCount = 12 };
            Items lotion = new Items { itemName = "LOTION", itemCount = 2 };

            ItemList.Add(shampoo);
            ItemList.Add(soap);
            ItemList.Add(toothpaste);
            ItemList.Add(deodorant);
            ItemList.Add(lotion);

        }

        public List<Items> getAllItems() => ItemList;

        public void AddItem(Items item) => ItemList.Add(item);

        public void UpdateItem(int index, int newCount) => ItemList[index].itemCount = newCount;

        public void DeleteItem(int index) => ItemList.RemoveAt(index);
    }

    }

