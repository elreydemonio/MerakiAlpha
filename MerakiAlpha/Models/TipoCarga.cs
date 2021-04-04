using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class TipoCarga
    {
        public TipoCarga()
        {
            Servicios = new HashSet<Servicio>();
        }
        [Key]
        public int IdTipoCarga { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
