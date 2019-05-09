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
    public class BuscaController : Controller
    {
        GridView dgv = new GridView();

        // GET: Busca
        public ActionResult Index(){return View();}

        public ActionResult Cliente()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Cliente(ClienteDTO dto, FormCollection frm)
        {


            if (frm["busca"] == "Usuário")
            {
                dgv.DataSource = new ClienteBLL().buscarUser(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (frm["busca"] == "CPF")
            {
                dgv.DataSource = new ClienteBLL().buscarCpf(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (frm["busca"] == "E-mail")
            {
                dgv.DataSource = new ClienteBLL().buscarEmail(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else
            {
                ViewBag.GridViewString = "Escolha uma maneira de consulta";
            }

            return View();
        }

        public ActionResult Funcionario()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Funcionario(FuncionarioDTO dto, FormCollection frm)
        {


            if (frm["busca"] == "Usuário")
            {
                dgv.DataSource = new FuncionarioBLL().buscarUser(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (frm["busca"] == "CPF")
            {
                dgv.DataSource = new FuncionarioBLL().buscarCpf(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (frm["busca"] == "E-mail")
            {
                dgv.DataSource = new FuncionarioBLL().buscarEmail(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else
            {
                ViewBag.GridViewString = "Escolha uma maneira de consulta";
            }

            return View();
        }

        public ActionResult Administrador()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Administrador(AdministradorDTO dto, FormCollection frm)
        {


            if (frm["busca"] == "Usuário")
            {
                dgv.DataSource = new AdministradorBLL().buscarNome(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (frm["busca"] == "CPF")
            {
                dgv.DataSource = new AdministradorBLL().buscarCpf(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (frm["busca"] == "E-mail")
            {
                dgv.DataSource = new AdministradorBLL().buscarEmail(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else
            {
                ViewBag.GridViewString = "Escolha uma maneira de consulta";
            }

            return View();
        }


        public ActionResult Caixao() { return View(); }

        public ActionResult Urna() { return View(); }

        public ActionResult Plano() { return View(); }

        public ActionResult Flores() { return View(); }

        public ActionResult Coroa() { return View(); }


        public string CarregaGrid()
        {
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            return sw.ToString();
        }

    }
}