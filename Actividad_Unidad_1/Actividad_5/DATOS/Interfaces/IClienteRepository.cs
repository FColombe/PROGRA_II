using Actividad_5.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Interfaces
{
    interface IClienteRepository
    {
        List<Cliente> ConsultarTodos();
        Cliente ConsultarPorId(int id);
        bool Grabar(Cliente cliente);
        bool Borrar(int id);
    }
}
