//Interfaz de aplicacion de la entidad Productos
using Framework.Application.DTO;
using Framework.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Interface
{
    public interface IProductoApplication
    {
        
        Response<bool> Insertar(ProductoDTO producto);
        Response<bool> Actualizar(ProductoDTO producto);
        Response<bool> Eliminar(int Codigo);
        Response<IEnumerable<ProductoDTO>> ObtenerTodos();
        Response<IEnumerable<ProductoDTO>> ObtenerPorCodigo(int Codigo);

        #region Métodos Asincronos
        //Response<Task<bool>> InsertAsync(ProductosDTO producto);
        //Response<Task<IEnumerable<ProductosDTO>>> GetAllAsync();
        #endregion
    }
}
