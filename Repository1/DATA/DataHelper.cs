using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.DATA
{
    public class DataHelper                   //PATRÓN SINGLETON: para tener una sola instancia de esta clase.
                                              //Es importante mantener privada la conexión a la BD, para que solo se conecte desde un solo lugar. 
                                              //DATA HELPER ES LA CAPA DONDE GUARDO TODA LA COMUNICACIÓN CON LA BD (ex ADO)
    {
        
         
        private static DataHelper instance;
        private SqlConnection cnn;

        private  DataHelper()
        {
            cnn = new SqlConnection(Properties.Resources.strConnect); 
        }

        public static DataHelper GetInstance()
        {
            if(instance == null)                    //si aún no fue creada, la crea
            {
                instance = new DataHelper();
            }
            return instance;                       //si ya fue creada, devuelve la existente
        }

        private void Connect()
        {
            
        }


        public DataTable ExecuteSPQuery(string sp)
        {
            DataTable dt = new DataTable();
            try
            {
                //this.Connect();
                cnn.Open();
                var cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;        //Tengo que dejar indicado que lo que le voy a pasar es un SP y no una query

                dt.Load(cmd.ExecuteReader());

                cnn.Close();
            }
            catch (SqlException)                       //CONTROLA POSIBLE ERROR EN TIEMPO DE EJECUCIÓN
            {

                throw;
            }
            

            return dt;
        }
    }
}
