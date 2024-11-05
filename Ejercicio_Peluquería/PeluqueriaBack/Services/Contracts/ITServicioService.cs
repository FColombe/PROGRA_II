using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Services.Contracts
{
    public interface ITServicioService
    {
        List<TServicio> GetServicios();
        TServicio? GetServiciosById(int id);
        List<TServicio> GetServiciosByProm(string prom);
        List<TServicio> GetServiciosByCosto(int costoMenor);  
        bool AddServicio(TServicio TServicio);
        bool UpdateServicio(TServicio TServicio);
        bool DeleteServicio(int id);
    }
}
