using Microsoft.EntityFrameworkCore;
using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Repositories.Implementations
{
    public class TTurnoRepository : ITTurnoRepository
    {
        private readonly PELUQUERIADBContext _context;

        public TTurnoRepository(PELUQUERIADBContext context)
        {
            _context = context;
        }


        public async Task<List<TTurno>> GetAll()
        {
            return await _context.TTurnos.Where(x => !x.FechaCanc.HasValue).ToListAsync();
        }

        public async Task<TTurno>? GetById(int id)
        {
            return await _context.TTurnos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<TTurno>> GetCancels(int days)                       //TRAE LOS TURNOS CANCELADOS EN LOS ÚLTIMOS X DÍAS
        {
           var fromDays = DateOnly.FromDateTime(DateTime.Today.AddDays(days));
           return await _context.TTurnos.Where( x => x.FechaCanc.HasValue && x.FechaCanc > fromDays).ToListAsync();
        }



        public async Task<bool> Add(TTurno t)
        {
            
            _context.TTurnos.Add(t);
            return await _context.SaveChangesAsync() > 0;
 
        }

        public async Task<bool> Delete(int id, DateOnly fechCacel, string motivo)
        {
            var turnoCancelado = _context.TTurnos.Find(id);
            turnoCancelado.FechaCanc = fechCacel;
            turnoCancelado.MotivoCanc = motivo;
            return await _context.SaveChangesAsync() > 0;
        }

     

        public async Task<bool> Update(TTurno t)             //PERMITE MODIFICAR LOS DATOS DE UN TURNO DADO, PERO SIN CANCELARLO
        {
            var turnoModified = await _context.TTurnos.FindAsync(t.Id);
            turnoModified.Cliente = t.Cliente;
            turnoModified.Fecha = t.Fecha;
            turnoModified.Hora = t.Hora;
            turnoModified.FechaCanc = null;
            turnoModified.MotivoCanc = string.Empty;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
