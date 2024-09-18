using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulcita.Models;

[Table("ProdutoCategoria")]
public class ProdutoCategoria
{
    [Key, Column(Order = 1)]
    public int ProdutoNumero { get; set; }
    [ForeignKey("ProdutoNumero")]
    public Produto Produto { get; set; }

    [Key, Column(Order = 2)]
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public Categoria Categoria { get; set; }

}