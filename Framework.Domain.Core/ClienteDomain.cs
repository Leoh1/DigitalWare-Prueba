//Clase de dominio de la entidad Clientes 
using System.Collections.Generic;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;

namespace Framework.Domain.Core
{
    public class ClienteDomain : IClienteDomain{

        private readonly IClienteRepository _clientesRepository;

        public ClienteDomain(IClienteRepository clientesRepository) => _clientesRepository = clientesRepository;

        public bool Insertar(Cliente cliente)
        {
            return _clientesRepository.Insertar(cliente);
        }

        public bool Actualizar(Cliente cliente)
        {
            return _clientesRepository.Actualizar(cliente);
        }

        public bool Eliminar(string Identificacion)
        {
            return _clientesRepository.Eliminar(Identificacion);
        }

        public IEnumerable<Cliente> ObtenerTodos()
        {
            return _clientesRepository.ObtenerTodos();
        }

        public IEnumerable<Cliente> ObtenerPorIdentificacion(string Identificacion)
        {
            return _clientesRepository.ObtenerPorIdentificacion(Identificacion);
        }
    }
}
