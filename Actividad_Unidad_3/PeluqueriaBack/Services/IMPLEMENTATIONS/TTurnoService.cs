using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Data.Repositories.Contracts;
using PeluqueriaBack.Services.CONTRACTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Services.IMPLEMENTATIONS
{
    public class TTurnoService : ITTurnoService
    {
        private readonly ITTurnoRepository _repository;

        public TTurnoService(ITTurnoRepository repository)
        {
            _repository = repository;
        }

        

        public async Task<TTurno>? GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<TTurno>> GetCancelados(int days)
        {
            return await _repository.GetCancels(days);
        }

        public async Task<List<TTurno>> GetTurnos()
        {
            return await _repository.GetAll();
        }
        public async Task<bool> Add(TTurno turno)
        {
            return await _repository.Add(turno);
        }
        public async Task<bool> Update(TTurno turno)
        {
            return await _repository.Update(turno);
        }
        public async Task<bool> Delete(int id, DateOnly fecha, string motivo)
        {
            return await (_repository.Delete(id, fecha, motivo));
        }
    }
}
