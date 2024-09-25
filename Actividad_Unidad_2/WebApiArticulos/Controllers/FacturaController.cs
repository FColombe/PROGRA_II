using Microsoft.AspNetCore.Mvc;
using BackArticulos.MODELS;
using BackArticulos.SERVICES.CONTRACTS;
using BackArticulos.SERVICES.IMPLEMENTATIONS;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

//COLOMBETTI, FLORENCIA MAT. 412289


namespace WebApiArticulos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FacturaController : ControllerBase
    {
        private IFacturaService serv;

        public FacturaController()
        {
            serv = new FacturaService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(serv.GetFacturas());
        }

        [HttpGet("GetByDate")]
        public IActionResult GetByDate([FromQuery] DateTime date)
        {
            try
            {
                if (date != null)
                {
                    var facts = serv.GetFacturasByDate(date);
                    if (facts != null)
                    {
                        return Ok(facts);
                    }
                    else
                    {
                        return NotFound("No se encontraron facturas con esa fecha.");
                    }
                }
                else
                {
                    return BadRequest("Se esperaba una fecha.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo procesar la solicitud. Intente nuevamente.");
            }
        }

        [HttpGet("GetByPay")]
        public IActionResult GetByPay([FromQuery] int id)
        {
            try
            {
                if (id != null)
                {
                    var facts = serv.GetFacturasByPay(id);
                    if (facts != null)
                    {
                        return Ok(facts);
                    }
                    else
                    {
                        return NotFound("No se encontraron facturas con esa forma de pago.");
                    }

                }
                else
                {
                    return BadRequest("Se esperaba un identificador de la forma de pago.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo procesar la solicitud. Intente nuevamente.");
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int nro)
        {
            try
            {
                if (nro != null)
                {
                    var fact = serv.GetFacturasById(nro);
                    if (fact != null)
                    {
                        return Ok(fact);
                    }
                    else
                    {
                        return NotFound("No se encontró ninguna factura con ese número.");
                    }
                }
                else
                {
                    return BadRequest("Se esperaba un nro de factura.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo procesar la solicitud. Intente nuevamente.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Factura factura)
        {
            try
            {
                if (factura != null)
                {
                    var added = serv.AddFactura(factura);
                    if (added)
                    {
                        return Ok("La factura fue cargada.");
                    }
                    else
                    {
                        return StatusCode(500, "No se pudo cargar la factura. Intente nuevamente.");
                    }
                }
                else
                {
                    return BadRequest("Se esperaban los datos de una factura para cargar.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo procesar la solicitud. Intente nuevamente.");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Factura factura)
        {
            try
            {
                if (factura != null)
                {
                    var existFactura = serv.GetFacturasById(factura.Nro);
                    if (existFactura != null)
                    {
                        var modified = serv.UpdateFactura(factura);
                        if (modified)
                        {
                            return Ok("La factura fue modificada con éxito.");
                        }
                        else
                        {
                            return StatusCode(500, "No se pudo modificar la factura.");
                        }
                    }
                    else
                    {
                        return NotFound("No se pudo hallar la factura solicitada.");
                    }
                }
                else
                {
                    return BadRequest("Debe ingresar un número de factura válido.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. No se pudo procesar la solicitud.");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int nro)
        {
            try
            {
                if (nro <= 0)
                {
                    return BadRequest("Debe ingresar un número de factura válido.");
                }
                else
                {
                    var existFactura = serv.GetFacturasById(nro);
                    if (existFactura != null)
                    {
                        var deleted = serv.DeleteFactura(nro);
                        if (deleted)
                        {
                            return Ok("La factura fue anulada con éxito.");
                        }
                        else
                        {
                            return StatusCode(500, "No se pudo anular la factura.");
                        }
                    }
                    else
                    {
                        return NotFound("No se pudo hallar la factura solicitada.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. No se pudo procesar la solicitud.");
            }
        }
    }
}



