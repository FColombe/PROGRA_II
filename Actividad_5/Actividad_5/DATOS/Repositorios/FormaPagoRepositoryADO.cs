using Actividad_5.DATOS.Interfaces;
using Actividad_5.DATOS.Utilidades;
using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.DATOS.Repositorios
{
    public class FormaPagoRepositoryADO : IFormaPagoRepository
    {
        public List<Forma_Pago> VerFormasPago()
        {
            var lst = new List<Forma_Pago>();
            var dt = DataHelper
                     .CrearInstancia()
                     .ConsultarBD("sp_Consult_formaPago", null);
            foreach (DataRow fila in dt.Rows)
            {
                Forma_Pago forma = new Forma_Pago();
                forma.Id = (int)fila[0];
                forma.Nombre = (string)fila[1];
                forma.Recargo = Convert.ToDouble(fila[2]);
                lst.Add(forma);
            }

            return lst;
        }

        public bool AgregarFormaPago(Forma_Pago forma)
        {
            var lstP = new List<Parametros>()
           {
               new Parametros("@forma_pago", forma.Nombre),
               new Parametros("@recargo", forma.Recargo)
           };
            int filas = DataHelper
                     .CrearInstancia()
                     .EjecutarDML("sp_insert_formaPago", lstP);
            if (filas != 0)
            {
                return true;
            }
            else
            { return false; }
        }
    }
}
