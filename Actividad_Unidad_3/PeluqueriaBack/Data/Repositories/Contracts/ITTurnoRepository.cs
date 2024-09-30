using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Repositories.Contracts
{
    interface ITTurnoRepository
    {
        List<TTurno> GetAll();

        TTurno Get(int id);




    }
}
