using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class FloresDTO
    {
        
        public string Codigo { get; internal set; }

        [DisplayName("Espécie")]
        public string Especie { get; set; }

        
        public string Quantidade { get; set; }
        public string Tipo { get; set; }

        [Required]
        public string Valor { get; set; }
        public List<FloresDTO> arrayF = new List<FloresDTO>();

        public override string ToString()
        {
            return Especie;
        }

    }
}