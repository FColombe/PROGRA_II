using Actividad_5.DATOS.Interfaces;
using Actividad_5.DATOS.Utilidades;
using Actividad_5.DOMINIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Repositorios
{
    public class ArtRepositoryADO : IArtRepository
    {
        
        public List<Articulo> ConsultarTodos()
        {
            List<Articulo> lst = new List<Articulo>();
            var dt = DataHelper.CrearInstancia().ConsultarBD("sp_consult_art", null);
            foreach (DataRow fila in dt.Rows)
            {
                Articulo oArticulo = new Articulo();
                oArticulo.CodArt = (int)fila[0];
                oArticulo.Nombre = (string)fila[1];
                oArticulo.Marca.Nombre = (string)fila[2];
                oArticulo.Tipo.Tipo = (string)fila[3];
                oArticulo.PreUnitario = Convert.ToDouble(fila[4]);

                lst.Add(oArticulo);
            }

            return lst;
        }

        public Articulo ConsultarPorId(int id)
        {
            var lstP = new List<Parametros>()
            {
                new Parametros("@cod_art", id)
            };
            var dt = DataHelper.CrearInstancia().ConsultarBD("sp_consult_artID", lstP);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];

                Articulo oArticulo = new Articulo();
                oArticulo.CodArt = (int)fila[0];
                oArticulo.Nombre = (string)fila[1];
                oArticulo.Marca.Nombre = (string)fila[2];
                oArticulo.Tipo.Tipo = (string)fila[3];
                oArticulo.PreUnitario = Convert.ToDouble(fila[4]);
                return oArticulo;
            }
            else
            {
                return null;
            }
        }

        public bool Grabar(Articulo articulo)
        {
            bool flag = false;
           
            if (articulo != null)
            {
                if (articulo.CodArt == 0)                                          //SI EL CODIGO ES 0, NO VIENE DADO, ENTONCES ES UN INSERT
                {
                    var lst = new List<Parametros>()                               //Crea la lista y carga los objetos sin llamar al método Add. 
                    {
                        new Parametros("@nombre", articulo.Nombre),
                        new Parametros("@tipo_art", articulo.Tipo.idTipo),
                        new Parametros("@marca", articulo.Marca.idMarca),
                        new Parametros("@pre_unitario", articulo.PreUnitario)
                    };
                    int filas = DataHelper.CrearInstancia().EjecutarDML("sp_insert_articulos", lst);
                    if (filas != 0)
                    { flag = true; }
                }
                else if(articulo.CodArt !=0)                     //SI ES DISTINTO DE 0, ES UN UPDATE
                {
                    var lst = new List<Parametros>()
                    {
                        new Parametros("@cod_art", articulo.CodArt),
                        new Parametros("@nombre", articulo.Nombre),
                        new Parametros("@tipo_art", articulo.Tipo.idTipo),
                        new Parametros("@marca", articulo.Marca.idMarca),
                        new Parametros("@pre_unitario", articulo.PreUnitario),
                    };
                    int filas = DataHelper.CrearInstancia().EjecutarDML("sp_update_articulos", lst);
                    if (filas != 0)
                    { flag = true; }
                }
            }
            return flag; 
        }
        public bool Borrar(int id)
        {
            bool flag = false;
            var lst = new List<Parametros>()
            {
                new Parametros("@cod_art", id)
            };
            int filas = DataHelper.CrearInstancia().EjecutarDML("sp_delete_articulos", lst);
            if(filas != 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}
