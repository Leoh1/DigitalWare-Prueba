//IRepository Detalles

using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;

namespace Framework.InfraStructure.Interface
{
    public interface IDetalleRepository {

        bool Insertar(Detalle[] Detalle);
        bool Actualizar(Detalle Detalle);
        bool UnidadesDisponibles(Detalle[] Detalle);
        bool Eliminar(int Codigo);
        IEnumerable<Detalle>ObtenerTodos();
        IEnumerable<Detalle>ObtenerPorCodigo(int Codigo);

    }
}