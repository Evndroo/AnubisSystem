using SistemaAnubis.Models.BLL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAnubis.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comprar() {
            PlanoDTO dto = new PlanoDTO();
            PlanoBLL bll = new PlanoBLL();
            CompraDTO compra = new CompraDTO();
            compra.Planos=bll.Consultar(dto);
            return View(compra);
        }

        [HttpPost]
        public ActionResult Comprar(CompraDTO dto) {
            dto.Data = DateTime.Now.Date.ToString().Substring(0,10);
            dto.Cliente = MvcApplication.Session.Instance.Nome;


            return View();
        }
    }
}