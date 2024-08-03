using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributos
{
    public class MensajeRespuesta
    {
        public int Codigo { get; set; }

        public string Mensaje { get; set; }

        public object Contenido = new object();
    }
}
