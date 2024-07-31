using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulcita.Models;

[Table("Produto")]
public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o Nome")]
    [StringLength(100, ErrorMessage = "O nome deve possuir no máximo 100 caracteres")]
    public string Nome { get; set; }

    [Display(Name = "Ingredientes")]
    [StringLength(1000, ErrorMessage = "Os Ingredientes deve possuir no máximo 1000 caracteres")]
    public string Ingredientes { get; set; }

    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10,2)")] // 99.999.999,99
    [Required(ErrorMessage = "Por favor, informe o Preço de Venda")]
    public decimal Preco { get; set; }

    [Display(Name = "Preço com Desconto")]
    [Column(TypeName = "decimal(10,2)")] // 99.999.999,99
    public decimal PrecoDesconto { get; set; }

    [StringLength(300)]
    public string Imagem { get; set; }

    [Display(Name = "Categoria")]
    [Required(ErrorMessage = "Por Favor, informe a Categoria")]
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public Categoria Categoria { get; set; }
}