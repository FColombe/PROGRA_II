using Actividad_5.DATOS;
using Actividad_5.DATOS.Interfaces;
using Actividad_5.DATOS.Repositorios;
using Actividad_5.NEGOCIO.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_5.NEGOCIO.SERVICIOS
{
    public class Servicio 
    {
        private IArtRepository oRepoArticulos;
        private IMarcaRepository oRepoMarca;
        private IClienteRepository oRepoCliente;
        private IFormaPagoRepository oRepoFormaPago;
        private ITipoArtRepository oRepoTipoArt;
        private IFacturaRepository oRepoFactura;
        public Servicio()
        {
            oRepoArticulos = new ArtRepositoryADO();
            oRepoMarca = new MarcaRepositoryADO(); 
            oRepoCliente = new ClienteRepositoryADO();
            oRepoFormaPago = new FormaPagoRepositoryADO();
            oRepoTipoArt = new TipoArtRepositoryADO();
            oRepoFactura = new FacturaRepositoryADO();
        }

        //MARCAS
        public bool AgregarMarca(Marca marca)
        {
            return oRepoMarca.Agregar(marca);
        }
        public List<Marca> ConsultarMarcas()
        {
            return oRepoMarca.ConsultarTodos();
        }

        //TIPOS ARTÍCULOS
        public bool AgregarTipo(TipoArt tipo)
        {
            return oRepoTipoArt.Agregar(tipo);
        }
        public List<TipoArt> ConsultarTipos()
        {
            return oRepoTipoArt.ConsultarTodos();
        }
      

        //ARTÍCULOS
        public List<Articulo> ConsultarArticulos()
        {
            return oRepoArticulos.ConsultarTodos();
        }
        public Articulo ConsultarArtID(int id)
        {
            Articulo art = oRepoArticulos.ConsultarPorId(id);

            return art;
        }
        public bool EliminarArt(int id)
        {
            return oRepoArticulos.Borrar(id);
        }
        public bool AgregarArt(Articulo articulo)
        {
            return oRepoArticulos.Grabar(articulo);
        }
        public bool EditarArt(Articulo articulo)
        {
            return oRepoArticulos.Grabar(articulo);
        }
        
        //CLIENTES
        public List<Cliente> ConsultarClientes()
        {
            return oRepoCliente.ConsultarTodos();
        }
        public Cliente ConsultarClienteID(int id)
        {
            return oRepoCliente.ConsultarPorId(id);
        }
        public bool AgregarCliente(Cliente cliente)
        {
            return oRepoCliente.Grabar(cliente);
        }
        public bool EditarCliente(Cliente cliente)
        {
            return oRepoCliente.Grabar(cliente);
        }
        public bool EliminarCliente(int id)
        {
            return oRepoCliente.Borrar(id);
        }

        //FORMAS DE PAGO
        public bool AgregarFP(Forma_Pago forma)
        {
            return oRepoFormaPago.AgregarFormaPago(forma);
        }
        public List<Forma_Pago> ConsultarFP()
        {
            return oRepoFormaPago.VerFormasPago();
        }


        //FACTURAS
        public bool AgregarFactura(Factura factura)
        {
            return oRepoFactura.Grabar(factura);
        }
    }
}
