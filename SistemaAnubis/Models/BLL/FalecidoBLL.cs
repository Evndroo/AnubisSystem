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
            MySqlCommand cmd = new MySqlCommand("call inserirFal(@responsavel,@nome,@nascimento,@falecimento,@circunferencia,@altura)", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Codigo;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
            cmd.Parameters.Add("@nascimento", MySqlDbType.VarChar).Value = dto.Nascimento;
            cmd.Parameters.Add("@falecimento", MySqlDbType.VarChar).Value = dto.Falecimento;
            cmd.Parameters.Add("@circunferencia", MySqlDbType.VarChar).Value = dto.Circunferencia;
            cmd.Parameters.Add("@altura", MySqlDbType.VarChar).Value = dto.Altura;
            cmd.Parameters.Add("@responsavel", MySqlDbType.VarChar).Value = dto.Responsavel;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
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
            MySqlCommand cmd = new MySqlCommand("select * from tbFalecido where cpf_fal = @cpf", con.conectarBD());
            cmd.Parameters.AddWithValue("@cpf", dto.Codigo);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                dto.Codigo = dr[0].ToString();
                dto.Nome = dr[1].ToString();
                dto.Nascimento = dr[2].ToString();
                dto.Falecimento = dr[3].ToString();
                dto.Circunferencia= dr[4].ToString();
                dto.Altura = dr[5].ToString();
                dto.Plano = dr[6].ToString();
                dto.Responsavel = dr[7].ToString();
            }
            con.desconectarBD();
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
    }
}