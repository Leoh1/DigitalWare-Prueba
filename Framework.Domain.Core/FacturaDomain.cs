//Clase de dominio de la entidad Facturas 
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;

namespace Framework.Domain.Core
{
    public class FacturaDomain : IFacturaDomain{

        private readonly IFacturaRepository _facturasRepository;

        public FacturaDomain(IFacturaRepository facturasRepository) => _facturasRepository = facturasRepository;

        public bool Insertar(Factura factura)
        {
            return _facturasRepository.Insertar(factura);
        }

        public bool Actualizar(Factura factura)
        {
            return _facturasRepository.Actualizar(factura);
        }

        public bool Eliminar(int Codigo)
        {
            return _facturasRepository.Eliminar(Codigo);
        }

        public IEnumerable<Factura> ObtenerTodos()
        {
            return _facturasRepository.ObtenerTodos();
        }

        public IEnumerable<Factura> ObtenerPorCodigo(int Codigo)
        {
            return _facturasRepository.ObtenerPorCodigo(Codigo);
        }


    }
}
