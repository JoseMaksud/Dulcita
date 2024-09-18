using Dulcita.Models;
using Dulcita.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dulcita.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        AppDbSeed seed = new(builder);

        #region Relacionamento de Muitos para Muitos - Categorias
    
        builder.Entity<ProdutoCategoria>().HasKey(
            pt => new { pt.ProdutoNumero, pt.CategoriaId }
        );

        builder.Entity<ProdutoCategoria>()
            .HasOne(pt => pt.Produto)
            .WithMany(p => p.Categorias)
            .HasForeignKey(pt => pt.ProdutoNumero);

        builder.Entity<ProdutoCategoria>()
            .HasOne(pt => pt.Categoria)
            .WithMany(t => t.Produtos)
            .HasForeignKey(pt => pt.CategoriaId);

        #endregion
    }
}