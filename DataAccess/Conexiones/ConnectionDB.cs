using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DataAccess.Conexiones
{
    public class ConnectionDB
    {
        private SqlConnection Conexion = new SqlConnection("Data Source=DESKTOP-9JI62JQ\\SQLEXPRESS;Initial Catalog=ISIV;Integrated Security=True;");
        
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