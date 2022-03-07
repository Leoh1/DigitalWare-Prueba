
using Framework.Application.DTO;
using Framework.Application.Interface;
using Framework.Services.WebApi.Helpers;
using Framework.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Framework.Services.WebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : Controller
    {
        #region Inyección de dependencias
        private readonly IClienteApplication _clientesApplication;

        private readonly AppSettings _appSettings;

        public ClienteController(IClienteApplication clientesApplication, IOptions<AppSettings> appSettings)
        {
            _clientesApplication = clientesApplication;
            _appSettings = appSettings.Value;
        }
        #endregion

        [HttpPost]
        public IActionResult Insertar([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest();

            var response = _clientesApplication.Insertar(clienteDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);   
            }
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest();

            var response = _clientesApplication.Actualizar(clienteDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);      
            }
        }

        [HttpDelete("{Identificacion}")]
        public IActionResult Eliminar(string Identificacion)
        {
            var response = _clientesApplication.Eliminar(Identificacion);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var response = _clientesApplication.ObtenerTodos();
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);
            
            }
        }


        [HttpGet("{Identificacion}")]
        public IActionResult ObtenerPorIdentificacion(string Identificacion)
        {
            var response = _clientesApplication.ObtenerPorIdentificacion(Identificacion);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);
            
            }
        }
    }
}
