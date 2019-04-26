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
    public class FloresBLL
    {
        Conexao con = new Conexao();


        public void inserir(FloresDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call sp_inserirAdm(@codigo,@especie,@quantidade,@tipo)", con.conectarBD());
            cmd.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = dto.Especie;
            cmd.Parameters.Add("@quantidade", MySqlDbType.VarChar).Value = dto.Quantidade;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = dto.Tipo;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable Consultar(FloresDTO dto)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tbFlores", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        MySqlDataReader dr;
        public void buscar(FloresDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbFlores where cpf_adm = @cpf", con.conectarBD());
            cmd.Parameters.AddWithValue("@cpf", dto.Codigo);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                //dto.User = dr[0].ToString();
                dto.Codigo = dr[0].ToString();
                dto.Especie = dr[1].ToString();
                dto.Quantidade = dr[2].ToString();
                dto.Tipo = dr[3].ToString();
            }
            con.desconectarBD();
        }

        public void atualizar(FloresDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbFlores set nome_adm=@Nome, cpf_adm=@cpf, tel_adm=@tel, email_adm=@email, cel_adm = @cel, CepAdm=@cep, admnum_end = @num where cpf_adm = @cpf", con.conectarBD());
            cmd.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = dto.Especie;
            cmd.Parameters.Add("@quantidade", MySqlDbType.VarChar).Value = dto.Quantidade;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = dto.Tipo;
            con.desconectarBD();

        }

        public void deletar(FloresDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbFlores where cpf_adm = @cpf", con.conectarBD());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Codigo;

            con.desconectarBD();
        }
    }
}