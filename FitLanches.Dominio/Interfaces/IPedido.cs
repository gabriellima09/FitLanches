using FitLanches.Dominio.Enums;
using FitLanches.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.Dominio.Interfaces
{
    public interface IPedido
    {
        void GerarNovoPedido(IList<Item> itens);
        void TrocarStatusPedido(StatusPedido status);
    }
}
