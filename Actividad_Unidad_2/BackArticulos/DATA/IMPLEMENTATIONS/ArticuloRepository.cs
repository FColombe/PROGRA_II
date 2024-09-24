using BackArticulos.DATA.CONTRACTS;
using BackArticulos.DATA.UTILS;
using BackArticulos.MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.DATA.IMPLEMENTATIONS
{
    public class ArticuloRepository : IArticuloRepository
    {

        public List<Articulo> GetAll()
        {
            var lst = new List<Articulo>();
            var dt = DataHelper
                .GetInstance()
                .ConsultDB("sp_consult_art", null);
            foreach (DataRow row in dt.Rows)
            {
                var oArticulo = new Articulo();
                oArticulo.CodArt = (int)row[0];
                oArticulo.Nombre = (string)row[1];
                oArticulo.Marca.Nombre = (string)row[2];
                oArticulo.Tipo.Tipo = (string)row[3];
                oArticulo.PreUnitario = Convert.ToDouble(row[4]);
                lst.Add(oArticulo);
            }
            return lst;
        }

        public Articulo GetById(int id)
        {
            var lst = new List<Parameters>()
            {
                new Parameters("@cod_art", id)
            };
            var dt = DataHelper
                .GetInstance()
                .ConsultDB("sp_consult_artID", lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                var oArticulo = new Articulo();
                oArticulo.CodArt = (int)row[0];
                oArticulo.Nombre = (string)row[1];
                oArticulo.Marca.Nombre = (string)row[2];
                oArticulo.Tipo.Tipo = (string)row[3];
                oArticulo.PreUnitario = Convert.ToDouble(row[4]);
                return oArticulo;
            }
            else
            {
                return null;
            }
        }

        public bool Add(Articulo art)
        {
            bool flag = false;

            if (art != null)
            {
                var lst = new List<Parameters>()
                    {
                        new Parameters("@nombre", art.Nombre),
                        new Parameters("@tipo_art", art.Tipo.idTipo),
                        new Parameters("@marca", art.Marca.idMarca),
                        new Parameters("@pre_unitario", art.PreUnitario)
                    };
                int row = DataHelper.GetInstance().ExecuteSP("sp_insert_articulos", lst);
                if (row > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }

       
        public bool Update(Articulo art)
        {
            bool flag = false;

            if (art != null)
            {
                var lst = new List<Parameters>()
                    {
                        new Parameters("@cod_art", art.CodArt),
                        new Parameters("@nombre", art.Nombre),
                        new Parameters("@tipo_art", art.Tipo.idTipo),
                        new Parameters("@marca", art.Marca.idMarca),
                        new Parameters("@pre_unitario", art.PreUnitario),
                    };
                int row = DataHelper
                    .GetInstance()
                    .ExecuteSP("sp_update_articulos", lst);
                if (row > 0)
                { 
                    flag = true; 
                }
            }
            return flag;
        }

        public bool Delete(int id)
        {
            bool flag = false;

            if (id != 0)
            {
                var lst = new List<Parameters>()
                    {
                        new Parameters("@cod_art", id),
                    };
                int row = DataHelper
                    .GetInstance()
                    .ExecuteSP("sp_delete_articulos", lst);
                if (row > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}
