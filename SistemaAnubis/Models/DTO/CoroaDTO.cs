using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class CoroaDTO
    {

        public string Codigo { get; set; }

        [DisplayName("Tipo de flores")]
        public string Tipo { get; set; }

        [DisplayName("Espécie")]
        public string Especie { get; set; }

        [DisplayName("Circunferência")]
        public string Circunferencia { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage ="Valor é obrigatório")]
        public string Valor { get;  set; }

        public List<CoroaDTO> arrayCO = new List<CoroaDTO>();

        public override string ToString()
        {
            return Tipo;
        }
    }
}