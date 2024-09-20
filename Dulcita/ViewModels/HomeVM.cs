using System.Collections.Generic;
using Dulcita.Models;

namespace Dulcita.ViewModels
{
    public class HomeVM
    {
        public List<Categoria> Categorias { get; set; } 
        public List<Produto> Produtos { get; set; } 
        public string CurrentSearchTerm { get; set; } 
        public int? CurrentCategoriaId { get; set; } 
        public int CurrentPage { get; set; } 
        public int TotalPages { get; set; } 
        public int TotalProdutos { get; set; }
    }
}
