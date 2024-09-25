using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Utilidades
{
    public class Parametros
    {

        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametros(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
