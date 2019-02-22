﻿using FitLanches.Dominio.Enums;
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
            if (itens == null || itens.Count < 1)
            {
                throw new ApplicationException("Ocorreu um erro ao gerar o pedido. A lista de itens estava vazia.");
            }

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

        private void VerificarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ApplicationException("Não foi possível realizar a operação. O pedido não foi identificado.");
            }
        }
    }
}