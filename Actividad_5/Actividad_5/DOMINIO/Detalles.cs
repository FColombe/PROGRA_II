using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DOMINIO
{
    public class Detalles
    {
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }

        public Factura Factura { get; set; }

        public Detalles()
        {
            Articulo = new Articulo();
            Cantidad = 0;
            Factura = new Factura();
        }

        public override string ToString()
        {
            return "Artículo: " + Articulo.Nombre + " Cantidad: " + Cantidad + " Precio unitario:  $" + Articulo.PreUnitario;
        }

        public double SubTotal()     //Calcula el subtotal de cada renglón en la factura; el total de la factura es la suma de los Subtotales
        {
            return Cantidad * Articulo.PreUnitario;
        }
    }
}
