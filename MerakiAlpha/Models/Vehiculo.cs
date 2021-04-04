using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class Vehiculo
    {

        public Vehiculo()
        {
            Conductores = new HashSet<Conductore>();
        }
        [Key]
        public string CodigoV { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Color { get; set; }
        public int Cilindraje { get; set; }
        public string Soat { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string TecnoMecanica { get; set; }
        [Column(TypeName = "varchar(8)")]
        public string Placa { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string FotoV { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string SeguroCarga { get; set; }
        public int IdPropietario { get; set; }
        public int IdTipoVehiculo { get; set; }

        public virtual Propietario IdPropietarioNavigation { get; set; }
        public virtual TipoVehiculo IdTipoVehiculoNavigation { get; set; }
        public virtual ICollection<Conductore> Conductores { get; set; }
    }
}
