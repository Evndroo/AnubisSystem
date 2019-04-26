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
    public class CaixaoBLL
    {
        Conexao con = new Conexao();


        public void inserir(CaixaoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call sp_inserirCaixao(@cod,@altura,@largura,@profundidade,@modelo,@valor)", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
            cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
            cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = dto.Modelo;
            cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable Consultar(CaixaoDTO dto)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tbCaixao", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        MySqlDataReader dr;
        public void buscar(CaixaoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCaixao where ", con.conectarBD());
            cmd.Parameters.AddWithValue("@cod", dto.Codigo);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Altura = dr[1].ToString();
                dto.Largura= dr[2].ToString();
                dto.Profundidade= dr[3].ToString();
                dto.Modelo= dr[4].ToString();
                dto.Valor= dr[5].ToString();

            }
            con.desconectarBD();
        }

        public void atualizar(CaixaoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbCaixao set where ", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
            cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
            cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = dto.Modelo;
            cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;
            con.desconectarBD();

        }

        public void deletar(CaixaoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbCaixao where cod_caixao = @cod", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Codigo;

            con.desconectarBD();
        }
    }
}