using ProjetoPI_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoPI_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Sair()
        {
            Response.Cookies.Remove("IdUsuario");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha)
        {
            try
            {
                Usuarios usuario = AutenticarUsuario(email, senha);
                if (usuario is Ongs)
                {
                    return RedirectToAction("Index", "Ong", new { id = usuario.Id });
                }
                else
                {
                    return RedirectToAction("Doador", "Usuario", new { id = usuario.Id });
                }
            }
            catch (Exception)
            {
                return Redirect(Request.RawUrl);
            }
        }

        [HttpPost]
        public ActionResult NovoSobre()
        {
            ViewBag.Visitante = false;
            return PartialView("../Usuario/_NovoSobre");
        }

        [HttpPost]
        public ActionResult NovoPessoal()
        {
            ViewBag.Visitante = false;
            return PartialView("../Usuario/_NovoPessoal");
        }

        [HttpPost]
        public ActionResult AddSobre(string nomeImagem, string titulo, string texto)
        {
            ProjetoPI_MVCContext bd = new ProjetoPI_MVCContext();
            Usuarios usuario = bd.Usuarios.Find(Convert.ToInt32(Request.Cookies["IdUsuario"].Value.ToString()));
            Sobre sobre = new Sobre() { Imagens = , Titulo = titulo, Texto = texto };
            usuario.Sobre.Add(sobre);
            bd.SaveChanges();
            var novoSobre = new List<Sobre>();
            novoSobre.Add(sobre);
            ViewBag.Visitante = false;
            return PartialView("../Usuario/_Sobre",novoSobre);
        }


        /// <summary>
        /// Salva as alteracoes feitas no banco
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idImagem"></param>
        /// <param name="titulo"></param>
        /// <param name="texto"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddEditSobre(int id, int? idImagem, string titulo, string texto)
        {
            ProjetoPI_MVCContext bd = new ProjetoPI_MVCContext();
            Sobre sobre = bd.Sobre.Find(id);
            sobre.IdImagem = idImagem;
            sobre.Titulo = titulo;
            sobre.Texto = texto;
            bd.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public ActionResult EditSobre(int id)
        {
            ProjetoPI_MVCContext bd = new ProjetoPI_MVCContext();
            Sobre sobre = bd.Sobre.Find(id);
            return PartialView("../Usuario/_EditaSobre", sobre);
        }

        private Usuarios AutenticarUsuario(string email, string senha)
        {
            try
            {
                var usuario = new ProjetoPI_MVCContext().Usuarios.Single(u => u.Email == email && u.Senha == senha);
                HttpCookie cookieUsuario = new HttpCookie("IdUsuario");
                cookieUsuario.Value = usuario.Id.ToString();
                cookieUsuario.Expires.AddHours(1);
                Response.Cookies.Add(cookieUsuario);
                FormsAuthentication.SetAuthCookie(usuario.Email, true);
                return usuario;
            }
            catch (Exception e)
            {
                TempData["ErroLogin"] = "Email ou senha incorreto";
                throw e;
            }
        }
    }
}