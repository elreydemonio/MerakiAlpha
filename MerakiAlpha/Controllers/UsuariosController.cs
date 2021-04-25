using MerakiAlpha.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MerakiAlpha.Models.Join;
using MerakiAlpha.Models;
using Microsoft.EntityFrameworkCore;
//Rama caice
namespace MerakiAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public const string SessionKeyName = "_Name";
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly ConfiguracionGlobal _configuracionGlobal;
        private readonly MerakiContext _context;
        public UsuariosController(UserManager<UsuarioIdentity> userManager,
            SignInManager<UsuarioIdentity> signInManager, IOptions<ConfiguracionGlobal> configuracionGlobal, MerakiContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuracionGlobal = configuracionGlobal.Value;
            _context = context;
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
                        new Claim("UsuarioID", usuario.Id.ToString()),
                        new Claim("Rol", usuario.IdRol.ToString()),
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
        public async Task<object> ObtenerPerfilUsuario()
        {
            string usuarioId = User.Claims.First(c => c.Type == "UsuarioID").Value;
            var usuario = await _userManager.FindByIdAsync(usuarioId).ConfigureAwait(false);
           
            if (usuario != null)
            {
                HttpContext.Session.SetString(SessionKeyName, usuario.Id);
                var vergil = HttpContext.Session.GetString("IdUsuario");
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
        [HttpGet]
        [Route("Perfil/Propietario")]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<PropietarioDetalleJoin> ObtenerPerfilPropietario()
        {
            string usuarioId = User.Claims.First(c => c.Type == "UsuarioID").Value;
            var usuario = await _userManager.FindByIdAsync(usuarioId).ConfigureAwait(false);
            PropietarioDetalleJoin Deallepropietario = await
                                                       (from C in _context.Propietarios
                                                        join G in _context.Generos on C.IdGenero equals G.IdGenero
                                                        join T in _context.TiposDocumentos on C.IdTipoDocumento equals T.IdTipoDocumento
                                                        join U in _context.UsuariosIdentity on C.Correo equals U.Email
                                                        join E in _context.EstadoUsuarios on U.IdEstado equals E.IdEstadoUsuario
                                                        where C.Correo == usuario.Email
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
    }
}
