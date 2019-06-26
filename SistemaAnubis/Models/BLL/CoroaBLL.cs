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


        public bool inserir(CoroaDTO dto)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("call inserirCoroa(@especie,@tipo,@circunferencia,@descricao,@val)", con.conectarBD());
                cmd.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = dto.Codigo;
                cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = dto.Tipo;
                cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = dto.Especie;
                cmd.Parameters.Add("@circunferencia", MySqlDbType.VarChar).Value = dto.Circunferencia;
                cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
                cmd.Parameters.Add("@val", MySqlDbType.VarChar).Value = dto.Valor;

                cmd.ExecuteNonQuery();
                con.desconectarBD();
                return true;
            }
            catch {
                return false;
            }
        }

        public DataTable ConsultarGrid(CoroaDTO dto)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tbCoroa;", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }

        MySqlDataReader dr;
        public List<CoroaDTO> Consultar(CoroaDTO dto)
        {
            List<CoroaDTO> array = new List<CoroaDTO>();
            MySqlCommand cmd = new MySqlCommand("select * from tbCoroa", con.conectarBD());
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CoroaDTO dto1 = new CoroaDTO();
                dto1.Codigo = dr[0].ToString();
                dto1.Tipo = dr[1].ToString();
                dto1.Especie = dr[2].ToString();
                dto1.Circunferencia = dr[3].ToString();
                dto1.Descricao = dr[4].ToString();
                dto1.Valor = dr[5].ToString();
                array.Add(dto1);
            }
            dto.arrayCO.Add(dto);
            con.desconectarBD();
            return array;
        }

        public DataTable busCoroaGrid(CoroaDTO dto) {
            MySqlCommand cmd = new MySqlCommand("call busCoroaAs(@esp);",con.conectarBD());
            cmd.Parameters.Add("@esp",MySqlDbType.VarChar).Value = dto.Especie;
            return Data(cmd);
        }

           
        public void buscar(CoroaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busCoroa(@especie)", con.conectarBD());
            cmd.Parameters.AddWithValue("@especie", dto.Especie);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Especie = dr[0].ToString();
                dto.Tipo = dr[1].ToString();
                dto.Circunferencia = dr[2].ToString();
                dto.Descricao = dr[3].ToString();
                dto.Valor = dr[4].ToString();
            }
            con.desconectarBD();
        }

        public void atualizar(CoroaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call upCoroa(@especie,@especie,@tipo,@circunferencia,@desccricao)", con.conectarBD());
            cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = dto.Especie;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = dto.Tipo;
            cmd.Parameters.Add("@circunferencia", MySqlDbType.VarChar).Value = dto.Circunferencia;
            cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
            con.desconectarBD();

        }

        public void deletar(CoroaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call delCoroa(@esp)", con.conectarBD());
            cmd.Parameters.Add("@esp", MySqlDbType.VarChar).Value = dto.Especie ;
            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public string BuscarCodigo(string coroa)
        {
            throw new NotImplementedException();
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
    }
}