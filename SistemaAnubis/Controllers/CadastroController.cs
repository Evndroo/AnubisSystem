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
                try {
                    AdministradorBLL bll = new AdministradorBLL();
                    bll.inserir(dto);
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            else {
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
            try
            {
                ClienteBLL bll = new ClienteBLL();
                bll.inserir(dto);
                return View();
            }
            catch
            {
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
            try
            {
                FuncionarioBLL bll = new FuncionarioBLL();
                bll.inserir(dto);
                return View();
            }
            catch
            {
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
                return View();
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
                return View();
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