using Actividad_5.DATOS.Interfaces;
using Actividad_5.DATOS.Utilidades;
using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Repositorios
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        public List<Factura> ConsultarTodos()
        {
            var lst = new List<Factura>();


            return lst;
        }

        public Factura ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }


        public bool Grabar(Factura factura)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction tr = null;
            try
            {
                cnn = DataHelper.CrearInstancia().Conectar();                          //Abre la conexión desde el repository
                cnn.Open();
                tr = cnn.BeginTransaction();                                           //Inicia la transacción, se va a cerrar con Commit o Rollback

                SqlCommand cmd = new SqlCommand("sp_Insert_Factura", cnn, tr);                          
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", factura.Cliente.ID);
                cmd.Parameters.AddWithValue("@idFormaPago", factura.FormaPago.Id);

                SqlParameter p = new SqlParameter("@nroFactura", SqlDbType.Int); //Para obtener el parámetro de salidad (Nombre del parametro, tipo de dato, dirección
                p.Direction = ParameterDirection.Output;  
                cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();

                int NroFactura = Convert.ToInt32(p.Value);

                foreach (var d in factura.Detalles)              //Llamo a la lista como properti
                {
                    var cmdD = new SqlCommand("sp_Insert_Detalles", cnn, tr);
                    cmdD.CommandType = CommandType.StoredProcedure;

                    cmdD.Parameters.AddWithValue("@NroFactura", NroFactura);
                    cmdD.Parameters.AddWithValue("@articulo", d.Articulo.CodArt);
                    cmdD.Parameters.AddWithValue("@cantidad", d.Cantidad);
                    cmdD.Parameters.AddWithValue("@pre_venta", Convert.ToDecimal(d.Articulo.PreUnitario));

                    cmdD.ExecuteNonQuery();
                }


                tr.Commit();                //Confirma todo lo anterior
            }
            catch (SqlException)
            {
                if(tr != null)
                {
                    tr.Rollback();          //Si algo falla, no se ejecuta nada en la base
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return result;
        }
        public bool Borrar(int id)                //BORRADO LÓGICO
        {
            throw new NotImplementedException();
        }
    }
}
