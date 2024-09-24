using BackArticulos.DATA.CONTRACTS;
using BackArticulos.DATA.UTILS;
using BackArticulos.MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackArticulos.DATA.IMPLEMENTATIONS
{
    public class FacturaRepository : IFacturaRepository
    {
       
        public List<Factura> GetAll()
        {
            var lst = new List<Factura>();
            var dt = DataHelper.GetInstance().ConsultDB("sp_Consult_FactHeader", null);
            foreach (DataRow r in dt.Rows)
            {
                var factura = new Factura();
                {
                    factura.Nro = (int)r[0];
                    factura.Fecha = Convert.ToDateTime(r[1]);
                    factura.Cliente.Apellido = (string)r[2];
                    factura.Cliente.Nombre = (string)r[3];
                    factura.FormaPago.Nombre = (string)r[4];
                    factura.Estado = (bool)r[5];
                }
                lst.Add(factura);
            }
            return lst;
        }

        public List<Factura> GetByPay(int id)
        {
            var lst = new List<Factura>();

            var lstP = new List<Parameters>()
            {
                new Parameters("@forma_pago", id)
            };
            var dt = DataHelper.GetInstance().ConsultDB("sp_Consult_FactFormaPago", lstP);
            foreach (DataRow r in dt.Rows)
            {
                var factura = new Factura();
                {
                    factura.Nro = (int)r[0];
                    factura.Fecha = Convert.ToDateTime(r[1]);
                    factura.Cliente.Apellido = (string)r[2];
                    factura.Cliente.Nombre = (string)r[3];
                    factura.FormaPago.Id = (int)r[4];
                    factura.FormaPago.Nombre = (string)r[5];
                    factura.Estado = (bool)r[6];
                }
                lst.Add(factura);
            }
            return lst;
        }

        public List<Factura> GetByDate(DateTime date)    
        {
            var lst = new List<Factura>();
            //DateTime dateOnly = date.Date;              //CONVIERTE A SOLO FECHA. No lo uso porque la conversión la hice en el SP.
            var lstP = new List<Parameters>()
            {
                new Parameters("@fecha", date)
            };
            var dt = DataHelper.GetInstance().ConsultDB("sp_Consult_FactFecha", lstP); 
            foreach (DataRow r in dt.Rows)
            {
                var factura = new Factura();
                {
                    factura.Nro = (int)r[0];
                    factura.Fecha = Convert.ToDateTime(r[1]);
                    factura.Cliente.Apellido = (string)r[2];
                    factura.Cliente.Nombre = (string)r[3];
                    factura.FormaPago.Nombre = (string)r[4];
                    factura.Estado = (bool)r[5];
                }
                lst.Add(factura);
            }

            return lst;
        }

        public Factura GetById(int nro)
        {
            var lstP = new List<Parameters>()
            {
                new Parameters("@nroFactura", nro)
            };
            var dt = DataHelper.GetInstance().ConsultDB("sp_Consult_FacturasID", lstP);
            if(dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                var factura = new Factura();
                {
                    factura.Nro = (int)r[0];
                    factura.Fecha = Convert.ToDateTime(r[1]);
                    factura.Cliente.Apellido = (string)r[2];
                    factura.Cliente.Nombre = (string)r[3];
                    factura.FormaPago.Nombre = (string)r[4];
                    factura.Estado = (bool)r[8];
                }

                foreach(DataRow d in dt.Rows)
                {
                    var det = new Detalle();
                    {
                        //det.Factura.Nro = (int)d[0];
                        det.Articulo.Nombre= (string)d[5];
                        det.Cantidad = (int)d[6];
                        det.Articulo.PreUnitario = Convert.ToDouble(d[7]);
                    }
                    factura.Detalles.Add(det);
                }
                return factura;
            }
            else
            {
                return null;
            }
        }

        public bool Add(Factura factura)
        {
            bool flag = false;
            var lstF = new List<Parameters>()
            {
                new Parameters("@idCliente", factura.Cliente.ID),
                new Parameters("@idFormaPago", factura.FormaPago.Id),
                new Parameters("@activo", true)
            };

            var lstD = new List<List<Parameters>>();
            foreach (var d in factura.Detalles) 
            {
                var subLstD = new List<Parameters>()
                {
                    new Parameters("@articulo", d.Articulo.CodArt),
                    new Parameters("@cantidad", d.Cantidad),
                    new Parameters("@pre_venta", d.Articulo.PreUnitario)
                };
                lstD.Add(subLstD);
            }
            var added = DataHelper.GetInstance().ExecuteTransaction("sp_Insert_Factura", "sp_Insert_Detalles", lstF, lstD);
            if(added > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool Update(Factura factura)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int nro)
        {
            throw new NotImplementedException();
        }

       
    }
}
