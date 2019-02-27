using FitLanches.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitLanches.UI.Controllers
{
    public class CardapioController : Controller
    {
        // GET: Cardapio
        public ActionResult Index()
        {
            return View(new Cardapio());
        }
    }
}