//DTO de la entidad Productos
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework.Application.DTO
{
    public class ProductoDTO {
        public int  Codigo { get; set; }
        public string  Nombre { get; set; }
        public decimal  Precio { get; set; }
        public int Unidades { get; set; }
    } 
}