using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class EstadoServicio
    {
        public EstadoServicio()
        {
            Servicios = new HashSet<Servicio>();
        }
        [Key]
        public int IdEstadoServicio { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
