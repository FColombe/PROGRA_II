using BackArticulos.DATA.CONTRACTS;
using BackArticulos.DATA.IMPLEMENTATIONS;
using BackArticulos.MODELS;
using BackArticulos.SERVICES.CONTRACTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.SERVICES.IMPLEMENTATIONS
{
    public class FacturaService : IFacturaService
    {
        private IFacturaRepository oRepoFactura;

        public FacturaService()
        {
                oRepoFactura = new FacturaRepository();
        }

        public List<Factura> GetFacturas()
        {
            return oRepoFactura.GetAll();
        }
        public List<Factura> GetFacturasByDate(DateTime date)
        {
            return oRepoFactura.GetByDate(date);
        }

        public List<Factura> GetFacturasByPay(int id)
        {
            return oRepoFactura.GetByPay(id);
        }

        public Factura GetFacturasById(int nro)
        {
            return oRepoFactura.GetById(nro);
        }

        public bool AddFactura(Factura factura)
        {
            return oRepoFactura.Add(factura);
        }

        public bool UpdateFactura(Factura factura)
        {
            return oRepoFactura.Update(factura);
        }
        public bool DeleteFactura(int nro)
        {
            return oRepoFactura.Delete(nro);
        }
    }
}
