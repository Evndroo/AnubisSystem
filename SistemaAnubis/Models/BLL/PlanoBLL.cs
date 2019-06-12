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

            if (MvcApplication.Session.Instance.Nvl == "3")
            {
                MySqlCommand cmd = new MySqlCommand("call inserirPlano(@nome,@dono,@caixao,@urna,@flor,@quantFlor,@coroa,@quantCoroa,@translado,@paramentacao,@necro,@lapide,@veu,@valor,null,null);", con.conectarBD());
                //MySqlCommand cmd = new MySqlCommand("call inserirPlano(nome,@dono,@caixao,@urna,@flor,@qtdFlor,@coroa,@qtdCoroa,@translado,@paramentacao,@necro,@lapide,@veu,@valor,null,null);", con.conectarBD());
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
                cmd.Parameters.Add("@dono", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Codigo;
                cmd.Parameters.Add("@caixao", MySqlDbType.VarChar).Value = dto.Caixao;
                cmd.Parameters.Add("@urna", MySqlDbType.VarChar).Value = dto.Urna;
                cmd.Parameters.Add("@flor", MySqlDbType.VarChar).Value = dto.Flor;
                cmd.Parameters.Add("@quantFlor", MySqlDbType.VarChar).Value = dto.QuantFlor;
                cmd.Parameters.Add("@coroa", MySqlDbType.VarChar).Value = dto.Coroa;
                cmd.Parameters.Add("@quantCoroa", MySqlDbType.VarChar).Value = dto.QuantCoroa;
                cmd.Parameters.Add("@translado", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@paramentacao", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@necro", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@lapide", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@veu", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = 1500;
                cmd.ExecuteNonQuery();
            }
            else if (MvcApplication.Session.Instance.Nvl == "2")
            {
                MySqlCommand cmd = new MySqlCommand("call inserirPlano(@nome,null,@caixao,@urna,@flor,@qtdFlor,@coroa,@qtdCoroa,@translado,@paramentacao,@necro,@lapide,@veu,@valor,@dono,null);", con.conectarBD());
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
                cmd.Parameters.Add("@caixao", MySqlDbType.VarChar).Value = dto.Caixao;
                cmd.Parameters.Add("@urna", MySqlDbType.VarChar).Value = dto.Urna;
                cmd.Parameters.Add("@flor", MySqlDbType.VarChar).Value = dto.Flor;
                cmd.Parameters.Add("@quantFlor", MySqlDbType.VarChar).Value = dto.QuantFlor;
                cmd.Parameters.Add("@coroa", MySqlDbType.VarChar).Value = dto.Coroa;
                cmd.Parameters.Add("@quantCoroa", MySqlDbType.VarChar).Value = dto.QuantCoroa;
                cmd.Parameters.Add("@translado", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@paramentacao", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@necro", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@lapide", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@veu", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = 1500;
                cmd.Parameters.Add("@dono", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Codigo;
                cmd.ExecuteNonQuery();
            }
            else {
                MySqlCommand cmd = new MySqlCommand("call inserirPlano(@nome,null,@caixao,@urna,@flor,@qtdFlor,@coroa,@qtdCoroa,@translado,@paramentacao,@necro,@lapide,@veu,@valor,null,@dono);", con.conectarBD());
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = dto.Nome;
                cmd.Parameters.Add("@caixao", MySqlDbType.VarChar).Value = dto.Caixao;
                cmd.Parameters.Add("@urna", MySqlDbType.VarChar).Value = dto.Urna;
                cmd.Parameters.Add("@flor", MySqlDbType.VarChar).Value = dto.Flor;
                cmd.Parameters.Add("@quantFlor", MySqlDbType.VarChar).Value = dto.QuantFlor;
                cmd.Parameters.Add("@coroa", MySqlDbType.VarChar).Value = dto.Coroa;
                cmd.Parameters.Add("@quantCoroa", MySqlDbType.VarChar).Value = dto.QuantCoroa;
                
                cmd.Parameters.Add("@translado", MySqlDbType.VarChar).Value = 0;

                
                cmd.Parameters.Add("@paramentacao", MySqlDbType.VarChar).Value = 0;
                
                cmd.Parameters.Add("@necro", MySqlDbType.VarChar).Value = 0;
                
                cmd.Parameters.Add("@lapide", MySqlDbType.VarChar).Value = 0;
                
                cmd.Parameters.Add("@veu", MySqlDbType.VarChar).Value = 0;
                cmd.Parameters.Add("@valor", MySqlDbType.VarChar).Value = 1500;
                cmd.Parameters.Add("@dono", MySqlDbType.VarChar).Value = MvcApplication.Session.Instance.Codigo;
                cmd.ExecuteNonQuery();
            }
            con.desconectarBD();
        }

        internal List<PlanoDTO> Listar()
        {

            List<PlanoDTO> list = new List<PlanoDTO>();
            //where cod_dono = @cod or cod_dono=null
            MySqlCommand cmd = new MySqlCommand("call sp_busPlano();", con.conectarBD());
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PlanoDTO inst = new PlanoDTO();
                inst.Caixao = dr[0].ToString();
                inst.Urna = dr[1].ToString();
                inst.Translado = int.Parse(dr[2].ToString());
                inst.Paramentacao = int.Parse(dr[3].ToString());
                inst.Necromaquiagem = int.Parse(dr[4].ToString());
                inst.Veu = int.Parse(dr[5].ToString());
                inst.Nome = dr[6].ToString();
                inst.Lapide = int.Parse(dr[7].ToString());
                inst.Coroa = dr[8].ToString();
                inst.QuantCoroa = dr[9].ToString();
                inst.Flor = dr[10].ToString();;
                inst.QuantFlor = dr[11].ToString();
                inst.Valor = dr[12].ToString();
                list.Add(inst);
            }
            con.desconectarBD();

            return list;
        }

        public List<PlanoDTO> Consultar(PlanoDTO dto)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbPlano", con.conectarBD());
            dr = cmd.ExecuteReader();
            List<PlanoDTO> array = new List<PlanoDTO>();

            while (dr.Read())
            {
                PlanoDTO dto1 = new PlanoDTO();
                dto1.Urna = dr[0].ToString();
                dto1.Caixao = dr[1].ToString();
                dto1.Flor = dr[2].ToString();
                dto1.QuantFlor = dr[3].ToString();
                dto1.Coroa = dr[4].ToString();
                dto1.QuantCoroa = dr[5].ToString();
                dto1.Lapide = int.Parse(dr[6].ToString());
                dto1.Necromaquiagem = int.Parse(dr[7].ToString());
                dto1.Paramentacao = int.Parse(dr[8].ToString());
                dto1.Translado = int.Parse(dr[9].ToString());
                dto1.Veu = int.Parse(dr[10].ToString());
                array.Add(dto1);
            }
            dto.arrayP = array;
            con.desconectarBD();
            return array;
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
                dto.Lapide = int.Parse(dr[6].ToString());
                dto.Necromaquiagem = int.Parse(dr[7].ToString());
                dto.Paramentacao = int.Parse(dr[8].ToString());
                dto.Translado = int.Parse(dr[9].ToString());
                dto.Veu = int.Parse(dr[10].ToString());

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
            MySqlCommand cmd = new MySqlCommand("call delPlano(@cod)", con.conectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = dto.Codigo;

            con.desconectarBD();
        }
    }
}