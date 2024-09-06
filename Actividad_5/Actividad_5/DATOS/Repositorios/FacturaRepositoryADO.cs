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
                var factura = lst.FirstOrDefault(x => x.Nro == nroFactura);  //Busca en la lista de facturas si ya hay una con el mismo nro: si ya hay, devuelve ese objeto y se saltea el if que sigue, sino dvuelve null y entra al if para cargarse

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
                    det.Factura.Nro = (int)f[0];
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
            var list = new List<Parametros>()
            {
                new Parametros("@nroFactura", id)
            };

            var dt = DataHelper
                .CrearInstancia()
                .ConsultarBD("sp_Consult_FacturasID", list);

            if (dt.Rows.Count > 0 && dt != null)
            {
                DataRow f = dt.Rows[0];
                var factura = new Factura();
                {
                    factura.Nro = (int)f[0];
                    factura.Cliente.Apellido = (string)f[2];
                    factura.Cliente.Nombre = (string)f[3];
                    factura.Fecha = Convert.ToDateTime(f[1]);
                    factura.FormaPago.Nombre = (string)f[4];
                    factura.Estado = (bool)f[8];
                }

                foreach(DataRow d in dt.Rows)
                {
                    Detalles det = new Detalles();
                    {
                        det.Factura.Nro = (int)f[0];
                        det.Articulo.Nombre = (string)f[5];
                        det.Cantidad = (int)f[6];
                        det.Articulo.PreUnitario = Convert.ToDouble(f[7]);
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

        public List<Factura> ConsultarFactEstado(string estado)
        {
            var lst = new List<Factura>();
            var list = new List<Parametros>()
            {
                new Parametros("@activo", estado)
            };
            var dt = DataHelper.CrearInstancia().ConsultarBD("sp_Consult_EstadosFactura", list);
            foreach (DataRow f in dt.Rows)
            {
                var nroFactura = (int)f[0];                                              
                var factura = lst.FirstOrDefault(x => x.Nro == nroFactura);  

                if (factura == null)
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
                    det.Factura.Nro = (int)f[0];
                    det.Articulo.Nombre = (string)f[5];
                    det.Cantidad = (int)f[6];
                    det.Articulo.PreUnitario = Convert.ToDouble(f[7]);
                }
                factura.Detalles.Add(det);
            }

            return lst;
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
    }
}
