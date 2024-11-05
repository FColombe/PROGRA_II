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
    public class TServicioService : ITServicioService
    {
        private readonly ITServicioRepository _repo;

        public TServicioService(ITServicioRepository repo)
        {
            _repo = repo;
        }

        public List<TServicio> GetServicios()
        {
            return _repo.GetAll();
        }

        public List<TServicio> GetServiciosByCosto(int costoMenor)
        {
            return _repo.GetByCosto(costoMenor);
        }

        public TServicio? GetServiciosById(int id)
        {
            return _repo.GetById(id);
        }

        public List<TServicio> GetServiciosByProm(string prom)
        {
            return _repo.GetByProm(prom);
        }

        public bool AddServicio(TServicio TServicio)
        {
            return _repo.Add(TServicio);
        }

        public bool DeleteServicio(int id)
        {
            return _repo.Delete(id);
        }

        public bool UpdateServicio(TServicio TServicio)
        {
            return _repo.Update(TServicio);
        }
    }
}
