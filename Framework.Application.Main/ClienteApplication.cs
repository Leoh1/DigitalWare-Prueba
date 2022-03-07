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
    public class ClienteApplication : IClienteApplication
    {
        #region Inyección de dependencias
        private readonly IClienteDomain _clientesDomain;
        
        private readonly IMapper _mapper;

        public ClienteApplication(IClienteDomain clientesDomain, IMapper iMapper)
        {
            _clientesDomain = clientesDomain;
            _mapper = iMapper;
        }
        #endregion

        public Response<bool> Insertar(ClienteDTO clienteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);
                response.Data = _clientesDomain.Insertar(cliente);
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

        public Response<bool> Actualizar(ClienteDTO clienteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);
                response.Data = _clientesDomain.Actualizar(cliente);
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

        public Response<bool> Eliminar(string Identificacion)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _clientesDomain.Eliminar(Identificacion);
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

        public Response<IEnumerable<ClienteDTO>> ObtenerTodos()
        {
            var response = new Response<IEnumerable<ClienteDTO>>();
            try
            {
                var cliente = _clientesDomain.ObtenerTodos();
                response.Data = _mapper.Map<IEnumerable<ClienteDTO>>(cliente);
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


        public Response<IEnumerable<ClienteDTO>> ObtenerPorIdentificacion(string Identificacion)
        {
            var response = new Response<IEnumerable<ClienteDTO>>();
            try
            {
                var cliente = _clientesDomain.ObtenerPorIdentificacion(Identificacion);
                response.Data = _mapper.Map<IEnumerable<ClienteDTO>>(cliente);
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
