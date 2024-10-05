using CineBack.Data.Models;
using CineBack.Data.REPOSITORIES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace CineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaRepository _repository;

        public PeliculaController(IPeliculaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var peliculas = _repository.GetAll();
                if (peliculas == null)
                {
                    return NotFound("No se encontraron películas en cartelera.");
                }
                else
                {
                    return Ok(peliculas);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error.");
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pelicula peli)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Se esperaban todos los datos de una película.");
                }
                else
                {
                    var added = _repository.Add(peli);
                    if(added)
                    {
                        return Ok("La película fue agregada con éxito.");
                    }
                    else
                    {
                        return StatusCode(500, "Ocurrió un error. No se pudo agregar la película.");
                    }
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error.");
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] Pelicula peli)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_repository.Update(peli))
                    {
                        return Ok("Se modificó con éxito.");
                    }
                    else
                    {
                        return NotFound("No existe la película ingresada.");
                    }
                }
                else
                {
                    return BadRequest("Se esperan todos los datos de una película.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest("Se esperaba un identificador de película válido.");
                }
                else
                {
                    if(_repository.Delete(id))
                    {
                        return Ok("Se dio de baja la película en cartelera.");
                    }
                    else
                    {
                        return StatusCode(500, "No se pudo dar de baja la película. Intente nuevamente."); //Iría un found en lugar de este error?
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, "Error interno.");
            }
        }

    }
}
