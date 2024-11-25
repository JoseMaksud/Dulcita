using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Dulcita.Models;

namespace Dulcita.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region Populate Categoria
        List<Categoria> categorias = new() {
                new Categoria() {
                Id = 1,
                Nome = "Donuts Tradicionais",
            },
            new Categoria() {
                Id = 2,
                Nome = "Donuts Recheados",
            },
            new Categoria() {
                Id = 3,
                Nome = "Donuts Salgados",
            },
            new Categoria() {
                Id = 4,
                Nome = "Mini Donuts",
            },
            new Categoria() {
                Id = 5,
                Nome = "Bebidas",
            }
        };
        builder.Entity<Categoria>().HasData(categorias);
        #endregion

        #region Populate Produtos
        List<Produto> produtos = new() {
            new Produto() {
                Id = 1,
                Nome = "Açúcar com canela",
                Ingredientes = "Donut passado no açúcar refinado com canela em pó.",
                Preco = 8.90M,
                PrecoDesconto = 8.90M,
                Imagem = @"img/produtos/1.png",
            },
            new Produto() {
                Id = 2,
                Nome = "Chocolate ao leite",
                Ingredientes = "Cobertura de chocolate ao leite e granulado.",
                Preco = 10.90M,
                PrecoDesconto = 10.90M,
                Imagem = @"img/produtos/2.png",
            },
            new Produto() {
                Id = 3,
                Nome = "Blue",
                Ingredientes = "Cobertura de chocolate branco tingido de azul e granulado colorido.",
                Preco = 11.90M,
                PrecoDesconto = 11.90M,
                Imagem = @"img/produtos/3.png",
            },
            new Produto() {
                Id = 4,
                Nome = "Homer",
                Ingredientes = "Cobertura de chocolate branco tingido de rosa e granulado colorido.",
                Preco = 11.90M,
                PrecoDesconto = 11.90M,
                Imagem = @"img/produtos/4.png",
            },
            new Produto() {
                Id = 5,
                Nome = "Chocolate meio amargo",
                Ingredientes = "Cobertura de chocolate meio amargo.",
                Preco = 11.90M,
                PrecoDesconto = 11.90M,
                Imagem = @"img/produtos/5.png",
            },
            new Produto() {
                Id = 6,
                Nome = "Confete",
                Ingredientes = "Cobertura de chocolate ao leite e coberto com confete.",
                Preco = 11.90M,
                PrecoDesconto = 11.90M,
                Imagem = @"img/produtos/6.png",
            },
            new Produto() {
                Id = 7,
                Nome = "Nutella",
                Ingredientes = "Cobertura generosa de Nutella.",
                Preco = 14.90M,
                PrecoDesconto = 14.90M,
                Imagem = @"img/produtos/7.png",
            },
            new Produto() {
                Id = 8,
                Nome = "Ouro Branco",
                Ingredientes = "Cobertura de ganache de chocolate branco, fios de chocolate ao leite e ouro branco picado.",
                Preco = 14.90M,
                PrecoDesconto = 14.90M,
                Imagem = @"img/produtos/8.png",
            },
            new Produto() {
                Id = 9,
                Nome = "Ninho",
                Ingredientes = "Cobertura de brigadeiro de leite ninho finalizado com leite em pó.",
                Preco = 13.90M,
                PrecoDesconto = 13.90M,
                Imagem = @"img/produtos/9.png",
            },
            new Produto() {
                Id = 10,
                Nome = "KitKat",
                Ingredientes = "Cobertura de ganache de chocolate ao leite finalizado com KitKat.",
                Preco = 13.90M,
                PrecoDesconto = 13.90M,
                Imagem = @"img/produtos/10.png",
            },
            new Produto() {
                Id = 11,
                Nome = "Stikadinho",
                Ingredientes = "Cobertura de chocolate meio amargo, fios de recheio de morango e Stikadinho.",
                Preco = 13.90M,
                PrecoDesconto = 13.90M,
                Imagem = @"img/produtos/11.png",
            },
            new Produto() {
                Id = 12,
                Nome = "Churros",
                Ingredientes = "Cobertura de brigadeiro de churros polvilhado com açúcar e canela.",
                Preco = 13.90M,
                PrecoDesconto = 13.90M,
                Imagem = @"img/produtos/12.png",
            },
            new Produto() {
                Id = 13,
                Nome = "Doce de leite",
                Ingredientes = "Cobertura de doce de leite.",
                Preco = 13.90M,
                PrecoDesconto = 13.90M,
                Imagem = @"img/produtos/13.png",
            },
            new Produto() {
                Id = 14,
                Nome = "Kinder bueno",
                Ingredientes = "Recheado de Nutella e ganache branca coberto com chocolate ao leite e Kinder bueno.",
                Preco = 19.90M,
                PrecoDesconto = 19.90M,
                Imagem = @"img/produtos/14.png",
            },
            new Produto() {
                Id = 15,
                Nome = "Ferrero rocher",
                Ingredientes = "Recheado com brigadeiro de Ferrero coberto com chocolate ao leite, amendoim e bombom Ferrero.",
                Preco = 19.90M,
                PrecoDesconto = 19.90M,
                Imagem = @"img/produtos/15.png",
            },
            new Produto() {
                Id = 16,
                Nome = "Petit Gateau",
                Ingredientes = "Recheado com brigadeiro coberto com chocolate meio amargo e uma bola de sorvete.",
                Preco = 19.90M,
                PrecoDesconto = 19.90M,
                Imagem = @"img/produtos/16.png",
            },
            new Produto() {
                Id = 17,
                Nome = "Nutella (recheado)",
                Ingredientes = "Recheado de Nutella com cobertura de Nutella.",
                Preco = 19.90M,
                PrecoDesconto = 19.90M,
                Imagem = @"img/produtos/17.png",
            },
            new Produto() {
                Id = 18,
                Nome = "Ninho com Nutella",
                Ingredientes = "Recheado com brigadeiro de Ninho coberto com Nutella, finalizado com chocoball.",
                Preco = 18.90M,
                PrecoDesconto = 18.90M,
                Imagem = @"img/produtos/18.png",
            },
            new Produto() {
                Id = 19,
                Nome = "Banana nevada",
                Ingredientes = "Recheado de ganache de chocolate branco com banana e casquinha de chocolate branco.",
                Preco = 18.90M,
                PrecoDesconto = 18.90M,
                Imagem = @"img/produtos/19.png",
            },
            new Produto() {
                Id = 20,
                Nome = "Surpresa de uva",
                Ingredientes = "Recheado com brigadeiro de Ninho e uvas frescas, coberto com ganache de chocolate ao leite, uvas e polvilhado com leite Ninho.",
                Preco = 18.90M,
                PrecoDesconto = 18.90M,
                Imagem = @"img/produtos/20.png",
            },
            new Produto() {
                Id = 21,
                Nome = "Ouro branco (recheado)",
                Ingredientes = "Recheio cremoso de Ouro Branco, coberto com chocolate branco, bombom de Ouro Branco picado e fios de chocolate ao leite.",
                Preco = 17.90M,
                PrecoDesconto = 17.90M,
                Imagem = @"img/produtos/21.png",
            },
            new Produto() {
                Id = 22,
                Nome = "Super ninho",
                Ingredientes = "Recheado de brigadeiro de Ninho, coberto e polvilhado com leite em pó.",
                Preco = 15.90M,
                PrecoDesconto = 15.90M,
                Imagem = @"img/produtos/22.png",
            },
            new Produto() {
                Id = 23,
                Nome = "Stikadinho (recheado)",
                Ingredientes = "Recheado com creme de morango, coberto com chocolate meio amargo, fios de creme de morango e Stikadinho.",
                Preco = 15.90M,
                PrecoDesconto = 15.90M,
                Imagem = @"img/produtos/23.png",
            },
            new Produto() {
                Id = 24,
                Nome = "Oreo",
                Ingredientes = "Recheado com brigadeiro de Oreo, coberto com chocolate branco e Oreo.",
                Preco = 15.90M,
                PrecoDesconto = 15.90M,
                Imagem = @"img/produtos/24.png",
            },
            new Produto() {
                Id = 25,
                Nome = "Super doce de leite",
                Ingredientes = "Recheado com doce de leite e coberto com doce de leite.",
                Preco = 15.90M,
                PrecoDesconto = 15.90M,
                Imagem = @"img/produtos/25.png",
            },
            new Produto() {
                Id = 26,
                Nome = "Frango cremoso",
                Ingredientes = "Donut coberto com delicioso frango cremoso desfiado e catupiry original.",
                Preco = 16.90M,
                PrecoDesconto = 16.90M,
                Imagem = @"img/produtos/26.png",
            },
            new Produto() {
                Id = 27,
                Nome = "Baconpiry",
                Ingredientes = "Donut coberto com catupiry original e cubos de bacon frito.",
                Preco = 16.90M,
                PrecoDesconto = 16.90M,
                Imagem = @"img/produtos/27.png",
            },
            new Produto() {
                Id = 28,
                Nome = "Bacon cheddar",
                Ingredientes = "Donut coberto com cheddar e cubos de bacon frito.",
                Preco = 16.90M,
                PrecoDesconto = 16.90M,
                Imagem = @"img/produtos/28.png",
            },
            new Produto() {
                Id = 29,
                Nome = "Cheddar com doritos",
                Ingredientes = "Donut coberto com cheddar e Doritos.",
                Preco = 16.90M,
                PrecoDesconto = 16.90M,
                Imagem = @"img/produtos/29.png",
            },
            new Produto() {
                Id = 30,
                Nome = "Mini Donuts(Sem Recheio)",
                Ingredientes = "Feito mediante encomenda de uma semana antes.<br />" +
                   "Sabores: Ninho, Nutella, Morango e Doce de Leite.<br />" +
                   "Entre 50 e 99 unidades R$2,50<br />" +
                   "Abaixo de 29 unidades R$3,50<br />" +
                   "Entre 30 a 49 unidades R$3,50<br />" +
                   "Entre 50 e 99 unidades R$2,50<br />" +
                   "+ de 100 unidades R$2,00",
                Preco = 3.50M,
                PrecoDesconto = 3.50M,
                Imagem = @"img/produtos/30.png",
            },
            new Produto() {
                Id = 31,
                Nome = "Mini Donuts(Com Recheio)",
                Ingredientes = "Feito mediante encomenda de uma semana antes.<br />" +
                   "Sabores: Ninho, Nutella, Morango e Doce de Leite.<br />" +
                   "Abaixo de 29 unidades R$5,00.<br />" +
                   "Entre 30 a 49 unidades R$5,00.<br />" +
                   "Entre 50 e 99 unidades R$4,00.<br />" +
                   "+ de 100 unidades R$3,00.",
                Preco = 5.00M,
                PrecoDesconto = 5.00M,
                Imagem = @"img/produtos/30.png",
            },
            new Produto() {
                Id = 32,
                Nome = "Donuts Flork (coberto)",
                Ingredientes = "Donut personalizado com desenho e frase.",
                Preco = 17.90M,
                PrecoDesconto = 17.90M,
                Imagem = @"img/produtos/31.png",
            },
            new Produto() {
                Id = 33,
                Nome = "Donuts Flork (recheado)",
                Ingredientes = "Donut personalizado com desenho e frase, recheado com Nutella, Ninho, Morango ou Doce de leite.",
                Preco = 21.90M,
                PrecoDesconto = 21.90M,
                Imagem = @"img/produtos/32.png",
            },
            new Produto() {
                Id = 34,
                Nome = "Água mineral",
                Ingredientes = "",
                Preco = 4.00M,
                PrecoDesconto = 4.00M,
                Imagem = @"img/produtos/33.png",
            },
            new Produto() {
                Id = 35,
                Nome = "Água com gás",
                Ingredientes = "",
                Preco = 4.50M,
                PrecoDesconto = 4.50M,
                Imagem = @"img/produtos/34.png",
            },
            new Produto() {
                Id = 36,
                Nome = "Refrigerante lata",
                Ingredientes = "Coca-cola, Coca-cola zero, Fanta, Sprite, Guaraná Antártica, Schweppes.",
                Preco = 6.00M,
                PrecoDesconto = 6.00M,
                Imagem = @"img/produtos/35.png",
            },
            new Produto() {
                Id = 37,
                Nome = "Del vale lata",
                Ingredientes = "",
                Preco = 6.00M,
                PrecoDesconto = 6.00M,
                Imagem = @"img/produtos/36.png",
            },
            new Produto() {
                Id = 38,
                Nome = "Monster",
                Ingredientes = "",
                Preco = 11.00M,
                PrecoDesconto = 11.00M,
                Imagem = @"img/produtos/37.png",
            },
            new Produto() {
                Id = 39,
                Nome = "Soda italiana 200ml",
                Ingredientes = "Limão siciliano, frutas vermelhas, maçã verde, kiwi.",
                Preco = 13.90M,
                PrecoDesconto = 13.90M,
                Imagem = @"img/produtos/38.png",
            },
            new Produto() {
                Id = 40,
                Nome = "Milk shake 400ml",
                Ingredientes = "Nutella, Ovomaltine, Morango, Ninho com Nutella, Doce de leite, Oreo.",
                Preco = 17.90M,
                PrecoDesconto = 17.90M,
                Imagem = @"img/produtos/39.png",
            },
            new Produto() {
                Id = 41,
                Nome = "Toddynho",
                Ingredientes = "",
                Preco = 4.90M,
                PrecoDesconto = 4.90M,
                Imagem = @"img/produtos/40.png",
            },
            new Produto() {
                Id = 42,
                Nome = "Alpino 270ml",
                Ingredientes = "",
                Preco = 9.90M,
                PrecoDesconto = 9.90M,
                Imagem = @"img/produtos/41.png",
            },
            new Produto() {
                Id = 43,
                Nome = "Nescau 270ml",
                Ingredientes = "",
                Preco = 9.90M,
                PrecoDesconto = 9.90M,
                Imagem = @"img/produtos/42.png",
            },
            new Produto() {
                Id = 44,
                Nome = "Neston 270ml",
                Ingredientes = "",
                Preco = 9.90M,
                PrecoDesconto = 9.90M,
                Imagem = @"img/produtos/43.png",
            },
            new Produto() {
                Id = 45,
                Nome = "Nescafé 270ml",
                Ingredientes = "",
                Preco = 9.90M,
                PrecoDesconto = 9.90M,
                Imagem = @"img/produtos/44.png",
            },
        };
        builder.Entity<Produto>().HasData(produtos);
        #endregion

        #region Populate ProdutoCategoria
        List<ProdutoCategoria> produtoCategorias = new()
        {
            new ProdutoCategoria() {
                ProdutoNumero = 1,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 2,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 3,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 4,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 5,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 6,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 7,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 8,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 9,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 10,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 11,
                CategoriaId = 1
            },
            new ProdutoCategoria() {
                ProdutoNumero = 12,
                 CategoriaId = 1
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 13,
                 CategoriaId = 1
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 14,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 15,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 16,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 17,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 18,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 19,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 20,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 21,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 22,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 23,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 24,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 25,
                 CategoriaId = 2
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 26,
                 CategoriaId = 3
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 27,
                 CategoriaId = 3
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 28,
                 CategoriaId = 3
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 29,
                 CategoriaId = 3
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 30,
                 CategoriaId = 4
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 31,
                 CategoriaId = 4
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 32,
                 CategoriaId = 4
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 33,
                 CategoriaId = 4
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 34,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 35,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 36,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 37,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 38,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 39,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 40,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 41,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 42,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 43,
                 CategoriaId = 5
                 },
            new ProdutoCategoria() {
                ProdutoNumero = 44,
                 CategoriaId = 5
                 }
        };
        builder.Entity<ProdutoCategoria>().HasData(produtoCategorias);
        #endregion


        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate IdentityUser
        List<IdentityUser> users = new(){
            new IdentityUser(){
                Id = Guid.NewGuid().ToString(),
                Email = "admin@dulcita.com",
                NormalizedEmail = "ADMIN@DULCITA.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                EmailConfirmed = true,
            },
        };
        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "@Etec123");
        }
        builder.Entity<IdentityUser>().HasData(users);

        List<Usuario> usuarios = new(){
            new Usuario(){
                UsuarioId = users[0].Id,
                Nome = "Dulcita",
                Foto = @"img/usuarios/avatar.png"
            },
        };
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = users[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = users[0].Id,
                RoleId = roles[1].Id
            },
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}