using FitLanches.BLL.Models;
using FitLanches.Dominio.Enums;
using FitLanches.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitLanches.UI.Controllers
{
    public class PedidoController : Controller
    {
        private GerenciadorPedido gerenciador = new GerenciadorPedido();

        // GET: Pedido
        public ActionResult Index()
        {
            IList<Pedido> pedidos = new List<Pedido>
            {
                new Pedido
                {
                    Id = 1,
                    Status = StatusPedido.PreparoIniciado,
                    Itens = new List<Item>
                    {
                        new Item
                        {
                            Descricao = "item teste"
                        }
                    }
                },
                new Pedido
                {
                    Id = 2,
                    Status = StatusPedido.PreparoFinalizado,
                    Itens = new List<Item>
                    {
                        new Item
                        {
                            Descricao = "item teste"
                        }
                    }
                },
                new Pedido
                {
                    Id = 3,
                    Status = StatusPedido.PedidoProntoRetirada,
                    Itens = new List<Item>
                    {
                        new Item
                        {
                            Descricao = "item teste"
                        }
                    }
                },
                new Pedido
                {
                    Id = 4,
                    Status = StatusPedido.PedidoEntregue,
                    Itens = new List<Item>
                    {
                        new Item
                        {
                            Descricao = "item teste"
                        }
                    }
                }
            };

            return View(pedidos);
        }

        public ActionResult MonitorPedidos(IList<Pedido> pedidos)
        {
            return PartialView(pedidos);
        }

        [ValidateAntiForgeryToken]
        public ActionResult GerarPedido(IList<Item> itens)
        {
            gerenciador.GerarNovoPedido(itens);

            return RedirectToAction("Index");
        }

        public ActionResult PreparoFinalizado(Pedido pedido)
        {
            gerenciador.FinalizarPreparoPedido(pedido);

            return RedirectToAction("MonitorPedidos");
        }

        public ActionResult PedidoProntoRetirada(Pedido pedido)
        {
            gerenciador.RetirarPedido(pedido);

            return RedirectToAction("MonitorPedidos");
        }

        public ActionResult PedidoEntregue(Pedido pedido)
        {
            gerenciador.EntregarPedido(pedido);

            return RedirectToAction("MonitorPedidos");
        }
    }
}