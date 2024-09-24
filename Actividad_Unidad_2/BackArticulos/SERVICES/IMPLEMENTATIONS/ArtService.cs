using BackArticulos.DATA.CONTRACTS;
using BackArticulos.DATA.IMPLEMENTATIONS;
using BackArticulos.MODELS;
using BackArticulos.SERVICES.CONTRACTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackArticulos.SERVICES.IMPLEMENTATIONS
{
    public class ArtService : IArtService
    {

        private IArticuloRepository oRepoArt;

        public ArtService()
        {
            oRepoArt = new ArticuloRepository();
        }


        public bool AddArt(Articulo articulo)
        {
            return oRepoArt.Add(articulo);
        }

        public List<Articulo> GetArt()
        {
            return oRepoArt.GetAll();
        }

        public Articulo GetArtId(int id)
        {
            return oRepoArt.GetById(id);
        }

        public bool RemoveArt(int id)
        {
            return oRepoArt.Delete(id);
        }

        public bool UpdateArt(Articulo articulo)
        {
            return oRepoArt.Update(articulo);
        }

    }
}
