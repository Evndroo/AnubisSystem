using MySql.Data.MySqlClient;
using SistemaAnubis.Models.BLL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAnubis.Controllers
{
    public class AlterarController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Planos()
        {

            return View();
        }


        //só funcionário ou adm pode fazer
        public ActionResult Cliente()
        {
            ClienteDTO dto = new ClienteDTO();
            dto.Celular = "";
            return View(dto);
        }

        [HttpPost]
        public ActionResult Cliente(ClienteDTO dto, string btn)
        {
            ClienteBLL bll = new ClienteBLL();
            if (btn == "Buscar")
            {
                bll.busUser(dto);
                return View(dto);
            }
            else if (btn == "Salvar")
            {
                bll.atualizar(dto);
                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("index", "Busca", model);
            }
            else if (btn == "Deletar")
            {
                return View();
            }
            else return View();
        }

        public ActionResult Result()
        {
            return View();
        }

        public ActionResult Funcionario()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Funcionario(FuncionarioDTO dto, string btn)
        {
            if (btn == "Buscar")
                return View(dto);
            else if (btn == "Salvar")
            {
                return RedirectToAction("index");
            }
            else return View();
        }

        public ActionResult Administrador() { return View(); }

        [HttpPost]
        public ActionResult Administrador(FuncionarioDTO dto, string btn)
        {
            if (btn == "Buscar")
                return View();
            else if (btn == "Salvar")
            {
                return RedirectToAction("index");
            }
            else return View();
        }

        public ActionResult Urna()
        {
            UrnaBLL bll = new UrnaBLL();
            UrnaDTO dto = new UrnaDTO();
            dto.arrayU = bll.buscar(dto);
            dto.Altura = "";
            dto.Largura = "";
            dto.Profundidade = "";
            dto.Descricao = "";
            dto.Valor = "";
            return View(dto);
        }

        [HttpPost]
        public ActionResult Urna(UrnaDTO dto, string btn)
        {
            if (btn == "Buscar")
            {
                UrnaBLL bll = new UrnaBLL();
                bll.achar(dto);
                dto.arrayU = bll.buscar(dto);
                return View(dto);

            }
            else if (btn == "Salvar")
            {

            }
            else
            { //botão é deletar

            }
            return View();
        }

        public ActionResult ClienteInfo()
        {
            ClienteDTO dto = new ClienteDTO();
            dto.Codigo = MvcApplication.Session.Instance.Codigo;
            dto.User = MvcApplication.Session.Instance.User;
            dto.Senha = MvcApplication.Session.Instance.Senha;
            dto.Nome = MvcApplication.Session.Instance.Nome;
            dto.Cpf = MvcApplication.Session.Instance.Cpf;
            dto.Email = MvcApplication.Session.Instance.Email;
            dto.Telefone = MvcApplication.Session.Instance.Telefone;
            dto.Celular = MvcApplication.Session.Instance.Celular;
            dto.Cep = MvcApplication.Session.Instance.Cep;
            dto.Num = MvcApplication.Session.Instance.Num;
            dto.Nvl = MvcApplication.Session.Instance.Nvl;
            dto.CodUser = MvcApplication.Session.Instance.CodUser;
            return View(dto);
        }

        [HttpPost]
        public ActionResult ClienteInfo(ClienteDTO dto, FormCollection frm)
        {                
            if (Validacoes.IsCpf(dto.Cpf))
            {
                ClienteBLL bll = new ClienteBLL();
                bll.atualizar(dto);

                IndexDTO model = new IndexDTO();
                model.Alert = true;
                MvcApplication.Session.Instance.User = dto.User;
                MvcApplication.Session.Instance.Nome = dto.Nome;
                MvcApplication.Session.Instance.Cpf = dto.Cpf;
                MvcApplication.Session.Instance.Email = dto.Email;
                MvcApplication.Session.Instance.Telefone = dto.Telefone;
                MvcApplication.Session.Instance.Celular = dto.Celular;
                MvcApplication.Session.Instance.Cep = dto.Cep;
                MvcApplication.Session.Instance.Num = dto.Num;
                return RedirectToAction("Index", "Busca", model);

            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('CPF inválido!'); location.href='Administrador'</script>");
            }               
            
        }


        public ActionResult FuncionarioInfo()
        {
            FuncionarioDTO dto = new FuncionarioDTO();
            dto.Codigo = MvcApplication.Session.Instance.Codigo;
            dto.User = MvcApplication.Session.Instance.User;
            dto.Senha = MvcApplication.Session.Instance.Senha;
            dto.Nome = MvcApplication.Session.Instance.Nome;
            dto.Cpf = MvcApplication.Session.Instance.Cpf;
            dto.Email = MvcApplication.Session.Instance.Email;
            dto.Telefone = MvcApplication.Session.Instance.Telefone;
            dto.Celular = MvcApplication.Session.Instance.Celular;
            dto.Cep = MvcApplication.Session.Instance.Cep;
            dto.Num = MvcApplication.Session.Instance.Num;
            dto.Nvl = MvcApplication.Session.Instance.Nvl;
            dto.CodUser = MvcApplication.Session.Instance.CodUser;
            return View(dto);
        }

        [HttpPost]
        public ActionResult FuncionarioInfo(FuncionarioDTO dto)
        {
            if (Validacoes.IsCpf(dto.Cpf))
            {
                FuncionarioBLL bll = new FuncionarioBLL();
                bll.atualizar(dto);

                IndexDTO model = new IndexDTO();
                model.Alert = true;
                MvcApplication.Session.Instance.User = dto.User;
                MvcApplication.Session.Instance.Nome = dto.Nome;
                MvcApplication.Session.Instance.Cpf = dto.Cpf;
                MvcApplication.Session.Instance.Email = dto.Email;
                MvcApplication.Session.Instance.Telefone = dto.Telefone;
                MvcApplication.Session.Instance.Celular = dto.Celular;
                MvcApplication.Session.Instance.Cep = dto.Cep;
                MvcApplication.Session.Instance.Num = dto.Num;
                return RedirectToAction("Index", "Busca", model);

            }
            else
            {
                return View();
            }
        }

        public ActionResult AdministradorInfo()
        {
            AdministradorDTO dto = new AdministradorDTO();
            dto.Codigo = MvcApplication.Session.Instance.Codigo;
            dto.User = MvcApplication.Session.Instance.User;
            dto.Senha = MvcApplication.Session.Instance.Senha;
            dto.Nome = MvcApplication.Session.Instance.Nome;
            dto.Cpf = MvcApplication.Session.Instance.Cpf;
            dto.Email = MvcApplication.Session.Instance.Email;
            dto.Telefone = MvcApplication.Session.Instance.Telefone;
            dto.Celular = MvcApplication.Session.Instance.Celular;
            dto.Cep = MvcApplication.Session.Instance.Cep;
            dto.Num = MvcApplication.Session.Instance.Num;
            dto.Nvl = MvcApplication.Session.Instance.Nvl;
            dto.CodUser = MvcApplication.Session.Instance.CodUser;
            return View(dto);
        }

        [HttpPost]
        public ActionResult AdministradorInfo(AdministradorDTO dto)
        {
            if (Validacoes.IsCpf(dto.Cpf))
            {
                AdministradorBLL bll = new AdministradorBLL();
                bll.atualizar(dto);

                IndexDTO model = new IndexDTO();
                model.Alert = true;
                MvcApplication.Session.Instance.User = dto.User;
                MvcApplication.Session.Instance.Nome = dto.Nome;
                MvcApplication.Session.Instance.Cpf = dto.Cpf;
                MvcApplication.Session.Instance.Email = dto.Email;
                MvcApplication.Session.Instance.Telefone = dto.Telefone;
                MvcApplication.Session.Instance.Celular = dto.Celular;
                MvcApplication.Session.Instance.Cep = dto.Cep;
                MvcApplication.Session.Instance.Num = dto.Num;
                return RedirectToAction("Index", "Busca", model);

            }
            else
            {
                return View();
            }
        }

        public ActionResult MudarSenha() {
            
            return View();
        }

        [HttpPost]
        public ActionResult MudarSenha(LoginDTO dto, FormCollection frm)
        {
            if (frm["Antiga"] == MvcApplication.Session.Instance.Senha)
            {
                if (dto.ConfSenha == dto.Senha)
                {
                    try
                    {
                        ClienteBLL bll = new ClienteBLL();
                        ClienteDTO cli = new ClienteDTO();
                        cli.Senha = dto.Senha;
                        bll.MudarSenha(cli);
                        MvcApplication.Session.Instance.Senha = dto.Senha;
                        IndexDTO model = new IndexDTO();
                        model.Alert = true;
                        return RedirectToAction("Index", "Busca", model);
                    }
                    catch (MySqlException ex)
                    {
                        ViewBag.erro = ex.ToString();
                        return View();
                    }

                }
                else {
                    ViewBag.senha = "A senha e a confirmação não estão iguais";
                    return View();
                }
            }
            else {
                ViewBag.incorreta = "Sua senha está incorreta";
            }
            return View();
        }
    }
}