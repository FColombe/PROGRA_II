using Actividad_5.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Interfaces
{
    interface IFacturaRepository
    {
        List<Factura> ConsultarTodos();
        Factura ConsultarPorId(int id);
        List<Factura> ConsultarFactEstado(string estado);
        bool Grabar(Factura factura);
        bool Borrar(int nro);
    }
}
