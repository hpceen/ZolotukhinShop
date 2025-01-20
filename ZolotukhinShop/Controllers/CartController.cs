using DomainModule.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using ZolotukhinShop.Common;

namespace ZolotukhinShop.Controllers;

public class CartController(ILogger<HomeController> logger, IProductRepository productRepository) : Controller
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        var cart = HttpContext.Session.Get<CartModel>(Keys.CartModel) ?? new CartModel();
        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int id, string urlAction, string controllerName)
    {
        var product = await _productRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }

        var cart = HttpContext.Session.Get<CartModel>(Keys.CartModel) ?? new CartModel();
        cart.Add(product);
        HttpContext.Session.Set(Keys.CartModel, cart);
        return new RedirectToActionResult(urlAction, controllerName, (urlAction == "Details") ? new { id } : null);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int id, string urlAction, string controllerName)
    {
        var product = await _productRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }

        var cart = HttpContext.Session.Get<CartModel>(Keys.CartModel) ?? new CartModel();
        cart.Remove(product);
        HttpContext.Session.Set(Keys.CartModel, cart);
        return new RedirectToActionResult(urlAction, controllerName, (urlAction == "Details") ? new { id } : null);
    }

    public IActionResult RemoveAllFromCart(int id, string urlAction, string controllerName)
    {
        var cart = HttpContext.Session.Get<CartModel>(Keys.CartModel);
        if (cart == null) return NotFound();
        cart.RemoveAll(id);
        HttpContext.Session.Set(Keys.CartModel, cart);
        return new RedirectToActionResult(urlAction, controllerName, (urlAction == "Details") ? new { id } : null);
    }
}