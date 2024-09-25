﻿using Actividad_5.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Interfaces
{
    interface ITipoArtRepository
    {
        bool Agregar(TipoArt tipo);
        List<TipoArt> ConsultarTodos();
    }
}