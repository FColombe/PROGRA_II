using BackArticulos.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.DATA.CONTRACTS
{
    interface IArticuloRepository
    {
        List<Articulo> GetAll();
        Articulo GetById(int id);
        bool Add(Articulo art);
        bool Update(Articulo art);
        bool Delete(int id);  
    }
}
