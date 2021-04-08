using MerakiAlpha.Models.Interfaces;
using MerakiAlpha.Models.Join;
using MerakiAlpha.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models.Servicios
{
    public class ServiciosPropietario : IPropietario
    {
        private readonly MerakiContext _context;
        public ServiciosPropietario(MerakiContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<ListPropietario>>> ListPropietarios()
        {
            ActionResult<IEnumerable<ListPropietario>> propietarios = await
                                                        (from C in _context.Propietarios
                                                         join G in _context.Generos on C.IdGenero equals G.IdGenero
                                                         join T in _context.TiposDocumentos on C.IdTipoDocumento equals T.IdTipoDocumento
                                                         join U in _context.UsuariosIdentity on C.Correo equals U.Email
                                                         join E in _context.EstadoUsuarios on U.IdEstado equals E.IdEstadoUsuario
                                                         select new ListPropietario
                                                         {
                                                             IdPropietario = C.IdPropietario,
                                                             Apellido = C.Apellido,
                                                             NumeroDocumento = C.NumeroDocumento,
                                                             Celular = C.Celular,
                                                             Nombre = C.Nombre,
                                                             TipoDocumento = T.Descripcion,
                                                             idEstado = E.IdEstadoUsuario,
                                                             Estado = E.Descripcion,
                                                             IdUsuario = U.Id,
                                                             Direccion = C.Direccion
                                                         }).ToListAsync();

            return propietarios;
        }
        public async Task<Propietario> Propitario(int? id)
        {
            Propietario propietario = null;
            if (id == null)
            {
                return propietario;
            }
            else
            {
                propietario = await _context.Propietarios.FindAsync(id.Value);
                return propietario;
            }
        }
        public Task ActivarDesactivar(int id)
        {
            throw new NotImplementedException();
        }
        public async Task GuardarEditar(Propietario propietario)
        {
            try
            {
                if (propietario.IdPropietario == 0)
                    _context.Propietarios.Add(propietario);
                else
                    _context.Propietarios.Update(propietario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<PropietarioDetalleJoin> Detallepropitario(int? id)
        {
            PropietarioDetalleJoin Deallepropietario = await
                                                       (from C in _context.Propietarios
                                                        join G in _context.Generos on C.IdGenero equals G.IdGenero
                                                        join T in _context.TiposDocumentos on C.IdTipoDocumento equals T.IdTipoDocumento
                                                        where C.IdPropietario == id.Value
                                                        select new PropietarioDetalleJoin
                                                        {
                                                            IdPropietario = C.IdPropietario,
                                                            Genero = G.Descripcion,
                                                            Direccion = C.Direccion,
                                                            Celular = C.Celular,
                                                            Nombre = C.Nombre,
                                                            TipoDoumento = T.Descripcion,
                                                            Apellido = C.Apellido,
                                                            Correo = C.Correo,
                                                            NumeroDocumento = C.NumeroDocumento
                                                        }).FirstAsync();
            return Deallepropietario;
        }
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> ListaTipoDocumento()
        {
            ActionResult<IEnumerable<TiposDocumento>> ListaDocumento = await _context.TiposDocumentos.ToListAsync();
            return ListaDocumento;
        }
        public async Task<ActionResult<IEnumerable<Genero>>> ListaGenero()
        {
            ActionResult<IEnumerable<Genero>> ListaGenero = await _context.Generos.ToListAsync();
            return ListaGenero;
        }
        public async Task DeletePropietario(int? id)
        {
            var propietario = await Propitario(id);
            _context.Propietarios.Remove(propietario);
            await _context.SaveChangesAsync();
        }
        public async Task CambiarEstado(String id)
        {
            UsuarioIdentity usuario = await _context.UsuariosIdentity.FindAsync(id);
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
        }
    }
}
