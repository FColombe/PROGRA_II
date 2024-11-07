using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Data.Repositories.Contracts;
using PeluqueriaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Services.Implementations
{
    public class TTurnoService : ITTurnoService
    {
        private readonly ITTurnoRepository _repository;

        public TTurnoService(ITTurnoRepository repository)
        {
            _repository = repository;
        }

        public List<TTurno> GetTurnos()
        {
            return _repository.GetAll();
        }

        public List<TTurno> GetByCliente(string cliente)
        {
            return _repository.GetByCliente(cliente);
        }

        public List<TTurno> GetByFecha(string fecha1)
        {
            return _repository.GetByFecha(fecha1);
        }

        public TTurno? GetById(int id)
        {
           return _repository.GetById(id);
        }

        public bool AddTurno(TTurno turno)
        {
            return _repository.Add(turno);
        }

        public bool DeleteTurno(int id, DateTime fechaCancelacion, string motivo)
        {
           return _repository.Delete(id, fechaCancelacion, motivo);
        }

        public bool UpdateTurno(TTurno turno)
        {
            return _repository.Update(turno);
        }

        public async Task<bool> Reservar(TTurno turno)
        {
            return await _repository.ReservarTurno(turno);   
        }
    }
}
