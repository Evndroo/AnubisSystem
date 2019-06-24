using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class FalecidoDTO
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        public string Nascimento { get; set; }

        [DisplayName("Data de falescimento")]
        public string Falecimento { get; set; }
        public string Circunferencia { get; set; }
        public string Altura { get; set; }
        public string Plano { get; set; }

        [DisplayName("Responsável")]
        public string Responsavel { get; set; }
        public List<FalecidoDTO> listaFal = new List<FalecidoDTO>();

        public List<ClienteDTO> clientes = new List<ClienteDTO>();
        public List<PlanoDTO> arrayP = new List<PlanoDTO>();


        public override string ToString()
        {
            return Nome;
        }
    }
}

    
