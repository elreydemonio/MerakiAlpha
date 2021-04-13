using MerakiAlpha.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//Rama caice
namespace MerakiAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly ConfiguracionGlobal _configuracionGlobal;
        public UsuariosController(UserManager<UsuarioIdentity> userManager,
            SignInManager<UsuarioIdentity> signInManager, IOptions<ConfiguracionGlobal> configuracionGlobal)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuracionGlobal = configuracionGlobal.Value;
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
        [HttpPost]
        [Route("Login")]
        //POST: /api/Usuario/Login
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var usuario = await _userManager.FindByNameAsync(loginModel.NombreUsuario).ConfigureAwait(false);
            if (usuario != null && await _userManager.CheckPasswordAsync(usuario, loginModel.Password).ConfigureAwait(false))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UsuarioID", usuario.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracionGlobal.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { token });

            }
            else
            {
                return BadRequest(new { mensaje = "Nombre de usuario o contraseña incorrecta" });
            }
        }
        [HttpGet]
        [Route("Perfil")]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> ObtenerPerfilUsuario()
        {
            string usuarioId = User.Claims.First(c => c.Type == "UsuarioID").Value;
            var usuario = await _userManager.FindByIdAsync(usuarioId).ConfigureAwait(false);

            if (usuario != null)
            {
                return new
                {
                    usuario.Nombre,
                    usuario.Email,
                    usuario.UserName,
                    usuario.IdEstado,
                    usuario.IdRol,
                    usuario.idUsuario
                };
            }
            else
            {
                return BadRequest(new { mensaje = "No se encuentra el usuario" });
            }

        }

    }
}
