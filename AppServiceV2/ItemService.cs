using System;
using System.Collections.Generic;
using System.Linq;
using ItemModels;
using DataServiceV2;

namespace AppServiceV2
{
    public class ItemService
    {
        private InventoryManagementService dataService =
            new InventoryManagementService(new ItemDataServiceDB());

        public List<Items> getAllItems()
        {
            return dataService.getAllItems();
        }

        public bool itemExist(int itemID)
        {
            return dataService.getAllItems().Any(x => x.itemID == itemID);
        }

        public bool addItem(Items newItem)
        {
            if (itemExist(newItem.itemID))
                return false;

            dataService.AddItem(newItem);
            return true;
        }

        public bool updateItem(int itemID, int newCount)
        {
            var item = dataService.getAllItems().FirstOrDefault(x => x.itemID == itemID);

            if (item == null)
                return false;

            dataService.UpdateItem(itemID, newCount);
            return true;
        }

        public bool deleteItem(int itemID)
        {
            var item = dataService.getAllItems().FirstOrDefault(x => x.itemID == itemID);

            if (item == null)
                return false;

            dataService.DeleteItem(itemID);
            return true;
        }
    }
}