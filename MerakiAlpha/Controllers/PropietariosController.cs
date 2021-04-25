using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerakiAlpha.Models;
using MerakiAlpha.Models.Interfaces;
using MerakiAlpha.Models.Join;

namespace MerakiAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietariosController : ControllerBase
    {
        private readonly IPropietario _context;
        public PropietariosController(IPropietario context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListPropietario>>> GetPropietarios()
        {
            return await _context.ListPropietarios();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PropietarioDetalleJoin>> GetPropietario(int? id)
        {
            var vergil = HttpContext.Session.GetString("IdUsuario");
            var propietario = await _context.Detallepropitario(id.Value);
            if (propietario == null)
                return NotFound();
            return propietario;
        }
        // GET: api/Propietarios/5
        [HttpGet]
        [Route("DetallePropietario/{id}")]
        public async Task<ActionResult<Propietario>> GetReactPropietario(int? id)
        {
            var propietario = await _context.Propitario(id.Value);
            if (propietario == null)
                return NotFound();
            return propietario;
        }
        [HttpGet]
        [Route("ListaDocumento")]
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> GetListaDocumento()
        {
            return await _context.ListaTipoDocumento();
        }
        [HttpGet]
        [Route("ListaGenero")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGenero()
        {
            return await _context.ListaGenero();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropietario(int id, Propietario propietario)
        {
            if (id != propietario.IdPropietario)
            {
                return BadRequest();
            }
            try
            {
                await _context.GuardarEditar(propietario);
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return NoContent();
        }
        [HttpPut]
        [Route("EditarEstado/{id}")]
        public async Task<ActionResult<Propietario>> EditarEstado(String id)
        {
            await _context.CambiarEstado(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Propietario>> PostPropietario(Propietario propietario)
        {
            await _context.GuardarEditar(propietario);
            return CreatedAtAction("GetPropietario", new { id = propietario.IdPropietario }, propietario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Propietario>> DeletePropietario(int? id)
        {
            Propietario propietario = await _context.Propitario(id.Value);
            if (propietario == null)
            {
                return NotFound();
            }
            await _context.DeletePropietario(id.Value);
            return propietario;
        }
    }
}