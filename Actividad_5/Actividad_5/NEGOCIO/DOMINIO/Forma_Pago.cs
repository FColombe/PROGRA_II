using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.NEGOCIO.DOMINIO
{
    public class Forma_Pago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Recargo { get; set; }


        public override string ToString()
        {
            return Id + " | " + Nombre + " | " + Recargo + " %";
        }
    }
}
