using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoPI_MVC.ViewModels;
namespace ProjetoPI_MVC.Controllers
{
    public class BuscaController : Controller
    {
        // GET: Busca
        [HttpGet]
        public ActionResult Index(string busca)
        {
            ViewBag.Busca = busca;
            return View(new ProjetosOngsViewModel(busca));
        }
    }
}