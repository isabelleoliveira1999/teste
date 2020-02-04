using System.Collections.Generic;
using go_webapi.Models;
using go_webapi.DAL;

namespace go_webapi.BLL
{
   public class BUser
   {
       public List<User> FindUsers(){
           return new DAOUser().FindUsers();
       }      
   }
}