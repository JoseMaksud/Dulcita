using Microsoft.AspNetCore.Mvc;
using Dulcita.Models;
using Dulcita.Helpers; // Para os helpers de sessão
using System.Linq;
using Dulcita.Data;

namespace Dulcita.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly AppDbContext _context;

        public CarrinhoController(AppDbContext context)
        {
            _context = context;
        }

        // Exibir o carrinho
        public IActionResult Index()
        {
            var carrinho = SessionHelper.GetCarrinho(HttpContext.Session);
            return View(carrinho);
        }

        // Adicionar produto ao carrinho
        public IActionResult Adicionar(int produtoId, int quantidade = 1)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null) return NotFound();

            var carrinho = SessionHelper.GetCarrinho(HttpContext.Session);
            var item = carrinho.Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

            if (item != null)
            {
                item.Quantidade += quantidade;
            }
            else
            {
                carrinho.Itens.Add(new ItemCarrinho { Produto = produto, Quantidade = quantidade });
            }

            SessionHelper.SetCarrinho(HttpContext.Session, carrinho);
            return RedirectToAction("Index");
        }

        // Remover produto do carrinho
        public IActionResult Remover(int produtoId)
        {
            var carrinho = SessionHelper.GetCarrinho(HttpContext.Session);
            var item = carrinho.Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

            if (item != null)
            {
                carrinho.Itens.Remove(item);
            }

            SessionHelper.SetCarrinho(HttpContext.Session, carrinho);
            return RedirectToAction("Index");
        }

        // Finalizar compra enviando a mensagem para o WhatsApp// Finalizar compra enviando a mensagem para o WhatsApp
        public IActionResult FinalizarCompra()
        {
            var carrinho = SessionHelper.GetCarrinho(HttpContext.Session);

            if (!carrinho.Itens.Any())
            {
                return RedirectToAction("Index");
            }

            // Monta a mensagem para o WhatsApp
            var mensagem = MontarMensagemWhatsApp(carrinho);
            var numeroWhatsApp = "5514988270845"; // Coloque aqui o número do WhatsApp

            // Redireciona para o WhatsApp
            return Redirect($"https://api.whatsapp.com/send?phone={numeroWhatsApp}&text={mensagem}");
        }

        // Montar a mensagem de resumo do carrinho para o WhatsApp
        private string MontarMensagemWhatsApp(CarrinhoViewModel carrinho)
        {
            var mensagem =
                "Pedido Dulcita\n" +
                "*------------------------------*\n" +
                "*PEDIDO DONUTS*\n";

            // Adiciona os itens do carrinho com apenas os nomes
            foreach (var item in carrinho.Itens)
            {
                mensagem += $"* {item.Produto.Nome}  - Quantidade: {item.Quantidade}\n";
            }

            mensagem +=
                "*------------------------------*\n" +
                $"*TOTAL:* R${carrinho.Total}\n" +
                "*------------------------------*";

            return Uri.EscapeDataString(mensagem); // Codifica para URL no final da mensagem
        }

        [HttpPost]
        public IActionResult AtualizarCarrinho(int[] produtoIds, int[] quantidades)
        {
            var carrinho = SessionHelper.GetCarrinho(HttpContext.Session);

            for (int i = 0; i < produtoIds.Length; i++)
            {
                var produtoId = produtoIds[i];
                var novaQuantidade = quantidades[i];

                var item = carrinho.Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

                if (item != null)
                {
                    if (novaQuantidade > 0)
                    {
                        item.Quantidade = novaQuantidade;
                    }
                    else
                    {
                        // Remove o item se a quantidade for zero ou negativa
                        carrinho.Itens.Remove(item);
                    }
                }
            }

            SessionHelper.SetCarrinho(HttpContext.Session, carrinho);
            return RedirectToAction("Index");
        }


    }
}
