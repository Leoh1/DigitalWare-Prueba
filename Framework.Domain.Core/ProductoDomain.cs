//Clase de dominio de la entidad Productos 
using System.Collections.Generic;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;

namespace Framework.Domain.Core
{
    public class ProductoDomain : IProductoDomain{

        private readonly IProductoRepository _productosRepository;

        public ProductoDomain(IProductoRepository productosRepository) => _productosRepository = productosRepository;

        public bool Insertar(Producto producto)
        {
            return _productosRepository.Insertar(producto);
        }

        public bool Actualizar(Producto producto)
        {
            return _productosRepository.Actualizar(producto);
        }

        public bool Eliminar(int Codigo)
        {
            return _productosRepository.Eliminar(Codigo);
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _productosRepository.ObtenerTodos();
        }

        public IEnumerable<Producto> ObtenerPorCodigo(int Codigo)
        {
            return _productosRepository.ObtenerPorCodigo(Codigo);
        }
    }
}
