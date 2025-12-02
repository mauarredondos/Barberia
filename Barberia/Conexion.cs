using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Barberia
{
    public static class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            string cadena = "Server=localhost;Database=barberia;Uid=root;Pwd=;";
            return new MySqlConnection(cadena);
        }
    }
}