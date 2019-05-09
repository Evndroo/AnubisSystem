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
            if (Validacoes.IsCpf(dto.Cpf)) {
                //if (dto.ConfSenha.Equals(dto.Senha))
                //{
                    AdministradorBLL bll = new AdministradorBLL();
                    bll.inserir(dto);
                    if (dto.erro == "1")
                    {
                        ViewBag.erro = "Este usuário já existe";
                        return View();
                    }
                    else if (dto.erro == "2")
                        return Content("<script language='javascript' type='text/javascript'>alert('CPF já cadastrado, favor resgatar seu logine senha !'); location.href='Administrador'</script>");
                    else
                        return View();
                //}
                //else {
                    
                    //return View();
                //}
            }
            else {
                
                return Content("<script language='javascript' type='text/javascript'>alert('CPF inválido!'); location.href='Administrador'</script>");
            }
        }




        public ActionResult Cliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cliente(ClienteDTO dto)
        {
            if (Validacoes.IsCpf(dto.Cpf))
            {
                try
                {
                    ClienteBLL bll = new ClienteBLL();
                    bll.inserir(dto);

                    if (dto.erro == "1")
                    {
                        ViewBag.erro = "Este usuário já existe";
                        return View();
                    }
                    else if (dto.erro == "2")
                        return Content("<script language='javascript' type='text/javascript'>alert('CPF já cadastrado, favor resgatar seu logine senha !'); location.href='Administrador'</script>");
                    else
                        return View();
                }
                catch
                {
                    return View();
                }
            } else return Content("<script language='javascript' type='text/javascript'>alert('CPF inválido!'); location.href='Administrador'</script>");
        }



        public ActionResult Funcionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Funcionario(FuncionarioDTO dto)
        {
            if (Validacoes.IsCpf(dto.Cpf)){
                try
                {
                    FuncionarioBLL bll = new FuncionarioBLL();
                    bll.inserir(dto);
                    if (dto.erro == "1")
                    {
                        ViewBag.erro = "Este usuário já existe";
                        return View();
                    }
                    else if (dto.erro == "2")
                        return Content("<script language='javascript' type='text/javascript'>alert('CPF já cadastrado, favor resgatar seu logine senha !'); location.href='Administrador'</script>");
                    else
                        return View();
                }
                catch
                {
                    return View();
                }
            } else return Content("<script language='javascript' type='text/javascript'>alert('CPF inválido!'); location.href='Administrador'</script>");

    }

    public ActionResult Falecido()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Falecido(FalecidoDTO dto)
        {
            try
            {
                FalecidoBLL bll = new FalecidoBLL();
                bll.inserir(dto);
                return View();
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Caixao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Caixao(CaixaoDTO dto)
        {
            try
            {
                CaixaoBLL bll = new CaixaoBLL();
                bll.inserir(dto);
                return View();
            }
            catch
            {            
                return Content("<script language='javascript' type='text/javascript'> alert('Erro ao cadastrar!');</script>");
            }
        }


        public ActionResult Coroa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Coroa(CoroaDTO dto)
        {
            try
            {
                CoroaBLL bll = new CoroaBLL();
                bll.inserir(dto);
                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Flores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Flores(FloresDTO dto)
        {
            try
            {
                FloresBLL bll = new FloresBLL();
                bll.inserir(dto);
                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Urna()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Urna(UrnaDTO dto)
        {
            try
            {
                UrnaBLL bll = new UrnaBLL();
                bll.inserir(dto);
                return View();
            }
            catch
            {
                return Content("<script language='javascript' type='text/javascript'> alert('Erro ao cadastrar!');</script>");
            }
        }




        public ActionResult Plano()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Plano(PlanoDTO dto)
        {
            try
            {
                PlanoBLL bll = new PlanoBLL();
                bll.inserir(dto);
                return View();
            }
            catch
            {
                return View();
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
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}