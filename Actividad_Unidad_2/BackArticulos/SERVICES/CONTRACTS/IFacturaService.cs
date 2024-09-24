using BackArticulos.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.SERVICES.CONTRACTS
{
    public interface IFacturaService
    {
        List<Factura> GetFacturas();
        List<Factura> GetFacturasByDate(DateTime date);
        List<Factura> GetFacturasByPay(int id);
        Factura GetFacturasById(int nro);
        bool AddFactura(Factura factura);
        bool UpdateFactura(Factura factura);
        bool DeleteFactura(int nro);
    }
}
