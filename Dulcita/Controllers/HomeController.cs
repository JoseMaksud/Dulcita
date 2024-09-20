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

    public IActionResult Cardapio(string searchTerm, int? categoriaId, int page = 1, int pageSize = 9)
{
    // Obter a lista de categorias
    var categorias = _context.Categorias.ToList();

    // Obter produtos e incluir as categorias relacionadas
    var produtosQuery = _context.Produtos
        .Include(p => p.Categorias)
        .ThenInclude(pc => pc.Categoria)
        .AsQueryable();

    // Filtro por termo de pesquisa
    if (!string.IsNullOrEmpty(searchTerm))
    {
        produtosQuery = produtosQuery.Where(p => p.Nome.Contains(searchTerm));
    }

    // Filtro por categoria, se selecionada
    if (categoriaId.HasValue)
    {
        produtosQuery = produtosQuery.Where(p => p.Categorias.Any(c => c.CategoriaId == categoriaId));
    }

    // Contagem total de produtos (após filtros)
    var totalProdutos = produtosQuery.Count();

    // Paginação dos produtos
    var produtos = produtosQuery
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    HomeVM home = new HomeVM
    {
        Categorias = categorias,
        Produtos = produtos,
        CurrentSearchTerm = searchTerm,
        CurrentCategoriaId = categoriaId,
        CurrentPage = page,
        TotalPages = (int)Math.Ceiling(totalProdutos / (double)pageSize),
        TotalProdutos = totalProdutos
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
