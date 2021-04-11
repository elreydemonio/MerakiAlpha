using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models.Join
{
    public class ListCliente
    {
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string Genero { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
    }

    //Hola x4
}
