using FitLanches.Dominio.Enums;
using FitLanches.Dominio.Interfaces;
using FitLanches.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLanches.BLL.Models
{
    public class GerenciadorPedido : IPedido
    {
        public void EntregarPedido(Pedido pedido)
        {
            VerificarPedido(pedido);

            TrocarStatusPedido(pedido, StatusPedido.PedidoEntregue);
        }

        public void FinalizarPreparoPedido(Pedido pedido)
        {
            VerificarPedido(pedido);

            TrocarStatusPedido(pedido, StatusPedido.PreparoFinalizado);
        }

        public void GerarNovoPedido(IList<Item> itens)
        {
            if ((itens == null || itens.Count < 1) || itens.Count(x => x.Selecionado) == 0)
            {
                throw new ApplicationException("Ocorreu um erro ao gerar o pedido. A lista de itens estava vazia.");
            }

            ValidarPromocao(ref itens);

            Pedido pedido = new Pedido
            {
                Itens = itens
            };
            
            //salvar pedido

            VerificarPedido(pedido);

            TrocarStatusPedido(pedido, StatusPedido.PreparoIniciado);

            //retornar tempo de espera até a retirada
            
            //TODO: verificar como armazenar/exibir o tempo na tela
        }

        public void RetirarPedido(Pedido pedido)
        {
            VerificarPedido(pedido);

            TrocarStatusPedido(pedido, StatusPedido.PedidoEntregue);
        }

        public void TrocarStatusPedido(Pedido pedido, StatusPedido status)
        {
            pedido.Status = status;
            
            //salvar novo status no banco
        }

        public void ValidarPromocao(ref IList<Item> itens)
        {
            if (itens.Count(x => x.Categoria == CategoriaItem.Hamburguer && x.Quantidade >= 2) > 0)
            {
                itens.Add(new Item
                {
                    Id = 0,
                    Descricao = "Suco Promoção",
                    Categoria = CategoriaItem.Bebiba,
                    TempoPreparo = 0,
                    Status = StatusItem.Disponivel,
                    Valor = decimal.Zero
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
    }
}
