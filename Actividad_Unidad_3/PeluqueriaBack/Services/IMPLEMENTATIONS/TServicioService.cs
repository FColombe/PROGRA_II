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
    public class TServicioService : ITServicioService
    {
        private readonly ITServicioRepository _oRepo;

        public TServicioService(ITServicioRepository TServicioRepository)
        {
            _oRepo = TServicioRepository;
        }

        public List<TServicio> GetServicioList()
        {
            return _oRepo.GetAll();
        }

        public List<TServicio> GetServicioCosto(int costo)
        {
            return _oRepo.GetByCosto(costo);    
        }

        public TServicio? GetServicioId(int id)
        {
            return _oRepo.GetById(id);
        }

        public List<TServicio> GetServicioProm(string promId)
        {
            return _oRepo.GetByProm(promId);
        }

        public bool UpdateServicio(TServicio servicio)
        {
            return _oRepo.Update(servicio);
        }
        public bool CreateServicio(TServicio servicio)
        {
            return _oRepo.Add(servicio);
        }

        public bool DeleteServicio(int id)
        {
            return _oRepo.Delete(id);
        }
    }
}
