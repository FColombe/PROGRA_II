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


        public DataTable ConsultarBD(string sp)
        {
            DataTable dt = new DataTable();
            try
            {
                using (cnn)
                {
                    cnn.Open();
                    var cmd = new SqlCommand(sp, cnn);                 //ASOCIO LA QUERY Y LA CONEXIÓN!!!!!
                    cmd.CommandType = CommandType.StoredProcedure;

                    dt.Load(cmd.ExecuteReader());

                }
            }
            catch (SqlException)
            {
                dt = null;
            }

            return dt;
        }

        public int EjecutarDML(string sp, List<Parametros> lstP)
        {
            int filas = 0;
            try
            {
                using (cnn)
                {
                    cnn.Open();
                    var cmd = new SqlCommand(sp, cnn);
                    if (lstP != null)
                    {
                        foreach (Parametros p in lstP)
                        {
                            cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                        }
                    }
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                filas = 0;
            }

            return filas;
        }
    }

}
