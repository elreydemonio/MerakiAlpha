using MerakiAlpha.Usuarios;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MerakiAlpha.Models
{
    public class Role
    {
        public Role()
        {
            Usuarios = new HashSet<UsuarioIdentity>();
        }
        [Key]
        public int IdRol { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<UsuarioIdentity> Usuarios { get; set; }
    }
}
