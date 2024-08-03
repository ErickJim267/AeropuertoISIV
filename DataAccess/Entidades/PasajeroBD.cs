using Atributos;
using DataAccess.Conexiones;
using System;
using System.CodeDom;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace DataAccess.Entidades
{
    public class PasajeroBD
    {
        ConnectionDB Cn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        /*Repositorio del Pasajero*/
        public Pasajero ObtenerPasajero(int idPasajero)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                using (SqlConnection connection = Cn.openSqlConnection())
                {
                    SqlCommand command = new SqlCommand("ObtenerPasajero", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdPasajero", idPasajero);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Pasajero pasajero = new Pasajero
                        {
                            ID_Pasajero = (int)reader["ID_Pasajero"],
                            Nombre_Pasajero = (string)reader["Nombre_Pasajero"],
                            Pasaporte = (string)reader["Pasaporte"],
                            Pais = new Pais { Nombre_Pais = (string)reader["Nombre_Pais"] }
                        };

                        return pasajero;
                    }
                }
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -1;
                Rpta.Mensaje = "Hubo un inconveniente para consultar la información. " + ex;
            }
            finally
            {
                Cn.closeSqlConnection();
            }

            return null;
        }

        /*INSERTAR*/
        public MensajeRespuesta NuevoPasajero(Pasajero P)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "NuevoPasajero";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NomPasajero", P.Nombre_Pasajero);
                cmd.Parameters.AddWithValue("@Pais", P.ID_Pais);
                cmd.Parameters.AddWithValue("@Pasaporte", P.Pasaporte);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "El Pasajero se agregó a los registros satisfactoriamente.";
                Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -1;
                Rpta.Mensaje = "Se ha presentado un inconveniente al insertar el registro de pasajero" + ex.Message;
            }
            finally
            {
                Cn.closeSqlConnection();

            }
            return Rpta;
        }
        /*MODIFICAR -no retorna nada-*/
        public MensajeRespuesta ModificarPasajero(Pasajero pasajero)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarPasajero";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPasajero", pasajero.ID_Pasajero);
                cmd.Parameters.AddWithValue("@NombrePasajero", pasajero.Nombre_Pasajero);
                cmd.Parameters.AddWithValue("@IdPais", pasajero.ID_Pais);
                cmd.Parameters.AddWithValue("@Pasaporte", pasajero.Pasaporte);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "Pasajero modificado correctamente.";
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -1;
                Rpta.Mensaje = "Se ha presentado un inconveniente al modificar el registro de pasajero: " + ex.Message;
            }
            finally
            {
                Cn.closeSqlConnection();
            }
            return Rpta;
        }
        /*CONSULTAR*/
        public MensajeRespuesta ConsultarPasajero(string nombrePasajero, string nombrePais)
        {
            MensajeRespuesta respuesta = new MensajeRespuesta();

            try
            {                
                {
                    using (SqlCommand cmd = new SqlCommand("ConsultaPasajero"))
                    {
                        cmd.Connection = Cn.openSqlConnection();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreCli", nombrePasajero);
                        cmd.Parameters.AddWithValue("@NomPais", nombrePais);                      

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    reader.Read();
                                }
                            }
                            else
                            {
                                respuesta.Codigo = 0;
                                respuesta.Mensaje = "No se encontraron registros.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se ha presentado un inconveniente al consultar el registro de pasajero: " + ex.Message;
            }

            return respuesta;
        }

        /*ELIMINAR -No retorna nada-*/
        public MensajeRespuesta EliminarPasajero(int eliminarPasajero_ID)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "EliminarPasajero";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eliminarPasajero_ID", eliminarPasajero_ID);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "Pasajero Eliminado de los registros";
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -1;
                Rpta.Mensaje = "Se ha presentado un inconveniente al eliminar el registro de pasajero" + ex.Message;
            }
            finally
            {
                Cn.closeSqlConnection();
            }
            return Rpta;
        }
    }
}
