//Interfaz de aplicacion de la entidad Detalles
using Framework.Application.DTO;
using Framework.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Interface
{
    public interface IDetalleApplication
    {
        
        Response<bool> Insertar(DetalleDTO[] detalle);
        Response<bool> Actualizar(DetalleDTO detalle);
        Response<bool> Eliminar(int Codigo);
        Response<IEnumerable<DetalleDTO>> ObtenerTodos();
        Response<IEnumerable<DetalleDTO>> ObtenerPorCodigo(int Codigo);
        

        #region Métodos Asincronos
        //Response<Task<bool>> InsertAsync(DetallesDTO detalle);
        //Response<Task<IEnumerable<DetallesDTO>>> GetAllAsync();
        #endregion
    }
}
