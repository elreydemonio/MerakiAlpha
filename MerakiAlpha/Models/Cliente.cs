using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Servicios = new HashSet<Servicio>();
        }
        [Key]
        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdGenero { get; set; }
        [Column(TypeName = "varchar(100)")]
        public String Direccion { get; set; }
        [Column(TypeName ="varchar(75)")]
        public string Correo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public int Celular { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual TiposDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
