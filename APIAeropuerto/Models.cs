using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAeropuerto.Models
{
    public class ConsultarPasajeroRequest
    {
        public string NombrePasajero { get; set; }
        public string NombrePais { get; set; }
    }
}