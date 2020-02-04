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
    [HttpGet]
    [Route("/ShowAll")]
    public IActionResult Index()
    {
      MongoDbContext dbContext = new MongoDbContext();
      List<User> listUser = dbContext.User.Find(m => true).ToList();
      return View(listUser);
    }

    [HttpGet]
    [Route("/ShowAllByName/{name}")]
    public IActionResult ShowAllByName(String name)
    {
      MongoDbContext dbContext = new MongoDbContext();
      List<User> listUser = dbContext.User.Find(m => true).ToList();
      var list = listUser.Where(p => p.Name == name).ToList();
      return View(listUser);
    }

    [HttpPost]
    [Route("/AddUser")]
    public IActionResult AddUser(User entity)
    {
      MongoDbContext dbContext = new MongoDbContext();

      dbContext.User.InsertOne(entity);
      return RedirectToAction("Index", "User");
    }

    [HttpGet]
    [Route("/DeleteUser")]
    public IActionResult Delete(String Name)
    {
      MongoDbContext dbContext = new MongoDbContext();
      dbContext.User.DeleteOne(m => m.Name == Name);
      return RedirectToAction("Index", "User");
    }
  }
}