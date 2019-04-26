using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class ClienteDTO : LoginDTO
    {


        public const int nivel =  3;

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Login { get; set; }

        public string Cep { get; set; }

        public string Num { get; set; }
    }
}