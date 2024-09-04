using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Interfaces
{
    interface IMarcaRepository
    {
        bool Agregar(Marca marca);
        List<Marca> ConsultarTodos();
    }
}
