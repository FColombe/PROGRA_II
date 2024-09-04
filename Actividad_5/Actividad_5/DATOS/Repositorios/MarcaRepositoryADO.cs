using Actividad_5.DATOS.Interfaces;
using Actividad_5.DATOS.Utilidades;
using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Repositorios
{
    public class MarcaRepositoryADO : IMarcaRepository
    {
        public bool Agregar(Marca marca)
        {
            int filas = 0;
            var lstP = new List<Parametros>()
            {
                new Parametros("@nombre", marca.Nombre)
            };
            filas = DataHelper.CrearInstancia().EjecutarDML("sp_insert_marca", lstP);
            if(filas != 0 ) 
                return true;
            else return false;
        }

        public List<Marca> ConsultarTodos()
        {
            List<Marca> lst = new List<Marca>();
            var dt = DataHelper.CrearInstancia().ConsultarBD("sp_Consult_Marca", null);
            foreach (DataRow fila in dt.Rows)
            {
                var marca = new Marca();
                marca.idMarca = (int)fila[0];
                marca.Nombre = (string)fila[1];

                lst.Add(marca);
            }

            return lst;
        }
    }
}
