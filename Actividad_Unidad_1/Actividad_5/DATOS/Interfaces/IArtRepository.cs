using Actividad_5.DOMINIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Interfaces
{
    interface IArtRepository
    {
        List<Articulo> ConsultarTodos();
        Articulo ConsultarPorId(int id);
        bool Grabar(Articulo articulo);
        bool Borrar(int id);
    }
}
