using BackArticulos.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.DATA.CONTRACTS
{
    interface IFacturaRepository
    {
        List<Factura> GetAll();
        List<Factura> GetByDate(DateTime date);
        List<Factura> GetByPay(int id);
        Factura GetById(int nro);
        bool Add(Factura factura);
        bool Update(Factura factura);
        bool Delete(int nro);
    }
}
