//Interfaz del dominio de la entidad Detalles
using Framework.Domain.Entity;
using System.Collections.Generic;


namespace Framework.Domain.Interface
{
    public interface IDetalleDomain {
        bool Insertar(Detalle[] Detalle);
        bool Actualizar(Detalle Detalle);
        bool Eliminar(int Codigo);
        IEnumerable<Detalle>ObtenerTodos();
        IEnumerable<Detalle>ObtenerPorCodigo(int Codigo);
    }
}