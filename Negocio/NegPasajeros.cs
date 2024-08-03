using Atributos;
using DataAccess.Entidades;
using System;

namespace Negocio
{
    public class NegPasajeros
    {
        private readonly PasajeroBD _pasajeroBD;

        public NegPasajeros()
        {
            _pasajeroBD = new PasajeroBD();
        }
        public NegPasajeros(PasajeroBD pasajeroBD)
        {
            _pasajeroBD = pasajeroBD;
        }

        public MensajeRespuesta ObtenerPasajero(int idPasajero)
        {
            try
            {
                Pasajero pasajero = _pasajeroBD.ObtenerPasajero(idPasajero);

                if (pasajero != null)
                {
                    return new MensajeRespuesta { Codigo = 0, Contenido = pasajero };
                }
                else
                {
                    return new MensajeRespuesta { Codigo = -1, Mensaje = "Pasajero no encontrado. " };
                }
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Error al obtener el pasajero: " + ex.Message };
            }
        }
        public MensajeRespuesta Insertar(Pasajero pasajero)
        {
            if (!IsValidPasajero(pasajero))
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Datos de pasajero incorrectos" };
            }
            try
            {
                return _pasajeroBD.NuevoPasajero(pasajero);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Error al ingresar nuevo Pasajero" };
            }
        }
        public MensajeRespuesta Eliminar(int idPasajero)
        {
            if (idPasajero <= 0)
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "ID pasajero incorrecto" };
            }

            try
            {
                return _pasajeroBD.EliminarPasajero(idPasajero);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Error al eliminar Pasajero" };
            }
        }
        public MensajeRespuesta Modificar(Pasajero ParametroPasajero)
        {
            try
            {
                if (ParametroPasajero.ID_Pasajero < 1 || String.IsNullOrEmpty(ParametroPasajero.Nombre_Pasajero))
                {
                    return new MensajeRespuesta { Codigo = -4, Mensaje = "Debe ingresar un ID y nombre de pasajero correcto" };
                }
                PasajeroBD PasajeroRef = new PasajeroBD();
                return PasajeroRef.ModificarPasajero(ParametroPasajero);
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Se prensentó un inconveniente al modificar Pasajero: " + ex.Message };
            }
        }
        public MensajeRespuesta ConsultarPasajero(string nombrePasajero, string nombrePais)
        {
            try
            {
                PasajeroBD PasajeroRef = new PasajeroBD();
                return PasajeroRef.ConsultarPasajero(nombrePasajero, nombrePais);
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Se ha presentado un inconveniente al consultar el registro de pasajero: " + ex.Message };
            }
        }
        private bool IsValidPasajero(Pasajero pasajero)
        {
            return !string.IsNullOrEmpty(pasajero.Nombre_Pasajero)
                   && pasajero.ID_Pais > 0
                   && !string.IsNullOrEmpty(pasajero.Pasaporte)
                   && pasajero.ID_Pasajero > 0 // Ejemplo de validación adicional
                   && pasajero.Nombre_Pasajero.Length <= 70; // Ejemplo de validación de longitud
        }
    }
}
