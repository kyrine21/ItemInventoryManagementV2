using ItemModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceV2
{

    public class ItemDataServiceDB : InventoryManagementStructure
    {
        private string connectionString
       = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = ItemRecord; Integrated Security = True; TrustServerCertificate=True;";
        
        private SqlConnection sqlConnection;


        public ItemDataServiceDB()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void AddItem(Items item)
        {
            var addStatement =
            "INSERT INTO ItemList (itemName, itemQuantity) VALUES ( @itemName, @itemQuantity)";

            SqlCommand addCommand = new SqlCommand(addStatement, sqlConnection);

            addCommand.Parameters.AddWithValue("@itemName", item.itemName);
            addCommand.Parameters.AddWithValue("@itemQuantity", item.itemCount);
            
            sqlConnection.Open();

            addCommand.ExecuteNonQuery();
             
            sqlConnection.Close();

        }

        public void DeleteItem(int itemID)
        {
            string addStatement = "DELETE FROM ItemList WHERE itemID = @itemID";
            SqlCommand addCommand = new SqlCommand(addStatement, sqlConnection);
            addCommand.Parameters.AddWithValue("@itemID", itemID);
            sqlConnection.Open();

            addCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<Items> getAllItems()
        {
            string getStatementList = "SELECT itemID, itemName, itemQuantity FROM ItemList";

            SqlCommand getCommandList = new SqlCommand(getStatementList, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = getCommandList.ExecuteReader();

            List<Items> list = new List<Items>();
            while (reader.Read())
            {
                int itemID = (int)reader["itemID"];
                string itemName = reader["itemName"].ToString();
                int itemCount = (int)reader["itemQuantity"];

                list.Add(new Items { itemID = itemID,itemName = itemName, itemCount = itemCount });
            }

            sqlConnection.Close();
            return list;

        }

        public void UpdateItem(int itemID, int newCount)
        {
            string updateStatement =
            "UPDATE ItemList SET itemQuantity = @newQuantity WHERE itemID = @itemID";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@newQuantity", newCount);
            updateCommand.Parameters.AddWithValue("@itemID", itemID);

            sqlConnection.Open();
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
