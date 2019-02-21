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
            Itens = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Descricao = "Hambúrger",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 300,
                    Valor = 15
                },
                new Item
                {
                    Id = 2,
                    Descricao = "Suco",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 120,
                    Valor = 5
                }
            };
        }

        public IList<Item> Itens;
    }
}
