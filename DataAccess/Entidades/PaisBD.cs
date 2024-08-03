using Atributos;
using DataAccess.Conexiones;
using System;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Entidades
{
    public class PaisBD
    {
        ConnectionDB Cn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        /*INSERTAR*/
        public MensajeRespuesta NuevoPais (Pais P)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "NuevoPais";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombrePais", P.Nombre_Pais);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "El país se agregó a los registros satisfactoriamente.";
                Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -1;
                Rpta.Mensaje = "Se ha presentado un inconveniente al insertar el nuevo registro de país" + ex.Message;
            }
            finally 
            {
                Cn.closeSqlConnection();
            
            }          
            return Rpta;
        }
        /*MODIFICAR -no retorna nada-*/
        public MensajeRespuesta ModificarPais(Pais P)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarPais";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPais", P.ID_Pais);
                cmd.Parameters.AddWithValue("@NombrePais", P.Nombre_Pais);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "El país se modificó satisfactoriamente.";
                Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -1;
                Rpta.Mensaje = "Se ha presentado un inconveniente al modificar el registro de país" + ex.Message;
            }
            finally            
            {
                Cn.closeSqlConnection();
            }
            return Rpta;
        }
        /*CONSULTAR*/
        public MensajeRespuesta ConsultarPais(string buscarPais)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultarPais";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscarPais", buscarPais);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "Consulta exitosa.";
                Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -1;
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el registro de país" + ex.Message;
            }
            finally
            {
                Cn.closeSqlConnection();
            }
            return Rpta;
        }
        /*ELIMINAR -No retorna nada-*/
        public MensajeRespuesta EliminarPais(int eliminarPais_ID)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "EliminarPais";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eliminarPais_ID", eliminarPais_ID);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "El país se eliminó de los registros satisfactoriamente.";
                Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -1;
                Rpta.Mensaje = "Se ha presentado un inconveniente al eliminar el registro de país" + ex.Message;
            }
            finally
            {
                Cn.closeSqlConnection();
            }
            return Rpta;
        }
    }
}