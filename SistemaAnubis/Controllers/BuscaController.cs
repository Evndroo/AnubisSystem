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
        public ActionResult Index(){
            ViewBag.Mensagem = "Bem vindo " + Logado.Nome + ".";
            return View();
        }

        public ActionResult Cliente()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Cliente(ClienteDTO dto, FormCollection frm)
        {


            if (frm["busca"] == "Usuário")
            {
                new ClienteBLL().buscarUser(dto);
                return RedirectToAction("Index");
            }
            else if (frm["busca"] == "CPF")
            {
                new ClienteBLL().buscarCpf(dto);
                return RedirectToAction("Index");
            }
            else if (frm["busca"] == "E-mail")
            {
                new ClienteBLL().buscarEmail(dto);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.erro = "Escolha uma maneira de consulta";
                return View();
            }

            
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
                new FuncionarioBLL().buscarUser(dto);
                return RedirectToAction("Index");

            }
            else if (frm["busca"] == "CPF")
            {
                new FuncionarioBLL().buscarCpf(dto);
                ViewBag.GridViewString = CarregaGrid();
                return RedirectToAction("Index");
            }
            else if (frm["busca"] == "E-mail")
            {
                new FuncionarioBLL().buscarEmail(dto);
                ViewBag.GridViewString = CarregaGrid();
                return RedirectToAction("Index");
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
                new AdministradorBLL().buscarNome(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (frm["busca"] == "CPF")
            {
                new AdministradorBLL().buscarCpf(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (frm["busca"] == "E-mail")
            {/*
                dgv.DataSource = new AdministradorBLL().buscarEmail(dto);
                ViewBag.GridViewString = CarregaGrid();*/
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