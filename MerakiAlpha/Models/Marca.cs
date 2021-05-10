using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class Marca
    {
        public Marca()
        {
            Marcas = new HashSet<Vehiculo>();
        }
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }


        public virtual ICollection<Vehiculo> Marcas { get; set; }
    }
}
