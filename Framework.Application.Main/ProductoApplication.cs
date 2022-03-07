//asd
using AutoMapper;
using Framework.Application.DTO;
using Framework.Application.Interface;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.Transversal.Common;
using System;
using System.Collections.Generic;

namespace Framework.Application.Main
{
    public class ProductoApplication : IProductoApplication
    {
        #region Inyección de dependencias
        private readonly IProductoDomain _productosDomain;
        
        private readonly IMapper _mapper;

        public ProductoApplication(IProductoDomain productosDomain, IMapper iMapper)
        {
            _productosDomain = productosDomain;
            _mapper = iMapper;
        }
        #endregion

        public Response<bool> Insertar(ProductoDTO productoDTO)
        {
            var response = new Response<bool>();
            try
            {
                var producto = _mapper.Map<Producto>(productoDTO);
                response.Data = _productosDomain.Insertar(producto);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro ingresado exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public Response<bool> Actualizar(ProductoDTO productoDTO)
        {
            var response = new Response<bool>();
            try
            {
                var producto = _mapper.Map<Producto>(productoDTO);
                response.Data = _productosDomain.Actualizar(producto);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro actualizado exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public Response<bool> Eliminar(int Codigo)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _productosDomain.Eliminar(Codigo);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro eliminado exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public Response<IEnumerable<ProductoDTO>> ObtenerTodos()
        {
            var response = new Response<IEnumerable<ProductoDTO>>();
            try
            {
                var producto = _productosDomain.ObtenerTodos();
                response.Data = _mapper.Map<IEnumerable<ProductoDTO>>(producto);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }


        public Response<IEnumerable<ProductoDTO>> ObtenerPorCodigo(int Codigo)
        {
            var response = new Response<IEnumerable<ProductoDTO>>();
            try
            {
                var producto = _productosDomain.ObtenerPorCodigo(Codigo);
                response.Data = _mapper.Map<IEnumerable<ProductoDTO>>(producto);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

    }
}
