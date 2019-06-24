using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DTO
{
    public class ClienteDTO : LoginDTO
    {
       public List<ClienteDTO> arrayCli = new List<ClienteDTO>();

        public override string ToString()
        {
            return this.User;
        }
    }
}