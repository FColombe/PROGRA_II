using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using BackArticulos.MODELS;
using System.Data;


namespace BackArticulos.DATA.UTILS
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private string CadenaCnn;

        private DataHelper()
        {
            CadenaCnn = Properties.Resources.CadenaCnn;
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ConsultDB(string sp, List<Parameters> lst)
        {
            var dt = new DataTable();
            using (var cnn = new SqlConnection(CadenaCnn))
            {
                cnn.Open();
                var cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parameters p in lst)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                }
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public int ExecuteSP(string sp, List<Parameters> lst)
        {
            int row = 0;
            using (var cnn = new SqlConnection(CadenaCnn))
            {
                cnn.Open();
                var cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    foreach (Parameters p in lst)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                }
                row = cmd.ExecuteNonQuery();
            }
            return row;
        }

        public int ExecuteTransaction(string sp1, string sp2, List<Parameters> lstF, List<List<Parameters>> lstD)
        {
            int row = 0;

            using (var cnn = new SqlConnection(CadenaCnn))
            {
                cnn.Open();

                using (SqlTransaction tr = cnn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(sp1, cnn, tr);
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (lstF != null)
                        {
                            foreach (Parameters p in lstF)
                            {
                                cmd.Parameters.AddWithValue(p.Name, p.Value);
                            }
                        }
                        var param = new SqlParameter("@nroFactura", SqlDbType.Int);
                        param.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(param);

                        row = cmd.ExecuteNonQuery();

                        int nroF = Convert.ToInt32(param.Value);

                        if (lstD != null)
                        {
                            foreach (var sublist in lstD)
                            {
                                var cmd2 = new SqlCommand(sp2, cnn, tr);
                                cmd2.CommandType = CommandType.StoredProcedure;

                                cmd2.Parameters.AddWithValue("@nroFactura", nroF);

                                foreach (var d in sublist)
                                {
                                    cmd2.Parameters.AddWithValue(d.Name, d.Value);
                                }
                                row = cmd2.ExecuteNonQuery();
                                cmd2.Parameters.Clear();             //Limpiar los parameters del comando en cada vuelta, por las dudas que no se liberen
                            }
                        }
                        tr.Commit();
                    }
                    catch (SqlException)
                    {
                        tr.Rollback();
                        row = 0;
                    }
                }
            }
            return row;
        }
    }
}
