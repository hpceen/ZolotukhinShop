using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace ZolotukhinShop.Controllers;

public class LoginController(IUserRepository userRepository) : Controller
{
    public IActionResult Index(string? error = null)
    {
        ViewData["Error"] = error;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string phone, string password)
    {
        var user = await userRepository.GetUserByPhone(phone);
        if (user == null || user.Password != password)
            return new RedirectToActionResult("Index", "Login", new { error = "Неверный логин или пароль" });

        var claims = new List<Claim>
        {
            new("lastName", user.LastName),
            new("firstName", user.FirstName),
            new("patronymic", user.Patronymic),
            new(ClaimTypes.MobilePhone, user.Phone)
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await HttpContext.SignInAsync(claimsPrincipal);
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}