
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
    public class FacturaController : Controller
    {
        #region Inyección de dependencias
        private readonly IFacturaApplication _facturasApplication;

        private readonly AppSettings _appSettings;

        public FacturaController(IFacturaApplication facturasApplication, IOptions<AppSettings> appSettings)
        {
            _facturasApplication = facturasApplication;
            _appSettings = appSettings.Value;
        }
        #endregion

        [HttpPost]
        public IActionResult Insertar([FromBody] FacturaDTO facturaDto)
        {
            if (facturaDto == null)
                return BadRequest();

            var response = _facturasApplication.Insertar(facturaDto);
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
        public IActionResult Actualizar([FromBody] FacturaDTO facturaDto)
        {
            if (facturaDto == null)
                return BadRequest();

            var response = _facturasApplication.Actualizar(facturaDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);      
            }
        }

        [HttpDelete("{Codigo}")]
        public IActionResult Eliminar(int Codigo)
        {
            var response = _facturasApplication.Eliminar(Codigo);
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
            var response = _facturasApplication.ObtenerTodos();
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);
            
            }
        }


        [HttpGet("{Codigo}")]
        public IActionResult ObtenerPorCodigo(int Codigo)
        {
            var response = _facturasApplication.ObtenerPorCodigo(Codigo);
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
