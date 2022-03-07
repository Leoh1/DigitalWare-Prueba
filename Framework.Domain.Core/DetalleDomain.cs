//Clase de dominio de la entidad Detalles 
using System.Collections.Generic;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;

namespace Framework.Domain.Core
{
    public class DetalleDomain : IDetalleDomain{

        private readonly IDetalleRepository _detallesRepository;

        public DetalleDomain(IDetalleRepository detallesRepository) => _detallesRepository = detallesRepository;

        public bool Insertar(Detalle[] detalle)
        {
            if (_detallesRepository.UnidadesDisponibles(detalle))
            {
                return _detallesRepository.Insertar(detalle);
            }
            else {
                return false;
            }
        }

        public bool Actualizar(Detalle detalle)
        {
            return _detallesRepository.Actualizar(detalle);
        }

        public bool Eliminar(int Codigo)
        {
            return _detallesRepository.Eliminar(Codigo);
        }

        public IEnumerable<Detalle> ObtenerTodos()
        {
            return _detallesRepository.ObtenerTodos();
        }

        public IEnumerable<Detalle> ObtenerPorCodigo(int Codigo)
        {
            return _detallesRepository.ObtenerPorCodigo(Codigo);
        }
    }
}
