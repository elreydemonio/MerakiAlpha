using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models.Join
{
    public class PropietarioDetalleJoin
    {
        public int IdPropietario { get; set; }
        public String TipoDoumento { get; set; }
        public String Genero { get; set; }
        public String Direccion { get; set; }
        public String Correo { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public int Celular { get; set; }
    }
}
