﻿using MySql.Data.MySqlClient;
using SistemaAnubis.Models.DAL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.BLL
{
    public class AdministradorBLL
    {
        Conexao con = new Conexao();

        

        public void inserir(AdministradorDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirAdmLogin(@user,@senha,@nome,@cpf,@email,@telefone,@celular,@cep,@num)", con.conectarBD());
            cmd.Parameters.Add("@user",MySqlDbType.VarChar).Value = dto.User;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = dto.Senha;
            cmd.Parameters.Add("@nome",MySqlDbType.VarChar).Value=dto.Nome;
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
            catch (MySqlException e) {

                //verifica se o usuário já existe, caso sim manda uma mensagem melhor para a tela
                if (e.Message.Equals("Duplicate entry '" + dto.User + "' for key 'user_log'"))
                {
                    dto.erro = "1";
                }
                else if (e.Message.Equals("Duplicate entry '" + dto.Cpf + "' for key 'cpf_adm'"))
                {
                    dto.erro = "2";
                }
            }
        }

        public DataTable Consultar()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAdministrador", con.conectarBD());
            return Data(cmd);
        }

        

        MySqlDataReader dr;
        public DataTable buscarCpf(AdministradorDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busCliCPF(@cpf)", con.conectarBD());
            cmd.Parameters.AddWithValue("@cpf", dto.Cpf);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.User = dr[0].ToString();
                dto.Nome = dr[2].ToString();
                dto.Cpf = dr[3].ToString();
                dto.Email = dr[4].ToString();
                dto.Telefone = dr[5].ToString();
                dto.Celular = dr[6].ToString();
                dto.Cep = dr[7].ToString();
                dto.Num = dr[8].ToString();
            }
            return Data(cmd);
        }

        public DataTable buscarEmail(AdministradorDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busCliEmail(@email)", con.conectarBD());
            cmd.Parameters.AddWithValue("@email", dto.Email);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.User = dr[0].ToString();
                dto.Nome = dr[2].ToString();
                dto.Cpf = dr[3].ToString();
                dto.Email = dr[4].ToString();
                dto.Telefone = dr[5].ToString();
                dto.Celular = dr[6].ToString();
                dto.Cep = dr[7].ToString();
                dto.Num = dr[8].ToString();
            }
            return Data(cmd);
        }

        public DataTable buscarNome(AdministradorDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busCli(@nome)", con.conectarBD());
            cmd.Parameters.AddWithValue("@nome", dto.Nome);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.User = dr[0].ToString();
                dto.Nome = dr[2].ToString();
                dto.Cpf = dr[3].ToString();
                dto.Email = dr[4].ToString();
                dto.Telefone = dr[5].ToString();
                dto.Celular = dr[6].ToString();
                dto.Cep = dr[7].ToString();
                dto.Num = dr[8].ToString();
            }
            return Data(cmd);
        }

        public void atualizar(AdministradorDTO dto) {
            MySqlCommand cmd = new MySqlCommand("update tbAdministrador set nome_adm=@Nome, cpf_adm=@cpf, tel_adm=@tel, email_adm=@email, cel_adm = @cel, CepAdm=@cep, admnum_end = @num where cpf_adm = @cpf", con.conectarBD());
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

        public void deletar(AdministradorDTO dto) {
            MySqlCommand cmd = new MySqlCommand("delete from tbAdministrador where cpf_adm = @cpf", con.conectarBD());
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
    }
}