using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using go_webapi.BLL;
using go_webapi.Models;

namespace go_webapi.Controllers
{
  [Route("api/[controller]")]
  public class ApiPessoaController : Controller
  {
    // GET api/values
    [HttpGet("{name}")]
    public List<User> GetUsersName(String name)
    {
      var List = new BUser().FindUsers();
      var res = List.Where(p => p.Name == name).ToList();
      return res;
    }
  }
}