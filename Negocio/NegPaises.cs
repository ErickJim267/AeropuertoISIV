using Atributos;
using DataAccess.Entidades;
using System;


namespace Negocio
{
    public class NegPaises
    {
        public MensajeRespuesta InsertarPais(Pais ParametroPais)
        {
            try
            {
                if (String.IsNullOrEmpty(ParametroPais.Nombre_Pais))
                {
                    return new MensajeRespuesta { Codigo = -4, Mensaje = "No puede guardar sin nombre correcto de país" };
                }
                PaisBD PaisRef = new PaisBD();
                return PaisRef.NuevoPais(ParametroPais);
            }
            catch (Exception ex)
            {
                var prueba = ex;
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Se presentó un inconveniente al crear País " };
            }
        }

        public MensajeRespuesta ModificarPais(Pais ParametroPais)
        {
            try
            {
                if (String.IsNullOrEmpty(ParametroPais.Nombre_Pais))
                {
                    return new MensajeRespuesta { Codigo = -4, Mensaje = "No puede guardar sin nombre correcto de país" };
                }
                PaisBD PaisRef = new PaisBD();
                return PaisRef.ModificarPais(ParametroPais);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Se prensentó un inconveniente al modificar País " };
            }
        }

        public MensajeRespuesta EliminarPais(int? IdPais)
        {
            try
            {
                if (IdPais < 1 || IdPais == null)
                {
                    return new MensajeRespuesta { Codigo = -4, Mensaje = "Debe ingresar un código de país correcto" };
                }
                PaisBD PaisRef = new PaisBD();
                return PaisRef.EliminarPais(IdPais.Value);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -1, Mensaje = "Se prensentó un inconveniente al eliminar País " };
            }
        }
        public MensajeRespuesta ConsultarPais(string buscarPais)
        {
            try
            {

                PaisBD PaisRef = new PaisBD();
                return PaisRef.ConsultarPais(String.IsNullOrEmpty(buscarPais) ? "" : buscarPais);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -1, Mensaje = "Se prensentó un inconveniente al consultar País" };
            }
        }
    }
}