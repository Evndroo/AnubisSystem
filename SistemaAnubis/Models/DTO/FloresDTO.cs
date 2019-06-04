using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class FloresDTO
    {
        
        public string Codigo { get; internal set; }
        public string Especie { get; set; }
        public string Quantidade { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; internal set; }
        public List<FloresDTO> arrayF = new List<FloresDTO>();

        public override string ToString()
        {
            return Especie;
        }

    }
}