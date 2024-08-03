using APIAeropuerto.Models;
using Atributos;
using Negocio;
using System.Web.Http;
using System.Web.Http.Cors;


namespace APIAeropuerto.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class APIPasajerosController : ApiController
    {
        private NegPasajeros _negPasajeros = new NegPasajeros();

        private readonly NegPasajeros _pasajeroService;

        public APIPasajerosController()
        {
            _pasajeroService = new NegPasajeros();
        }
        /*Endpoints*/

        [Route("api/ApiPasajeros/ObtenerPasajero")]
        [HttpGet]
        public IHttpActionResult ObtenerPasajero(int id)
        {
            // Lógica para obtener el pasajero
            var pasajero = _pasajeroService.ObtenerPasajero(id); 

            if (pasajero != null)
            {
                return Ok(pasajero);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("api/ApiPasajeros/InsertarPasajero")]
        [HttpPost]
        public IHttpActionResult NuevoPasajero([FromBody] Pasajero pasajero)
        {
            NegPasajeros P = new NegPasajeros();
            return Ok(P.Insertar(pasajero));
        }

        
        [Route("api/ApiPasajeros/ConsultaPasajero")]
        [HttpGet]
        public IHttpActionResult ConsultaPasajero([FromUri] ConsultarPasajeroRequest pasajero)
        {
            if (pasajero == null)
            {
                return BadRequest("La solicitud no puede ser nula.");
            }
            var respuesta = _negPasajeros.ConsultarPasajero(pasajero.NombrePasajero, pasajero.NombrePais);
            return Ok(respuesta);
        }


        [Route("api/ApiPasajeros/ModificarPasajero")]
        [HttpPut]
        public IHttpActionResult ModificarPasajero([FromBody] Pasajero pasajero)
        {
            NegPasajeros P = new NegPasajeros();
            MensajeRespuesta respuesta = P.Modificar(pasajero);
            return Ok(respuesta);
        }


        [Route("api/ApiPasajeros/EliminarPasajero")]
        [HttpDelete]
        public IHttpActionResult EliminarPasajero([FromBody] Pasajero pasajero)
        {
            NegPasajeros P = new NegPasajeros();
            MensajeRespuesta respuesta = P.Eliminar(pasajero.ID_Pasajero);
            return Ok(P.Eliminar(pasajero.ID_Pasajero));     
        }
    }
}