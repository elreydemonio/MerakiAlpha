using MerakiAlpha.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;

        public UsuariosController(UserManager<UsuarioIdentity> userManager, SignInManager<UsuarioIdentity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("Registro")]
        public async Task<Object> PostUsuario(UsuarioModel usuarioModel)
        {
            UsuarioIdentity usu = new UsuarioIdentity()
            {
                UserName = usuarioModel.NombreUsuario,
                Email = usuarioModel.Email,
                Nombre = usuarioModel.Nombre,
                idUsuario = usuarioModel.idUsuario,
                IdEstado = usuarioModel.IdEstado,
                IdRol = usuarioModel.IdRol
            };
            try
            {
                var result = await _userManager
                    .CreateAsync(usu, usuarioModel.Password).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
