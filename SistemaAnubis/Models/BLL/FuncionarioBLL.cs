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
    public class FuncionarioBLL
    {

        Conexao con = new Conexao();


        public void inserir(FuncionarioDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call sp_inserirfunc(@user,@senha@lvl,@nome,@cpf,@email,@telefone,@celular,@cep,@num)", con.conectarBD());
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dto.User;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = dto.Senha;
            cmd.Parameters.Add("@lvl", MySqlDbType.VarChar).Value = FuncionarioDTO.nivel;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dto.Email;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = dto.Telefone;
            cmd.Parameters.Add("@celular", MySqlDbType.VarChar).Value = dto.Celular;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = dto.Cep;
            cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = dto.Num;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable Consultar(FuncionarioDTO dto)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        MySqlDataReader dr;
        public void buscar(FuncionarioDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario where cpf_func = @cpf", con.conectarBD());
            cmd.Parameters.AddWithValue("@cpf", dto.Cpf);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.User = dr[0].ToString();
                dto.Senha = dr[1].ToString();
                dto.Nome = dr[2].ToString();
                dto.Cpf = dr[3].ToString();
                dto.Email = dr[4].ToString();
                dto.Telefone = dr[5].ToString();
                dto.Celular = dr[6].ToString();
                dto.Cep = dr[7].ToString();
                dto.Num = dr[8].ToString();
            }
            con.desconectarBD();
        }

        public void atualizar(FuncionarioDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbFuncionario set nome_func=@Nome, cpf_func=@cpf, tel_func=@tel, email_func=@email, cel_func = @cel, Cepfunc=@cep, funcnum_end = @num where cpf_func = @cpf", con.conectarBD());
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dto.User;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = dto.Senha;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dto.Email;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = dto.Telefone;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = dto.Cep;
            cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = dto.Num;
            con.desconectarBD();

        }

        public void deletar(FuncionarioDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbFuncionario where cpf_func = @cpf", con.conectarBD());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Cpf;

            con.desconectarBD();
        }
    }
}