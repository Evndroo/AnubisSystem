using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class PlanoDTO
    {

        public string Codigo { get; set; }

        public string Urna { get; set; }

        [DisplayName("Caixão")]
        public string Caixao { get; set; }

        public string Flor { get; set; }

        [DisplayName("Quantidade")]
        public string QuantFlor { get; set; }
        public string Coroa { get; set; }

        [DisplayName("Quantidade")]
        public string QuantCoroa { get; set; }

        [DisplayName("Lápide")]
        public int Lapide { get; set; }

        public int Necromaquiagem { get; set; }

        [DisplayName("Paramentação")]
        public int Paramentacao { get; set; }


        public int Translado { get; set; }

        [DisplayName("Véu")]
        public int Veu { get; set; }

        public string Dono { get;  set; }
        public string Nome { get;  set; }
        public string Valor { get; set; }
        public static object Antigo { get; set; }

        public List<CoroaDTO> arrayCO = new List<CoroaDTO>();

        public List<UrnaDTO> arrayU = new List<UrnaDTO>();
        public List<CaixaoDTO> arrayC = new List<CaixaoDTO>();
        public List<FloresDTO> arrayF = new List<FloresDTO>();
        public List<PlanoDTO> arrayP = new List<PlanoDTO>();

        public override string ToString()
        {
            return Nome;
        }




    }
}