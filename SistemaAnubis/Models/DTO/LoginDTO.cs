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


        [DisplayName("Usuário")]
        public string User { get; set; }


        [DisplayName("Digite sua senha")]
        
        public string Senha { get; set; }
        
        
        [DisplayName("Confirme sua senha")]
        public string ConfSenha { get; set; }

        public string Codigo { get; set; }

        public string CodUser { get; set; }

        
        [StringLength(85, MinimumLength = 3)]
        public string Nome { get; set; }

        
        [DisplayName("CPF")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        public string Cpf { get; set; }
        
        [DataType(DataType.EmailAddress,ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$|^\d{8}$")]
        public string Telefone { get; set; }

        
        [RegularExpression(@"^\d{11}$|^\d{9}$")]
        public string Celular { get; set; }

        [DisplayName("CEP")]
        public string Cep { get; set; }

        public string erro;

        public string Num { get; set; }

        public string Nvl { get; set; }

        public void LimpaDTO(LoginDTO dto) {
            dto.Codigo = null;
            dto.User = null;
            dto.Senha = null;
            dto.Nome = null;
            dto.Cpf = null;
            dto.Email = null;
            dto.Telefone = null;
            dto.Celular = null;
            dto.Cep = null;
            dto.Num = null;
        }
    }
}