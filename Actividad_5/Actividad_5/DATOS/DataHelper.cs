using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS
{
    public class DataHelper
    {
        private static DataHelper instancia;
        private string cadenaCnn;

        public DataHelper()
        {
            cadenaCnn = Properties.Resources.cadenacnn;
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
                using (var cnn = new SqlConnection(cadenaCnn))
                {
                    cnn.Open();
                    var cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    dt.Load(cmd.ExecuteReader());

                    
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return dt;
        }


    }

}
