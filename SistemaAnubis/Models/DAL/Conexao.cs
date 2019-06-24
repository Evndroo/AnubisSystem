using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaAnubis.Models.DAL
{
    public class Conexao
    {
        public static string msg;
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=dbAnubis;user=root;pwd=1234567;CharSet=utf8;");
        //MySqlConnection con = new MySqlConnection("server=db4free.net;Database=anubis;user=emgelf;pwd=emgelf123;Port=3306");

        public MySqlConnection conectarBD() {
            try {
                con.Open();
            }
            catch(Exception e) {
                msg = "Erro de conexão: " + e;
            }
            return con;
        }

        public MySqlConnection desconectarBD()
        {
            try
            {
                con.Close();
            }
            catch (Exception e)
            {
                msg = "Erro de desconexão: " + e;
            }
            return con;
        }
    }
}