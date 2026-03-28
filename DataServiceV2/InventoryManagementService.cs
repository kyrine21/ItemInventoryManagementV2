using ItemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceV2
{
    public class InventoryManagementService
    {
        InventoryManagementStructure _inventoryManagementStructure;

        public InventoryManagementService(InventoryManagementStructure inventoryManagementStructure)
        {
            _inventoryManagementStructure = inventoryManagementStructure;
        }

        public List<Items> getAllItems() { 
            return _inventoryManagementStructure.getAllItems();
        }

        public void AddItem(Items item) {
            _inventoryManagementStructure.AddItem(item);
        }

        public void UpdateItem(int index, int newCount) { 
            _inventoryManagementStructure.UpdateItem(index, newCount);
        }

        public void DeleteItem(int index) { 
            _inventoryManagementStructure.DeleteItem(index);

        }

    }
}
