using SistemaAnubis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.BLL
{
    public abstract class LoginBLL
    {
        abstract public void atualizar(LoginDTO dto);

        abstract public void buscarEmail(LoginDTO dto);

        abstract public void buscarCpf(LoginDTO dto);

        abstract public void buscarUser(LoginDTO dto);

        abstract public void buscarNome(LoginDTO dto);

        abstract public DataTable buscarEmailGrid(LoginDTO dto);

        abstract public DataTable buscarCpfGrid(LoginDTO dto);

        abstract public DataTable buscarUserGrid(LoginDTO dto);
    }
}