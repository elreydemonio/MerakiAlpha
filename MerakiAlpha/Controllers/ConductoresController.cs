using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerakiAlpha.Models;
using MerakiAlpha.Models.Join;
using MerakiAlpha.Usuarios;

namespace MerakiAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {
        private readonly MerakiContext _context;

        public ConductoresController(MerakiContext context)
        {
            _context = context;
        }

        // GET: api/Conductores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListConductor>>> GetConductores()
        {
            ActionResult<IEnumerable<ListConductor>> conductores = await
            (from C in _context.Conductores
             join G in _context.Generos on C.IdGenero equals G.IdGenero
             join T in _context.TiposDocumentos on C.IdTipoDocumento equals T.IdTipoDocumento
             join U in _context.UsuariosIdentity on C.Correo equals U.Email
             select new ListConductor
             {
                 IdConductor = C.IdConductor,
                 Genero = G.Descripcion,
                 Nombre = C.Nombre,
                 Apellido = C.Apellido,
                 TipoDocumento = T.Descripcion,
                 NumeroDocumento = C.NumeroDocumento,
                 IdUsuario = U.Id,
                 Direccion = C.Direccion,
                 FechaInicio = C.FechaInicio
             }).ToListAsync();

            return conductores;
        }

        [HttpGet]
        [Route("ListaDocumento")]
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> GetListaTipoDocumento()
        {
            return await _context.TiposDocumentos.ToListAsync();
        }

        [HttpGet]
        [Route("ListaGenero")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetListaGenero()
        {
            return await _context.Generos.ToListAsync();
        }

        // GET: api/Conductores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleConductor>> GetConductores(int? id)
        {
            DetalleConductor Detalleconductor = await
                           (from C in _context.Conductores
                            join G in _context.Generos on C.IdGenero equals G.IdGenero
                            join T in _context.TiposDocumentos on C.IdTipoDocumento equals T.IdTipoDocumento
                            where C.IdConductor == id
                            select new DetalleConductor
                            {
                                IdConductor = C.IdConductor,
                                Genero = G.Descripcion,
                                Celular = C.Celular,
                                Nombre = C.Nombre,
                                TipoDocumento = T.Descripcion,
                                Apellido = C.Apellido,
                                Correo = C.Correo,
                                NumeroDocumento = C.NumeroDocumento,
                                Direccion = C.Direccion,
                                FechaInicio = C.FechaInicio,
                                FechaFin = C.FechaFin,
                                FotoConductor = C.FotoConductor,
                                CodigoV = C.CodigoV
                            }).FirstAsync();
            return Detalleconductor;
        }

        // PUT: api/Conductores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConductore(int id, Conductore conductore)
        {
            if (id != conductore.IdConductor)
            {
                return BadRequest();
            }

            _context.Entry(conductore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConductoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/Conductores/5
        [HttpGet]
        [Route("DetalleConductor/{id}")]
        public async Task<ActionResult<Conductore>> GetAngularConductor(int? id)
        {
            Conductore conductor;
            conductor = await _context.Conductores.FindAsync(id.Value);
            if (conductor == null)
                return NotFound();
            return conductor;
        }

        // POST: api/Conductores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conductore>> PostConductore(Conductore conductore)
        {
            _context.Conductores.Add(conductore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConductore", new { id = conductore.IdConductor }, conductore);
        }

        // DELETE: api/Conductores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConductore(int id)
        {
            var conductore = await _context.Conductores.FindAsync(id);
            if (conductore == null)
            {
                return NotFound();
            }

            _context.Conductores.Remove(conductore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConductoreExists(int id)
        {
            return _context.Conductores.Any(e => e.IdConductor == id);
        }
    }
}
