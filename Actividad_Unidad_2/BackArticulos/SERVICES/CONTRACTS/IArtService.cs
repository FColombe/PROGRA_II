using BackArticulos.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.SERVICES.CONTRACTS
{
    public interface IArtService
    {
        List<Articulo> GetArt();
        Articulo GetArtId(int id);
        bool AddArt(Articulo articulo);
        bool RemoveArt(int id);
        bool UpdateArt(Articulo articulo);
    }
}
