using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DOMINIO
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cuit { get; set; }
        public int Tel { get; set; }
        public string Calle { get; set; }
        public int NroCalle { get; set; }

        public Cliente() { }
        public Cliente(string nombre, string apellido, int cuit, int tel, string calle, int nroCalle)
        {
            Nombre = nombre;
            Apellido = apellido;
            Cuit = cuit;
            Tel = tel;
            Calle = calle;
            NroCalle = nroCalle;
        }

        public override string ToString()
        {
            return ID + " | " + Nombre + " | " + Apellido + " | " + Cuit + " | " + Tel;
        }
    }
}
