using MySql.Data.MySqlClient;
using ToDoList;

namespace ToDoList.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      return new MySqlConnection(DBConfiguration.ConnectionString);
    }
  }
}