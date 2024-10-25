using Dulcita.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Dulcita.Helpers
{
    public static class SessionHelper
    {
        public static CarrinhoViewModel GetCarrinho(ISession session)
        {
            var carrinho = session.GetObjectFromJson<CarrinhoViewModel>("Carrinho");
            if (carrinho == null)
            {
                carrinho = new CarrinhoViewModel();
            }
            return carrinho;
        }

        public static void SetCarrinho(ISession session, CarrinhoViewModel carrinho)
        {
            session.SetObjectAsJson("Carrinho", carrinho);
        }
    }
}
