using System.Collections.Generic;
using System.Linq;

namespace Dulcita.Models
{
    public class CarrinhoViewModel
    {
        public List<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();
        public decimal Total => Itens.Sum(i => i.Total); // Total do carrinho
    }
}
