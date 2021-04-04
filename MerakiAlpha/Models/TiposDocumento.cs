using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class TiposDocumento
    {
        public TiposDocumento()
        {
            Clientes = new HashSet<Cliente>();
            Conductores = new HashSet<Conductore>();
            Propietarios = new HashSet<Propietario>();
        }
        [Key]
        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Conductore> Conductores { get; set; }
        public virtual ICollection<Propietario> Propietarios { get; set; }
    }
}
