using Actividad_5.DATOS.Interfaces;
using Actividad_5.DATOS.Utilidades;
using Actividad_5.DOMINIO;
using System.Data;

namespace Actividad_5.DATOS.Repositorios
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        public List<Factura> ConsultarTodos()
        {
            var lst = new List<Factura>();
            var dt = DataHelper.CrearInstancia().ConsultarBD("sp_Consult_Facturas", null);
            foreach (DataRow f in dt.Rows)
            {
                var nroFactura = (int)f[0];                                   //PARA ASOCIAR VARIOS DETALLES A LA MISMA FACTURA                  
                var factura = lst.FirstOrDefault(x => x.Nro == nroFactura);  //Busca en la lista de facturas, si ya hay una con el mismo nro: si ya hay, devuelve ese objeto y se saltea el if que sigue, sino dvuelve null y entra al if para cargarse

                if( factura == null)
                {
                    factura = new Factura();
                    {
                        factura.Nro = (int)f[0];
                        factura.Fecha = Convert.ToDateTime(f[1]);
                        factura.Cliente.Apellido = (string)f[2];
                        factura.Cliente.Nombre = (string)f[3];
                        factura.FormaPago.Nombre = (string)f[4];
                        factura.Estado = (bool)f[8];
                    }
                    lst.Add(factura);
                }

                var det = new Detalles();
                {
                    det.Articulo.Nombre = (string)f[5];
                    det.Cantidad = (int)f[6];
                    det.Articulo.PreUnitario = Convert.ToDouble(f[7]);
                }
                factura.Detalles.Add(det);               
            }

            return lst;
        }

        public Factura ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }


        public bool Grabar(Factura factura)
        {
            bool nueva = false;

            var lstF = new List<Parametros>()
            {
                new Parametros("@idCliente", factura.Cliente.ID),
                new Parametros("@idFormaPago", factura.FormaPago.Id),
                new Parametros("@activo", true)
            };

            var lstD = new List<List<Parametros>>();
            foreach (var d in factura.Detalles)
            {
                var subList = new List<Parametros>()
                {
                    new Parametros("@articulo", d.Articulo.CodArt),
                    new Parametros("@cantidad", d.Cantidad),
                    new Parametros("@pre_venta", Convert.ToDecimal(d.Articulo.PreUnitario))
                };
                lstD.Add(subList);
            }

            var filas = DataHelper
                        .CrearInstancia()
                        .EjecutarTransaccion("sp_Insert_Factura", lstF, "sp_Insert_Detalles", lstD);
            if(filas != 0)
            {
                nueva = true;
            }

            return nueva;
        }


        public bool Borrar(int nro)                //BORRADO LÓGICO
        {
            var anulada = false;
            var lst = new List<Parametros>()
            {
                new Parametros("@nroFactura", nro),
                new Parametros("@activo", false)
            };
            int filas = DataHelper.CrearInstancia().EjecutarDML("sp_Update_Factura", lst);
            if (filas != 0)
            {
                anulada = true;
            }
            return anulada;
        }










        //public bool Grabar(Factura factura)
        //{
        //    bool result = true;
        //    SqlConnection cnn = null;
        //    SqlTransaction tr = null;
        //    try
        //    {
        //        cnn = DataHelper.CrearInstancia().Conectar();                          //Abre la conexión desde el repository
        //        cnn.Open();
        //        tr = cnn.BeginTransaction();                                           //Inicia la transacción, se va a cerrar con Commit o Rollback

        //        SqlCommand cmd = new SqlCommand("sp_Insert_Factura", cnn, tr);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@idCliente", factura.Cliente.ID);
        //        cmd.Parameters.AddWithValue("@idFormaPago", factura.FormaPago.Id);
        //        cmd.Parameters.AddWithValue("@activo", true);

        //        SqlParameter p = new SqlParameter("@nroFactura", SqlDbType.Int);     //Para obtener el parámetro de salida (Nombre del parametro, tipo de dato, dirección
        //        p.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(p);

        //        cmd.ExecuteNonQuery();

        //        int NroFactura = Convert.ToInt32(p.Value);

        //        foreach (var d in factura.Detalles)              //Llamo a la lista como properti
        //        {
        //            var cmdD = new SqlCommand("sp_Insert_Detalles", cnn, tr);
        //            cmdD.CommandType = CommandType.StoredProcedure;

        //            cmdD.Parameters.AddWithValue("@NroFactura", NroFactura);
        //            cmdD.Parameters.AddWithValue("@articulo", d.Articulo.CodArt);
        //            cmdD.Parameters.AddWithValue("@cantidad", d.Cantidad);
        //            cmdD.Parameters.AddWithValue("@pre_venta", Convert.ToDecimal(d.Articulo.PreUnitario));

        //            cmdD.ExecuteNonQuery();
        //        }

        //        tr.Commit();                //Confirma todo lo anterior
        //    }
        //    catch (SqlException)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();          //Si algo falla, no se ejecuta nada en la base
        //        }
        //        result = false;
        //    }
        //    finally
        //    {
        //        if (cnn != null && cnn.State == ConnectionState.Open)
        //        {
        //            cnn.Close();
        //        }
        //    }

        //    return result;
        //}
    }
}
