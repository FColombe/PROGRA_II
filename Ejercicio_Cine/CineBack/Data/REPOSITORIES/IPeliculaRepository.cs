using CineBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBack.Data.REPOSITORIES
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetAll();
        Pelicula Get(int id);
        bool Add(Pelicula peli);
        bool Update(Pelicula peli);
        bool Delete(int id);
    }
}
