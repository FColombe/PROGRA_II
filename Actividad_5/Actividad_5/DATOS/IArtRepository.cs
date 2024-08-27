using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS
{
    interface IArtRepository
    {
        List<Articulo> GetAll();
        Articulo GetById(int id);
        int Save(Articulo articulo);
        int Delete(Articulo articulo);
    }
}
