using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System;

namespace WorldData.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
