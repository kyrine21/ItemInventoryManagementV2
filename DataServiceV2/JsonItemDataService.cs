using ItemModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace DataServiceV2
{
    public class JsonItemDataService : InventoryManagementStructure
    {
        List<Items> ItemList = new List<Items>();

        private string _jsonFileName;

        public JsonItemDataService()
        {

            Items shampoo = new Items { itemName = "SHAMPOO", itemCount = 20 };
            Items soap = new Items { itemName = "SOAP", itemCount = 5 };
            Items toothpaste = new Items { itemName = "TOOTHPASTE", itemCount = 26 };
            Items deodorant = new Items { itemName = "DEODORANT", itemCount = 12 };
            Items lotion = new Items { itemName = "LOTION", itemCount = 2 };

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
            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                ItemList = JsonSerializer.Deserialize<List<Items>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public List<Items> getAllItems() {
            this.RetrieveDataFromJsonFile();
            return ItemList;
        }

        public void AddItem(Items item)
        {
            ItemList.Add(item);
            this.SaveDataToJsonFile();
        }



        public void UpdateItem(int index, int newCount) {
            ItemList[index].itemCount = newCount;
            this.SaveDataToJsonFile();

        }

        public void DeleteItem(int index)
        {
            ItemList.RemoveAt(index);
            this.SaveDataToJsonFile();
        }


    }
}
