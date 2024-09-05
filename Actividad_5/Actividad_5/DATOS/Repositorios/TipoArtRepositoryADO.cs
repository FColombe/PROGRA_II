using Actividad_5.DATOS.Interfaces;
using Actividad_5.DATOS.Utilidades;
using Actividad_5.DOMINIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Repositorios
{
    public class TipoArtRepositoryADO : ITipoArtRepository
    {
        public bool Agregar(TipoArt tipo)
        {
            int filas = 0;
            var lstP = new List<Parametros>()
            {
                new Parametros("@descripcion", tipo.Tipo)
            };
            filas = DataHelper.CrearInstancia().EjecutarDML("sp_Insert_TipoArt", lstP);
            if (filas != 0)
                return true;
            else return false;
        }

        public List<TipoArt> ConsultarTodos()
        {
            var lst = new List<TipoArt>();
            var dt = DataHelper.CrearInstancia().ConsultarBD("sp_Consult_TipoArt", null);
            foreach (DataRow fila in dt.Rows)
            {
                var tipo = new TipoArt();
                tipo.idTipo = (int)fila[0];
                tipo.Tipo = (string)fila[1];

                lst.Add(tipo);
            }

            return lst;
        }
    }
}
