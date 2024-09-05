using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DOMINIO
{
    public class Factura
    {
        public int Nro { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public Forma_Pago FormaPago { get; set; }
        public bool Estado { get; set; }
        public List<Detalles> Detalles { get; set; }   //Se modela como "TIENE UN"; NO es igual que en el DER

        public Factura()
        {
            Nro = 0;
            Cliente = new Cliente();
            Fecha = DateTime.Now;
            FormaPago = new Forma_Pago();
            Estado = true;
            Detalles = new List<Detalles>();
        }

        public string ConvertEstado()
        {
            var estado = "";
            if (Estado)
            {
                estado = "ACTIVO";
            }
            else
            {
                estado = "ANULADA";
            }
            return estado;
        }
        public override string ToString()
        {
            return Nro + " | " + Fecha + " | " + Cliente.Apellido + ", " + Cliente.Nombre + " | " + FormaPago.Nombre + " | " + ConvertEstado();
        }

        public double Total()
        {
            double total = 0;
            foreach (Detalles d in Detalles)
            {
                total += d.SubTotal();
            }
            return total;
        }
    }
}
