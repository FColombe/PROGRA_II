﻿using Actividad_5.DATOS;
using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.NEGOCIO.SERVICIOS
{
    public class Servicio 
    {
        private IArtRepository oRepo;

        public Servicio()
        {
            oRepo = new RepositoryADO();
        }

        public List<Articulo> ConsultarArt()
        {
            return oRepo.GetAll();
        }
    }
}
