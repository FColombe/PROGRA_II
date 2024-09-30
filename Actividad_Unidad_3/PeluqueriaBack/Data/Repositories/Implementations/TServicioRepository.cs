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

        private readonly PELUQUERIADBContext _context;

        public TServicioRepository(PELUQUERIADBContext context)   //Inyección de dependencia
        {
            _context = context;
        }


        public List<TServicio> GetAll()
        {
            return _context.TServicios.ToList();
        }

        public TServicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }


        public List<TServicio> GetByCosto(int costo)
        {
            return _context.TServicios.Where(TServicio => TServicio.Costo == costo).ToList();
        }

        public List<TServicio> GetByProm(string prom)
        {
            return _context.TServicios.Where(TServicio => TServicio.EnPromocion == prom).ToList();
        }

        public bool Add(TServicio TServicio)
        {
            _context.TServicios.Add(TServicio);  //Todavía estoy en memoria
            _context.SaveChanges();              //Este método es el que va a la BD y realiza los cambios

            return true;
        }

        public bool Delete(int id)
        {
            var servicioDeleted = this.GetById(id);
            if (servicioDeleted != null)
            {
                _context.TServicios.Remove(servicioDeleted);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(TServicio TServicio)
        {
                       
            if (TServicio != null)
            {
                _context.TServicios.Update(TServicio);
                _context.SaveChanges();
                return true;
            }
            else
            { return false; }   
        }
    }
}
