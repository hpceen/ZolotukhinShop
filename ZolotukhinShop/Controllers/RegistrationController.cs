using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Repositories.Database.Entities;
using Repositories.Interfaces;

namespace ZolotukhinShop.Controllers;

public class RegistrationController(IUserRepository userRepository) : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Register(string lastName, string firstName, string patronymic, string phone,
        string password)
    {
        if (await userRepository.GetUserByPhone(phone) != null)
            return RedirectToAction("Index", "Login", new { error = "Такой юзер уже существует. Войдите!" });
        await userRepository.AddUser(new UserEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Patronymic = patronymic,
            Phone = phone,
            Password = password
        });
        
        var claims = new List<Claim>
        {
            new("firstName", firstName),
            new("lastName", lastName),
            new("patronymic", patronymic),
            new(ClaimTypes.MobilePhone, phone)
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await HttpContext.SignInAsync(claimsPrincipal);
        return RedirectToAction("Index", "Home");
    }
}