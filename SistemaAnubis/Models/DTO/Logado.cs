using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class Logado
    {
        public static string User { get; set; }
        
        public static string Senha { get; set; }
        

        public static string Codigo;
        
        public static string Nome { get; set; }
        
        public static string Cpf { get; set; }
        
        public static string Email { get; set; }        

        public static string Telefone { get; set; }
        
        public static string Celular { get; set; }        

        public static string Cep { get; set; }

        public static string erro;

        public static string Num { get; set; }

        public static void Logoff()
        {
            User = null;
            Senha = null;
            Codigo = null;
            Nome = null;
            Cpf = null;
            Email = null;
            Telefone = null;
            Celular = null;
            Cep = null;
            erro = null;
            Num = null;
        }
    }
}