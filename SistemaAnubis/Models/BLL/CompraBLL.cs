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
    public class CompraBLL
    {
        Conexao con = new Conexao();


        public void inserir(CompraDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call sp_inserirCompra(@user, @senha, nome)", con.conectarBD());
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dto.Cliente;
            cmd.Parameters.Add("@plano", MySqlDbType.VarChar).Value = dto.Plano;
            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = dto.Data;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable Consultar(CompraDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCompra", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        MySqlDataReader dr;
        public void buscar(CompraDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCompra where cpf_adm = @cli", con.conectarBD());
            cmd.Parameters.AddWithValue("@cli", dto.Cliente);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Cliente = dr[0].ToString();
                dto.Plano = dr[1].ToString();
                dto.Data = dr[2].ToString();

            }
            con.desconectarBD();
        }

        public void atualizar(CompraDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbCompra set nome_adm=@Nome, cpf_adm=@cpf, tel_adm=@tel, email_adm=@email, cel_adm = @cel, CepAdm=@cep, admnum_end = @num where cpf_adm = @cpf", con.conectarBD());
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dto.Cliente;
            cmd.Parameters.Add("@plano", MySqlDbType.VarChar).Value = dto.Plano;
            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = dto.Data;
            
            cmd.ExecuteNonQuery();
            con.desconectarBD();

        }

        public void deletar(CompraDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbCompra where cod_cli = @cod and cod_plano=@plano", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Cliente;
            cmd.Parameters.Add("@plano", MySqlDbType.VarChar).Value = dto.Plano;

            con.desconectarBD();
        }
    }
}