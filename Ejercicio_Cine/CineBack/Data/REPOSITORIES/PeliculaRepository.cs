using CineBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Data.REPOSITORIES
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly cineContext _context;

        public PeliculaRepository(cineContext context)
        {
            _context = context;
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.Where(p => p.Estreno == true).ToList();
        }
        public Pelicula? Get(int id)
        {
            return _context.Peliculas.Find(id);
        }


        public bool Add(Pelicula peli)
        {
            peli.Estreno = true;
            _context.Peliculas.Add(peli);                    
            return  _context.SaveChanges() > 0;
        }

        public bool Update(Pelicula peli)
        {
            var peliUpdated = _context.Peliculas.Find(peli.Id);
            if(peliUpdated != null)
            {
                peliUpdated.Titulo = peli.Titulo;
                peliUpdated.Director = peli.Director;
                peliUpdated.Anio = peli.Anio;
                peliUpdated.Estreno = peli.Estreno;
                peliUpdated.IdGenero = peli.IdGenero;

                _context.Peliculas.Update(peliUpdated);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var peliDeleted = _context.Peliculas.Find(id);      
            if (peliDeleted != null)
            {
                peliDeleted.Estreno = false;
                //_context.Peliculas.Update(peliDeleted);     NO HACE FALTA LLAMAR AL MÉTODO UPDATE, PORQUE YA MODIFICA EN LA BASE A PARTIR DEL VALOR DE LA PROPERTI MODIFICADO
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
       
    }
}
