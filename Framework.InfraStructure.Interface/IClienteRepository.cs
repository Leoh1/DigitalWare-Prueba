//IRepository Clientes

using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;

namespace Framework.InfraStructure.Interface
{
    public interface IClienteRepository {

        bool Insertar(Cliente Cliente);
        bool Actualizar(Cliente Cliente);
        bool Eliminar(string Identificacion);
        IEnumerable<Cliente>ObtenerTodos();
        IEnumerable<Cliente>ObtenerPorIdentificacion(string Identificacion);

    }
}