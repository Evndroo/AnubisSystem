﻿using MySql.Data.MySqlClient;
using SistemaAnubis.Models.BLL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAnubis.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Administrador() {
            return View();
        }

        [HttpPost]
        public ActionResult Administrador(AdministradorDTO dto)
        {
            if  (dto.ConfSenha.Equals(dto.Senha)) {
                if (Validacoes.IsCpf(dto.Cpf))
                {
                    AdministradorBLL bll = new AdministradorBLL();
                    bll.inserir(dto);
                    if (dto.erro == "1")
                    {
                        ViewBag.erro = "Este usuário já existe";
                        return View();
                    }
                    else if (dto.erro == "2")
                    {
                        ViewBag.erro2 = "Cpf já cadastrado";
                        return View();
                    }
                    else if (dto.erro == "3")
                    {
                        ViewBag.erro3 = "Email já cadastrado.";
                        return View();
                    }
                    else
                    {
                        IndexDTO model = new IndexDTO();
                        model.Alert = true;
                        if (MvcApplication.Session.Instance.Codigo != null)
                        {
                            return RedirectToAction("Index", "Busca", model);
                        }
                        else
                        {
                            MvcApplication.Session.Instance.Codigo = dto.Codigo;
                            MvcApplication.Session.Instance.User = dto.User;
                            MvcApplication.Session.Instance.Senha = dto.Senha;
                            MvcApplication.Session.Instance.Nome = dto.Nome;
                            MvcApplication.Session.Instance.Cpf = dto.Cpf;
                            MvcApplication.Session.Instance.Email = dto.Email;
                            MvcApplication.Session.Instance.Telefone = dto.Telefone;
                            MvcApplication.Session.Instance.Celular = dto.Celular;
                            MvcApplication.Session.Instance.Cep = dto.Cep;
                            MvcApplication.Session.Instance.Num = dto.Num;
                            MvcApplication.Session.Instance.Nvl = dto.Nvl;
                            MvcApplication.Session.Instance.CodUser = dto.CodUser;
                            return RedirectToAction("Index", "Busca", model);
                        }
                    }
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('CPF inválido!'); location.href='Administrador'</script>");
                }
            }
            else {
                ViewBag.erro4 = "Senha e confirmação se divergem";
                return View();
            }
        }




        public ActionResult Cliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cliente(ClienteDTO dto)
        {
            if (dto.ConfSenha.Equals(dto.Senha))
            {
                if (Validacoes.IsCpf(dto.Cpf))
                {
                    ClienteBLL bll = new ClienteBLL();
                    bll.inserir(dto);
                    if (dto.erro == "1")
                    {
                        ViewBag.erro = "Este usuário já existe";
                        return View();
                    }
                    else if (dto.erro == "2")
                    {
                        ViewBag.erro2 = "Cpf já cadastrado";
                        return View();
                    }
                    else if (dto.erro == "3")
                    {
                        ViewBag.erro3 = "Email já cadastrado.";
                        return View();
                    }
                    else
                    {
                        IndexDTO model = new IndexDTO();
                        model.Alert = true;
                        if (MvcApplication.Session.Instance.Codigo != null)
                        {
                            return RedirectToAction("Index", "Busca", model);
                        }
                        else {
                            MvcApplication.Session.Instance.Codigo = dto.Codigo;
                            MvcApplication.Session.Instance.User = dto.User;
                            MvcApplication.Session.Instance.Senha = dto.Senha;
                            MvcApplication.Session.Instance.Nome = dto.Nome;
                            MvcApplication.Session.Instance.Cpf = dto.Cpf;
                            MvcApplication.Session.Instance.Email = dto.Email;
                            MvcApplication.Session.Instance.Telefone = dto.Telefone;
                            MvcApplication.Session.Instance.Celular = dto.Celular;
                            MvcApplication.Session.Instance.Cep = dto.Cep;
                            MvcApplication.Session.Instance.Num = dto.Num;
                            MvcApplication.Session.Instance.Nvl = dto.Nvl;
                            MvcApplication.Session.Instance.CodUser = dto.CodUser;
                            return RedirectToAction("Index", "Busca",model);
                        }
                    }
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('CPF inválido!'); location.href='Administrador'</script>");
                }
            }
            else
            {
                ViewBag.erro4 = "Senha e confirmação se divergem";
                return View();
            }
        }



        public ActionResult Funcionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Funcionario(FuncionarioDTO dto)
        {
            if (dto.ConfSenha.Equals(dto.Senha))
            {
                if (Validacoes.IsCpf(dto.Cpf))
                {
                    FuncionarioBLL bll = new FuncionarioBLL();
                    bll.inserir(dto);
                    if (dto.erro == "1")
                    {
                        ViewBag.erro = "Este usuário já existe";
                        return View();
                    }
                    else if (dto.erro == "2")
                    {
                        ViewBag.erro2 = "Cpf já cadastrado";
                        return View();
                    }
                    else if (dto.erro == "3")
                    {
                        ViewBag.erro3 = "Email já cadastrado.";
                        return View();
                    }
                    else
                    {
                        IndexDTO model = new IndexDTO();
                        model.Alert = true;
                        if (MvcApplication.Session.Instance.Codigo != null)
                        {
                            return RedirectToAction("Index", "Busca", model);
                        }
                        else
                        {
                            MvcApplication.Session.Instance.Codigo = dto.Codigo;
                            MvcApplication.Session.Instance.User = dto.User;
                            MvcApplication.Session.Instance.Senha = dto.Senha;
                            MvcApplication.Session.Instance.Nome = dto.Nome;
                            MvcApplication.Session.Instance.Cpf = dto.Cpf;
                            MvcApplication.Session.Instance.Email = dto.Email;
                            MvcApplication.Session.Instance.Telefone = dto.Telefone;
                            MvcApplication.Session.Instance.Celular = dto.Celular;
                            MvcApplication.Session.Instance.Cep = dto.Cep;
                            MvcApplication.Session.Instance.Num = dto.Num;
                            MvcApplication.Session.Instance.Nvl = dto.Nvl;
                            MvcApplication.Session.Instance.CodUser = dto.CodUser;
                            return RedirectToAction("Index", "Busca", model);
                        }
                    }
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('CPF inválido!'); location.href='Administrador'</script>");
                }
            }
            else
            {
                ViewBag.erro4 = "Senha e confirmação se divergem";
                return View();
            }

        }

        public ActionResult Falecido()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Falecido(FalecidoDTO dto)
        {
            FalecidoBLL bll = new FalecidoBLL();
            bll.inserir(dto);
            IndexDTO model = new IndexDTO();
            model.Alert = true;
            return RedirectToAction("Index", "Busca", model);

        }



        public ActionResult Caixao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Caixao(CaixaoDTO dto)
        {
            CaixaoBLL bll = new CaixaoBLL();
            IndexDTO model = new IndexDTO();
            model.Alert = true;
            if (bll.inserir(dto))
            {
                return RedirectToAction("Index", "Busca",model);
            }
            return View();
        }
        

        public ActionResult Coroa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Coroa(CoroaDTO dto)
        {
            CoroaBLL bll = new CoroaBLL();

            IndexDTO model = new IndexDTO();
            model.Alert = true;
            if (bll.inserir(dto)) return RedirectToAction("Index", "Busca",model);
            else return View();
        }


        public ActionResult Flores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Flores(FloresDTO dto)
        {
            
            FloresBLL bll = new FloresBLL();
            if (bll.inserir(dto)) {
                return RedirectToAction("Index","Busca");
            }else
                return View();
            
        }


        public ActionResult Urna()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Urna(UrnaDTO dto)
        {

            UrnaBLL bll = new UrnaBLL();
            if (bll.inserir(dto)) {
                return RedirectToAction("Index", "Busca");
            }
            return View();

        }




        public ActionResult Plano()
        {
            CaixaoBLL bllC = new CaixaoBLL();
            UrnaBLL bllU = new UrnaBLL();
            CoroaBLL bllCO = new CoroaBLL();
            FloresBLL bllF = new FloresBLL();
            CaixaoDTO dtoC = new CaixaoDTO();
            UrnaDTO dtoU = new UrnaDTO();
            CoroaDTO dtoCO = new CoroaDTO();
            FloresDTO dtoF = new FloresDTO();
            PlanoDTO dtoP = new PlanoDTO();
            dtoP.arrayU = bllU.buscar(dtoU);
            dtoP.arrayC = bllC.buscar(dtoC);
            dtoP.arrayCO = bllCO.Consultar(dtoCO);
            dtoP.arrayF = bllF.Consultar(dtoF);
            return View(dtoP);
        }

        [HttpPost]
        public ActionResult Plano(PlanoDTO dto)
            {
            PlanoBLL bll = new PlanoBLL();

            try
            {
                bll.inserir(dto);
                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("Index", "Busca", model);
                
            }
            catch(Exception ex)
            {
                ViewBag.Erro = ex.ToString();
                return View(new PlanoDTO());
            }
        }



        public ActionResult Compra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Compra(CompraDTO dto)
        {
            try
            {
                CompraBLL bll = new CompraBLL();
                bll.inserir(dto);
                IndexDTO model = new IndexDTO();
                model.Compra = true;
                return RedirectToAction("Index", "Busca", model);
            }
            catch
            {
                return View();
            }
        }
    }
}