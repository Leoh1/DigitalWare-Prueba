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
    public class DetalleApplication : IDetalleApplication
    {
        #region Inyección de dependencias
        private readonly IDetalleDomain _detallesDomain;
        
        private readonly IMapper _mapper;

        public DetalleApplication(IDetalleDomain detallesDomain, IMapper iMapper)
        {
            _detallesDomain = detallesDomain;
            _mapper = iMapper;
        }
        #endregion

        public Response<bool> Insertar(DetalleDTO[] detalleDTO)
        {
            var response = new Response<bool>();
            try
            {
                var detalle = _mapper.Map<Detalle[]>(detalleDTO);
                response.Data = _detallesDomain.Insertar(detalle);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro ingresado exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "No hay Stock suficiente en al menos un producto";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public Response<bool> Actualizar(DetalleDTO detalleDTO)
        {
            var response = new Response<bool>();
            try
            {
                var detalle = _mapper.Map<Detalle>(detalleDTO);
                response.Data = _detallesDomain.Actualizar(detalle);
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
                response.Data = _detallesDomain.Eliminar(Codigo);
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

        public Response<IEnumerable<DetalleDTO>> ObtenerTodos()
        {
            var response = new Response<IEnumerable<DetalleDTO>>();
            try
            {
                var detalle = _detallesDomain.ObtenerTodos();
                response.Data = _mapper.Map<IEnumerable<DetalleDTO>>(detalle);
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


        public Response<IEnumerable<DetalleDTO>> ObtenerPorCodigo(int Codigo)
        {
            var response = new Response<IEnumerable<DetalleDTO>>();
            try
            {
                var detalle = _detallesDomain.ObtenerPorCodigo(Codigo);
                response.Data = _mapper.Map<IEnumerable<DetalleDTO>>(detalle);
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
