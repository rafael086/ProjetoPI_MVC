using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoPI_MVC.ViewModels;
 
namespace ProjetoPI_MVC.Models
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new ProjetosOngsViewModel());
        }
    }
}