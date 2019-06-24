using System;
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

        public static string Antiga { get; set; }

        public string Largura { get; set; }

        public string Profundidade { get; set; }

        [DisplayName("Nome da urna")]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public string Valor { get; set; }

        public string Codigo { get;  set; }

        public List<UrnaDTO> arrayU = new List<UrnaDTO>();

        public override string ToString()
        {
            return Nome;
        }
    }
}