using Microsoft.AspNetCore.Mvc;
using BackArticulos.MODELS;
using BackArticulos.SERVICES.CONTRACTS;
using BackArticulos.SERVICES.IMPLEMENTATIONS;
using System.Reflection.Metadata.Ecma335;

namespace WebApiArticulos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FacturaController : ControllerBase
    {
        private IFacturaService serv;                     //No me deja llamar a la interface

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
        public IActionResult GetByDate (DateTime date)
        {
            try
            {
                if(date != null)
                {
                    var facts = serv.GetFacturasByDate(date);
                    return Ok(facts);
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
        public IActionResult GetByPay(int id)
        {
            try
            {
                if (id != null)
                {
                    var facts = serv.GetFacturasByPay(id);
                    return Ok(facts);
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
        public IActionResult GetById(int nro)
        {
            try
            {
                if (nro != null)
                {
                    var fact = serv.GetFacturasById(nro);
                    return Ok(fact);
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
                        return StatusCode(500, "No se pudo procesar la solicitud. Intente nuevamente.");
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

       
    }
}
