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
            PlanoBLL bll = new PlanoBLL();
            List<PlanoDTO> plano = new List<PlanoDTO>();
            plano = bll.Listar();
            return View(plano);
        }


        //só funcionário ou adm pode fazer
        public ActionResult Cliente()
        {
            ClienteBLL bll = new ClienteBLL();
            List<ClienteDTO> cli = new List<ClienteDTO>();
            cli = bll.Listar();
            return View(cli);
        }

        public ActionResult Funcionario()
        {
            FuncionarioBLL bll = new FuncionarioBLL();
            List<FuncionarioDTO> func = new List<FuncionarioDTO>();
            func = bll.Listar();
            return View(func);
        }
        

        public ActionResult Administrador(){
            AdministradorBLL bll = new AdministradorBLL();
            List<AdministradorDTO> adm = new List<AdministradorDTO>();
            adm = bll.listar();
            return View(adm);
        }
    }
}