using MySql.Data.MySqlClient;
using SistemaAnubis.Models.DAL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.BLL
{
    public class AdministradorBLL : LoginBLL
    {
        Conexao con = new Conexao();



        /***************************************************************************************************
         **                                     Buscando dados no banco                                   **
         ***************************************************************************************************/

        public DataTable Consultar()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAdministrador", con.conectarBD());
            return Data(cmd);
        }

        

        MySqlDataReader dr;
        public override void buscarCpf(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdmCpf(@cpf)", con.conectarBD());
            cmd.Parameters.AddWithValue("@cpf", dto.Cpf);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.CodUser = dr[0].ToString();
                dto.User = dr[1].ToString();
                dto.Senha = dr[2].ToString();
                dto.Nvl = dr[3].ToString();
                dto.Codigo = dr[4].ToString();
                dto.Nome = dr[5].ToString();
                dto.Cpf = dr[6].ToString();
                dto.Email = dr[7].ToString();
                dto.Telefone = dr[8].ToString();
                dto.Celular = dr[9].ToString();
                dto.Cep = dr[10].ToString();
                dto.Num = dr[11].ToString();
            }
            con.desconectarBD();
        }

        internal List<AdministradorDTO> listar()
        {
            List<AdministradorDTO> list = new List<AdministradorDTO>();

            MySqlCommand cmd = new MySqlCommand("select * from tbLogin join tbAdministrador on cod_login_adm = cod_login;", con.conectarBD());
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                AdministradorDTO inst = new AdministradorDTO();
                inst.User = dr[1].ToString();
                inst.Nvl = dr[3].ToString();
                inst.Nome = dr[5].ToString();
                inst.Cpf = dr[6].ToString();
                inst.Email = dr[7].ToString();
                inst.Telefone = dr[8].ToString();
                inst.Celular = dr[9].ToString();
                inst.Cep = dr[10].ToString();
                inst.Num = dr[11].ToString();
                list.Add(inst);
            }
            con.desconectarBD();

            return list;
        }

        public override void buscarEmail(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdmEmail(@email)", con.conectarBD());
            cmd.Parameters.AddWithValue("@email", dto.Email);
            dr = cmd.ExecuteReader();


            
            while (dr.Read())
            {
                dto.CodUser = dr[0].ToString();
                dto.User = dr[1].ToString();
                dto.Senha = dr[2].ToString();
                dto.Nvl = dr[3].ToString();
                dto.Codigo = dr[4].ToString();
                dto.Nome = dr[5].ToString();
                dto.Cpf = dr[6].ToString();
                dto.Email = dr[7].ToString();
                dto.Telefone = dr[8].ToString();
                dto.Celular = dr[9].ToString();
                dto.Cep = dr[10].ToString();
                dto.Num = dr[11].ToString();
            }
            con.desconectarBD();
        }

        public override void buscarUser(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdmUser(@user)", con.conectarBD());
            cmd.Parameters.AddWithValue("@user", dto.User);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.CodUser = dr[0].ToString();
                dto.User = dr[1].ToString();
                dto.Senha = dr[2].ToString();
                dto.Nvl = dr[3].ToString();
                dto.Codigo = dr[4].ToString();
                dto.Nome = dr[5].ToString();
                dto.Cpf = dr[6].ToString();
                dto.Email = dr[7].ToString();
                dto.Telefone = dr[8].ToString();
                dto.Celular = dr[9].ToString();
                dto.Cep = dr[10].ToString();
                dto.Num = dr[11].ToString();
            }
            con.desconectarBD();
        }

        public override DataTable buscarCpfGrid(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdmCPF(@cpf)", con.conectarBD());
            cmd.Parameters.AddWithValue("@cpf", dto.Cpf);
            return Data(cmd);
        }

        public override DataTable buscarEmailGrid (LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdmEmail(@email)", con.conectarBD());
            cmd.Parameters.AddWithValue("@email", dto.Email);
            return Data(cmd);
        }

        public override DataTable buscarUserGrid(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdm(@user)", con.conectarBD());
            cmd.Parameters.AddWithValue("@user", dto.User);
            return Data(cmd);
        }

        public override void buscarNome(LoginDTO dto)
        {//para fazer
            throw new NotImplementedException();
        }



        /************************************************************************************
         **                             Manipulando dados no banco                         **
         ************************************************************************************/





        public void inserir(AdministradorDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirAdmLogin(@user,@senha,@nome,@cpf,@email,@telefone,@celular,@cep,@num)", con.conectarBD());
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dto.User;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = dto.Senha;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dto.Email;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = dto.Telefone;
            cmd.Parameters.Add("@celular", MySqlDbType.VarChar).Value = dto.Celular;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = dto.Cep;
            cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = dto.Num;


            try
            {
                cmd.ExecuteNonQuery();
                con.desconectarBD();
            }
            catch (MySqlException e)
            {

                //verifica se o usuário já existe, caso sim manda uma mensagem melhor para a tela
                if (e.Message.Equals("Duplicate entry '" + dto.User + "' for key 'user_log'"))
                {
                    dto.erro = "1";
                }
                else if (e.Message.Equals("Duplicate entry '" + dto.Cpf + "' for key 'cpf_adm'"))
                {
                    dto.erro = "2";
                }
                if (e.Message.Equals("Duplicate entry '" + dto.Email + "' for key 'email_adm'"))
                {
                    dto.erro = "3";
                }
            }
        }

        public override void atualizar(LoginDTO dto) {
            MySqlCommand cmd = new MySqlCommand("call upAdm(@cpf,@user,@senha,@nome,@email,@tel,@cel,@cep,@num)", con.conectarBD());
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dto.User;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = dto.Senha;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dto.Email;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = dto.Telefone;
            cmd.Parameters.Add("@cel", MySqlDbType.VarChar).Value = dto.Celular;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = dto.Cep;
            cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = dto.Num;
            cmd.ExecuteNonQuery();
            con.desconectarBD();

        }

        public void deletar(AdministradorDTO dto) {
            MySqlCommand cmd = new MySqlCommand("call delAdm(@cpf)", con.conectarBD());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;

            con.desconectarBD();
        }



        /************************************************************************************
         **                       Métodos sem conexão com o banco                          **
         ************************************************************************************/


        public DataTable Data(MySqlCommand cmd)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }

        internal void MudarSenha(AdministradorDTO adm)
        {
            throw new NotImplementedException();
        }
    }
}