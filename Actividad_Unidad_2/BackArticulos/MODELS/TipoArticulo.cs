using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.MODELS
{
    public class TipoArt
    {
        public int idTipo { get; set; }
        public string Tipo { get; set; }

        public TipoArt()
        {
            idTipo = 0;
            Tipo = string.Empty;
        }

        public override string ToString()
        {
            return Tipo;
        }
    }
}
