using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conexiones
{
    public class ConnectionDB
    {
        private SqlConnection Conexion = new SqlConnection("Data Source = localhost; Initial Catalog = IICISIV2024; Persist Security Info = True; User ID = usrrh; Password = 12345");
        public SqlConnection openSqlConnection()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed) Conexion.Open();
            return Conexion;    
        }

        public SqlConnection closeSqlConnection()
        {
            if (Conexion.State == System.Data.ConnectionState.Open) Conexion.Close();
            return Conexion;
        }
    }
}