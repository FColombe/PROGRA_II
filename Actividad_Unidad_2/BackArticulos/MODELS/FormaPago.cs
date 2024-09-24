using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.MODELS
{
    public class FormaPago
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
