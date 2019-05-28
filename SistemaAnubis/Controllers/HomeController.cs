using SistemaAnubis.Models.BLL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Net.Configuration;
using System.Net;
using MySql.Data.MySqlClient;

namespace SistemaAnubis.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Empresa()
        {


            return View();
        }

        public ActionResult Suporte()
        {

            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        public ActionResult Portifolio()
        {
            return View();
        }

        public ActionResult Login() {
           return View();
        }

        [HttpPost]
        public ActionResult Login(ClienteDTO dto)
        {
            int tipo = TipoDeLogin(dto);
            AchaLogin(dto, tipo);
            if (dto.Senha == null)
            {
                ViewBag.msg = dto.erro;
                return View();
            }
            //    Senha está correta           E                      Login está correto              
            else if (dto.Senha == Logado.Senha && (dto.Cpf == Logado.Cpf || dto.User == Logado.User || dto.Email == Logado.Email)) //
            {
                Logado.User = dto.User;
                Logado.Senha = dto.Senha;
                Logado.Nome = dto.Nome;
                Logado.Cpf = dto.Cpf;
                Logado.Email = dto.Email;
                Logado.Telefone = dto.Telefone;
                Logado.Celular = dto.Celular;
                Logado.Cep = dto.Cep;
                Logado.Num = dto.Num;

                return RedirectToAction("Index", "Busca");
            }
            else
            {
                dto.LimpaDTO(dto);
                Logado.Logoff();
                ViewBag.msg = "Login ou senha incorreto";
                return View();
            }
        }


        [HttpPost]
        public ActionResult Esqueci(LoginDTO dto)
        {
            Random random = new Random();
            int senha = random.Next(10000, 99999);
            string resposta;
            try
            {
                ClienteBLL bll = new ClienteBLL();                
                bll.buscarEmail(dto);
                resposta = EnviarEmail(dto,bll,senha);
                MudarSenha(dto, bll, 3,senha);
            }
            catch {
                try {
                    FuncionarioBLL bllF = new FuncionarioBLL();
                    bllF.buscarEmail(dto);
                    resposta = EnviarEmail(dto, bllF, senha);
                    MudarSenha(dto, bllF, 2, senha);
                }
                catch {
                    try
                    {
                        AdministradorBLL bllA = new AdministradorBLL();
                        bllA.buscarEmail(dto);

                        resposta = EnviarEmail(dto, bllA, senha);
                        MudarSenha(dto, bllA, 1, senha);
                    }
                    catch (MySqlException ex) {
                        resposta = ex.ToString();
                    }
                }
            }

            return View();
        }

        public ActionResult Esqueci()
        {
            
            return View();
        }

        public string EnviarEmail(LoginDTO dto, LoginBLL bll, int senha)
        {
            try
            {                
                    //Instância classe email
                    MailMessage mail = new MailMessage();
                    mail.To.Add(dto.Email);
                    mail.From = new MailAddress("anubisfuneraria@gmail.com");
                    mail.Subject = "Nova senha";
                    string Body = "Nova senha: " + senha ;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;

                    //Instância smtp do servidor, neste caso o gmail.
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 25;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("anubisfuneraria", "Anubis123");// Login e senha do e-mail.
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return "Envio do E-mail com sucesso"; 
                
            }
            catch (Exception e)
            {                 
                return e.Message.ToString();
            }
        }


        private int TipoDeLogin(LoginDTO dto)
        {
            int tipo;
            Logado.Senha = dto.Senha;
            dto.Email = dto.User;
            dto.Cpf = dto.User;
            if (Validacoes.isEmail(dto.Email)) //tentou logar com o email
            {
                dto.Cpf = "";
                dto.User = "";
                Logado.Email = dto.Email;
                tipo = 0;
            }
            else if (Int64.TryParse(dto.Cpf,out long i)) //tentou logar com o cpf
            {
                if (Validacoes.IsCpf(dto.Cpf))
                {
                    dto.Email = "";
                    dto.User = "";
                    Logado.Cpf = dto.Cpf;
                    tipo = 1;
                }
                else if (dto.Cpf.Length != 11)
                { //Usuário numérico
                    dto.Email = "";
                    dto.Cpf = "";
                    Logado.User = dto.User;
                    tipo = 2;
                }
                else
                {
                    tipo = 3;
                }
            }
            else //tentou logar com o user
            {
                dto.Email = "";
                dto.Cpf = "";
                Logado.User = dto.User;
                tipo = 2;
            }
            return tipo;
        }


        private void AchaLogin(LoginDTO dto, int tipo)
        {

            ClienteBLL bll = new ClienteBLL();
            FuncionarioBLL bllF = new FuncionarioBLL();
            AdministradorBLL bllA = new AdministradorBLL();

            //verifica se foi o cliente que logou
            switch (tipo)
            {
                case 0:
                    bll.buscarEmail(dto);

                    if (dto.Nome == null)
                    {
                        bllF.buscarEmail(dto);
                        if (dto.Nome == null)
                        {
                            bllA.buscarEmail(dto);
                            if (dto.Nome == null)
                            {
                                dto.LimpaDTO(dto);
                                dto.erro = "E-mail não registrado";
                            }
                        }
                    }
                    break;
                case 1:
                    bll.buscarCpf(dto);
                    if (dto.Nome == null)
                    {
                        bllF.buscarCpf(dto);
                        if (dto.Nome == null)
                        {
                            bllA.buscarCpf(dto);
                            if (dto.Nome == null)
                            {
                                dto.LimpaDTO(dto);
                                dto.erro = "Cpf não registrado";
                            }
                        }
                    }
                    break;
                case 2:
                    bll.buscarUser(dto);
                    if (dto.Nome == null)
                    {
                        bllF.buscarUser(dto);
                        if (dto.Nome == null)
                        {
                            bllA.buscarUser(dto);
                            if (dto.Nome == null)
                            {
                                dto.LimpaDTO(dto);
                                dto.erro  = "Usuário não registrado";
                            }
                        }
                    }
                    break;
                case 3:
                    dto.LimpaDTO(dto);
                    ViewBag.msg = "CPF inválido, corrijá-o e tente novamente";
                    break;
            }
        }


        

        private void MudarSenha(LoginDTO dto, LoginBLL bll, int nivel, int senha) {
            bll.buscarEmail(dto);
            dto.Senha = senha.ToString();
            switch (nivel)
            {
                case 3:
                    bll.atualizar(dto);
                    break;
                case 2:
                    bll.atualizar(dto);
                    break;
                case 1:
                    bll.atualizar(dto);
                    break;
            }
        }
    }
}