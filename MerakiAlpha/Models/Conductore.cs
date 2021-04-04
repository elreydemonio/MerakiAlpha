using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class Conductore
    {
        public Conductore()
        {
            Servicios = new HashSet<Servicio>();
        }
        [Key]
        public int IdConductor { get; set; }
        [Column(TypeName = "varchar(100)")]
        public String Direccion { get; set; }
        public int IdGenero { get; set; }
        public int IdTipoDocumento { get; set; }
        [Column(TypeName = "varchar(75)")]
        public string Correo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        public int Celular { get; set; }
        public int NumeroDocumento { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaInicio { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaFin { get; set; }
        public string FotoConductor { get; set; }
        public string CodigoV { get; set; }

        public virtual Vehiculo CodigoVNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual TiposDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
