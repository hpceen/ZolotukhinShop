using Microsoft.AspNetCore.Mvc;
using ZolotukhinShop.Common;

namespace ZolotukhinShop.Controllers;

public class OrderController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SubmitOrder()
    {
        HttpContext.Session.Remove(Keys.CartModel);
        return View();
    }
}