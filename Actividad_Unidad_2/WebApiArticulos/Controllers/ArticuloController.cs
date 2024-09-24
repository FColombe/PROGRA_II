using BackArticulos.MODELS;
using BackArticulos.SERVICES.CONTRACTS;
using BackArticulos.SERVICES.IMPLEMENTATIONS;
using Microsoft.AspNetCore.Mvc;

//ESTUDIANTE: COLOMBETTI, Florencia 412289

namespace WebApiArticulos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    

    public class ArticuloController : ControllerBase
    {
        private IArtService serv;

        public ArticuloController()
        {
            serv = new ArtService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(serv.GetArt());
        }

        [HttpGet("Getbyid")]                    //Se le agrega algo a la ruta para que no pise el Get anterior
        public IActionResult Get(int id)
        {
            try
            {
                if (id != null)
                {
                    var art = serv.GetArtId(id);
                    if (art != null)
                    {
                        return Ok(art);
                    }
                    else
                    {
                        return NotFound("No existen artículos con ese código");
                    }
                }
                else
                {
                    return BadRequest("Se esperaba un código de artículo");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo procesar la solicitud.Intente nuevamente.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Articulo art)
        {
            try
            {
                if(art == null)
                {
                    return BadRequest("Se esperaban los datos de un artículo");
                }
                if (serv.AddArt(art))
                {
                    return Ok("Artículo ingresado con éxito.");
                }
                else
                {
                    return StatusCode(500, "No se pudo registrar el artículo.Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo procesar la solicitud.Intente nuevamente.");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Articulo art)
        {
            try
            {
                if (art == null)
                {
                    return BadRequest("Se esperaban los datos de un artículo");
                }
                if (serv.UpdateArt(art))
                {
                    return Ok("Artículo modificado con éxito.");
                }
                else
                {
                    return StatusCode(500, "No se pudo modificar el artículo.Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo procesar la solicitud.Intente nuevamente.");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Se esperaban los datos de un artículo");
                }
                if (serv.RemoveArt(id))
                {
                    return Ok("Artículo eliminado con éxito.");
                }
                else
                {
                    return StatusCode(500, "No se pudo eliminar el artículo.Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo procesar la solicitud.Intente nuevamente.");
            }
        }
    }
}
