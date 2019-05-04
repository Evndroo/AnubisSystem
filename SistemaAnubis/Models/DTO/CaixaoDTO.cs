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

        [ReadOnly(true)]
        public string Altura { get; set; }

        [ReadOnly(true)]
        public string Largura { get; set; }

        [ReadOnly(true)]
        public string Profundidade { get; set; }

        public string Modelo { get; set; }

        [ReadOnly(true)]
        public string Valor { get; set; }
    }
}