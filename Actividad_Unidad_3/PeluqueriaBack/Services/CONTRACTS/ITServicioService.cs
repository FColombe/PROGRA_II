using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Services.CONTRACTS
{
    public interface ITServicioService
    {
        List<TServicio> GetServicioList();
        TServicio? GetServicioId(int id);
        List<TServicio> GetServicioProm(string promId);
        List<TServicio> GetServicioCosto(int costo);

        bool CreateServicio(TServicio servicio);
        bool UpdateServicio(TServicio servicio);
        bool DeleteServicio(int id);    

    }
}
