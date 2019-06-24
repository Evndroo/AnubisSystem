using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class CompraDTO
    {

        public string Cliente { get; set; }
        public string Vendedor{ get; set; }
        public string Plano { get; set; }
        public string Data { get; set; }
        public string Falecido { get; set; }
        public string Funcionario { get; set; }

        public List<PlanoDTO> Planos = new List<PlanoDTO>();
        public List<FalecidoDTO> Falecidos = new List<FalecidoDTO>();
        public List<FuncionarioDTO> Funcionarios = new List<FuncionarioDTO>();
        public List<ClienteDTO> Clientes = new List<ClienteDTO>();
        public bool erro;
    }
}