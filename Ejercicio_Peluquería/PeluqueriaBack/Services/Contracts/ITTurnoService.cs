using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Services.Contracts
{
    public interface ITTurnoService
    {
        List<TTurno> GetTurnos();
        List<TTurno> GetByCliente(string cliente);
        List<TTurno> GetByFecha(string fecha1);
        TTurno? GetById(int id);
        bool AddTurno(TTurno turno);
        bool DeleteTurno(int id, DateTime fechaCancelacion, string motivo);
        bool UpdateTurno(TTurno turno);
        Task<bool> Reservar(TTurno turno);
    }
}
