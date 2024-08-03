using Atributos;
using Negocio;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIAeropuerto.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class APIPaisesController : ApiController
    {
        /*Endpoints*/
        [Route("api/ApiPaises/ConsultarPais")]
        [HttpGet]
        public IHttpActionResult ConsultarPais(string buscarPais) 
        {
            NegPaises P = new NegPaises();
            return Ok (P.ConsultarPais(buscarPais));     
        }

        [Route("api/ApiPaises/InsertarPais")]
        [HttpPost]
        public IHttpActionResult InsertarPais([FromBody] Pais ParametroPais)
        {
            NegPaises P = new NegPaises();
            return Ok(P.InsertarPais(ParametroPais));
        }

        [Route("api/ApiPaises/ModificarPais")]
        [HttpPut]
        public IHttpActionResult ModificarPais([FromBody] Pais pais)
        {
            NegPaises P = new NegPaises();
            MensajeRespuesta respuesta = P.ModificarPais(pais);
            return Ok(P.ModificarPais(pais));
        }

        [Route("api/ApiPaises/EliminarPais")]
        [HttpDelete]
        public IHttpActionResult EliminarPais([FromBody] Pais pais)
        {
            NegPaises P = new NegPaises();
            MensajeRespuesta respuesta = P.EliminarPais(pais.ID_Pais);
            return Ok(P.EliminarPais(pais.ID_Pais));
        }


    }
}
