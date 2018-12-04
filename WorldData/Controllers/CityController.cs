using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class CityController : Controller
  {
    [HttpGet("/city")]
    public ActionResult Index()
    {
      List<City> allcities= City.GetAll();
      return View(allcities);
    }
    // [HttpPost("/city")]
    // public ActionResult create(string cityname)
    // {
    //   List Inputedcity = City
    //   return View();
    // }

  }
}
