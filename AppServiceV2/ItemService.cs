using System;
using System.Collections.Generic;
using System.Text;
using ItemModels;
using DataServiceV2;
using System.Security.Cryptography.X509Certificates;

namespace AppServiceV2
{
    public class ItemService
    {
        private InventoryManagementService dataService = new InventoryManagementService(new JsonItemDataService());

        public List<Items> getAllItems()
        {
            return dataService.getAllItems();
        }

        public bool itemExist(string itemName)
        {
            return dataService.getAllItems().Any(x => x.itemName == itemName.ToUpper());
        }

        public bool addItem(Items newItem)
        {

            if (itemExist(newItem.itemName)) {
                return false;
            }

            dataService.AddItem(newItem);
            return true;
        }

        public bool updateItem(string itemName, int newCount)
        {
            var items = dataService.getAllItems();
            var item = items.Find(x => x.itemName == itemName.ToUpper());
            int index = items.IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            dataService.UpdateItem(index, newCount);
            return true;
        }

        public bool deleteItem(string itemName)
        {
            var items = dataService.getAllItems();
            var item = items.Find(x => x.itemName == itemName.ToUpper());
            int index = items.IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            dataService.DeleteItem(index);
            return true;
        }




    }
}
