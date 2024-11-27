using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dulcita.Data;
using Dulcita.Models;

namespace Dulcita.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produtos
        .Include(p => p.Categorias)
        .ThenInclude(pc => pc.Categoria)
        .ToListAsync();

            return View(produtos);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["Categorias"] = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Ingredientes,Preco,Imagem")] Produto produto, IFormFile Arquivo, int[] CategoriasSelecionadas)
        {
            if (ModelState.IsValid)
            {
                if (Arquivo != null && Arquivo.Length > 0)
                {
                    var caminhoImagens = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/produtos");
                    if (!Directory.Exists(caminhoImagens))
                    {
                        Directory.CreateDirectory(caminhoImagens);
                    }

                    var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(Arquivo.FileName);
                    var caminhoArquivo = Path.Combine(caminhoImagens, nomeArquivo);

                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await Arquivo.CopyToAsync(stream);
                    }

                    produto.Imagem = $"img/produtos/{nomeArquivo}";
                }

                _context.Add(produto);
                await _context.SaveChangesAsync();

                // Associar as categorias selecionadas
                foreach (var categoriaId in CategoriasSelecionadas)
                {
                    var produtoCategoria = new ProdutoCategoria
                    {
                        ProdutoNumero = produto.Id,
                        CategoriaId = categoriaId
                    };
                    _context.Add(produtoCategoria);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Categorias"] = new SelectList(_context.Categorias, "Id", "Nome");
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ingredientes,Preco,PrecoDesconto,Imagem")] Produto produto, IFormFile Arquivo)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Arquivo != null && Arquivo.Length > 0)
                    {
                        var caminhoImagens = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/produtos");
                        if (!Directory.Exists(caminhoImagens))
                        {
                            Directory.CreateDirectory(caminhoImagens);
                        }

                        // Nome único para o novo arquivo
                        var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(Arquivo.FileName);
                        var caminhoArquivo = Path.Combine(caminhoImagens, nomeArquivo);

                        // Salvar o novo arquivo
                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        {
                            await Arquivo.CopyToAsync(stream);
                        }

                        // Atualizar o caminho da nova imagem no modelo
                        produto.Imagem = $"img/produtos/{nomeArquivo}";
                    }
                    // Caso nenhuma nova imagem seja enviada, o campo `Imagem` mantém o valor atual.

                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
