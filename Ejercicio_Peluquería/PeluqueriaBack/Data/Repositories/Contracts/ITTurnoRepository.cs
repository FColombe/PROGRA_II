using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Repositories.Contracts
{
    public interface ITTurnoRepository
    {
        List<TTurno> GetAll();
        List<TTurno> GetByCliente(string cliente);
        List<TTurno> GetByFecha(string fecha1);
        TTurno? GetById(int id);
        bool Add(TTurno t);
        bool Update(TTurno t);
        bool Delete(int id, DateTime fechaCancelacion, string motivo);

        Task<bool> ReservarTurno(TTurno turno);
    }
}
