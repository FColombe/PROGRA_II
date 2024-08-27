using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.NEGOCIO.DOMINIO
{
    public class Factura
    {
        public int Nro {  get; set; }
        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public Forma_Pago Forma_Pago { get; set; }

        public Factura() 
        { 
            Nro = 0;
            Cliente = null;
            Fecha = DateTime.Today;
            Forma_Pago = null;
        }
    }
}
