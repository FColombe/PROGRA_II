using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Repositories.Contracts
{
    public interface ITTurnoRepository
    {
        Task<List<TTurno>> GetAll();
        Task<TTurno>? GetById(int id);
        Task<List<TTurno>> GetCancels(int days);
        Task<bool> Add(TTurno t);
        Task<bool> Update(TTurno t);
        Task<bool> Delete(int id, DateOnly fechCacel, string motivo);
    }
}
