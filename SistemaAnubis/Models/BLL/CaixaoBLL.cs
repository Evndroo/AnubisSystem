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


        public bool inserir(CaixaoDTO dto)
        {
            try
            {
                if (MvcApplication.Session.Instance.Nvl == "1")
                {
                    MySqlCommand cmd = new MySqlCommand("call inserirCaixao(null,@modelo,@altura,@largura,@profundidade,@descricao,@valor,null,@dono);", con.conectarBD());
                    cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = dto.Modelo;
                    cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
                    cmd.Parameters.Add("@largura", MySqlDbType.VarChar).Value = dto.Largura;
                    cmd.Parameters.Add("@profundidade", MySqlDbType.VarChar).Value = dto.Profundidade;
                    cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = dto.Descricao;
                    cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = dto.Valor;
                    cmd.Parameters.Add("@dono", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Nome;
                    cmd.ExecuteNonQuery();
                }
                else if ((MvcApplication.Session.Instance.Nvl == "2"))
                {
                    MySqlCommand cmd = new MySqlCommand("call inserirCaixao(null,@nome,@altura,@largura,@profundidade,@descricao,@valor,@dono,null)", con.conectarBD());

                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Modelo;
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
                    MySqlCommand cmd = new MySqlCommand("call inserirCaixao(@dono,@nome,@altura,@largura,@profundidade,@descricao,@valor,null,null)", con.conectarBD());
                    cmd.Parameters.Add("@dono", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Codigo;
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Modelo;
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
            catch
            {
                return false;
            }
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
        public List<CaixaoDTO> buscar(CaixaoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCaixao", con.conectarBD());
            //cmd.Parameters.AddWithValue("@modelo", dto.Modelo);
            List<CaixaoDTO> array = new List<CaixaoDTO>();
            dr = cmd.ExecuteReader(CommandBehavior.Default);

            while (dr.Read())
            {
                CaixaoDTO inst = new CaixaoDTO();
                inst.Codigo = dr[0].ToString();
                inst.Modelo= dr[1].ToString();
                inst.Altura = dr[2].ToString();
                inst.Largura= dr[3].ToString();
                inst.Profundidade= dr[4].ToString();
                inst.Descricao = dr[5].ToString();
                inst.Valor= dr[6].ToString();
                array.Add(inst);
            }
            dto.arrayC = array;
            con.desconectarBD();
            return array;
        }

        public void atualizar(CaixaoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call upCaixao(@modelo,@modelo,@altura,@largura,@profundidade,@valor)", con.conectarBD());
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
            MySqlCommand cmd = new MySqlCommand("call delCaixao(@codigo)", con.conectarBD());
            cmd.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = dto.Codigo;

            con.desconectarBD();
        }

        public DataTable BusscarGrid(CaixaoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call busCaixaoAs(@modelo);", con.conectarBD());
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = dto.Modelo;
            return Data(cmd);
        }

        public string BuscarCodigo(string caixao)
        {
            MySqlCommand cmd = new MySqlCommand("select cod_caixao from tbcaixao where modelo_caixao = @modelo", con.conectarBD());
            cmd.Parameters.Add("@modelo",MySqlDbType.VarChar).Value = caixao;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr[0].ToString();
            }
            else return "Caixão não encontrado";
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

        public void buscarModelo(CaixaoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCaixao where modelo_caixao = @mod", con.conectarBD());
            cmd.Parameters.Add("@mod", MySqlDbType.VarChar).Value = dto.Modelo;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Modelo = dr[1].ToString();
                dto.Altura = dr[2].ToString();
                dto.Largura = dr[3].ToString();
                dto.Profundidade = dr[4].ToString();
                dto.Descricao = dr[5].ToString();
                dto.Valor = dr[6].ToString();               
            }
            con.desconectarBD();
        }
    }
}