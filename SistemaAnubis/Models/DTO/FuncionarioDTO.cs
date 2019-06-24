using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class FuncionarioDTO : LoginDTO
    {
        public List<FuncionarioDTO> arrayfunc = new List<FuncionarioDTO>();

        public override string ToString()
        {
            return this.User;
        }
    }
}