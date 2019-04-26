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
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=dbAnubis;user=root;pwd=1234567");

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