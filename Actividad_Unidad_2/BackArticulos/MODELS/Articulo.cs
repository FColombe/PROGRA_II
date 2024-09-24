using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.MODELS
{
    public class Articulo
    {
        public int CodArt { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public TipoArt Tipo { get; set; }
        public double PreUnitario { get; set; }

        public Articulo()
        {
            CodArt = 0;
            Nombre = string.Empty;
            Marca = new Marca();            
            Tipo = new TipoArt();
            PreUnitario = 0;
        }

        public override string ToString()
        {
            return CodArt + " | " + Nombre + " | " + Marca.Nombre + " | " + Tipo.Tipo + " | " + PreUnitario;
        }
    }
}
