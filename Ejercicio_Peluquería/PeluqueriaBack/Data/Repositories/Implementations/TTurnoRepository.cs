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
        private readonly PELUQUERIAContext _context;

        public TTurnoRepository(PELUQUERIAContext context)
        {
            _context = context;
        }

        public List<TTurno> GetAll()
        {
            return _context.TTurnos.Where(x => !x.FechaCanc.HasValue).ToList();
        }

        public List<TTurno> GetByCliente(string cliente)
        {
            return _context.TTurnos.ToList().Where(x => x.Cliente.Equals(cliente.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();  //EF NO ADMITE EL MÉTODO STRINGCOMPARISION; ESTA ES UNA FORMA PARA HACERLO PERO POCO EFICIENTE PORQUE TRAE TODA LA LISTA Y LUEGO FILTRA EN MEMORIA.
        }

        public List<TTurno> GetByFecha(string fecha1)
        {
            return _context.TTurnos.Where(x => x.Fecha.Equals(fecha1)).ToList();
        }

        public TTurno? GetById(int id)
        {
            return _context.TTurnos.Find(id);
        }

        public bool Add(TTurno t)
        {
            bool exists = _context.TTurnos.Any(x => x.Fecha.Equals(t.Fecha) && x.Hora.Equals(t.Hora));
            if (exists)
            {
                return false;
            }
            else
            {
                _context.TTurnos.Add(t);
                return  _context.SaveChanges() > 0;
            }
        }

        //TRANSACCIÓN
        public async Task<bool> ReservarTurno(TTurno turno)
        {
            using (var trans = await _context.Database.BeginTransactionAsync())
            {
                try
                {

                    _context.TTurnos.Add(turno);
                    await _context.SaveChangesAsync();

                    foreach (var detalle in turno.TDetallesTurnos)
                    {
                        detalle.IdTurno = turno.Id;
                    }

                    await _context.SaveChangesAsync();

                    await trans.CommitAsync();

                    return true;
                }
                catch 
                {
                    await trans.RollbackAsync();    
                    return false;
                }
            }
        }

        public bool Delete(int id, DateTime fechaCancelacion, string motivo)
        {
            var turnoDelete = _context.TTurnos.Find(id);
            if (turnoDelete != null)
            {
                turnoDelete.FechaCanc = fechaCancelacion;
                turnoDelete.MotivoCanc = motivo;
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool Update(TTurno t)
        {
            var turnoUpdate = _context.TTurnos.FirstOrDefault(x => x.Id == t.Id);
            if (turnoUpdate != null)
            {
                turnoUpdate.Cliente = t.Cliente;
                turnoUpdate.Fecha = t.Fecha;
                turnoUpdate.Hora = t.Hora;

                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
