using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Repositories.Implementations
{
    public class TServicioRepository : ITServicioRepository
    {
        private readonly PELUQUERIAContext _context;

        public TServicioRepository(PELUQUERIAContext context)
        {
            _context = context;
        }

        public List<TServicio> GetAll()
        {
            return _context.TServicios.ToList();
        }

        public List<TServicio> GetByCosto(int costoMenor)
        {
            return _context.TServicios.Where(x => x.Costo <= costoMenor).ToList();
        }

        public TServicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }

        public List<TServicio> GetByProm(string prom)
        {
            return _context.TServicios.Where(x => x.EnPromocion.Equals(prom.Trim())).ToList();
        }

        public bool Add(TServicio TServicio)
        {
            var servAdded = _context.TServicios.Any(x => x.Id == TServicio.Id);
            if (!servAdded)
            {
                _context.TServicios.Add(TServicio);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var servDeleted = _context.TServicios.Find(id);
            if (servDeleted != null)
            {
                _context.TServicios.Remove(servDeleted);
                return _context.SaveChanges() > 0;
            }
            else
            { 
                return false; 
            }
        }

        public bool Update(TServicio TServicio)
        {
            var servExists = _context.TServicios.FirstOrDefault(x => x.Id == TServicio.Id);
            if (servExists != null)
            {
                servExists.Nombre = TServicio.Nombre;
                servExists.Costo = TServicio.Costo;
                servExists.EnPromocion  = TServicio.EnPromocion;
                return _context.SaveChanges() > 0;
            }
            else
            { 
                return false; 
            }
        }
    }
}
