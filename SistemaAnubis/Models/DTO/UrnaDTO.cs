﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class UrnaDTO
    {
        public string Altura { get; set; }

        public string Largura { get; set; }

        public string Profundidade { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public string Valor { get; set; }
        public string Codigo { get;  set; }
    }
}