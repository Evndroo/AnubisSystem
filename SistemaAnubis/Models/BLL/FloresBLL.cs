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
    public class FloresBLL
    {
        Conexao con = new Conexao();


        public bool inserir(FloresDTO dto)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("call inserirFlores(@especie,@tipo,@quantidade,@val)", con.conectarBD());
                cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = dto.Especie;
                cmd.Parameters.Add("@quantidade", MySqlDbType.VarChar).Value = dto.Quantidade;
                cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = dto.Tipo;
                cmd.Parameters.Add("@val", MySqlDbType.VarChar).Value = dto.Valor;

                cmd.ExecuteNonQuery();
                con.desconectarBD();
                return true;
            }
            catch {
                return false;
            }
        }

        public DataTable buscarG(FloresDTO dto) {
            MySqlCommand cmd = new MySqlCommand("call busFlorAs(@esp);", con.conectarBD());
            cmd.Parameters.Add("@esp", MySqlDbType.VarChar).Value = dto.Especie;
            return Data(cmd);
        }

        public List<FloresDTO> Consultar(FloresDTO dto)
        {
            List<FloresDTO> array = new List<FloresDTO>();
            MySqlCommand cmd = new MySqlCommand("select * from tbFlores", con.conectarBD());
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FloresDTO dto1 = new FloresDTO();
                dto1.Codigo = dr[0].ToString();
                dto1.Especie = dr[1].ToString();
                dto1.Quantidade = dr[2].ToString();
                dto1.Tipo = dr[3].ToString();
                dto1.Valor = dr[4].ToString();
                array.Add(dto1);
            }
            dto.arrayF = array;
            con.desconectarBD();
            return array;
        }


        MySqlDataReader dr;
        public void buscar(FloresDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbFlores where especie_flor = @esp", con.conectarBD());
            cmd.Parameters.Add("@esp", MySqlDbType.VarChar).Value = dto.Especie;
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
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
            MySqlCommand cmd = new MySqlCommand("call delFlores(@especie)", con.conectarBD());
            cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = dto.Especie;

            con.desconectarBD();
        }

        string BuscarCodigo(string flor)
        {
            MySqlCommand cmd = new MySqlCommand("select cod_flor from tbFlores where especie_flor = @especie", con.conectarBD());
            cmd.Parameters.Add("@especie", MySqlDbType.VarChar).Value = flor;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr[0].ToString();
            }
            else return "Flor não encontrada";
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