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
    public class UrnaBLL
    {
        Conexao con = new Conexao();


        public void inserir(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirUrna(@nome,@altura,@largura,@profundidade,@descricao,@valor)", con.conectarBD());
            cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
            cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
            cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
            cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable Consultar(UrnaDTO dto)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tbUrna", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        MySqlDataReader dr;
        public void buscar(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbUrna where cpf_adm = @cpf", con.conectarBD());
            //cmd.Parameters.AddWithValue("@cpf", dto.C);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Altura = dr[1].ToString();
                dto.Largura = dr[2].ToString();
                dto.Profundidade = dr[3].ToString();
                dto.Nome = dr[4].ToString();
                dto.Valor = dr[5].ToString();
            }
            con.desconectarBD();
        }

        public void atualizar(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbCaixao set where ", con.conectarBD());
            cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
            cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
            cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;
            con.desconectarBD();

        }

        public void deletar(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbUrna where cpf_adm = @cpf", con.conectarBD());
            //cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = dto.Codigo;

            con.desconectarBD();
        }
    }
}