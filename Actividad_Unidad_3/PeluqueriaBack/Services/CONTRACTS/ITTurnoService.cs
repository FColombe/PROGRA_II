using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Services.CONTRACTS
{
    public interface ITTurnoService
    {
        Task<List<TTurno>> GetTurnos();
        Task<List<TTurno>>  GetCancelados(int days);
        Task<TTurno>? GetById(int id);
        Task<bool> Add(TTurno turno);
        Task<bool> Update(TTurno turno);
        Task<bool> Delete(int id, DateOnly fecha, string motivo);
    }
}
