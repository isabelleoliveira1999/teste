using GoOrangeApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GoOrangeApi.Controllers
{
  public class LoginController : Controller
  {
    public IActionResult Index()
    {
      MongoDbContext dbContext = new MongoDbContext();
      List<User> listaNotas = dbContext.User.Find(m => true).ToList();
      return View(listaNotas);
    }
    [HttpPost]
    public IActionResult AddUser(User entity)
    {
      MongoDbContext dbContext = new MongoDbContext();

      dbContext.User.InsertOne(entity);
      return RedirectToAction("Index", "User");
    }
    [HttpGet]
    public IActionResult Delete(String Name)
    {
      MongoDbContext dbContext = new MongoDbContext();
      dbContext.User.DeleteOne(m => m.Name == Name);
      return RedirectToAction("Index", "User");
    }
  }
}