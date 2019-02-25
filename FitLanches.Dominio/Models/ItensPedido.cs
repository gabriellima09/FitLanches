using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Dominio.Models
{
    public class ItensPedido : Item
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int Quantidade { get; set; }
        public bool Selecionado { get; set; }
    }
}
