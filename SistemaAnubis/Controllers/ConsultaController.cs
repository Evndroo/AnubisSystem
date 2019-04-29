using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAnubis.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Planos() {

            return View();
        }


        //só funcionário ou adm pode fazer
        public ActionResult Cliente()
        {

            return View();
        }

        public ActionResult Funcionario()
        {

            return View();
        }

        public ActionResult Administrador()
        {

            return View();
        }


        public ActionResult Urna()
        {

            return View();
        }

        public ActionResult Caixao()
        {

            return View();
        }

        public ActionResult Flores()
        {

            return View();
        }

        public ActionResult Coroa()
        {

            return View();
        }
    }
}