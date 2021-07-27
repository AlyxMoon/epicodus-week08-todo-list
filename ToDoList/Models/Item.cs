using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; set; }

    public Item(string description)
    {
      Description = description;
    }
    public Item(string description, int id)
    {
      Description = description;
      Id = id;
    }

    public override bool Equals(object otherItem)
    {
      if (otherItem is Item item)
      {
        return (
          Id == item.Id && 
          Description == item.Description
        );
      }
      else
      {
        return false;
      }
    }

    public static List<Item> GetAll()
    {
      List<Item> allItems = new() { };

      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT * FROM items;";

      MySqlDataReader rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        allItems.Add(new(itemDescription, itemId));
      }

      conn.Close();
      if (conn != null) conn.Dispose();
  
      return allItems;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"DELETE FROM items;";
      cmd.ExecuteNonQuery();
      conn.Close();

      if (conn != null) conn.Dispose();
    }

    public static Item Find(int searchId)
    {
      return new Item("placeholder item");
    }
  }
}
