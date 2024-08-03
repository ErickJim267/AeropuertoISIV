using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Atributos
{
    public class Pais
    {
        public int ID_Pais { get; set; }

        [MaxLength(20)]
        public string Nombre_Pais { get; set; }

    }
}
