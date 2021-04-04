using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCarga { get; set; }
        public int IdTipoVehiculo { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string DireccionCarga { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string DireccionEntrega { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PersonaRecibe { get; set; }
        public int CelularRecibe { get; set; }
        public int IdConductor { get; set; }
        public double PrecioServicio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEstadoServicio { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Conductore IdConductorNavigation { get; set; }
        public virtual EstadoServicio IdEstadoServicioNavigation { get; set; }
        public virtual TipoCarga IdTipoCargaNavigation { get; set; }
        public virtual TipoVehiculo IdTipoVehiculoNavigation { get; set; }
    }
}
