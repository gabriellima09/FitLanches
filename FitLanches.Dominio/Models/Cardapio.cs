using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Dominio.Models
{
    public class Cardapio
    {
        public Cardapio()
        {
            Itens = new List<ItensPedido>
            {
                new ItensPedido
                {
                    Id = 1,
                    Categoria = Enums.CategoriaItem.Hamburguer,
                    Descricao = "X-Burger",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 60,
                    Valor = 10
                },
                new ItensPedido
                {
                    Id = 2,
                    Categoria = Enums.CategoriaItem.Bebiba,
                    Descricao = "Suco Natural",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 40,
                    Valor = 5.50M
                },
                new ItensPedido
                {
                    Id = 3,
                    Categoria = Enums.CategoriaItem.Sobremesa,
                    Descricao = "Sorvete de Pote",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 10,
                    Valor = 8.50M
                },
                new ItensPedido
                {
                    Id = 4,
                    Categoria = Enums.CategoriaItem.Hamburguer,
                    Descricao = "X-Tudo",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 90,
                    Valor = 12.75M
                },
                new ItensPedido
                {
                    Id = 5,
                    Categoria = Enums.CategoriaItem.Salgado,
                    Descricao = "Coxinha de Frango",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 15,
                    Valor = 5
                }
            };
        }

        public IList<ItensPedido> Itens;
    }
}
