//IRepository Facturas

using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;

namespace Framework.InfraStructure.Interface
{
    public interface IFacturaRepository {

        bool Insertar(Factura Factura);
        bool Actualizar(Factura Factura);
        bool Eliminar(int Codigo);
        IEnumerable<Factura>ObtenerTodos();
        IEnumerable<Factura>ObtenerPorCodigo(int Codigo);

    }
}