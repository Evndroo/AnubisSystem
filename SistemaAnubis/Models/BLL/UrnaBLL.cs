using MySql.Data.MySqlClient;
using SistemaAnubis.Models.DAL;
using SistemaAnubis.Models.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.BLL
{
    public class UrnaBLL
    {
        Conexao con = new Conexao();


        public bool inserir(UrnaDTO dto)
        {
            try
            {
                if (MvcApplication.Session.Instance.Nvl == "1")
                {
                    MySqlCommand cmd = new MySqlCommand("call inserirUrna(null,@nome,@altura,@largura,@profundidade,@descricao,@valor,null,@dono)", con.conectarBD());
                    
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
                    cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
                    cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
                    cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
                    cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
                    cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;
                    cmd.Parameters.Add("@dono", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Nome;
                    int i = cmd.ExecuteNonQuery();

                }
                else if ((MvcApplication.Session.Instance.Nvl == "2"))
                {
                    MySqlCommand cmd = new MySqlCommand("call inserirUrna(null,@nome,@altura,@largura,@profundidade,@descricao,@valor,@dono,null)", con.conectarBD());
                    
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
                    cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
                    cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
                    cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
                    cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
                    cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;
                    cmd.Parameters.Add("@dono", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Nome;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("call inserirUrna(@dono,@nome,@altura,@largura,@profundidade,@descricao,@valor,null,null)", con.conectarBD());
                    cmd.Parameters.Add("@dono", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Codigo;
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
                    cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
                    cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
                    cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
                    cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
                    cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;
                    cmd.ExecuteNonQuery();
                }

                con.desconectarBD();
                return true;
            }
            catch(Exception e) {
                return false;
            }
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
        public List<UrnaDTO> buscar(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbUrna", con.conectarBD());
            //cmd.Parameters.AddWithValue("@nome", dto.Nome);
            dr = cmd.ExecuteReader();

            List<UrnaDTO> array = new List<UrnaDTO>();
            

            while (dr.Read())
            {
                UrnaDTO dto1 = new UrnaDTO();
                dto1.Codigo = dr[0].ToString();
                dto1.Nome = dr[1].ToString();
                dto1.Altura = dr[2].ToString();
                dto1.Largura = dr[3].ToString();
                dto1.Profundidade = dr[4].ToString();
                dto1.Descricao = dr[5].ToString();
                dto1.Valor = dr[6].ToString();
                array.Add(dto1);
            }
            con.desconectarBD();
            dto.arrayU = array;
            return array;
        }

        public void atualizar(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call upUrna(@antiga,@modelo,@altura,@largura,@profundidade,@descricao,@valor);", con.conectarBD());
            cmd.Parameters.Add("@antiga", MySqlDbType.VarChar).Value = UrnaDTO.Antiga;
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
            cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
            cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
            cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
            cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;
            cmd.ExecuteNonQuery();
            con.desconectarBD();

        }

        public DataTable BuscarUrnaGrid(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busUrnaAs(@modelo)", con.conectarBD());
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = dto.Nome;
            return Data(cmd);

        }

        public void deletar(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call delUrna(@mod)", con.conectarBD());
            cmd.Parameters.Add("@mod", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public string BuscarCodigo(string urna)
        {
            MySqlCommand cmd = new MySqlCommand("select cod_urna from tburna where modelo_urna = @modelo", con.conectarBD());
            cmd.Parameters.Add("@modelo",MySqlDbType.VarChar).Value = urna;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr[0].ToString();
            }
            else return "Urna não encontrada";
        }

        internal void achar(UrnaDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busUrna(@modelo)", con.conectarBD());
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = dto.Nome;
            dr = cmd.ExecuteReader();

            if (dr.Read()) {
                dto.Nome = dr[0].ToString();
                dto.Altura = dr[1].ToString();
                dto.Largura = dr[2].ToString();
                dto.Profundidade = dr[3].ToString();
                dto.Descricao = dr[4].ToString();
                dto.Valor= dr[5].ToString();
            }
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
    }
}