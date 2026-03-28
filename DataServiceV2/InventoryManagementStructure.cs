using ItemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceV2
{
    public interface InventoryManagementStructure
    {
        public List<Items> getAllItems();

        public void AddItem(Items item);

        public void UpdateItem(int index, int newCount);

        public void DeleteItem(int index);
    }
}
