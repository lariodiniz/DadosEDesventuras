using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DadosEDesventuras.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dados&Desventuras";
            ViewBag.Message = "Ajudando Mestres e jogadores a rolarem seus acertos Cliticos";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "Dados&Desventuras";
            ViewBag.Message = "Ajudando Mestres e jogadores a rolarem seus acertos Cliticos";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contato";
            ViewBag.Message = "Contato.";

            return View();
        }
    }
}