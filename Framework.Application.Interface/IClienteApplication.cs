//Interfaz de aplicacion de la entidad Clientes
using Framework.Application.DTO;
using Framework.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Interface
{
    public interface IClienteApplication
    {
        
        Response<bool> Insertar(ClienteDTO cliente);
        Response<bool> Actualizar(ClienteDTO cliente);
        Response<bool> Eliminar(string Identificacion);
        Response<IEnumerable<ClienteDTO>> ObtenerTodos();
        Response<IEnumerable<ClienteDTO>> ObtenerPorIdentificacion(string Identificacion);

        #region Métodos Asincronos
        //Response<Task<bool>> InsertAsync(ClientesDTO cliente);
        //Response<Task<IEnumerable<ClientesDTO>>> GetAllAsync();
        #endregion
    }
}
