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
                dto.Codigo = dr[0].ToString();
                dto.Nome = dr[1].ToString();
                dto.Cpf = dr[2].ToString();
                dto.Email = dr[3].ToString();
                dto.Telefone = dr[4].ToString();
                dto.Celular = dr[5].ToString();
                dto.Cep = dr[6].ToString();
                dto.Num = dr[7].ToString();
                dto.CodUser = dr[9].ToString();
                dto.User = dr[10].ToString();
                dto.Senha = dr[11].ToString();
                dto.Nvl = dr[12].ToString();
            }
            con.desconectarBD();
        }

        public override void buscarEmail(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdmEmail(@email)", con.conectarBD());
            cmd.Parameters.AddWithValue("@email", dto.Email);
            dr = cmd.ExecuteReader();


            
            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Nome = dr[1].ToString();
                dto.Cpf = dr[2].ToString();
                dto.Email = dr[3].ToString();
                dto.Telefone = dr[4].ToString();
                dto.Celular = dr[5].ToString();
                dto.Cep = dr[6].ToString();
                dto.Num = dr[7].ToString();
                dto.CodUser = dr[9].ToString();
                dto.User = dr[10].ToString();
                dto.Senha = dr[11].ToString();
                dto.Nvl = dr[12].ToString();
            }
            con.desconectarBD();
        }

        public override void buscarUser(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdm(@user)", con.conectarBD());
            cmd.Parameters.AddWithValue("@user", dto.User);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Nome = dr[1].ToString();
                dto.Cpf = dr[2].ToString();
                dto.Email = dr[3].ToString();
                dto.Telefone = dr[4].ToString();
                dto.Celular = dr[5].ToString();
                dto.Cep = dr[6].ToString();
                dto.Num = dr[7].ToString();
                dto.CodUser = dr[9].ToString();
                dto.User = dr[10].ToString();
                dto.Senha = dr[11].ToString();
                dto.Nvl = dr[12].ToString();
            }
            con.desconectarBD();
        }

        public override DataTable buscarCpfGrid(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdmCPF(@cpf)", con.conectarBD());
            cmd.Parameters.AddWithValue("@cpf", dto.Cpf);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Nome = dr[1].ToString();
                dto.Cpf = dr[2].ToString();
                dto.Email = dr[3].ToString();
                dto.Telefone = dr[4].ToString();
                dto.Celular = dr[5].ToString();
                dto.Cep = dr[6].ToString();
                dto.Num = dr[7].ToString();
                dto.CodUser = dr[9].ToString();
                dto.User = dr[10].ToString();
                dto.Senha = dr[11].ToString();
                dto.Nvl = dr[12].ToString();
            }
            con.desconectarBD();
            return Data(cmd);
        }

        public override DataTable buscarEmailGrid (LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busAdmEmail(@email)", con.conectarBD());
            cmd.Parameters.AddWithValue("@email", dto.Email);
            dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Nome = dr[1].ToString();
                dto.Cpf = dr[2].ToString();
                dto.Email = dr[3].ToString();
                dto.Telefone = dr[4].ToString();
                dto.Celular = dr[5].ToString();
                dto.Cep = dr[6].ToString();
                dto.Num = dr[7].ToString();
                dto.CodUser = dr[9].ToString();
                dto.User = dr[10].ToString();
                dto.Senha = dr[11].ToString();
                dto.Nvl = dr[12].ToString();
            }
            con.desconectarBD();
            return Data(cmd);
        }

        public override DataTable buscarUserGrid(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call buscaAdm(@user)", con.conectarBD());
            cmd.Parameters.AddWithValue("@user", dto.User);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Nome = dr[1].ToString();
                dto.Cpf = dr[2].ToString();
                dto.Email = dr[3].ToString();
                dto.Telefone = dr[4].ToString();
                dto.Celular = dr[5].ToString();
                dto.Cep = dr[6].ToString();
                dto.Num = dr[7].ToString();
                dto.CodUser = dr[9].ToString();
                dto.User = dr[10].ToString();
                dto.Senha = dr[11].ToString();
                dto.Nvl = dr[12].ToString();
            }
            con.desconectarBD();
            return Data(cmd);
        }

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
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = dto.Telefone;
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

        public DataTable Data(MySqlCommand cmd)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }

        public override void buscarNome(LoginDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}