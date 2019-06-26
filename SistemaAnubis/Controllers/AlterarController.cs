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
            PlanoDTO dto = new PlanoDTO();
            dto.arrayP = new PlanoBLL().Listar();
            dto.arrayF = new FloresBLL().Consultar(new FloresDTO());
            dto.arrayCO = new CoroaBLL().Consultar(new CoroaDTO());
            dto.arrayC = new CaixaoBLL().buscar(new CaixaoDTO());
            dto.arrayU = new UrnaBLL().buscar(new UrnaDTO());
            dto.Caixao = " ";
            dto.Urna = " ";
            dto.Coroa = " ";
            dto.Flor = " ";
            return View(dto);
        }

        [HttpPost]
        public ActionResult Planos(PlanoDTO dto, string btn, FormCollection frm)
        {
            PlanoBLL bll = new PlanoBLL();
            if (btn == "Buscar")
            {
                dto = bll.buscar(dto);
                dto.arrayP = new PlanoBLL().Listar();
                dto.arrayF = new FloresBLL().Consultar(new FloresDTO());
                dto.arrayCO = new CoroaBLL().Consultar(new CoroaDTO());
                dto.arrayC = new CaixaoBLL().buscar(new CaixaoDTO());
                dto.arrayU = new UrnaBLL().buscar(new UrnaDTO());
                PlanoDTO.Antigo = dto.Nome;
                return View(dto);

            }
            else if (btn == "Salvar")
            {
                string veu = frm["Véu"];
                string lapide = frm["Lap"];
                string necromaquiagem = frm["necro"];
                string translado = frm["Transl"];
                string paramentacao = frm["Paramentação"];

                if (veu != null) dto.Veu = 1;
                else dto.Veu = 0;

                if (lapide != null) dto.Lapide = 1;
                else dto.Lapide = 0;

                if (necromaquiagem != null) dto.Necromaquiagem = 1;
                else dto.Necromaquiagem = 0;

                if (translado != null) dto.Translado = 1;
                else dto.Translado = 0;

                if (paramentacao != null) dto.Paramentacao = 1;
                else dto.Paramentacao = 0;
                bll.atualizar(dto);
                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("index", "Busca", model);
            }
            else
            {
                try
                {
                    bll.deletar(dto);
                    IndexDTO model = new IndexDTO();
                    model.delete = true;
                    return RedirectToAction("Index", "Busca", model);
                }
                catch {
                    ViewBag.delete = "Erro ao deletar";
                    return View();
                }
            }
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
                dto.Email = dto.User;
                dto.Cpf = dto.User;
                if (Int64.TryParse(dto.Cpf, out long i))
                {
                    if (Validacoes.IsCpf(dto.Cpf)) //buscando por cpf
                    {
                        dto.Email = null;
                        dto.User = null;
                        bll.buscarCpf(dto);
                    }
                    else if (dto.Cpf.Length != 11)
                    { //Usuário numérico
                        dto.Email = null;
                        dto.Cpf = null;
                        bll.buscarUser(dto);
                    }
                    else
                    {
                        //CPF inválido
                        ViewBag.erro = "Cpf Inválido";
                    }
                }
                else if (Validacoes.isEmail(dto.Email)) //buscando por email
                {
                    dto.Cpf = null;
                    dto.User = null;
                    bll.buscarEmail(dto);

                }
                else
                {
                    dto.Email = null;
                    dto.Cpf = null;
                    bll.buscarUser(dto);
                }
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
                try
                {
                    bll.deletar(dto);
                    IndexDTO model = new IndexDTO();
                    model.delete = true;
                    return RedirectToAction("Index", "Busca", model);
                }
                catch
                {
                    ViewBag.delete = "Erro ao deletar";
                    return View();
                }

            }
            else return View();
        }

        public ActionResult Result()
        {
            return View();
        }

        public ActionResult Funcionario()
        {
            FuncionarioDTO dto = new FuncionarioDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult Funcionario(FuncionarioDTO dto, string btn)
        {
            FuncionarioBLL bll = new FuncionarioBLL();
            if (btn == "Buscar")
            {
                dto.Email = dto.User;
                dto.Cpf = dto.User;
                if (Int64.TryParse(dto.Cpf, out long i))
                {
                    if (Validacoes.IsCpf(dto.Cpf)) //buscando por cpf
                    {
                        dto.Email = null;
                        dto.User = null;
                        bll.buscarCpf(dto);
                    }
                    else if (dto.Cpf.Length != 11)
                    { //Usuário numérico
                        dto.Email = null;
                        dto.Cpf = null;
                        bll.buscarUser(dto);
                    }
                    else
                    {
                        //CPF inválido
                        ViewBag.erro = "Cpf Inválido";
                    }
                }
                else if (Validacoes.isEmail(dto.Email)) //buscando por email
                {
                    dto.Cpf = null;
                    dto.User = null;
                    bll.buscarEmail(dto);

                }
                else
                {
                    dto.Email = null;
                    dto.Cpf = null;
                    bll.buscarUser(dto);
                }
                return View(dto);
            }
            else if (btn == "Salvar")
            {
                bll.alterar(dto);
                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("index", "Busca", model);
            }
            else {
                try
                {
                    bll.deletar(dto);
                    IndexDTO model = new IndexDTO();
                    model.delete = true;
                    return RedirectToAction("Index", "Busca", model);
                }
                catch
                {
                    ViewBag.delete = "Erro ao deletar";
                    return View();
                }
            }
        }

        public ActionResult Administrador()
        {
            AdministradorDTO dto = new AdministradorDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult Administrador(AdministradorDTO dto, string btn)
        {
            AdministradorBLL bll = new AdministradorBLL();
            if (btn == "Buscar")
            {
                dto.Email = dto.User;
                dto.Cpf = dto.User;
                if (Int64.TryParse(dto.Cpf, out long i))
                {
                    if (Validacoes.IsCpf(dto.Cpf)) //buscando por cpf
                    {
                        dto.Email = null;
                        dto.User = null;
                        bll.buscarCpf(dto);
                    }
                    else if (dto.Cpf.Length != 11)
                    { //Usuário numérico
                        dto.Email = null;
                        dto.Cpf = null;
                        bll.buscarUser(dto);
                    }
                    else
                    {
                        //CPF inválido
                        ViewBag.erro = "Cpf Inválido";
                    }
                }
                else if (Validacoes.isEmail(dto.Email)) //buscando por email
                {
                    dto.Cpf = null;
                    dto.User = null;
                    bll.buscarEmail(dto);

                }
                else
                {
                    dto.Email = null;
                    dto.Cpf = null;
                    bll.buscarUser(dto);
                }
                return View(dto);
            }
            else if (btn == "Salvar")
            {
                bll.alterar(dto);
                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("index", "Busca", model);
            }
            else {
                try
                {
                    bll.deletar(dto);
                    IndexDTO model = new IndexDTO();
                    model.delete = true;
                    return RedirectToAction("Index", "Busca", model);
                }
                catch
                {
                    ViewBag.delete = "Erro ao deletar";
                    return View();
                }
            }
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
            UrnaBLL bll = new UrnaBLL();
            if (btn == "Buscar")
            {
                bll.achar(dto);
                dto.Altura = dto.Altura.Replace(',', '.');
                dto.Largura = dto.Largura.Replace(',', '.');
                dto.Profundidade = dto.Profundidade.Replace(',', '.');
                dto.Valor = dto.Valor.Replace(',', '.');
                UrnaDTO.Antiga = dto.Nome;
                dto.arrayU = bll.buscar(dto);
                return View(dto);

            }
            else if (btn == "Salvar")
            {
                bll.atualizar(dto);

                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("index", "Busca", model);
            }
            else
            { //botão é deletar
                try
                {
                    bll.deletar(dto);
                    IndexDTO model = new IndexDTO();
                    model.delete = true;
                    return RedirectToAction("Index", "Busca", model);
                }
                catch
                {
                    ViewBag.delete = "Erro ao deletar";
                    return View();
                }
            }
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
                bll.alterar(dto);

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
                bll.alterar(dto);

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

        public ActionResult MudarSenha()
        {

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
                else
                {
                    ViewBag.senha = "A senha e a confirmação não estão iguais";
                    return View();
                }
            }
            else
            {
                ViewBag.incorreta = "Sua senha está incorreta";
            }
            return View();
        }

        public ActionResult Caixao()
        {
            CaixaoBLL bll = new CaixaoBLL();
            CaixaoDTO dto = new CaixaoDTO();
            dto.arrayC = bll.buscar(dto);
            dto.Altura = "";
            dto.Largura = "";
            dto.Profundidade = "";
            dto.Descricao = "";
            dto.Valor = "";
            return View(dto);
        }

        [HttpPost]
        public ActionResult Caixao(CaixaoDTO dto, string btn)
        {
            CaixaoBLL bll = new CaixaoBLL();
            if (btn == "Buscar")
            {
                bll.buscarModelo(dto);
                dto.Altura = dto.Altura.Replace(',', '.');
                dto.Largura = dto.Largura.Replace(',', '.');
                dto.Profundidade = dto.Profundidade.Replace(',', '.');
                dto.Valor = dto.Valor.Replace(',', '.');
                dto.arrayC = bll.buscar(dto);
                return View(dto);

            }
            else if (btn == "Salvar")
            {
                bll.atualizar(dto);

                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("index", "Busca", model);
            }
            else
            { //botão é deletar
                try
                {
                    bll.deletar(dto);
                    IndexDTO model = new IndexDTO();
                    model.delete = true;
                    return RedirectToAction("Index", "Busca", model);
                }
                catch
                {
                    ViewBag.delete = "Erro ao deletar";
                    return View();
                }
            }
        }

        public ActionResult Flores()
        {
            FloresBLL bll = new FloresBLL();
            FloresDTO dto = new FloresDTO();
            dto.arrayF = bll.Consultar(dto);
            dto.Especie = "";
            dto.Quantidade = "";
            dto.Tipo = "";
            dto.Valor = "";
            return View(dto);
        }

        [HttpPost]
        public ActionResult Flores(FloresDTO dto, string btn)
        {
            FloresBLL bll = new FloresBLL();
            if (btn == "Buscar")
            {
                dto.arrayF = bll.Consultar(dto);
                bll.buscar(dto);
                dto.Valor = dto.Valor.Replace(",", ".");
                return View(dto);

            }
            else if (btn == "Salvar")
            {
                dto.arrayF = bll.Consultar(dto);
                bll.atualizar(dto);
                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("index", "Busca", model);
            }
            else
            { //botão é deletar
                try
                {
                    bll.deletar(dto);
                    IndexDTO model = new IndexDTO();
                    model.delete = true;
                    return RedirectToAction("Index", "Busca", model);
                }
                catch
                {
                    ViewBag.delete = "Erro ao deletar";
                    return View();
                }
            }
        }
        public ActionResult Coroa()
        {
            CoroaBLL bll = new CoroaBLL();
            CoroaDTO dto = new CoroaDTO();
            dto.arrayCO = bll.Consultar(dto);
            dto.Especie = "";
            dto.Circunferencia = "";
            dto.Descricao = "";
            dto.Codigo = "";
            dto.Tipo = "";
            dto.Valor = "";
            return View(dto);
        }

        [HttpPost]
        public ActionResult Coroa(CoroaDTO dto, string btn)
        {
            CoroaBLL bll = new CoroaBLL();
            if (btn == "Buscar")
            {
                dto.arrayCO = bll.Consultar(dto);
                bll.buscar(dto);
                dto.Valor = dto.Valor.Replace(",", ".");
                dto.Valor = dto.Circunferencia.Replace(",", ".");
                return View(dto);

            }
            else if (btn == "Salvar")
            {
                dto.arrayCO = bll.Consultar(dto);
                bll.atualizar(dto);
                IndexDTO model = new IndexDTO();
                model.Alert = true;
                return RedirectToAction("index", "Busca", model);
            }
            else
            { //botão é deletar
                try
                {
                    bll.deletar(dto);
                    IndexDTO model = new IndexDTO();
                    model.delete = true;
                    return RedirectToAction("Index", "Busca", model);
                }
                catch
                {
                    ViewBag.delete = "Erro ao deletar";
                    return View();
                }
            }
            return View();
        }
    }
 }