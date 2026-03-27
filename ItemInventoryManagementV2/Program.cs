namespace ItemInventoryManagementV2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    internal class Program
    {

            static List<string> itemNames = new List<string>();
            static List<int> itemStocks = new List<int>();

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
                PopulateItemsStock();

                bool continueProgram = true;

                while (continueProgram)
                {
                    Console.WriteLine("\nItem Inventory Management");
                    Console.Write("Enter Function:\n[1] Item List\n[2] Add\n[3] Delete \n[4] Update \n[5] Exit\n");
                    Console.Write("Function: ");
                    int functionInput = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                    switch (functionInput)
                    {
                        case 1:
                            listOfItems();
                            break;

                        case 2:
                            addItem();
                            break;

                        case 3:
                            deleteItem();
                            break;

                        case 4:
                            updateItem();
                            break;

                        case 5:
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

            static void PopulateItemsStock()
            {

                itemNames.Add("SHAMPOO");
                itemNames.Add("SOAP");
                itemNames.Add("TOOTHPASTE");
                itemNames.Add("DEODORANT");
                itemNames.Add("LOTION");

                itemStocks.Add(20);
                itemStocks.Add(5);
                itemStocks.Add(26);
                itemStocks.Add(12);
                itemStocks.Add(2);


            }

            static void listOfItems()
            {

                Console.WriteLine("\n------------------------------------\nItems in Stock: \n------------------------------------\n");

                for (int i = 0; i < itemNames.Count; i++)
                {
                    Console.WriteLine("Item " + (i + 1) + ": " + itemNames[i]);
                    Console.WriteLine("Quantity: " + itemStocks[i]);

                    if (itemStocks[i] < 5)
                    {
                        Console.Write("[!] Warning: Low on stocks\n");
                    }


                    Console.Write("\n\n");

                }
            }
            static void addItem()
            {


                Console.WriteLine("_______________________________________");
                Console.WriteLine("\n\nAdd Item");
                Console.Write("Enter item name: ");
                string toAddItemName = Console.ReadLine().ToUpper();
                int indexToAddName = itemNames.IndexOf(toAddItemName);

                if (indexToAddName >= 0)
                {
                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("[!] Item already exists");
                    Console.WriteLine("-------------------------\n\n");

                }

                else
                {
                    Console.Write("Enter item quantity: ");
                    int toAddItemStock = Convert.ToInt32(Console.ReadLine());

                    if (toAddItemStock >= 0)
                    {

                        itemNames.Add(toAddItemName);
                        itemStocks.Add(toAddItemStock);

                        Console.WriteLine("\n-------------------------");
                        Console.WriteLine("[!] Item added successfully");
                        Console.WriteLine("-------------------------");

                    }

                    else
                    {
                        Console.WriteLine("\n-------------------------");
                        Console.WriteLine("[!] Quantity can't be less than 0.");
                        Console.WriteLine("-------------------------");

                    }
                }

            }

            static void deleteItem()
            {
                Console.WriteLine("_______________________________________\n\n");
                Console.WriteLine("Delete Item");
                Console.Write("Enter item name to delete: ");
                string itemToDelete = Console.ReadLine().ToUpper();

                int indexToDelete = itemNames.IndexOf(itemToDelete);

                if (indexToDelete >= 0)
                {

                    Console.Write("Press Y to confirm delete / Press N to cancel: ");
                    string deleteConfirm = Console.ReadLine().ToUpper();

                    if (deleteConfirm == "Y")
                    {

                        itemNames.RemoveAt(indexToDelete);
                        itemStocks.RemoveAt(indexToDelete);

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



            static void updateItem()
            {
                Console.WriteLine("\n------------------------------------");

                Console.WriteLine("Items in Stock: \n------------------------------------\n");

                for (int i = 0; i < itemNames.Count; i++)
                {
                    Console.WriteLine("Item " + (i + 1) + ": " + itemNames[i]);
                    Console.WriteLine("Quantity: " + itemStocks[i]);
                    Console.WriteLine(" ");
                }

                Console.WriteLine("------------------------------------\n");

                Console.WriteLine("Update Item");
                Console.Write("Enter item name to update: ");
                string itemToUpdate = Console.ReadLine().ToUpper();
                int indexToUpdate = itemNames.IndexOf(itemToUpdate);

                if (indexToUpdate < 0)
                {
                    Console.WriteLine("\n[!] Item not found");
                }

                else
                {
                    Console.Write("Enter new quantity: ");
                    int itemStockToUpdate = Convert.ToInt32(Console.ReadLine());

                    if (itemStockToUpdate >= 0)
                    {
                        itemStocks[indexToUpdate] = itemStockToUpdate;

                        Console.WriteLine("\n-------------------------");
                        Console.WriteLine("[!] Item updated successfully");
                        Console.WriteLine("-------------------------");
                    }

                    else
                    {
                        Console.WriteLine("\n[!] Quantity can't be less than 0.");
                    }

                }

            }


        

    


}
}
