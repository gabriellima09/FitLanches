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
                    Valor = 15
                },
                new ItensPedido
                {
                    Id = 2,
                    Categoria = Enums.CategoriaItem.Bebiba,
                    Descricao = "Suco",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 12,
                    Valor = 5
                }
            };
        }

        public IList<ItensPedido> Itens;
    }
}
