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
        void GerarNovoPedido(IList<ItensPedido> itens);
        void FinalizarPreparoPedido(Pedido pedido);
        void RetirarPedido(Pedido pedido);
        void EntregarPedido(Pedido pedido);
        void TrocarStatusPedido(Pedido pedido, StatusPedido status);
        void ValidarPromocao(ref IList<ItensPedido> itens);
        IList<Pedido> SelecionarTodos();
        Pedido SelecionarPorId(int id);
        IList<Pedido> GerenciarPedidos(IList<Pedido> pedidos);
    }
}
