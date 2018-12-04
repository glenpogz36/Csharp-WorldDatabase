using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class CountryControllers : Controller
  {
    [HttpGet("/country")]
    public ActionResult Index()
    {
      List<Country> allcountries= Country.GetAll();
      return View(allcountries);
    }

  }
}
