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
    public class FalecidoBLL
    {
        Conexao con = new Conexao();


        public void inserir(FalecidoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirFal(@responsavel,@nome,@nascimento,@falecimento,null)", con.conectarBD());
            cmd.Parameters.Add("@responsavel", MySqlDbType.VarChar).Value = dto.Responsavel;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@nascimento", MySqlDbType.VarChar).Value = dto.Nascimento;
            cmd.Parameters.Add("@falecimento", MySqlDbType.VarChar).Value = dto.Falecimento;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public List<FalecidoDTO> ListarByResp() {
            List<FalecidoDTO> list = new List<FalecidoDTO>();

            MySqlCommand cmd = new MySqlCommand("select * from tbFalecido where cod_cli = @resp;", con.conectarBD());
            cmd.Parameters.Add("@resp", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Codigo;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FalecidoDTO inst = new FalecidoDTO();
                inst.Codigo = dr[0].ToString();
                inst.Responsavel = dr[1].ToString();
                inst.Nome = dr[2].ToString();
                inst.Nascimento = dr[3].ToString();
                inst.Falecimento = dr[4].ToString();
                list.Add(inst);
            }
            con.desconectarBD();
            return list;
        }


        public List<FalecidoDTO> Listar()
        {
            List<FalecidoDTO> list = new List<FalecidoDTO>();

            MySqlCommand cmd = new MySqlCommand("select * from tbFalecido", con.conectarBD());
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FalecidoDTO inst = new FalecidoDTO();
                inst.Codigo = dr[0].ToString();
                inst.Responsavel = dr[1].ToString();
                inst.Nome = dr[2].ToString();
                inst.Nascimento= dr[3].ToString();
                inst.Falecimento= dr[4].ToString();
                list.Add(inst);
            }            
            con.desconectarBD();
            return list;
        }

        public DataTable Consultar(FalecidoDTO dto)
        {

            MySqlCommand cmd = new MySqlCommand("select * from tbFalecido", con.conectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable agenda = new DataTable();
            da.Fill(agenda);
            con.desconectarBD();
            return agenda;
        }


        MySqlDataReader dr;
        public void buscar(FalecidoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbFalecido where nome_fal = @nome", con.conectarBD());
            cmd.Parameters.AddWithValue("@nome", dto.Nome);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Nome = dr[2].ToString();
                dto.Nascimento = dr[3].ToString();
                dto.Falecimento = dr[4].ToString();
            }
            con.desconectarBD();
        }


        public DataTable bucaFalNome(FalecidoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select nome_fal as 'Nome', nasc_fal as 'Nascimento', data_fal as 'Falescimento' from tbFalecido where nome_fal = @nome", con.conectarBD());
            cmd.Parameters.AddWithValue("@nome", dto.Nome);
            return Data(cmd);
        }

        public void atualizar(FalecidoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbFalecido set nome_fal=@Nome, cpf_fal=@cpf, tel_fal=@tel, email_fal=@email, cel_fal = @cel, Cepfal=@cep, falnum_end = @num where cod_fal = @cod", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@nascimento", MySqlDbType.VarChar).Value = dto.Nascimento;
            cmd.Parameters.Add("@falecimento", MySqlDbType.VarChar).Value = dto.Falecimento;
            cmd.Parameters.Add("@circunferencia", MySqlDbType.VarChar).Value = dto.Circunferencia;
            cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
            cmd.Parameters.Add("@plano", MySqlDbType.VarChar).Value = dto.Plano;
            cmd.Parameters.Add("@responsavel", MySqlDbType.VarChar).Value = dto.Responsavel;
            con.desconectarBD();

        }

        public void deletar(FalecidoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("call delFalecido(cod)", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Codigo;

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