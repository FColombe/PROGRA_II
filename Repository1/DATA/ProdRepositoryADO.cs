using Repository1.DOMAIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository1.DATA
{
    public class ProdRepositoryADO : iRepository
    {
        
       


        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_recuperar");  //INVOCA AL MÉTODO ESTÁTICO DE LA CLASE DATAHELPER, LUEGO AL MÉTODO QUE CONECTA Y HACE LA CONSULTA Y MANDA LA QUERY CON FORMA DE sp
            foreach (DataRow dr in dt.Rows)
            {
                Product p = new Product();                      //Por cada fila que trae el método, creo un objeto y lo mapeo: cargo sus properties con el contenido de cada columna
                p.Codigo = Convert.ToInt32(dr[0]);
                p.Nombre = Convert.ToString(dr[1]);
                p.Precio = Convert.ToDouble(dr[2]);
                p.Stock = Convert.ToInt32(dr[3]);
                p.Activo = Convert.ToBoolean(dr[4]);
                list.Add(p);
            }   
            return list;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
