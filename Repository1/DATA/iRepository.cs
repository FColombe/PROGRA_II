using Repository1.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.DATA
{
    interface iRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        int Delete(int id); 
        int Save(Product product);
    }
}
