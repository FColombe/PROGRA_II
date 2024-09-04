using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

        public SqlConnection Conectar()     //Permite conectar desde otro lugar del código
        {
            return cnn;
        }

        public DataTable ConsultarBD(string sp, List<Parametros> lstP)
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();

                var cmd = new SqlCommand(sp, cnn);                 //ASOCIO LA QUERY Y LA CONEXIÓN!!!!!
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
    }
}
