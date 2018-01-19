using ProjetoPI_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoPI_MVC.Controllers
{
    public class CategoriaController : Controller
    {
        private const int ItensPorPagina = 3;
        // GET: Categoria
        public ActionResult Ongs()
        {
            return View(new ProjetoPI_MVCContext().Usuarios.OfType<Ongs>().OrderByDescending(o => o.Id).Skip(0).Take(ItensPorPagina).ToList());
        }

        public ActionResult Projetos()
        {
            return View(new ProjetoPI_MVCContext().Projetos.OrderByDescending(p => p.Id).Skip(0).Take(ItensPorPagina).ToList());
        }
    }
}