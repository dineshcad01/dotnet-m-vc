using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_sharp2.Models;

namespace MVC_sharp2.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
     public IActionResult Order()
    {
        return View();
    }
     public IActionResult Login()
    {
        return View();
    }
     public IActionResult Help()
    {
        return View();
    }
}
