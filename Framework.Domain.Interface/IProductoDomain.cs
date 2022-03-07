//Interfaz del dominio de la entidad Productos
using Framework.Domain.Entity;
using System.Collections.Generic;


namespace Framework.Domain.Interface
{
    public interface IProductoDomain {
        bool Insertar(Producto Producto);
        bool Actualizar(Producto Producto);
        bool Eliminar(int Codigo);
        IEnumerable<Producto>ObtenerTodos();
        IEnumerable<Producto>ObtenerPorCodigo(int Codigo);
    }
}