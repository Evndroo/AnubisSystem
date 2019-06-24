using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class CaixaoDTO
    {

        public string Codigo { get; set; }
        
        public string Altura { get; set; }
        
        public string Largura { get; set; }
                
        public string Profundidade { get; set; }

        [DisplayName("Nome")]
        public string Modelo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public string Valor { get; set; }

        public List<CaixaoDTO> arrayC = new List<CaixaoDTO>();

        public override string ToString()
        {
            return Modelo;
        }
    }
}