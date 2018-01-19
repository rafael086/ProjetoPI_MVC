using ProjetoPI_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoPI_MVC.Controllers
{
    public class FormularioController : Controller
    {
        // GET: Formulario
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                ProjetoPI_MVCContext bd = new ProjetoPI_MVCContext();
                bd.Usuarios.Add(usuario);
                bd.SaveChanges();
            }
            return View();
        }
                
    }
}