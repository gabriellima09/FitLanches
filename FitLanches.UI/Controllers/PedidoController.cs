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
            return View();
        }

        public ActionResult GerarPedido(IList<Item> itens)
        {
            gerenciador.GerarNovoPedido(itens);

            return View();
        }

        public ActionResult PreparoFinalizado(Pedido pedido)
        {
            gerenciador.FinalizarPreparoPedido(pedido);

            return View();
        }

        public ActionResult PedidoProntoRetirada(Pedido pedido)
        {
            gerenciador.RetirarPedido(pedido);

            return View();
        }

        public ActionResult PedidoEntregue(Pedido pedido)
        {
            gerenciador.EntregarPedido(pedido);

            return View();
        }
    }
}