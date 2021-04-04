using MerakiAlpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Usuarios
{
    public class UsuarioModel
    {
        [Column(TypeName = "nvarchar(60)")]
        public string NombreUsuario { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string Nombre { get; set; }
        public int idUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdEstado { get; set; }
    }
}
