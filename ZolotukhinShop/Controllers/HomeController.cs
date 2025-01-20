using System.Diagnostics;
using DomainModule.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using ZolotukhinShop.ViewModels;

namespace ZolotukhinShop.Controllers;

public class HomeController(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    ILogger<HomeController> logger)
    : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(Filter filter)
    {
        var categories = await categoryRepository.GetAll();
        var products = await productRepository.GetByFilter(filter);
        return View(new IndexViewModel
        {
            Products = products, Categories = categories, Filter = filter
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public Task<IActionResult> Test()
    {
        return Task.FromResult<IActionResult>(Content("<h1>Zolotukhin</h1>", "text/html"));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var product = await productRepository.GetById(id);
        if (product == null) return NotFound();

        return View(product);
    }
}