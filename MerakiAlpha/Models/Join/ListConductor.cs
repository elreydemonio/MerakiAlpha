using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models.Join
{
    public class ListConductor
    {
        public int IdConductor { get; set; }
        public string TipoDocumento { get; set; }
        public string Genero { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public string IdUsuario { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
