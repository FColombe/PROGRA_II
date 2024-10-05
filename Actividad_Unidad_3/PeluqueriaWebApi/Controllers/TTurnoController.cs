using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Services.CONTRACTS;


namespace PeluqueriaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TTurnoController : ControllerBase
    {
        private readonly ITTurnoService _service;

        public TTurnoController(ITTurnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lst = await _service.GetTurnos();
                if (lst == null)
                {
                    return Ok(lst);
                }
                else
                {
                    return NotFound("No hay turnos registrados.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno.Intente nuevamente.");
            }
        }

        [HttpGet("/GetCancels/{days}")]
        public async Task<IActionResult> GetCancels(int days)
        {
            try
            {
                var lst = await _service.GetCancelados(days);
                if (lst == null)
                {
                    return NotFound("No se hallaron turnos cancelados en el período indicado.");
                }
                else
                {
                    return Ok(lst);
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.Intente nuevamente.");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Debe ingresar un identificador válido");
                }
                else
                {
                    var turno = await _service.GetById(id);
                    if (turno != null)
                    {
                        return Ok(turno);
                    }
                    else
                    {
                        return NotFound("No se encontró el turno solicitado.");
                    }
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.Intente nuevamente.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TTurno turno)
        {
            try
            {
                if (this.IsValid(turno))
                {
                    return Ok(await _service.Add(turno));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsValid(TTurno t)
        {
            var fecha = Convert.ToDateTime(t.Fecha);
            var fechaMin = DateTime.Today.AddDays(1);
            var fechaMax = DateTime.Today.AddDays(45);


            return !String.IsNullOrWhiteSpace(t.Cliente)
                    && !String.IsNullOrWhiteSpace(t.Fecha)
                    && !String.IsNullOrWhiteSpace(t.Hora)
                    && fecha < fechaMin
                    && fecha > fechaMax;

        }
    }
}
