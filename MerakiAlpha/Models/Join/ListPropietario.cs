using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models.Join
{
    public class ListPropietario
    {
        public int IdPropietario { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public string Nombre { get; set; }
        public int Celular { get; set; }
        public String IdUsuario { get; set; }
        public String Estado { get; set; }
        public int idEstado { get; set; }
    }
}
