using System.Data;
using System.Data.SqlClient;

namespace Actividad_5.DATOS.Utilidades
{
    public class DataHelper
    {
        private static DataHelper instancia;
        private SqlConnection cnn;

        private DataHelper()
        {
            cnn = new SqlConnection(Properties.Resources.cadenacnn);
        }

        public static DataHelper CrearInstancia()
        {
            if (instancia == null)
            {
                instancia = new DataHelper();
            }
            return instancia;
        }


        public DataTable ConsultarBD(string sp, List<Parametros> lstP)
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();

                var cmd = new SqlCommand(sp, cnn);                 
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstP != null)
                {
                    foreach (Parametros p in lstP)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }

                dt.Load(cmd.ExecuteReader());
                cnn.Close();
                
            }
            catch (SqlException)
            {
                dt = null;
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return dt;
        }

        public int EjecutarDML(string sp, List<Parametros> lstP)
        {
            int filas = 0;
            try
            {
                cnn.Open();
                var cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstP != null)
                {
                    foreach (Parametros p in lstP)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }
                filas = cmd.ExecuteNonQuery();
                cnn.Close();

            }
            catch
            {
                filas = 0;
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return filas;
        }

        public int EjecutarTransaccion(string sp1, List<Parametros> lstF, string sp2, List<List<Parametros>> lstD)
        {
            int filas = 0;
            SqlTransaction tr = null;
            try
            {                      
                cnn.Open();
                tr = cnn.BeginTransaction();                                           //Inicia la transacción, se va a cerrar con Commit o Rollback

                SqlCommand cmd = new SqlCommand(sp1, cnn, tr);
                cmd.CommandType = CommandType.StoredProcedure;

                if (lstF != null)
                {
                    foreach (Parametros p in lstF)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }
                
                var param = new SqlParameter("@nroFactura", SqlDbType.Int);     //Para obtener el parámetro de salida (Nombre del parametro, tipo de dato, dirección
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                filas = cmd.ExecuteNonQuery();

                int NroFactura = Convert.ToInt32(param.Value);

                if(lstD != null)
                {
                    foreach(var subList in lstD)
                    {
                        var cmdD = new SqlCommand(sp2, cnn, tr);
                        cmdD.CommandType = CommandType.StoredProcedure;

                        cmdD.Parameters.AddWithValue("@nroFactura", NroFactura);

                        foreach (var p in subList)
                        {
                            cmdD.Parameters.AddWithValue(p.Nombre, p.Valor);
                        }
                        filas = cmdD.ExecuteNonQuery();
                    }
                }

                tr.Commit();                //Confirma todo lo anterior
            }
            catch (SqlException)
            {
                if (tr != null)
                {
                    tr.Rollback();          //Si algo falla, no se ejecuta nada en la base
                }
                filas = 0;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return filas;
        }
    }
}
