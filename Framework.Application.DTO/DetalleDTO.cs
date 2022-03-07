//DTO de la entidad Detalles
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework.Application.DTO
{
    public class DetalleDTO {
        //public IEnumerable<DetallesDTO> todos { get; set; }
        public int  Codigo { get; set; }
        public int  Cantidad { get; set; }
        public decimal  Precio { get; set; }
        public int  Factura { get; set; }
        public int  Producto { get; set; }
    } 
}