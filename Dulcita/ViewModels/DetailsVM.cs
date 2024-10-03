using System.Collections.Generic;
using Dulcita.Models;

namespace Dulcita.ViewModels
{
    public class DetailsVM
    {
        public Produto Produto { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<Produto> ProdutosRelacionados { get; set; } 
    }
}
