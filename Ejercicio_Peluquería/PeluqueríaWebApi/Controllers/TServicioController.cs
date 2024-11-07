using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Services.Contracts;

namespace PeluqueríaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TServicioController : ControllerBase
    {
        private readonly ITServicioService _serv;

        public TServicioController(ITServicioService serv)
        {
            _serv = serv;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var servicios = _serv.GetServicios();
                if (servicios.Count > 0)
                {
                    return Ok(servicios);
                }
                else
                {
                    return NotFound("No se han encontrado servicios.");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Debe ingresar un identificador válido.");
                }
                else
                {
                    var servicio = _serv.GetServiciosById(id);
                    if (servicio == null)
                    {
                        return NotFound($"No hay servicios con el identificador {id}.");
                    }
                    else
                    {
                        return Ok(servicio);
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpGet("GetByProm")]
        public IActionResult GetByProm([FromQuery] string prom)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(prom))  //
                {
                    var servsEnPromo = _serv.GetServiciosByProm(prom);
                    if (servsEnPromo.Count > 0)
                    {
                        return Ok(servsEnPromo);
                    }
                    else
                    {
                        return NotFound("No hay servicios en promoción.");
                    }
                }
                else
                {
                    return BadRequest("Debe ingresar S/N");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpGet("GetByCosto")]
        public IActionResult GetByCosto([FromQuery] int costoMenor)
        {
            try
            {
                if (costoMenor == 0)
                {
                    return BadRequest("Debe seleccionar un precio.");
                }
                else
                {
                    var serviciosMenores = _serv.GetServiciosByCosto(costoMenor);
                    if (serviciosMenores.Count > 0)
                    {
                        return Ok(serviciosMenores);
                    }
                    else
                    {
                        return NotFound($"No hay servicios con precios menores o iguales a ${costoMenor}.");
                    }
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                if (IsValid(servicio))
                {
                    var servAdded = _serv.AddServicio(servicio);
                    if (servAdded)
                    {
                        return Ok("Se ha agregado el servicio solicitado.");
                    }
                    else
                    {
                        return BadRequest("El identificador ya está en uso. Debe ingresar uno nuevo.");
                    }
                }
                else
                {
                    return BadRequest("Debe ingresar todos los campos obligatorios.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] TServicio servicio)
        {
            try
            {
                if (IsValid(servicio))
                {
                    var servUpdated = _serv.UpdateServicio(servicio);
                    if (servUpdated)
                    {
                        return Ok("Se ha modificado el servicio solicitado.");
                    }
                    else
                    {
                        return NotFound($"No se encontró un servicio con el identificador {servicio.Id}");
                    }
                }
                else
                {
                    return BadRequest("Debe ingresar todos los campos obligatorios.");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }

        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest("Debe ingresar un identificador válido.");
                }
                else
                {
                    var servDeleted = _serv.DeleteServicio(id);
                    if (servDeleted)
                    {
                        return Ok("Se ha eliminado el servicio solicitado.");
                    }
                    else
                    {
                        return NotFound($"No se encontraron servicios con el id {id}.");
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno. Intente más tarde.");
            }
        }


        private bool IsValid(TServicio serv)   //los campos son todos not null en la BD, por eso hace falta validar cada properti
        {
            if (!string.IsNullOrWhiteSpace(serv.Nombre) && serv.Costo >= 0 && !string.IsNullOrWhiteSpace(serv.EnPromocion))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
