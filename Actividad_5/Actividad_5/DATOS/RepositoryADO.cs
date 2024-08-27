using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS
{
    public class RepositoryADO : IArtRepository
    {
        public List<Articulo> GetAll()
        {
            List<Articulo> lst = new List<Articulo>();
            var dt = DataHelper.CrearInstancia().ConsultarBD("sp_consult_art");
            foreach (DataRow fila in dt.Rows)
            {
                Articulo oArticulo = new Articulo();
                oArticulo.CodArt = (int)fila[0];
                oArticulo.Nombre = (string)fila[1];
                Marca oMarca = new Marca();
                oMarca.Nombre = (string)fila[2];
                TipoArt oTipo = new TipoArt();
                oTipo.Tipo = (string)fila[3];
                oArticulo.Precio = (float)fila[4];

                lst.Add(oArticulo);
            }

            return lst;
        }

        public Articulo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Articulo articulo)
        {
            throw new NotImplementedException();
        }
        public int Delete(Articulo articulo)
        {
            throw new NotImplementedException();
        }
    }
}
