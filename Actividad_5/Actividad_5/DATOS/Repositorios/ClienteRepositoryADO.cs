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
    public class ClienteRepositoryADO : IClienteRepository
    {

        public List<Cliente> ConsultarTodos()
        {
            List<Cliente> lst = new List<Cliente>();
            var dt = DataHelper
                .CrearInstancia()
                .ConsultarBD("sp_Consult_Clientes", null);
            foreach (DataRow fila in dt.Rows)
            {
                Cliente oCliente = new Cliente();
                oCliente.ID = (int)fila[0];
                oCliente.Nombre = (string)fila[1];
                oCliente.Apellido = (string)fila[2];
                oCliente.Cuit = (int)fila[3];
                oCliente.Tel = (int)fila[4];
                lst.Add(oCliente);
            }
            return lst;
        }
        public Cliente ConsultarPorId(int id)
        {
            var lstP = new List<Parametros>()
            {
                new Parametros("@id_cliente", id)
            };
            var dt = DataHelper
                .CrearInstancia()
                .ConsultarBD("sp_Consult_ClientesID", lstP);
           if(dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                
                Cliente oCliente = new Cliente();
                oCliente.ID = (int)fila[0];
                oCliente.Nombre = (string)fila[1];
                oCliente.Apellido = (string)fila[2];
                oCliente.Cuit = (int)fila[3];
                oCliente.Tel = (int)fila[4];
                return oCliente;
            }
            else
            {
                return null;
            }           
        }

        

        public bool Grabar(Cliente cliente)
        {
           bool flag = false;
            if(cliente.ID == 0)
            {
                var lstP = new List<Parametros>()
                {
                    new Parametros("@nom_cliente", cliente.Nombre),
                    new Parametros("@ape_cliente", cliente.Apellido),
                    new Parametros("@cuit", cliente.Cuit),
                    new Parametros("@calle", cliente.Calle),
                    new Parametros("@nro_calle", cliente.NroCalle),
                    new Parametros("@telefono", cliente.Tel)
                };
                var filas = DataHelper
                    .CrearInstancia()
                    .EjecutarDML("sp_insert_clientes", lstP);
                if (filas != 0)
                {
                    flag = true;
                }
            }
            else if(cliente.ID != 0)
            {
                var lstP = new List<Parametros>
                {
                    new Parametros("@id_cliente", cliente.ID),
                    new Parametros("@nom_cliente", cliente.Nombre),
                    new Parametros("@ape_cliente", cliente.Apellido),
                    new Parametros("@cuit", cliente.Cuit),
                    new Parametros("@calle", cliente.Calle),
                    new Parametros("@nro_calle", cliente.NroCalle),
                    new Parametros("@telefono", cliente.Tel)
                };
                var filas = DataHelper
                    .CrearInstancia()
                    .EjecutarDML("sp_update_clientes", lstP);
                if (filas != 0)
                {
                    flag = true;
                }
            }
           return flag;
        }

        public bool Borrar(int id)
        {
            bool flag = false;
            var lstP = new List<Parametros>()
            {
                new Parametros("@id", id)
            };
            var filas = DataHelper
                    .CrearInstancia()
                    .EjecutarDML("sp_delete_clientes", lstP);
            if (filas != 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}
