using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.NEGOCIO.DOMINIO
{
    public class Detalles
    {

        public int ID {  get; set; }
        public Factura  Factura { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

    }
}
