﻿using FitLanches.Comum.Models;
using FitLanches.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Dominio.Models
{
    public class ItensPedido : EntidadeDominio
    {
        public CategoriaItem Categoria { get; set; }
        public string Descricao { get; set; }
        public int TempoPreparo { get; set; }
        public decimal Valor { get; set; }
        public StatusItem Status { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int Quantidade { get; set; }
        public bool Selecionado { get; set; }
    }
}
