using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class Color
    {
        public Color()
        {
            Colores = new HashSet<Vehiculo>();
        }
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }


        public virtual ICollection<Vehiculo> Colores { get; set; }
    }
}
