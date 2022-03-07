//DTO de la entidad Clientes
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework.Application.DTO
{
    public class ClienteDTO {
        public string  Identificacion { get; set; }
        public string  Nombre { get; set; }
        public string  Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
    } 
}