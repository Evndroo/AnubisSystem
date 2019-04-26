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
    public class PlanoBLL
    {
        Conexao con = new Conexao();


        public void inserir(PlanoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call sp_inserirAdm(@user,@senha,@nome,@cpf,@email,@telefone,@celular,@cep,@num)", con.conectarBD());
            cmd.Parameters.Add("@urna", MySqlDbType.VarChar).Value = dto.Urna;
            cmd.Parameters.Add("@caixao", MySqlDbType.VarChar).Value = dto.Caixao;
            cmd.Parameters.Add("@flor", MySqlDbType.VarChar).Value = dto.Flor;
            cmd.Parameters.Add("@quantF", MySqlDbType.VarChar).Value = dto.QuantFlor;
            cmd.Parameters.Add("@coroa", MySqlDbType.VarChar).Value = dto.Coroa;
            cmd.Parameters.Add("@quantC", MySqlDbType.VarChar).Value = dto.QuantCoroa;
            cmd.Parameters.Add("@lapide", MySqlDbType.VarChar).Value = dto.Lapide;
            cmd.Parameters.Add("@necro", MySqlDbType.VarChar).Value = dto.Necromaquiagem;
            cmd.Parameters.Add("@paramentacao", MySqlDbType.VarChar).Value = dto.Paramentacao;
            cmd.Parameters.Add("@translado", MySqlDbType.VarChar).Value = dto.Translado;
            cmd.Parameters.Add("@veu", MySqlDbType.VarChar).Value = dto.Veu;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable Consultar(PlanoDTO dto)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tbPlano", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        MySqlDataReader dr;
        public void buscar(PlanoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbPlano where cpf_adm = @cod", con.conectarBD());
            cmd.Parameters.AddWithValue("@cod", dto.Codigo);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                //dto.User = dr[0].ToString();
                dto.Urna = dr[0].ToString();
                dto.Caixao = dr[1].ToString();
                dto.Flor = dr[2].ToString();
                dto.QuantFlor = dr[3].ToString();
                dto.Coroa = dr[4].ToString();
                dto.QuantCoroa = dr[5].ToString();
                dto.Lapide = dr[6].ToString();
                dto.Necromaquiagem = dr[7].ToString();
                dto.Paramentacao = dr[8].ToString();
                dto.Translado = dr[9].ToString();
                dto.Veu = dr[10].ToString();

            }
            con.desconectarBD();
        }

        public void atualizar(PlanoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbPlano set nome_adm=@Nome, cpf_adm=@cpf, tel_adm=@tel, email_adm=@email, cel_adm = @cel, CepAdm=@cep, admnum_end = @num where cpf_adm = @cpf", con.conectarBD());
            cmd.Parameters.Add("@Codigo", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@urna", MySqlDbType.VarChar).Value = dto.Urna;
            cmd.Parameters.Add("@caixao", MySqlDbType.VarChar).Value = dto.Caixao;
            cmd.Parameters.Add("@flor", MySqlDbType.VarChar).Value = dto.Flor;
            cmd.Parameters.Add("@quantF", MySqlDbType.VarChar).Value = dto.QuantFlor;
            cmd.Parameters.Add("@coroa", MySqlDbType.VarChar).Value = dto.Coroa;
            cmd.Parameters.Add("@quantC", MySqlDbType.VarChar).Value = dto.QuantCoroa;
            cmd.Parameters.Add("@lapide", MySqlDbType.VarChar).Value = dto.Lapide;
            cmd.Parameters.Add("@necro", MySqlDbType.VarChar).Value = dto.Necromaquiagem;
            cmd.Parameters.Add("@paramentacao", MySqlDbType.VarChar).Value = dto.Paramentacao;
            cmd.Parameters.Add("@translado", MySqlDbType.VarChar).Value = dto.Translado;
            cmd.Parameters.Add("@veu", MySqlDbType.VarChar).Value = dto.Veu;
            con.desconectarBD();

        }

        public void deletar(PlanoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbPlano where cpf_adm = @cpf", con.conectarBD());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Codigo;

            con.desconectarBD();
        }
    }
}