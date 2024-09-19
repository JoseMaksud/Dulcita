using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dulcita.Models;
using Dulcita.Data;
using Dulcita.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Dulcita.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Sobre()
    {
        return View();
    }

    public IActionResult Cardapio()
     {
        HomeVM home = new() {
            Categorias = _context.Categorias.ToList(),
            Produtos = _context.Produtos
                .Include(p => p.Categorias)
                .ThenInclude(t => t.Categoria)
                .ToList(),
        };
        return View(home);
    }

    

    public IActionResult Contato()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
