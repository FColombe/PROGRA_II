﻿using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Repositories.Contracts
{
    public interface ITServicioRepository
    {
        List<TServicio> GetAll();
        TServicio? GetById(int id);
        List<TServicio> GetByProm(string prom);
        List<TServicio> GetByCosto(int costo);
        bool Add(TServicio TServicio);
        bool Update(TServicio TServicio);
        bool Delete(int id);

    }
}