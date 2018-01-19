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
        [HttpGet]
        public ActionResult Ong(int id)
        {
            return View((Ongs)new ProjetoPI_MVCContext().Usuarios.Find(id));
        }

        [HttpGet]
        public ActionResult Doador(int id)
        {
            return View((Doadores)new ProjetoPI_MVCContext().Usuarios.Find(id));
        }

        public ActionResult Sair()
        {
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
                    return RedirectToAction("Ong", "Usuario", new { id = usuario.Id });
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
        private Usuarios AutenticarUsuario(string email, string senha)
        {
            try
            {
                var usuario = new ProjetoPI_MVCContext().Usuarios.Single(u => u.Email == email && u.Senha == senha);
                HttpCookie cookieUsuario = new HttpCookie("AutenticacaoUsuario");
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