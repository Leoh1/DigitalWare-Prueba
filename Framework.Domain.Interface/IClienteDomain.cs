//Interfaz del dominio de la entidad Clientes
using Framework.Domain.Entity;
using System.Collections.Generic;


namespace Framework.Domain.Interface
{
    public interface IClienteDomain {
        bool Insertar(Cliente Cliente);
        bool Actualizar(Cliente Cliente);
        bool Eliminar(string Identificacion);
        IEnumerable<Cliente>ObtenerTodos();
        IEnumerable<Cliente>ObtenerPorIdentificacion(string Identificacion);
    }
}