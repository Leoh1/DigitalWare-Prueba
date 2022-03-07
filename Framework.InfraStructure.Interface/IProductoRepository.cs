//IRepository Productos

using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;

namespace Framework.InfraStructure.Interface
{
    public interface IProductoRepository {

        bool Insertar(Producto Producto);
        bool Actualizar(Producto Producto);
        bool Eliminar(int Codigo);
        IEnumerable<Producto>ObtenerTodos();
        IEnumerable<Producto>ObtenerPorCodigo(int Codigo);

    }
}