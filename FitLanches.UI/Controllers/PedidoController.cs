using FitLanches.BLL.Models;
using FitLanches.Dominio.Enums;
using FitLanches.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            IList<Pedido> pedidos = gerenciador.SelecionarTodos();

            return View(pedidos);
        }

        public ActionResult MonitorPedidos(IList<Pedido> pedidos)
        {
            if (pedidos is null || pedidos.Count == 0)
            {
                pedidos = gerenciador.SelecionarTodos();
            }

            return PartialView(pedidos);
        }

        [HttpPost]
        public ActionResult GerenciarPedidos(IList<Pedido> pedidos)
        {
            IList<Pedido> lista = gerenciador.GerenciarPedidos(pedidos);

            return PartialView("MonitorPedidos", lista);
        }

        [ValidateAntiForgeryToken]
        public ActionResult GerarPedido(IList<ItensPedido> itens)
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