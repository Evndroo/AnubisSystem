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
    public class ClienteBLL : LoginBLL
    {
        Conexao con = new Conexao();


        

        public DataTable Buscar()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCliente", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        public void BuscarTodos(ClienteDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCliente", con.conectarBD());
            dr = cmd.ExecuteReader();
            List<ClienteDTO> array = new List<ClienteDTO>();

            while (dr.Read())
            {
                ClienteDTO dtoCli = new ClienteDTO();
                dtoCli.Codigo = dr[0].ToString();
                dtoCli.Nome = dr[1].ToString();
                dtoCli.Cpf = dr[2].ToString();
                dtoCli.Email = dr[3].ToString();
                dtoCli.Telefone = dr[4].ToString();
                dtoCli.Celular = dr[5].ToString();
                dtoCli.Cep = dr[6].ToString();
                dtoCli.Num = dr[7].ToString();
                array.Add(dtoCli);
            }
            dto.arrayCli = array;
            con.desconectarBD();
        }

            MySqlDataReader dr;
        public override void buscarCpf(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busCliCpf(@cpf);", con.conectarBD());
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
        


        public override void buscarEmail(LoginDTO dto){
            MySqlCommand cmd = new MySqlCommand("call busCliEmail(@email)", con.conectarBD());
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
            MySqlCommand cmd = new MySqlCommand("Call busCli(@user)", con.conectarBD());
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


        public ClienteDTO busUser(ClienteDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("Call busCli(@user)", con.conectarBD());
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
            return dto;
        }

        public List<ClienteDTO>  buscarUserL(List<ClienteDTO> dto)
        {
            List<ClienteDTO> list = new List<ClienteDTO>();
            foreach (ClienteDTO dt in dto)
            {
                MySqlCommand cmd = new MySqlCommand("Call busCli(@user)", con.conectarBD());
                cmd.Parameters.AddWithValue("@user", dt.User);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClienteDTO inst = new ClienteDTO();
                    inst.CodUser = dr[0].ToString();
                    inst.User = dr[1].ToString();
                    inst.Senha = dr[2].ToString();
                    inst.Nvl = dr[3].ToString();
                    inst.Codigo = dr[4].ToString();
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
            }
            return list;
        }

        public List<ClienteDTO> Listar()
        {
            List<ClienteDTO> list = new List<ClienteDTO>();
            
            MySqlCommand cmd = new MySqlCommand("select * from tbLogin join tbCliente on cod_login_cli = cod_login;", con.conectarBD());
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ClienteDTO inst = new ClienteDTO();
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

        public override DataTable buscarEmailGrid(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busCliEmailC(@email)", con.conectarBD());
            cmd.Parameters.AddWithValue("@email", dto.Email);
            return Data(cmd);
        }

        public override DataTable buscarCpfGrid(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("Call busCliCPFC(@cpf)", con.conectarBD());
            cmd.Parameters.AddWithValue("@cpf", dto.Cpf);
            return Data(cmd);
        }

        public override DataTable buscarUserGrid(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busCliC(@user);", con.conectarBD());
            cmd.Parameters.AddWithValue("@user", dto.User);
            return Data(cmd);
        }

        public void inserir(ClienteDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirCliLogin(@login,@senha,@nome,@cpf,@email,@telefone,@celular,@cep,@num)", con.conectarBD());
            cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = dto.User;
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
                else if (e.Message.Equals("Duplicate entry '" + dto.Cpf + "' for key 'cpf_cli'"))
                {
                    dto.erro = "2";
                }
                if (e.Message.Equals("Duplicate entry '" + dto.Email + "' for key 'email_cli'"))
                {
                    dto.erro = "3";
                }
            }
        }

        internal void MudarSenha(LoginDTO cli)
        {
            MySqlCommand cmd = new MySqlCommand("call upSenha(@user,@senha);", con.conectarBD());
            cmd.Parameters.Add("@user",MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.User;
            cmd.Parameters.Add("@senha",MySqlDbType.VarChar).Value = cli.Senha;
            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public override void atualizar(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call altCli(@cpf,@user,@nome,@email,@tel,@cel,@cep,@num)", con.conectarBD());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dto.User;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dto.Email;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = dto.Telefone;
            cmd.Parameters.Add("@cel", MySqlDbType.VarChar).Value = dto.Celular;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = dto.Cep;
            cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = dto.Num;
            cmd.ExecuteNonQuery();
            con.desconectarBD();

        }

        public void alterar(LoginDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call upCli(@cpf,@user,@senha,@nome,@email,@tel,@cel,@cep,@num)", con.conectarBD());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dto.User;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = dto.Senha;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dto.Email;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = dto.Telefone;
            cmd.Parameters.Add("@cel", MySqlDbType.VarChar).Value = dto.Celular;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = dto.Cep;
            cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = dto.Num;
            cmd.ExecuteNonQuery();
            con.desconectarBD();

        }

        public void deletar(ClienteDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call delCli(@cpf);", con.conectarBD());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;
            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable Data(MySqlCommand cmd)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            if (agenda.Rows.Count == 0) return null;
            return agenda;
        }

        public override void buscarNome(LoginDTO dto)
        {
        }
    }
}