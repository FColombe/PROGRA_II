﻿using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Interfaces
{
    interface IFormaPagoRepository
    {
        public List<Forma_Pago> VerFormasPago();
        public bool AgregarFormaPago(Forma_Pago forma);

    }
}
