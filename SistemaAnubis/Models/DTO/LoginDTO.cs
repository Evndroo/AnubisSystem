using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class LoginDTO
    {
        
        
        [Required]
        public string User { get; set; }

        [Required]
        [DisplayName("Digite sua senha")]
        public string Senha { get; set; }

        [Required]
        [DisplayName("Confirme sua senha")]
        public string ConfSenha { get; set; }
    }
}