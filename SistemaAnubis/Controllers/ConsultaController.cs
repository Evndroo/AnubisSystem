using SistemaAnubis.Models.BLL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAnubis.Controllers
{
    public class ConsultaController : Controller
    {
        GridView dgv = new GridView();

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

        [HttpPost]
        public ActionResult Cliente(ClienteDTO dto, FormCollection frm)
        {
            return View();
        }

        public ActionResult Funcionario()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Funcionario(FuncionarioDTO dto, FormCollection frm){return View();}

        public ActionResult Administrador(){return View();}

        [HttpPost] 
        public ActionResult Administrador(AdministradorDTO dto, FormCollection frm)
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

        public string CarregaGrid() {
            
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            return sw.ToString();
        }
    }
}