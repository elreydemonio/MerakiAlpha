using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class Propietario
    {
        public Propietario()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }
        [Key]
        public int IdPropietario { get; set; }
        [Required(ErrorMessage = "Es requerido el tipo de email")]
        public int IdTipoDocumento { get; set; }
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "Es requerido el barrio")]
        [Column(TypeName = "varchar(100)")]
        public String Direccion { get; set; }
        [Required(ErrorMessage = "Es requerido el email")]
        [StringLength(80, ErrorMessage = ("El mail es muy largo"))]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Ingresar un email correcto")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Es requerido el nombre")]
        [StringLength(50, ErrorMessage = ("El Nombre es muy largo"))]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es requerido el apellido")]
        [StringLength(50, ErrorMessage = ("El apellido es muy largo"))]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Es requerido el numero de documento")]
        public int NumeroDocumento { get; set; }
        [Required(ErrorMessage = "Es requerido el numero de celular")]
        public int Celular { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual TiposDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
