using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class FuncionarioDTO : LoginDTO
    {
        public string erro;

        [Required]
        [StringLength(85, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$|^\d{6}-\d{4}$|^\d{4}-\d{4}$|^\d{8}$")]
        public string Telefone { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$|^\d{7}-\d{4}$|^\d{5}-\d{4}$|^\d{9}$")]
        public string Celular { get; set; }

        public string Cep { get; set; }

        public string Num { get; set; }
    }
}