using FitLanches.Dominio.Enums;
using FitLanches.Dominio.Interfaces;
using FitLanches.Dominio.Models;
using FitLanches.Repositorio.Models;
using FitLanches.Util.Formatadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.BLL.Models
{
    public class GerenciadorPedido : IPedido
    {
        private readonly RepositorioPedido repositorio = new RepositorioPedido();

        public void EntregarPedido(Pedido pedido)
        {
            VerificarPedido(pedido);

            TrocarStatusPedido(pedido, StatusPedido.PedidoEntregue);
        }

        public void GerarNovoPedido(IList<ItensPedido> itens)
        {
            if ((itens == null || itens.Count < 1) || itens.Count(x => x.Selecionado) == 0)
            {
                throw new ApplicationException("Ocorreu um erro ao gerar o pedido. A lista de itens estava vazia.");
            }

            ValidarPromocao(ref itens);

            Pedido pedido = new Pedido
            {
                Itens = itens.Where(x => x.Selecionado).ToList(),
                Status = StatusPedido.NaFila,
                Data = DateTime.Now
            };

            repositorio.Inserir(pedido);
        }

        public void RetirarPedido(Pedido pedido)
        {
            VerificarPedido(pedido);

            TrocarStatusPedido(pedido, StatusPedido.PedidoEntregue);
        }

        public IList<Pedido> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }

        public Pedido SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public void TrocarStatusPedido(Pedido pedido, StatusPedido status)
        {
            var tempPedido = SelecionarPorId(pedido.Id);

            switch (status)
            {
                case StatusPedido.PreparoIniciado:
                    tempPedido.HoraInicioPreparo = DateTime.Now.TimeOfDay;
                    break;
                case StatusPedido.PedidoEntregue:
                    tempPedido.HoraRetirada = DateTime.Now.TimeOfDay;
                    break;
            }

            tempPedido.Status = status;

            repositorio.Alterar(tempPedido);
        }

        public void ValidarPromocao(ref IList<ItensPedido> itens)
        {
            if (itens.Count(x => x.Categoria == CategoriaItem.Hamburguer && x.Selecionado) >= 2
                || itens.Any(x => x.Categoria == CategoriaItem.Hamburguer && x.Quantidade >= 2))
            {
                itens.Add(new ItensPedido
                {
                    Id = 0,
                    Descricao = "Suco Promoção",
                    Categoria = CategoriaItem.Bebiba,
                    TempoPreparo = 0,
                    Status = StatusItem.Disponivel,
                    Valor = decimal.Zero,
                    Selecionado = true
                });
            }
        }

        private void VerificarPedido(Pedido pedido)
        {
            if (pedido is null)
            {
                throw new ApplicationException("Não foi possível realizar a operação. O pedido não foi identificado.");
            }
        }

        public IList<Pedido> GerenciarPedidos(IList<Pedido> pedidos)
        {
            while (pedidos.Any(x => x.Status == StatusPedido.NaFila) && pedidos.Count(x => x.Status == StatusPedido.PreparoIniciado) < 2)
            {
                Pedido pedido = pedidos
                    .Where(x => x.Status == StatusPedido.NaFila)
                    .OrderBy(y => y.Id)
                    .First();

                TrocarStatusPedido(pedido, StatusPedido.PreparoIniciado);

                pedidos = repositorio.SelecionarTodos();
            }

            foreach (var pedido in pedidos.Where(x => x.Status == StatusPedido.PreparoIniciado))
            {
                if (VerificarPedidoFinalizado(pedido.HoraInicioPreparo, pedido.Itens))
                {
                    TrocarStatusPedido(pedido, StatusPedido.PedidoProntoRetirada);
                }
            }

            return repositorio.SelecionarTodos();
        }

        private bool VerificarPedidoFinalizado(TimeSpan horaInicio, IList<ItensPedido> itens)
        {
            TimeSpan total = TimeSpan.FromSeconds(itens.Sum(x => x.TempoPreparo));

            return horaInicio.Add(total) < DateTime.Now.TimeOfDay;
        }

        public static string VerificarTempoPedido(TimeSpan horaInicio, IList<ItensPedido> itens)
        {
            TimeSpan total = TimeSpan.FromSeconds(itens.Sum(x => x.TempoPreparo));
            TimeSpan finalizado = horaInicio.Add(total);
            TimeSpan agora = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            horaInicio.Add(total).Subtract(DateTime.Now.TimeOfDay);

            return Convert.ToInt32(finalizado.Subtract(agora).TotalSeconds).ConverterTempo();
        }
    }
}
