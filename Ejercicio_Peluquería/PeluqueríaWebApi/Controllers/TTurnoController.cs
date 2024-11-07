using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Services.Contracts;
using System.Runtime.InteropServices;

namespace PeluqueríaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TTurnoController : ControllerBase
    {
        private readonly ITTurnoService _serv;

        public TTurnoController(ITTurnoService serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var turnos = _serv.GetTurnos();
                if (turnos.Count > 0)
                {
                    return Ok(turnos);
                }
                else
                {
                    return NotFound("No hay turnos agendados.");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpGet("GetByCliente")]
        public IActionResult GetByCliente([FromQuery] string cliente)
        {
            try
            {
                if (string.IsNullOrEmpty(cliente))
                {
                    return BadRequest("Debe ingresar el nombre de un cliente.");
                }
                else
                {
                    var turnosClientes = _serv.GetByCliente(cliente);
                    if (turnosClientes.Count > 0)
                    {
                        return Ok(turnosClientes);
                    }
                    else
                    {
                        return NotFound($"No se encontraron turnos para el cliente {cliente}");
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpGet("GetByFecha")]
        public IActionResult GetByFechas([FromQuery] string fecha1)
        {
            try
            {
                if ((this.ConvertFecha(fecha1) == null))
                {
                    return BadRequest("Debe ingresar una fecha en el formato correspondiente.");
                }
                else
                {
                    var turnoFecha = _serv.GetByFecha(fecha1);
                    if (turnoFecha.Count > 0)
                    {
                        return Ok(turnoFecha);
                    }
                    else
                    {
                        return NotFound($"No hay turnos en el día {fecha1}.");
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {

            try
            {
                if (id == 0)
                {
                    return BadRequest("Debe ingresar un id válido.");
                }
                else
                {
                    var turnoId = _serv.GetById(id);
                    if (turnoId == null)
                    {
                        return NotFound("No hay turnos con ese identificador.");
                    }
                    else
                    {
                        return Ok(turnoId);
                    }
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno. Intente más tarde.");
            }
            
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] TTurno turno)
        //{
        //    try
        //    {
        //        turno.Fecha = this.FechaDefault(turno);
        //        if(this.IsValid(turno) == false)
        //        {
        //            return BadRequest("Debe completar todos los campos en un formato válido.\nRecuerde que no se pueden agendar turnos con fechas anteriores al día de mañana ni con más de 45 días de antelación.");
        //        }
        //        else
        //        {
        //            if(_serv.AddTurno(turno))
        //            {
        //                return Ok("Se ha agendado el turno.");
        //            }
        //            else
        //            {
        //                return StatusCode(500, "Ya existe un turno en ese día y horario. Elegir otra fecha.");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(500, "Error interno. Intente más tarde.");
        //    }
        //}

        [HttpPut]
        public IActionResult Put([FromBody] TTurno turno)
        {
            try
            {
                turno.Fecha = this.FechaDefault(turno);
                if (this.IsValid(turno) == false)
                {
                    return BadRequest(@"Debe completar los campos en un formato válido. 
                                        Recuerde que no se pueden agendar turnos con fechas anteriores al día de mañana ni con más de 45 días de antelación.");
                }
                else
                {
                    if(_serv.UpdateTurno(turno))
                    {
                        return Ok("Se ha modificado el turno correctamente.");
                    }
                    else
                    {
                        return NotFound("No se pudo modificar el turno seleccionado. Verifique que el identificador sea válido");
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id, [FromQuery] DateTime fechaC, [FromQuery] string motivo)
        {
            try
            {
                if(id == 0 || fechaC == null)
                {
                    return BadRequest("Debe enviar los datos para la cancelación del turno");
                }
                else
                {
                    if(_serv.DeleteTurno(id, fechaC, motivo))
                    {
                        return Ok("El turno fue dado de baja exitosamente");
                    }
                    else
                    {
                        return NotFound("No se encontró el turno.");
                    }
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TTurno turno)
        {
            try
            {
                turno.Fecha = this.FechaDefault(turno);
                if (this.IsValid(turno) == false)
                {
                    return BadRequest("Debe completar todos los campos en un formato válido.\nRecuerde que no se pueden agendar turnos con fechas anteriores al día de mañana ni con más de 45 días de antelación.");
                }
                else
                {
                    var reserva = await _serv.Reservar(turno);
                    if (reserva)
                    {
                        return Ok("Se ha agendado el turno.");
                    }
                    else
                    {
                        return StatusCode(500, "Ya existe un turno en ese día y horario. Elegir otra fecha.");
                    }
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }











        private bool IsValid(TTurno t)                       //Método para validar los campos
        {
            var fechaValida = this.ConvertFecha(t.Fecha);
            var fechaMin = DateTime.Today.AddDays(1);
            var fechaMax = DateTime.Today.AddDays(45);


            return  !string.IsNullOrWhiteSpace(t.Cliente) 
                    //&& !string.IsNullOrWhiteSpace(t.Fecha)
                    && !string.IsNullOrEmpty(t.Hora)
                    && fechaValida >= fechaMin
                    && fechaValida <= fechaMax;
        }

        private string FechaDefault(TTurno t)                // Método para asignar un valor por defecto si no se ingresa una fecha
        {
            if(string.IsNullOrWhiteSpace(t.Fecha))
            {
                var fechaValida = DateTime.Today.AddDays(1);
                
                var fechaEnLetras = fechaValida.ToString("yyyy/MM/dd");
                return fechaEnLetras;
            }
            else
            { 
                return t.Fecha; 
            }
        }
        
        private DateTime? ConvertFecha(string fecha)        //Método para convertir los valores del campo varchar fecha a DateTime y evitar que se ingrese cualquier cosa
        {
            try
            {
                var fechaEnFecha = DateTime.Parse(fecha);
                return fechaEnFecha;
            }
            catch (FormatException e)
            {
                return null;
            }
        }
    }
}
