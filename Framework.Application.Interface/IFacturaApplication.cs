//Interfaz de aplicacion de la entidad Facturas
using Framework.Application.DTO;
using Framework.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Interface
{
    public interface IFacturaApplication
    {

        Response<bool> Insertar(FacturaDTO factura);
        Response<bool> Actualizar(FacturaDTO factura);
        Response<bool> Eliminar(int Codigo);
        Response<IEnumerable<FacturaDTO>> ObtenerTodos();
        Response<IEnumerable<FacturaDTO>> ObtenerPorCodigo(int Codigo);

        #region Métodos Asincronos
        //Response<Task<bool>> InsertarAsync(FacturasDTO factura);
        //Response<Task<IEnumerable<FacturasDTO>>> ObtenerTodosAsync();
        #endregion
    }
}
