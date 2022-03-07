using Framework.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Domain.Interface
{
    public interface IFacturaDomain {
        bool Insertar(Factura Factura);
        bool Actualizar(Factura Factura);
        bool Eliminar(int Codigo);
        IEnumerable<Factura>ObtenerTodos();
        IEnumerable<Factura>ObtenerPorCodigo(int Codigo);
    }
}