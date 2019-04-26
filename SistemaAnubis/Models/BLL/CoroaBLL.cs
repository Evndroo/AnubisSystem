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
    public class CoroaBLL
    {
        Conexao con = new Conexao();


        public void inserir(CoroaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call sp_inserirCoroa(@codigo,@tipo,@especie,@circunferencia,@descricao)", con.conectarBD());
            cmd.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = dto.Tipo;
            cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = dto.Especie;
            cmd.Parameters.Add("@circunferencia", MySqlDbType.VarChar).Value = dto.Circunferencia;
            cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable Consultar(CoroaDTO dto)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tbCoroa", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        MySqlDataReader dr;
        public void buscar(CoroaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCoroa where cpf_adm = @codigo", con.conectarBD());
            cmd.Parameters.AddWithValue("@codigo", dto.Codigo);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Tipo = dr[1].ToString();
                dto.Especie = dr[2].ToString();
                dto.Circunferencia = dr[3].ToString();
                dto.Descricao = dr[4].ToString();

            }
            con.desconectarBD();
        }

        public void atualizar(CoroaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbCoroa set nome_adm=@Nome, cpf_adm=@cpf, tel_adm=@tel, email_adm=@email, cel_adm = @cel, CepAdm=@cep, admnum_end = @num where cpf_adm = @cpf", con.conectarBD());
            cmd.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = dto.Tipo;
            cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = dto.Especie;
            cmd.Parameters.Add("@circunferencia", MySqlDbType.VarChar).Value = dto.Circunferencia;
            cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
            con.desconectarBD();

        }

        public void deletar(CoroaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbCoroa where cod_coroa = @cod", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Codigo;

            con.desconectarBD();
        }
    }
}