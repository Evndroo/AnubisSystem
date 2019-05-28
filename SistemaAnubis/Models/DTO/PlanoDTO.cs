using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class PlanoDTO
    {

        public string Codigo { get; set; }
        public string Urna { get; set; }
        public string Caixao { get; set; }
        public string Flor { get; set; }
        public string QuantFlor { get; set; }
        public string Coroa { get; set; }
        public string QuantCoroa { get; set; }
        public bool Lapide { get; set; }
        public bool Necromaquiagem { get; set; }
        public bool Paramentacao { get; set; }
        public bool Translado { get; set; }
        public bool Veu { get; set; }
    }
}