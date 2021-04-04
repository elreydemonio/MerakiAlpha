using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Servicios = new HashSet<Servicio>();
            Vehiculos = new HashSet<Vehiculo>();
        }
        [Key]
        public int IdTipoVehiculo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
