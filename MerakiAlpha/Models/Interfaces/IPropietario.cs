using MerakiAlpha.Models.Join;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerakiAlpha.Models.Interfaces
{
    public interface IPropietario
    {
        Task<ActionResult<IEnumerable<ListPropietario>>> ListPropietarios();
        Task<Propietario> Propitario(int? id);
        Task GuardarEditar(Propietario propietario);
        Task ActivarDesactivar(int id);
        Task<PropietarioDetalleJoin> Detallepropitario(int? id);
        Task<ActionResult<IEnumerable<TiposDocumento>>> ListaTipoDocumento();
        Task<ActionResult<IEnumerable<Genero>>> ListaGenero();
        Task DeletePropietario(int? id);
        Task CambiarEstado(string id);
    }
}
