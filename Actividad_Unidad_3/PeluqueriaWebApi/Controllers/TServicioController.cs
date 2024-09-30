using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Services.CONTRACTS;
using System.Data.SqlTypes;
using System.Linq.Expressions;

//COLOMBETTI, FLORENCIA Mat. 412289

namespace PeluqueriaWebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //     NO TOMA ESTOS DECORADORES GLOBALES


    public class TServicioController : Controller
    {
        
        private readonly ITServicioService _serv;
        public TServicioController(ITServicioService TServicioService)
        {
            _serv = TServicioService;
        }

        [HttpGet("api/[controller]")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_serv.GetServicioList());
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error interno. Intente nuevamente.");
            }
        }

        [HttpGet("api/[controller]/GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Se esperaba un identificador válido.");
                }
                else
                {
                    var servcioExist = _serv.GetServicioId(id);
                    if (servcioExist != null)
                    {
                        return Ok(servcioExist);
                    }
                    else
                    {
                        return NotFound("No existe un servicio con ese identificador.");
                    }
                }
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error. Intente nuevamente.");
            }
        }

        [HttpGet("api/[controller]/GetByProm/{prom}")]
        public IActionResult GetByProm(string prom)
        {
            try
            {
                if(string.IsNullOrEmpty(prom))
                {
                    return BadRequest("Se esperaba un filtro.");
                }
                else
                {
                    return Ok(_serv.GetServicioProm(prom));
                }
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error. Intente nuevamente.");
            }
        }

        [HttpGet("api/[controller]/GetByCosto/{costo}")]
        public IActionResult GetByCosto(int costo)
        {
            try
            {
                if(costo == 0)
                {
                    return BadRequest("Se esperaba un monto para filtrar.");
                }
                else
                {
                    return Ok(_serv.GetServicioCosto(costo));
                }
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error. Intente nuevamente.");
            }
        }


        [HttpPost("api/[controller]")]
        public IActionResult Post([FromBody] TServicio servicio)   
        {
            try
            {
                if (this.IsValid(servicio) == false)
                {
                    return BadRequest("Se esperaba un servicio con todos los datos requeridos.");
                }
                else
                {
                    var servExists = _serv.GetServicioList().FirstOrDefault(TServicio => TServicio.Id == servicio.Id);
                    if (servExists != null)
                    {
                        return BadRequest("El identificador utilizado ya está en uso; aporte uno nuevo.");
                    }
                    else
                    {
                        var servAdded = _serv.CreateServicio(servicio);
                        if (servAdded)
                        {
                            return Ok("Se pudo agregar el servicio correctamente.");
                        }
                        else
                        {
                            return StatusCode(500, "No se pudo agregar el servicio. Intente nuevamente.");
                        }
                    }
                }
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error interno. Intente nuevamente.");
            }
        }

        [HttpPut("api/[controller]")]
        public IActionResult Put([FromBody] TServicio servicio)
        {
            try
            {
                if(servicio == null)
                {
                    return BadRequest("Se esperaban los datos completos de un servicio.");
                }
                else
                {
                    var servUpdate = _serv.GetServicioId(servicio.Id);   //Llama al método de filtro por ID para ver si existe o no el servicio a modificar. Tendría que hacerlo en el repository?
                    
                    if(servUpdate != null)
                    {
                        servUpdate.Nombre = servicio.Nombre;              //Hay que asignar las propertis del q viene del swagger al que trae el método getbyid, pq sino se pisan y pasa al catch
                        servUpdate.Costo = servicio.Costo;
                        servUpdate.EnPromocion = servicio.EnPromocion;

                        if(_serv.UpdateServicio(servUpdate))
                        {
                            return Ok("El servicio fue modificado con éxito.");
                        }
                        else
                        {
                            return StatusCode(500, "No se pudo modificar el servicio seleccionado.");
                        }
                    }
                    else
                    {
                        return NotFound("No existen servicios con el identificador seleccionado.");
                    }
                }
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error interno. Pruebe nuevamente.");
            }
        }

        [HttpDelete("api/[controller]")]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Debe seleccionar un identificador válido.");
                }
                else
                {
                    if(_serv.DeleteServicio(id))                 //El filtro por id para ver si existe está en el repository: si viene false, devuelve NotFound; pero si no se puede eliminar, va al catch?
                    {
                        return Ok("El servicio fue eliminado.");
                    }
                    else
                    {
                        return NotFound("No se encontró un servicio con el identificador indicado.");
                    }
                }
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error interno. Pruebe nuevamente.");
            }
        }

        public bool IsValid(TServicio serv)   //los campos son todos not null en la BD, por eso hace falta validar cada properti
        {
            if(serv.Id !=0 && !string.IsNullOrWhiteSpace(serv.Nombre) && serv.Costo != 0 && !string.IsNullOrWhiteSpace(serv.EnPromocion))
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
