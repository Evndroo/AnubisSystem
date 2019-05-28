using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class CoroaDTO
    {

        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Especie { get; set; }
        public string Circunferencia { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; internal set; }
    }
}