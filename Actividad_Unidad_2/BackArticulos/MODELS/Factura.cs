using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.MODELS
{
    public class Factura
    {
        public int Nro { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public bool Estado { get; set; }
        public List<Detalle> Detalles { get; set; }   

        public Factura()
        {
            Nro = 0;
            Cliente = new Cliente();
            Fecha = DateTime.Now;
            FormaPago = new FormaPago();
            Estado = true;
            Detalles = new List<Detalle>();
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
            return Nro + " | " + Fecha.ToString("dd/MM/yyyy") + " | " + Cliente.Apellido + ", " + Cliente.Nombre + " | " + FormaPago.Nombre + " | " + ConvertEstado();
        }

        public double Total()
        {
            double total = 0;
            foreach (Detalle d in Detalles)
            {
                total += d.SubTotal();
            }
            return total;
        }
    }
}
