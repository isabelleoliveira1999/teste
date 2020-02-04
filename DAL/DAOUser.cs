using Npgsql;
using System.Collections.Generic;
using System;
using go_webapi.Models;

namespace go_webapi.DAL
{

  public class DAOUser
  {
    public static bool InsertUser(User user)
    {
      bool status;
      try
      {
        // DbContext.Products.Add(user);  
        //DbContext.SaveChanges();  
        status = true;
      }
      catch (Exception)
      {
        status = false;
      }
      return status;
    }
    public List<User> FindUsers()

    {
      var connString = "Host=localhost;Username=postgres;Password=zp3;Database=DotNetCoreAPI";

      List<User> lstUser = new List<User>();

      try
      {
        using (var conn = new NpgsqlConnection(connString))
        {
          conn.Open();
          using (var cmd = new NpgsqlCommand("SELECT * FROM \"Users\"", conn))
          using (var reader = cmd.ExecuteReader())
            while (reader.Read())
            {
              User user = new User();
              user.Id = (Int64)reader["id"];
              user.Birth = (String)reader["birth"];
              user.Name = (String)reader["name"];
              user.Genre = (String)reader["genre"];
              lstUser.Add(user);
            }
          conn.Close();
        }
      }
      catch (Exception ex)
      {
        string teste = ex.Message;
      }

      return lstUser;
    }
  }

}