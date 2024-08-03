using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributos
{
    public class Pasajero
    {
        public int ID_Pasajero {  get; set; }
        [MaxLength(20)]
        public string Nombre_Pasajero {get; set; }
        public int ID_Pais { get; set; }
        public string Pasaporte { get; set; }

        public Pais Pais { get; set; }
    }
}
