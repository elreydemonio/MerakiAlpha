using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models.Join
{
    public class DetalleConductor
    {
        public int IdConductor { get; set; }
        public String TipoDocumento { get; set; }
        public String Genero { get; set; }
        public String Correo { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public int Celular { get; set; }
        public String Direccion { get; set; }
        public String IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String FotoConductor { get; set; }
        public String CodigoV { get; set; }
    }
}
