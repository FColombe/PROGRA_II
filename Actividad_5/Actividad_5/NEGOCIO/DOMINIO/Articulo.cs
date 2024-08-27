using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.NEGOCIO.DOMINIO
{
    public class Articulo
    {
        public int CodArt {  get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public TipoArt Tipo { get; set; }
        public float Precio { get; set; }

        public Articulo() 
        { 
            CodArt = 0;
            Nombre = string.Empty;
            Marca = null;
            Tipo = null;
            Precio = 0;     
        }

        public override string ToString()
        {
            return CodArt + " | " + Nombre + " | " + Marca + " | " + Tipo + " | " + Precio;
        }

    }
}
