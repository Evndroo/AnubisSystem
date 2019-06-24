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
            FuncionarioBLL funcActions = new FuncionarioBLL();
            ClienteBLL bllCli = new ClienteBLL();
            FalecidoBLL falecido = new FalecidoBLL();
            CompraDTO compra = new CompraDTO();
            compra.Funcionarios = funcActions.Listar();
            compra.Falecidos = falecido.Listar();
            compra.Clientes = bllCli.Listar();
            compra.Planos = bll.Consultar(dto);
            return View(compra);
        }

        [HttpPost]
        public ActionResult Comprar(CompraDTO dto) {
            dto.Data = DateTime.Now.ToString("yyyy-MM-dd");
            if (MvcApplication.Session.Instance.Nvl == "3") dto.Cliente = MvcApplication.Session.Instance.User;
            if (MvcApplication.Session.Instance.Nvl == "2") dto.Vendedor = MvcApplication.Session.Instance.Nome;

            CompraBLL bll = new CompraBLL();
            try
            {
                bll.inserir(dto);
                IndexDTO model = new IndexDTO();
                model.Alert = true;
                model.Compra = true;
                return RedirectToAction("Index", "Busca", model);
            }
            catch(Exception ex) {
                CompraDTO compra = new CompraDTO();
                PlanoDTO dtoP = new PlanoDTO();
                PlanoBLL bllP = new PlanoBLL();
                FuncionarioBLL funcActions = new FuncionarioBLL();
                ClienteBLL bllCli = new ClienteBLL();
                FalecidoBLL falecido = new FalecidoBLL();
                compra.Funcionarios = funcActions.Listar();
                compra.Falecidos = falecido.Listar();
                compra.Clientes = bllCli.Listar();
                compra.Planos = bllP.Consultar(dtoP);
                compra.erro = true;
                ViewBag.erro = "Uma compra já foi efetuada nestas condições";
                return View(compra);
            }
        }
    }
}