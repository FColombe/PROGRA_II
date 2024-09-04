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
        public Forma_Pago FormaPago { get; set; } 
        public List<Detalles> Detalles { get; set; }   //Se modela como "TIENE UN"; NO es igual que en el DER

        public Factura() 
        {
            Nro = 0;
            Cliente = new Cliente();
            Fecha = DateTime.Now;
            FormaPago = new Forma_Pago();      
            Detalles = new List<Detalles>();    
        }

        public override string ToString()
        {
            return Nro + " | " + Cliente.Apellido + " | " + Fecha + " | " + FormaPago.Nombre;
        }

        public void AgregarDetalle(Detalles detalle)   //Métodos propios de la clase: suma o resta detalles en la lista
        {
            Detalles.Add(detalle);
        }

        public void EliminarDetalle(int id)
        {
            Detalles.RemoveAt(id);
        }

        public double Total()
        {
            double total = 0;  
            foreach(Detalles d in Detalles)
            {
                total += d.SubTotal();
            }
            return total;
        }
    }
}
