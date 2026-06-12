using ItemModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Linq;

namespace DataServiceV2
{
    public class JsonItemDataService : InventoryManagementStructure
    {
        List<Items> ItemList = new List<Items>();

        private string _jsonFileName;

        public JsonItemDataService()
        {

            Items shampoo = new Items {itemID = 1, itemName = "SHAMPOO", itemCount = 20 };
            Items soap = new Items { itemID = 2, itemName = "SOAP", itemCount = 5 };
            Items toothpaste = new Items { itemID = 3, itemName = "TOOTHPASTE", itemCount = 26 };
            Items deodorant = new Items { itemID = 4, itemName = "DEODORANT", itemCount = 12 };
            Items lotion = new Items { itemID = 5, itemName = "LOTION", itemCount = 2 };

            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/ItemsInventory.json";
            this.AddItem(shampoo);
            this.AddItem(soap);
            this.AddItem(toothpaste);
            this.AddItem(deodorant);
            this.AddItem(lotion);

        }

        public void SaveDataToJsonFile()
        {
            using (var outputStream = File.Create(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Items>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , ItemList);
            }
        }

        public void RetrieveDataFromJsonFile()
        {
            if (!File.Exists(_jsonFileName))
            {
                ItemList = new List<Items>();
                return;
            }

            var json = File.ReadAllText(_jsonFileName);

            if (string.IsNullOrWhiteSpace(json))
            {
                ItemList = new List<Items>();
                return;
            }

            ItemList = JsonSerializer.Deserialize<List<Items>>(json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

                    if (ItemList == null)
                    {
                        ItemList = new List<Items>();
                    }
        }

        public List<Items> getAllItems() {
            this.RetrieveDataFromJsonFile();
            return ItemList;
        }

        public void AddItem(Items item)
        {
            RetrieveDataFromJsonFile();

            ItemList.Add(item);

            SaveDataToJsonFile();
        }



        public void UpdateItem(int itemID, int newCount)
        {
            var item = ItemList.FirstOrDefault(x => x.itemID == itemID);

            if (item != null)
            {
                item.itemCount = newCount;
                SaveDataToJsonFile();
            }
        }

        public void DeleteItem(int itemID)
        {
            var item = ItemList.FirstOrDefault(x => x.itemID == itemID);

            if (item != null)
            {
                ItemList.Remove(item);
                SaveDataToJsonFile();
            }
        }


    }
}
