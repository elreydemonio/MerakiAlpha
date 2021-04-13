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
//Rama Pablo
namespace MerakiAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly MerakiContext _context;

        public ClientesController(MerakiContext context)
        {
            _context = context;
        }

        //Hola

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListCliente>>> GetClientes()
        {
            ActionResult<IEnumerable<ListCliente>> clientes = await
            (from C in _context.Clientes
             join G in _context.Generos on C.IdGenero equals G.IdGenero
             join T in _context.TiposDocumentos on C.IdTipoDocumento equals T.IdTipoDocumento
             join U in _context.UsuariosIdentity on C.Correo equals U.Email
             join E in _context.EstadoUsuarios on U.IdEstado equals E.IdEstadoUsuario
             select new ListCliente
             {
                 IdCliente = C.IdCliente,
                 Genero = G.Descripcion,
                 Nombre = C.Nombre,
                 Apellido = C.Apellido,
                 TipoDocumento = T.Descripcion,
                 NumeroDocumento = C.NumeroDocumento,
                 IdRol = U.IdEstado,
                 Estado = E.Descripcion,
                 IdUsuario = U.idUsuario
             }).ToListAsync();

            return clientes;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPut]
        [Route("EditarEstado/{id}")]
        public async Task<ActionResult<Cliente>> EditarEstado(int? id)
        {
            UsuarioIdentity usuario = await _context.UsuariosIdentity.FindAsync(id.Value);
            if (usuario.IdEstado == 1)
            {
                int? estado = 2;
                usuario.IdEstado = estado.Value;
                _context.UsuariosIdentity.Update(usuario);
            }
            else if (usuario.IdEstado == 2)
            {
                int? estado = 1;
                usuario.IdEstado = estado.Value;
                _context.UsuariosIdentity.Update(usuario);
            }
            await _context.SaveChangesAsync();
            return NoContent();
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

        // GET: api/Clientes/5
        [HttpGet]
        [Route("DetalleCliente/{id}")]
        public async Task<ActionResult<DetalleCliente>> GetClientes(int? id)
        {
            DetalleCliente Detallecliente = await
                           (from C in _context.Clientes
                            join G in _context.Generos on C.IdGenero equals G.IdGenero
                            join T in _context.TiposDocumentos on C.IdTipoDocumento equals T.IdTipoDocumento
                            where C.IdCliente == id
                            select new DetalleCliente
                            {
                                IdCliente = C.IdCliente,
                                Genero = G.Descripcion,
                                Celular = C.Celular,
                                Nombre = C.Nombre,
                                TipoDocumento = T.Descripcion,
                                Apellido = C.Apellido,
                                Correo = C.Correo,
                                NumeroDocumento = C.NumeroDocumento
                            }).FirstAsync();
            return Detallecliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
