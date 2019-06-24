using SistemaAnubis.Models.BLL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections;
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
        public ActionResult Index(IndexDTO dto){
            ViewBag.Mensagem = "Bem vindo " + MvcApplication.Session.Instance.Nome + ".";
            if (dto.Alert==false)
            {
                IndexDTO model = new IndexDTO();
                model.Alert = false;
                return View(model);
            }
            else return View(dto);
        }

        public ActionResult Falecido() {
            FalecidoDTO dto = new FalecidoDTO();
            FalecidoBLL bll = new FalecidoBLL();
            if(MvcApplication.Session.Instance.Nvl != "3")
                dto.listaFal = bll.Listar();
            else 
                dto.listaFal = bll.ListarByResp();
            return View(dto);
        }

        [HttpPost]
        public ActionResult Falecido(FalecidoDTO dto)
        {
            FalecidoBLL bll = new FalecidoBLL();
            if (MvcApplication.Session.Instance.Nvl != "3")
                dto.listaFal = bll.Listar();
            else
                dto.listaFal = bll.ListarByResp();
            dto.listaFal = bll.Listar();
            dgv.DataSource = bll.bucaFalNome(dto);

            ViewBag.GridViewString = CarregaGrid().Replace(" 00:00:00","");
            return View(dto);
        }


        public ActionResult Cliente()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Cliente(ClienteDTO dto, FormCollection frm)
        {
            ClienteBLL bll = new ClienteBLL();
            if (dto.Cpf != null)
            {
                dto.Email = dto.Cpf;
                dto.User = dto.Cpf;
                if (Validacoes.isEmail(dto.Email)) //buscando por email
                {
                    dto.Cpf = null;
                    dto.User = null;
                    dgv.DataSource = bll.buscarEmailGrid(dto);
                    ViewBag.GridViewString = CarregaGrid();

                }
                else if (Int64.TryParse(dto.Cpf, out long i))
                {
                    if (Validacoes.IsCpf(dto.Cpf)) //buscando por cpf
                    {
                        dto.Email = null;
                        dto.User = null;
                        dgv.DataSource = bll.buscarCpfGrid(dto);
                        ViewBag.GridViewString = CarregaGrid();
                    }
                    else if (dto.Cpf.Length != 11)
                    { //Usuário numérico
                        dto.Email = "";
                        dto.Cpf = "";
                        dgv.DataSource = bll.buscarUserGrid(dto);
                        ViewBag.GridViewString = CarregaGrid();
                    }
                    else
                    {
                        //CPF inválido
                        ViewBag.GridViewString = "Cpf Inválido";
                    }
                }
                else //tentou buscar com o user
                {
                    dto.Cpf = null;
                    dto.Email = null;
                    dgv.DataSource = bll.buscarUserGrid(dto);
                    ViewBag.GridViewString = CarregaGrid();
                }
            }
            return View();
        }

            
        

        public ActionResult Funcionario()
        {

            return View();
        }

        
        [HttpPost]
        public ActionResult Funcionario(FuncionarioDTO dto)
        {
            FuncionarioBLL bll = new FuncionarioBLL();
            dto.Email = dto.Cpf;
            dto.User = dto.Cpf;

            if (Validacoes.isEmail(dto.Email)) //buscando por email
            {
                dto.Cpf = null;
                dto.User = null;
                dgv.DataSource = bll.buscarEmailGrid(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            else if (Int64.TryParse(dto.Cpf, out long i))
            {
                if (Validacoes.IsCpf(dto.Cpf)) //buscando por cpf
                {
                    dto.Email = null;
                    dto.User = null;
                    dgv.DataSource = bll.buscarCpfGrid(dto);
                    ViewBag.GridViewString = CarregaGrid();
                }
                else if (dto.Cpf.Length == 11)
                {             //CPF inválido
                    ViewBag.GridViewString = "Cpf Inválido";
                }
                else
                {
                    //Usuário numérico
                    dto.Email = "";
                    dto.Cpf = "";
                    dgv.DataSource = bll.buscarUserGrid(dto);
                    ViewBag.GridViewString = CarregaGrid();
                }
            }
            else //tentou buscar com o user
            {
                dto.Cpf = null;
                dto.Email = null;
                dgv.DataSource = bll.buscarUserGrid(dto);
                ViewBag.GridViewString = CarregaGrid();

            }
            return View();           
        }
        

        public ActionResult Administrador()
        {

            return View();
        }

        public ActionResult Result()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Administrador(AdministradorDTO dto)
        {
            AdministradorBLL bll = new AdministradorBLL();
            dto.Email = dto.Cpf;
            dto.User = dto.Cpf;
            if (Validacoes.isEmail(dto.Email)) //buscando por email
            {
                dto.Cpf = null;
                dto.User = null;
                dgv.DataSource = bll.buscarEmailGrid(dto);
                ViewBag.GridViewString = CarregaGrid();

            }
            else if (Int64.TryParse(dto.Cpf, out long i))
            {
                if (Validacoes.IsCpf(dto.Cpf)) //buscando por cpf
                {
                    dto.Email = null;
                    dto.User = null;
                    dgv.DataSource = bll.buscarCpfGrid(dto);
                    ViewBag.GridViewString = CarregaGrid();
                }
                else if (dto.Cpf.Length != 11)
                { //Usuário numérico
                    dto.Email = "";
                    dto.Cpf = "";
                    dgv.DataSource = bll.buscarUserGrid(dto);
                    ViewBag.GridViewString = CarregaGrid();
                }
                else
                {
                    //CPF inválido
                    ViewBag.GridViewString = "Cpf Inválido";
                }
            }
            else //tentou buscar com o user
            {
                dto.Cpf = null;
                dto.Email = null;
                dgv.DataSource = bll.buscarUserGrid(dto);
                ViewBag.GridViewString = CarregaGrid();
            }
            return View();
        }


        public ActionResult Caixao() {
            CaixaoBLL bll = new CaixaoBLL();
            CaixaoDTO dto = new CaixaoDTO();
            dto.arrayC = bll.buscar(dto);
            return View(dto);
        }

        [HttpPost]
        public ActionResult Caixao(CaixaoDTO dto) {
            CaixaoBLL bll = new CaixaoBLL();
            dto.arrayC = bll.buscar(dto);
            dgv.DataSource = bll.BusscarGrid(dto);
        
            ViewBag.GridViewString = CarregaGrid();
            CarregaGrid();
            return View(dto);
        }


        public ActionResult Urna() {
            UrnaBLL bll = new UrnaBLL();
            UrnaDTO dto = new UrnaDTO();
            dto.arrayU = bll.buscar(dto);
            return View(dto);
        }

        [HttpPost]
        public ActionResult Urna(UrnaDTO dto, string btn) {           
            UrnaBLL bll = new UrnaBLL();
            dto.arrayU = bll.buscar(dto);
            dgv.DataSource =  bll.BuscarUrnaGrid(dto);
            ViewBag.GridViewString = CarregaGrid();            
            return View(dto);
        }



        public ActionResult Plano() {
            PlanoBLL bll = new PlanoBLL(); 
            PlanoDTO dto = new PlanoDTO();
            dto.arrayP = bll.Consultar(dto);
            return View(dto);
        }

        [HttpPost]
        public ActionResult Plano(PlanoDTO dto) {
            PlanoBLL bll = new PlanoBLL();
            dto.arrayP = bll.Consultar(dto);
            dgv.DataSource = bll.buscarG(dto);
            ViewBag.GridViewString = CarregaGrid();
            return View(dto);
        }


        public ActionResult Flores() {
            FloresBLL bll = new FloresBLL();
            FloresDTO dto = new FloresDTO();
            dto.arrayF = bll.Consultar(dto);
            return View(dto);
        }

        [HttpPost]
        public ActionResult Flores(FloresDTO dto) {
            FloresBLL bll = new FloresBLL();
            dto.arrayF = bll.Consultar(dto);
            dgv.DataSource= bll.buscarG(dto);
            ViewBag.GridViewString = CarregaGrid();
            return View(dto);
        }


        public ActionResult Coroa() {
            CoroaBLL bll = new CoroaBLL();
            CoroaDTO dto = new CoroaDTO();
            dto.arrayCO = bll.Consultar(dto);
            return View(dto);
        }

        [HttpPost]
        public ActionResult Coroa(CoroaDTO dto) {
            CoroaBLL bll = new CoroaBLL();
            dto.arrayCO = bll.Consultar(dto);
            dgv.DataSource = bll.busCoroaGrid(dto);
            ViewBag.GridViewString = CarregaGrid();
            return View(dto);
        }


        public string CarregaGrid()
        {
            dgv.CssClass = "table table-hover table-bordered mx-auto col-6";
            dgv.ID = "tabela-principal";            
            dgv.UseAccessibleHeader = true;
            dgv.HorizontalAlign = HorizontalAlign.Center;
            if (dgv.DataSource != null)
                dgv.DataBound += (object o, EventArgs ev) =>
                {
                    dgv.HeaderRow.TableSection = TableRowSection.TableHeader;

                };
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            
            dgv.RenderControl(htw);
            if (dgv.Rows.Count >= 1) {
                
                return sw.ToString();
            }
            else return "Nenhum dado foi encontrado";
        }


    }
}