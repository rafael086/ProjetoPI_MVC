using ProjetoPI_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoPI_MVC.Controllers
{
    public class OngController : Controller
    {
        private ProjetoPI_MVCContext bd = new ProjetoPI_MVCContext();
        private const string EmAguardo = "Em aguardo";
        private const string Aprovado = "Aprovado";
        private const string Negado = "Negado";

        // GET: Ong
        [HttpGet]
        public ActionResult Index(int id)
        {
            Ongs ong = (Ongs)bd.Usuarios.Find(id);
            //guardo em uma session para persistir os dados
            Session["ong"] = ong;
            try
            {
                ViewBag.Visitante = (Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]) == Convert.ToInt32(Request.Cookies["IdUsuario"].Value.ToString())) ? false : true;
            }
            catch (Exception)
            {
                ViewBag.Visitante = true;
            }
            ViewBag.Doador = false;
            if (User.Identity.IsAuthenticated && bd.Usuarios.Find(Convert.ToInt32(Request.Cookies["IdUsuario"].Value.ToString())) is Doadores)
            {
                ViewBag.Doador = true;
                ConfiguraBotao();
            }
            return View(ong);
        }
     

        [HttpPost]
        public JsonResult Voluntariar()
        {
            Doadores doador = (Doadores)bd.Usuarios.Find(Convert.ToInt32(Request.Cookies["IdUsuario"].Value.ToString()));
            Ongs ong = (Ongs)bd.Usuarios.Find(((Ongs)Session["ong"]).Id);
            Voluntarios voluntario = doador.Voluntarios.SingleOrDefault(v => v.IdOng == ong.Id);
            int i = ConfiguraBotao();
            switch (i)
            {
                case 0:
                    ong.Voluntarios.Add(new Voluntarios { IdDoador = doador.Id });
                    bd.SaveChanges();
                    return Json(1);
                case 1:
                    ong.Voluntarios.Remove(voluntario);
                    bd.SaveChanges();
                    return Json(0);
                default:
                    return Json(i);
            }
        }

        private int ConfiguraBotao()
        {
            Doadores doador = (Doadores)bd.Usuarios.Find(Convert.ToInt32(Request.Cookies["IdUsuario"].Value.ToString()));
            Ongs ong = (Ongs)bd.Usuarios.Find(((Ongs)Session["ong"]).Id);
            Voluntarios voluntario = doador.Voluntarios.SingleOrDefault(v => v.IdOng == ong.Id);
            if (voluntario is null)
            {
                ViewBag.EstiloBotao = "btn btn-block btn-success";
                ViewBag.TextoBotao = "Voluntariar-se a esta ong";
                return 0;
            }
            else if (voluntario.Situacao == EmAguardo)
            {
                ViewBag.EstiloBotao = "btn btn-block btn-warning";
                ViewBag.TextoBotao = "A ong esta analisando seus dados, clique para remover a solicitação";
                return 1;
            }
            else if (voluntario.Situacao == Negado)
            {
                ViewBag.EstiloBotao = "btn btn-block btn-danger";
                ViewBag.TextoBotao = "A ong não aceitou sua solicitacao";
                return 2;
            }
            else
            {
                ViewBag.EstiloBotao = "btn btn-block btn-success";
                ViewBag.TextoBotao = "A ong aceitou sua solicitacao";
                return 3;
            }
        }
    }
}