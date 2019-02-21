using FitLanches.Comum.Models;
using FitLanches.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Dominio.Models
{
    public class Pedido : EntidadeDominio
    {
        public Pedido()
        {
            Itens = new List<Item>();
            Status = StatusPedido.PreparoIniciado;
        }

        public IList<Item> Itens { get; set; }
        public StatusPedido Status { get; set; }
    }
}
