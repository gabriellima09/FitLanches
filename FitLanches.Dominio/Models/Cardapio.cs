﻿using System;
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
                    Categoria = Enums.CategoriaItem.Hamburguer,
                    Descricao = "X-Burger",
                    Status = Enums.StatusItem.Disponivel,
                    TempoPreparo = 330,
                    Valor = 15
                },
                new Item
                {
                    Id = 2,
                    Categoria = Enums.CategoriaItem.Bebiba,
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
