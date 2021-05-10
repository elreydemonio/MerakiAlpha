using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerakiAlpha.Models;
using System.IO;

namespace MerakiAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoesController : ControllerBase
    {
        private string fotoV ;
        private readonly MerakiContext _context;

        public VehiculoesController(MerakiContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }
        [HttpGet]
        [Route("Tipovehiculos")]
        public async Task<ActionResult<IEnumerable<TipoVehiculo>>> GetTipoVechiuslo()
        {
            return await _context.TipoVehiculos.ToListAsync();
        }

        // GET: api/Vehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(string id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // PUT: api/Vehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(string id, Vehiculo vehiculo)
        {
            if (id != vehiculo.CodigoV)
            {
                return BadRequest();
            }
            string Fotov = Path.GetFileName(vehiculo.FotoV);
            string Seguro = Path.GetFileName(vehiculo.SeguroCarga);
            string soat = Path.GetFileName(vehiculo.Soat);
            string tecnomecanica = Path.GetFileName(vehiculo.TecnoMecanica);
            vehiculo.FotoV = Fotov;
            vehiculo.SeguroCarga = Seguro;
            vehiculo.Soat = soat;
            vehiculo.TecnoMecanica = tecnomecanica;

            _context.Vehiculos.Update(vehiculo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
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
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            int id = 1;
            int longitud = 7;
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");
            string codigoV = token.Substring(0, longitud);
            vehiculo.CodigoV = codigoV;
            vehiculo.IdPropietario = id;
            string Fotov = Path.GetFileName(vehiculo.FotoV);
            string Seguro = Path.GetFileName(vehiculo.SeguroCarga);
            string soat = Path.GetFileName(vehiculo.Soat);
            string tecnomecanica = Path.GetFileName(vehiculo.TecnoMecanica);
            vehiculo.FotoV = Fotov;
            vehiculo.SeguroCarga = Seguro;
            vehiculo.Soat = soat;
            vehiculo.TecnoMecanica = tecnomecanica;
            _context.Vehiculos.Add(vehiculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VehiculoExists(vehiculo.CodigoV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.CodigoV }, vehiculo);
        }
        [HttpPost]
        [Route("Imagenes")]
        public async Task<IActionResult> imagenes(IFormFile File)
        {
            var files = Request.Form.Files[0];
            string move = $"E:\\GitHub\\Sebastian\\MerakiFrontEnd\\src\\assets\\img";
            using (var fileStream = new FileStream(Path.Combine(move, File.FileName), FileMode.Create, FileAccess.Write))
            {
                await File.CopyToAsync(fileStream);
                this.fotoV = File.FileName;
            }

            return NoContent();
        }
        // DELETE: api/Vehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(string id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(string id)
        {
            return _context.Vehiculos.Any(e => e.CodigoV == id);
        }
    }
}
