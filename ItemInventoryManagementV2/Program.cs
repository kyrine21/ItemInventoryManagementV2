namespace ItemInventoryManagementV2
{
    using AppServiceV2;
    using ItemModels;
    using System;

    internal class Program
    {

        static ItemService itemService = new ItemService();

        static bool showMenuOption()
        {
            Console.WriteLine("\n_______________________________________\n");
            Console.Write("Do you want to continue (Y/N): ");
            string choice = Console.ReadLine().ToUpper();
            Console.WriteLine("\n_______________________________________\n");



            switch (choice)
            {
                case "Y":
                    return true;

                case "N":
                    return false;

                default:
                    Console.WriteLine("Invalid input. System will exit.");
                    Environment.Exit(0);
                    return false;
            }
        }


        static void Main(string[] args)
        {

            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\nItem Inventory Management");
                Console.Write("Enter Function:\n[1] Item List\n[2] Search\n[3] Add \n[4] Update \n[5] Delete\n[6] Exit Program\n");
                Console.Write("Function: ");
                int functionInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
                switch (functionInput)
                {
                    case 1:
                        listOfItems();
                        break;

                    case 2:
                        searchItem();
                        break;

                    case 3:
                        addItem();
                        break;

                    case 4:
                        updateItem();
                        break;

                    case 5:
                        deleteItem();
                        break;

                    

                    case 6:
                        Console.WriteLine("\n\n_______________________________________\n");
                        Console.WriteLine("Program Closed");
                        Console.WriteLine("_______________________________________\n\n");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                continueProgram = showMenuOption();
            }
        }

        static void listOfItems()
        {

            Console.WriteLine("\n------------------------------------\nItems in Stock: \n------------------------------------\n");

            var items = itemService.getAllItems();

            if (items.Count == 0)
            {
                Console.WriteLine("No items in stock");
            }

            foreach (var item in items)
            {

                Console.WriteLine("Item: " + item.itemName);
                Console.WriteLine("Quantity: " + item.itemCount);

                if (item.itemCount < 5)
                {
                    Console.Write("[!] Warning: Low on stocks\n");
                }

                Console.WriteLine(" ");
            }
            Console.Write("\n\n");

        }

        static void searchItem()
        {
            Console.WriteLine("_______________________________________\n\n");
            Console.WriteLine("Search Item");
            Console.Write("Enter item name to search: ");
            string itemToSearch = Console.ReadLine().ToUpper();
            
        }

        static void addItem()
        {

            Console.WriteLine("_______________________________________");
            Console.WriteLine("\n\nAdd Item");
            Console.Write("Enter item name: ");
            string toAddItemName = Console.ReadLine().ToUpper();

            bool isItDuplicate = itemService.itemExist(toAddItemName);
            if (isItDuplicate)
            {
                Console.WriteLine("\n-------------------------");
                Console.WriteLine("[!] " + toAddItemName + " already exists");
                Console.WriteLine("-------------------------\n\n");
            }

            else
            {
                Console.Write("Enter item quantity: ");
                int toAddItemCount = Convert.ToInt32(Console.ReadLine());

                if (toAddItemCount < 0)
                {
                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("[!] Quantity can't be less than 0.");
                    Console.WriteLine("-------------------------\n\n");
                    return;
                }

                Items newItem = new Items { itemName = toAddItemName, itemCount = toAddItemCount };

                bool added = itemService.addItem(newItem);
                if (added)
                {
                    {
                        Console.WriteLine("\n-------------------------");
                        Console.WriteLine("[!] Item added successfully");
                        Console.WriteLine("-------------------------\n\n");
                    }
                }

            }

        }

        static void updateItem()
        {

            Console.WriteLine("------------------------------------\n");

            Console.WriteLine("Update Item");
            Console.Write("Enter item name to update: ");
            string itemToUpdate = Console.ReadLine().ToUpper();

            bool doesItemExist = itemService.itemExist(itemToUpdate);

            if (!doesItemExist)
            {
                Console.WriteLine("\n[!] Item not found");
            }

            else
            {
                Console.Write("Enter new quantity: ");
                int itemStockToUpdate = Convert.ToInt32(Console.ReadLine());

                if (itemStockToUpdate < 0)
                {


                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("[!] Item quantity can't be less than 0.");
                    Console.WriteLine("-------------------------");
                }

                else
                {
                    bool updated = itemService.updateItem(itemToUpdate, itemStockToUpdate);
                    if (updated)
                    {
                        Console.WriteLine("\n-------------------------");
                        Console.WriteLine("[!] Item updated successfully");
                        Console.WriteLine("-------------------------\n\n");
                    }

                    else
                    {
                        Console.WriteLine("\n-------------------------");
                        Console.WriteLine("[!] Failed to update item");
                        Console.WriteLine("-------------------------\n\n");
                    }

                }


            }

        }

            static void deleteItem()
            {
                Console.WriteLine("_______________________________________\n\n");
                Console.WriteLine("Delete Item");
                Console.Write("Enter item name to delete: ");
                string itemToDelete = Console.ReadLine().ToUpper();

            if (itemService.itemExist(itemToDelete))
            {

                Console.Write("Press Y to confirm delete / Press N to cancel: ");
                string deleteConfirm = Console.ReadLine().ToUpper();

                if (deleteConfirm == "Y")
                {

                    itemService.deleteItem(itemToDelete);

                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("[!] Item deleted successfully");
                    Console.WriteLine("-------------------------");

                }

                else
                {
                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("\n[!] Delete cancelled");
                    Console.WriteLine("\n-------------------------");

                }
            }

            else
            {
                Console.WriteLine("\n-------------------------");
                Console.WriteLine("Item not found");
                Console.WriteLine("-------------------------");
            }
        }


    }

}
