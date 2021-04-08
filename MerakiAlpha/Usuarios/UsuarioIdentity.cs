﻿using MerakiAlpha.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerakiAlpha.Usuarios
{
    public class UsuarioIdentity: IdentityUser
    {
        public int idUsuario { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Nombre { get; set; }
        public int IdRol { get; set; }
        public int IdEstado { get; set; }


        public virtual EstadoUsuario IdEstadoNavigation { get; set; }
        public virtual Role IdRolNavigation { get; set; }
    }
}
