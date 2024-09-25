using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DOMINIO
{
    public class Marca
    {
        public int idMarca { get; set; }
        public string Nombre { get; set; }

        public Marca()
        {
            idMarca = 0;
            Nombre = string.Empty;
        }
        public override string ToString()
        {
            return idMarca + " - " + Nombre;
        }
    }
}
